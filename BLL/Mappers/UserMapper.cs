using System;
using System.Collections.Generic;
using System.Text;
using BLL.DtoEntities;
using DAL.Entities;

namespace BLL.Mappers
{
    public static class UserMapper
    {
        public static User ToUser(this CreateUserDto userDto)
        {
            return new User
            {
                Name = userDto.Name,
                Surname = userDto.Surname,
                Address = userDto.Address,
                Email = userDto.Email,
                Password = userDto.Password
            };
        }
    }
}
