using Rosentis.DataContract.Users;
using Rosentis.ServiceContract.Users;
using System.Linq;

namespace Rosentis.ServiceImplementation.Users
{
    public class RoleApplicationService : IRoleApplicationService
    {

        public RoleApplicationService()
		{

        }

        public RoleDto Find(int id)
        {
			// Criteria criteria = new EqualCriteria()
			// {
			//     FirstOprand = "Id",
			//     ObjectType = typeof(int),
			//     SecondOperand = id
			// };
			//return base.Find(criteria);
			return null;
        }

        public RoleDtos FindAll()
        {
			//var dtos = new RoleDtos()
			//{
			//    Roles = base.FindAll(null, null).ToList()
			//};
			//return dtos;
			return null;
        }

        public RoleDto Save(RoleDto dto)
        {
            return null;
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
        }

        public bool Remove(RoleDto dto)
        {
			//return base.Delete(dto);
			return false;
        }
    }
}
