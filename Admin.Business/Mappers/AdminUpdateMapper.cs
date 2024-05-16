using Admin.Business.Dtos;
using Admin.Infrastructure.Entities;

namespace Admin.Business.Mappers
{
    public class AdminUpdateMapper
    {
        public static void MapToEntity(AdminDto dto, AdminEntity entity)
        {
            entity.FirstName = dto.FirstName;
            entity.LastName = dto.LastName;
            entity.Email = dto.Email;

            entity.NormalizedEmail = dto.Email;
            entity.UserName = dto.Email;
            entity.NormalizedUserName = dto.Email;

        }
    }
}
