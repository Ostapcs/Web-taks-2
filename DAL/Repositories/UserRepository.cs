﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL.Context;
using DAL.Entities;
using DAL.Interfaces;

namespace DAL.Repositories
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        public UserRepository(ShopContext shopContext) : base(shopContext)
        {
        }

        public User GetUserByEmail(string email)
        {
            return dbContext.Users.FirstOrDefault(u => u.Email == email);
        }
    }
}
