using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using db = DataLayer.Database;
using web = WebModel.Account;
using AutoMapper;
using WebModel;
namespace RepositoryLayer.AccountRepository
{
    public class AccountRegistration : BaseRepository
    {
        public ResultSet RegisterNewAccount(web.AccountModel model)
        {
            var dbAccount = Mapper.Map<web.AccountModel, db.Account>(model);
            dbAccount.CreationDate = DateTime.UtcNow;
            dbAccount.ModifiedDate = DateTime.UtcNow;
            dbAccount.IsActive = true;
            var result = base.DbContext.Accounts.FirstOrDefault(c => c.UserId == model.UserId && c.AccountName.ToLower() == model.AccountName.ToLower());
            if (result != null)
            {
                base.ResultSet.IsSuccess = false;
                base.ResultSet.ErrorMessage = "Account already exist with same name.";
                return Mapper.Map<DataLayer.ResultSet, WebModel.ResultSet>(base.ResultSet);

            }
            var dbResultSet = base.InsertEntity<db.Account>(dbAccount);
            return Mapper.Map<DataLayer.ResultSet, WebModel.ResultSet>(dbResultSet);
        }

        public ResultSet GetAllRegisterdAccounts(long UserId, FilterOptions filter)
        {
            base.ResultSet.IsSuccess = true;
            var data = base.DbContext.
                Accounts.Where(x => x.UserId == UserId && x.IsActive == true).ToList();

            base.ResultSet.ResultObject = data.Select(x => new web.AccountModel
            {
                AccountName = x.AccountName, IsActive = x.IsActive, Username = x.ShowUsername.GetValueOrDefault() ? x.Username : string.Empty
            }).ToList();
            return Mapper.Map<DataLayer.ResultSet, WebModel.ResultSet>(base.ResultSet);
        }
        
    }
}
