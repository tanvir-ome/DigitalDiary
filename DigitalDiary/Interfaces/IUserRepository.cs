﻿using DigitalDiary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigitalDiary.Interfaces
{
    interface IUserRepository : IRepository<User>
    {
        User GetLogInInfo(string username, string password);
    }
}
