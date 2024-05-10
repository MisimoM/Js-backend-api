using Microsoft.AspNetCore.Identity;

namespace Admin.Infrastructure.Entities
{
    public class AdminEntity : IdentityUser
    {
        public string FirstName { get; set; } = null!;

        public string LastName { get; set; } = null!;
    }
}
