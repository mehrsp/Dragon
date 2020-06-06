using AutoMapper;
using Rosentis.DomainModel.AuthEntities;
using Rosentis.DataContract.Base;
using Rosentis.DataContract.Brands;

using Rosentis.DataContract.ExeptionModel;
using Rosentis.DataContract.Info.Address;
using Rosentis.DataContract.Users;
using Rosentis.DataContract.Products;
using Rosentis.DataContract.Slides;
using Rosentis.DomainModel.Brands;
using Rosentis.DomainModel.Exceptions;
using Rosentis.DomainModel.Users;
using Rosentis.DomainModel.Products;
using Rosentis.DataContract.AuthEntities;
using Rosentis.DomainModel.Base;
using Rosentis.DomainModel.Shop;
using Rosentis.DataContract.Shop;

namespace Rosentis.ServiceImplementation
{
	public class AutoMapperConfig
	{
		public static void RegisterMappings()
		{
			Mapper.Initialize(cfg =>
			{
				#region Users
				cfg.CreateMap<User, UserDto>();
				cfg.CreateMap<UserDto, User>();

				cfg.CreateMap<Supplier, SupplierDto>();
				cfg.CreateMap<SupplierDto, Supplier>();


				cfg.CreateMap<Member, MemberDto>();
				cfg.CreateMap<MemberDto, Member>();

				cfg.CreateMap<DropBoxDto, Supplier>()
			  .ForMember(dto => dto.Name, opt => opt.MapFrom(src => src.Text));
				cfg.CreateMap<Supplier, DropBoxDto>()
				  .ForMember(dto => dto.Text, opt => opt.MapFrom(src => src.Name));
				#endregion
				#region Address
				cfg.CreateMap<Province, ProvinceDto>();
				cfg.CreateMap<ProvinceDto, Province>();
				cfg.CreateMap<DropBoxDto, Province>()
				  .ForMember(dto => dto.Name, opt => opt.MapFrom(src => src.Text));
				cfg.CreateMap<Province, DropBoxDto>()
				  .ForMember(dto => dto.Text, opt => opt.MapFrom(src => src.Name));

				cfg.CreateMap<City, CityDto>();
				cfg.CreateMap<CityDto, City>();
				cfg.CreateMap<DropBoxDto, City>()
				  .ForMember(dto => dto.Name, opt => opt.MapFrom(src => src.Text));
				cfg.CreateMap<City, DropBoxDto>()
				  .ForMember(dto => dto.Text, opt => opt.MapFrom(src => src.Name));


				cfg.CreateMap<Country, CountryDto>();
				cfg.CreateMap<CountryDto, Country>();
				cfg.CreateMap<DropBoxDto, Country>()
				  .ForMember(dto => dto.Title, opt => opt.MapFrom(src => src.Text));
				cfg.CreateMap<Country, DropBoxDto>()
				  .ForMember(dto => dto.Text, opt => opt.MapFrom(src => src.Title));
				#endregion Address
				#region Exceptions
				cfg.CreateMap<Exception, ExceptionDto>();
				cfg.CreateMap<ExceptionDto, Exception>();
				#endregion Exceptions
				#region Brands
				cfg.CreateMap<Brand, BrandDto>();
				cfg.CreateMap<BrandDto, Brand>();

				cfg.CreateMap<DropBoxDto, Brand>()
				  .ForMember(dto => dto.Name, opt => opt.MapFrom(src => src.Text));
				cfg.CreateMap<Brand, DropBoxDto>()
				  .ForMember(dto => dto.Text, opt => opt.MapFrom(src => src.Name));

				#endregion Brands
				#region Products
				cfg.CreateMap<Comment, CommentDto>();
				cfg.CreateMap<CommentDto, Comment>();

				cfg.CreateMap<Product, ProductDto>();
				cfg.CreateMap<ProductDto, Product>();
				
				cfg.CreateMap<ProductCatalog, ProductCatalogDto>();
				cfg.CreateMap<ProductCatalogDto, ProductCatalog>();

				cfg.CreateMap<ProductCategory, ProductCategoryDto>();
				cfg.CreateMap<ProductCategoryDto, ProductCategory>();

				cfg.CreateMap<DropBoxDto, ProductCategory>()
				  .ForMember(dto => dto.Name, opt => opt.MapFrom(src => src.Text));
				cfg.CreateMap<ProductCategory, DropBoxDto>()
				  .ForMember(dto => dto.Text, opt => opt.MapFrom(src => src.Name));

				cfg.CreateMap<ProductImage, ProductImageDto>();
				cfg.CreateMap<ProductImageDto, ProductImage>();
				
				cfg.CreateMap<ProductRelated, ProductRelatedDto>();
				cfg.CreateMap<ProductRelatedDto, ProductRelated>();


				cfg.CreateMap<ProductTechnical, ProductTechnicalDto>();
				cfg.CreateMap<ProductTechnicalDto, ProductTechnical>();

				cfg.CreateMap<Technical, TechnicalDto>();
				cfg.CreateMap<TechnicalDto, Technical>();

				cfg.CreateMap<Technical, TechnicalChildDto>();
				cfg.CreateMap<TechnicalChildDto, Technical>();

				cfg.CreateMap<DropBoxDto, Technical>()
			  .ForMember(dto => dto.Title, opt => opt.MapFrom(src => src.Text));
				cfg.CreateMap<Technical, DropBoxDto>()
				  .ForMember(dto => dto.Text, opt => opt.MapFrom(src => src.Title));

				cfg.CreateMap<ProductCategoryTechnical, ProductCategoryTechnicalDto>();
				cfg.CreateMap<ProductCategoryTechnicalDto, ProductCategoryTechnical>();
				#endregion Products
				#region SlideShow

				cfg.CreateMap<Rosentis.DomainModel.Slides.SlideShow, SlideShowDto>();
				cfg.CreateMap<SlideShowDto, Rosentis.DomainModel.Slides.SlideShow>();

				#endregion
				#region Cart

				cfg.CreateMap<Cart, CartDto>();
				cfg.CreateMap<CartDto, Cart>();

				cfg.CreateMap<CartItem, CartItemDto>();
				cfg.CreateMap<CartItemDto, CartItem>();
				#endregion
			});
		}
	}
}
