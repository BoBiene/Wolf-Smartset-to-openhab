using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace WolfSmartsetCollector.JSON
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Globalization;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;

    public partial class GuiDescriptionForGatewayResponse
    {
        [JsonProperty("MenuItems")]
        public List<MenuItem> MenuItems { get; set; }

        [JsonProperty("DynFaultMessageDevices")]
        public List<object> DynFaultMessageDevices { get; set; }

        [JsonProperty("SystemHasWRSClassicDevices")]
        public bool SystemHasWrsClassicDevices { get; set; }
    }

    [DebuggerDisplay("{Name}")]
    public partial class MenuItem
    {
        [JsonProperty("Name")]
        public string Name { get; set; }

        [JsonProperty("SortId")]
        public string SortId { get; set; }

        [JsonProperty("SubMenuEntries")]
        public List<SubMenuEntry> SubMenuEntries { get; set; }

        [JsonProperty("ParameterNode")]
        public bool ParameterNode { get; set; }

        [JsonProperty("ImageName")]
        public string ImageName { get; set; }

        [JsonProperty("TabViews")]
        public List<MenuItemTabView> TabViews { get; set; }
    }

    [DebuggerDisplay("{Name}")]
    public partial class SubMenuEntry
    {
        [JsonProperty("Name")]
        public string Name { get; set; }

        [JsonProperty("SortId")]
        public string SortId { get; set; }

        [JsonProperty("SubMenuEntries")]
        public List<object> SubMenuEntries { get; set; }

        [JsonProperty("ParameterNode")]
        public bool ParameterNode { get; set; }

        [JsonProperty("ImageName")]
        public string ImageName { get; set; }

        [JsonProperty("TabViews")]
        public List<MenuItemTabView> TabViews { get; set; }
    }

   

    public partial class ConfigComboBoxParameterDescDto
    {
        [JsonProperty("ValueId")]
        public long ValueId { get; set; }

        [JsonProperty("SortId")]
        public long SortId { get; set; }

        [JsonProperty("SubBundleId")]
        public long SubBundleId { get; set; }

        [JsonProperty("ParameterId")]
        public long ParameterId { get; set; }

        [JsonProperty("IsReadOnly")]
        public bool IsReadOnly { get; set; }

        [JsonProperty("NoDataPoint")]
        public bool NoDataPoint { get; set; }

        [JsonProperty("IsExpertProtectable")]
        public bool IsExpertProtectable { get; set; }

        [JsonProperty("Name")]
        public string Name { get; set; }

        [JsonProperty("ControlType")]
        public long ControlType { get; set; }

        [JsonProperty("ValueState")]
        public long ValueState { get; set; }

        [JsonProperty("HasDependentParameter")]
        public bool HasDependentParameter { get; set; }

        [JsonProperty("ChildParameterDescriptors", NullValueHandling = NullValueHandling.Ignore)]
        public List<ParameterDescriptor> ChildParameterDescriptors { get; set; }

        [JsonProperty("Value", NullValueHandling = NullValueHandling.Ignore)]
        public string Value { get; set; }
    }
    [DebuggerDisplay("{Name}")]
    public partial class ParameterDescriptor:IParameter
    {
        [JsonProperty("ValueId")]
        public long ValueId { get; set; }

        [JsonProperty("SortId")]
        public long SortId { get; set; }

        [JsonProperty("SubBundleId")]
        public long SubBundleId { get; set; }

        [JsonProperty("ParameterId")]
        public long ParameterId { get; set; }

        [JsonProperty("IsReadOnly")]
        public bool IsReadOnly { get; set; }

        [JsonProperty("NoDataPoint")]
        public bool NoDataPoint { get; set; }

        [JsonProperty("IsExpertProtectable")]
        public bool IsExpertProtectable { get; set; }

        [JsonProperty("Name")]
        public string Name { get; set; }

        [JsonProperty("Group")]
        public string Group { get; set; }

        [JsonProperty("ControlType")]
        public long ControlType { get; set; }

        [JsonProperty("Value")]
        public string Value { get; set; }

        [JsonProperty("ValueState")]
        public long ValueState { get; set; }

        [JsonProperty("HasDependentParameter")]
        public bool HasDependentParameter { get; set; }

        [JsonProperty("ListItems", NullValueHandling = NullValueHandling.Ignore)]
        public List<ListItem> ListItems { get; set; }

        [JsonProperty("ProtGrp", NullValueHandling = NullValueHandling.Ignore)]
        public ProtGrp? ProtGrp { get; set; }

        [JsonProperty("Unit", NullValueHandling = NullValueHandling.Ignore)]
        public Unit? Unit { get; set; }

        [JsonProperty("Decimals", NullValueHandling = NullValueHandling.Ignore)]
        public long? Decimals { get; set; }

        [JsonProperty("MinValueCondition", NullValueHandling = NullValueHandling.Ignore)]
        public string MinValueCondition { get; set; }

        [JsonProperty("MaxValueCondition", NullValueHandling = NullValueHandling.Ignore)]
        public string MaxValueCondition { get; set; }

        [JsonProperty("MinValue", NullValueHandling = NullValueHandling.Ignore)]
        public long? MinValue { get; set; }

        [JsonProperty("MaxValue", NullValueHandling = NullValueHandling.Ignore)]
        public long? MaxValue { get; set; }

        [JsonProperty("StepWidth", NullValueHandling = NullValueHandling.Ignore)]
        public double? StepWidth { get; set; }

        [JsonProperty("ChildParameterDescriptors", NullValueHandling = NullValueHandling.Ignore)]
        public List<ConfigComboBoxParameterDescDto> ChildParameterDescriptors { get; set; }

        [JsonProperty("NamePrefix", NullValueHandling = NullValueHandling.Ignore)]
        public string NamePrefix { get; set; }

        [JsonProperty("TurnOffValue", NullValueHandling = NullValueHandling.Ignore)]
        public long? TurnOffValue { get; set; }
    }

    public partial class ListItem
    {
        [JsonProperty("Value")]
        public string Value { get; set; }

        [JsonProperty("DisplayText")]
        public string DisplayText { get; set; }

        [JsonProperty("ImageName", NullValueHandling = NullValueHandling.Ignore)]
        public string ImageName { get; set; }

        [JsonProperty("IsSelectable")]
        public bool IsSelectable { get; set; }

        [JsonProperty("HighlightIfSelected")]
        public bool HighlightIfSelected { get; set; }
    }

    public partial class SchemaTabViewConfigDto
    {
        [JsonProperty("Configs")]
        public List<Config> Configs { get; set; }

        [JsonProperty("ConfigComboBoxParameterDescDTO")]
        public ConfigComboBoxParameterDescDto ConfigComboBoxParameterDescDto { get; set; }
    }

    public partial class Config
    {
        [JsonProperty("ConfigIndex")]
        public long ConfigIndex { get; set; }

        [JsonProperty("ConfigName")]
        public string ConfigName { get; set; }

        [JsonProperty("ConfigDesc")]
        public string ConfigDesc { get; set; }

        [JsonProperty("ImageName")]
        public string ImageName { get; set; }

        [JsonProperty("Parameters")]
        public List<Parameter> Parameters { get; set; }
    }

    public interface IParameter
    {
        long ControlType { get; set; }
        long? Decimals { get; set; }
        List<ListItem> ListItems { get; set; }
        string Name { get; set; }
        long ParameterId { get; set; }
        long ValueId { get; }
        Unit? Unit { get; set; }
        string Value { get; set; }
    }

    public partial class Parameter : IParameter
    {
        [JsonProperty("PortName")]
        public string PortName { get; set; }

        [JsonProperty("PortDesc")]
        public string PortDesc { get; set; }

        [JsonProperty("ValueId")]
        public long ValueId { get; set; }

        [JsonProperty("ParameterId")]
        public long ParameterId { get; set; }

        [JsonProperty("Value")]
        public string Value { get; set; }

        [JsonProperty("ControlType")]
        public long ControlType { get; set; }

        [JsonProperty("ValueState")]
        public long ValueState { get; set; }

        [JsonProperty("ProtGrp")]
        public ProtGrp ProtGrp { get; set; }

        [JsonProperty("Unit", NullValueHandling = NullValueHandling.Ignore)]
        public Unit? Unit { get; set; }

        [JsonProperty("Decimals", NullValueHandling = NullValueHandling.Ignore)]
        public long? Decimals { get; set; }

        [JsonProperty("Name")]
        public string Name { get; set; }

        [JsonProperty("ListItems", NullValueHandling = NullValueHandling.Ignore)]
        public List<ListItem> ListItems { get; set; }
    }
    [DebuggerDisplay("{GroupName}")]
    public partial class TabViewGroup
    {
        [JsonProperty("GroupName")]
        public string GroupName { get; set; }

        [JsonProperty("IsTitleEditable")]
        public bool IsTitleEditable { get; set; }
    }
    [DebuggerDisplay("{TabName}")]
    public partial class MenuItemTabView
    {
        [JsonProperty("IsExpertView")]
        public bool IsExpertView { get; set; }

        [JsonProperty("TabName")]
        public string TabName { get; set; }

        [JsonProperty("GuiId")]
        public long GuiId { get; set; }

        [JsonProperty("BundleId")]
        public long BundleId { get; set; }

        [JsonProperty("ParameterDescriptors")]
        public List<ParameterDescriptor> ParameterDescriptors { get; set; }

        [JsonProperty("ViewType")]
        public long ViewType { get; set; }

        [JsonProperty("SvgSchemaDeviceId")]
        public long SvgSchemaDeviceId { get; set; }

        [JsonProperty("GetValueLastAccess")]
        public DateTimeOffset GetValueLastAccess { get; set; }

        [JsonProperty("TabViewGroups")]
        public List<TabViewGroup> TabViewGroups { get; set; }

        [JsonProperty("SchemaTabViewConfigDTO", NullValueHandling = NullValueHandling.Ignore)]
        public SchemaTabViewConfigDto SchemaTabViewConfigDto { get; set; }
    }


    public enum ProtGrp { Bm0, Dhk0, Hg1, Sm10 };

    public enum Unit { C, Empty, K, KK, LMin, Min, Std, UMin, Uhr, Wochen };



    internal static class GuiDescriptionForGatewayResponseConverter
    {
        public static readonly JsonSerializerSettings Settings = new JsonSerializerSettings
        {
            MetadataPropertyHandling = MetadataPropertyHandling.Ignore,
            DateParseHandling = DateParseHandling.None,
            Converters =
            {
                ProtGrpConverter.Singleton,
                UnitConverter.Singleton,
                new IsoDateTimeConverter { DateTimeStyles = DateTimeStyles.AssumeUniversal }
            },
        };
    }

    internal class ProtGrpConverter : JsonConverter
    {
        public override bool CanConvert(Type t) => t == typeof(ProtGrp) || t == typeof(ProtGrp?);

        public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null) return null;
            var value = serializer.Deserialize<string>(reader);
            switch (value)
            {
                case "BM <0>":
                    return ProtGrp.Bm0;
                case "DHK <0>":
                    return ProtGrp.Dhk0;
                case "HG <1>":
                    return ProtGrp.Hg1;
                case "SM1 <0>":
                    return ProtGrp.Sm10;
            }
            throw new Exception("Cannot unmarshal type ProtGrp");
        }

        public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
        {
            if (untypedValue == null)
            {
                serializer.Serialize(writer, null);
                return;
            }
            var value = (ProtGrp)untypedValue;
            switch (value)
            {
                case ProtGrp.Bm0:
                    serializer.Serialize(writer, "BM <0>");
                    return;
                case ProtGrp.Dhk0:
                    serializer.Serialize(writer, "DHK <0>");
                    return;
                case ProtGrp.Hg1:
                    serializer.Serialize(writer, "HG <1>");
                    return;
                case ProtGrp.Sm10:
                    serializer.Serialize(writer, "SM1 <0>");
                    return;
            }
            throw new Exception("Cannot marshal type ProtGrp");
        }

        public static readonly ProtGrpConverter Singleton = new ProtGrpConverter();
    }

    internal class UnitConverter : JsonConverter
    {
        public override bool CanConvert(Type t) => t == typeof(Unit) || t == typeof(Unit?);

        public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null) return null;
            var value = serializer.Deserialize<string>(reader);
            switch (value)
            {
                case "%":
                    return Unit.Empty;
                case "K":
                    return Unit.K;
                case "K/K":
                    return Unit.KK;
                case "Std":
                    return Unit.Std;
                case "U/min":
                    return Unit.UMin;
                case "Uhr":
                    return Unit.Uhr;
                case "Wochen":
                    return Unit.Wochen;
                case "l/min":
                    return Unit.LMin;
                case "min":
                    return Unit.Min;
                case "°C":
                    return Unit.C;
            }
            throw new Exception("Cannot unmarshal type Unit");
        }

        public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
        {
            if (untypedValue == null)
            {
                serializer.Serialize(writer, null);
                return;
            }
            var value = (Unit)untypedValue;
            switch (value)
            {
                case Unit.Empty:
                    serializer.Serialize(writer, "%");
                    return;
                case Unit.K:
                    serializer.Serialize(writer, "K");
                    return;
                case Unit.KK:
                    serializer.Serialize(writer, "K/K");
                    return;
                case Unit.Std:
                    serializer.Serialize(writer, "Std");
                    return;
                case Unit.UMin:
                    serializer.Serialize(writer, "U/min");
                    return;
                case Unit.Uhr:
                    serializer.Serialize(writer, "Uhr");
                    return;
                case Unit.Wochen:
                    serializer.Serialize(writer, "Wochen");
                    return;
                case Unit.LMin:
                    serializer.Serialize(writer, "l/min");
                    return;
                case Unit.Min:
                    serializer.Serialize(writer, "min");
                    return;
                case Unit.C:
                    serializer.Serialize(writer, "°C");
                    return;
            }
            throw new Exception("Cannot marshal type Unit");
        }

        public static readonly UnitConverter Singleton = new UnitConverter();
    }
}
