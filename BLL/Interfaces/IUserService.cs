﻿using System;
using System.Collections.Generic;
using System.Text;
using BLL.DtoEntities;

namespace BLL.Interfaces
{
    public interface IUserService
    {
        void Register(CreateUserDto userDto);
    }
}