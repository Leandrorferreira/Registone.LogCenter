using System;

namespace Registone.LogCenter.Api.Exceptions
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
