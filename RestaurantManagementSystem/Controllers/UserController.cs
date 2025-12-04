using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using Microsoft.AspNetCore.Authorization;
using RestaurantManagementSystem.Data;
using RestaurantManagementSystem.DTOs;
using RestaurantManagementSystem.Services.IServices;

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
        [AllowAnonymous]
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
        [AllowAnonymous]
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
        [AllowAnonymous]
        //[Authorize(Roles ="admin, employee, client")]
        //nqma kak da se registrirash za6toto nqmash rolq 
        public async Task<IActionResult> RegisterUser([FromBody] RegisterUserModel request)
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
        [Authorize(Roles = "admin, employee, client")]
        public async Task<IActionResult> LogInUser([FromBody] LogInModel request)
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

        [HttpPut("update-user")]
        [Authorize(Roles = "admin, employee, client")]
        public async Task<IActionResult> UpdateUser([FromBody] UpdateUserInfoModel request)
        {
            try
            {
                await _userService.UpdateUser(request);
                return Ok();
            }
            catch (ArgumentNullException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpDelete("delete-user")]
        [Authorize(Roles = "admin, employee, client")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            try
            {
                await _userService.DeleteUser(id);
                return Ok();
            }
            catch (ArgumentNullException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet]
        [Route("Admin")]
        [Authorize(Roles = "admin")]
        public ActionResult<string> AdminProfile()
        {
            return Ok("Welcome, admin!");
        }

        [HttpGet]
        [Route("Client")]
        [Authorize(Roles = "client")]
        public ActionResult<string> ClientProfile()
        {
            return Ok("Welcome, client!");
        }

        [HttpGet]
        [Route("All")]
        [Authorize(Roles = "admin, client")]
        public ActionResult<string> AllProfile()
        {
            return Ok("Welcome, Client or Admin!");
        }

    }
}
