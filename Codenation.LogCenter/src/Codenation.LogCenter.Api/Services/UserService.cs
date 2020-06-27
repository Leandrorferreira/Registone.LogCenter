using Codenation.LogCenter.Api.DataTransferObjects;
using Codenation.LogCenter.Api.Exceptions;
using Codenation.LogCenter.Api.Models;
using Codenation.LogCenter.Api.Repositories;

namespace Codenation.LogCenter.Api.Services
{
    public class UserService
    {
        #region Properties
        private UserRepository Repository { get; set; }

        #endregion

        #region Constructor
        public UserService(LogCenterContext context)
        {
            Repository = new UserRepository(context);
        }

        #endregion

        #region Methods

        public UserAuthenticatedDto Authenticate(UserDto user, byte[] key)
        {
            var userRegister = new User
            {
                Email = user.Email,
                Password = user.Password
            };

            var result = Repository.Login(userRegister);

            if (result is null) throw new UserNotFoundException();
      
            return new UserAuthenticatedDto
            {
                Token = TokenService.GenerateToken(result, key),
                UserEmail = user.Email
            }; ;
        }

        public void Register(UserDto user)
        {
            var userRegister = new User
            {
                Email = user.Email,
                Password = user.Password
            };

            Repository.Register(userRegister);
        }
        
        #endregion
    }
}
