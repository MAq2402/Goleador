﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Goleador.Application.Write.Commands;
using Goleador.Application.Write.Dtos;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Goleador.Web.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BookController : ControllerBase
    {
        private readonly IMediator _mediator;

        public BookController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> AddBookToFutureReadList([FromBody] BookForCreationDto book)
        {
            await _mediator.Send(new AddBookToFutureReadListCommand(book.Name, book.Author));

            return CreatedAtRoute(null, null);
        }
    }
}
