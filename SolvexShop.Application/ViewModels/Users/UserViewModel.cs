﻿
namespace SolvexShop.Core.Application.ViewModels.Users
{
    public class UserViewModel
    {
        public string Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string IdentificationNumber { get; set; }
        public List<string> Roles { get; set; }
        public bool IsActive { get; set; }

    }
}
