﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Domain.Entities
{
    public class Comment
    {
        public int CommentId { get; set; }
        public string Name { get; set; }        // user name
        public string Description { get; set; }  // comment
        public DateTime CreatedDate { get; set; } 
        public Blog Blog { get; set; }
    }
}