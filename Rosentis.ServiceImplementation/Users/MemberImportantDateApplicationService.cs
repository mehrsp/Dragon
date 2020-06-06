using Rosentis.ServiceContract.Users;
using Rosentis.DataContract.Base;
using Rosentis.DataContract.Users;
using System.Linq;

namespace Rosentis.ServiceImplementation.Users
{
    public class MemberImportantDateApplicationService : IMemberImportantDateApplicationService
	{

        public MemberImportantDateApplicationService()
        {

        }

        public MemberImportantDateDto Find(long id)
        {
			// Criteria criteria = new EqualCriteria()
			// {
			//     FirstOprand = "Id",
			//     ObjectType = typeof(long),
			//     SecondOperand = id
			// };
			//return base.Find(criteria);
			return null;
        }

        public MemberImportantDateDtos FindAll()
        {
		    var dtos = new MemberImportantDateDtos();
            //dtos.MemberImportantDates = base.FindAll(null, null).ToList();
            return dtos;
        }

        public MemberImportantDateDto Save(MemberImportantDateDto dto)
        {

			//var model = base.Save(dto);
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

        public DtoResponse Remove(MemberImportantDateDto dto)
        {
			var response = new DtoResponse();
			//if (base.Delete(dto))
			//{
			//	return response;
			//}

			//response.AddException(new ExceptionDto()
			//{
			//	Id = 2,
			//	Message = "در هنگام حذف خطایی رخ داد. لطفا با ادمین تماس بگیرید",
			//	Title = "خطای حذف"
			//});
			return response;
		}
    }
}
