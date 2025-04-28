﻿using Microsoft.AspNetCore.Http;
using SolvexShop.Core.Application.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace SolvexShop.Core.Application.Services
{
    public class CurrentUserService : ICurrentUserService
    {


        private readonly IHttpContextAccessor _httpContextAccessor;

        public CurrentUserService(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public string UserId => _httpContextAccessor.HttpContext?.User?.FindFirst(ClaimTypes.NameIdentifier)?.Value;
        public string UserName => _httpContextAccessor.HttpContext?.User?.Identity?.Name;


    }
}
