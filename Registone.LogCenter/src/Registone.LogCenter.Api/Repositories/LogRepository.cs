using Registone.LogCenter.Domain.Interfaces;
using Registone.LogCenter.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Registone.LogCenter.Api.Repositories
{
    public class LogRepository : ILogRepository
    {
        #region Properties

        private LogCenterContext Context;

        #endregion

        #region Constructor
        public LogRepository(LogCenterContext context)
        {
            Context = context;
        }

        #endregion

        #region Methods

        public IList<Log> Get()
        {
            try
            {
                return Context.Logs.Where(l => l.Filed == false).ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public IList<Log> GetFileds()
        {
            try
            {
                return Context.Logs.Where(l => l.Filed).ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Register(Log log)
        {
            try
            {
                Context.Logs.Add(log);
                Context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Remove(Log log)
        {
            try
            {
                Context.Logs.Remove(log);
                Context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Update(Log log)
        {
            try
            {
                Context.Logs.Update(log);
                Context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Log GetById(int id)
        {
            try
            {
                return Context.Logs.AsNoTracking().Where(l => l.Id == id).FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public IList<Log> GetByTitle(string title)
        {
            try
            {
                return Context.Logs.AsNoTracking().Where(x => x.Title == title && x.Filed == false).ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public IList<Log> GetByLevel(string level)
        {
            try
            {
                return Context.Logs.AsNoTracking().Where(x => x.Level == level && x.Filed == false).ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public IList<Log> GetByOrigin(string origin)
        {
            try
            {
                return Context.Logs.AsNoTracking().Where(x => x.Origin == origin && x.Filed == false).ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion
    }
}
