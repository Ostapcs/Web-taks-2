using System;
using System.Collections.Generic;
using System.Text;
using DAL.Context;
using DAL.Interfaces;
using DAL.Repositories;

namespace DAL.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ShopContext _shopContext;

        public ICommentRepository Comments { get; }
        public IOrderRepository Orders { get; }
        public IProductOrdersRepository ProductOrders { get; }
        public IProductRepository Products { get; }
        public IUserRepository Users { get; }
        public ICartProductsRepository CartProducts { get; }

        public void Save()
        {
            _shopContext.SaveChanges();
        }

        public UnitOfWork(ShopContext shopContext)
        {
            _shopContext = shopContext;
            Comments = new CommentRepository(shopContext);
            Orders = new OrderRepository(shopContext);
            ProductOrders = new ProductOrdersRepository(shopContext);
            Products = new ProductRepository(shopContext);
            Users = new UserRepository(shopContext);
            CartProducts = new CartProductsRepository(shopContext);
        }

        public void Dispose()
        {
            _shopContext.Dispose();
        }
    }
}
