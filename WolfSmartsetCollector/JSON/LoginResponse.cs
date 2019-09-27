using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace WolfSmartsetCollector.JSON
{
    public partial class LoginResponse
    {
        [JsonProperty("access_token")]
        public string AccessToken { get; set; }

        [JsonProperty("expires_in")]
        public long ExpiresIn { get; set; }

        [JsonProperty("token_type")]
        public string TokenType { get; set; }

        [JsonProperty("refresh_token")]
        public string RefreshToken { get; set; }

        [JsonProperty("scope")]
        public string Scope { get; set; }

        [JsonProperty("CultureInfoCode")]
        public string CultureInfoCode { get; set; }

        [JsonProperty("IsPasswordReset")]
        public bool IsPasswordReset { get; set; }

        [JsonProperty("IsProfessional")]
        public bool IsProfessional { get; set; }

        [JsonProperty("IsProfessionalPasswordReset")]
        public bool IsProfessionalPasswordReset { get; set; }
    }
}
