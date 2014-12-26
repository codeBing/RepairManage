using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using RepairManage.Models;
using System.Web.Security;

namespace RepairManage.Controllers
{ 
    public class AdminController : Controller
    {
        private RepairSystemContext db = new RepairSystemContext();

        //
        // GET: /Admin/LogOn

        public ActionResult LogOn()
        {
            return View();
        }

        //
        // POST: /Admin/LogOn

        [HttpPost]
        public ActionResult LogOn(Administrator model)
        {
            if (ModelState.IsValid)
            {
                if (ValidateUser(model))
                {

                    FormsAuthentication.SetAuthCookie(model.adminName, true);
                    return RedirectToAction("Home", "Admin");
                }
                else
                {
                    ModelState.AddModelError("", "用户名或密码不正确！");
                }
            }

            // If we got this far, something failed, redisplay form
            return View(model);
        }

        //
        // GET: /Account/LogOff

        public ActionResult LogOff()
        {
            FormsAuthentication.SignOut();

            return RedirectToAction("LogOn", "Admin");
        }

        private bool ValidateUser(Administrator model)
        {
            string name = model.adminName;
            string pwd = model.adminPwd;
            var count = db.Administrator.Where(admin => admin.adminName == name && admin.adminPwd == pwd);
            if (count.Count() == 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        [Authorize]
        public ActionResult Home()
        {
            return View();
        }
    }
}