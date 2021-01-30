using Goleador.Application.Read.Queries;
using Goleador.Application.Write.Commands;
using Goleador.Application.Write.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Distributed;
using System.Threading.Tasks;

namespace Goleador.Web.Controllers
{
    public class AuthController : Controller
    {
        public AuthController(IMediator mediator, IDistributedCache cache) : base(mediator, cache)
        {
        }

        [HttpPost("register")]
        public async Task<IActionResult> RegisterAsync([FromBody] UserForCreationDto model)
        {
            var command = new Register(model.UserName, model.Password);

            await _mediator.Send(command);

            return NoContent();
        }

        [HttpPost("login")]
        public async Task<IActionResult> LoginAsync([FromBody] LoginCredentialsDto model)
        {
            var query = new LoginQuery(model.UserName, model.Password);

            return Ok(await _mediator.Send(query));
        }
    }
}
