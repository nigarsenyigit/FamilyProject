using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Family.UI.Filters
{
    public class SessionFilter : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (HttpContext.Current.Session["CurrentUser"] == null)
            {
                filterContext.Result = new RedirectResult("~/Session/SignIn");
            }
            base.OnActionExecuting(filterContext);
        }
    }
}