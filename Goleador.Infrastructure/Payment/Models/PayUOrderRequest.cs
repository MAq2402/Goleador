using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Goleador.Infrastructure.Payment.Models
{
    public class PayUOrderRequest
    {
        [JsonProperty("notifyUrl")]
        public string NotifyUrl { get; set; }

        [JsonProperty("customerIp")]
        public string CustomerIp { get; set; }

        [JsonProperty("merchantPosId")]
        public string MerchantPosId { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("currencyCode")]
        public string CurrencyCode { get; set; }

        [JsonProperty("totalAmount")]
        public string TotalAmount { get; set; }

        [JsonProperty("products")]
        public IEnumerable<PayUProduct> Products { get; set; }

        [JsonProperty("buyer")]
        public PayUBuyer Buyer { get; set; }
    }
}
