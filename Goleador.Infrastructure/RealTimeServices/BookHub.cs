using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Goleador.Infrastructure.RealTimeServices
{
    [Authorize]
    public class BookHub : Hub
    {
        public BookHub()
        {
            
        }

        // public Task DoSomething(){

        //public ClaimsPrincipal GetUser()
        //{
        //    return this.Context.User;
        //}

        //[Authorize]
        //public Task SendBooks(object data)
        //{

        //    return Clients.User(Context.UserIdentifier).SendAsync("books", new { newChanges = false, data });
        //}

        //[AllowAnonymous]

        //public Task SendUpdateNotification(string userId)
        //{
        //    return Clients.User(userId).SendAsync("books", new { newChanges = true, data = new object() });
        //}

        //public Task SendMessageToCaller(string user, string message)
        //{
        //    return Clients.Caller.SendAsync("ReceiveMessage", user, message);
        //}

        //public Task SendMessageToGroup(string user, string message)
        //{
        //    return Clients.Group("SignalR Users").SendAsync("ReceiveMessage", user, message);
        //}
    }
}
