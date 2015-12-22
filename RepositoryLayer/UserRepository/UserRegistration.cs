using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using db = DataLayer.Database;
using web = WebModel.User;
using AutoMapper;
using WebModel;

namespace RepositoryLayer.UserRepository
{
    public class UserRegistration : BaseRepository
    {
        public ResultSet RegisterUser(web.UserModel model)
        {
            var dbUser = Mapper.Map<web.UserModel, db.User>(model);
            dbUser.CreationDate = DateTime.UtcNow;
            dbUser.ModifiedDate = DateTime.UtcNow;
            dbUser.IsActive = true;
            var dbResultSet = base.InsertEntity<db.User>(dbUser);
            return Mapper.Map<DataLayer.ResultSet, WebModel.ResultSet>(dbResultSet);
        }
        public ResultSet LoginUser(web.UserModel model)
        {
            var dbUser = Mapper.Map<web.UserModel, db.User>(model);
            var Result = base.DbContext.Users.FirstOrDefault(x =>
                                                x.IsActive == true &&
                                                x.Username == dbUser.Username &&
                                                x.Password == dbUser.Password
                                                );
            if (Result == null)
            {
                base.ResultSet.IsSuccess = false;
                base.ResultSet.ErrorMessage = "User not found";
                return Mapper.Map<DataLayer.ResultSet, WebModel.ResultSet>(base.ResultSet);
            }
            //need to create service token here....
            base.ResultSet.IsSuccess = true;
            base.ResultSet.ResultObject = new KeyValuePair<string, long>(Result.Email, Result.Id);
            return Mapper.Map<DataLayer.ResultSet, WebModel.ResultSet>(base.ResultSet);
        }
    }
}
