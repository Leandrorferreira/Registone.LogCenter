using Codenation.LogCenter.Api.DataTransferObjects;
using Codenation.LogCenter.Api.Models;
using Codenation.LogCenter.Api.Repositories;
using Codenation.LogCenter.Api.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Moq;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace Codenation.LogCenter.Tests
{
    public class UserTests
    {

        #region Properties

        private UserService userService;

        #endregion

        #region Constructor

        public UserTests()
        {
            userService = new UserService(GetContext());
        }

        #endregion

        #region Tests

        [Fact]
        public void Register_User_Succeesfully()
        {
            var user = new UserDto 
            {
                Email = "test@test.com",
                Password = "12345"
            };

            userService.Register(user);
        }

        [Fact]
        public void Authenticate_User_Successfully()
        {            
            var user = new UserDto
            {
                Email = "test@test.com",
                Password = "12345"
            };

            // Act
            var result = userService.Authenticate(user, Encoding.ASCII.GetBytes("b9040de2d5764252b817dbbc1e6c0426"));

            // Assert 
            Assert.NotNull(result.UserEmail);
            Assert.Equal("test@test.com", result.UserEmail);
        }
       
        #endregion

        #region Private Methods

        private LogCenterContext GetContext()
        {
            var context = new LogCenterContext(GetOptions());

            var userDbSet = GetUserDbSet();            

            context.Users = userDbSet.Object;

            return context;
        }

        private IQueryable<User> GetUsers()
        {
            return new List<User>
            {
                new User
                {
                    Id = 1,
                    Email = "test@test.com",
                    Password = "12345"
                },
                new User
                {
                    Id = 2,
                    Email = "leandro@test.com",
                    Password = "@lOpIng"
                },
                new User
                {
                    Id = 3,
                    Email = "user@gmail.com",
                    Password = "options123"
                }

            }.AsQueryable();
        }

        private ServiceProvider GetServiceProvider()
        {
            return new ServiceCollection()
           .AddEntityFrameworkInMemoryDatabase()
           .BuildServiceProvider();
        }

        private DbContextOptions<LogCenterContext> GetOptions()
        {
            var serviceProvider = GetServiceProvider();

            return new DbContextOptionsBuilder<LogCenterContext>()
               .UseInMemoryDatabase("LogCenter")
               .UseInternalServiceProvider(serviceProvider)
               .Options;
        }

        private Mock<DbSet<User>> GetUserDbSet()
        {
            var users = GetUsers();

            var userDbSet = new Mock<DbSet<User>>();
            userDbSet.As<IQueryable<User>>().Setup(m => m.Provider).Returns(users.Provider);
            userDbSet.As<IQueryable<User>>().Setup(m => m.Expression).Returns(users.Expression);
            userDbSet.As<IQueryable<User>>().Setup(m => m.ElementType).Returns(users.ElementType);
            userDbSet.As<IQueryable<User>>().Setup(m => m.GetEnumerator()).Returns(users.GetEnumerator());

            return userDbSet;
        }

        #endregion
    }
}
