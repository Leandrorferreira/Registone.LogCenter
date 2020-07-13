using Registone.LogCenter.Api.DataTransferObjects;
using Registone.LogCenter.Api.Exceptions;
using Registone.LogCenter.Api.Interfaces;
using Registone.LogCenter.Api.Models;

namespace Registone.LogCenter.Api.Services
{
    public class UserService : IUserService
    {
        #region Properties
        private IUserRepository Repository { get; set; }

        #endregion

        #region Constructor
        public UserService(IUserRepository repository)
        {
            Repository = repository;
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
