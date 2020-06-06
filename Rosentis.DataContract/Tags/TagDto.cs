using Rosentis.DataContract.Base;

namespace Rosentis.DataContract.Tags
{
	public class TagDto: BaseDto
	{
		public long Id { get; set; }
		public string Name { get; set; }
		public int TypeId { get; set; }
	}
}
