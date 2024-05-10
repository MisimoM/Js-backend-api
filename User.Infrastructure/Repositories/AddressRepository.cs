using User.Infrastructure.Contexts;
using User.Infrastructure.Entities;

namespace User.Infrastructure.Repositories
{
    public class AddressRepository(UserDbContext dbContext) : BaseRepository<AddressEntity>(dbContext)
    {

    }
}
