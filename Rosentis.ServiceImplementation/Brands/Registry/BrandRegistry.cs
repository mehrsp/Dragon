using Rosentis.ServiceContract.Brands;
using Rosentis.ServiceContract.Info.Address;
using Rosentis.ServiceImplementation.Base;
using Rosentis.ServiceImplementation.Products;

namespace Rosentis.ServiceImplementation.Brands.Registry
{
	public class BrandRegistry : StructureMap.Registry
	{
		public BrandRegistry()
		{
			this.For<IBrandService>().Use<BrandApplicationService>();
		}
	}
}
