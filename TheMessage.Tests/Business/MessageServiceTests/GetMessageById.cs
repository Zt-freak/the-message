using Microsoft.EntityFrameworkCore;
using Moq;
using TheMessage.Business.Context;
using TheMessage.Business.Entities;
using TheMessage.Business.Interfaces.Repositories;
using TheMessage.Business.Services;
using Xunit;

namespace TheMessage.Tests.Business.MessageServiceTests
{
    public class GetMessageById
    {
        private readonly MessageService _service;
        private readonly Mock<IMessageRepository> _mockMessageRepository;

        public GetMessageById()
        {
            _mockMessageRepository = new Mock<IMessageRepository>();

            _service = new MessageService(_mockMessageRepository.Object);
        }

        [Fact]
        public void ItShould_GetMessageById()
        {
            // Arrange
            int id = 1;

            var options = new DbContextOptionsBuilder<MessageDataContext>()
                .UseInMemoryDatabase(databaseName: "ItShould_GetMessageById")
                .Options;
            var dataContext = new MessageDataContext(options);

            dataContext.Messages.Add(new Message { Id = 1, Title = "Lorem Ipsum", SenderId = 1 });
            dataContext.Messages.Add(new Message { Id = 2, Title = "Lorem Ipsum", SenderId = 1 });
            dataContext.Messages.Add(new Message { Id = 3, Title = "Lorem Ipsum", SenderId = 1 });
            dataContext.SaveChanges();

            using (dataContext)
            {
                _mockMessageRepository.Setup(x => x.GetById(id)).Returns(dataContext.Messages.Find(id));

                // Act
                var message = _service.GetMessageById(id);

                // Assert
                Assert.Equal(id, message.Id);
            }
        }

        [Fact]
        public void ItShould_ReturnNull_WhenMessageDoesNotExist()
        {
            // Arrange
            int id = 6;

            var options = new DbContextOptionsBuilder<MessageDataContext>()
                .UseInMemoryDatabase(databaseName: "ItShould_ReturnNull_WhenMessageDoesNotExist")
                .Options;
            var dataContext = new MessageDataContext(options);

            dataContext.Messages.Add(new Message { Id = 1, Title = "Lorem Ipsum", SenderId = 1 });
            dataContext.Messages.Add(new Message { Id = 2, Title = "Lorem Ipsum", SenderId = 1 });
            dataContext.Messages.Add(new Message { Id = 3, Title = "Lorem Ipsum", SenderId = 1 });
            dataContext.SaveChanges();

            using (dataContext)
            {
                _mockMessageRepository.Setup(x => x.GetById(id)).Returns(dataContext.Messages.Find(id));

                // Act
                var message = _service.GetMessageById(id);

                // Assert
                Assert.Null(message);
            }
        }
    }
}
