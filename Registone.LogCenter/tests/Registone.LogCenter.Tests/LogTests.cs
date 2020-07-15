using Moq;
using Registone.LogCenter.Domain.DataTransferObjects;
using Registone.LogCenter.Domain.Interfaces;
using Registone.LogCenter.Domain.Models;
using Registone.LogCenter.Domain.Services;
using System;
using System.Collections.Generic;
using Xunit;

namespace Registone.LogCenter.Tests
{
    public class LogTests
    {
        #region Properties

        private Mock<ILogRepository> LogRepository { get; set; }
        private Mock<IUserRepository> UserRepository { get; set; }


        #endregion

        #region Constructor
        public LogTests()
        {
            LogRepository = new Mock<ILogRepository>();
            UserRepository = new Mock<IUserRepository>();
        }

        #endregion

        #region Tests

        [Fact]
        public void GetLogs_Succeesfully()
        {
            var logs = new List<Log> {
                new Log
                {
                    CreatedAt = new DateTime(),
                    Details = "string",
                    Filed = false,
                    Id = 1,
                    Level = "string",
                    Origin = "string",
                    Title = "string",
                    UserId = 1
                }
            };

            LogRepository.Setup(x => x.Get()).Returns(logs);
            var user = new User 
            {
                Email = "string"
            };
            UserRepository.Setup(x => x.GetUserById(It.IsAny<int>())).Returns(user);

            var service = new LogService(LogRepository.Object, UserRepository.Object);

            var result = service.GetLogs();

            Assert.NotNull(result);
            Assert.Equal(user.Email, result[0].UserEmail);
        }

        //[Fact]
        //public void Should_Register_New_A_Log()
        //{
        //    var log = new LogRegisterDto
        //    {
        //        Level = "Error",
        //        Origin = "Origin",
        //        Details = "Details",
        //        Title = "Title",
        //        UserEmail = "test@test.com"
        //    };

        //    logService.Register(log);
        //}

        //[Fact]
        //public void Should_Archive_Log()
        //{
        //    logService.ArchiveLog(7);
        //}

        //[Fact]
        //public void Should_Remove_Log()
        //{
        //    logService.Remove(7);
        //}

        //[Theory]
        //[InlineData("Error")]
        //[InlineData("Unique")]
        //[InlineData("Title")]
        //public void Should_Return_Right_Log_When_Find_By_Title(string title)
        //{
        //    var result = logService.FindByTitle(title);

        //    Assert.NotNull(result);
        //}

        //[Theory]
        //[InlineData("Origem do log")]
        //[InlineData("Origem do log 2")]
        //[InlineData("Origem do log 3")]
        //public void Should_Return_Right_Log_When_Find_By_Origin(string origin)
        //{
        //    var result = logService.FindByOrigin(origin);

        //    Assert.Equal(origin, result[0].Origin);
        //}

        //[Theory]
        //[InlineData("Error")]
        //[InlineData("Warning")]
        //[InlineData("Debug")]
        //public void Should_Return_Logs_When_Find_By_Level(string level)
        //{

        //    var result = logService.FindByLevel(level);

        //    Assert.NotNull(result);
        //}

        #endregion      
    }
}
