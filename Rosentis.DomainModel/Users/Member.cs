using Rosentis.Common;
using Rosentis.DomainModel.Base;
using Rosentis.DomainModel.Products;
using Rosentis.DomainModel.AuthEntities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Rosentis.DomainModel.Users
{
	public  class Member
	{
		[Key,ForeignKey("User")]
		[DatabaseGenerated(DatabaseGeneratedOption.None)]
		public long Id { get; set; }
		public virtual User User { get; set; }
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public string BirthDate { get; set; }
		public MemberType MemberType { get; set; } = MemberType.Others;
		public string Email { get; set; }
		public string NationalCode { get; set; }
		public string Phone { get; set; }
		public string Description { get; set; }
		public string FavoriteColor { get; set; }
		public virtual Province Province { get; set; }
		public int? ProvinceId { get; set; }
		public virtual City City { get; set; }
		public int? CityId { get; set; }
		public string Address1 { get; set; }
		public string Address2 { get; set; }
		public DateTime CreatedDate { get; set; }
		public virtual IList<MemberImportantDate> ImportantDates { get; set; }
		public virtual IList<Product> Favorites { get; set; }
		public virtual IList<Product> Likes { get; set; }
	}
}
