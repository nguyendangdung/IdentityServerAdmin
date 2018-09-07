namespace App.Cache
{
    public interface IEFRedisCacheSettings
    {
        bool UseRedisCache { get; }
        string RedisConnectionString { get; }

    }
}
