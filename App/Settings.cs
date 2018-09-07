using App.Cache;

namespace App
{
    class ProductionEFRedisCacheSettings : IEFRedisCacheSettings
    {
        public bool UseRedisCache { get; }
        public string RedisConnectionString { get; }

        public ProductionEFRedisCacheSettings()
        {
            UseRedisCache = ConfigurationFacade.UseRedisCache;
            RedisConnectionString = ConfigurationFacade.ProductionRedisConnectionString;
        }
    }

    class StagingEFRedisCacheSettings : IEFRedisCacheSettings
    {
        public bool UseRedisCache { get; }
        public string RedisConnectionString { get; }

        public StagingEFRedisCacheSettings()
        {
            UseRedisCache = ConfigurationFacade.UseRedisCache;
            RedisConnectionString = ConfigurationFacade.StagingRedisConnectionString;
        }
    }

    class DebugEFRedisCacheSettings : IEFRedisCacheSettings
    {


        public bool UseRedisCache { get; }
        public string RedisConnectionString { get; }

        public DebugEFRedisCacheSettings()
        {
            UseRedisCache = ConfigurationFacade.UseRedisCache;
            RedisConnectionString = ConfigurationFacade.RedisConnectionString;
        }
    }
}