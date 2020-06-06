using Rosentis.DomainModel.Brands;
using Rosentis.DomainModel.Users;
using Rosentis.DomainModel.AuthEntities;
using Rosentis.DomainModel.Tags;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Rosentis.DomainModel.Products
{
	public class Product
	{
		public Product()
		{
			Catalogs = new HashSet<ProductCatalog>();
			Comments = new HashSet<Comment>();
			Tags = new HashSet<Tag>();
		}
		[Key]
		public long Id { get; set; }
		public string Name { get; set; }
		public DateTime? LatestPriceModified { get; set; }
		public int Price { get; set; }
		public bool Discontinued { get; set; }
		public double Quantity { get; set; }
		public string Description { get; set; }
		public string Specifications { get; set; }
		public virtual Brand Brand { get; set; }
		public int? BrandId { get; set; }
		public virtual Supplier Supplier { get; set; }
		public long?  SupplierId { get; set; }
		public DateTime CreatedDate { get; set; }
		public User CreatedBy { get; set; }
		public long CreatedById { get; set; }
		public ProductCategory ProductCategory { get; set; }
		public int? ProductCategoryId { get; set; }
		public double Ranking { get; set; }
		public long? SoldCount { get; set; }
		public long? LikeCount { get; set; }
		public long? FavoritCount { get; set; }
		public bool IsRemoved { get; set; }
		public decimal Discount { get; set; }
		public bool Orderable { get; set; }
		public long Time { get; set; }
		public string Picture { get; set; }
		public virtual Product Parent { get; set; }
		public long? ParentId { get; set; }
		public ICollection<ProductCatalog> Catalogs { get; set; }
		public ICollection<Tag> Tags { get; set; }
		public ICollection<Comment> Comments { get; set; }
		public virtual ICollection<ProductImage> Images { get; set; }
		public virtual List<ProductTechnical> Technicals { get; set; }
		public virtual ICollection<Product> Children { get; set; }
	}
}
