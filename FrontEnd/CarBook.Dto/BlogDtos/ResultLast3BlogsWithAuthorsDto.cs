using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Dto.BlogDtos
{
    public class ResultLast3BlogsWithAuthorsDto
    {
        public int BlogId { get; set; }
        public string Title { get; set; }
        public string CoverImageUrl { get; set; }
        public DateTime CreatedTime { get; set; }
        public int AuthorID { get; set; }
        public string AuthorName { get; set; }
        public int CategoryID { get; set; }
    }
}
