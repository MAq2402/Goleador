using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Goleador.Application.Read.Models;
using Goleador.Application.Read.Repositories;
using Goleador.Domain.Book.Events;

namespace Goleador.Application.Messages.Handlers
{
    public class ReadingBookStartedHandler : IMessageHandler<ReadingBookStarted>
    {
        private readonly IRepository<Book> _bookRepository;

        public ReadingBookStartedHandler(IRepository<Book> bookRepository)
        {
            _bookRepository = bookRepository;
        }

        public async Task HandleAsync(ReadingBookStarted message)
        {
            var updateDictionary = new Dictionary<string, object>
            {
                { nameof(Book.ReadingStarted), message.OccuredOn },
                { nameof(Book.Status), "In read" }
            };

            await _bookRepository.UpdateAsync(message.AggregateId, updateDictionary);
        }
    }
}
