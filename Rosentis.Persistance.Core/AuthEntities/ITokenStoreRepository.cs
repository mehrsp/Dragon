using Rosentis.DomainModel.AuthEntities;
using System;

namespace Rosentis.Persistance.Core.AuthEntities
{
    public interface ITokenStoreRepository
    {
        void Save(UserToken userToken);
        void Update(UserToken token);
    }
}