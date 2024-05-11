using User.Business.Dtos;
using User.Infrastructure.Entities;

namespace User.Business.Mappers
{
    public class UserMapper
    {
        public static UserEntity MapToEntity(UserDto dto)
        {
            return new UserEntity
            {
                FirstName = dto.FirstName,
                LastName = dto.LastName,
                Email = dto.Email,
                UserName = dto.Email,
            };
        }
    }
}
