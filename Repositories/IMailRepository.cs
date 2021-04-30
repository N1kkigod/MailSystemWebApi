using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MailSystemWebApi.Repositories
{
    public interface IMailRepository<TDbModel> where TDbModel : Mail
    {
        public IEnumerable<TDbModel> getAllMail();
        public TDbModel getMailById();
        public IEnumerable<TDbModel> getAllMailByUserId(int UserId);
        public bool createMailByUser(string title, DateTime date, int addresseeId, int addresserId, string content);
    }
}
