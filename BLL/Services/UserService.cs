using System;
using System.Collections.Generic;
using System.Text;
using BLL.DtoEntities;
using BLL.DtoEntities.UserDto;
using BLL.Interfaces;
using BLL.Mappers;
using DAL.Entities;
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

        public void SetAdmin(int id)
        {
            var user = _db.Users.GetById(id);

            user.Role = "Admin";

            _db.Save();
        }

        public UpdatedUserDto Update(UpdatedUserDto updatedUser)
        {
            var user = _db.Users.GetById(updatedUser.Id);

            user.Name = updatedUser.Name;
            user.Surname = updatedUser.Surname;
            user.Email = updatedUser.Email;
            user.Address = updatedUser.Address;

            _db.Users.Update(user);

            _db.Save();

            return updatedUser;
        }

        public UserInfoDto GetUserInfo(int userId)
        {
            var user = _db.Users.GetById(userId);

            return user.ToUserInfo();
        }
    }
}
