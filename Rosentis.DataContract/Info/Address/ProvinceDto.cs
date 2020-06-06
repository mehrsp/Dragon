using System.Collections.Generic;
namespace Rosentis.DataContract.Info.Address
{
	public class ProvinceDto
	{
		
		public int Id { get; set; }
		public string Name { get; set; }
		public List<CityDto> Cities { get; set; }

		public ProvinceDto()
		{
			Cities = new List<CityDto>();
		}
	}
}
