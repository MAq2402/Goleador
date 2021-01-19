using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Goleador.Application.Read.Models;
using Goleador.Application.Read.Queries;
using Goleador.Application.Write.Commands;
using Goleador.Application.Write.Models;
using Goleador.Web.Filters;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Distributed;
using Newtonsoft.Json;

namespace Goleador.Web.Controllers
{
    [Authorize]
    public class BooksController : Controller
    {
        private IDistributedCache _cache;

        public BooksController(IMediator mediator, IDistributedCache cache) : base(mediator)
        {
            _cache = cache;
        }

        [HttpGet]
        public async Task<IActionResult> GetBooksAsync()
        {
            return Ok(await _mediator.Send(new GetBooksQuery(UserId)));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetBookAsync(string id)
        {
            return Ok(await _mediator.Send(new GetBookQuery(new Guid(id))));
        }

        [HttpGet("search")]
        [ServiceFilter(typeof(CacheFilter))]

        public async Task<IActionResult> SearchBooksAsync(string query)
        {
            var books = await _mediator.Send(new SearchBooksQuery(query));
            return Ok(books);
        }

        [HttpPost]
        public async Task<IActionResult> AddBookToFutureReadListAsync([FromBody] BookForCreation book)
        {
            await _mediator.Send(new AddBookToFutureReadList(book.Title, book.Authors, book.Thumbnail, 
                book.PublishedYear, book.ExternalId, UserId));

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

        [HttpPut("finishReading/{id}")]
        public async Task<IActionResult> FinishReadingAsync(string id)
        {
            await _mediator.Send(new FinishReadingBook(new Guid(id)));

            return NoContent();
        }
    }
}