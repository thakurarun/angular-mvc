using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abstraction.Services;
using RepositoryLayer.UserRepository;
using WebModel;
using WebModel.User;
using CommonLibrary;
namespace ServiceLayer.UserService
{
    public class UserService : BaseService, IUserService
    {
        private UserRegistration _UserRepo;
        UserRegistration UserRepo
        {
            get { return _UserRepo ?? (_UserRepo = new UserRegistration()); }
        }

        public ResultSet RegisterUser(UserModel model)
        {
            var result = UserRepo.RegisterUser(model);
            if (result.IsSuccess == false)
            {
                //log inner exception
                result.ErrorMessage = "User already exist";
            }
            return result;
        }

        public WebModel.ResultSet LoginUser(UserModel model)
        {
            var result = UserRepo.LoginUser(model);
            if (result.IsSuccess == false)
            {
                //log inner exception
                result.ErrorMessage = "Username/Password not correct";
                return result;
            }
            //we need to generate token here..
            var idEmailKeyValuePair = (KeyValuePair<string, long>)result.ResultObject;
            var emailEncrypted = SecurityApiToken.Instance.EncryptToString(idEmailKeyValuePair.Key.ToString());
            var id = idEmailKeyValuePair.Value;
            cacheService.Add(emailEncrypted, id);
            result._vt = emailEncrypted;
            return result;
        }
    }
}
