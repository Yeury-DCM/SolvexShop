﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolvexShop.Core.Application.Interfaces.Services
{
    public interface ICurrentUserService
    {
        public string UserId { get; }
        public string UserName { get; }
    }
}
