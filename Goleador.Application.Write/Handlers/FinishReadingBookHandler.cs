﻿using Goleador.Application.Shared.Exceptions;
using Goleador.Application.Write.Commands;
using Goleador.Domain.Base;
using Goleador.Domain.Book;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Goleador.Application.Write.Handlers
{
    public class FinishReadingBookHandler : IRequestHandler<FinishReadingBook>
    {
        private readonly IRepository<Book> _bookRepository;

        public FinishReadingBookHandler(IRepository<Book> bookRepository)
        {
            _bookRepository = bookRepository;
        }

        public async Task<Unit> Handle(FinishReadingBook request, CancellationToken cancellationToken)
        {
            var book = await _bookRepository.GetAsync(request.Id);

            if (book == null)
            {
                throw new NotFoundException($"Book with id: {request.Id} does not exist.");
            }

            book.FinishReading();

            await _bookRepository.SaveChangesAsync(book);

            return Unit.Value;
        }
    }
}
