using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MailSystemWebApi.Repositories;
using MailSystemWebApi.Models;

namespace MailSystemWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private IUserRepository<User> UsersTable { get; set; }
        public UserController(IUserRepository<User> user)
        {
            UsersTable = user;
        }
        [HttpGet]
        public JsonResult Get(string login, string password)
        {
            return new JsonResult(UsersTable.checkLogin(login, password));
        }
    }
}
