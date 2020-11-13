﻿using Goleador.Application.Messages.Messages;
using Goleador.Application.Read.Models;
using Goleador.Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Goleador.Application.Messages.Handlers
{
    public class ReadingBookFinishedHandler : IMessageHandler<ReadingBookFinished>
    {
        private readonly IReadRepository<Book> _bookRepository;

        public ReadingBookFinishedHandler(IReadRepository<Book> bookRepository)
        {
            _bookRepository = bookRepository;
        }

        public async Task HandleAsync(ReadingBookFinished message)
        {
            var updateDictionary = new Dictionary<string, string>
            {
                { "Status", "Finished"}
            };

            await _bookRepository.UpdateAsync(message.Id, updateDictionary);
        }
    }
}