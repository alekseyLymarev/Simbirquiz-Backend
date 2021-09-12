using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using SimbirSquize.Data;
using SimbirSquize.Data.Dtos;

namespace SimbirSquize.Controllers
{
    [Route("api/v1/identity")]
    [ApiController]
    public class IdentityController : AbstractController
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly IConfiguration _configuration;

        public IdentityController(UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager, IConfiguration configuration)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _configuration = configuration;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginDto loginData)
        {
            var user = await _userManager.Users.FirstOrDefaultAsync(x => x.Email.Equals(loginData.Email));
            var result = await _signInManager.CheckPasswordSignInAsync(user, loginData.Password, false);
            if (result.Succeeded)
            {
                return Ok(new
                {
                    Token = GenerateToken(user)
                });
            }

            return BadRequest(WrapToResponse(new {Message = "OK! It's Worked"}));
        }

        private string GenerateToken(ApplicationUser user)
        {
            var claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Sub, user.Email),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(ClaimTypes.Name, user.Email),
                new Claim("Id", user.Id.ToString())
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var expires = DateTime.Now.AddDays(Convert.ToDouble(_configuration["Jwt:ExpireDays"]));

            var token = new JwtSecurityToken(
                _configuration["Jwt:Issuer"],
                _configuration["Jwt:Issuer"],
                claims,
                expires: expires,
                signingCredentials: creds
            );

            return new JwtSecurityTokenHandler().WriteToken(token).ToString();
        }

        [HttpPost("registration")]
        public async Task<IActionResult> Registration([FromBody] RegistrationDto registrationData)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(WrapErrorResponse(ModelState));
            }

            var user = new ApplicationUser
            {
                Email = registrationData.Email,
                UserName = registrationData.Email
            };

            var result = await _userManager.CreateAsync(user, registrationData.Password);
            if (result.Succeeded)
            {
                return Ok(WrapToResponse(new
                {
                    Message = "Пользователь зарегистрирован"
                }));
            }

            return BadRequest();
        }
    }
}