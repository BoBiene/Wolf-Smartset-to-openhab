using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace WolfSmartsetCollector.JSON
{

    public partial class WolfSystem
    {
        [JsonProperty("Id")]
        public long Id { get; set; }

        [JsonProperty("GatewayId")]
        public long GatewayId { get; set; } 

        [JsonProperty("IsForeignSystem")]
        public bool IsForeignSystem { get; set; }

        [JsonProperty("AccessLevel")]
        public long AccessLevel { get; set; }

        [JsonProperty("GatewayUsername")]
        public string GatewayUsername { get; set; }

        [JsonProperty("Name")]
        public string Name { get; set; }

        [JsonProperty("SystemShares")]
        public List<object> SystemShares { get; set; }

        [JsonProperty("GatewaySoftwareVersion")]
        public string GatewaySoftwareVersion { get; set; }
    }
}
