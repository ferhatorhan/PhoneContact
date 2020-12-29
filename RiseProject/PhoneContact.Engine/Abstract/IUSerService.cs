﻿using PhoneContact.Core.Helpers;
using PhoneContact.Engine.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PhoneContact.Engine.Abstract
{
    public interface IUSerServices
    {
        Task<UserResponse> Authenticate(string username, string password);

    }
}
