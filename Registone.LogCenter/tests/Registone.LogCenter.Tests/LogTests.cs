using Registone.LogCenter.Domain.DataTransferObjects;
using Registone.LogCenter.Domain.Interfaces;
using Xunit;

namespace Registone.LogCenter.Tests
{
    public class LogTests
    {
        #region Properties

        private ILogService logService;

        #endregion

        #region Constructor
        public LogTests(ILogService service)
        {          
            logService = service;
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
    }
}
