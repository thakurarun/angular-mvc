using CommonLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Http.Controllers;

namespace webapi.CustomFilter
{
    public class CustomAuthorizeFilter : AuthorizeAttribute
    {
        protected override bool IsAuthorized(HttpActionContext actionContext)
        {
            var s = actionContext.Request.Headers.FirstOrDefault(x => x.Key == "_vt");
            if(!string.IsNullOrEmpty(s.Key))
            {
                var token = s.Value.FirstOrDefault();
                if (!string.IsNullOrEmpty(token))
                {
                    return !string.IsNullOrEmpty(SecurityApiToken.Instance.ValidateToken(token));
                }
            }
            return false;
        }
       
    }
}