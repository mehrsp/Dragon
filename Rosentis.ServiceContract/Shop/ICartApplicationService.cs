using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Rosentis.DataContract.Shop;

namespace Rosentis.ServiceContract.Shop
{
    public interface ICartApplicationService
    {
        CartDto Save(CartDto dto);
        bool Remove(CartDto dto);
        CartDtos FindAll();
        CartDto Find(Guid id);
    }
}
