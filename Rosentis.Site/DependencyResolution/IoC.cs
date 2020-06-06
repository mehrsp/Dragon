// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IoC.cs" company="Web Advanced">
// Copyright 2012 Web Advanced (www.webadvanced.com)
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//
// http://www.apache.org/licenses/LICENSE-2.0

// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------



namespace Rosentis.Site.DependencyResolution
{
	using Rosentis.ServiceContract.AuthEntities;
	using Rosentis.ServiceImplementation.AuthEntities.Registry;
	using Rosentis.ServiceImplementation.Base.Registry;
	using Rosentis.ServiceImplementation.Brands.Registry;
	using Rosentis.ServiceImplementation.Messaging.Registry;
	using Rosentis.ServiceImplementation.Products.Registry;
	using Rosentis.ServiceImplementation.Shop.Registry;
	using Rosentis.ServiceImplementation.SlideShow.Registry;
	using Rosentis.ServiceImplementation.Suppliers.Registry;
	using Rosentis.ServiceImplementation.Users.Registry;
	using StructureMap;
	using System;

	public static class IoC {
        public static IContainer Initialize() {
            return new Container(
				ioc =>
				{
					//ioc.Forward<IDataContext, IUnitOfWork>();
					//ioc.For<IDataContext>().Use<LotusContext>();

					ioc.Policies.SetAllProperties(setterConvention =>
					{
						// For WebAPI ActionFilter Dependency Injection
						setterConvention.OfType<Func<IUsersApplicationService>>();
						setterConvention.OfType<Func<ITokenStoreApplicationService>>();
					});

					ioc.AddRegistry<DefaultRegistry>();
					//ioc.AddRegistry<TagRegistry>();
					ioc.AddRegistry<UsersRegistry>();
					ioc.AddRegistry<SupplierRegistry>();
					ioc.AddRegistry<ProvinceRegistry>();
					ioc.AddRegistry<CityRegistry>();
					ioc.AddRegistry<CountryRegistry>();
					//ioc.AddRegistry<PageRegistry>();
					ioc.AddRegistry<PoductCategoryRegistry>();
					ioc.AddRegistry<ProductRegistry>();
					ioc.AddRegistry<AuthEntityRegistry>();
					ioc.AddRegistry<ProductCategoryTechnicalRegistry>();
					ioc.AddRegistry<TechnicalRegistry>();
					ioc.AddRegistry<BrandRegistry>();
					ioc.AddRegistry<PoductImageRegistry>();
					ioc.AddRegistry<PoductTechnicalRegistry>();
					ioc.AddRegistry<SlideShowRegistry>();
					ioc.AddRegistry<CartRegistry>();
					ioc.AddRegistry<CartItemRegistry>();
					ioc.AddRegistry<CustomerRegistry>();
					ioc.AddRegistry<InvoiceRegistry>();
					ioc.AddRegistry<InvoiceDetailsRegistry>();
					ioc.AddRegistry<ProviderRegistry>();
					ioc.AddRegistry<PurchaseRegistry>();
					ioc.AddRegistry<PurchaseTypeRegistry>();
					ioc.AddRegistry<MemberRegistry>();
					ioc.AddRegistry<SmsRegistry>();
					ioc.AddRegistry<EmailRegistry>();
					//ioc.AddRegistry<NotificationRegistry>();
					ioc.AddRegistry<MemberImportantDateRegistry>();
					// we only need one instance of this provider
				}); 
        }
    }
}