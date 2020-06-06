using Rosentis.DomainModel.Base;
using Rosentis.DomainModel.Brands;
using Rosentis.DomainModel.Exceptions;
using Rosentis.DomainModel.Products;
using Rosentis.DomainModel.Slides;
using Rosentis.DomainModel.Users;
using Rosentis.DomainModel.AuthEntities;
using Rosentis.DomainModel.Blobs;
using Rosentis.DomainModel.Messaging;
using Rosentis.DomainModel.Notification;
using Rosentis.DomainModel.Pages;
using Rosentis.DomainModel.Shop;
using Rosentis.DomainModel.Tags;
using Rosentis.DomainModel.Visits;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using Rosentis.Persistance.Migrations;
using Rosentis.Persistance.Mapping.AuthEntities;
using Rosentis.Persistance.Mapping.Base;
using Rosentis.Persistance.Mapping.Blobs;
using Rosentis.Persistance.Mapping.Brands;
using Rosentis.Persistance.Mapping.ExceptionCategotys;
using Rosentis.Persistance.Mapping.Exceptions;
using Rosentis.Persistance.Mapping.Messaging;
using Rosentis.Persistance.Mapping.Notifications;
using Rosentis.Persistance.Mapping.Products;
using Rosentis.Persistance.Mapping.Pages;
using Rosentis.Persistance.Mapping.Shop;
using Rosentis.Persistance.Mapping.SlideShow;
using Rosentis.Persistance.Mapping.Tags;
using Rosentis.Persistance.Mapping.Users;
using Rosentis.Persistance.Mapping.Visits;

namespace Rosentis.Persistance.Facade
{
	public class RosentisContext : DbContext
	{
		public RosentisContext() : base("rosentisConnection")
		{
			//Configuration.LazyLoadingEnabled = false;
			Database.SetInitializer(new MigrateDatabaseToLatestVersion<RosentisContext, Configuration>());
		}
		protected override void OnModelCreating(DbModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);
			modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();

			#region AuthEntities
			modelBuilder.Configurations.Add(new PermissionMap());
			modelBuilder.Configurations.Add(new UserMap());
			modelBuilder.Configurations.Add(new UserTokenMap());
			modelBuilder.Configurations.Add(new UserVerificationMap());
			#endregion

			#region Base
			modelBuilder.Configurations.Add(new CityMap());
			modelBuilder.Configurations.Add(new ProvinceMap());
			modelBuilder.Configurations.Add(new CountryMap());
			#endregion

			#region Blobs
			modelBuilder.Configurations.Add(new BlobDescriptionMap());
			modelBuilder.Configurations.Add(new BlobMap());
			#endregion

			#region Brands
			modelBuilder.Configurations.Add(new BrandMap());
			#endregion

			#region Exceptions
			modelBuilder.Configurations.Add(new ExceptionCategotyMap());
			modelBuilder.Configurations.Add(new ExceptionMap());
			#endregion

			#region Messaging
			modelBuilder.Configurations.Add(new EmailMap());
			modelBuilder.Configurations.Add(new MessageMap());
			modelBuilder.Configurations.Add(new MessageTypeMap());
			modelBuilder.Configurations.Add(new SmsMap());
			#endregion

			#region Notifications
			modelBuilder.Configurations.Add(new NotificationMap());
			#endregion

			#region Pages
			modelBuilder.Configurations.Add(new PageMap());
			#endregion

			#region Products
			modelBuilder.Configurations.Add(new CommentMap());
			modelBuilder.Configurations.Add(new ProductCatalogMap());
			modelBuilder.Configurations.Add(new ProductCategoryMap());
			modelBuilder.Configurations.Add(new ProductImageMap());
			modelBuilder.Configurations.Add(new ProductMap());
			modelBuilder.Configurations.Add(new ProductRelatedMap());
			modelBuilder.Configurations.Add(new ProductTechinicalMap());
			modelBuilder.Configurations.Add(new TechnicalMap());
			modelBuilder.Configurations.Add(new ProductCategoryTechnicalMap());
			#endregion

			#region Shop
			modelBuilder.Configurations.Add(new CartItemMap());
			modelBuilder.Configurations.Add(new CartMap());
			modelBuilder.Configurations.Add(new CustomerMap());
			modelBuilder.Configurations.Add(new InvoiceDetailsMap());
			modelBuilder.Configurations.Add(new InvoiceMap());
			modelBuilder.Configurations.Add(new ProductInvoiceTypeMap());
			modelBuilder.Configurations.Add(new ProviderMap());
			modelBuilder.Configurations.Add(new PurchaseMap());
			modelBuilder.Configurations.Add(new PurchaseTypeMap());
			#endregion

