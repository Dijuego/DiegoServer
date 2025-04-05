using System.IdentityModel.Tokens.Jwt;
using DiegoServer.Dtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Model;

namespace DiegoServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController(UserManager<WorldUser> userManager, JwtHandler jwtHandler) : ControllerBase
    {
        [HttpPost("Login")]
        public async Task<ActionResult> LoginAsync(LoginRequest request)
        {
            WorldUser user = await userManager.FindByNameAsync(request.UserName);
            if (user == null)
            {
                return Unauthorized("Unkown User");
            }
            bool success = await userManager.CheckPasswordAsync(user, request.Password);
            if (!success)
            {
                return Unauthorized("Bad Password");
            }

            JwtSecurityToken token = await jwtHandler.GetTokenAsync(user);

            string tokenString = new JwtSecurityTokenHandler().WriteToken(token);

            return Ok(new LoginResponse
            {
                Success = true,
                Message = "Mom Loves Me",
                Token = tokenString
            });
        }

    }
}
