using Goleador.Application.Read.Queries;
using Goleador.Application.Read.Services;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Goleador.Application.Read.Handlers
{
    public class BuyPremiumHandler : IRequestHandler<BuyPremium, string>
    {
        private readonly IPaymentProvider _paymentProvider;

        public BuyPremiumHandler(IPaymentProvider paymentProvider)
        {
            _paymentProvider = paymentProvider;
        }

        public async Task<string> Handle(BuyPremium request, CancellationToken cancellationToken)
        {
            return (await _paymentProvider.BuyPremiumAsync()).RedirectUri;
        }
    }
}
