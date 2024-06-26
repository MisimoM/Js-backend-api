﻿using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using User.Business.Dtos;
using User.Business.Services;

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

        [HttpPut]
        public async Task<IActionResult> UpdateAddressAsync(string userId, AddressDto dto)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var result = await _addressService.UpdateAddressAsync(userId, dto);

                    if (result is true)
                    {
                        return Ok("Address updated successfully.");
                    }
                    else
                    {
                        return NotFound("User or address not found.");
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
        public async Task<IActionResult> GetAddressAsync(int addressId)
        {
            try
            {
                var result = await _addressService.GetAddressAsync(addressId);

                if (result is not null)
                {
                    return Ok(result);
                }
                else
                {
                    return NotFound();
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
