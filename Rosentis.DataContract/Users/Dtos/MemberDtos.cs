using Rosentis.DataContract.Base;
using System.Collections.Generic;

namespace Rosentis.DataContract.Users.Dtos
{
	public class MemberDtos : BaseDto
	{
		public List<MemberDto> Members { get; set; }

		public MemberDtos()
		{
			Members = new List<MemberDto>();
		}
	}
}
