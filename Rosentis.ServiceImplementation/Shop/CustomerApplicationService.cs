using System;
using System.Linq;
using Rosentis.DataContract.Shop;
using Rosentis.DomainModel.Shop;
using Rosentis.ServiceContract.Shop;

namespace Rosentis.ServiceImplementation.Shop
{
    public class CustomerApplicationService : ICustomerApplicationService
    {

        public CustomerApplicationService()
        {

        }

        public CustomerDto Find(Guid id)
        {
			// Criteria criteria = new EqualCriteria()
			// {
			//     FirstOprand = "Id",
			//     ObjectType = typeof(Guid),
			//     SecondOperand = id
			// };
			//return base.Find(criteria);
			return null;

		}

		public CustomerDtos FindAll()
        {
		    var dtos = new CustomerDtos();
            //dtos.Customers = base.FindAll(null, null).ToList();
            return dtos;
        }

        public CustomerDto Save(CustomerDto dto)
        {

			//var model = base.Save(dto);
			//Criteria criteria = new EqualCriteria()
			//{
			//    FirstOprand = "Id",
			//    ObjectType = typeof(Guid),
			//    SecondOperand = model.Id
			//};
			//var result = base.Find(criteria);
			//return result;
			return null;

		}

		public bool Remove(CustomerDto dto)
        {
			//return base.Delete(dto);
			return false;
        }
    }
}
