using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebModel.User;
using DependencyInjection.Services;
namespace webapi.Controllers
{
    public class RegisterController : BaseController
    {
        Abstraction.Services.IUserService _userService;
        public RegisterController()
        {
            _userService = IocContainer.GetServiceType<Abstraction.Services.IUserService>();
        }

        // POST: api/Register
        public IHttpActionResult Post([FromBody]UserModel model)
        {
            var result = _userService.RegisterUser(model);
            return Json(new
            {
                IsSuccess = result.IsSuccess,
                Message = result.IsSuccess == false ? result.ErrorMessage : result.Message
            });
        }
    }
}
