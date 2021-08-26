using System;
using TheMessage.Business.Interfaces.Entities;
using TheMessage.Business.Interfaces.Repositories;
using TheMessage.Business.Interfaces.Services;

namespace TheMessage.Business.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _repository;

        public UserService(IUserRepository repository)
        {
            _repository = repository;
        }

        public IUser GetUserById(int id)
        {
            return _repository.GetById(id);
        }

        public void SaveUser(IUser user)
        {
            if (!ValidateUser(user))
                throw new ArgumentException();
            _repository.Add(user);
        }

        public bool ValidateUser(IUser user)
        {
            bool[] validations = new bool[]
            {
                ValidateLastName(user.Lastname),
                ValidateEmail(user.Email)
            };

            return !Array.Exists(validations, e => e == false);
        }

        private bool ValidateLastName(string lastname)
        {
            if (string.IsNullOrWhiteSpace(lastname))
            {
                return false;
            }
            return true;
        }

        private bool ValidateEmail(string email)
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }
    }
}
