

using SolvexShop.Core.Domain.Enums;

namespace SolvexShop.Core.Application.Dtos.User
{
    public class SaveUserDto
    {
        public string Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string UserName { get; set; }
        public string IdentificationNumber { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }

        public Roles Role { get; set; }

    }
}
