using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Goleador.Application.Messages.Messages;
using Goleador.Application.Read.Models;
using Goleador.Infrastructure.Repositories;

namespace Goleador.Application.Messages.Handlers
{
    public class ReadingBookStartedHandler : IMessageHandler<ReadingBookStarted>
    {
        private readonly IReadRepository<Book> _bookRepository;

        public ReadingBookStartedHandler(IReadRepository<Book> bookRepository)
        {
            _bookRepository = bookRepository;
        }

        public async Task HandleAsync(ReadingBookStarted message)
        {
            var updateDictionary = new Dictionary<string, string>
            {
                { "Status", "In read"}
            };

            await _bookRepository.UpdateAsync(message.Id, updateDictionary);
        }
    }
}
