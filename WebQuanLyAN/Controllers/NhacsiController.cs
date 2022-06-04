using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebQuanLyAN.Models;

namespace WebQuanLyAN.Controllers
{
    public class NhacsiController : Controller
    {
        // GET: Nhacsi
        QLAMNHACVNEntities ql = new QLAMNHACVNEntities();
        public ActionResult Index()
        {
            List<Nhacsi> list = ql.Nhacsis.OrderBy(n => n.Id).ToList();
            ViewBag.data = list;
            return View(list);

        }
        public ActionResult Search(string search)
        {
            return View(ql.Nhacsis.Where(n => n.tenNS.Contains(search) || search == null).ToList());
        }
        public ActionResult Create()
        {

            return View();
        }
        public ActionResult add(Nhacsi ns)
        {
            try
            {
                ql.Nhacsis.Add(ns);
                ql.SaveChanges();
                TempData["ThongBao"] = "Success!";
                return RedirectToAction("Index");
            }
            catch
            {
                TempData["ThongBao"] = "Fail!";
                return RedirectToAction("Create");
            }
        }
        public ActionResult Edit(int id)
        {

            Nhacsi ns = ql.Nhacsis.Where(n => n.Id == id).FirstOrDefault();
            return View(ns);
        }
        public ActionResult sua(Nhacsi ns)
        {
            if (ModelState.IsValid)
            {
                ql.Entry(ns).State = System.Data.Entity.EntityState.Modified;
                ql.SaveChanges();
                TempData["ThongBao"] = "Success!";
            }
            return RedirectToAction("Index");
        }
        public ActionResult Delete(int Id)
        {
            Nhacsi ns = ql.Nhacsis.Where(n => n.Id == Id).FirstOrDefault();
            if (ns != null)
            {
                ql.Nhacsis.Remove(ns);
                ql.SaveChanges();
                TempData["ThongBao"] = "Success!";
            }
            return RedirectToAction("Index");
        }
    }
}