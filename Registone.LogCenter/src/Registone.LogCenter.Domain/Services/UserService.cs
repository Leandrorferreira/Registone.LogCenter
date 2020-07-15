using Registone.LogCenter.Domain.DataTransferObjects;
using Registone.LogCenter.Domain.Exceptions;
using Registone.LogCenter.Domain.Interfaces;
using Registone.LogCenter.Domain.Models;
using Registone.LogCenter.Services;

namespace Registone.LogCenter.Domain.Services
{
    public class UserService : IUserService
    {
        #region Properties

        private IUserRepository Repository { get; set; }
        public IEncryptor Encryptor { get; set; }

        #endregion

        #region Constructor

        public UserService(IUserRepository repository, IEncryptor encryptor)
        {
            Repository = repository;
            Encryptor = encryptor;
        }

        #endregion

        #region Methods

        public UserAuthenticatedDto Authenticate(UserDto user, byte[] key)
        {
            var userRegister = new User
            {
                Email = user.Email,
                Password = Encryptor.Encrypt(user.Password)
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
            if(Repository.GetUserByEmail(user.Email) != null)
            {
                throw new UserEmailAlreadyExistsException(user.Email);
            }

            var userRegister = new User
            {
                Email = user.Email,
                Password = Encryptor.Encrypt(user.Password)
            };

            Repository.Register(userRegister);
        }
        
        #endregion
    }
}
