using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Mediator.Results.BlogResults
{
	public class GetBlogByAuthorIdQueryResult // bize bu entity'de sadece o bloğa ait yazar bilgileri lazım.
	{
		public int BlogId { get; set; }
		public int AuthorId { get; set; }
		public string AuthorName { get; set; }
		public string AuthorDescription { get; set; }
		public string AuthorImageUrl { get; set; }
	}
}
