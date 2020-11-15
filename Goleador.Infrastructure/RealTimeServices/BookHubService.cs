using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Connections.Client;
using Microsoft.AspNetCore.SignalR;
using Microsoft.AspNetCore.SignalR.Client;
using Microsoft.Net.Http.Headers;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Goleador.Infrastructure.RealTimeServices
{
    public class BookHubService : IBookHubService
    {
        HubConnection connection;
        private readonly IHubContext<BookHub> _hubContext;

        public BookHubService(IHubContext<BookHub> hubContext)
        {
            _hubContext = hubContext;
            //var options = new HttpConnectionOptions()
            //{
            //    AccessTokenProvider = 
            //};
   
        }

        public async Task SendAsync(object data, string userId)
        {
            try
            {
                //connection = new HubConnectionBuilder()
                //    .WithUrl("https://localhost:44323/sth", options => {
                //        options.HttpMessageHandlerFactory = (message) =>
                //        {
                //            if (message is HttpClientHandler clientHandler)
                //                // bypass SSL certificate
                //                clientHandler.ServerCertificateCustomValidationCallback +=
                //                    (sender, certificate, chain, sslPolicyErrors) => { return true; };
                //            return message;
                //        };
                //    })
                //    .Build();
                //await connection.StartAsync();

                //await connection.InvokeAsync("SendUpdateNotification", userId);

                await _hubContext.Clients.User(userId).SendAsync("books", data);
            } catch(Exception ex)
            {
                int xD = ex.Message.Length;
            }
            //TYPE HUB I WGL I MOZE TYPE CONTEXT
            //USER
            /// await _hubContext.Clients.
            /// 
          
            // await _hubContext.Clients.All.SendAsync("books", data);
        }
    }
}
