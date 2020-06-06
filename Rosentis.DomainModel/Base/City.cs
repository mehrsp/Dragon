

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Rosentis.DomainModel.Base
{
	public class City
	{
		[Key]
		public int Id { get; set; }
		public string Name { get; set; }
		public virtual Province Province { get; set; }
		public int ProvinceId { get; set; }


	}
}
