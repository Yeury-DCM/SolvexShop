﻿

namespace SolvexShop.Core.Application.Dtos.User
{
    public class UserDto
    {
        public string Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string UserName { get; set; }
        public string IdentificationNumber { get; set; }
        public bool IsActive { get; set; }

        public List<string> Roles { get; set; }

    }
}
