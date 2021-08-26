using System.Collections.Generic;
using TheMessage.Business.Interfaces.Entities;

namespace TheMessage.Business.Interfaces.Services
{
    public interface IMessageService
    {
        void SaveMessage(IMessage message);
        IMessage GetMessageById(int id);
        IEnumerable<IMessage> GetMessagesByUserId(int id);
    }
}
