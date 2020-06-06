using Rosentis.DataContract.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rosentis.DataContract.Products
{
	public class CommentDto: BaseDto
	{
		public CommentDto()
		{
			Children = new List<CommentDto>();
		}
		public long Id { get; set; }
		public string Description { get; set; }
		public CommentDto Parent { get; set; }
		public long? ParentId { get; set; }
		public virtual ProductDto Product { get; set; }
		public long ProductId { get; set; }
		//public virtual MemberDto Member { get; set; }
		public long MemberId { get; set; }
		public virtual List<CommentDto> Children { get; set; }
	}
}
