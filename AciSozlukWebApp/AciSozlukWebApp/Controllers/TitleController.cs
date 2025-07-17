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
        AciSozlukDB db= new AciSozlukDB();
        public ActionResult Index()
        {
            List<Title> titles = db.Titles.Where(x => x.IsActive == true).ToList();

            return PartialView(titles);
        }
        [HttpGet]
        public ActionResult Create()
        {
            ViewBag.Categories = new SelectList(db.Categories, "ID", "CategoryName");
            return View();
        }
        [HttpPost]
        public ActionResult Create(Title Model)
        {
            if (Session["MemberSession"] == null)
            return RedirectToAction("Index","HomePageMember");

            if(ModelState.IsValid)
            {
                db.Titles.Add(Model);
                db.SaveChanges();
                TempData["Mesaj"] = "Başlık başarıyla eklendi.";
                return RedirectToAction("Create", "Title");
            }
            ViewBag.Categories = new SelectList(db.Categories, "ID", "CategoryName", Model.CategoryID);
            return View(Model);

        }
        
    }
}