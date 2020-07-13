using Registone.LogCenter.Api.DataTransferObjects;
using Registone.LogCenter.Api.Interfaces;
using System.Text;
using Xunit;

namespace Registone.LogCenter.Tests
{
    public class UserTests
    {

        #region Properties

        private IUserService userService;

        #endregion

        #region Constructor

        public UserTests(IUserService service)
        {
            userService = service;
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
    }
}
