using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        ICommentRepository Comments { get; }
        IOrderRepository Orders { get; }
        IProductOrdersRepository ProductOrders { get; }
        IProductRepository Products { get; }
        IUserRepository Users { get; }
        ICartProductsRepository CartProducts { get; }

        void Save();
    }
}
