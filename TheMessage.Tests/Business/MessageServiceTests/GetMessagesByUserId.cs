using Microsoft.EntityFrameworkCore;
using Moq;
using System.Linq;
using TheMessage.Business.Context;
using TheMessage.Business.Entities;
using TheMessage.Business.Interfaces.Repositories;
using TheMessage.Business.Services;
using Xunit;

namespace TheMessage.Tests.Business.MessageServiceTests
{
    public class GetMessageByUserId
    {
        private readonly MessageService _service;
        private readonly Mock<IMessageRepository> _mockMessageRepository;

        public GetMessageByUserId()
        {
            _mockMessageRepository = new Mock<IMessageRepository>();

            _service = new MessageService(_mockMessageRepository.Object);
        }

        [Fact]
        public void ItShould_GetMessagesByUserId()
        {
            // Arrange
            int id = 1;

            var options = new DbContextOptionsBuilder<MessageDataContext>()
                .UseInMemoryDatabase(databaseName: "ItShould_GetMessageByUserId")
                .Options;
            var dataContext = new MessageDataContext(options);

            dataContext.Messages.Add(new Message { Id = 1, Title = "Lorem Ipsum", SenderId = 1 });
            dataContext.Messages.Add(new Message { Id = 2, Title = "Lorem Ipsum", SenderId = 1 });
            dataContext.Messages.Add(new Message { Id = 3, Title = "Lorem Ipsum", SenderId = 2 });
            dataContext.SaveChanges();

            using (dataContext)
            {
                _mockMessageRepository.Setup(x => x.GetByUserId(id)).Returns(dataContext.Messages.Where(m => m.SenderId == 1));

                // Act
                var messages = _service.GetMessagesByUserId(id);

                // Assert
                Assert.Equal(2, messages.Count());
            }
        }
    }
}
