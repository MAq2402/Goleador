using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Goleador.Infrastructure.Payment.Models
{
    public class PayUBuyer
    {
        [JsonProperty("language")]
        public string Language { get; set; }
    }
}
