using Microsoft.AspNetCore.SignalR;
using ShopOnline.Model.ChatModel;
using ShopOnline.Model.MessageModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopOnline.Web.Hubs
{
    public class HubUser:Hub
    {
        public async Task SendMessage(string UserName,string Content) =>
         await Clients.All.SendAsync("ConnectRecievemessage", UserName,Content);
    }
}
