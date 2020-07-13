using System;

namespace Registone.LogCenter.Domain.Exceptions
{
    [Serializable]
    public class LogNotFoundException : Exception
    {
        public LogNotFoundException(int logId)
            : base($"Log {logId} not found")
        {
        }

        public LogNotFoundException()
        : base($"Log not found")
        {
        }
    }
}
