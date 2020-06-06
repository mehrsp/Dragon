using Rosentis.DataContract.Base;
using Rosentis.DataContract.Info.Address;
using Rosentis.DistributedServices;
using Rosentis.DomainModel.Base;

namespace Rosentis.ServiceImplementation.Base.Mapper
{
    public class CountryMapper : IEntityMapper<Country, CountryDto>
    {
        public Country CreateFrom(CountryDto domainDto)
        {
			//if (domainDto == null)
			//    return new NullCountry();
			//return new Country(domainDto.Name,domainDto.Id);
			return null;
		}
		public  CountryDto MapTo(Country domain)
		{
			CountryDto domainDto = new CountryDto();
			if (domain != null)
			{
				domainDto.Summary = domain.Summary;
				domainDto.Title = domain.Title;
				domainDto.Id = domain.Id;
			}

			return domainDto;
		}

		public static CountryDto MapToDto(Country domain)
        {
            CountryDto domainDto = new CountryDto();
            if (domain != null)
            {
				domainDto.Summary = domain.Summary;
				domainDto.Title = domain.Title;
				domainDto.Id = domain.Id;
            }

            return domainDto;
        }
		public static DropBoxDto MapForDropBox(Country domain)
		{
			DropBoxDto domainDto = new DropBoxDto();
			if (domain != null)
			{
				domainDto.Text = domain.Title;
				domainDto.Id = domain.Id;
			}

			return domainDto;
		}
	}

}