			#region Slides
			modelBuilder.Configurations.Add(new SlideShowMap());
			#endregion

			#region Tags
			modelBuilder.Configurations.Add(new TagMap());
			modelBuilder.Configurations.Add(new TagTypeMap());
			#endregion

			#region Users
			modelBuilder.Configurations.Add(new MemberMap());
			modelBuilder.Configurations.Add(new MemberImportantDateMap());
			modelBuilder.Configurations.Add(new RoleMap());
			modelBuilder.Configurations.Add(new SessionMap());
			#endregion

			#region Visits
			modelBuilder.Configurations.Add(new PageUrlMap());
			modelBuilder.Configurations.Add(new VisitorMap());
			modelBuilder.Configurations.Add(new VisitorPageMap());
			#endregion

		}

		#region AuthEntities
		public DbSet<Permission> Permissions { get; set; }
		public DbSet<User> Users { get; set; }
		public DbSet<UserToken> UserTokens { get; set; }
		public DbSet<UserVerification> UserVerifications { get; set; }
		#endregion

		#region Base
		public DbSet<Province> Provinces { get; set; }
		public DbSet<City> Cities { get; set; }
		public DbSet<Country> Countries { get; set; }
		#endregion

		#region Blobs
		public DbSet<Blob> BlobMap { get; set; }
		public DbSet<BlobDescription> BlobDescriptionMap { get; set; }
		#endregion

		#region Brands
		public DbSet<Brand> Brands { get; set; }
		#endregion

		#region Exceptions
		public DbSet<Exception> Exceptions { get; set; }
		public DbSet<ExceptionCategory> ExceptionCategories { get; set; }
		#endregion

		#region Messaging
		public DbSet<Message> MessageMap { get; set; }
		public DbSet<MessageType> MessageTypeMap { get; set; }
		public DbSet<Email> EmailMap { get; set; }
		#endregion

		#region Notifications
		public DbSet<Notification> Notifications { get; set; }
		#endregion

		#region Products
		public DbSet<Comment> Comments { get; set; }
		public DbSet<Product> Products { get; set; }
		public DbSet<Technical> Technicals { get; set; }
		public DbSet<ProductCategoryTechnical> ProductCategoryTechnicals { get; set; }
		public DbSet<ProductCatalog> ProductCatalogs { get; set; }
		public DbSet<ProductCategory> ProductCategories { get; set; }
		public DbSet<ProductImage> ProductImages { get; set; }
		public DbSet<ProductRelated> ProductRelatedes { get; set; }
		public DbSet<ProductTechnical> ProductTechnicals { get; set; }
		#endregion

		#region Shop
		public DbSet<Cart> Carts { get; set; }
		//public DbSet<CartItem> CartItems { get; set; }
		public DbSet<Customer> Customers { get; set; }
		public DbSet<Invoice> Invoices { get; set; }
		public DbSet<InvoiceDetails> InvoiceDetailses { get; set; }
		public DbSet<ProductInvoiceType> ProductInvoiceTypes { get; set; }
		public DbSet<Provider> Providers { get; set; }
		public DbSet<Purchase> Purchases { get; set; }
		public DbSet<PurchaseType> PurchaseTypes { get; set; }
		#endregion

		#region Slides
		public DbSet<SlideShow> SlideShows { get; set; }
		#endregion

		#region Tags
		public DbSet<Tag> Tags { get; set; }
		public DbSet<TagType> TagTypes { get; set; }
		#endregion

		#region Users
		public DbSet<Member> Members { get; set; }
		public DbSet<MemberImportantDate> MemberImportantDates { get; set; }
		public DbSet<Role> Roles { get; set; }
		public DbSet<Session> Sessions { get; set; }
		public DbSet<Supplier> Supplieres { get; set; }
		#endregion

		#region Visits
		public DbSet<Page> Pages { get; set; }
		public DbSet<PageUrl> PageUrls { get; set; }
		public DbSet<Visitor> Visitors { get; set; }
		public DbSet<VisitorPage> VisitorPages { get; set; }
		#endregion
	}
}
