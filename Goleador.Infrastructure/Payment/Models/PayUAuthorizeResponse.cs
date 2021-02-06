using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Goleador.Infrastructure.Payment.Models
{
    public class PayUAuthorizeResponse
    {
        [JsonProperty("access_token")]
        public string AccessToken { get; set; }
    }
}
