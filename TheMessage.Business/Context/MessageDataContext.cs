using Microsoft.EntityFrameworkCore;
using TheMessage.Business.Entities;

namespace TheMessage.Business.Context
{
    class MessageDataContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Message> Messages { get; set; }

        public MessageDataContext(DbContextOptions<MessageDataContext> options) : base(options)
        {

        }
    }
}
