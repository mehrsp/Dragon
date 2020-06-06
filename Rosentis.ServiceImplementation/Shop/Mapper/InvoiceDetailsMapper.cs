using Rosentis.DataContract.Shop;
using Rosentis.DomainModel.Shop;
using Rosentis.DomainModel.Shop.NullObjects;
using Rosentis.DataContract.Products;
using Rosentis.DomainModel.Products;
using Rosentis.DistributedServices;

namespace Rosentis.ServiceImplementation.Shop.Mapper
{
    public class InvoiceDetailsMapper : IEntityMapper<InvoiceDetails, InvoiceDetailsDto>
    {
		private IEntityMapper<Product, ProductDto> _productMapper;

        public InvoiceDetailsMapper(IEntityMapper<Product, ProductDto> productMapper)
        {
            _productMapper = productMapper;
        }
        public InvoiceDetails CreateFrom(InvoiceDetailsDto domainDto)
        {
            if (domainDto == null)
                return new NullInvoiceDetails();
            return new InvoiceDetails(null,domainDto.InvoiceId,null,
				domainDto.ProductId,domainDto.ProductNumber,domainDto.ProductName,
				domainDto.Qauntity,domainDto.Price,domainDto.Vat,domainDto.Discount,null,domainDto.ProductInvoiceTypeId,
				domainDto.CreatedDate,domainDto.Id);

        }

        public InvoiceDetailsDto MapTo(InvoiceDetails domain)
        {
            InvoiceDetailsDto domainDto = new InvoiceDetailsDto();
            if (domain != null)
            {
				domainDto.InvoiceId = domain.InvoiceId;
				if(domain.Product!=null)domainDto.Product = _productMapper.MapTo(domain.Product);
				//if(domain.Vase!=null)domainDto.Vase = _productVaseMapper.MapTo(domain.Vase);
    //            domainDto.VaseId = domain.VaseId;
                domainDto.ProductInvoiceTypeId = domain.ProductInvoiceTypeId;
                if (domain.ProductInvoiceType != null)
                {
                    domainDto.ProductInvoiceType = new ProductInvoiceTypeDto()
                    {
                        Id = domain.ProductInvoiceType.Id,
                        Name = domain.ProductInvoiceType.Name
                    };
                }
                //if (domain.InvoiceDetailsFlower != null)
                //{
                //    domainDto.InvoiceDetailsFlower = new InvoiceDetailsFlowerDto()
                //    {
                //        Id = domain.InvoiceDetailsFlower.Id,
                //        Text = domain.InvoiceDetailsFlower.Text
                //    };
                //}
                //if (domain.InvoiceDetailsCake != null)
                //{
                //    domainDto.InvoiceDetailsCake = new InvoiceDetailsCakeDto()
                //    {
                //        Id = domain.InvoiceDetailsCake.Id,
                //        Text = domain.InvoiceDetailsCake.Text
                //    };
                //}
                //if (domain.InvoiceDetailsGift != null)
                //{
                //    domainDto.InvoiceDetailsGift = new InvoiceDetailsGiftDto()
                //    {
                //        Id = domain.InvoiceDetailsGift.Id,
                //    };
                //}
                domainDto.ProductId = domain.ProductId;
				domainDto.ProductNumber = domain.ProductNumber;
				domainDto.ProductName = domain.ProductName;
				domainDto.Qauntity = domain.Qauntity;
				domainDto.Price = domain.Price;
				domainDto.Vat = domain.Vat;
				domainDto.Discount = domain.Discount;
				domainDto.CreatedDate = domain.CreatedDate;
				domainDto.Id = domain.Id;

            }

            return domainDto;
        }
    }

}