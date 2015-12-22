using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebModel
{
    public class FilterOptions
    {
        public int PageSize { get; set; }
        public int PageNumber { get; set; }
        public int Total { get; set; }
        public Dictionary<string, string> Filters { get; set; }
        public static Dictionary<string, string> GetOptions(string queryString)
        {
            return new Dictionary<string, string>();
        }
    }
}
