using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Goleador.Infrastructure.Types;
using RawRabbit;

namespace Goleador.Infrastructure.Messages
{
    public class MessageService : IMessageService
    {
        private readonly IBusClient _client;

        public MessageService(IBusClient client)
        {
            _client = client;
        }

        public async Task PublishAsync(IMessage message)
        {
            await _client.PublishAsync(message);
        }
    }
}
