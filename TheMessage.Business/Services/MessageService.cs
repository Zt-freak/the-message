using System;
using System.Collections.Generic;
using TheMessage.Business.Interfaces.Entities;
using TheMessage.Business.Interfaces.Repositories;
using TheMessage.Business.Interfaces.Services;

namespace TheMessage.Business.Services
{
    public class MessageService : IMessageService
    {
        private readonly IMessageRepository _repository;

        public MessageService(IMessageRepository repository)
        {
            _repository = repository;
        }

        public IMessage GetMessageById(int id)
        {
            return _repository.GetById(id);
        }

        public IEnumerable<IMessage> GetMessagesByUserId(int id)
        {
            return _repository.GetByUserId(id);
        }

        public void SaveMessage(IMessage message)
        {
            if (!ValidateMessage(message))
                throw new ArgumentException();
            _repository.Add(message);
        }

        public bool ValidateMessage(IMessage message)
        {
            bool[] validations = new bool[]
            {
                ValidateTitle(message.Title),
                ValidateSenderId(message.SenderId),
            };

            return !Array.Exists(validations, e => e == false);
        }

        private bool ValidateTitle(string title)
        {
            if (string.IsNullOrWhiteSpace(title))
            {
                return false;
            }
            return true;
        }
        private bool ValidateSenderId(int id)
        {
            if (id == 0)
            {
                return false;
            }
            return true;
        }
    }
}
