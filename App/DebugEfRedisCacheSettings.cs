using App.Cache;

namespace App
{
    class DebugEfRedisCacheSettings : IEFRedisCacheSettings
    {


        public bool UseRedisCache { get; }
        public string RedisConnectionString { get; }

        public DebugEfRedisCacheSettings()
        {
            UseRedisCache = ConfigurationFacade.UseRedisCache;
            RedisConnectionString = ConfigurationFacade.RedisConnectionString;
        }
    }
}