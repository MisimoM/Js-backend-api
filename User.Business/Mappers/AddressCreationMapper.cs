using User.Business.Dtos;
using User.Infrastructure.Entities;

namespace User.Business.Mappers
{
    public class AddressCreationMapper
    {
        public static AddressEntity MapToEntity(AddressDto dto)
        {
            return new AddressEntity
            {
                AddressLine_1 = dto.AddressLine_1,
                AddressLine_2 = dto.AddressLine_2,
                PostalCode = dto.PostalCode,
                City = dto.City

            };

        }
    }
}
