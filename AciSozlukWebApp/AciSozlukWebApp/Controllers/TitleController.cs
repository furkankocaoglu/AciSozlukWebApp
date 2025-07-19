using AciSozlukWebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AciSozlukWebApp.Controllers
{
    public class TitleController : Controller
    {
        AciSozlukDB db = new AciSozlukDB();
        public ActionResult Index()
        {
            List<Title> titles = db.Titles.Where(x => x.IsActive == true).ToList();

            return PartialView(titles);
        }
        [HttpGet]
        public ActionResult Create()
        {
            List<Category> aktifCategory=db.Categories.Where(x => x.IsActive==true).ToList();
            ViewBag.Categories = new SelectList(aktifCategory, "ID", "CategoryName");
            return View();
        }
        [HttpPost]
        public ActionResult Create(Title Model)
        {
            if (Session["MemberSession"] == null)
            {
                TempData["Mesaj"] = "Üye girişi yapmanız gerekmektedir.";
                return RedirectToAction("Index", "HomePageMember");
            }
            if (ModelState.IsValid)
            {
                db.Titles.Add(Model);
                db.SaveChanges();
                TempData["Mesaj"] = "Başlık yönetici onayında değerlendirilerek eklenecektir.";
                return RedirectToAction("Create", "Title");
            }
            List<Category> aktifCategory = db.Categories.Where(x => x.IsActive == true).ToList();
            ViewBag.Categories = new SelectList(aktifCategory, "ID", "CategoryName", Model.CategoryID);
            return View(Model);

        }

    }
}