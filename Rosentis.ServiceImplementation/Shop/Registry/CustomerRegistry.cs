using Rosentis.DataContract.Shop;
using Rosentis.DistributedServices;
using Rosentis.DomainModel.Shop;
using Rosentis.ServiceContract.Shop;
using Rosentis.ServiceImplementation.Shop.Mapper;

namespace Rosentis.ServiceImplementation.Shop.Registry
{
    public class CustomerRegistry : StructureMap.Registry
    {
        public CustomerRegistry()
        {
            //this.For<ICustomerService>().Use<CustomerService>();
            this.For<IEntityMapper<Customer, CustomerDto>>().Use<CustomerMapper>();
            //this.For<ICustomerRepository>().Use<CustomerRepository>();
            this.For<ICustomerApplicationService>().Use<CustomerApplicationService>();

        }
    }
}