using Rosentis.DataContract.Base;
using System.Collections.Generic;

namespace Rosentis.DataContract.Messaging.Dtos
{
	public class MessageDtos : BaseDto
	{
		public List<MessageDto> Messages { get; set; }

		public MessageDtos()
		{
			Messages = new List<MessageDto>();
		}
	}
}
