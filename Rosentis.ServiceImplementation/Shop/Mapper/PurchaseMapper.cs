using Rosentis.DataContract.Shop;
using Rosentis.DistributedServices;
using Rosentis.DomainModel.Shop;
using Rosentis.DomainModel.Shop.NullObjects;

namespace Rosentis.ServiceImplementation.Shop.Mapper
{
    public class PurchaseMapper : IEntityMapper<Purchase, PurchaseDto>
    {
		private IEntityMapper<PurchaseType, PurchaseTypeDto> _purchaseTypeMapper;
		private IEntityMapper<Invoice, InvoiceDto> _invoiceMapper;

        public PurchaseMapper(IEntityMapper<PurchaseType, PurchaseTypeDto> purchaseTypeMapper,IEntityMapper<Invoice, InvoiceDto> invoiceMapper)
        {
		_purchaseTypeMapper = purchaseTypeMapper;
		_invoiceMapper = invoiceMapper;

        }
        public Purchase CreateFrom(PurchaseDto domainDto)
        {
            if (domainDto == null)
                return new NullPurchase();
            return new Purchase(domainDto.ProductNumber,domainDto.ProductName,domainDto.Qauntity,domainDto.Price,domainDto.Vat,domainDto.Discount,null,domainDto.ProviderId,domainDto.CommisionPercentage,domainDto.Notes,domainDto.CreatedDate,null,domainDto.PurchaseTypeId,null,domainDto.InvoiceId,domainDto.CheckedOut,domainDto.CheckedOutDate,domainDto.Id);

        }

        public PurchaseDto MapTo(Purchase domain)
        {
            PurchaseDto domainDto = new PurchaseDto();
            if (domain != null)
            {
				domainDto.ProductNumber = domain.ProductNumber;
				domainDto.ProductName = domain.ProductName;
				domainDto.Qauntity = domain.Qauntity;
				domainDto.Price = domain.Price;
				domainDto.Vat = domain.Vat;
				domainDto.Discount = domain.Discount;
				domainDto.ProviderId = domain.ProviderId;
				domainDto.CommisionPercentage = domain.CommisionPercentage;
				domainDto.Notes = domain.Notes;
				domainDto.CreatedDate = domain.CreatedDate;
				if(domain.PurchaseType!=null)domainDto.PurchaseType = _purchaseTypeMapper.MapTo(domain.PurchaseType);
				domainDto.PurchaseTypeId = domain.PurchaseTypeId;
				if(domain.Invoice!=null)domainDto.Invoice = _invoiceMapper.MapTo(domain.Invoice);
				domainDto.InvoiceId = domain.InvoiceId;
				domainDto.CheckedOut = domain.CheckedOut;
				domainDto.CheckedOutDate = domain.CheckedOutDate;
				domainDto.Id = domain.Id;

            }

            return domainDto;
        }
    }

}