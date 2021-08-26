using Microsoft.EntityFrameworkCore;
using System;
using TheMessage.Business.Entities;

namespace TheMessage.Business.Context
{
    public class MessageDataContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Message> Messages { get; set; }

        public MessageDataContext(DbContextOptions<MessageDataContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Message>()
                .Property(b => b.DataTimeSent)
                .HasDefaultValueSql("getdate()");

            modelBuilder.Entity<User>().HasData(
                new { Id = 1, Name = "John", Lastname = "Doe", Email = "john@doe.com" },
                new { Id = 2, Name = "Jane", Lastname = "Doe", Email = "jane@doe.com" }
            );
            modelBuilder.Entity<Message>()
                .HasData(
                new { Id = 1, Title = "Test", Content = "this is a test", SenderId = 1, DataTimeSent = DateTime.Now}
            );
        }
    }
}
