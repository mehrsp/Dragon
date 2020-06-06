using Rosentis.ServiceContract.Products;

namespace Rosentis.ServiceImplementation.Products.Registry
{
	public class PoductTechnicalRegistry : StructureMap.Registry
	{

		public PoductTechnicalRegistry()
		{
			this.For<IProductTechnicalService>().Use<ProductTechnicalApplicationService>();

		}
	}
}
