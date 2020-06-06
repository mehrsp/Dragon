using Rosentis.DataContract.Slides;
using Rosentis.DistributedServices;
using Rosentis.ServiceContract.Slides;
using Rosentis.ServiceImplementation.Slides.Mapper;
using Rosentis.DomainModel.Slides;
using Rosentis.ServiceContract.Suppliers;
using Rosentis.ServiceImplementation.Products;

namespace Rosentis.ServiceImplementation.Suppliers.Registry
{
		public class SupplierRegistry : StructureMap.Registry
		{
	
			public SupplierRegistry()
			{
				this.For<ISupplierService>().Use<SupplierApplicationService>();
				//this.For<IEntityMapper<Rosentis.DomainModel.Slides.Supplier, SupplierDto>>().Use<SupplierMapper>();

			}
		}
}
