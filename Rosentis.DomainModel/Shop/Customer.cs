using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Rosentis.DomainModel.AuthEntities;
using Rosentis.DomainModel.Base;

namespace Rosentis.DomainModel.Shop
{
    public class Customer
    {
        [Key,ForeignKey("Invoice")]
        public   Guid Id { get; set; }
        protected Customer()
        {

        }
		public Customer(User user, long? userId, string name, string address, string postalCode, string cityName, long phone, long cell, string email, string notes, Invoice invoice, Province province, int? provinceId, string provinceName, City city, int? cityId, double? latitude, double? longitude, string gender, Guid id)
		{
			User = user;
			UserId = userId;
			Name = name;
			Address = address;
			PostalCode = postalCode;
			City = city;
			CityName = cityName;
			Province = province;
			ProvinceId = provinceId;
			ProvinceName = provinceName;
			CityId = cityId;
			Latitude = latitude;
			Longitude = longitude;
			Phone = phone;
			Cell = cell;
			Email = email;
			Notes = notes;
			Invoice = invoice;
			Gender = gender;
			Id = id;
		}
		public virtual User User {get; set;}
		public long? UserId {get; set;}
		public string Name {get; set;}
		public string Address {get; set;}
		public string PostalCode {get; set;}
		public string CityName {get; set;}
		public string ProvinceName {get; set;}
		public long Phone {get; set;}
		public long Cell {get; set;}
		public string Email {get; set;}
		public string Notes {get; set;}
		public virtual Invoice Invoice { get; set;}
        public virtual Province Province { get;  set; }
        public Int32? ProvinceId { get;  set; }
        public virtual City City { get;  set; }
        public Int32? CityId { get;  set; }
        public Double? Latitude { get;  set; }
        public Double? Longitude { get;  set; }
        public string Gender { get; set; }
    }
}
