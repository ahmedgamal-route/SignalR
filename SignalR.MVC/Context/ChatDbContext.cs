using Microsoft.EntityFrameworkCore;
using SignalR.MVC.Models;

namespace SignalR.MVC.Context
{
    public class ChatDbContext : DbContext
    {
        public ChatDbContext(DbContextOptions<ChatDbContext> options) : base(options)
        {
        }
        public DbSet<Message> Messages { get; set; }
    }
}
