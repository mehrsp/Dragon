using System;
using Rosentis.DataContract.AuthEntities;
using Rosentis.DataContract.Base;
using Rosentis.DataContract.Info.Address;

namespace Rosentis.DataContract.Shop
{
    public class CustomerDto: BaseDto
    {
		public UserDto User {get; set;}
		public long? UserId {get; set;}
		public string Name {get; set;}
		public string Address {get; set;}
		public string PostalCode {get; set;}
		public string CityName {get; set;}
        public string ProvinceName { get; set; }
        public long Phone {get; set;}
		public long Cell {get; set;}
		public string Email {get; set;}
		public string Notes {get; set;}
        public ProvinceDto Province { get; set; }
        public Int32? ProvinceId { get; set; }
        public CityDto City { get; set; }
        public Int32? CityId { get; set; }
        public Double? Latitude { get; set; }
        public Double? Longitude { get; set; }
        public Guid Id {get; set;}
        public string Gender { get; set; }
    }
}
