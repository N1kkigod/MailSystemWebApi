using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MailSystemWebApi.DataBase;
using MailSystemWebApi.Models;
using MailSystemWebApi.Repositories;

namespace MailSystemWebApi.Repositories
{
    public class UserRepository<TDbModel> : IUserRepository<TDbModel> where TDbModel : User
    {
        private ApplicationContext Context { get; set; }
        public UserRepository(ApplicationContext context)
        {
            Context = context;
        }
        public TDbModel checkLogin(string login, string password)
        {
            try 
            {
                int searchUser = Context.Set<TDbModel>().Where(user => user.UserName == login).First().UserID;
                //var selectedUser = Context.Set<TDbModel>().Select(
                //    (user, username) => new { User = user, UserName = username }).Where(user => user.UserName == login)
                //    .Select(user => user.UserID);

                //int id = Context.Set<TDbModel>().Find
                if (Context.Set<TDbModel>().Find(searchUser).Password == password)
                    return Context.Set<TDbModel>().Find(searchUser);
                else
                    return null;
            }
            catch
            {
                throw;
            }
        }
    }
}
