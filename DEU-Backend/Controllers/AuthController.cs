using System.IdentityModel.Tokens.Jwt;
using DEU_Backend.Identity;
using DEU_Backend.Services;
using DEU_Lib.Model.Identity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace DEU_Backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController(UserManager<ApplicationUser> userManager, TokenService tokenService, AuthService authService) : ControllerBase
    {
        /// <summary>
        /// Register a new user
        /// </summary>
        /// <param name="model">AuthRequest</param>
        /// <returns></returns>
        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] AuthRequest model)
        {
            var user = new ApplicationUser { Email = model.Email, UserName = model.Email };
            var result = await userManager.CreateAsync(user, model.Password);

            if (result.Succeeded)
            {
                // Optionally assign roles to the user after successful registration
                return Ok();
            }
            return BadRequest(result.Errors);
        }

        /// <summary>
        /// Login with username and password
        /// </summary>
        /// <param name="model">AuthRequest</param>
        /// <returns></returns>
        /// <response code="200">Returns token and refresh token</response>
        /// <response code="401">Unauthorized</response>
        /// <response code="404">User not found</response>
        /// <response code="400">Bad request</response>
        /// <response code="500">Internal server error</response>
        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] AuthRequest model)
        {
            var user = await userManager.FindByNameAsync(model.Email);
            if (user != null && await userManager.CheckPasswordAsync(user, model.Password))
            {
                var token = await tokenService.GenerateToken(user);
                var refreshToken = TokenService.GenerateRefreshToken();
                var refreshTokenExpiryTime = DateTime.Now.AddDays(30);

                user.RefreshToken = refreshToken;
                user.RefreshTokenExpiryTime = refreshTokenExpiryTime;

                await userManager.UpdateAsync(user);

                return Ok(new { token, refreshToken, refreshTokenExpiryTime, email = user.Email, id = user.Id });
            }
            return Unauthorized();
        }
        /// <summary>
        /// Refresh token
        /// </summary>
        /// <param name="tokenModel">TokenModel</param>
        /// <returns></returns>
        /// <response code="200">Returns token and refresh token</response>
        /// <response code="400">Bad request</response>
        /// <response code="500">Internal server error</response>
        //[Authorize]
        [HttpPost]
        [Route("refresh-token")]
        public async Task<IActionResult> RefreshToken(TokenModel tokenModel)
        {
            if (tokenModel is null)
            {
                return BadRequest("Invalid client request");
            }

            var principal = tokenService.GetPrincipalFromExpiredToken(tokenModel.AccessToken);
            if (principal == null)
            {
                return BadRequest("Invalid access token or refresh token");
            }

            string? username = principal.Identity!.Name!;

            var user = await userManager.FindByEmailAsync(username);

            if (user == null || user.RefreshToken != tokenModel.RefreshToken || user.RefreshTokenExpiryTime <= DateTime.Now)
            {
                return BadRequest("Invalid access token or refresh token");
            }

            var token = await tokenService.GenerateToken(user);
            var refreshToken = TokenService.GenerateRefreshToken();
            var refreshTokenExpiryTime = DateTime.Now.AddDays(30);

            user.RefreshToken = refreshToken;
            user.RefreshTokenExpiryTime = refreshTokenExpiryTime;
            await userManager.UpdateAsync(user);

            return Ok(new { token, refreshToken, refreshTokenExpiryTime, email = user.Email, id = user.Id });
        }

        /// <summary>
        /// Get user profile
        /// </summary>
        /// <returns></returns>
        /// <response code="200">Returns user profile</response>
        /// <response code="404">User not found</response>
        /// <response code="401">Unauthorized</response>
        /// <response code="500">Internal server error</response>
        [Authorize]
        [HttpGet("profile")]
        public async Task<IActionResult> Profile()
        {
            var user = await userManager.FindByNameAsync(User.Identity!.Name!);
            if (user == null) return NotFound("User not found");

            var dbuser = await authService.GetUserProfileByIdAsync(user.Id);

            return Ok(new { dbuser.Email, dbuser.Id });
        }
    }
}