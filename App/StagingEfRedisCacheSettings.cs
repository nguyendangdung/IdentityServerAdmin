using App.Cache;

namespace App
{
    class StagingEfRedisCacheSettings : IEFRedisCacheSettings
    {
        public bool UseRedisCache { get; }
        public string RedisConnectionString { get; }

        public StagingEfRedisCacheSettings()
        {
            UseRedisCache = ConfigurationFacade.UseRedisCache;
            RedisConnectionString = ConfigurationFacade.StagingRedisConnectionString;
        }
    }
}