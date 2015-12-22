using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebModel.User;
using WebModel;
namespace Abstraction.Services
{
    public interface IUserService
    {
        WebModel.ResultSet RegisterUser(UserModel model);
        WebModel.ResultSet LoginUser(UserModel model);
    }
}
