using Codenation.LogCenter.Api.DataTransferObjects;
using Codenation.LogCenter.Api.Models;
using Codenation.LogCenter.Api.Repositories;
using Codenation.LogCenter.Api.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace Codenation.LogCenter.Tests
{
    public class LogTests
    {
        #region Properties

        private LogService logService;

        #endregion

        #region Constructor
        public LogTests()
        {          
            logService = new LogService(GetContext());
        }

        #endregion

        #region Tests

        [Fact]
        public void GetLogs_Succeesfully()
        {
            var result = logService.GetLogs();

            Assert.NotNull(result);
            Assert.True(result.Count > 0);
        }

        [Fact]
        public void Should_Register_New_A_Log()
        {
            var log = new LogRegisterDto
            {
                CreatedAt = new DateTime(),
                Level = "Error",
                Origin = "Origin",
                Details = "Details",
                Title = "Title",
                UserEmail = "test@test.com"
            };

            logService.Register(log);
        }

        [Fact]
        public void Should_Archive_Log()
        {
            logService.ArchiveLog(7);
        }

        [Fact]
        public void Should_Remove_Log()
        {
            logService.Remove(7);
        }

        [Theory]
        [InlineData("Error")]
        [InlineData("Unique")]
        [InlineData("Title")]
        public void Should_Return_Right_Log_When_Find_By_Title(string title)
        {
            var result = logService.FindByTitle(title);

            Assert.NotNull(result);
        }

        [Theory]
        [InlineData("Origem do log")]
        [InlineData("Origem do log 2")]
        [InlineData("Origem do log 3")]
        public void Should_Return_Right_Log_When_Find_By_Origin(string origin)
        {
            var result = logService.FindByOrigin(origin);

            Assert.Equal(origin, result[0].Origin);
        }

        [Theory]
        [InlineData("Error")]
        [InlineData("Warning")]
        [InlineData("Debug")]
        public void Should_Return_Logs_When_Find_By_Level(string level)
        {

            var result = logService.FindByLevel(level);

            Assert.NotNull(result);
        }
        #endregion

        #region Private Methods

        private LogCenterContext GetContext()
        {
            var context = new LogCenterContext(GetOptions());
                     
            var userDbSet = GetUserDbSet();
            var logDbSet = GetLogDbSet();

            context.Users = userDbSet.Object;
            context.Logs = logDbSet.Object;

            return context;
        }

        private IQueryable<User> GetUsers()
        {
            return new List<User>
            {
                new User
                {
                    Id = 1,
                    Role = "Default",
                    Email = "test@test.com",
                    Password = "12345"
                },
                new User
                {
                    Id = 2,
                    Role = "Default",
                    Email = "leandro@test.com",
                    Password = "@lOpIng"
                },
                new User
                {
                    Id = 3,
                    Role = "Default",
                    Email = "user@gmail.com",
                    Password = "options123"
                }

            }.AsQueryable();
        }

        private IQueryable<Log> GetLog()
        {
            return new List<Log>
            {
                new Log
                {
                    Id = 1,
                    CreatedAt = new DateTime(),
                    Details = "Detalhes do log",
                    Filed = false,
                    Level = "Warning",
                    Origin = "Origem do log",
                    Title = "Decrição do Log",
                    UserId = 1
                },
                new Log
                {
                    Id = 2,
                    CreatedAt = new DateTime(),
                    Details = "Detalhes do log 2",
                    Filed = false,
                    Level = "Warning",
                    Origin = "Origem do log 2",
                    Title = "Decrição do Log 2",
                    UserId = 2
                },
                new Log
                {
                    Id = 3,
                    CreatedAt = new DateTime(),
                    Details = "Detalhes do log 3",
                    Filed = false,
                    Level = "Error",
                    Origin = "Origem do log 3",
                    Title = "Decrição do Log 3",
                    UserId = 2
                },
                new Log
                {
                    Id = 4,
                    CreatedAt = new DateTime(),
                    Details = "Detalhes do log 4",
                    Filed = true,
                    Level = "error",
                    Origin = "Origem do log 4",
                    Title = "Decrição do Log 4",
                    UserId = 1
                },
                new Log
                {
                    Id = 5,
                    CreatedAt = new DateTime(),
                    Details = "Detalhes do log 5",
                    Filed = false,
                    Level = "Debug",
                    Origin = "Origem do log 5",
                    Title = "Decrição do Log 5",
                    UserId = 1
                },
                new Log
                {
                    Id = 6,
                    CreatedAt = new DateTime(),
                    Details = "Detalhes do log 6",
                    Filed = false,
                    Level = "Debud",
                    Origin = "Origem do log 6",
                    Title = "Decrição do Log 6",
                    UserId = 1
                },
                new Log
                {
                    Id = 7,
                    CreatedAt = new DateTime(),
                    Details = "Detalhes do log 6",
                    Filed = false,
                    Level = "Debud",
                    Origin = "Origem do log 6",
                    Title = "Decrição do Log 6",
                    UserId = 1
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

        private Mock<DbSet<Log>> GetLogDbSet()
        {
            var logs = GetLog();
            var logDbSet = new Mock<DbSet<Log>>();
            logDbSet.As<IQueryable<Log>>().Setup(m => m.Provider).Returns(logs.Provider);
            logDbSet.As<IQueryable<Log>>().Setup(m => m.Expression).Returns(logs.Expression);
            logDbSet.As<IQueryable<Log>>().Setup(m => m.ElementType).Returns(logs.ElementType);
            logDbSet.As<IQueryable<Log>>().Setup(m => m.GetEnumerator()).Returns(logs.GetEnumerator());

            return logDbSet;
        }

        #endregion
    }
}
