using Goleador.Application.Read.Queries;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Distributed;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Goleador.Web.Controllers
{
    //[Authorize]
    public class PremiumController : Controller
    {
        public PremiumController(IMediator mediator, IDistributedCache cache) : base(mediator, cache)
        {
        }

        [HttpPost("buy")]
        public async Task<IActionResult> BuyPremiumAsync()
        {
            return Ok(await _mediator.Send(new BuyPremium()));
        }
    }
}
