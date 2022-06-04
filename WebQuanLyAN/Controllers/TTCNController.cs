using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebQuanLyAN.Models;
namespace WebQuanLyAN.Controllers
{
    public class TTCNController : Controller
    {
        public static string id;
        QLAMNHACVNEntities ql = new QLAMNHACVNEntities();
        // GET: TTCN
        public ActionResult Index()
        {
            var ac = ql.Acs.Where(n => n.TaiKhoan.Contains(datatk.tk));
            ViewBag.data = ac;
            return View(ac);
        }
        public ActionResult Edit(String tk)
        {
            Ac ac = ql.Acs.Where(n => n.TaiKhoan == tk).FirstOrDefault();
            id = tk;
            return View(ac);
        }
        public ActionResult EditHoTen(String tk)
        {
            Ac ac = ql.Acs.Where(n => n.TaiKhoan == tk).FirstOrDefault();
            id = tk;
            return View(ac);
        }
        public ActionResult sua(Ac ac)
        {
            if (ModelState.IsValid)
            {
                if (ac.MatKhauCu == datatk.mk)
                {
                    if (ac.MatKhau == ac.MatKhau1)
                    {
                        ql.Entry(ac).State = System.Data.Entity.EntityState.Modified;
                        ql.SaveChanges();
                        TempData["TB"] = "true";
                        datatk.mk = ac.MatKhau;
                    }
                    else
                    {
                        TempData["TB"] = "khac";
                        return Redirect("/TTCN/Edit?tk=" + id);
                    }
                }
                else
                {
                    TempData["TB"] = "false";
                    return Redirect("/TTCN/Edit?tk="+id);
                }
            }
                return RedirectToAction("Index");
        }
        public ActionResult suaten(Ac ac)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    ql.Entry(ac).State = System.Data.Entity.EntityState.Modified;
                    ql.SaveChanges();
                    TempData["TBT"] = "true";
                }
                catch
                {
                    TempData["TBT"] = "false";
                }
            }
            return RedirectToAction("Index");
        }
    }
}