﻿using System.Collections.Generic;
using System.Threading.Tasks;
using LogProxy.Models;

namespace LogProxy.Services
{
    public interface IUserService
    {
        Task<User> Authenticate(string username, string password);
        Task<IEnumerable<User>> GetAll();
    }
}