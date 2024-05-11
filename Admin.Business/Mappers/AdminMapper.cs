using Admin.Business.Dtos;
using Admin.Infrastructure.Entities;

namespace Admin.Business.Mappers
{
    public class AdminMapper
    {
        public static AdminEntity MapToEntity(AdminDto dto)
        {
            return new AdminEntity
            {
                FirstName = dto.FirstName,
                LastName = dto.LastName,
                Email = dto.Email,
                UserName = dto.Email,
            };
        }
    }
}
