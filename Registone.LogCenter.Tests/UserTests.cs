using Moq;
using Registone.LogCenter.Domain.DataTransferObjects;
using Registone.LogCenter.Domain.Interfaces;
using Registone.LogCenter.Domain.Models;
using Registone.LogCenter.Domain.Services;
using Registone.LogCenter.Services;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Registone.LogCenter.Tests
{
    public class UserTests
    {

        #region Properties

        private Mock<IUserRepository> Repository;
        private Mock<IEncryptor>  Encryptor;

        #endregion

        #region Constructor

        public UserTests()
        {
            Repository = new Mock<IUserRepository>();
            Encryptor = new Mock<IEncryptor>();
        }

        #endregion

        #region Tests

        [Fact]
        public void Register_User_Succeesfully()
        {
            var encrypt = "test";
            Encryptor.Setup(x => x.Encrypt(It.IsAny<string>())).Returns(encrypt);

            User user = null;
            Repository.Setup(x => x.GetUserByEmail(It.IsAny<string>())).Returns(user);       
            Repository.Setup(x => x.Register(It.IsAny<User>()));

            var service = new UserService(Repository.Object, Encryptor.Object);
            var userDto = GetUserDto();
            service.Register(userDto);

            Assert.NotNull(userDto);
        }

        [Fact]
        public void Authenticate_User_Successfully()
        {
            var encrypt = "test";
            Encryptor.Setup(x => x.Encrypt(It.IsAny<string>())).Returns(encrypt);

            var user = GetUser();
            Repository.Setup(x => x.Login(It.IsAny<User>())).Returns(user);
           
            var service = new UserService(Repository.Object, Encryptor.Object);
            var userDto = GetUserAuthenticatedDto();

            var key = Encoding.ASCII.GetBytes("b9040de2d5764252b817dbbc1e6c0426");
            var result = service.Authenticate(GetUserDto(), key);

            Assert.NotNull(result);
            Assert.Equal(user.Email, result.UserEmail);
        }

        #endregion

        #region Private Methods

        private UserDto GetUserDto()
        {
            return new UserDto 
            {
                Email = "test",
                Password = "test"
            };
        }

        private UserAuthenticatedDto GetUserAuthenticatedDto()
        {
            return new UserAuthenticatedDto
            {
                Token = "test",
                UserEmail = "test"
            };
        }

        private User GetUser()
        {
            return new User
            {
               Email = "test",
               Id = 1,
               Logs = new List<Log>(),
               Password = "test"
            };
        }

        #endregion
    }
}
