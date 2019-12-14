using System.Threading.Tasks;
using BLL.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

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

            var jwtToken = _accountService.Authenticate(email, password);

            Response.ContentType = "application/json";

            await Response.WriteAsync(jwtToken);

        }
    }
}