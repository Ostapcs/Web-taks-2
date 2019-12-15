using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL.Context;
using DAL.Entities;
using DAL.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DAL.Repositories
{
    public class CommentRepository : Repository<Comment>, ICommentRepository
    {
        public CommentRepository(ShopContext shopContext) : base(shopContext) 
        {
        }

        public Comment GetWithUser(int id)
        {
            return dbContext.Comments
                .Include(c => c.User)
                .FirstOrDefault(c => c.Id == id);
        }
    }
}
