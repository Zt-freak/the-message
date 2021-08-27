using System.Collections.Generic;
using TheMessage.Business.Interfaces.Entities;

namespace TheMessage.Business.Interfaces.Repositories
{
    public interface IUserRepository
    {
        IEnumerable<IUser> GetAll();
        IUser GetById(int id);
        IUser GetByName(string name);
        void Add(IUser user);
        void Update(IUser user);
        void Delete(int id);
    }
}
