using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ejemplo2.Controllers;
using ejemplo2.Models;

namespace ejemplo2.Filters
{
    public class verifySession : ActionFilterAttribute
    {

        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var user = (user)HttpContext.Current.Session["user"];

            if (user == null)
            {
                if(filterContext.Controller is AccessController == false)
                {
                    filterContext.HttpContext.Response.Redirect("~/access/index");
                }
            }
            else
            {
                if (filterContext.Controller is AccessController == true)
                {
                    filterContext.HttpContext.Response.Redirect("~/home/index");
                }
            }

            base.OnActionExecuting(filterContext);
        }

    }
}