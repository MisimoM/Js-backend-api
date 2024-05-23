using User.Business.Dtos;
using User.Infrastructure.Entities;

namespace User.Business.Mappers
{
    public class UserResponseMapper
    {
        public static UserResponseDto MapToDto(UserEntity entity)
        {
            return new UserResponseDto
            {
                Id = entity.Id,
                FirstName = entity.FirstName,
                LastName = entity.LastName,
                Email = entity.Email!,
                Phone = entity.PhoneNumber,
                Bio = entity.Bio
            };
        }
    }
}
