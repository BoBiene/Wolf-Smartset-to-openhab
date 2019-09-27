using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace WolfSmartsetCollector.JSON
{
    public partial class GetSystemStateListResponse
    {
        [JsonProperty("SystemId")]
        public long SystemId { get; set; }

        [JsonProperty("GatewayState")]
        public GatewayState GatewayState { get; set; }

        [JsonProperty("AccessLevel")]
        public long AccessLevel { get; set; }

        [JsonProperty("IsSystemShareDeleted")]
        public bool IsSystemShareDeleted { get; set; }

        [JsonProperty("IsSystemShareRejected")]
        public bool IsSystemShareRejected { get; set; }

        [JsonProperty("IsSystemDeleted")]
        public bool IsSystemDeleted { get; set; }
    }

    public partial class GatewayState
    {
        [JsonProperty("GatewayId")]
        public long GatewayId { get; set; }

        [JsonProperty("IsOnline")]
        public bool IsOnline { get; set; }

        [JsonProperty("GatewayOfflineCause")]
        public long GatewayOfflineCause { get; set; }

        [JsonProperty("IsLocked")]
        public bool IsLocked { get; set; }

        [JsonProperty("IsDeleted")]
        public bool IsDeleted { get; set; }

        [JsonProperty("IsBusy")]
        public bool IsBusy { get; set; }

        [JsonProperty("ImageName")]
        public string ImageName { get; set; }
    }
}
