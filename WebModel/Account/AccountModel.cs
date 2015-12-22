using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebModel.Account
{
    public class AccountModel : BaseModel
    {
        public long Id { get; set; }
        public string AccountName { get; set; }
        public string Username { get; set; }
        public string PasswordHint { get; set; }
        public string Password { get; set; }
        public Nullable<bool> ShowUsername { get; set; }
        public string PrivateKey { get; set; }
        public Nullable<bool> UsePrivateKey { get; set; }
        public Nullable<bool> IsActive { get; set; }
    }
}
