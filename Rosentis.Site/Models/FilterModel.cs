using Rosentis.DataContract.Brands.Dtos;
using Rosentis.DataContract.Info.Address.Dtos;
using Rosentis.DataContract.Products;
using Rosentis.DataContract.Products.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Rosentis.Site.Models
{
    public class FilterModel
    {
		public ProductDtos Products { get; set; }
		public decimal PageCount { get; set; }
		public int CurrentPage { get; set; }
		public ProductCategoryTechnicalDtos Technicals { get; set; }
		public int CategoryId { get; set; }
		public FilterCategoryChild FilterCategoryChild { get; set; }
		public string OrderBy { get; set; }
		public List<int> Filters { get; set; }
		public string FilterString { get; set; }
		public List<int> Brands { get; set; }
		public List<int> Countries { get; set; }
		public string CountryString { get; set; }
		public string BrandString { get; set; }
		public TechnicalDtos TechnicalChooses { get; set; }
		public BrandDtos BrandChooses { get; set; }
		public CountryDtos CountryChooses { get; set; }
		public int OnSale { get; set; }
		public int InStock { get; set; }
		public int MinPrice { get; set; } = 1000;
		public int MaxPrice { get; set; } = 10000000;
	}
}