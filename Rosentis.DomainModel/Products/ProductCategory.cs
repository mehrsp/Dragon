using Rosentis.DomainModel.AuthEntities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Rosentis.DomainModel.Products
{
	public class ProductCategory
	{
		public int Id { get; set; }
		public virtual ProductCategory Parent { get; set; }
		public int? ParentId { get; set; }
		public string Name { get; set; }
		public int Priority { get; set; }
		public DateTime CreatedDate { get; set; }
		public DateTime? ModifiedDate { get; set; }
		public virtual User CreatedBy { get; set; }
		public long? CreatedById { get; set; }
		public virtual ICollection<Product> Products { get; set; }
		public virtual ICollection<ProductCategory> Children { get; set; }
		public virtual ICollection<ProductCategoryTechnical> ProductCategoryTechnicals { get; set; }
		public ProductCategory()
		{
			Children = new List<ProductCategory>();
		}
	}
}
