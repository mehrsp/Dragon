using System;
using System.Data.Entity.Validation;
using System.Diagnostics;
using Rosentis.DomainModel.Products;
using Rosentis.DomainModel.Brands;
using Rosentis.DomainModel.Messaging;
using Rosentis.DomainModel.Slides;
using Rosentis.Persistance.Facade;
using Rosentis.DomainModel.Users;
using Rosentis.DomainModel.AuthEntities;
using Rosentis.DomainModel.Base;
using System.Linq;
using Rosentis.DomainModel.Shop;

namespace Rosentis.Persistance
{

    public class UnitOfWork
    {
		private RosentisContext context = new RosentisContext();

		#region Member
		private GenericRepository<Member> _MemberRepository;
		public GenericRepository<Member> MemberRepository
		{
			get
			{

				if (this._MemberRepository == null)
				{
					this._MemberRepository = new GenericRepository<Member>(context);
					this._MemberRepository.SetIncludes(x=>x.ImportantDates);
				}
				return _MemberRepository;
			}
		}

		#endregion
		#region Supplier
		private GenericRepository<Supplier> _SupplierRepository;
		public GenericRepository<Supplier> SupplierRepository
		{
			get
			{

				if (this._SupplierRepository == null)
				{
					this._SupplierRepository = new GenericRepository<Supplier>(context);
				}
				return _SupplierRepository;
			}
		}

		#endregion		
		#region Province
		private GenericRepository<Province> _ProvinceRepository;
		public GenericRepository<Province> ProvinceRepository
		{
			get
			{

				if (this._ProvinceRepository == null)
				{
					this._ProvinceRepository = new GenericRepository<Province>(context);
				}
				return _ProvinceRepository;
			}
		}

		#endregion
		#region City
		private GenericRepository<City> _CityRepository;
		public GenericRepository<City> CityRepository
		{
			get
			{

				if (this._CityRepository == null)
				{
					this._CityRepository = new GenericRepository<City>(context);
				}
				return _CityRepository;
			}
		}

		#endregion
		#region Country
		private GenericRepository<Country> _countryRepository;
		public GenericRepository<Country> countryRepository
		{
			get
			{

				if (this._countryRepository == null)
				{
					this._countryRepository = new GenericRepository<Country>(context);
				}
				return _countryRepository;
			}
		}

		#endregion
		#region Brand
		private GenericRepository<Brand> _BrandRepository;
		public GenericRepository<Brand> BrandRepository
		{
			get
			{

				if (this._BrandRepository == null)
				{
					this._BrandRepository = new GenericRepository<Brand>(context);
					this._BrandRepository.SetIncludes(x => x.Country);

				}
				return _BrandRepository;
			}
		}

		#endregion
		#region Comment
		private GenericRepository<Comment> _CommentRepository;
		public GenericRepository<Comment> CommentRepository
		{
			get
			{

				if (this._CommentRepository == null)
				{
					this._CommentRepository = new GenericRepository<Comment>(context);
				}
				return _CommentRepository;
			}
		}

		#endregion
		#region ProductCatalog
		private GenericRepository<ProductCatalog> _ProductCatalogRepository;
		public GenericRepository<ProductCatalog> ProductCatalogRepository
		{
			get
			{

				if (this._ProductCatalogRepository == null)
				{
					this._ProductCatalogRepository = new GenericRepository<ProductCatalog>(context);
				}
				return _ProductCatalogRepository;
			}
		}

		#endregion
		#region ProductCategory
		private GenericRepository<ProductCategory> _ProductCategoryRepository;
		public GenericRepository<ProductCategory> ProductCategoryRepository
		{
			get
			{

				if (this._ProductCategoryRepository == null)
				{
					this._ProductCategoryRepository = new GenericRepository<ProductCategory>(context);
					this._ProductCategoryRepository.SetIncludes(x => x.Children);

				}
				return _ProductCategoryRepository;
			}
		}

