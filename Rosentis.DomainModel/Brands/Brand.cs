using Rosentis.DomainModel.AuthEntities;
using Rosentis.DomainModel.Base;
using System;

namespace Rosentis.DomainModel.Brands
{
	public class Brand
	{
		public int? Id { get; set; }
		public string Name { get; set; }
		public string Description { get; set; }
		public string Logo { get; set; }
		public int Priority { get; set; }
		public virtual Country Country { get; set; } 
		public int CountryId { get; set; } = 1;
	}
}
