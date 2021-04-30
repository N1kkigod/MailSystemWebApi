using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MailSystemWebApi.Repositories;

namespace MailSystemWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MailController : ControllerBase
    {
        private IMailRepository<Mail> Mails { get; set; }
        public MailController(IMailRepository<Mail> mail)
        {
            Mails = mail;
        }
        //[HttpGet]
        //public JsonResult Get()
        //{
        //    return new JsonResult(Mails.getAllMail());
        //}
        [HttpGet]
        public JsonResult Get(int userId)
        {
            return new JsonResult(Mails.getAllMailByUserId(userId));
        }
        [HttpPost]
        public JsonResult Post(Mail mail)
        {
            return new JsonResult(Mails.createMailByUser(mail));
        }
        [HttpDelete]
        public JsonResult Delete(int mailID)
        {
            JsonResult jsonResult = new JsonResult(Mails.deleteMailByUser(mailID));
            jsonResult.StatusCode = 200;
            return jsonResult;
        }
    }
}
