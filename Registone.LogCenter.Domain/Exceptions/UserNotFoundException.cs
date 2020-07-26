using System;

namespace Registone.LogCenter.Domain.Exceptions
{
    [Serializable]
    public class UserNotFoundException : Exception
    {

        public UserNotFoundException(int id)
            : base($"User {id} not found")
        {
        }

        public UserNotFoundException(string email)
        : base($"No user was found with { email} email address")
        {
        }

        public UserNotFoundException()
        : base($"No user email address or password not found")
        {
        }
    }
}
