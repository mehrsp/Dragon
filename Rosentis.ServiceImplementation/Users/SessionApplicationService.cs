using System;
using System.Collections.Generic;
using Rosentis.ServiceContract.Users;
using Rosentis.DataContract.Users;

namespace Rosentis.ServiceImplementation.Users
{
    public class SessionApplicationService : ISessionApplicationService
    {

        public SessionApplicationService() 
        {

        }

        public SessionDto Find(Guid id)
        {
			return null;
           // Criteria criteria = new EqualCriteria()
           // {
           //     FirstOprand = "Id",
           //     ObjectType = typeof(Guid),
           //     SecondOperand = id
           // };
           //return base.Find(criteria);
        }

        public IList<SessionDto> FindAll()
        {
			//return base.FindAll(null,null);
			return null;
        }

        public SessionDto Save(SessionDto dto)
        {

			//var model = base.Save(dto);
			//dto.Id = model.Id;
			//Criteria criteria = new EqualCriteria()
			//{
			//    FirstOprand = "Id",
			//    ObjectType = typeof(long),
			//    SecondOperand = model.Id
			//};
			//var result = base.Find(criteria);
			//return result;
			return null;
        }

        public bool Remove(SessionDto dto)
        {
			//return base.Delete(dto);
			return false;
        }
    }
}
