using BusinessLayer.Interfaces;
using Microsoft.AspNetCore.Mvc;
using ModelLayer.DTOs;

namespace Fundoo.Controllers
{
    [ApiController]
    [Route("api/v1/user")]
    public class UserController : ControllerBase
    {
        // Holds an immutable reference to the user business logic service via Dependency Injection
        private readonly IUserService _userService;

        // Injects the IUserService instance via constructor dependency injection
        public UserController(IUserService userService)
        {
            _userService = userService;
        }


        // IActionResult provides standard HTTP status codes and responses for API endpoints
        // 'RegisterRequest' is the custom DTO type defining data structure; 'request' is the parameter holding the bound instance
        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterRequest request)
        {

            // Executes registration logic in the business layer asynchronously
            var result = await _userService.RegisterAsync(request);

            // Return 200 OK if registration succeeded
            if (result.Success == true)
            {
                return Ok(result);
            }
            // Return 409 Conflict if registration failed (e.g., duplicate email/user)
            else
            {
                return Conflict(result);
            }
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginRequest request)
        {

            // Invokes business service to validate credentials and generate JWT token
            var result = await _userService.LoginAsync(request);

            // Return 200 OK on successful authentication, otherwise return 401 Unauthorized
            return result.Success ? Ok(result) : Unauthorized(result);
        }

        [HttpPost("forgot-password")]
        public async Task<IActionResult> ForgotPassword([FromBody] ForgotPasswordRequest request)
        {
            var result = await _userService.ForgotPasswordAsync(request);
            return Ok(result);
        }

        [HttpPost("reset-password")]
        public async Task<IActionResult> ResetPassword([FromBody] ResetPasswordRequest request)
        {
            var result = await _userService.ResetPasswordAsync(request);
            return result.Success ? Ok(result) : BadRequest(result);
        }
    }
}
