using Rosentis.DataContract.Base;
using Rosentis.DataContract.Users;
using Rosentis.DataContract.Users.Dtos;
using Rosentis.DomainModel.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rosentis.ServiceContract.Users
{
	public interface IMemberService
	{
		bool IsValidNationalCode(string nationlCode);
		MemberDto CreateMember(MemberDto member);
		DtoResponse Remove(MemberDto dto);
		MemberDtos FindAll();
		MemberDto Find(long id);
		bool DoFavorite(long userId, long productId);
		bool DoLike(long userId, long productId);

	}
}
