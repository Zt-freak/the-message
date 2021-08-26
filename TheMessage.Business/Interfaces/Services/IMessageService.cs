using TheMessage.Business.Interfaces.Entities;

namespace TheMessage.Business.Interfaces.Services
{
    public interface IMessageService
    {
        void SaveMessage(IMessage message);
        IMessage GetMessageById(int id);
        IMessage GetMessageByUserId(int id);
    }
}
