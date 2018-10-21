using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UI.Controllers
{
    /// <summary>
    /// 权限验证
    /// </summary>
    public class BaseController : Controller
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            string ControllerName = filterContext.RouteData.Values["Controller"].ToString();
            string ActionName = filterContext.RouteData.Values["Action"].ToString();        
            if (WebHelper.WebHelper.UserSession == null && ControllerName == "Evaluation" &&
                ( ActionName == "Index" || ActionName == "PostEvaluatuin"))
            {   
                string path = HttpContext.Request.Path;
                string parm = HttpContext.Request.QueryString.ToString();
                string url = path + parm;

                HttpContext.Session.SetString("Url", url);
                Response.Redirect("/Login/Login");
            }
        }
    }
}
