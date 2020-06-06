using StackExchange.Redis;

namespace Rosentis.Api.JsonWebTokenConfig
{
    public static class ConnectionRedis
    {
       

        public static ConnectionMultiplexer RedisConnect
        {
           get { return ConnectionMultiplexer.Connect("150.150.100.47");}
        }

        public static IDatabase DataBase
        {
            get { return RedisConnect.GetDatabase(); }
        }


    }
}