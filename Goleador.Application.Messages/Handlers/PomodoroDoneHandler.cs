using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Goleador.Application.Read.Models;
using Goleador.Application.Read.Repositories;
using Goleador.Domain.Book.Events;

namespace Goleador.Application.Messages.Handlers
{
    public class PomodoroDoneHandler : IMessageHandler<PomodoroDone>
    {
        private readonly IRepository<Pomodoro> _pomodoroRepository;

        public PomodoroDoneHandler(IRepository<Pomodoro> pomodoroRepository)
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
