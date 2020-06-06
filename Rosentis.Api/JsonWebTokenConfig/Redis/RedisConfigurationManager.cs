using System.Configuration;

namespace Rosentis.Api.JsonWebTokenConfig.Redis
{
    public class RedisConfigurationManager
    {
        #region Constants

        private const string SectionName = "RedisConfiguration";

        public static RedisConfigurationSection Config
        {
            get
            {
                return (RedisConfigurationSection)ConfigurationManager.GetSection(SectionName);
            }
        }

        #endregion
    }
}