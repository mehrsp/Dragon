using Rosentis.ServiceContract.Products;

namespace Rosentis.ServiceImplementation.Products.Registry
{
	public class PoductImageRegistry : StructureMap.Registry
	{

		public PoductImageRegistry()
		{
			this.For<IProductImageService>().Use<ProductImageApplicationService>();

		}
	}
}
