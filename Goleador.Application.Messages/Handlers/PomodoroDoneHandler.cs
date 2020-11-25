using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Goleador.Application.Read.Models;
using Goleador.Domain.Book.Events;
using Goleador.Infrastructure.Repositories;

namespace Goleador.Application.Messages.Handlers
{
    public class PomodoroDoneHandler : IMessageHandler<PomodoroDone>
    {
        private readonly IReadRepository<Pomodoro> _pomodoroRepository;

        public PomodoroDoneHandler(IReadRepository<Pomodoro> pomodoroRepository)
        {
            _pomodoroRepository = pomodoroRepository;
        }

        public async Task HandleAsync(PomodoroDone message)
        {
            var pomodoro = new Pomodoro()
            {
                Done = message.Done,
                PomodorableId = message.AggregateId
            };

            await _pomodoroRepository.InsertOneAsync(pomodoro);
        }
    }
}
