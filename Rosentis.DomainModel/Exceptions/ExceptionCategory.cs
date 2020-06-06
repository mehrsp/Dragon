using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Rosentis.DomainModel.Exceptions
{
    public class ExceptionCategory
	{
		public int Id { get; set; }
		[Required]
        public string Title { get; set; }
      
    }
}