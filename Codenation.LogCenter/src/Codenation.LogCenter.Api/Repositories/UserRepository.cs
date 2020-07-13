using Codenation.LogCenter.Api.Interfaces;
using Codenation.LogCenter.Api.Models;
using System;
using System.Linq;

namespace Codenation.LogCenter.Api.Repositories
{
    public class UserRepository : IUserRepository
    {
        #region Properties
       
        private LogCenterContext Context;

        #endregion

        #region Constructor
        public UserRepository(LogCenterContext context)
        {
            Context = context;
        }

        #endregion

        #region Methods

        public void Register(User user)
        {
            try
            {
                Context.Users.Add(user);
                Context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            };
        }

        public User Login(User user)
        {
            try
            {
                return Context.Users.Where(u => u.Email == user.Email && u.Password == user.Password).FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw ex;
            };
        }

        public User GetUserByEmail(string email)
        {
            try
            {
                return Context.Users.Where(u => u.Email == email).FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw ex;
            };
        }

        public User GetUserById(int id)
        {
            try
            {
                return Context.Users.Where(u => u.Id == id).FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw ex;
            };
        }

        #endregion
    }
}
