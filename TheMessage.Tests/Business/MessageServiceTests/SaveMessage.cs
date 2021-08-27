using Moq;
using System;
using TheMessage.Business.Entities;
using TheMessage.Business.Interfaces.Repositories;
using TheMessage.Business.Services;
using Xunit;

namespace TheMessage.Tests.Business.UserServiceTests
{
    public class SaveMessage
    {
        private readonly MessageRepository _service;
        private readonly Mock<IMessageRepository> _mockMessageRepository;

        public SaveMessage()
        {
            _mockMessageRepository = new Mock<IMessageRepository>();

            _service = new MessageRepository(_mockMessageRepository.Object);
            _service = new MessageRepository(_mockMessageRepository.Object);
        }

        [Fact]
        public void ItShould_SaveMessage()
        {
            // Arrange
            var message = new Message { Id = 1, Title = "Lorem Ipsum", SenderId = 1 };

            // Act
            _service.SaveMessage(message);

            // Assert
            _mockMessageRepository.Verify(x => x.Add(message), Times.Once);
        }

        [Fact]
        public void ItShould_ThrowArgumentException_WhenTitleEmpty()
        {
            // Arrange
            var message = new Message { Id = 1, SenderId = 1 };

            // Act & Assert
            _mockMessageRepository.Verify(x => x.Add(message), Times.Never);
            Assert.Throws<ArgumentException>(() => _service.SaveMessage(message));
        }

        [Fact]
        public void ItShould_ThrowArgumentException_WhenSenderIdEmpty()
        {
            // Arrange
            var message = new Message { Id = 1, Title = "Lorem Ipsum" };

            // Act & Assert
            _mockMessageRepository.Verify(x => x.Add(message), Times.Never);
            Assert.Throws<ArgumentException>(() => _service.SaveMessage(message));
        }
    }
}
