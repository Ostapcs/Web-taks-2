using System.Text;
using Microsoft.IdentityModel.Tokens;

namespace Web_Task2_Shop
{
    public class AuthOptions
    {
        public const string ISSUER = "Shop-Task";
        public const string AUDIENCE = "http://localhost:51884/";
        const string KEY = "mysuperpupersecret_key!400";
        public const int LIFETIME = 400;

        public static SymmetricSecurityKey GetSymmetricSecurityKey()
        {
            return new SymmetricSecurityKey(Encoding.ASCII.GetBytes(KEY));
        }
    }
}