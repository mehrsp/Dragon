using Rosentis.DataContract.Base;
using System.Collections.Generic;

namespace Rosentis.DataContract.Base.Dtos
{
	public class DropBoxDtos: BaseDto
	{
		public List<DropBoxDto> Items { get; set; }
		public DropBoxDtos()
		{
			Items = new List<DropBoxDto>();
		}
	}
}
