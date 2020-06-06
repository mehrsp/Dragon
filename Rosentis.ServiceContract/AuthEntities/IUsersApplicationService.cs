using System.Collections.Generic;
using Rosentis.DataContract.AuthEntities;
using Rosentis.DataContract.Users;

namespace Rosentis.ServiceContract.AuthEntities
{
    public interface IUsersApplicationService
    {
        UserDto Save(UserDto dto);
        bool Remove(UserDto dto);
        IList<UserDto> FindAll();
        UserDto Find(long id);
        void UpdateUserLastActivityDate(long userId);
        string GetSerialNumber(int parse);
        UserDto FindUser(string contextUserName, string contextPassword);
        UserDto FindByPhone(long phone);
        void GenerateVerificationCode(long phoneNumber);
        ChangePasswordRequestDto ChangePassword(ChangePasswordRequestDto userDto);
        MemberDto CreateMember(long dataPhone);
        UserDto FindByPhoneCode(long phone, int code);
        UserDto FindByEmail(string modelEmail);
    }
}
