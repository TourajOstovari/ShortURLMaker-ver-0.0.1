

namespace Portal.Services.Cache
{
    using Microsoft.Extensions.Caching.Memory;
    using System;
    public class MemoryCaching
    {
        #region MemoryCache
        private static MemoryCache cache = new MemoryCache(new MemoryCacheOptions());
        private static MemoryCache Recache = new MemoryCache(new MemoryCacheOptions());
        #endregion

        public static object GET(string URL) => cache.Get(URL);
        public static object GET_ShortURL(string URL) => Recache.Get(URL);
        public static bool SET(Portal.Domain.Entities.URL.URLInfo info)
        {
            if (GET(info.MainUrl_) == null)
            {
                cache.Set(info.MainUrl_, info.ShortUrl_);
                Recache.Set(info.ShortUrl_, info.MainUrl_);
                return true;
            }
            return false;
        }

    }
}
