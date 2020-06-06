using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Rosentis.DomainModel.Base
{
	public class Country
	{
		public Country()
		{
		}
		[Key]
		public int Id { get; set; }
		public string Summary { get; set; }
		public string Title { get; set; }
	}
}
