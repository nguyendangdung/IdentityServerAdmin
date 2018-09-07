using System;
using System.Collections.ObjectModel;
using System.Data.Entity.Core.Metadata.Edm;
using EFCache;

namespace App.Cache
{
    public class RedisCachingPolicy : CachingPolicy
    {
        protected override void GetExpirationTimeout(ReadOnlyCollection<EntitySetBase> affectedEntitySets, out TimeSpan slidingExpiration, out DateTimeOffset absoluteExpiration)
        {
            slidingExpiration = TimeSpan.MaxValue;
            absoluteExpiration = DateTimeOffset.MaxValue;
            //slidingExpiration = TimeSpan.FromMinutes(5);
            //absoluteExpiration = DateTimeOffset.Now.AddMinutes(30);
        }
    }
}
