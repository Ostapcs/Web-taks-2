﻿using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Entities
{
    public class Comment
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int ProductId { get; set; }
        public string Text { get; set; }
        public int Rating { get; set; }

        public User User { get; set; }
        public Product Product { get; set; }

    }
}
