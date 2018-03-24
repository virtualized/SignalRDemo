using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using Server.Data;

namespace SignalRTutorial.Hubs
{
    public class NotificationHub : Hub
    {
        private readonly NotifyContext dbContext;

        public NotificationHub(NotifyContext dbContext)
        {
            this.dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        }
        
        public override async Task OnConnectedAsync()
        {
            await Clients.All.SendAsync("SendAction", Context.User.Identity.Name, "joined");
        }

        public override async Task OnDisconnectedAsync(Exception ex)
        {
            await Clients.All.SendAsync("SendAction", Context.User.Identity.Name, "left");
        }

        public async Task Send(string message)
        {
            await Clients.All.SendAsync("SendMessage", Context.User.Identity.Name, message);
        }

        public async Task Create(string message)
        {
            await dbContext.Notifications.AddAsync(new Notification {
                Message = message,
                Completed = false
            });
            await dbContext.SaveChangesAsync();
            await BroadcastNotifications();
        }

        public async Task BroadcastNotifications() => 
            await Clients.All.SendAsync("BroadcastNotifications",
                await dbContext.Notifications.ToListAsync());

        public async Task Complete(int notificationId)
        {
            var note = await dbContext.Notifications.FindAsync(notificationId);
            note.Completed = true;
            await dbContext.SaveChangesAsync();
            await Clients.All.SendAsync("Completed", note);
            await BroadcastNotifications();
        }
    }
}