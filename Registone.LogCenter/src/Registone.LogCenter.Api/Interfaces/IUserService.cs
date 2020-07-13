using Registone.LogCenter.Api.DataTransferObjects;

namespace Registone.LogCenter.Api.Interfaces
{
    public interface IUserService
    {
        UserAuthenticatedDto Authenticate(UserDto user, byte[] key);
        void Register(UserDto user);
    }
}
