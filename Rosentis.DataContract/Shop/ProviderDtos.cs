using Rosentis.DataContract.Base;
using System.Collections.Generic;
namespace Rosentis.DataContract.Shop
{
    public class ProviderDtos: BaseDto
    {
        public List<ProviderDto> Providers { get; set; }

        public ProviderDtos()
        {
            Providers = new List<ProviderDto>();
        }
    }
}
