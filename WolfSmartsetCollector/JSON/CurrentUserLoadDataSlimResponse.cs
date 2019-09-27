using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace WolfSmartsetCollector.JSON
{
    public partial class CurrentUserLoadDataSlimResponse
    {
        [JsonProperty("IsPasswordReset")]
        public bool IsPasswordReset { get; set; }

        [JsonProperty("UserName")]
        public string UserName { get; set; }

        [JsonProperty("UserSalutationType")]
        public long UserSalutationType { get; set; }

        [JsonProperty("Firstname")]
        public string Firstname { get; set; }

        [JsonProperty("Surname")]
        public string Surname { get; set; }

        [JsonProperty("CompanyName")]
        public string CompanyName { get; set; }

        [JsonProperty("CustomerNumber")]
        public string CustomerNumber { get; set; }

        [JsonProperty("StreetName")]
        public string StreetName { get; set; }

        [JsonProperty("StreetNumber")]
        public string StreetNumber { get; set; }

        [JsonProperty("ZipCode")]
        public long ZipCode { get; set; }

        [JsonProperty("City")]
        public string City { get; set; }

        [JsonProperty("CultureInfoCode")]
        public string CultureInfoCode { get; set; }

        [JsonProperty("TwoLetterCountryCode")]
        public string TwoLetterCountryCode { get; set; }

        [JsonProperty("Email")]
        public string Email { get; set; }

        [JsonProperty("MaxSystemBusSamplingRateSec")]
        public long MaxSystemBusSamplingRateSec { get; set; }
    }
}
