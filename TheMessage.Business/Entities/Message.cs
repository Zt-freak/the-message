using System;
using System.ComponentModel.DataAnnotations;
using TheMessage.Business.Interfaces.Entities;

namespace TheMessage.Business.Entities
{
    class Message : IMessage
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        public string Content { get; set; }
        [Required]
        public int SenderId { get; set; }
        public IUser Sender { get; set; }
        public DateTime DataTimeSent { get; set; } = DateTime.Now;
    }
}
