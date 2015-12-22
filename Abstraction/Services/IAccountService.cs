using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebModel.Account;
using WebModel;
namespace Abstraction.Services
{
    public interface IAccountService
    {
        WebModel.ResultSet RegisterNewAccount(AccountModel model);
        WebModel.ResultSet GetAllRegisterdAccounts(AccountModel model, FilterOptions filter);
    }
}
