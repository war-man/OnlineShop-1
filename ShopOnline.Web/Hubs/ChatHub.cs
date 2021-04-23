using Microsoft.AspNetCore.SignalR;
using ShopOnline.Data.Entity;
using ShopOnline.Model.MessageModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopOnline.Web.Hubs
{
    public class ChatHub : Hub
    {
        public async Task SendMessage(AnnouncementViewModel message) =>
            await Clients.All.SendAsync("ReceiveMessage", message);
    }
}
