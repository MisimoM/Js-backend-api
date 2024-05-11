using Admin.Infrastructure.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Admin.Infrastructure.Contexts
{
    public class AdminDbContext(DbContextOptions<AdminDbContext> options) : IdentityDbContext<AdminEntity>(options)
    {

    }
}
