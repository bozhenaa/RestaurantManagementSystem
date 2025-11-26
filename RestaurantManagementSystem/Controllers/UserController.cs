using Microsoft.AspNetCore.Mvc;
using RestaurantManagementSystem.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using Microsoft.AspNetCore.Authorization;
using RestaurantManagementSystem.Models;
using RestaurantManagementSystem.DTOs;

namespace RestaurantManagementSystem.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IAuthService _authService;
        public UserController(IUserService userService, IAuthService authService)
        {
            _userService = userService;
            _authService = authService;
        }

        [HttpGet("by-username/{username}")]
        public async Task<IActionResult> GetUserByUsername(string username)
        {
            var user = await _userService.GetUserByUsername(username);
            if (user == null)
            {
                return NotFound($"User with username {username} not found.");
            }
            return Ok(user);
        }

        [HttpGet("by-email/{email}")]
        public async Task<IActionResult> GetUserByEmail(string email)
        {

            var user = await _userService.GetUserByEmail(email);
            if (user == null)
            {
                return NotFound($"User with email {email} not found.");
            }
            return Ok(user);
        }

        [HttpPost("register-user")]
        public async Task<IActionResult> RegisterUser([FromBody] RegisterUserDto request)
        {
            try
            {
                await _authService.RegisterUser(request);
                return Created();
            }
            catch (ArgumentNullException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (InvalidCastException ex)
            {
                return Conflict(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPost("login-user")]
        public async Task<IActionResult> LogInUser([FromBody] LogInDto request)
        {
            try
            {
                await _authService.LogInUser(request);
                return Ok();
            }
            catch (ArgumentNullException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (UnauthorizedAccessException ex)
            {
                return Unauthorized(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}
