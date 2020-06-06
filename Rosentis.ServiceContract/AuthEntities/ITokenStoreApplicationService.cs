using System.Collections.Generic;
using Rosentis.DataContract.AuthEntities;
using System;

namespace Rosentis.ServiceContract.AuthEntities
{
    public interface ITokenStoreApplicationService
    {
        UserTokenDto Save(UserTokenDto dto);
        bool Remove(UserTokenDto dto);
        IList<UserTokenDto> FindAll();
        UserTokenDto Find(string id);
        bool IsValidToken(string accessToken, long parse);
        void CreateUserToken(UserTokenDto token);
        void DeleteExpiredTokens();
        void DeleteToken(string hashedTokenId);
        void UpdateUserToken(long userId, string accessTokenHash);
        void InvalidateUserTokens(string parse);
    }
}
