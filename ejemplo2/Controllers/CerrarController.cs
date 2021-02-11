using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ejemplo2.Controllers
{
    public class CerrarController : Controller
    {
        public ActionResult Logout() {
            Session["user"] = null;
            return RedirectToAction("Index","Access");
        }
    }
}
