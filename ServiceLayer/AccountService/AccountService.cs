using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abstraction.Services;
using RepositoryLayer.AccountRepository;
using WebModel;
using WebModel.Account;

namespace ServiceLayer.AccountService
{
    public class AccountService : BaseService, IAccountService
    {
        private AccountRegistration _AccountRepo;
        AccountRegistration AccountRepo
        {
            get { return _AccountRepo ?? (_AccountRepo = new AccountRegistration()); }
        }
        public ResultSet GetAllRegisterdAccounts(AccountModel model, FilterOptions filter)
        {
            model.UserId = GetUserId(model._vt);
            var resultSet = AccountRepo.GetAllRegisterdAccounts(model.UserId, filter);
            return resultSet;
        }

        public ResultSet RegisterNewAccount(AccountModel model)
        {
            model.UserId = GetUserId(model._vt);
            var result = AccountRepo.RegisterNewAccount(model);
            if (result.IsSuccess == false)
            {
                //log inner exception
                result.ErrorMessage = "Account already exist with same name";
            }
            return result;
        }
    }
}
