using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.DtoEntities.UserDto
{
    public class CreateUserDto
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string Password { get; set; }
    }
}
