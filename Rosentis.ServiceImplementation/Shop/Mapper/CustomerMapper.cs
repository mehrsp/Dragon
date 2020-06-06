using Rosentis.DataContract.Shop;
using Rosentis.DomainModel.Shop;
using Rosentis.DomainModel.Shop.NullObjects;
using Rosentis.DataContract.AuthEntities;
using Rosentis.DomainModel.AuthEntities;
using Rosentis.DomainModel.Base;
using Rosentis.DistributedServices;
using Rosentis.DataContract.Info.Address;

namespace Rosentis.ServiceImplementation.Shop.Mapper
{
    public class CustomerMapper : IEntityMapper<Customer, CustomerDto>
    {
		private IEntityMapper<User, UserDto> _userMapper;
		private IEntityMapper<City, CityDto> _cityMapper;
		private IEntityMapper<Province, ProvinceDto> _provinceMapper;

        public CustomerMapper(IEntityMapper<User, UserDto> userMapper, IEntityMapper<City, CityDto> cityMapper, IEntityMapper<Province, ProvinceDto> provinceMapper)
        {
		_userMapper = userMapper;
            _cityMapper = cityMapper;
            _provinceMapper = provinceMapper;
        }
        public Customer CreateFrom(CustomerDto domainDto)
        {
            if (domainDto == null)
                return new NullCustomer();
            return new Customer(null,domainDto.UserId,domainDto.Name,domainDto.Address,domainDto.PostalCode,domainDto.CityName,domainDto.Phone,domainDto.Cell,domainDto.Email,domainDto.Notes,null,null,domainDto.ProvinceId,domainDto.ProvinceName,null,domainDto.CityId,domainDto.Latitude,domainDto.Longitude,domainDto.Gender,domainDto.Id);

        }

        public CustomerDto MapTo(Customer domain)
        {
            CustomerDto domainDto = new CustomerDto();
            if (domain != null)
            {
				if(domain.User!=null)domainDto.User = _userMapper.MapTo(domain.User);
				domainDto.UserId = domain.UserId;
				domainDto.Name = domain.Name;
				domainDto.Address = domain.Address;
				domainDto.PostalCode = domain.PostalCode;
                if (domain.City != null) domainDto.City = _cityMapper.MapTo(domain.City);
                domainDto.CityId = domain.CityId;
                domainDto.CityName = domain.CityName;
                domainDto.ProvinceId = domain.ProvinceId;
                domainDto.ProvinceName = domain.ProvinceName;
                if (domain.Province != null) domainDto.Province = _provinceMapper.MapTo(domain.Province);
                domainDto.Latitude = domain.Latitude;
                domainDto.Longitude = domain.Longitude;
                domainDto.Phone = domain.Phone;
				domainDto.Cell = domain.Cell;
				domainDto.Email = domain.Email;
				domainDto.Notes = domain.Notes;
				domainDto.Id = domain.Id;
                domainDto.Gender = domain.Gender;
            }

            return domainDto;
        }
    }

}