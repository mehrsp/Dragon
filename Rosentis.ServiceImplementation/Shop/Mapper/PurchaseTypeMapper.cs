using Rosentis.DataContract.Shop;
using Rosentis.DistributedServices;
using Rosentis.DomainModel.Shop;
using Rosentis.DomainModel.Shop.NullObjects;

namespace Rosentis.ServiceImplementation.Shop.Mapper
{
    public class PurchaseTypeMapper : IEntityMapper<PurchaseType, PurchaseTypeDto>
    {

        public PurchaseTypeMapper()
        {

        }
        public PurchaseType CreateFrom(PurchaseTypeDto domainDto)
        {
            if (domainDto == null)
                return new NullPurchaseType();
            return new PurchaseType(domainDto.Name,domainDto.Description,null,domainDto.Id);

        }

        public PurchaseTypeDto MapTo(PurchaseType domain)
        {
            PurchaseTypeDto domainDto = new PurchaseTypeDto();
            if (domain != null)
            {
				domainDto.Name = domain.Name;
				domainDto.Description = domain.Description;
				domainDto.Id = domain.Id;

            }

            return domainDto;
        }
    }

}