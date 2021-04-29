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
        [HttpGet]
        public JsonResult Get()
        {
            return new JsonResult(Mails.getAllMail());
        }
    }
}
