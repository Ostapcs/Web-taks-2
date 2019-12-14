using BLL.DtoEntities;
using BLL.DtoEntities.UserDto;
using BLL.Interfaces;
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

        [HttpPut]
        [Route("update")]
        public IActionResult Update(UpdatedUserDto updatedUser)
        {
            return Ok(_userService.Update(updatedUser));
        }

        [HttpGet]
        [Route("info/{id}")]
        public IActionResult GetUserInfo(int id)
        {
            return Ok(_userService.GetUserInfo(id));
        }
    }
}