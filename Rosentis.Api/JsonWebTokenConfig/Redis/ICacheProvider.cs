namespace Rosentis.Api.JsonWebTokenConfig.Redis
{
    public interface ICacheProvider
    {
        void Set<T>(string key, T value);

      

        T Get<T>(string key);

        bool Remove(string key);

        bool IsInCache(string key);
    }
}
