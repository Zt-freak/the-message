using TheMessage.Business.Interfaces.Entities;

namespace TheMessage.Business.Interfaces.Services
{
    public interface IUserService
    {
        void SaveUser(IUser user);
        bool ValidateUser(IUser user);
        IUser GetUserById(int id);
    }
}
