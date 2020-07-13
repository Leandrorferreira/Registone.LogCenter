using Registone.LogCenter.Api.DataTransferObjects;
using System.Collections.Generic;

namespace Registone.LogCenter.Api.Interfaces
{
    public interface ILogService
    {
        IList<LogDto> GetLogs();
        IList<LogDto> GetLogsFiled();
        void Register(LogRegisterDto dto);
        void ArchiveLog(int id);
        void Remove(int id);
        IList<LogDto> FindByTitle(string description);
        IList<LogDto> FindByLevel(string level);
        IList<LogDto> FindByOrigin(string origin);
    }
}
