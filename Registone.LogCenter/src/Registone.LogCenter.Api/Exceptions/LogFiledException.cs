using System;

namespace Registone.LogCenter.Api.Exceptions
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
