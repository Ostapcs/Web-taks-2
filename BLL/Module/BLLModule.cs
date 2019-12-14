using System;
using System.Collections.Generic;
using System.Text;
using BLL.Interfaces;
using BLL.Services;
using Microsoft.Extensions.DependencyInjection;

namespace BLL.Module
{
    public class BLLModule
    {
        public static void ConfigureBLLServices(IServiceCollection services)
        {
            DAL.Module.DALModule.ConfigureDALServices(services);
            services.AddTransient<IAccountService, AccountService>();
            services.AddTransient<IUserService, UserService>();
            services.AddTransient<IProductService, ProductService>();
        }
    }
}
