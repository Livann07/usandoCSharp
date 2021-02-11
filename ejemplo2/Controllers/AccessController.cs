using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ejemplo2.Models;

namespace ejemplo2.Controllers
{
    public class AccessController : Controller
    {
        // GET: Access
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Enter(string user, string password)
        {
            try
            {
                using (ejemplo1Entities db = new ejemplo1Entities())
                {
                    var lst = from d in db.user
                              where d.email == user && d.password == password && d.idState == 1
                              select d;
                    if (lst.Count() > 0)
                    {
                        user oUser = lst.First();
                        Session["user"] = oUser;
                        return Content("1");
                    }
                    else
                    {
                        return Content("Usuario Invalido");
                    }
                }

            }
            catch (Exception e)
            {
                return Content("Ocurrió un problema" + e.Message);
            }
        }

        
    }
}