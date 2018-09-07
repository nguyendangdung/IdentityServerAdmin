using App.Cache;

namespace App
{
    class ProductionEfRedisCacheSettings : IEFRedisCacheSettings
    {
        public bool UseRedisCache { get; }
        public string RedisConnectionString { get; }

        public ProductionEfRedisCacheSettings()
        {
            UseRedisCache = ConfigurationFacade.UseRedisCache;
            RedisConnectionString = ConfigurationFacade.ProductionRedisConnectionString;
        }
    }
}