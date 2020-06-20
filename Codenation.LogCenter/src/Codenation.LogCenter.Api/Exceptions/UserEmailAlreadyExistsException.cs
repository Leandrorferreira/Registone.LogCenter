using System;
using System.Runtime.Serialization;

namespace Codenation.LogCenter.Api.Exceptions
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
