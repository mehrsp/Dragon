using System;
using System.Collections.Generic;
using System.Linq;
using Rosentis.DataContract.Shop;
using Rosentis.DomainModel.Shop;
using Rosentis.ServiceContract.Shop;

namespace Rosentis.ServiceImplementation.Shop
{
    public class InvoiceApplicationService : IInvoiceApplicationService
    {
        ICustomerApplicationService _customerApplicationService;
        private IInvoiceDetailsApplicationService _invoiceDetailsApplicationService;
        public InvoiceApplicationService(ICustomerApplicationService customerApplicationService, IInvoiceDetailsApplicationService invoiceDetailsApplicationService)
        {
            _customerApplicationService = customerApplicationService;
            _invoiceDetailsApplicationService = invoiceDetailsApplicationService;
        }

        public InvoiceDto Find(Guid id)
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

		public InvoiceDtos FindAll()
        {
		    var dtos = new InvoiceDtos();
            //dtos.Invoices = base.FindAll(null, null).ToList();
            //dtos.Invoices.ForEach(model =>
            //{
            //    Criteria criteria = new EqualCriteria
            //    {
            //        ObjectType = typeof(string),
            //        FirstOprand = "InvoiceId",
            //        SecondOperand = model.Id.ToString()
            //    };
            //    model.InvoiceDetails = _invoiceDetailsApplicationService.FindAll(criteria, new List<SortItem>() { new SortItem() { SortFiledsSelector = "CreatedDate", Direction = SortDirection.Descending } });
            //});
            return dtos;
        }

        public InvoiceDto Save(InvoiceDto dto)
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

		public bool Remove(InvoiceDto dto)
        {
			//return base.Delete(dto);
			return false;

		}
	}
}
