using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Goleador.Application.Read.Models;
using Goleador.Application.Read.Queries;
using Goleador.Application.Write.Commands;
using Goleador.Application.Write.Models;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Distributed;

namespace Goleador.Web.Controllers
{
    [Authorize]
    public class BooksController : Controller
    {

        public BooksController(IMediator mediator, IDistributedCache cache) : base(mediator, cache)
        {
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

        public async Task<IActionResult> SearchBooksAsync(string query)
        {
            var key = $"search_books_{query}";
            var cachedBooks = await GetCacheAsync<SearchedBookCollection>(key);
            if (cachedBooks != null)
            {
                return Ok(cachedBooks);
            }

            var books = await _mediator.Send(new SearchBooksQuery(query));

            await SetCacheAsync(key, books);

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