using System.Collections.Generic;
using Rosentis.DataContract.Messaging;
using Rosentis.DomainModel.Messaging;
using Rosentis.DomainModel.Messaging.NullObjects;
using Rosentis.DataContract.AuthEntities;
using Rosentis.DataContract.Blobs;
using Rosentis.DomainModel.AuthEntities;
using Rosentis.DomainModel.Blobs;
using Rosentis.DistributedServices;

namespace Rosentis.ServiceImplementation.Messaging.Mapper
{
    public class MessageMapper : IEntityMapper<Message, MessageDto>
    {
		private IEntityMapper<User, UserDto> _userMapper;
		private IEntityMapper<MessageType, MessageTypeDto> _messageTypeMapper;
		private IEntityMapper<BlobDescription, BlobDescriptionDto> _blobDescriptionMapper;

        public MessageMapper(IEntityMapper<User, UserDto> userMapper,IEntityMapper<MessageType, MessageTypeDto> messageTypeMapper,IEntityMapper<BlobDescription, BlobDescriptionDto> blobDescriptionMapper)
        {
		_userMapper = userMapper;
		_messageTypeMapper = messageTypeMapper;
		_blobDescriptionMapper = blobDescriptionMapper;

        }
        public Message CreateFrom(MessageDto domainDto)
        {
            if (domainDto == null)
                return new NullMessage();
            var receivers = new List<User>();
            foreach (var item in domainDto.Receivers)
            {
                receivers.Add(_userMapper.CreateFrom(item));
            }
            var transcripts = new List<User>();
            foreach (var item in domainDto.Transcripts)
            {
                transcripts.Add(_userMapper.CreateFrom(item));
            }
            var hiddenTranscripts = new List<User>();
            foreach (var item in domainDto.HiddenTranscripts)
            {
                hiddenTranscripts.Add(_userMapper.CreateFrom(item));
            }
			//return new Message(domainDto.SenderId,domainDto.IsFinal,null,receivers,transcripts,hiddenTranscripts,domainDto.Subject,domainDto.Body,domainDto.IsAction,domainDto.ActionDateTime,domainDto.CreatedDate,domainDto.MessageTypeId,domainDto.ScanId,null,null,domainDto.Id);
			return null;
        }

        public MessageDto MapTo(Message domain)
        {
            MessageDto domainDto = new MessageDto();
            if (domain != null)
            {
				domainDto.SenderId = domain.SenderId;
				domainDto.IsFinal = domain.IsFinal;
				if(domain.Sender!=null)domainDto.Sender = _userMapper.MapTo(domain.Sender);
                foreach (var item in domain.Receivers)
                {
                    domainDto.Receivers.Add(_userMapper.MapTo(item));
                }
                foreach (var item in domain.Transcripts)
                {
                    domainDto.Transcripts.Add(_userMapper.MapTo(item));
                }
                foreach (var item in domain.HiddenTranscripts)
                {
                    domainDto.HiddenTranscripts.Add(_userMapper.MapTo(item));
                }
				domainDto.Subject = domain.Subject;
				domainDto.Body = domain.Body;
				domainDto.IsAction = domain.IsAction;
				domainDto.ActionDateTime = domain.ActionDateTime;
				domainDto.CreatedDate = domain.CreatedDate;
				domainDto.MessageTypeId = domain.MessageTypeId;
				if(domain.MessageType!=null)domainDto.MessageType = _messageTypeMapper.MapTo(domain.MessageType);
				domainDto.ScanId = domain.ScanId;
				if(domain.Scan!=null)domainDto.Scan = _blobDescriptionMapper.MapTo(domain.Scan);
				domainDto.Id = domain.Id;

            }

            return domainDto;
        }
    }

}