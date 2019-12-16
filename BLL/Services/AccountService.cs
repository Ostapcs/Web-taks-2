using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;
using BLL.Interfaces;
using DAL.Interfaces;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security;
using Newtonsoft.Json;


namespace BLL.Services
{
    class AccountService: IAccountService
    {
        private readonly IUnitOfWork _database;

        public AccountService(IUnitOfWork database)
        {
            _database = database;
        }

//        private string GenerateToken(ClaimsIdentity identity)
//        {
//            var now = DateTime.UtcNow;
//
//            var jwt = new JwtSecurityToken(
//                issuer: AuthOptions.AuthOptions.ISSUER,
//                audience: AuthOptions.AuthOptions.AUDIENCE,
//                notBefore: now,
//                claims: identity.Claims,
//                expires: now.Add(TimeSpan.FromMinutes(AuthOptions.AuthOptions.LIFETIME)),
//                signingCredentials: new SigningCredentials(AuthOptions.AuthOptions.GetSymmetricSecurityKey(), SecurityAlgorithms.HmacSha256));
//
//            var encodedJwt = new JwtSecurityTokenHandler().WriteToken(jwt);
//
//            return encodedJwt;
//        }

        public ClaimsIdentity Authenticate(string username, string password)
        {
            var claims = GetAccessToken(username, password);
            return claims;
//            var response = new
//            {
//                access_token = accessToken
//            };
//
//            return JsonConvert.SerializeObject(response, new JsonSerializerSettings()
//            {
//                Formatting = Formatting.Indented
//            });
        }

        private ClaimsIdentity GetAccessToken(string username, string password)
        {
            var user = _database.Users.GetUserByEmail(username);

            //var userHashPass = PasswordHashService.Hash(password);

            if (!PasswordHashService.Check(user.Password, password).Verified)
            {
                throw new SecurityException("Invalid email or password");
            }

            var identity = GetIdentity(user.Id, user.Name, user.Email, user.Role);

            return identity;
        }

        private ClaimsIdentity GetIdentity(int userId,string name, string email, string role)
        {
            var claims = new List<Claim>
            {
                new Claim("Id", userId.ToString()),
                new Claim(ClaimsIdentity.DefaultNameClaimType, name),
                new Claim(JwtRegisteredClaimNames.Email, email),
                new Claim(ClaimsIdentity.DefaultRoleClaimType, role),
            };
            var claimsIdentity =
                new ClaimsIdentity(claims, "Token", ClaimsIdentity.DefaultNameClaimType,
                    ClaimsIdentity.DefaultRoleClaimType);

            return claimsIdentity;
        }
    }
}
