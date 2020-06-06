using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Rosentis.DataContract.Messaging;
using Rosentis.DomainModel.Messaging;
using Rosentis.ServiceContract.Messaging;
using Rosentis.DataContract.Base;

namespace Rosentis.ServiceImplementation.Messaging
{
    public class SmsApplicationService :ISmsApplicationService
    {
		//private string _username = "Rosentis";
		//private string _password = "hbdhamed";
		private string _username = "09058091731";
		private string _password = "123456";
		public SmsApplicationService()
        {

        }

		public SmsDto Find(Guid id)
		{
			throw new NotImplementedException();
		}

		public SmsDtos FindAll()
		{
			throw new NotImplementedException();
		}

		public bool Remove(SmsDto dto)
		{
			throw new NotImplementedException();
		}

		public SmsDto Save(SmsDto dto)
		{
			throw new NotImplementedException();
		}

		public DtoResponse Send(long mobile, string message)
		{
			throw new NotImplementedException();
		}

		//  public SmsDto Find(Guid id)
		//  {
		//      Criteria criteria = new EqualCriteria()
		//      {
		//          FirstOprand = "Id",
		//          ObjectType = typeof(Guid),
		//          SecondOperand = id
		//      };
		//     return base.Find(criteria);
		//  }

		//  public DtoResponse Send(long mobile, string message)
		//  {
		//      var statusArray = new List<string> { "0" + mobile.ToString() };
		//      var client = new SmsService.SMSSoapClient();
		//      var test = client.SendArray(_username, _password, statusArray.ToArray(), message, "300003116", false, null);
		//      return new DtoResponse();

		//      //try
		//      //{
		//      //        var client = new SmsPavan.SMSSoapClient();
		//      //        long Result = client.SendItem(_username, _password, "0"+mobile.ToString(), message,null,false,0);
		//      //    return new DtoResponse();
		//      //}
		//      //catch (Exception EX)
		//      //{
		//      //    return new DtoResponse()
		//      //    {
		//      //        Exceptions = new List<ExceptionDto>(new[]
		//      //        {
		//      //            new ExceptionDto
		//      //            {
		//      //                Title = "خطای محلی",
		//      //                Message =  EX.Message
		//      //            }
		//      //        })
		//      //    };
		//      //}
		//  }

		//  public SmsDtos FindAll()
		//  {
		//var dtos = new SmsDtos();
		//      dtos.Smss = base.FindAll(null, null).ToList();
		//      return dtos;
		//  }

		//  public SmsDto Save(SmsDto dto)
		//  {

		//      var model = base.Save(dto);
		//      Criteria criteria = new EqualCriteria()
		//      {
		//          FirstOprand = "Id",
		//          ObjectType = typeof(Guid),
		//          SecondOperand = model.Id
		//      };
		//      var result = base.Find(criteria);
		//      return result;
		//  }

		//  public bool Remove(SmsDto dto)
		//  {
		//      return base.Delete(dto);
		//  }
	}
}
