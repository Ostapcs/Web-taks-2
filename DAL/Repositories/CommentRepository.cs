using System;
using System.Collections.Generic;
using System.Text;
using DAL.Context;
using DAL.Entities;
using DAL.Interfaces;

namespace DAL.Repositories
{
    public class CommentRepository : Repository<Comment>, ICommentRepository
    {
        public CommentRepository(ShopContext shopContext) : base(shopContext) 
        {
        }
    }
}
