using Rosentis.DataContract.AuthEntities;
using Rosentis.DataContract.Info.Address;
using Rosentis.DataContract.Products;
using Rosentis.DataContract.Users;
using Rosentis.DistributedServices;
using Rosentis.DomainModel.AuthEntities;
using Rosentis.DomainModel.Base;
using Rosentis.DomainModel.Products;
using Rosentis.DomainModel.Users;
using System.Collections.Generic;
using System.Linq;

namespace Rosentis.ServiceImplementation.Users.Mapper
{
    public class MemberMapper : IEntityMapper<Member, MemberDto>
    {
		private IEntityMapper<Province, ProvinceDto> _provinceMapper;
		private IEntityMapper<City, CityDto> _cityMapper;
		private IEntityMapper<User, UserDto> _userMapper;
		private IEntityMapper<Product, ProductDto> _prodcutMapper;
		private IEntityMapper<MemberImportantDate, MemberImportantDateDto> _memberImportatnDateMapper;

        public MemberMapper(IEntityMapper<Province, ProvinceDto> provinceMapper,IEntityMapper<City, CityDto> cityMapper,IEntityMapper<User, UserDto> userMapper,IEntityMapper<MemberImportantDate,MemberImportantDateDto> memberImportatnDateMapper,
            IEntityMapper<Product, ProductDto> prodcutMapper
            )
        {
		_provinceMapper = provinceMapper;
		_cityMapper = cityMapper;
		_userMapper = userMapper;
            _memberImportatnDateMapper = memberImportatnDateMapper;
            _prodcutMapper = prodcutMapper;
        }
        public Member CreateFrom(MemberDto domainDto)
        {
			//if (domainDto == null)
			//    return new NullMember();
			//var importantDays = new List<MemberImportantDate>();
			//foreach (var item in domainDto.ImportantDates)
			//{
			//    _memberImportatnDateMapper.CreateFrom(item);
			//}
			//var favorites = new List<Product>();
			//foreach (var item in domainDto.Favorites)
			//{
			//    favorites.Add(_prodcutMapper.CreateFrom(item));
			//}
			//var likes = new List<Product>();
			//foreach (var item in domainDto.Likes)
			//{
			//    likes.Add(_prodcutMapper.CreateFrom(item));
			//}
			//return new Member(domainDto.Id,domainDto.Title,null,domainDto.ProvinceId,null,domainDto.CityId,domainDto.Latitude,domainDto.Longitude,domainDto.Gender,domainDto.BirthDay,domainDto.FavoriteColor,domainDto.Photo,null,domainDto.FirstName,domainDto.LastName,domainDto.Address,domainDto.CreatedDate, importantDays,favorites,likes);
			return null;

        }

        public MemberDto MapTo(Member domain)
        {
            MemberDto domainDto = new MemberDto();
    //        if (domain != null)
    //        {
				//domainDto.Id = domain.Id;
				//domainDto.Title = domain.Title;
				//if(domain.Province!=null)domainDto.Province = _provinceMapper.MapTo(domain.Province);
				//domainDto.ProvinceId = domain.ProvinceId;
				//if(domain.City!=null)domainDto.City = _cityMapper.MapTo(domain.City);
				//domainDto.CityId = domain.CityId;
				//domainDto.Latitude = domain.Latitude;
				//domainDto.Longitude = domain.Longitude;
				//domainDto.Gender = domain.Gender;
				//domainDto.BirthDay = domain.BirthDay;
				//domainDto.FavoriteColor = domain.FavoriteColor;
				//domainDto.Photo = domain.Photo;
				//if(domain.User!=null)domainDto.User = _userMapper.MapTo(domain.User);
    //            domainDto.FirstName = domain.FirstName;
    //            domainDto.LastName = domain.LastName;
				//domainDto.CreatedDate = domain.CreatedDate;
    //            domain.ImportantDates.ToList().ForEach(x =>
    //            {
    //                domainDto.ImportantDates.Add(_memberImportatnDateMapper.MapTo(x));
    //            });
    //            domain.Favorites.ToList().ForEach(x =>
    //            {
    //                domainDto.Favorites.Add(_prodcutMapper.MapTo(x));
    //            });
    //            domain.Likes.ToList().ForEach(x =>
    //            {
    //                domainDto.Favorites.Add(_prodcutMapper.MapTo(x));
    //            });

    //        }

            return domainDto;
        }
    }

}