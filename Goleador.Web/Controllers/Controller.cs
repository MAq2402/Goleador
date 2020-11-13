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
    public class Controller : ControllerBase
    {
        protected readonly IMediator _mediator;

        protected string UserId
        {
            get
            {
                return User.Claims.FirstOrDefault(c => c.Type == "userId")?.Value;
            }
        }

        public Controller(IMediator mediator)
        {
            _mediator = mediator;
        }
    }
}
