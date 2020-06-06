using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Rosentis.DataContract.Shop;

namespace Rosentis.ServiceContract.Shop
{
    public interface ICustomerApplicationService
    {
        CustomerDto Save(CustomerDto dto);
        bool Remove(CustomerDto dto);
        CustomerDtos FindAll();
        CustomerDto Find(Guid id);
    }
}
