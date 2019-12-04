using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BLL.DtoEntities;
using BLL.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Web_Task2_Shop.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost]
        [Route("register")]
        public IActionResult Register(CreateUserDto userDto)
        {
            _userService.Register(userDto);
            return Ok();
        }
    }
}