using System;

namespace Registone.LogCenter.Domain.Exceptions
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
