using System;
using System.Collections.Generic;
using System.Text;
using DAL.Context;
using DAL.Interfaces;
using DAL.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace DAL.Module
{
    public class DALModule
    {
        public static void ConfigureDALServices(IServiceCollection services)
        {
            //IServiceCollection services = new ServiceCollection();
            services.AddTransient<ICommentRepository, CommentRepository>();
            services.AddTransient<IOrderRepository, OrderRepository>();
            services.AddTransient<IProductOrdersRepository, ProductOrdersRepository>();
            services.AddTransient<IUserRepository, UserRepository>();
            services.AddTransient<IUnitOfWork, UnitOfWork.UnitOfWork>();
            services.AddTransient<ShopContext>();

            //return services.BuildServiceProvider();
        }
    }
}
