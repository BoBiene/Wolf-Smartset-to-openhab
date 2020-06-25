using CommandLine;
using CommandLine.Text;
using System;
using System.Collections.Generic;
using System.Text;

namespace WolfSmartsetCollector
{
    class Options
    {
        [Option('u',Required =true, HelpText = "Username to authenticate at https://www.wolf-smartset.com/")]
        public string UserName { get; set; }

        [Option('p', Required = true, HelpText = "Password to authenticate at https://www.wolf-smartset.com/")]
        public string Password { get; set; }

        [Option('d', Required = false, Default = false, HelpText ="Store reponses on disk")]
        public bool DumpResponse { get; set; } = false;

        [Option('e', Required = false, Default = false,HelpText ="Throw rest and json srialize exceptions")]
        public bool RestThrowOnAnyError { get; set; } = false;

        [Option('m', Required =false,Default =false, HelpText ="When set, http-requests will be skipped an the json files cached on disk will be used")]
        public bool MockWithCachedResponses { get; set; } = false;

        [Option('o', "output", Required = false, Default = "generated", HelpText = "Target directory to create the openHAB files in.")]
        public string OutputDir { get; set; } = "generated";

        [Option('s',"systems",HelpText ="List of system ids to process; leave empty to process all")]
        public IEnumerable<long> SystemIds { get; set; }

        [Option("pathToScript", Default = "/etc/openhab2/scripts/")]
        public string PathToScripts { get; set; } = "/etc/openhab2/scripts/";


    }
}
