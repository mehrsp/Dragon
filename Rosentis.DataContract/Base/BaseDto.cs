using Rosentis.DataContract.ExeptionModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rosentis.DataContract.Base
{
	public class BaseDto
	{
		public List<ExceptionDto> Exceptions;
		public string Token { get; set; }
		protected BaseDto()
		{
			Exceptions = new List<ExceptionDto>();
		}

		public void AddException(ExceptionDto exception)
		{
			Exceptions.Add(exception);
		}
	}
}
