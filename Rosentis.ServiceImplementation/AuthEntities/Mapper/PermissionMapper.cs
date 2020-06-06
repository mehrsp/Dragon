using System.Linq;
using Rosentis.DataContract.AuthEntities;
using Rosentis.DomainModel.AuthEntities;
using Rosentis.DistributedServices;

namespace Rosentis.ServiceImplementation.AuthEntities.Mapper
{
    public class PermissionMapper : IEntityMapper<Permission, PermissionDto>
    {
        public PermissionMapper()
        {
        }
        public Permission CreateFrom(PermissionDto domainDto)
        {
            return null;
        }

        public PermissionDto MapTo(Permission domain)
        {
            PermissionDto domainDto = new PermissionDto();
            if (domain != null)
            {
				domainDto.Name = domain.Name;
                domainDto.Parent = new PermissionDto();
                if (domain.Parent != null)
                {
                    domainDto.Parent = new PermissionDto()
                    {
                        Parent = null,
                        Name = domain.Name
                    };
                }
                domain.Children.ToList().ForEach(x =>
                {
                    domainDto.Children.Add(new PermissionDto()
                    {
                        Name = x.Name,
                    });
                });
            }

            return domainDto;
        }
    }

}
