using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Rosentis.DataContract.Shop;
using Rosentis.DomainModel.Shop;
using Rosentis.DomainModel.Shop.NullObjects;
using Rosentis.DistributedServices;
using Rosentis.DomainModel.Users;
using Rosentis.DataContract.Users;

namespace Rosentis.ServiceImplementation.Shop.Mapper
{
    public class ProviderMapper : IEntityMapper<Provider, ProviderDto>
    {
		private IEntityMapper<Supplier, SupplierDto> _supplierMapper;
        private IEntityMapper<Purchase, PurchaseDto> _purchaseMapper;

        public ProviderMapper(IEntityMapper<Supplier, SupplierDto> supplierMapper,
            IEntityMapper<Purchase, PurchaseDto> purchaseMapper
            )
        {
		_supplierMapper = supplierMapper;
            _purchaseMapper = purchaseMapper;
        }
        public Provider CreateFrom(ProviderDto domainDto)
        {
            if (domainDto == null)
                return new NullProvider();
            var purchases = new List<Purchase>();
            foreach (var item in domainDto.Purchases)
            {
                purchases.Add(_purchaseMapper.CreateFrom(item));
            }
            return new Provider(null,domainDto.SupplierId,domainDto.Address,domainDto.Phone,domainDto.Cell,domainDto.Email,domainDto.SupplierName,domainDto.CreatedDate,purchases,domainDto.Id);

        }

        public ProviderDto MapTo(Provider domain)
        {
            ProviderDto domainDto = new ProviderDto();
            if (domain != null)
            {
				if(domain.Supplier!=null)domainDto.Supplier = _supplierMapper.MapTo(domain.Supplier);
				domainDto.SupplierId = domain.SupplierId;
				domainDto.Address = domain.Address;
				domainDto.Phone = domain.Phone;
				domainDto.Cell = domain.Cell;
				domainDto.Email = domain.Email;
				domainDto.CreatedDate = domain.CreatedDate;
                domainDto.SupplierName = domain.SupplierName;
                foreach (var item in domain.Purchases)
                {
                    domainDto.Purchases.Add(_purchaseMapper.MapTo(item));
                }
				domainDto.Id = domain.Id;

            }

            return domainDto;
        }
    }

}