using Rosentis.ServiceContract.Products;

namespace Rosentis.ServiceImplementation.Products.Registry
{
	public class PoductCatalogRegistry : StructureMap.Registry
	{

		public PoductCatalogRegistry()
		{
			this.For<IProductCatalogService>().Use<ProductCatalogApplicationService>();

		}
	}
}
