using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.Interfaces
{
    public interface IAccountService
    {
        string Authenticate(string email, string password);
    }
}
