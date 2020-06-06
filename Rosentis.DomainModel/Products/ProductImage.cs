
using Rosentis.DomainModel.AuthEntities;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Rosentis.DomainModel.Products
{
	public class ProductImage
	{
		public long Id { get; set; }
		public string Title { get; set; }
		public virtual Product Product { get; set; }
		public long ProductId { get; set; }
		public DateTime CreatedDate { get; set; }
		public string Photo { get; set; }
	}
}
