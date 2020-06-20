using System;

namespace Codenation.LogCenter.Api.Exceptions
{
    [Serializable]
    public class LogFiledException : Exception
    {
        public LogFiledException()
            : base($"The informed Log already was filed")
        {
                
        }
    }
}
