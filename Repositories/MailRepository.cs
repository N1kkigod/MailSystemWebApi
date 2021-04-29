using MailSystemWebApi.DataBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MailSystemWebApi.Repositories
{

    public class MailRepository<TDbModel> : IMailRepository<TDbModel> where TDbModel : Mail
    {
        private ApplicationContext Context { get; set; }
        public MailRepository(ApplicationContext context)
        {
            Context = context;
        }

        //private ApplicationContext Context { get; set; }
        public IEnumerable<TDbModel> getAllMail()
        {
            return Context.Set<TDbModel>().ToList();
        }
        public TDbModel getMailById()
        {
            return null;
        }
        public IEnumerable<TDbModel> getAllMailByUserId()
        {
            return Enumerable.Empty<TDbModel>();
        }

    }
}
