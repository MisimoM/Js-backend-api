using Admin.Business.Dtos;
using Admin.Business.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;


namespace AdminApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class AdminController(AdminService adminService) : ControllerBase
    {
        private readonly AdminService _adminService = adminService;


        [HttpPost]
        public async Task<IActionResult> CreateAdminAsync(AdminRegistrationDto dto)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var result = await _adminService.CreateNewAdminAsync(dto);

                    if (result is true)
                    {
                        return Ok("Admin created successfully.");
                    }
                    else
                    {
                        return Conflict("Email already exists.");
                    }
                }
                else
                {
                    return BadRequest(ModelState);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);

                return StatusCode(StatusCodes.Status500InternalServerError, "An error occurred while processing your request.");
            }
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteAdminAsync(string userId)
        {
            try
            {
                var result = await _adminService.DeleteAdminAsync(userId);

                if (result is true)
                {
                    return Ok("User was deleted successfully.");
                }
                else
                {
                    return NotFound("User with the ID was not found");
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);

                return StatusCode(StatusCodes.Status500InternalServerError, "An error occurred while processing your request.");
            }
        }

        [HttpPut]
        public async Task<IActionResult> UpdateAdminAsync(string userId, AdminUpdateDto adminDto)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var result = await _adminService.UpdateAdminAsync(userId, adminDto);

                    if (result is true)
                    {
                        return Ok("User was updated successfully.");
                    }
                    else
                    {
                        return NotFound("User with the ID was not found");
                    }
                }
                else
                {
                    return BadRequest(ModelState);
                }

            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);

                return StatusCode(StatusCodes.Status500InternalServerError, "An error occurred while processing your request.");
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetAdminsAsync()
        {
            try
            {
                var result = await _adminService.GetAdminsAsync();

                if (result is not null)
                {
                    return Ok(result);
                }
                else
                {
                    return NotFound("No admins found");
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);

                return StatusCode(StatusCodes.Status500InternalServerError, "An error occurred while processing your request.");
            }
        }

        [HttpGet("{userId}")]
        public async Task<IActionResult> GetAdminByIdAsync(string userId)
        {
            try
            {
                var admin = await _adminService.GetAdminByIdAsync(userId);
                if (admin is not null)
                {
                    return Ok(admin);
                }
                else
                {
                    return NotFound("User with the ID was not found");
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                return StatusCode(StatusCodes.Status500InternalServerError, "An error occurred while processing your request.");
            }
        }

    }
}
