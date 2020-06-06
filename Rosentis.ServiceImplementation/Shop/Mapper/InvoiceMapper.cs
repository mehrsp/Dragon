using System.Collections.Generic;
using Rosentis.DataContract.Shop;
using Rosentis.DomainModel.Shop;
using Rosentis.DomainModel.Shop.NullObjects;
using Rosentis.DataContract.AuthEntities;
using Rosentis.DomainModel.AuthEntities;
using Rosentis.DistributedServices;

namespace Rosentis.ServiceImplementation.Shop.Mapper
{
    public class InvoiceMapper : IEntityMapper<Invoice, InvoiceDto>
    {
		private IEntityMapper<Customer, CustomerDto> _customerMapper;
		private IEntityMapper<User, UserDto> _userMapper;
		private IEntityMapper<InvoiceDetails, InvoiceDetailsDto> _invoiceDetailsMapper;

        public InvoiceMapper(IEntityMapper<Customer, CustomerDto> customerMapper,
            IEntityMapper<User, UserDto> userMapper,
            IEntityMapper<InvoiceDetails, InvoiceDetailsDto> invoiceDetailsMapper           
            )
        {
		_customerMapper = customerMapper;
		_userMapper = userMapper;
            _invoiceDetailsMapper = invoiceDetailsMapper;
        }
        public Invoice CreateFrom(InvoiceDto domainDto)
        {
            if (domainDto == null)
                return new NullInvoice();
            var invoiceDetails = new List<InvoiceDetails>();
            foreach (var item in domainDto.InvoiceDetails)
            {
               invoiceDetails.Add(_invoiceDetailsMapper.CreateFrom(item));
            }
            Customer customer = null;
            if (domainDto.Customer != null)
            {
                customer = _customerMapper.CreateFrom(domainDto.Customer);
            }
            return new Invoice(domainDto.InvoiceNumber,customer,null,domainDto.UserId,domainDto.Notes,domainDto.CreatedDate,domainDto.DueDate,domainDto.Paid,domainDto.PurchaseType,invoiceDetails,domainDto.Id);

        }

        public InvoiceDto MapTo(Invoice domain)
        {
            InvoiceDto domainDto = new InvoiceDto();
            if (domain != null)
            {
				domainDto.InvoiceNumber = domain.InvoiceNumber;
				if(domain.Customer!=null)domainDto.Customer = _customerMapper.MapTo(domain.Customer);				if(domain.User!=null)domainDto.User = _userMapper.MapTo(domain.User);
				domainDto.UserId = domain.UserId;
				domainDto.Notes = domain.Notes;
				domainDto.CreatedDate = domain.CreatedDate;
				domainDto.DueDate = domain.DueDate;
				domainDto.Paid = domain.Paid;
				domainDto.PurchaseType = domain.PurchaseType;
                foreach (var detail in domain.InvoiceDetails)
                {
                    domainDto.InvoiceDetails.Add(_invoiceDetailsMapper.MapTo(detail));
                }
				domainDto.Id = domain.Id;

            }

            return domainDto;
        }
    }

}