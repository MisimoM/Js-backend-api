using Admin.Business.Dtos;
using Admin.Business.Mappers;
using Admin.Infrastructure.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace Admin.Business.Services
{
    public class AdminService(UserManager<AdminEntity> userManager, RoleManager<IdentityRole> roleManager)
    {
        private readonly UserManager<AdminEntity> _userManager = userManager;

        public async Task<bool> CreateNewAdminAsync(AdminRegistrationDto adminDto)
        {
            try
            {
                var isUniqueEmail = await _userManager.FindByEmailAsync(adminDto.Email);

                if (isUniqueEmail is null)
                {
                    var adminEntity = AdminRegistrationMapper.MapToEntity(adminDto);
                    await _userManager.CreateAsync(adminEntity, adminDto.Password);
                    await _userManager.AddToRoleAsync(adminEntity, adminDto.Role);
                    return true;
                }

                return false;
            }
            catch (Exception ex) { Debug.WriteLine(ex.Message); throw; }
        }

        public async Task<bool> DeleteAdminAsync(string userId)
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

        public async Task<bool> UpdateAdminAsync(string userId, AdminUpdateDto adminDto)
        {
            try
            {
                var user = await _userManager.FindByIdAsync(userId);

                if (user is not null)
                {
                    var currentRoles = await _userManager.GetRolesAsync(user);
                    await _userManager.RemoveFromRolesAsync(user, currentRoles);

                    AdminUpdateMapper.MapToEntity(adminDto, user);
                    await _userManager.UpdateAsync(user);
                    await _userManager.AddToRoleAsync(user, adminDto.Role);
                    return true;
                }

                return false;
            }
            catch (Exception ex) { Debug.WriteLine(ex.Message); throw; }
        }

        public async Task<List<AdminResponseDto>> GetAdminsAsync()
        {
            try
            {
                var adminsEntities = await _userManager.Users.ToListAsync();
                var adminDtos = new List<AdminResponseDto>();

                foreach (var admins in adminsEntities)
                {
                    var roles = await _userManager.GetRolesAsync(admins);
                    var adminDto = AdminResponseMapper.MapToDto(admins);
                    adminDto.Role = roles.FirstOrDefault()!;

                    adminDtos.Add(adminDto);
                }

                if (adminDtos is not null)
                {
                    return adminDtos;
                }

                return null!;
            }
            catch (Exception ex) { Debug.WriteLine(ex.Message); throw; }
        }

        public async Task<AdminResponseDto> GetAdminByIdAsync(string userId)
        {
            try
            {
                var user = await _userManager.FindByIdAsync(userId);
                if (user is not null)
                {
                    var roles = await _userManager.GetRolesAsync(user);
                    var adminDto = AdminResponseMapper.MapToDto(user);
                    adminDto.Role = roles.FirstOrDefault()!;
                    return adminDto;
                }

                return null!;
            }
            catch (Exception ex) { Debug.WriteLine(ex.Message); throw; }
        }
    }
}
