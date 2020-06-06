using System;
using System.ComponentModel.DataAnnotations.Schema;
namespace Rosentis.DomainModel.Messaging
{
    public class MessageType
    {

        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }

        public MessageType()
        {

        }
        public MessageType(int id, string name)
        {
            Id = id;
            Name = name;
        }
        public string Name { get; set; }
    }
}