		#endregion
		#region Product
		private GenericRepository<Product> _ProductRepository;
		public GenericRepository<Product> ProductRepository
		{
			get
			{

				if (this._ProductRepository == null)
				{
					this._ProductRepository = new GenericRepository<Product>(context);
					_ProductRepository.SetIncludes(x => x.Brand, x => x.Catalogs, x => x.Comments,x => x.Supplier, x => x.ProductCategory.Parent, x => x.Images, x => x.Technicals,  x => x.Technicals.Select(y=>y.Technical.Parent));
				}
				return _ProductRepository;
			}
		}

		#endregion
		#region Message
		private GenericRepository<Message> _MessageRepository;
		public GenericRepository<Message> MessageRepository
		{
			get
			{

				if (this._MessageRepository == null)
				{
					this._MessageRepository = new GenericRepository<Message>(context);
				}
				return _MessageRepository;
			}
		}

		#endregion
		#region ProductImage
		private GenericRepository<ProductImage> _ProductImageRepository;
		public GenericRepository<ProductImage> ProductImageRepository
		{
			get
			{

				if (this._ProductImageRepository == null)
				{
					this._ProductImageRepository = new GenericRepository<ProductImage>(context);
				}
				return _ProductImageRepository;
			}
		}

		#endregion
		#region ProductRelated
		private GenericRepository<ProductRelated> _ProductRelatedRepository;
		public GenericRepository<ProductRelated> ProductRelatedRepository
		{
			get
			{

				if (this._ProductRelatedRepository == null)
				{
					this._ProductRelatedRepository = new GenericRepository<ProductRelated>(context);
				}
				return _ProductRelatedRepository;
			}
		}

		#endregion
		#region ProductTechnical
		private GenericRepository<ProductTechnical> _productTechnicalRepository;
		public GenericRepository<ProductTechnical> productTechnicalRepository
		{
			get
			{

				if (this._productTechnicalRepository == null)
				{
					this._productTechnicalRepository = new GenericRepository<ProductTechnical>(context);
					this._productTechnicalRepository.SetIncludes(x=>x.Technical, x => x.Technical.Parent);
				}
				return _productTechnicalRepository;
			}
		}

		#endregion
		#region ProductCategoryTechnical
		private GenericRepository<ProductCategoryTechnical> _productCategoryTechnicalRepository;
		public GenericRepository<ProductCategoryTechnical> ProductCategoryTechnicalRepository
		{
			get
			{

				if (this._productCategoryTechnicalRepository == null)
				{
					this._productCategoryTechnicalRepository = new GenericRepository<ProductCategoryTechnical>(context);
					this._productCategoryTechnicalRepository.SetIncludes(x=>x.Technical, x => x.Technical.Children,x=> x.Brand);
				}
				return _productCategoryTechnicalRepository;
			}
		}

		#endregion
		#region Technical
		private GenericRepository<Technical> _techincalRepository;
		public GenericRepository<Technical> TechnicalRepository
		{
			get
			{

				if (this._techincalRepository == null)
				{
					this._techincalRepository = new GenericRepository<Technical>(context);
					this._techincalRepository.SetIncludes(x=>x.Parent);
				}
				return _techincalRepository;
			}
		}

		#endregion
		#region SlideShow
		private GenericRepository<SlideShow> _SlideShowRepository;
		public GenericRepository<SlideShow> SlideShowRepository
		{
			get
			{

				if (this._SlideShowRepository == null)
				{
					this._SlideShowRepository = new GenericRepository<SlideShow>(context);
				}
				return _SlideShowRepository;
			}
		}

		#endregion
		#region Cart
		private GenericRepository<Cart> _cartRepository;
		public GenericRepository<Cart> CartRepository
		{
			get
			{

				if (this._cartRepository == null)
				{
					this._cartRepository = new GenericRepository<Cart>(context);
					this._cartRepository.SetIncludes(x=>x.CartItems,x=>x.CartItems.Select(y => y.Product));
				}
				return _cartRepository;
			}
		}
		#endregion
		#region CartItem
		private GenericRepository<CartItem> _cartItemRepository;
		public GenericRepository<CartItem> CartItemRepository
		{
			get
			{

				if (this._cartItemRepository == null)
				{
					this._cartItemRepository = new GenericRepository<CartItem>(context);
				}
				return _cartItemRepository;
			}
		}
		#endregion
		#region Rosentis.DomainModel.Exceptions.Exception
		private GenericRepository<Rosentis.DomainModel.Exceptions.Exception> _exception;

