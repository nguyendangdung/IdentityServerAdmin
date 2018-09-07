using System;
using System.Data.Entity;
using System.Data.Entity.Core.Common;
using EFCache;
using EFCache.Redis;

namespace App.Cache
{
    public class Configuration : DbConfiguration
    {
        public static RedisCache Cache;

        public Configuration()
        {

        }

        public Configuration(IEFRedisCacheSettings efRedisCacheSettings)
        {
            bool useRedis = efRedisCacheSettings.UseRedisCache;
            var redisCon = efRedisCacheSettings.RedisConnectionString;
            if (useRedis && !string.IsNullOrWhiteSpace(redisCon))
            {
                try
                {
                    Cache = new RedisCache(redisCon);
                }
                catch (Exception)
                {
                    // eat 
                    // throw;
                }
            }



            if (!useRedis || Cache == null) return;

            var transactionHandler = new CacheTransactionHandler(Cache);
            AddInterceptor(transactionHandler);
            Loaded +=
                (sender, args) =>
                    args.ReplaceService<DbProviderServices>(
                        (s, _) => new CachingProviderServices(s, transactionHandler, new RedisCachingPolicy()));
        }
    }
}