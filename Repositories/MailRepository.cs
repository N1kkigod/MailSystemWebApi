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

        //getAllMail() - возвращает Context всех писем
        public IEnumerable<TDbModel> getAllMail()
        {
            return Context.Set<TDbModel>().ToList();
        }
        //getMailById() - возвращает Context письма по его ID
        public TDbModel getMailById()
        {
            return null;
        }
        //getAllMailByUserId() - возвращает Context всех писем, в которых содержится ID пользователя
        public IEnumerable<TDbModel> getAllMailByUserId(int UserId)
        {
            List<TDbModel> mailsByUserId = new List<TDbModel>();
            foreach(TDbModel mailByUserId in Context.Set<TDbModel>().ToList())
            {
                if(mailByUserId.AddresseeID == UserId || mailByUserId.AddresserID == UserId)
                    mailsByUserId.Add(mailByUserId);
            }
            return mailsByUserId;
        }
        public bool createMailByUser(string title, DateTime date, int addresseeId, int addresserId, string content)
        {
            try
            {
                TDbModel nMail = (TDbModel)new Mail();
                nMail.MailID = Context.Set<TDbModel>().OrderBy(TDbModel => TDbModel.MailID).Last().MailID + 1;
                nMail.Title = title;
                nMail.Date = date;
                nMail.AddresseeID = addresseeId;
                nMail.AddresserID = addresserId;
                nMail.MailContent = content;
                Context.Set<TDbModel>().Add(nMail);
                Context.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

    }
}
