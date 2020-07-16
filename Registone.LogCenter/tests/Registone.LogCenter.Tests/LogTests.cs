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
            var logs = GetLogs();

            LogRepository.Setup(x => x.Get()).Returns(logs);
            var user = GetUser();
            UserRepository.Setup(x => x.GetUserById(It.IsAny<int>())).Returns(user);

            var service = new LogService(LogRepository.Object, UserRepository.Object);

            var result = service.GetLogs();

            Assert.NotNull(result);
            Assert.Equal(user.Email, result[0].UserEmail);
        }

        [Fact]
        public void GetLogsFiled_Succeesfully()
        {
            var logs = GetLogs();
            LogRepository.Setup(x => x.GetFileds()).Returns(logs);
            var user = GetUser();
            UserRepository.Setup(x => x.GetUserById(It.IsAny<int>())).Returns(user);

            var service = new LogService(LogRepository.Object, UserRepository.Object);

            var result = service.GetLogsFiled();

            Assert.NotNull(result);
            Assert.Equal(user.Email, result[0].UserEmail);
        }

        [Fact]
        public void Register_Succeesfully()
        {
            var user = GetUser();
            LogRepository.Setup(x => x.Register(It.IsAny<Log>()));
            UserRepository.Setup(x => x.GetUserByEmail(It.IsAny<string>())).Returns(user);
            var service = new LogService(LogRepository.Object, UserRepository.Object);
           
            service.Register(GetLogRegisterDto());
        }

        [Fact]
        public void ArchiveLog_Succeesfully()
        {
            var user = GetUser();
            LogRepository.Setup(x => x.GetById(It.IsAny<int>())).Returns(GetLog());
            LogRepository.Setup(x => x.Update(It.IsAny<Log>()));
            var service = new LogService(LogRepository.Object, UserRepository.Object);

            service.ArchiveLog(1);
        }

        [Fact]
        public void Remove_Succeesfully()
        {
            var user = GetUser();
            LogRepository.Setup(x => x.GetById(It.IsAny<int>())).Returns(GetLog());
            LogRepository.Setup(x => x.Remove(It.IsAny<Log>()));

            var service = new LogService(LogRepository.Object, UserRepository.Object);

            service.Remove(1);
        }

        [Fact]
        public void FindByTitle_Succeesfully()
        {
            LogRepository.Setup(x => x.GetByTitle(It.IsAny<string>())).Returns(GetLogs());
            UserRepository.Setup(x => x.GetUserById(It.IsAny<int>())).Returns(GetUser());

            var service = new LogService(LogRepository.Object, UserRepository.Object);

            var result = service.FindByTitle("test");

            Assert.NotNull(result);
        }

        [Fact]
        public void FindByLevel_Succeesfully()
        {
            LogRepository.Setup(x => x.GetByLevel(It.IsAny<string>())).Returns(GetLogs());
            UserRepository.Setup(x => x.GetUserById(It.IsAny<int>())).Returns(GetUser());

            var service = new LogService(LogRepository.Object, UserRepository.Object);

            var result = service.FindByLevel("test");

            Assert.NotNull(result);
        }

        [Fact]
        public void FindByOrigin_Succeesfully()
        {
            LogRepository.Setup(x => x.GetByOrigin(It.IsAny<string>())).Returns(GetLogs());
            UserRepository.Setup(x => x.GetUserById(It.IsAny<int>())).Returns(GetUser());

            var service = new LogService(LogRepository.Object, UserRepository.Object);

            var result = service.FindByOrigin("test");

            Assert.NotNull(result);
        }

        #endregion

        #region Private Methods

        private IList<Log> GetLogs()
        {
            return new List<Log> {
                GetLog()
            };
        }

        private Log GetLog()
        {
            return new Log
            {
                CreatedAt = new DateTime(),
                Details = "string",
                Filed = false,
                Id = 1,
                Level = "string",
                Origin = "string",
                Title = "string",
                UserId = 1
            };
        }

        private User GetUser()
        {
            return new User
            {
                Email = "test"
            };
        }

        private LogRegisterDto GetLogRegisterDto()
        {
            return new LogRegisterDto
            {
                Details = "string",
                Level = "string",
                Origin = "string",
                Title = "string",
                UserEmail = "string"
            };
        }

        #endregion
    }
}
