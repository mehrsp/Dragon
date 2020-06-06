using System.Collections.Generic;
using Rosentis.DomainModel.Users;
using Rosentis.DistributedServices;
using Rosentis.DataContract.Users;
using Rosentis.DomainModel.AuthEntities;
using Rosentis.DataContract.AuthEntities;

namespace Rosentis.ServiceImplementation.Users.Mapper
{
    public class RoleMapper : IEntityMapper<Role, RoleDto>
    {
        private IEntityMapper<Permission, PermissionDto> _permissionMapper;

        public RoleMapper(IEntityMapper<Permission,PermissionDto> permissionMapper)
        {
            _permissionMapper = permissionMapper;
        }
        public Role CreateFrom(RoleDto domainDto)
        {
			//if (domainDto == null)
			//    return new NullRole();
			//var permissions = new List<Permission>();
			//foreach (var item in domainDto.Permissions)
			//{
			//    permissions.Add(_permissionMapper.CreateFrom(item));
			//}
			//return new Role(domainDto.Name, domainDto.Id, permissions);
			return null;

        }

        public RoleDto MapTo(Role domain)
        {
            RoleDto domainDto = new RoleDto();
            if (domain != null)
            {
                domainDto.Name = domain.Name;
                domainDto.Id = domain.Id;
                foreach (var permission in 
                    domain.Permissions)
                {
                   domainDto.Permissions.Add(_permissionMapper.MapTo(permission));
                }
            }

            return domainDto;
        }
    }

}
