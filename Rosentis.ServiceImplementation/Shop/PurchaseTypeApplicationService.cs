using System.Linq;
using Rosentis.DataContract.Shop;
using Rosentis.DomainModel.Shop;
using Rosentis.ServiceContract.Shop;

namespace Rosentis.ServiceImplementation.Shop
{
    public class PurchaseTypeApplicationService : IPurchaseTypeApplicationService
    {

        public PurchaseTypeApplicationService()
		{

        }

		public PurchaseTypeDto Find(int id)
		{
			//Criteria criteria = new EqualCriteria()
			//{
			//	FirstOprand = "Id",
			//	ObjectType = typeof(int),
			//	SecondOperand = id
			//};
			//return base.Find(criteria);
			return null;
		}

		public PurchaseTypeDtos FindAll()
		{
			//var dtos = new PurchaseTypeDtos();
			//dtos.PurchaseTypes = base.FindAll(null, null).ToList();
			//return dtos;
			return null;

		}

		public PurchaseTypeDto Save(PurchaseTypeDto dto)
		{

			//var model = base.Save(dto);
			//Criteria criteria = new EqualCriteria()
			//{
			//	FirstOprand = "Id",
			//	ObjectType = typeof(int),
			//	SecondOperand = model.Id
			//};
			//var result = base.Find(criteria);
			//return result;
			return null;

		}

		public bool Remove(PurchaseTypeDto dto)
		{
			//return base.Delete(dto);
			return false;

		}
	}
}
