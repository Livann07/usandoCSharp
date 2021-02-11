using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ejemplo2.Models;
using ejemplo2.Models.TableViewModels;
using ejemplo2.Models.ViewModels;

namespace ejemplo2.Controllers
{
    public class UserController : Controller
    {
        // GET: User
        public ActionResult Index()
        {
            List<UserTableViewModel> lst;
            using(ejemplo1Entities db = new ejemplo1Entities())
            {
                lst = (from d in db.user
                       where d.idState == 1
                       orderby d.email
                       select new UserTableViewModel
                       {
                           Email = d.email,
                           ID = d.id,
                           Edad = d.edad
                       }).ToList();

            }
            
            
            return View(lst);
        }
        [HttpGet]
        public ActionResult Add() {
            return View();

        }
        
        [HttpPost]
        public ActionResult Add(UserViewModel model) {
            if(!ModelState.IsValid) {
                return View(model);
            }

            using(var db = new ejemplo1Entities()) {
                user oUser = new user();
                oUser.idState = 1;
                oUser.email = model.Email;
                oUser.edad = model.Edad;
                oUser.password = model.Password;

                db.user.Add(oUser);
                db.SaveChanges();
            }

            return Redirect(Url.Content("~/user/"));
        }

        public ActionResult Edit(int Id) {
            EditUserViewModel model = new EditUserViewModel();
            using(var db = new ejemplo1Entities()) {
                var oUser = db.user.Find(Id);
                model.Edad = (int)oUser.edad;
                model.Email = oUser.email;
                model.id = oUser.id;
            }

            return View(model);
        }
        [HttpPost]
        public ActionResult Edit(EditUserViewModel model) {
            if(!ModelState.IsValid) {
                return View(model);
            }

            using(var db = new ejemplo1Entities()) {
                var oUser = db.user.Find(model.id);
                oUser.email = model.Email;
                oUser.edad = model.Edad; 
            
                if(model.Password!=null && model.Password.Trim() != "") {
                    oUser.password = model.Password;
                }

                db.Entry(oUser).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();

            }

            return Redirect(Url.Content("~/user/"));
        }


       
        [HttpPost]
        public ActionResult Delete(int id) {
           
            using(var db = new ejemplo1Entities()) {
                var oUser = db.user.Find(id);
                oUser.idState = 3; //Eliminar


                db.Entry(oUser).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();

            }

            return Content("1");
        }


    }


}