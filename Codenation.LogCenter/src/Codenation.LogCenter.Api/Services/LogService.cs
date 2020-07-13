using Codenation.LogCenter.Api.DataTransferObjects;
using Codenation.LogCenter.Api.Exceptions;
using Codenation.LogCenter.Api.Interfaces;
using Codenation.LogCenter.Api.Models;
using Codenation.LogCenter.Api.Repositories;
using System;
using System.Collections.Generic;

namespace Codenation.LogCenter.Api.Services
{
    public class LogService : ILogService
    {
        #region Properties

        private ILogRepository LogRepository { get; set; }

        private UserRepository UserRepository { get; set; }

        #endregion

        #region Constructor
        public LogService(ILogRepository logRepository, LogCenterContext context)
        {
            LogRepository = logRepository;
            UserRepository = new UserRepository(context);
        }

        #endregion

        #region MyRegion

        public IList<LogDto> GetLogs()
        {
            var logs =  LogRepository.Get();
            var result = new List<LogDto>();
           
            foreach (var log in logs)
            {
                result.Add(new LogDto
                {
                    Id = log.Id,
                    Details = log.Details,
                    Level = log.Level,
                    Origin = log.Origin,
                    Title = log.Title,
                    CreatedAt = log.CreatedAt,
                    UserEmail = UserRepository.GetUserById(log.UserId).Email
                });
            }

            return result;
        }

        public IList<LogDto> GetLogsFiled()
        {
            var logs = LogRepository.GetFileds();
            var result = new List<LogDto>();

            foreach (var log in logs)
            {
                result.Add(new LogDto
                {
                    Id = log.Id,
                    Details = log.Details,
                    Level = log.Level,
                    Origin = log.Origin,
                    Title = log.Title,
                    CreatedAt = log.CreatedAt,
                    UserEmail = UserRepository.GetUserById(log.UserId).Email
                });
            }

            return result;
        }

        public void Register(LogRegisterDto dto)
        {
            var user = UserRepository.GetUserByEmail(dto.UserEmail);

            if (user is null) throw new UserNotFoundException(dto.UserEmail);

            LogRepository.Register(new Log()
            {
                Details = dto.Details,
                Filed = false,
                Level = dto.Level,
                Origin = dto.Origin,
                Title = dto.Title,
                CreatedAt = DateTime.Now,
                User = user,
                UserId = user.Id
            });
        }

        public void ArchiveLog(int id)
        {            
            var log = LogRepository.GetById(id);

            if (log is null) throw new LogNotFoundException(id);
            if (log.Filed) throw new LogFiledException();

            log.Filed = true;
            LogRepository.Update(log);
        }

        public void Remove(int id)
        {
            var log = LogRepository.GetById(id);

            if (log is null) throw new LogNotFoundException(id);

            LogRepository.Remove(new Log()
            {
                Id = id
            });
        }

        public IList<LogDto> FindByTitle(string description)
        {
            var logs = LogRepository.GetByTitle(description);

            if (logs is null) throw new LogNotFoundException();

            var logsDto = new List<LogDto>();

            foreach (var log in logs)
            {
                var user = UserRepository.GetUserById(log.UserId);

                if (user is null) throw new UserNotFoundException();

                logsDto.Add(
                    new LogDto
                    {
                        CreatedAt = log.CreatedAt,
                        Details = log.Details,
                        Id = log.Id,
                        Level = log.Level,
                        Origin = log.Origin,
                        Title = log.Title,
                        UserEmail = user.Email
                    }
                );
            }

            return logsDto;
        }

        public IList<LogDto> FindByLevel(string level)
        {
            var logs = LogRepository.GetByTitle(level);

            if (logs is null) throw new LogNotFoundException();

            var logsDto = new List<LogDto>();

            foreach (var log in logs)
            {
                var user = UserRepository.GetUserById(log.UserId);

                if (user is null) throw new UserNotFoundException();

                logsDto.Add(
                    new LogDto
                    {
                        CreatedAt = log.CreatedAt,
                        Details = log.Details,
                        Id = log.Id,
                        Level = log.Level,
                        Origin = log.Origin,
                        Title = log.Title,
                        UserEmail = user.Email
                    }
                );
            }

            return logsDto;
        }

        public IList<LogDto> FindByOrigin(string origin)
        {
            var logs = LogRepository.GetByOrigin(origin);

            if (logs is null) throw new LogNotFoundException();

            var logsDto = new List<LogDto>();

            foreach (var log in logs)
            {
                var user = UserRepository.GetUserById(log.UserId);

                if (user is null) throw new UserNotFoundException();

                logsDto.Add(
                    new LogDto
                    {
                        CreatedAt = log.CreatedAt,
                        Details = log.Details,
                        Id = log.Id,
                        Level = log.Level,
                        Origin = log.Origin,
                        Title = log.Title,
                        UserEmail = user.Email
                    }
                );
            }

            return logsDto;
        }

        #endregion
    }
}
