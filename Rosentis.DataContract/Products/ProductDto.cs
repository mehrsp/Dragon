using Rosentis.DataContract.Base;
using Rosentis.DataContract.Brands;
using Rosentis.DataContract.Users;
using Rosentis.DataContract.Tags;
using System;
using System.Collections.Generic;
using Rosentis.DataContract.AuthEntities;
using System.Linq;

namespace Rosentis.DataContract.Products
{
	public class ProductDto: BaseDto
	{
		public ProductDto()
		{
			Catalogs = new List<ProductCatalogDto>();
			Comments = new List<CommentDto>();
			Images = new List<ProductImageDto>();
			Tags = new List<TagDto>();
			Children = new List<ProductDto>();
		}
		public long Id { get; set; }
		public string Name { get; set; }
		public DateTime? LatestPriceModified { get; set; }
		public bool Discontinued { get; set; }
		public double Quantity { get; set; }
		public string Description { get; set; }
		public string Specifications { get; set; }
		public virtual BrandDto Brand { get; set; }
		public int? BrandId { get; set; }
		public virtual SupplierDto Supplier { get; set; }
		public long? SupplierId { get; set; }
		public DateTime CreatedDate { get; set; }
		public UserDto CreatedBy { get; set; }
		public long CreatedById { get; set; }
		public ProductCategoryDto ProductCategory { get; set; }
		public int? ProductCategoryId { get; set; }
		public double Ranking { get; set; }
		public long? SoldCount { get; set; }
		public long? LikeCount { get; set; }
		public long? FavoritCount { get; set; }
		public bool IsRemoved { get; set; }
		public int Price { get; set; }
		public string PriceMoney { get {
				if (Children.Count == 0)
				{
					return Price.ToString("#,##0") + " تومان";
				}
				else
				{
					var t =Children.Average(x => x.Price);
					return t.ToString("#,##0") + " تومان";
				}
				 } } 
		public decimal Discount { get; set; }
		public string DiscountMoney => ((int)Discount).ToString() + "%";
		public string PriceMoneyWithDiscount => ((Price * (Discount / 100)) * UserQuantity).ToString("#,##0") + " تومان";
		public bool Orderable { get; set; }
		public int UserQuantity { get; set; } = 1;
		public int DiscountPrice => (int)((Price - (Price * (Discount / 100))) * UserQuantity);
		public string PriceWithDiscountMoney => DiscountPrice.ToString("#,##0") + " تومان";		
		public long Time { get; set; }
		public string Picture { get; set; }		
		//public virtual ProductDto Parent { get; set; }
		public long? ParentId { get; set; }
		//showing just parent name 
		public string ParentName { get; set; }
		public List<ProductCatalogDto> Catalogs { get; set; }
		public List<TagDto> Tags { get; set; }
		public List<CommentDto> Comments { get; set; }
		public virtual List<ProductImageDto> Images { get; set; }
		public virtual List<ProductDto> Children { get; set; }
		public virtual List<ProductCategoryDto> Categories { get; set; }
		public virtual List<ProductTechnicalDto> Technicals { get; set; }
	}
}
