using Goleador.Application.Read.Models;
using Goleador.Application.Read.Repositories;
using Goleador.Infrastructure.DbContext;
using Goleador.Infrastructure.Types;
using Microsoft.EntityFrameworkCore;
using Nexmo.Api;
using Nexmo.Api.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Goleador.Infrastructure.SMS
{
    public class SmsService : ISmsService
    {
        private readonly SmsSettings _settings;
        private readonly GoleadorDbContext _dbContext;
        private readonly IBookRepository _bookRepository;

        public SmsService(Settings settings, GoleadorDbContext dbContext, IBookRepository bookRepository)
        {
            _settings = settings.SmsSettings;
            _dbContext = dbContext;
            _bookRepository = bookRepository;
        }

        public async Task SendMessageAboutBooksInReadAsync(string from, string to, string text)
        {
            var users = await _dbContext.Users.Where(u => !string.IsNullOrEmpty(u.PhoneNumber))
                .Select(u => new
                {
                    u.Id,
                    u.PhoneNumber
                })
                .ToListAsync();

            var client = new Client(creds: new Credentials
            {
                ApiKey = _settings.Key,
                ApiSecret = _settings.Secret
            });

            try
            {
                foreach (var user in users)
                {
                    var books = await _bookRepository.BooksWithPomodorosAsync(user.Id, "In read"); // shared project needed

                    if (books.Any())
                    {
                        var message = BuildMessage(books);
                        client.SMS.Send(request: new SMSRequest
                        {
                            from = _settings.From,
                            to = user.PhoneNumber,
                            text = message.ToString()
                        });
                    }
                }
            }
            catch
            {
            }
        }

        private string BuildMessage(IEnumerable<Book> books)
        {
            var messageBuilder = new StringBuilder();
            messageBuilder.Append("You are reading: ");
            foreach (var book in books)
            {
                messageBuilder.Append($"{book.Title} ({book.Pomodoros.Count()} Pomodoros){Environment.NewLine}");
            }

            return messageBuilder.ToString();
        }

        internal class SMSRequest : Nexmo.Api.SMS.SMSRequest
        {
            public string from { get; set; }
            public string to { get; set; }
            public string text { get; set; }
        }
    }
}
