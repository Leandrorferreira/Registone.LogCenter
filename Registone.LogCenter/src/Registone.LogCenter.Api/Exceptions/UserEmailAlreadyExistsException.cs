using System;
using System.Runtime.Serialization;

namespace Registone.LogCenter.Api.Exceptions
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
