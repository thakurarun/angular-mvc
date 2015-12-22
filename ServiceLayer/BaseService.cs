using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CachingLayer;
using CommonLibrary;
namespace ServiceLayer
{
    public abstract class BaseService
    {
        protected ICacheService cacheService = new CacheService();
        protected long GetUserId(string key)
        {
            return cacheService.Find<long>(key);
        }
    }
}
