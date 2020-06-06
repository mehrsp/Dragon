using Rosentis.DataContract.Base;
using Rosentis.DataContract.Messaging;
using Rosentis.DataContract.Messaging.Dtos;

namespace Rosentis.ServiceContract.Messaging
{
	public interface IMessageService
	{
		MessageDto Save(MessageDto dto);
		DtoResponse Remove(MessageDto dto);
		DataContract.Messaging.MessageDtos FindAll();
		MessageDto FindById(long id);
		DataContract.Messaging.MessageDtos FindByChecked(bool isChecked);
	}
}
