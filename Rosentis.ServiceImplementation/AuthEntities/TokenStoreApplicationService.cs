using System.Collections.Generic;
using Rosentis.DataContract.AuthEntities;
using Rosentis.ServiceContract.AuthEntities;
using Rosentis.ServiceImplementation.AuthEntities.Mapper;
using Rosentis.DistributedServices;
using Rosentis.DomainModel.AuthEntities;
using System;
using Rosentis.Persistance.Core.AuthEntities;
using Rosentis.Persistance;
using System.Linq;
using Rosentis.Api.Helpers;

namespace Rosentis.ServiceImplementation.AuthEntities
{
    public class TokenStoreApplicationService: ITokenStoreApplicationService
    {
        #region Propertises
		private IEntityMapper<UserToken, UserTokenDto> _mapper;
		private readonly ITokenStoreRepository _repository;
		private UnitOfWork _unitOfWork = new UnitOfWork();
		#endregion

		#region Ctor
		public TokenStoreApplicationService(IEntityMapper<UserToken, UserTokenDto> mapper, ITokenStoreRepository repository)
		{
			_mapper = mapper;
			_repository = repository;
		}
		#endregion

		#region Methods
		public UserTokenDto Find(string id)
		{
			return _unitOfWork.UserTokenRepository.Get(x => x.AccessTokenHash == id).Select(_mapper.MapTo).FirstOrDefault();
		}

		public bool IsValidToken(string accessToken, long parse)
		{
			var accessTokenHash = SecurityHelper.GetSha256Hash(accessToken);
			var userToken = _unitOfWork.UserTokenRepository.Get(x => x.AccessTokenHash == accessTokenHash && x.OwnerUserId == parse).FirstOrDefault();
			return userToken?.AccessTokenExpirationDateTime >= DateTime.UtcNow;
		}

		public void CreateUserToken(UserTokenDto tokenDto)
		{
			var token = _mapper.CreateFrom(tokenDto);
			token.Id = Guid.NewGuid();
			_repository.Save(token);
		}

		public void DeleteExpiredTokens()
		{
			var now = DateTime.UtcNow;
			var userTokens = _unitOfWork.UserTokenRepository.Get(x => x.RefreshTokenExpiresUtc < now, null).ToList();
			foreach (var userToken in userTokens)
			{
				try
				{
					_unitOfWork.UserTokenRepository.Delete(userToken);
				}
				catch { }
			}
		}

		public void DeleteToken(string hashedTokenId)
		{
			var token = FindToken(hashedTokenId);
			if (token != null)
			{
				_unitOfWork.UserTokenRepository.Delete(token);
			}
		}

		public void UpdateUserToken(long userId, string accessTokenHash)
		{
			var token = _unitOfWork.UserTokenRepository.Get(x => x.OwnerUserId == userId).FirstOrDefault();
			if (token != null)
			{
				token.AccessTokenHash = accessTokenHash;
			}
			_repository.Update(token);
		}

		public void InvalidateUserTokens(string parse)
		{
			var accessTokenHash = SecurityHelper.GetSha256Hash(parse);
			var userTokens = _unitOfWork.UserTokenRepository.Get(x => x.AccessTokenHash == accessTokenHash, null).ToList();
			foreach (var userToken in userTokens)
			{
				_unitOfWork.UserTokenRepository.Delete(userToken);
			}
		}

		public IList<UserTokenDto> FindAll()
		{
			return _unitOfWork.UserTokenRepository.Get().Select(_mapper.MapTo).ToList();
		}

		public UserTokenDto Save(UserTokenDto dto)
		{
			var model = _unitOfWork.UserTokenRepository.Insert(_mapper.CreateFrom(dto));
			return _unitOfWork.UserTokenRepository.Get(x => x.Id == model.Id).Select(_mapper.MapTo).FirstOrDefault();
		}

		public bool Remove(UserTokenDto dto)
		{
			_unitOfWork.UserTokenRepository.Delete(dto.Id);
			return true;
		}
		#endregion

		#region Functions
		public UserToken FindToken(string refreshTokenIdHash)
		{
			return _unitOfWork.UserTokenRepository.Get(x => x.RefreshTokenIdHash == refreshTokenIdHash).FirstOrDefault();
		}
		#endregion
	}
}