		public GenericRepository<Rosentis.DomainModel.Exceptions.Exception> Exception
		{
			get
			{

				if (this._exception == null)
				{
					this._exception = new GenericRepository<Rosentis.DomainModel.Exceptions.Exception>(context);
					_exception.SetIncludes(x => x.Category);
				}
				return _exception;
			}
		}
		#endregion
		public void Save()
		{
			try
			{
				context.SaveChanges();

			}
			catch (ArgumentNullException EX)
			{
				throw;
			}
			catch (DbEntityValidationException e)
			{
				foreach (var eve in e.EntityValidationErrors)
				{
					Debug.WriteLine("Entity of type \"{0}\" in state \"{1}\" has the following validation errors:",
						eve.Entry.Entity.GetType().Name, eve.Entry.State);
					foreach (var ve in eve.ValidationErrors)
					{
						Debug.WriteLine("- Property: \"{0}\", Error: \"{1}\"",
							ve.PropertyName, ve.ErrorMessage);
						throw new ApplicationException(ve.PropertyName + ve.ErrorMessage);
					}
				}

			}
		}
		private bool disposed = false;
		protected virtual void Dispose(bool disposing)
		{
			if (!this.disposed)
			{
				if (disposing)
				{
					context.Dispose();
				}
			}
			this.disposed = true;
		}
		#region Authentication
		//private UserRepository _userRepository;
		//public IUsersRepository UserRepository
		//{
		//	get
		//	{

		//		if (this._userRepository == null)
		//		{
		//			this._userRepository = new UserRepository(context);
		//		}
		//		return _userRepository;
		//	}
		//}
		//private TokenStoreRepository _tokenStoreRepository;
		//public TokenStoreRepository TokenStoreRepository
		//{
		//	get
		//	{

		//		if (this._tokenStoreRepository == null)
		//		{
		//			this._tokenStoreRepository = new TokenStoreRepository(context);
		//		}
		//		return _tokenStoreRepository;
		//	}
		//}
		//private GenericRepository<UserRole> _userRoleRepository;
		//public GenericRepository<UserRole> UserRoleRepository
		//{
		//	get
		//	{

		//		if (this._userRoleRepository == null)
		//		{
		//			this._userRoleRepository = new GenericRepository<UserRole>(context);
		//		}
		//		return _userRoleRepository;
		//	}
		//}
		private GenericRepository<UserToken> _userTokenRepository;
		public GenericRepository<UserToken> UserTokenRepository
		{
			get
			{

				if (this._userTokenRepository == null)
				{
					this._userTokenRepository = new GenericRepository<UserToken>(context);
				}
				return _userTokenRepository;
			}
		}
		private GenericRepository<Permission> _permissionRepository;
		public GenericRepository<Permission> PermissionRepository
		{
			get
			{

				if (this._permissionRepository == null)
				{
					this._permissionRepository = new GenericRepository<Permission>(context);
				}
				return _permissionRepository;
			}
		}
		private GenericRepository<User> _userRepository;
		public GenericRepository<User> UserRepository
		{
			get
			{

				if (this._userRepository == null)
				{
					this._userRepository = new GenericRepository<User>(context);
					this._userRepository.SetIncludes(x => x.Roles, x => x.Permissions);

				}
				return _userRepository;
			}
		}
		private GenericRepository<Role> _roleRepository;
		public GenericRepository<Role> RoleRepository
		{
			get
			{

				if (this._roleRepository == null)
				{
					this._roleRepository = new GenericRepository<Role>(context);
				}
				return _roleRepository;
			}
		}
		private GenericRepository<UserVerification> _userVerificationRepository;
		public GenericRepository<UserVerification> UserVerificationRepository
		{
			get
			{

				if (this._userVerificationRepository == null)
				{
					this._userVerificationRepository = new GenericRepository<UserVerification>(context);
				}
				return _userVerificationRepository;
			}
		}

		#endregion
		public void Dispose()
		{
			Dispose(true);
			GC.SuppressFinalize(this);
		}
		internal void DisableProxy()
		{
		}
		internal void EnableProxy()
		{

		}
	}
}
