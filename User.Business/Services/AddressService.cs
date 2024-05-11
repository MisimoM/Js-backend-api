using Microsoft.AspNetCore.Identity;
using System.Diagnostics;
using User.Business.Dtos;
using User.Business.Mappers;
using User.Infrastructure.Entities;
using User.Infrastructure.Repositories;

namespace User.Business.Services
{
    public class AddressService(AddressRepository addressRepository, UserManager<UserEntity> userManager)
    {
        private readonly AddressRepository _addressRepository = addressRepository;
        private readonly UserManager<UserEntity> _userManager = userManager;

        public async Task<bool> CreateAddressAsync(string userId, AddressDto addressDto)
        {
            try
            {
                var user = await _userManager.FindByIdAsync(userId);

                if (user is not null && user.AddressId is null)
                {
                    var addressEntity = AddressCreationMapper.MapToEntity(addressDto);
                    await _addressRepository.AddAsync(addressEntity);
                    
                    user.AddressId = addressEntity.Id;
                    await _userManager.UpdateAsync(user);

                    return true;
                }

                return false;
            }
            catch (Exception ex) { Debug.WriteLine(ex.Message); throw; }
        }

        public async Task<bool> UpdateAddressAsync(string userId, AddressDto addressDto)
        {
            try
            {
                var user = await _userManager.FindByIdAsync(userId);

                if (user is not null && user.AddressId is not null)
                {
                    var existingAddress = await _addressRepository.GetAsync(a => a.Id == user.AddressId.Value);

                    if (existingAddress is not null)
                    {
                        AddressUpdateMapper.MapToEntity(addressDto, existingAddress);
                        var updatedAddress = await _addressRepository.UpdateAsync(a => a.Id == user.AddressId.Value, existingAddress);

                        if (updatedAddress is not null)
                            return true;
                    }
                }

                return false;
            }
            catch (Exception ex) { Debug.WriteLine(ex.Message); throw; }
        }

        public async Task<AddressEntity> GetAddressAsync(int addressId)
        {
            try
            {
                var getAddress = await _addressRepository.GetAsync(address => address.Id == addressId);

                if (getAddress is not null)
                    return getAddress;
            }
            catch (Exception ex) { Debug.WriteLine(ex.Message); }

            return null!;
        }
    }
}
