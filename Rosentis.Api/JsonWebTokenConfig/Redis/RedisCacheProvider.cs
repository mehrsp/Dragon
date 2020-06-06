using ServiceStack.Redis;

namespace Rosentis.Api.JsonWebTokenConfig.Redis
{
    public class RedisCacheProvider : ICacheProvider
    {
       static RedisEndpoint _endPoint;

        public RedisCacheProvider()
        {
            if (_endPoint == null)
            {
                _endPoint = new RedisEndpoint(RedisConfigurationManager.Config.Host, RedisConfigurationManager.Config.Port, RedisConfigurationManager.Config.Password, RedisConfigurationManager.Config.DatabaseID);
            }
        }
        public void Set<T>(string key, T value)
        {
            using (RedisClient client = new RedisClient(_endPoint))
            {
                client.As<T>().SetValue(key, value);
            }
        }


        public T Get<T>(string key)
        {
            T result = default(T);

            using (RedisClient client = new RedisClient(_endPoint))
            {
                var wrapper = client.As<T>();

                result = wrapper.GetValue(key);
            }

            return result;
        }

        public bool Remove(string key)
        {
            bool removed = false;

            using (RedisClient client = new RedisClient(_endPoint))
            {
                removed = client.Remove(key);
            }

            return removed;
        }

        public bool IsInCache(string key)
        {
            bool isInCache = false;

            using (RedisClient client = new RedisClient(_endPoint))
            {
                isInCache = client.ContainsKey(key);
            }

            return isInCache;
        }
    }
}