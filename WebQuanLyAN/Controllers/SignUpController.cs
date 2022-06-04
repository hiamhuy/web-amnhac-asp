using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebQuanLyAN.Models;

namespace WebQuanLyAN.Controllers
{
    public class SignUpController : Controller
    {
        // GET: SignUp
        QLAMNHACVNEntities db = new QLAMNHACVNEntities();
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult add(Ac ac)
        {

            try
            {
                db.Acs.Add(ac);
                db.SaveChanges();
                TempData["ThongBao"] = "true";
                return Redirect("/Login/Index");
            }
            catch
            {
                TempData["ThongBao"] = "false";
                return RedirectToAction("Index");
            }
        }
    }
}