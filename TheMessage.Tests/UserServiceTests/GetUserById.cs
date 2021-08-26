using Microsoft.EntityFrameworkCore;
using Moq;
using TheMessage.Business.Context;
using TheMessage.Business.Entities;
using TheMessage.Business.Interfaces.Repositories;
using TheMessage.Business.Services;
using Xunit;

namespace TheMessage.Tests.UserServiceTests
{
    public class GetUserById
    {
        private readonly UserService _service;
        private readonly Mock<IUserRepository> _mockUserRepository;

        public GetUserById()
        {
            _mockUserRepository = new Mock<IUserRepository>();

            _service = new UserService(_mockUserRepository.Object);
        }

        [Fact]
        public void ItShould_GetUserById ()
        {
            // Arrange
            int id = 1;

            var options = new DbContextOptionsBuilder<MessageDataContext>()
                .UseInMemoryDatabase(databaseName: "ItShould_GetUserById")
                .Options;
            var dataContext = new MessageDataContext(options);

            dataContext.Users.Add(new User { Id = 1, Name = "John", Lastname = "Doe", Email = "john@doe.com" });
            dataContext.Users.Add(new User { Id = 2, Name = "Jane", Lastname = "Doe", Email = "jane@doe.com" });
            dataContext.Users.Add(new User { Id = 3, Name = "Lorem", Lastname = "Ipsum", Email = "lipsum@example.be" });
            dataContext.SaveChanges();

            using (dataContext)
            {
                _mockUserRepository.Setup(x => x.GetById(id)).Returns(dataContext.Users.Find(id));

                // Act
                var user = _service.GetUserById(id);

                // Assert
                Assert.Equal(id, user.Id);
            }
        }

        [Fact]
        public void ItShould_ReturnNull_WhenUserDoesNotExist()
        {
            // Arrange
            int id = 6;

            var options = new DbContextOptionsBuilder<MessageDataContext>()
                .UseInMemoryDatabase(databaseName: "ItShould_ReturnNull_WhenUserDoesNotExist")
                .Options;
            var dataContext = new MessageDataContext(options);

            dataContext.Users.Add(new User { Id = 1, Name = "John", Lastname = "Doe", Email = "john@doe.com" });
            dataContext.Users.Add(new User { Id = 2, Name = "Jane", Lastname = "Doe", Email = "jane@doe.com" });
            dataContext.Users.Add(new User { Id = 3, Name = "Lorem", Lastname = "Ipsum", Email = "lipsum@example.be" });
            dataContext.SaveChanges();

            using (dataContext)
            {
                _mockUserRepository.Setup(x => x.GetById(id)).Returns(dataContext.Users.Find(id));

                // Act
                var user = _service.GetUserById(id);

                // Assert
                Assert.Null(user);
            }
        }
    }
}
