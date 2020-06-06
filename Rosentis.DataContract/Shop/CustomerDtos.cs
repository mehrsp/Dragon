using Rosentis.DataContract.Base;
using System.Collections.Generic;
namespace Rosentis.DataContract.Shop
{
    public class CustomerDtos: BaseDto
    {
        public List<CustomerDto> Customers { get; set; }

        public CustomerDtos()
        {
            Customers = new List<CustomerDto>();
        }
    }
}
