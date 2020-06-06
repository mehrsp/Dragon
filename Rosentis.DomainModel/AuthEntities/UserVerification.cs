using System;

namespace Rosentis.DomainModel.AuthEntities
{
    public class UserVerification
    {
		protected UserVerification()
		{

		}
		public UserVerification(long phone, int code, DateTime createdDate, bool isValidCode, Guid id)
		{
			Phone = phone;
			Code = code;
			CreatedDate = createdDate;
			IsValidCode = isValidCode;
			Id = id;
		}
		public Guid Id { get; set; }

		public long Phone {get;set;}
		public int Code {get;set;}
		public DateTime CreatedDate {get;set;}
		public bool IsValidCode {get;set;}
    }
}
