using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using User.Business.Dtos;
using User.Business.Mappers;
using User.Infrastructure.Entities;

namespace User.Business.Services
{
    public class UserService(UserManager<UserEntity> userManager)
    {
        private readonly UserManager<UserEntity> _userManager = userManager;

        public async Task<bool> CreateNewUserAsync(UserDto userDto)
        {
            try
            {
                var isUniqueEmail = await _userManager.FindByEmailAsync(userDto.Email);

                if (isUniqueEmail is null)
                {
                    var userEntity = UserMapper.MapToEntity(userDto);
                    await _userManager.CreateAsync(userEntity, userDto.Password);
                    return true;
                }

                return false;
            }
            catch (Exception ex) { Debug.WriteLine(ex.Message); throw; }
        }

        public async Task<bool> DeleteUserAsync(string userId)
        {
            try
            {
                var user = await _userManager.FindByIdAsync(userId);

                if (user is not null)
                {
                    await _userManager.DeleteAsync(user);
                    return true;
                }

                return false;
            }
            catch (Exception ex) { Debug.WriteLine(ex.Message); throw; }
        }

        public async Task<bool> UpdateUserAsync(string userId, UserDetailsDto userDetailsDto)
        {
            try
            {
                var user = await _userManager.FindByIdAsync(userId);

                if (user is not null)
                {
                    UserDetailsMapper.MapToEntity(userDetailsDto, user);
                    await _userManager.UpdateAsync(user);
                    return true;
                }

                return false;
            }
            catch (Exception ex) { Debug.WriteLine(ex.Message); throw; }
        }

        public async Task<List<UserEntity>> GetUsersAsync()
        {
            try
            {
                var users = await _userManager.Users.ToListAsync();

                if (users is not null)
                {
                    return users;
                }

                return null!;
            }
            catch (Exception ex) { Debug.WriteLine(ex.Message); throw; }
        }

    }
}
