using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using RepairManage.Models;
using System.Web.Helpers;

namespace RepairManage.Controllers
{
    public class RepairDetailController : Controller
    {
        private RepairSystemContext db = new RepairSystemContext();

        //
        // GET: /RepairDetail/

        public ViewResult Index()
        {
            return View(db.RepairDetail.ToList());
        }

        //
        // GET: /RepairDetail/Search/5
        [Authorize]
        public ViewResult Browser(int id)
        {
            return View("List", db.RepairDetail.Where(p => p.repairId == id).ToList());
        }

        //
        // GET: /RepairDetail/Search/5
        [Authorize]
        public ViewResult Search(int id)
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
        // GET: /RepairDetail/Details/5
        [Authorize]
        public ViewResult Details(int id)
        {
            RepairDetail repairdetail = db.RepairDetail.Find(id);
            return View(repairdetail);
        }

        //
        // GET: /RepairDetail/Create
        [Authorize]
        public ActionResult Create()
        {
            return View();
        }



        //
        // POST: /RepairDetail/Create
        [HttpPost]
        [Authorize]
        public ActionResult Create(RepairDetail repairdetail)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    db.RepairDetail.Add(repairdetail);
                    db.SaveChanges();
                    return RedirectToAction("List");
                }
            }
            catch (Exception e)
            {
                return View(repairdetail);
            }
            return View(repairdetail);
        }

        //
        //GET:/RepairDetail/List
        [Authorize]
        public ActionResult List()
        {
            return View(db.RepairDetail.ToList());
        }

        //
        // GET: /RepairDetail/Edit/5
        [Authorize]
        public ActionResult Edit(int id)
        {
            RepairDetail repairdetail = db.RepairDetail.Find(id);
            //处理日期格式
            DateTime dt = repairdetail.repairTime;
            string str = "";
            str += dt.Year.ToString();
            str += "-";
            if (dt.Month < 10) str += "0" + dt.Month.ToString();

            else str += dt.Month.ToString();
            str += "-";
            if (dt.Day < 10) str += "0" + dt.Day.ToString();
            else str += dt.Day.ToString();
            ViewBag.strDate = str;


            return View(repairdetail);
        }

        //
        // POST: /RepairDetail/Edit/5

        [HttpPost]
        [Authorize]
        public ActionResult Edit(RepairDetail repairdetail)
        {
            if (ModelState.IsValid)
            {

                db.Entry(repairdetail).State = EntityState.Modified;
                db.SaveChanges();
                if (repairdetail.isFixed == true)
                {
                    sendEmail(repairdetail.email,repairdetail.customerName);
                }
                return RedirectToAction("List");
            }
            return View(repairdetail);
        }

        private void sendEmail(string email,string name)
        {
            WebMail.SmtpServer = "smtp.163.com";//获取或设置要用于发送电子邮件的 SMTP 中继邮件服务器的名称。
            WebMail.SmtpPort = 25;//发送端口
            WebMail.EnableSsl = false;//是否启用 SSL GMAIL 需要 而其他都不需要 具体看你在邮箱中的配置
            WebMail.UserName = "ksws0191053";//账号名
            WebMail.From = "ksws0191053@163.com";//邮箱名
            WebMail.Password = "zbj5501308";//密码
            WebMail.SmtpUseDefaultCredentials = true;//是否使用默认配置
            WebMail.Send(to: email,
                         subject: "电脑已维修完成",
                         body: "亲爱的"+name+"您好，您的电脑已经维修完成，请于近期到指定的维修中心提取您的电脑，谢谢。"
                         );
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}