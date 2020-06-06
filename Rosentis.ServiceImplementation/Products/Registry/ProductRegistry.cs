using Rosentis.ServiceContract.Products;

namespace Rosentis.ServiceImplementation.Products.Registry
{
	public class ProductRegistry : StructureMap.Registry
	{

		public ProductRegistry()
		{
			this.For<IProductService>().Use<ProductApplicationService>();
		}
	}
}
