using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Rosentis.DomainModel.Exceptions
{
    public class Exception
    {
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.None)] 
		public int Id { get; set; }
		[Required]
        public string Title { get; set; }
        [Required]
        public string Message { get; set; }
        public virtual ExceptionCategory Category { get; set; }
        [Required]
        public int CategoryId { get; set; }

    }
}
