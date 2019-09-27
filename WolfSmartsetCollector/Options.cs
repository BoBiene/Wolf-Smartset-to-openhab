using CommandLine;
using CommandLine.Text;
using System;
using System.Collections.Generic;
using System.Text;

namespace WolfSmartsetCollector
{
    class Options
    {
        [Option('u',Required =true)]
        public string UserName { get; set; }

        [Option('p', Required = true)]
        public string Password { get; set; }

        [Option('o', "output", Required = false, HelpText = "Target directory to create the openHAB files in.")]
        public string OutputDir { get; set; }
    }
}
