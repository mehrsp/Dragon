using System;
using Rosentis.DataContract.Base;
using Rosentis.DataContract.Base.Dtos;
using Rosentis.ServiceContract.AuthEntities;
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
using Rosentis.ServiceContract.Info.Address;
using Rosentis.DataContract.Info.Address.Dtos;

namespace Rosentis.Api.Controllers.Base
{
	public class CountriesController : ApiController
	{
		#region Propertises
		private ICountryService _countryService;
		#endregion

		#region Ctors
		public CountriesController(ICountryService countryService)
		{
			_countryService = countryService;
		}
		#endregion

		#region Methods
		[HttpPost]
		public DropBoxDtos FillDropBox()
		{
			return _countryService.FillDropBox();
		}
		#endregion
	}
}