using Rosentis.Persistance;
using Rosentis.ServiceContract.Users;
using Rosentis.Common.Helper;
using Rosentis.DomainModel.Users;
using Rosentis.DataContract.Users;
using Rosentis.Persistance.Facade;
using Rosentis.DataContract.Base;
using Rosentis.DataContract.Users.Dtos;
using System;

namespace Rosentis.ServiceImplementation.Users
{
	public class MemberApplicationService : IMemberService
	{
		#region Propertises
		private UnitOfWork unitOfWork = new UnitOfWork();
		#endregion

		#region Ctors
		public MemberApplicationService(RosentisContext context)
		{
		}
		#endregion

		#region Method
		//public MemberDto Save(MemberDto dto)
		//{
			
		//}
		public bool IsValidNationalCode(string nationlCode)
		{
			if (NationalCodeValidation.IsValidNationalCode(nationlCode))
				return true;
			else
				return false;
		}
		public MemberDto CreateMember(MemberDto member)
		{
			var dto = new MemberDto();
			unitOfWork.MemberRepository.Insert(AutoMapper.Mapper.Map<Member>(member));
			unitOfWork.Save();
			dto.Id = member.Id;
			return dto;
		}

		public DtoResponse Remove(MemberDto dto)
		{
			throw new NotImplementedException();
		}

		public MemberDtos FindAll()
		{
			throw new NotImplementedException();
		}

		public MemberDto Find(long id)
		{
			throw new NotImplementedException();
		}

		public bool DoFavorite(long userId, long productId)
		{
			throw new NotImplementedException();
		}

		public bool DoLike(long userId, long productId)
		{
			throw new NotImplementedException();
		}
		#endregion
	}
}
