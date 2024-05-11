using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using User.Business.Dtos;
using User.Business.Services;

namespace UserApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController(UserService userService) : ControllerBase
    {
        private readonly UserService _userService = userService;

        [HttpPost]
        public async Task<IActionResult> CreateUserAsync(UserDto dto)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var result = await _userService.CreateNewUserAsync(dto);

                    if (result is true)
                    {
                        return Ok("User created successfully.");
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
        public async Task<IActionResult> DeleteUserAsync(string userId)
        {
            try
            {
                var result = await _userService.DeleteUserAsync(userId);

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
        public async Task<IActionResult> UpdateUserAsync(string userId, UserDetailsDto userDetailsDto)
        {
            try
            {
                if(ModelState.IsValid)
                {
                    var result = await _userService.UpdateUserAsync(userId, userDetailsDto);

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
        public async Task<IActionResult> GetUsersAsync()
        {
            try
            {
                var result = await _userService.GetUsersAsync();

                if (result is not null)
                {
                    return Ok(result);
                }
                else
                {
                    return NotFound("No users found");
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
