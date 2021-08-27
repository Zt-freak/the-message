using Microsoft.EntityFrameworkCore;
using TheMessage.Business.Entities;

namespace TheMessage.Business.Interfaces.Context
{
    public interface IMessageDataContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Message> Messages { get; set; }
    }
}
