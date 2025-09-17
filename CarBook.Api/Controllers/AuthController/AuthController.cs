using CarBook.Application.Features.CQRS.Command.AuthCommand;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarBook.Api.Controllers.AuthController
{
    /// <summary>
    /// Controller for authentication operations (Login, Register, Token Refresh, Logout)
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IMediator _mediator;

        public AuthController(IMediator mediator)
        {
            _mediator = mediator;
        }

        /// <summary>
        /// Login endpoint - Returns access token and refresh token
        /// </summary>
        /// <param name="command">Login credentials (email, password)</param>
        /// <returns>Login result with tokens</returns>
        [HttpPost("Login")]
        [AllowAnonymous]
        public async Task<IActionResult> Login([FromBody] LoginCommand command)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            // Get IP address
            command.IpAddress = HttpContext.Connection.RemoteIpAddress?.ToString();

            var result = await _mediator.Send(command);

            if (!result.Success)
                return Unauthorized(new { message = result.Message });

            return Ok(result);
        }

        /// <summary>
        /// Register endpoint - Creates a new user
        /// </summary>
        /// <param name="command">Registration data</param>
        /// <returns>Registration result</returns>
        [HttpPost("Register")]
        [AllowAnonymous]
        public async Task<IActionResult> Register([FromBody] RegisterCommand command)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await _mediator.Send(command);

            if (!result.Success)
                return BadRequest(new { message = result.Message });

            return Ok(result);
        }

        /// <summary>
        /// Refresh token endpoint - Generates new access token using refresh token
        /// </summary>
        /// <param name="command">Refresh token</param>
        /// <returns>New access token and refresh token</returns>
        [HttpPost("RefreshToken")]
        [AllowAnonymous]
        public async Task<IActionResult> RefreshToken([FromBody] RefreshTokenCommand command)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            // Get IP address
            command.IpAddress = HttpContext.Connection.RemoteIpAddress?.ToString();

            var result = await _mediator.Send(command);

            if (!result.Success)
                return Unauthorized(new { message = result.Message });

            return Ok(result);
        }

        /// <summary>
        /// Logout endpoint - Revokes refresh token
        /// </summary>
        /// <param name="command">Refresh token to revoke</param>
        /// <returns>Logout result</returns>
        [HttpPost("Logout")]
        public async Task<IActionResult> Logout([FromBody] RevokeTokenCommand command)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            // Get IP address
            command.IpAddress = HttpContext.Connection.RemoteIpAddress?.ToString();

            var result = await _mediator.Send(command);

            if (!result.Success)
                return BadRequest(new { message = result.Message });

            return Ok(result);
        }

        /// <summary>
        /// Test endpoint to verify authentication
        /// </summary>
        /// <returns>Current user info</returns>
        [HttpGet("Me")]
        [Authorize]
        public IActionResult GetCurrentUser()
        {
            var userId = User.FindFirst("UserId")?.Value;
            var email = User.FindFirst(System.Security.Claims.ClaimTypes.Email)?.Value;
            var name = User.FindFirst(System.Security.Claims.ClaimTypes.Name)?.Value;

            return Ok(new
            {
                userId,
                email,
                name,
                message = "Authenticated successfully"
            });
        }
    }
}
