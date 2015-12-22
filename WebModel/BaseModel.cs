using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebModel
{
    public abstract class BaseModel
    {
        public long UserId { get; set; }
        public string _vt { get; set; }
    }
}
