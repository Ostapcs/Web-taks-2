using System;
using DAL.Context;
using DAL.Interfaces;
using DAL.Module;
using DAL.UnitOfWork;
using Microsoft.Extensions.DependencyInjection;

namespace TestTool
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var uof = new UnitOfWork(new ShopContext()))
            {
                
            }
        }
    }
}
