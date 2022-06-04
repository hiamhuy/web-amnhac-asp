using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebQuanLyAN.Models;

namespace WebQuanLyAN.Controllers
{
    public class DSBHController : Controller
    {
        // GET: DSBH
        QLAMNHACVNEntities db = new QLAMNHACVNEntities();
        public ActionResult Index()
        {
            List<Baihat> list = db.Baihats.ToList();
            ViewBag.data = list;
            return View(list);
        }
        public ActionResult Search(string search)
        {
            return View(db.thongtinnhacs.Where(n => n.tenBH.Contains(search) || search == null).ToList());
        }
        public ActionResult Create()
        {

            ViewBag.nhacS = new SelectList(db.Nhacsis, "Id", "tenNS");
            ViewBag.theL = new SelectList(db.Theloais, "Id", "tenTL");
            return View();
        }

        public ActionResult add(Baihat bh)
        {
            try
            {
                db.Entry(bh).State = System.Data.Entity.EntityState.Modified;
                db.Baihats.Add(bh);
                db.SaveChanges();
                TempData["ThongBao"] = "Success!";
                return RedirectToAction("Index");
            }
            catch
            {
                TempData["ThongBao"] = "Fail!";
                return RedirectToAction("Create");
            }

        }

        public ActionResult Edit(int? id)
        {
            Baihat bh = db.Baihats.Where(n => n.Id == id).FirstOrDefault();
            ViewBag.nhacS = new SelectList(db.Nhacsis, "Id", "tenNS");
            ViewBag.theL = new SelectList(db.Theloais, "Id", "tenTL");
            return View(bh);
        }
        public ActionResult sua(Baihat bh)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    db.Entry(bh).State = System.Data.Entity.EntityState.Modified;
                    db.SaveChanges();
                    TempData["ThongBao"] = "Success!";
                }

                return RedirectToAction("Index");
            }
            catch
            {
                TempData["ThongBao"] = "Fail!";
                return RedirectToAction("Edit");
            }
        }


        public ActionResult Delete(int? id)
        {
            Baihat bh = db.Baihats.Where(n => n.Id == id).FirstOrDefault();
            if (bh != null)
            {
                db.Baihats.Remove(bh);
                db.SaveChanges();
                TempData["ThongBao"] = "Success!";
            }
            return RedirectToAction("Index");
        }
    }
}