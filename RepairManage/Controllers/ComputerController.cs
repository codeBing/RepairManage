using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using RepairManage.Models;

namespace RepairManage.Controllers
{ 
    public class ComputerController : Controller
    {
        private RepairSystemContext db = new RepairSystemContext();

        //
        // GET: /Computer/

        public ViewResult Index()
        {
            var computer = db.Computer.Include(c => c.center);
            return View(computer.ToList());
        }

        //
        // GET: /Computer/Browser/5
        public ViewResult Browser(int id)
        {
            Computer Computer = db.Computer.Find(id);
            if (Computer == null)
            {
                ViewBag.isExist = 0;
            }
            else
            {
                ViewBag.isExist = 1;
            }
            return View(Computer);
        }

        //
        // GET: /Computer/RepairList/5
        public ViewResult RepairList(int id)
        {
            var detail = db.RepairDetail.Where(p => p.computerId == id).OrderByDescending(p=>p.repairTime).ToList();
            return View(detail);
        }

        //
        // GET: /Computer/Details/5

        public ViewResult Details(int id)
        {
            var detail = db.RepairDetail.Find(id);
            return View(detail);
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}