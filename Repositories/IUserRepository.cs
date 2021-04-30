﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MailSystemWebApi.Models;

namespace MailSystemWebApi.Repositories
{
    public interface IUserRepository<TDbModel> where TDbModel : User
    {
        public TDbModel checkLogin(string login, string password);
    }
}
