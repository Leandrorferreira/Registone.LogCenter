using Registone.LogCenter.Api.Models;

namespace Registone.LogCenter.Api.Interfaces
{
    public interface IUserRepository
    {
        void Register(User user);

        User Login(User user);

        User GetUserByEmail(string email);

        User GetUserById(int id);
    }
}
