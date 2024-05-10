using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using User.Infrastructure.Entities;

namespace User.Infrastructure.Contexts
{
    public class UserDbContext(DbContextOptions<UserDbContext> options) : IdentityDbContext<UserEntity>(options)
    {
        public DbSet<AddressEntity> Address { get; set; }
    }
}
