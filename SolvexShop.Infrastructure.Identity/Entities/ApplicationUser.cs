﻿

using Microsoft.AspNetCore.Identity;

namespace SolvexShop.Infrastructure.Identity.Entities
{
    public class ApplicationUser : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string IdentificationNumber { get; set; }
        public bool IsActive { get; set; }
        
    }
}
