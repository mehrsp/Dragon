using System.Collections.Generic;
using System.Linq;
using Rosentis.DataContract.AuthEntities;
using Rosentis.DomainModel.AuthEntities;
using Rosentis.DomainModel.AuthEntities.NullObjects;
using Rosentis.DataContract.Users;
using Rosentis.DomainModel.Users;
using Rosentis.DistributedServices;

namespace Rosentis.ServiceImplementation.AuthEntities.Mapper
{
    public class UserMapper : IEntityMapper<User, UserDto>
    {
        private IEntityMapper<Role, RoleDto> _roleMapper;
        private IEntityMapper<Permission, PermissionDto> _permissionMapper;

        public UserMapper(IEntityMapper<Role, RoleDto> roleMapper, IEntityMapper<Permission, PermissionDto> permissionMapper)
        {
            _roleMapper = roleMapper;
            _permissionMapper = permissionMapper;
        }
        public User CreateFrom(UserDto domainDto)
        {
            if (domainDto == null)
                return new NullUser();
            var roles = new List<Role>();
            foreach (var item in domainDto.Roles)
            {
                roles.Add(_roleMapper.CreateFrom(item));
            }

            var permissions = new List<Permission>();
            foreach (var item in domainDto.Permissions)
            {
                permissions.Add(_permissionMapper.CreateFrom(item));
            }
            return new
				User(domainDto.Phone,domainDto.Email,domainDto.UserName,domainDto.DisplayName,domainDto.IsActive,domainDto.LastLoggedIn,domainDto.Password,roles,permissions,domainDto.SerialNumber,domainDto.Id);

        }

        public UserDto MapTo(User domain)
        {
            UserDto domainDto = new UserDto();
            if (domain != null)
            {
				domainDto.UserName = domain.UserName;
				domainDto.DisplayName = domain.DisplayName;
				domainDto.IsActive = domain.IsActive;
				domainDto.LastLoggedIn = domain.LastLoggedIn;
				domainDto.Password = domain.Password;
                domainDto.Phone = domain.Phone;
                domain.Roles.ToList().ForEach(x =>
                {
                    domainDto.Roles.Add(_roleMapper.MapTo(x));
                });
                domain.Permissions.ToList().ForEach(x =>
                {
                    domainDto.Permissions.Add(_permissionMapper.MapTo(x));
                });
                domainDto.SerialNumber = domain.SerialNumber;
                domainDto.Email = domain.Email;
				domainDto.Id = domain.Id;

            }

            return domainDto;
        }
    }

}
