using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;

namespace BLL.Interfaces
{
    public interface IAccountService
    {
        ClaimsIdentity Authenticate(string email, string password);
    }
}
