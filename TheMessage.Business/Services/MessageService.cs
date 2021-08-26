using TheMessage.Business.Interfaces.Entities;
using TheMessage.Business.Interfaces.Services;

namespace TheMessage.Business.Services
{
    public class MessageService : IMessageService
    {
        public IMessage GetMessageById(int id)
        {
            throw new System.NotImplementedException();
        }

        public IMessage GetMessageByUserId(int id)
        {
            throw new System.NotImplementedException();
        }

        public void SaveMessage(IMessage message)
        {
            throw new System.NotImplementedException();
        }
    }
}
