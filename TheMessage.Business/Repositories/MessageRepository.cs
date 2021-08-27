using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using TheMessage.Business.Context;
using TheMessage.Business.Interfaces.Entities;
using TheMessage.Business.Interfaces.Repositories;

namespace TheMessage.Business.Repositories
{
    public class MessageRepository : IMessageRepository
    {
        private readonly MessageDataContext _datacontext;

        public MessageRepository (MessageDataContext datacontext)
        {
            _datacontext = datacontext;
        }

        public void Add(IMessage message)
        {
            _datacontext.Add(message);
            _datacontext.SaveChanges();
        }

        public void Delete(int id)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<IMessage> GetAll()
        {
            throw new System.NotImplementedException();
        }

        public IMessage GetById(int id)
        {
            return _datacontext.Messages.Where(m => m.Id == id).Include(b => b.Sender).FirstOrDefault();
        }

        public IEnumerable<IMessage> GetByUserId(int id)
        {
            return _datacontext.Messages.Where(m => m.SenderId == id).Include(b => b.Sender);
        }

        public void Update(IMessage message)
        {
            throw new System.NotImplementedException();
        }
    }
}
