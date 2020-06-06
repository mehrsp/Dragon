
using Rosentis.DataContract.Users;
using Rosentis.DistributedServices;
using Rosentis.DomainModel.Users;

namespace Rosentis.ServiceImplementation.Users.Mapper
{
    public class MemberImportantDateMapper : IEntityMapper<MemberImportantDate, MemberImportantDateDto>
    {
        public MemberImportantDateMapper()
        {

        }
        public MemberImportantDate CreateFrom(MemberImportantDateDto domainDto)
        {
			//if (domainDto == null)
			//    return new NullMemberImportantDate();
			//return new MemberImportantDate(null,domainDto.MemberId,domainDto.Title,domainDto.Description,domainDto.Date,domainDto.CreatedDate,domainDto.ModifiedDate,domainDto.Id);
			return null;
        }

        public MemberImportantDateDto MapTo(MemberImportantDate domain)
        {
            MemberImportantDateDto domainDto = new MemberImportantDateDto();
            if (domain != null)
            {
				domainDto.Title = domain.Title;
				domainDto.Description = domain.Description;
				domainDto.Date = domain.Date;
				domainDto.CreatedDate = domain.CreatedDate;
				domainDto.ModifiedDate = domain.ModifiedDate;
				domainDto.Id = domain.Id;
                domainDto.MemberId = domain.MemberId;
            }

            return domainDto;
        }
    }

}