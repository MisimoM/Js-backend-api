using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using User.Business.Dtos;
using User.Business.Services;
using User.Infrastructure.Entities;

namespace UserApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AddressController(AddressService addressService) : ControllerBase
    {
        private readonly AddressService _addressService = addressService;

        [HttpPost]
        public async Task<IActionResult> CreateAddressAsync(string userId, AddressDto dto)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var result = await _addressService.CreateAddressAsync(userId, dto);
                    if (result is true)
                    {
                        return Ok("Address created successfully.");
                    }
                    else
                    {
                        return Conflict("User already has an address.");
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
    }
}
