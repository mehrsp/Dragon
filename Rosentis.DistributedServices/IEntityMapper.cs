namespace Rosentis.DistributedServices
{
	public interface IEntityMapper<TSource, TDestination>
	{
		TDestination MapTo(TSource source);
		TSource CreateFrom(TDestination destination);
	}
}
