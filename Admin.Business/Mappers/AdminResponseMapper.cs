using Admin.Business.Dtos;
using Admin.Infrastructure.Entities;

namespace Admin.Business.Mappers
{
    public class AdminResponseMapper
    {
        public static AdminResponseDto MapToDto(AdminEntity entity)
        {
            return new AdminResponseDto
            {
                Id = entity.Id,
                FirstName = entity.FirstName,
                LastName = entity.LastName,
                Email = entity.Email!,
            };
        }
    }
}
