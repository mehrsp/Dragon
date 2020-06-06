using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using Rosentis.DomainModel.AuthEntities;
using Rosentis.DomainModel.Blobs;

namespace Rosentis.DomainModel.Messaging
{
    public class Message
    {
        public Guid Id { get; set; }
        public Message()
        {
            this.Receivers = new List<User>();
            this.Transcripts = new List<User>();
            this.HiddenTranscripts = new List<User>();

        }
        public int SenderId { get; set; }
        public bool IsFinal { get; set; }
        public virtual User Sender { get; set; }
        public virtual long userId { get; set; }
        public virtual IList<User> Receivers { get; set; }
        public virtual IList<User> Transcripts { get; set; }
        public virtual IList<User> HiddenTranscripts { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }
        public bool IsAction { get; set; }
        public DateTime ActionDateTime { get; set; }
        public DateTime CreatedDate { get; set; }
        public int MessageTypeId { get; set; }
        public virtual MessageType MessageType { get; set; }
        public long? ScanId { get; set; }
        public virtual BlobDescription Scan { get; set; }
    }
}
