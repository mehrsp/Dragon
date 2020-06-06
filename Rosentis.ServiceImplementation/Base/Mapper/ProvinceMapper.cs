using Rosentis.DataContract.Info.Address;
using Rosentis.DistributedServices;
using Rosentis.DomainModel.Base;

namespace Rosentis.ServiceImplementation.Base.Mapper
{
    public class ProvinceMapper : IEntityMapper<Province, ProvinceDto>
    {
        public Province CreateFrom(ProvinceDto domainDto)
        {
			//if (domainDto == null)
			//    return new NullProvince();
			//return new Province(domainDto.Name,domainDto.Id);
			return null;
        }

        public ProvinceDto MapTo(Province domain)
        {
            ProvinceDto domainDto = new ProvinceDto();
            if (domain != null)
            {
				domainDto.Name = domain.Name;
				domainDto.Id = domain.Id;

            }

            return domainDto;
        }
    }

}
