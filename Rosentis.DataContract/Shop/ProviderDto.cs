using Rosentis.DataContract.Base;
using Rosentis.DataContract.Users;
using System;
using System.Collections.Generic;

namespace Rosentis.DataContract.Shop
{
    public class ProviderDto: BaseDto
    {
		public SupplierDto Supplier {get; set;}
		public long? SupplierId {get; set;}
        public string SupplierName { get; set; }
		public string Address {get; set;}
		public string Phone {get; set;}
		public string Cell {get; set;}
		public string Email {get; set;}
		public DateTime CreatedDate {get; set;}
		public ICollection<PurchaseDto> Purchases {get; set;}
		public Guid Id {get; set;}

        public ProviderDto()
        {
            Purchases = new List<PurchaseDto>();
        }

    }
}
