using Rosentis.Common;
using Rosentis.DataContract.Base;

namespace Rosentis.DataContract.AuthEntities
{
    public class ClientDto: BaseDto
    {
		public string Secret {get; set;}
		public string Name {get; set;}
		public ApplicationTypes ApplicationType {get; set;}
		public bool Active {get; set;}
		public int RefreshTokenLifeTime {get; set;}
		public string AllowedOrigin {get; set;}
		public string Id {get; set;}

    }
}
