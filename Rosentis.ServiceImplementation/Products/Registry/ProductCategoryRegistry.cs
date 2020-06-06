using Rosentis.ServiceContract.Products;

namespace Rosentis.ServiceImplementation.Products.Registry
{
	public class PoductCategoryRegistry : StructureMap.Registry
	{

		public PoductCategoryRegistry()
		{
			this.For<IProductCategoryService>().Use<ProductCategoryApplicationService>();

		}
	}
}
