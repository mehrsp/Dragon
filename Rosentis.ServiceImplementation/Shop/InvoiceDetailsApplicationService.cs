using System;
using System.Linq;
using Rosentis.DataContract.Shop;
using Rosentis.DomainModel.Shop;
using Rosentis.ServiceContract.Shop;

namespace Rosentis.ServiceImplementation.Shop
{
    public class InvoiceDetailsApplicationService : IInvoiceDetailsApplicationService
    {

        public InvoiceDetailsApplicationService()
        {

        }

        public InvoiceDetailsDto Find(Guid id)
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

		public InvoiceDetailsDtos FindAll()
        {
		    var dtos = new InvoiceDetailsDtos();
            //dtos.InvoiceDetailss = base.FindAll(null, null).ToList();
            return dtos;
        }

        public InvoiceDetailsDto Save(InvoiceDetailsDto dto)
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

		public bool Remove(InvoiceDetailsDto dto)
        {
			//return base.Delete(dto);
			return false;

		}
	}
}
