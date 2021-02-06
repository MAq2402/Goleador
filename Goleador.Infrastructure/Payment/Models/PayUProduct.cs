using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Goleador.Infrastructure.Payment.Models
{
    public class PayUProduct
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("unitPrice")]
        public string UnitPrice { get; set; }

        [JsonProperty("quantity")]
        public string Quantity { get; set; }
    }
}
