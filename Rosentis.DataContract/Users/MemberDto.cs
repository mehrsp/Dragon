using Rosentis.Common;
using Rosentis.DataContract.AuthEntities;
using Rosentis.DataContract.Base;
using Rosentis.DataContract.Info.Address;
using System;
using System.Collections.Generic;

namespace Rosentis.DataContract.Users
{
	public class MemberDto: BaseDto
	{
		public long Id { get; set; }
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public string BirthDate { get; set; }
		public MemberType MemberType { get; set; } = MemberType.Others;
		public string Email { get; set; }
		public string UserName { get; set; }
		public string NationalCode { get; set; }
		public string Phone { get; set; }
		public string Description { get; set; }
		public int? ProvinceId { get; set; }
		public int? CityId { get; set; }
		public string Address { get; set; }
		public string Address2 { get; set; }
		public DateTime CreatedDate { get; set; }
		public long? CreatedUserId { get; set; }
		public DateTime? ModifiedDate { get; set; }
		public long? ModifiedById { get; set; }
		public UserDto User { get; set; }
		public ProvinceDto Province { get; set; }
		public CityDto City { get; set; }
		public virtual List<MemberImportantDateDto> ImportantDates { get; set; }
	}
}
