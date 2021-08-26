using System;

namespace TheMessage.Business.Interfaces.Entities
{
    public interface IMessage
    {
        int Id { get; set; }
        string Title { get; set; }
        string Content { get; set; }
        int SenderId { get; set; }
        IUser Sender { get; set; }
        DateTime DataTimeSent { get; set; }
    }
}
