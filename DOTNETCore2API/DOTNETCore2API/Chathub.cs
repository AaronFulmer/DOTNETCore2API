using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DOTNETCore2API
{
    public class ChatHub : Hub
    {
        public async Task Send(String message) {
            
            await this.Clients.All.InvokeAsync("Send", message);
            
        } 

    }
}
