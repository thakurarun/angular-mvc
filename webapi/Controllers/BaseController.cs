using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using CachingLayer;
namespace webapi.Controllers
{
    [EnableCors(origins: "http://demo.eu", headers: "*", methods: "*")]
    public abstract class BaseController : ApiController
    {
        protected void AddVerificationTokenToModel(HttpRequestMessage Request,ref WebModel.BaseModel model)
        {
            if (Request.Method == HttpMethod.Post)
            {
                var s = Request.Headers.FirstOrDefault(x => x.Key == "_vt");
                if (!string.IsNullOrEmpty(s.Key))
                {
                    var token = s.Value.FirstOrDefault();
                    model._vt = token;
                }
            }
        }
        public virtual IHttpActionResult Get()
        {
            return Json(new { Result = "API IS UP AND WORKING GREAT!!!" });
        }
    }
}
