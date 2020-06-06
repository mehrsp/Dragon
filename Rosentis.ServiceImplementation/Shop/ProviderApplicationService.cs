using System;
using System.Linq;
using Rosentis.DataContract.Shop;
using Rosentis.DomainModel.Shop;
using Rosentis.ServiceContract.Shop;

namespace Rosentis.ServiceImplementation.Shop
{
    public class ProviderApplicationService : IProviderApplicationService
    {

        public ProviderApplicationService() 
        {

        }

        public ProviderDto Find(Guid id)
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

		public ProviderDtos FindAll()
        {
		    var dtos = new ProviderDtos();
            //dtos.Providers = base.FindAll(null, null).ToList();
            return dtos;
        }

        public ProviderDto Save(ProviderDto dto)
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

		public bool Remove(ProviderDto dto)
        {
			//return base.Delete(dto);
			return false;

		}
	}
}
