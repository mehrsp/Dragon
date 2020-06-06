using System;

namespace Rosentis.DomainModel.Tags
{
    public class Tag 
    {
        protected Tag()
        {

        }
		public Guid Id { get; set; }
		public string Name {get; set;}
		public virtual TagType Type {get; set;}
        public int TypeId { get;  set; }
    }
}
