using Microsoft.AspNetCore.Identity;

namespace User.Infrastructure.Entities
{
    public class UserEntity : IdentityUser
    {
        public string? ProfileImage { get; set; }

        public string? Bio { get; set; }

        public string FirstName { get; set; } = null!;

        public string LastName { get; set; } = null!;

        public int? AddressId { get; set; }
        public AddressEntity? Address { get; set; }
    }
}
