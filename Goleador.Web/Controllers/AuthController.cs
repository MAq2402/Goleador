using Goleador.Application.Read.Queries;
using Goleador.Application.Write.Commands;
using Goleador.Application.Write.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Goleador.Web.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private IMediator _mediator;

        public AuthController(IMediator mediator)
        {
            _mediator = mediator;
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

        //[Authorize]
        //[HttpGet("user")]
        //public async Task<IActionResult> GetCurrentUser()
        //{
        //    var userId = User.Claims.FirstOrDefault(c => c.Type == Constants.UserId)?.Value;

        //    var result = await QueryAsync(new GetUserQuery(userId));

        //    return result.IsSuccess ? (IActionResult)Ok(result.Value) : NotFound(result.Error);
        //}
    }
}
