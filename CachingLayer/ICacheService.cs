using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CachingLayer
{
    public interface ICacheService
    {
        bool Add<T>(string key,T data);
        bool Delete(string key);
        T Find<T>(string key);
    }
}
