using AciSozlukWebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AciSozlukWebApp.Areas.ManagerPanel.Controllers
{
    public class CategoryController : Controller
    {
        AciSozlukDB db= new AciSozlukDB();
       
        public ActionResult Index()
        {
            return View(db.Categories.Where(x=>x.Deleted==false).ToList());
        }
        public ActionResult Deleted()
        {
            return View(db.Categories.Where(x => x.Deleted == true).ToList());
        }
        [HttpGet]
        public ActionResult Create()
        {

            return View();
        }
        [HttpPost]
        public ActionResult Create(Category Model)
        {
            if(ModelState.IsValid)
            {
                db.Categories.Add(Model);
                db.SaveChanges();
                return RedirectToAction("Index","Category");
            }
            else
            {
                TempData["Mesaj"] = "Bir Hata Oluştu";
            }
            return View(Model);
        }
        [HttpGet]
        public ActionResult Edit(int? id)
        {
            if(id != null)
            {
                Category c = db.Categories.Find(id);

                if(c != null)
                {
                    return View(c);

                }
            }
            return RedirectToAction("Index","Category");
        }
        [HttpPost]
        public ActionResult Edit(Category Model)
        {
            if(ModelState.IsValid)
            {
                Category c = db.Categories.FirstOrDefault(x=> x.ID == Model.ID);

                if(c != null)
                {
                    c.CategoryName = Model.CategoryName;
                    c.IsActive = Model.IsActive;
                    db.SaveChanges();

                    TempData["Mesaj"] = "Kategori Güncelleme Başarılı";
                    return RedirectToAction("Index", "Category");
                }
                else
                {
                    TempData["Mesaj"] = "Kategori Bulunamadı";
                }

            }
            return View(Model);
        }
        public ActionResult Delete(int ? id)
        {
            if(id != null)
            {
                Category c = db.Categories.Find(id);  

                if(c != null)
                {
                    c.Deleted = true;
                    c.IsActive = false;
                    db.SaveChanges();
                    TempData["Mesaj"] = "Kategori Kaldırıldı";
                }
            }
            return RedirectToAction("Index", "Category");
        }
        public ActionResult Back(int? id)
        {
            if (id != null)
            {
                Category c = db.Categories.Find(id);

                if (c != null)
                {
                    c.Deleted = false;
                    c.IsActive = true;
                    db.SaveChanges();
                    TempData["Mesaj"] = "Kategori Geri Getirildi";
                }
            }
            return RedirectToAction("Index", "Category");
        }
    }
}