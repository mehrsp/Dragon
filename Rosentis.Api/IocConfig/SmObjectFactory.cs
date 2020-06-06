using System;
using StructureMap;
using System.Threading;
using Microsoft.Owin.Security.Infrastructure;
using Microsoft.Owin.Security.OAuth;
using Rosentis.Api.JsonWebTokenConfig;
using Rosentis.ServiceContract.Info.Address;
using Rosentis.ServiceContract.Products;
using Rosentis.ServiceImplementation.Products;
using Rosentis.ServiceContract.Brands;
using Rosentis.ServiceContract.Suppliers;
using Rosentis.ServiceContract.Messaging;
using Rosentis.ServiceContract.Slides;
using Rosentis.ServiceImplementation.SlideShow;
using Rosentis.ServiceContract.AuthEntities;
using Rosentis.ServiceContract.Users;
using Rosentis.ServiceImplementation.AuthEntities.Registry;
using Rosentis.ServiceImplementation.Products.Registry;
using Rosentis.ServiceImplementation.Users.Registry;
using Rosentis.ServiceImplementation.Messaging.Registry;
using Rosentis.ServiceImplementation.Shop.Registry;
using Rosentis.ServiceImplementation.SlideShow.Registry;
using Rosentis.ServiceImplementation.Base.Registry;
using Rosentis.ServiceImplementation.Suppliers.Registry;
using Rosentis.ServiceImplementation.Brands.Registry;

namespace Rosentis.Api.IoCConfig
{
	public static class SmObjectFactory
	{
		private static readonly Lazy<Container> _containerBuilder =
			new Lazy<Container>(defaultContainer, LazyThreadSafetyMode.ExecutionAndPublication);

		public static IContainer Container { get; } = _containerBuilder.Value;

		private static Container defaultContainer()
		{
			return new Container(ioc =>
			{
				ioc.For<IAppJwtConfiguration>().Singleton().Use(() => AppJwtConfiguration.Config);

				ioc.Policies.SetAllProperties(setterConvention =>
				{
					// For WebAPI ActionFilter Dependency Injection
					setterConvention.OfType<Func<IUsersApplicationService>>();
					setterConvention.OfType<Func<ITokenStoreApplicationService>>();
					setterConvention.OfType<Func<IRoleApplicationService>>();
				});

				// we only need one instance of this provider
				ioc.For<IOAuthAuthorizationServerProvider>().Singleton().Use<AppOAuthProvider>();
				ioc.For<IAuthenticationTokenProvider>().Singleton().Use<RefreshTokenProvider>();
				ioc.Configure(configuration => configuration.ImportRegistry((new AuthEntityRegistry())));
				//ioc.Configure(configuration => configuration.ImportRegistry((new TagRegistry())));
				ioc.Configure(configuration => configuration.ImportRegistry((new UsersRegistry())));
				ioc.Configure(configuration => configuration.ImportRegistry((new SupplierRegistry())));
				ioc.Configure(configuration => configuration.ImportRegistry(new ProvinceRegistry()));
				ioc.Configure(configuration => configuration.ImportRegistry(new CountryRegistry()));
				ioc.Configure(configuration => configuration.ImportRegistry(new CityRegistry()));
				//ioc.Configure(configuration => configuration.ImportRegistry(new PageRegistry()));
				ioc.Configure(configuration => configuration.ImportRegistry(new PoductCategoryRegistry()));
				ioc.Configure(configuration => configuration.ImportRegistry(new ProductRegistry()));
				ioc.Configure(configuration => configuration.ImportRegistry(new ProductRegistry()));
				ioc.Configure(configuration => configuration.ImportRegistry(new PoductCatalogRegistry()));
				ioc.Configure(configuration => configuration.ImportRegistry(new ProductCategoryTechnicalRegistry()));
				ioc.Configure(configuration => configuration.ImportRegistry(new TechnicalRegistry()));
				ioc.Configure(configuration => configuration.ImportRegistry(new BrandRegistry()));
				ioc.Configure(configuration => configuration.ImportRegistry(new PoductImageRegistry()));
				ioc.Configure(configuration => configuration.ImportRegistry(new PoductTechnicalRegistry()));
				ioc.Configure(configuration => configuration.ImportRegistry(new SlideShowRegistry()));
				ioc.Configure(configuration => configuration.ImportRegistry(new CartRegistry()));
				ioc.Configure(configuration => configuration.ImportRegistry(new CartItemRegistry()));
				ioc.Configure(configuration => configuration.ImportRegistry(new CustomerRegistry()));
				ioc.Configure(configuration => configuration.ImportRegistry(new InvoiceRegistry()));
				ioc.Configure(configuration => configuration.ImportRegistry(new InvoiceDetailsRegistry()));
				ioc.Configure(configuration => configuration.ImportRegistry(new ProviderRegistry()));
				ioc.Configure(configuration => configuration.ImportRegistry(new PurchaseRegistry()));
				ioc.Configure(configuration => configuration.ImportRegistry(new PurchaseTypeRegistry()));
				ioc.Configure(configuration => configuration.ImportRegistry(new MemberRegistry()));
				ioc.Configure(configuration => configuration.ImportRegistry(new SmsRegistry()));
				ioc.Configure(configuration => configuration.ImportRegistry(new EmailRegistry()));
				//ioc.Configure(configuration => configuration.ImportRegistry(new NotificationRegistry()));
				ioc.Configure(configuration => configuration.ImportRegistry(new MemberImportantDateRegistry()));

			});
		}
	}
}