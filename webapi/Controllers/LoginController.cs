using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebModel.User;
using DependencyInjection.Services;
using System.Net.Http.Headers;

namespace webapi.Controllers
{
    public class LoginController : BaseController
    {
        Abstraction.Services.IUserService _userService;
        public LoginController()
        {
            _userService = IocContainer.GetServiceType<Abstraction.Services.IUserService>();
        }
        // POST: api/login
        public IHttpActionResult Post([FromBody]UserModel model)
        {
            var result = _userService.LoginUser(model);
            //_vt is verification token here...will be used once only...and should be add in response header...
           
            return Json(new
            {
                IsSuccess = result.IsSuccess,
                Message = result.IsSuccess == false ? result.ErrorMessage : result.Message,
                _vt = result.IsSuccess == false ? string.Empty : result._vt
            });

        }
    }
}
