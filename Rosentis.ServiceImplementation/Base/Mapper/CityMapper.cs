
using Rosentis.DataContract.Info.Address;
using Rosentis.DistributedServices;
using Rosentis.DomainModel.Base;

namespace Rosentis.ServiceImplementation.Base.Mapper
{
    public class CityMapper : IEntityMapper<City, CityDto>
    {
        private IEntityMapper<Province, ProvinceDto> _provinMapper;

        public CityMapper(IEntityMapper<Province, ProvinceDto> provinMapper)
        {
            _provinMapper = provinMapper;
        }
        public City CreateFrom(CityDto domainDto)
        {
			//if (domainDto == null)
			//    return new NullCity();
			//return new City(domainDto.Name,null,domainDto.ProvinceId,domainDto.Id);
			return null;
        }

        public CityDto MapTo(City domain)
        {
            CityDto domainDto = new CityDto();
    //        if (domain != null)
    //        {
				//domainDto.Name = domain.Name;
    //            if (domainDto.Province != null) domainDto.Province = _provinMapper.MapTo(domain.Province);

    //            domainDto.ProvinceId = domain.ProvinceId;
				//domainDto.Id = domain.Id;

    //        }

            return domainDto;
        }
    }

}
