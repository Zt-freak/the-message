using System.Collections.Generic;
using System.Linq;
using TheMessage.Business.Context;
using TheMessage.Business.Interfaces.Entities;
using TheMessage.Business.Interfaces.Repositories;

namespace TheMessage.Business.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly MessageDataContext _datacontext;

        public UserRepository(MessageDataContext datacontext)
        {
            _datacontext = datacontext;
        }

        public void Add(IUser user)
        {
            _datacontext.Add(user);
            _datacontext.SaveChanges();
        }

        public void Delete(int id)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<IUser> GetAll()
        {
            throw new System.NotImplementedException();
        }

        public IUser GetById(int id)
        {
            return _datacontext.Users.Find(id);
        }

        public IUser GetByName(string name)
        {
            return _datacontext.Users.FirstOrDefault(u => u.Name == name);
        }

        public void Update(IUser user)
        {
            throw new System.NotImplementedException();
        }
    }
}
