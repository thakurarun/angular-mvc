using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CachingLayer
{
    public class CacheService : ICacheService
    {
        private static Dictionary<string, object> cacheObject = new Dictionary<string, object>();

        public bool Add<T>(string key, T data)
        {
            try
            {
                cacheObject.Add(key, data);
            }
            catch (Exception e)
            {
                return false;
            }
            return true;
        }

        public bool Delete(string key)
        {
            return cacheObject.Remove(key);
        }

        public T Find<T>(string key)
        {
            var result = cacheObject.FirstOrDefault(x => x.Key == key);
            if (string.IsNullOrEmpty(result.Key))
                return default(T);
            return (T)result.Value;
        }
    }
}
