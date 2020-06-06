using Rosentis.ServiceContract.Products;

namespace Rosentis.ServiceImplementation.Products.Registry
{
	public class ProductCategoryTechnicalRegistry : StructureMap.Registry
	{

		public ProductCategoryTechnicalRegistry()
		{
			this.For<IProductCategoryTechnicalService>().Use<ProductCategoryTechnicalApplicationService>();

		}
	}
}
