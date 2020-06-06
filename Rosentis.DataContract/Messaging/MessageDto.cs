using System;
using System.Collections;
using System.Collections.Generic;
using Rosentis.DataContract.Base;
using Rosentis.DataContract.AuthEntities;
using Rosentis.DataContract.Blobs;

namespace Rosentis.DataContract.Messaging
{
    public class MessageDto: BaseDto
    {
		public int SenderId {get; set;}
		public bool IsFinal {get; set;}
		public UserDto Sender {get; set;}
		public IList<UserDto> Receivers {get; set;}
		public IList<UserDto> Transcripts {get; set;}
		public IList<UserDto> HiddenTranscripts {get; set;}
		public string Subject {get; set;}
		public string Body {get; set;}
		public bool IsAction {get; set;}
		public DateTime ActionDateTime {get; set;}
		public DateTime CreatedDate {get; set;}
		public int MessageTypeId {get; set;}
		public MessageTypeDto MessageType {get; set;}
		public long? ScanId {get; set;}
		public BlobDescriptionDto Scan {get; set;}
		public Guid Id {get; set;}

        public MessageDto()
        {
            Receivers = new List<UserDto>();
            Transcripts = new List<UserDto>();
            HiddenTranscripts = new List<UserDto>();
        }
    }
}
