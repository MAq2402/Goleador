using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Goleador.Application.Messages.Messages;
using Goleador.Application.Read.Models;
using Goleador.Application.Read.Repositories;
using Goleador.Infrastructure.RealTimeServices;
using Goleador.Infrastructure.Repositories;

namespace Goleador.Application.Messages.Handlers
{
    public class ReadingBookStartedHandler : IMessageHandler<ReadingBookStarted>
    {
        private readonly IBookRepository _bookRepository;
        private readonly IBookHubService _hubService;

        public ReadingBookStartedHandler(IBookRepository bookRepository, IBookHubService hubService)
        {
            _bookRepository = bookRepository;
            _hubService = hubService;
        }

        public async Task HandleAsync(ReadingBookStarted message)
        {
            var updateDictionary = new Dictionary<string, string>
            {
                { "Status", "In read"}
            };

            await _bookRepository.UpdateAsync(message.Id, updateDictionary);

            //Get userId method??
            // var userId = (await _bookRepository.BookWithPomodorosAsync(message.Id)).UserId;

            // await _hubService.SendAsync(await _bookRepository.BooksWithPomodorosAsync(userId), userId);
        }
    }
}
