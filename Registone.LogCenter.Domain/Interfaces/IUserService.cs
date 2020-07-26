using Registone.LogCenter.Domain.DataTransferObjects;

namespace Registone.LogCenter.Domain.Interfaces
{
    public interface IUserService
    {
        UserAuthenticatedDto Authenticate(UserDto user, byte[] key);
        void Register(UserDto user);
    }
}
