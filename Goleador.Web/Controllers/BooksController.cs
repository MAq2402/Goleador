using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Goleador.Application.Read.Queries;
using Goleador.Application.Write.Commands;
using Goleador.Application.Write.Models;
using MediatR;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace Goleador.Web.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BooksController : ControllerBase
    {
        private readonly IMediator _mediator;

        public BooksController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetBooksAsync()
        {
            return Ok(await _mediator.Send(new GetBooksQuery()));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetBookAsync(string id)
        {
            return Ok(await _mediator.Send(new GetBookQuery(new Guid(id))));
        }

        [HttpGet("search")]

        public async Task<IActionResult> SearchBooksAsync(string query)
        {
            return Ok(await _mediator.Send(new SearchBooksQuery(query)));
        }

        [HttpPost]
        public async Task<IActionResult> AddBookToFutureReadListAsync([FromBody] BookForCreation book)
        {
            await _mediator.Send(new AddBookToFutureReadList(book.Title, book.Authors, book.Thumbnail, 
                book.PublishedYear, book.ExternalId));

            return CreatedAtRoute(null, null);
        }

        [HttpPut("startReading/{id}")]
        public async Task<IActionResult> StartReadingBookAsync(string id)
        {
            await _mediator.Send(new StartReadingBook(new Guid(id)));

            return NoContent();
        }

        [HttpPost("{id}/pomodoros")]
        public async Task<IActionResult> DoPomodoro(string id)
        {
            await _mediator.Send(new DoPomodoro(new Guid(id)));

            return NoContent();
        }
    }
}