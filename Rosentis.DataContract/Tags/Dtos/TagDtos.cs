using Rosentis.DataContract.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rosentis.DataContract.Tags.Dtos
{
	public class TagDtos : BaseDto
	{
		public List<TagDto> tags { get; set; }

		public TagDtos()
		{
			tags = new List<TagDto>();
		}
	}
}
