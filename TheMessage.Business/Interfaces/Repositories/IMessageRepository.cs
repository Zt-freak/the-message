using System.Collections.Generic;
using TheMessage.Business.Interfaces.Entities;

namespace TheMessage.Business.Interfaces.Repositories
{
    public interface IMessageRepository
    {
        IEnumerable<IMessage> GetAll();
        IMessage GetById(int id);
        IEnumerable<IMessage> GetByUserId(int id);
        void Add(IMessage message);
        void Update(IMessage message);
        void Delete(int id);
    }
}
