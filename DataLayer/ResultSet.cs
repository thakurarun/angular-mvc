using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public class ResultSet 
    {
        public bool IsSuccess { get; set; }
        public string ErrorMessage { get; set; }
        public string Message { get; set; }
        public bool Status { get; set; }
        public object ResultObject { get; set; }
    }
}
