using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.Configuration;
using EntityFrameWorkDataAccessLayer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Poco;

namespace WebAPI.Controllers

{
    //[Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class TokenController : ControllerBase
    {
        public IConfiguration _configuration;
        private readonly Context _context;
      
   
    public TokenController(IConfiguration config, Context context)
        {
            _configuration = config;
            _context = context;
        }

        [HttpPost]
        public ActionResult Post(User userData)
        {

            if (userData != null && userData.Email != null && userData.Password != null)
            {
                var user = GetUser(userData.Email, userData.Password);

                if (user != null)
                {

                    var claims = new[] {
                     new Claim(JwtRegisteredClaimNames.Sub, user.UserName),
                     new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                    new Claim(JwtRegisteredClaimNames.Iat, DateTime.UtcNow.ToString()),
                    new Claim("Id", user.Id.ToString()),
                    new Claim("Name", user.Name),
                    new Claim("Family", user.Family),
                    new Claim("Email", user.Email)


                   };


                    var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("4gSd0AsIoPvyD3PsXYNrP2XnVpIYCLLL"));

                    var signIn = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

                    var token = new JwtSecurityToken("DAC.Com", "", claims, expires: DateTime.UtcNow.AddDays(1), signingCredentials: signIn);

                    return Ok(new JwtSecurityTokenHandler().WriteToken(token));
                }
                else
                {
                    return BadRequest("Invalid credentials");
                }
            }
            else
            {
                return BadRequest();
            }
        }

        private User GetUser(string email, string password)
        {
            return _context.users.FirstOrDefault(u => u.Email == email && u.Password == password);
        }

    }
}
