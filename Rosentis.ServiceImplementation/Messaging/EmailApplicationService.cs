using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using Rosentis.DataContract.Messaging;
using Rosentis.DomainModel.Messaging;
using Rosentis.ServiceContract.Messaging;
namespace Rosentis.ServiceImplementation.Messaging
{
    public class EmailApplicationService :IEmailApplicationService
    {

        public EmailApplicationService()
        {

        }

		public EmailDto Find(Guid id)
		{
			throw new NotImplementedException();
		}

		public EmailDtos FindAll()
		{
			throw new NotImplementedException();
		}

		public bool Remove(EmailDto dto)
		{
			throw new NotImplementedException();
		}

		public EmailDto Save(EmailDto dto)
		{
			throw new NotImplementedException();
		}

		public bool SendMessage(string to, string subject, string body)
		{
			throw new NotImplementedException();
		}

		//  public EmailDto Find(Guid id)
		//  {
		//      Criteria criteria = new EqualCriteria()
		//      {
		//          FirstOprand = "Id",
		//          ObjectType = typeof(Guid),
		//          SecondOperand = id
		//      };
		//     return base.Find(criteria);
		//  }

		//  public bool SendMessage(string to, string subject, string body)
		//  {
		//      byte counter = 0;
		//      while (counter != 3)
		//      {
		//          MailMessage mail = new MailMessage("Rosentis@pavan.ir", to);
		//          SmtpClient client = new SmtpClient();
		//          client.Port = 25;
		//          client.DeliveryMethod = SmtpDeliveryMethod.Network;
		//          client.UseDefaultCredentials = false;
		//          client.Host = "mail.pavan.ir";
		//          client.Credentials = new System.Net.NetworkCredential("Rosentis@pavan.ir", "HBDhamed123");
		//          mail.Subject = subject;
		//          mail.Body = body;
		//          mail.IsBodyHtml = true;
		//          try
		//          {
		//              client.Send(mail);
		//              return true;
		//              break;
		//          }
		//          catch(Exception exception)
		//          {
		//              counter++;
		//          }
		//      }
		//      return false;
		//  }


		//  public EmailDtos FindAll()
		//  {
		//var dtos = new EmailDtos();
		//      dtos.Emails = base.FindAll(null, null).ToList();
		//      return dtos;
		//  }

		//  public EmailDto Save(EmailDto dto)
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

		//  public bool Remove(EmailDto dto)
		//  {
		//      return base.Delete(dto);
		//  }
	}
}
