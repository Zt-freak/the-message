using Microsoft.EntityFrameworkCore;
using Moq;
using System;
using System.Linq;
using TheMessage.Business.Context;
using TheMessage.Business.Entities;
using TheMessage.Business.Interfaces.Repositories;
using TheMessage.Business.Services;
using Xunit;

namespace TheMessage.Tests.UserServiceTests
{
    public class SaveUser
    {
        private readonly UserService _service;
        private readonly Mock<IUserRepository> _mockUserRepository;

        public SaveUser()
        {
            _mockUserRepository = new Mock<IUserRepository>();

            _service = new UserService(_mockUserRepository.Object);
        }

        [Fact]
        public void ItShould_SaveUser()
        {
            // Arrange
            var john = new User { Name = "John", Lastname = "Doe", Email = "john@doe.com" };

            // Act
            _service.SaveUser(john);

            // Assert
            _mockUserRepository.Verify(x => x.Add(john), Times.Once);
        }

        [Fact]
        public void ItShould_ThrowArgumentException_WhenUserLastnameEmpty()
        {
            // Arrange
            var john = new User { Name = "John", Email = "john@doe.com" };

            // Act & Assert
            _mockUserRepository.Verify(x => x.Add(john), Times.Never);
            Assert.Throws<ArgumentException>(() => _service.SaveUser(john));
        }

        [Fact]
        public void ItShould_ThrowArgumentException_WhenUserEmailEmpty()
        {
            // Arrange
            var john = new User { Name = "John", Lastname = "Doe"};

            // Act & Assert
            _mockUserRepository.Verify(x => x.Add(john), Times.Never);
            Assert.Throws<ArgumentException>(() => _service.SaveUser(john));
        }
    }
}
