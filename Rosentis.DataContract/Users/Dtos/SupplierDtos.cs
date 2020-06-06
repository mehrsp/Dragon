using Rosentis.DataContract.Base;
using System.Collections.Generic;

namespace Rosentis.DataContract.Users.Dtos
{
	public class SupplierDtos : BaseDto
	{
		public List<SupplierDto> Suppliers { get; set; }

		public SupplierDtos()
		{
			Suppliers = new List<SupplierDto>();
		}
	}
}
