using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Rosentis.DataContract.Messaging;
using Rosentis.DomainModel.Messaging;
using Rosentis.ServiceContract.Messaging;

namespace Rosentis.ServiceImplementation.Messaging
{
    public class MessageApplicationService : IMessageApplicationService
    {

        public MessageApplicationService()
        {

        }

		public MessageDto Find(Guid id)
		{
			throw new NotImplementedException();
		}

		public MessageDtos FindAll()
		{
			throw new NotImplementedException();
		}

		public bool Remove(MessageDto dto)
		{
			throw new NotImplementedException();
		}

		public MessageDto Save(MessageDto dto)
		{
			throw new NotImplementedException();
		}

		//  public MessageDto Find(Guid id)
		//  {
		//      Criteria criteria = new EqualCriteria()
		//      {
		//          FirstOprand = "Id",
		//          ObjectType = typeof(Guid),
		//          SecondOperand = id
		//      };
		//     return base.Find(criteria);
		//  }

		//  public MessageDtos FindAll()
		//  {
		//var dtos = new MessageDtos();
		//      dtos.Messages = base.FindAll(null, null).ToList();
		//      return dtos;
		//  }

		//  public MessageDto Save(MessageDto dto)
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

		//  public bool Remove(MessageDto dto)
		//  {
		//      return base.Delete(dto);
		//  }
	}
}
