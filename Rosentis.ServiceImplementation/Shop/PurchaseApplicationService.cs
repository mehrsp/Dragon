using System;
using System.Linq;
using Rosentis.DataContract.Shop;
using Rosentis.DomainModel.Shop;
using Rosentis.ServiceContract.Shop;

namespace Rosentis.ServiceImplementation.Shop
{
    public class PurchaseApplicationService : IPurchaseApplicationService
    {

        public PurchaseApplicationService()
        {

        }

        public PurchaseDto Find(Guid id)
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

		public PurchaseDtos FindAll()
        {
		    var dtos = new PurchaseDtos();
            //dtos.Purchases = base.FindAll(null, null).ToList();
            return dtos;
        }

        public PurchaseDto Save(PurchaseDto dto)
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

		public bool Remove(PurchaseDto dto)
        {
			//return base.Delete(dto);
			return false;

		}
	}
}
