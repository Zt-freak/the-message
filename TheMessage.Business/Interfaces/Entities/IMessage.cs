using System;
using TheMessage.Business.Entities;

namespace TheMessage.Business.Interfaces.Entities
{
    public interface IMessage
    {
        int Id { get; set; }
        string Title { get; set; }
        string Content { get; set; }
        int SenderId { get; set; }
        User Sender { get; set; }
        DateTime DataTimeSent { get; set; }
    }
}
