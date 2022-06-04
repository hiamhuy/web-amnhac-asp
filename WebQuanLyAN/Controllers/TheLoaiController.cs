using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebQuanLyAN.Models;

namespace WebQuanLyAN.Controllers
{
    public class TheLoaiController : Controller
    {
        // GET: TheLoai
        QLAMNHACVNEntities ql = new QLAMNHACVNEntities();
        public ActionResult Index()
        {
            List<Theloai> list = ql.Theloais.OrderBy(n => n.Id).ToList();
            ViewBag.data = list;
            return View(list);
        }
        public ActionResult them()
        {
            return View();
        }
        [HttpPost]
        public ActionResult them(Theloai t)
        {
            try
            {
                using (QLAMNHACVNEntities ql = new QLAMNHACVNEntities())
                {
                    ql.Theloais.Add(t);
                    ql.SaveChanges();
                    TempData["ThongBao"] = "Success!";
                }
                return RedirectToAction("Index");
            }
            catch
            {
                TempData["ThongBao"] = "Fail!";
                return View();
            }
        }
        public ActionResult sua(int Id)
        {
            Theloai tl = ql.Theloais.SingleOrDefault(n => n.Id == Id);
            return View(tl);
        }
        public ActionResult edit(Theloai t)
        {
            if (ModelState.IsValid)
            {
                ql.Entry(t).State = System.Data.Entity.EntityState.Modified;
                ql.SaveChanges();
                TempData["ThongBao"] = "Success!";

            }
            return RedirectToAction("Index");
        }
        public ActionResult xoa(int Id)
        {
            Theloai tl = ql.Theloais.SingleOrDefault(n => n.Id == Id);
            if (tl != null)
            {
                ql.Theloais.Remove(tl);
                ql.SaveChanges();
                TempData["ThongBao"] = "Success!!";
            }
            return RedirectToAction("Index");
        }
    }
}