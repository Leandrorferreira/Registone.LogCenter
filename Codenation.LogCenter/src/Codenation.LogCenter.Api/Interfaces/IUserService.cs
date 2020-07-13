using Codenation.LogCenter.Api.DataTransferObjects;

namespace Codenation.LogCenter.Api.Interfaces
{
    public interface IUserService
    {
        UserAuthenticatedDto Authenticate(UserDto user, byte[] key);
        void Register(UserDto user);
    }
}
