using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebQuanLyAN.Models;

namespace WebQuanLyAN.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        QLAMNHACVNEntities db = new QLAMNHACVNEntities();
        
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult LoginProcess(Ac ac)
        {
            var data = db.Acs.FirstOrDefault(acc => acc.TaiKhoan == ac.TaiKhoan && acc.MatKhau == ac.MatKhau);

            if (data == null)
            {

                TempData["IsLoginSuccess"] = "false";
                return RedirectToAction("Index");
            }
                datatk.tk=ac.TaiKhoan;
                datatk.mk = ac.MatKhau;
                TempData["IsLoginSuccess"] = "true";
                return Redirect("/Home/Index");
            
         
        }
    }
}