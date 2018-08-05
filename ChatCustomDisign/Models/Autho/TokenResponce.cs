using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace ChatCustomDisign.Models.Autho
{
    public class TokenResponce
    {
        [JsonProperty("access_token")]
        public string Token { get; set; }

        [JsonProperty("expires_in")]
        public long Time { get; set; }

        [JsonProperty("token_type")]
        public string TokenType { get; set; }
        
    }
}
