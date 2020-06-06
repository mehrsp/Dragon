using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Rosentis.DomainModel.Base
{
	public class Province
	{
		public Province()
		{
			Cities = new HashSet<City>();
		}
		[Key]
		public int Id { get; set; }
		public string Name { get; set; }
		public  ICollection<City> Cities { get; set; }
	}
}
