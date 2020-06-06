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
    public class MessageTypeApplicationService :IMessageTypeApplicationService
    {

        public MessageTypeApplicationService()
        {

        }

		public MessageTypeDto Find(int id)
		{
			throw new NotImplementedException();
		}

		public MessageTypeDtos FindAll()
		{
			throw new NotImplementedException();
		}

		public bool Remove(MessageTypeDto dto)
		{
			throw new NotImplementedException();
		}

		public MessageTypeDto Save(MessageTypeDto dto)
		{
			throw new NotImplementedException();
		}

		//  public MessageTypeDto Find(int id)
		//  {
		//      Criteria criteria = new EqualCriteria()
		//      {
		//          FirstOprand = "Id",
		//          ObjectType = typeof(int),
		//          SecondOperand = id
		//      };
		//     return base.Find(criteria);
		//  }

		//  public MessageTypeDtos FindAll()
		//  {
		//var dtos = new MessageTypeDtos();
		//      dtos.MessageTypes = base.FindAll(null, null).ToList();
		//      return dtos;
		//  }

		//  public MessageTypeDto Save(MessageTypeDto dto)
		//  {

		//      var model = base.Save(dto);
		//      Criteria criteria = new EqualCriteria()
		//      {
		//          FirstOprand = "Id",
		//          ObjectType = typeof(int),
		//          SecondOperand = model.Id
		//      };
		//      var result = base.Find(criteria);
		//      return result;
		//  }

		//  public bool Remove(MessageTypeDto dto)
		//  {
		//      return base.Delete(dto);
		//  }
	}
}
