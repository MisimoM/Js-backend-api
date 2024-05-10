using User.Business.Dtos;
using User.Infrastructure.Entities;

namespace User.Business.Mappers
{
    public class UserDetailsMapper
    {
        public static void MapToEntity(UserDetailsDto dto, UserEntity user)
        {
            user.FirstName = dto.FirstName;
            user.LastName = dto.LastName;
            user.Email = dto.Email;
            user.PhoneNumber = dto.Phone;
            user.Bio = dto.Bio;

            user.NormalizedEmail = dto.Email;
            user.UserName = dto.Email;
            user.NormalizedUserName = dto.Email;
        }
    }
}
