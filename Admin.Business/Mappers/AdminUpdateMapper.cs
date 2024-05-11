using Admin.Business.Dtos;
using Admin.Infrastructure.Entities;

namespace Admin.Business.Mappers
{
    public class AdminUpdateMapper
    {
        public static void MapToEntity(AdminDto dto, AdminEntity admin)
        {
            admin.FirstName = dto.FirstName;
            admin.LastName = dto.LastName;
            admin.Email = dto.Email;

            admin.NormalizedEmail = dto.Email;
            admin.UserName = dto.Email;
            admin.NormalizedUserName = dto.Email;

        }
    }
}
