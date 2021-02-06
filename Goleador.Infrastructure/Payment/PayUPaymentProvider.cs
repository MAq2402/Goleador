using Goleador.Application.Read.Models;
using Goleador.Application.Read.Services;
using Goleador.Infrastructure.Payment.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Goleador.Infrastructure.Payment
{
    public class PayUPaymentProvider : IPaymentProvider
    {
        private HttpClient _client;

        public PayUPaymentProvider(HttpClient client)
        {
            client.BaseAddress = new Uri("https://secure.snd.payu.com/");
            _client = client;
        }

        public async Task<BuyPremiumResponse> BuyPremiumAsync()
        {
            var authorizeResponse = await _client.PostAsync("pl/standard/user/oauth/authorize", content);

            var token = JsonConvert.DeserializeObject<PayUAuthorizeResponse>(await authorizeResponse.Content.ReadAsStringAsync());
            _client.DefaultRequestHeaders.Add("Authorization", $"Bearer {token.AccessToken}");
            _client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            var requestBodyOfBuy = new StringContent(JsonConvert.SerializeObject(BuildBuyRequestBody()),
                Encoding.Default, "application/json");
            var result = await _client.PostAsync("api/v2_1/orders", requestBodyOfBuy);

            if (result.StatusCode == HttpStatusCode.Found)
            {
                return new BuyPremiumResponse()
                {
                    RedirectUri = JsonConvert.DeserializeObject<BuyPremiumResponse>(await result.Content.ReadAsStringAsync()).RedirectUri,
                    Success = true
                };
            }
            else
            {
                return new BuyPremiumResponse()
                {
                    Success = false
                };
            }
        }

        private PayUOrderRequest BuildBuyRequestBody()
        {
            return new PayUOrderRequest
            {
                NotifyUrl = "http://goleador.com",
                CustomerIp = "127.0.0.1",
                MerchantPosId = "403050",
                Description = "Premium",
                CurrencyCode = "PLN",
                TotalAmount = "100",
                Buyer = new PayUBuyer()
                {
                    Language = "pl"
                },
                Products = new List<PayUProduct>
                {
                    new PayUProduct
                    {
                        Name = "Premium",
                        UnitPrice = "100",
                        Quantity = "1"
                    }
                }
            };
        }
    }
}
