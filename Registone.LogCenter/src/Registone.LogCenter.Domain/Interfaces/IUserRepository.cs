using Registone.LogCenter.Domain.Models;

namespace Registone.LogCenter.Domain.Interfaces
{
    public interface IUserRepository
    {
        void Register(User user);

        User Login(User user);

        User GetUserByEmail(string email);

        User GetUserById(int id);
    }
}
