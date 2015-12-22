using DependencyInjection.Services;
using System.Web.Http;
using webapi.CustomFilter;
using WebModel;
using WebModel.Account;
namespace webapi.Controllers
{
    [CustomAuthorizeFilter]
    public class AccountController : BaseController
    {
        Abstraction.Services.IAccountService _accountService;

        public AccountController()
        {
            _accountService = IocContainer.GetServiceType<Abstraction.Services.IAccountService>();
        }
        [HttpPost]
        public IHttpActionResult AddAccount([FromBody]AccountModel model)
        {
            WebModel.BaseModel _model = model;
            AddVerificationTokenToModel(Request, ref _model);
            var result = _accountService.RegisterNewAccount(model);

            return Json(new
            {
                IsSuccess = result.IsSuccess,
                Message = result.IsSuccess == false ? result.ErrorMessage : result.Message,

            });
        }
        [HttpPost]
        public IHttpActionResult GetAccounts([FromBody]AccountModel model)
        {
            FilterOptions filter = new FilterOptions();
            if (model == null)
                model = new AccountModel();
            WebModel.BaseModel _model = model;
            AddVerificationTokenToModel(Request, ref _model);
            var result = _accountService.GetAllRegisterdAccounts(model, filter);
            return Json(new
            {
                IsSuccess = result.IsSuccess,
                Message = result.IsSuccess == false ? result.ErrorMessage : result.Message,
                Data = result.ResultObject
            });
        }
    }
}
