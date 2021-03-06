﻿using System;
using System.Collections.Generic;
using System.Text;
using BLL.DtoEntities;
using BLL.DtoEntities.UserDto;

namespace BLL.Interfaces
{
    public interface IUserService
    {
        void Register(CreateUserDto userDto);

        void SetAdmin(int id);

        UpdatedUserDto Update(UpdatedUserDto updatedUser);

        UserInfoDto GetUserInfo(int id);
    }
}
