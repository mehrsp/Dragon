using Rosentis.ServiceImplementation;
using WebActivatorEx;

[assembly: PreApplicationStartMethod(typeof(Startup), "Start")]

namespace Rosentis.ServiceImplementation
{
	public class Startup
	{
		public static void Start()
		{
			AutoMapperConfig.RegisterMappings();
		}
	}
}