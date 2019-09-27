using CommandLine;
using Newtonsoft.Json;
using RestSharp;
using RestSharp.Authenticators;
using RestSharp.Serialization;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using WolfSmartsetCollector.JSON;

namespace WolfSmartsetCollector
{
    class Program
    {
      
        static void Main(string[] args)
        {
            try
            {
                Parser.Default.ParseArguments<Options>(args)
                 .WithParsed<Options>(Run);
                    
            }
            catch (Exception ex)
            {
                Console.WriteLine("Failed: " + ex.ToString());
            }
        }

        static void Run(Options options)
        {
            using (StreamWriter rulesFile = CreateRules(options))
            {
                using (StreamWriter itemsFile = CreateConfigFile(options, "items\\wolf_smartset.items"))
                {
                    using (StreamWriter sitemapFile = CreateSitemap(options))
                    {

                        Dictionary<Type, JsonSerializerSettings> typeSerializer = new Dictionary<Type, JsonSerializerSettings>();

                        typeSerializer.Add(typeof(GuiDescriptionForGatewayResponse), GuiDescriptionForGatewayResponseConverter.Settings);
                        var client = new RestClient("https://www.wolf-smartset.com/")
                             .UseSerializer(() => new JsonNetSerializer(t => typeSerializer.TryGetValue(t, out var s) ? s : null));



                        var loginRequest = new RestRequest("portal/connect/token2", Method.POST);
                        loginRequest.AddParameter("grant_type", "password");
                        loginRequest.AddParameter("username", options.UserName);
                        loginRequest.AddParameter("password", options.Password);
                        loginRequest.AddParameter("client_id", "ro.client");
                        loginRequest.AddParameter("scope", "offline_access openid api");
                        loginRequest.AddParameter("website_version", "29");

                  
                        var loginResponse = client.Execute<LoginResponse>(loginRequest);

                        if (loginResponse.StatusCode == HttpStatusCode.OK)
                        {
                            var token = loginResponse.Data;
                            client.Authenticator = new JwtAuthenticator(token.AccessToken);
                         
                            var systemListResponse = client.Execute<List<WolfSystem>>(new RestRequest("portal/api/portal/GetSystemList", Method.GET));
                            HashSet<string> createdItems = new HashSet<string>();
                            Dictionary<long, List<string>> mapValues = new Dictionary<long, List<string>>();
                            foreach (var system in systemListResponse.Data)
                            {
                                var guiDescriptionForGatewayResponse = client.Execute<GuiDescriptionForGatewayResponse>(
                                     new RestRequest("portal/api/portal/GetGuiDescriptionForGateway", Method.GET)
                                     .AddParameter("GatewayId", system.GatewayId)
                                     .AddParameter("SystemId", system.Id));

                                rulesFile.Write($@"
rule ""Refresh {system.Name}""
    when System started or Time cron ""0 0/1 * 1/1 * ? *""
then
    var String jsonToken =  executeCommandLine(""bash@@/openhab/conf/scripts/request_token.sh@@{options.UserName}@@{Uri.EscapeDataString(options.Password)}"",5000)
    var String token = transform(""JSONPATH"",""$.access_token"",jsonToken);
    var String jsonValues =  executeCommandLine(""bash@@/openhab/conf/scripts/request_values.sh@@""+token+""@@{system.GatewayId}@@{system.Id}"",5000)
");

                                var fachmannNode = guiDescriptionForGatewayResponse.Data.MenuItems.Find(m => m.Name == "Fachmann");
                                foreach (var submenu in fachmannNode.SubMenuEntries)
                                {

                                    foreach (var tabView in submenu.TabViews)
                                    {
                                        string tabViewName = (string.IsNullOrWhiteSpace(tabView.TabName) || tabView.TabName == "NULL") ? string.Empty : tabView.TabName;

                                        string grpName = (submenu.Name + (string.IsNullOrWhiteSpace(tabViewName) ? "" : "_" + tabViewName)).Escape();
                                        itemsFile.WriteLine($"Group {grpName} \"{submenu.Name}{(string.IsNullOrWhiteSpace(tabViewName) ? "" : " - " + tabViewName)}\"");
                                        sitemapFile.WriteLine($"Group item={grpName} ");

                                        foreach (var parameter in tabView.ParameterDescriptors)
                                        {
                                            AddParameter(rulesFile, itemsFile, createdItems, mapValues, grpName, parameter);
                                        }

                                        if (tabView?.SchemaTabViewConfigDto?.Configs != null)
                                            foreach (var cfg in tabView.SchemaTabViewConfigDto.Configs)
                                            {
                                                foreach (var parameter in cfg.Parameters)
                                                {
                                                    AddParameter(rulesFile, itemsFile, createdItems, mapValues, grpName, parameter);
                                                }
                                            }

                                        //$.MenuItems[?(@.Name="Fachmann")]..ParameterDescriptors[?(@.ParameterId=800400001)].Value
                                    }
                                }

                                rulesFile.WriteLine("end");
                            }
                        }
                        else
                        {
                            //Login failed
                        }
                        sitemapFile.WriteLine("}");
                    }
                }
            }
            DirectoryInfo confDir = new DirectoryInfo(options.OutputDir);
            Console.WriteLine("Created config files at " + confDir.FullName);
        }

        private static void AddParameter(StreamWriter rulesFile, StreamWriter itemsFile, 
            HashSet<string> createdItems, Dictionary<long, List<string>> mapValues, string grpName, IParameter parameter)
        {
            var itemName = grpName + "_" + parameter.Name.Escape();
            if (!createdItems.Contains(itemName))
            {
                createdItems.Add(itemName);
                if (!mapValues.TryGetValue(parameter.ControlType, out var values))
                    mapValues[parameter.ControlType] = values = new List<string>();

                values.Add(parameter.Value);



                string strItemType = "String";
                string strFormatString = "s";
                bool blnType = false;
                switch (parameter.ControlType)
                {
                    case 1:

                    case 3:
                    case 6:
                    case 8:
                        strItemType = "Number";
                        strFormatString = $".{parameter.Decimals ?? 0}f";
                        break;
                    case 5:
                        strItemType = "Contact";
                        blnType = true;
                        break;
                    case 9:
                    case 10:
                        strItemType = "DateTime";
                        break;
                }

                itemsFile.WriteLine($"{strItemType} {itemName} \"{parameter.Name} [%{strFormatString}{GetUnit(parameter.Unit)}]\" ({grpName})");
                rulesFile.WriteLine("\ttry {");
                rulesFile.WriteLine($"\t\tvar String {itemName}Value = transform(\"JSONPATH\",'$..ParameterDescriptors[?(@.ParameterId=={parameter.ParameterId})].Value',jsonValues)");

                rulesFile.WriteLine($"\t\tif({itemName}Value.startsWith(\"[\") && {itemName}Value.endsWith(\"]\"))");
                rulesFile.WriteLine($"\t\t\t{itemName}Value = transform(\"JSONPATH\",'$[-1]',{itemName}Value)");
                rulesFile.WriteLine($"\t\tlogInfo(\"Wolf\",\"{itemName}=\"+{itemName}Value)");

                if (blnType)
                {
                    rulesFile.WriteLine($"\t\t\tif({itemName}Value.equals(\"True\") && {itemName}.state != ON)");
                    rulesFile.WriteLine($"\t\t\t\t{itemName}.postUpdate(ON)");
                    rulesFile.WriteLine($"\t\t\telse if({itemName}.state != OFF)");
                    rulesFile.WriteLine($"\t\t\t\t{itemName}.postUpdate(OFF)");
                }
                else
                {
                    rulesFile.WriteLine($"\t\tif({itemName}.state != {itemName}Value)");
                    rulesFile.WriteLine($"\t\t\t{itemName}.postUpdate({itemName}Value)");
                }
                rulesFile.WriteLine("\t} catch(Throwable t) {");
                rulesFile.WriteLine($"\t\tlogError(\"Error\", \"Failed to refresh value for {itemName}: \" + t.toString)");
                rulesFile.WriteLine("\t}");
                rulesFile.WriteLine();
            }
            else
            {
                //Ignore
            }
        }

        private static object GetUnit(Unit? unit)
        {
            if (!unit.HasValue)
                return string.Empty;

            switch (unit.Value)
            {
                case Unit.C:
                    return " °C";
                case Unit.K:
                    return " K";
                case Unit.KK:
                    return " K/K";
                case Unit.LMin:
                    return " l/min";
                case Unit.Min:
                    return " min";
                case Unit.Std:
                    return " Std";
                case Unit.UMin:
                    return " U/min";
                case Unit.Uhr:
                    return " Uhr";
                case Unit.Wochen:
                    return " Wochen";
                case Unit.Empty:
                    return " %%";
                default:
                    return string.Empty;
            }

        }

        private static int GetNumbers(Random random, int numbers)
        {
            int nRet = 0;
            for (int i = 0; i < numbers; ++i)
            {
                nRet += random.Next(0, 9) * (int)Math.Pow(10, (i + 1));
            }

            return nRet;
        }

        private static IEnumerable<char> Escape(string strRoomName)
        {
            foreach (char c in strRoomName)
                if (!char.IsWhiteSpace(c))
                    if (char.IsLetterOrDigit(c))
                    {
                        switch (c)
                        {
                            case 'ü':
                                yield return 'u';
                                yield return 'e';
                                break;
                            case 'Ü':
                                yield return 'U';
                                yield return 'e';
                                break;
                            case 'ä':
                                yield return 'a';
                                yield return 'e';
                                break;
                            case 'Ä':
                                yield return 'A';
                                yield return 'e';
                                break;
                            case 'Ö':
                                yield return 'O';
                                yield return 'e';
                                break;
                            case 'ö':
                                yield return 'o';
                                yield return 'e';
                                break;
                            case 'ß':
                                yield return 's';
                                yield return 's';
                                break;
                            default:
                                yield return c;
                                break;
                        }
                    }
                    else
                        yield return '_';
        }

        private static StreamWriter CreateRules(Options options)
        {
            var writer = CreateConfigFile(options, "rules\\wolf_smartset.rules");
           
            return writer;
        }
        private static StreamWriter CreateConfigFile(Options options, string strName)
        {
            string strPath = Path.Combine(options.OutputDir,strName);
            FileInfo f = new FileInfo(strPath);
            if (!f.Directory.Exists)
                f.Directory.Create();

            Stream s = File.Open(strPath, FileMode.Create, FileAccess.ReadWrite, FileShare.Read);
            return new StreamWriter(s);
        }


        private static StreamWriter CreateSitemap(Options options)
        {
            var writer = CreateConfigFile(options, "sitemaps\\wolf_smartset.sitemap");

            writer.WriteLine("sitemap wolf_smartset label=\"Wolf Smartset\" icon=\"heating\" {");

            return writer;
        }
    }
}
