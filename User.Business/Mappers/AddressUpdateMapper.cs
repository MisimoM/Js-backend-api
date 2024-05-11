using User.Business.Dtos;
using User.Infrastructure.Entities;

namespace User.Business.Mappers
{
    public class AddressUpdateMapper
    {
        public static void MapToEntity(AddressDto dto, AddressEntity addressEntity)
        {
            addressEntity.AddressLine_1 = dto.AddressLine_1;
            addressEntity.AddressLine_2 = dto.AddressLine_2;
            addressEntity.PostalCode = dto.PostalCode;
            addressEntity.City = dto.City;
        }
    }
}
