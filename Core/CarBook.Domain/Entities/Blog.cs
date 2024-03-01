using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Domain.Entities
{
    public class Blog
    {
        public int BlogId { get; set; }
        public string Title { get; set; }    
        public string Description { get; set; }    
        public string CoverImageUrl { get; set; }
        public DateTime CreatedTime { get; set; }
        public int AuthorID { get; set; }
        public Author Author { get; set; }
        public int CategoryID { get; set; }
        public Category Category { get; set; }
    }
}
