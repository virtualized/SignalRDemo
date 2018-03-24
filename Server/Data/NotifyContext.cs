using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Server.Data
{
    public class NotifyContext : DbContext
    {
        public NotifyContext(DbContextOptions<NotifyContext> options)
            : base(options) {}

        public DbSet<Notification> Notifications { get; set; }
    }

    public class NotifyContextInitializer
    {
        public static void Initialize(NotifyContext context)
        {
            context.Database.EnsureCreated();

            if (context.Notifications.Any())
                return;

            var notifs = new Notification[]
            {
                new Notification { Message = "Notif 1", Completed = false },
                new Notification { Message = "Notif 2", Completed = false },
                new Notification { Message = "Notif 3", Completed = false }
            };
            foreach (var n in notifs)
            {
                context.Notifications.Add(n);
            }
            context.SaveChanges();
        }
    }
}