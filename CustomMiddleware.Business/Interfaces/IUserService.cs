﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomMiddleware.Business.Interfaces
{
    public interface IUserService
    {
        public string Login(string username, string password);
    }
}