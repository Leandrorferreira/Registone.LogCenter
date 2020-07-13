using System;

namespace Registone.LogCenter.Domain.Exceptions
{
    [Serializable]
    public class UserEmailAlreadyExistsException : Exception
    {
        public UserEmailAlreadyExistsException()
        {
        }

        public UserEmailAlreadyExistsException(string email)
            : base($"Email {email} already exists")
        {
        }
    }
}
