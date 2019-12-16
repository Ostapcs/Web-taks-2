using System;
using System.IdentityModel.Tokens.Jwt;
using System.Threading.Tasks;
using BLL.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;

namespace Web_Task2_Shop.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IAccountService _accountService;

        public AccountController(IAccountService accountService)
        {
            _accountService = accountService;
        }

        [HttpPost("token")]
        public async Task Token()
        {
            var email = Request.Form["email"];
            var password = Request.Form["password"];

            var claimsIdentity = _accountService.Authenticate(email, password);
            if (claimsIdentity == null)
            {
                Response.StatusCode = 400;
                await Response.WriteAsync("Invalid username or password.");
                return;
            }
            
            var now = DateTime.UtcNow;
            
            var jwt = new JwtSecurityToken(
                issuer: AuthOptions.ISSUER,
                audience: AuthOptions.AUDIENCE,
                notBefore: now,
                claims: claimsIdentity.Claims,
                expires: now.Add(TimeSpan.FromMinutes(AuthOptions.LIFETIME)),
                signingCredentials: new SigningCredentials(AuthOptions.GetSymmetricSecurityKey(), SecurityAlgorithms.HmacSha256));
            var encodedJwt = new JwtSecurityTokenHandler().WriteToken(jwt);
             
            var response = new
            {
                access_token = encodedJwt,
            };
 
            
            Response.ContentType = "application/json";
            await Response.WriteAsync(JsonConvert.SerializeObject(response,
                new JsonSerializerSettings
                {
                    Formatting = Formatting.Indented
                }));
        }
    }
}