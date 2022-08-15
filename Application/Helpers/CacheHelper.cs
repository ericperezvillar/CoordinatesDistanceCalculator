using Application.Interfaces;
using Microsoft.Extensions.Caching.Memory;
using System;

namespace Application.Helpers
{
    public class CacheHelper : ICacheHelper
    {
        private readonly IMemoryCache _memoryCache;

        public CacheHelper(IMemoryCache memoryCache)
        {
            _memoryCache = memoryCache;
        }

        public void Add(object value, string key, DateTimeOffset absExpiration)
        {
            _memoryCache.Set(key, value, absExpiration);
        }

        public TItem Get<TItem>(string key) where TItem : class
        {
            return _memoryCache.Get(key) as TItem;
        }
    }
}
