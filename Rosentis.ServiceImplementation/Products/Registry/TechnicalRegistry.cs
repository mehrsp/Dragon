using Rosentis.ServiceContract.Products;
using Rosentis.ServiceImplementation.Products;

namespace Rosentis.ServiceImplementation.Brands.Registry
{
	public class TechnicalRegistry : StructureMap.Registry
	{
		public TechnicalRegistry()
		{
			this.For<ITechnicalService>().Use<TechnicalApplicationService>();
		}
	}
}
