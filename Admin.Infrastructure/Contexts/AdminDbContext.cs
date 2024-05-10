using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Admin.Infrastructure.Contexts
{
    public class AdminDbContext(DbContextOptions options) : IdentityDbContext(options)
    {

    }
}
