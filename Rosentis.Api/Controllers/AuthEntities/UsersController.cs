using System;
using Rosentis.DataContract.Base;
using Rosentis.DataContract.Base.Dtos;
using Rosentis.DataContract.Brands;
using Rosentis.DataContract.Brands.Dtos;
using Rosentis.ServiceContract.AuthEntities;
using Rosentis.ServiceContract.Brands;
using System.Web.Http;
using Rosentis.Api.JsonWebTokenConfig;
using Rosentis.DataContract.AuthEntities;
using System.Security.Claims;
using System.Net.Http;
using Rosentis.Api.Models;
using System.Web;
using Newtonsoft.Json;
using Rosentis.Api.Helper;
using System.IO;
using System.Net.Http.Headers;

namespace Rosentis.Api.Controllers.Brands
{
	[RoutePrefix("api/Users")]
	public class UsersController: ApiController
	{
		#region Propertises
		private readonly IUsersApplicationService _usersService; 
		#endregion

		#region Ctors
		public UsersController(IUsersApplicationService usersService)
		{
			_usersService = usersService;
		}
		#endregion

		#region Methods
		[HttpPost]
		[Route("Save")]
		public UserDto Save(UserDto dto)
		{
			return _usersService.Save(dto);
		}
		#endregion
	}
}