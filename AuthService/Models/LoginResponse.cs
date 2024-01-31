using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JwtAuthenticationManager.Models
{
    public class LoginResponse
    {
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string Name { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string Email { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string JwtToken { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public int ExpiresIn { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public bool Success { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string Message { get; set; }

    }
}
