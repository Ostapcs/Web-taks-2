using System;
using System.Collections.Generic;
using System.Text;
using BLL.DtoEntities;
using BLL.Interfaces;
using BLL.Mappers;
using DAL.Interfaces;

namespace BLL.Services
{
    public class UserService : IUserService
    {
        private readonly IUnitOfWork _db;

        public UserService(IUnitOfWork db)
        {
            _db = db;
        }

        public void Register(CreateUserDto userDto)
        {
            var pass = PasswordHashService.Hash(userDto.Password);

            var user = userDto.ToUser();

            user.Role = "User";
            user.Password = pass;

            _db.Users.Add(user);
            _db.Save();
        }
    }
}
