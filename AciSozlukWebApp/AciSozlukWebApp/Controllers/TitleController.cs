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
            return PartialView(db.Titles.Where(x => x.IsActive == true).ToList());
        }
        [HttpGet]
        public ActionResult Create()
        {
            List<Category> aktifCategory=db.Categories.Where(x => x.IsActive == true).ToList();
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
            List <Category> aktifCategory = db.Categories.Where(x => x.IsActive == true).ToList();
            ViewBag.Categories = new SelectList(aktifCategory, "ID", "CategoryName", Model.CategoryID);
            return View(Model);

        }
        public ActionResult Detail(int? id)
        {
            Title secilenBaslik = db.Titles.FirstOrDefault(x => x.ID == id && x.IsActive && !x.Deleted);

            List<Entry> entryListesi = db.Entries.Where(x => x.TitleID == id).ToList();

            foreach (Entry entry in entryListesi)
            {
                entry.Member = db.Members.FirstOrDefault(m => m.ID == entry.MemberID);
            }

            secilenBaslik.Entries = entryListesi;

            return View(secilenBaslik);
        }
        [HttpGet]
        public ActionResult CreateEntry(int? titleID)
        {
            if (Session["MemberSession"]== null)
            {
                TempData["Mesaj"] = "Üye girişi yapmanız gerekmektedir.";
                return RedirectToAction("Index", "HomePageMember");
            }
            if(titleID == null)
            {
                return RedirectToAction("Index", "Title");
            }
            Title secilenBaslik = db.Titles.FirstOrDefault(x=>x.ID==titleID&&x.IsActive && !x.Deleted);
            ViewBag.TitleName = secilenBaslik.TitleName;
            ViewBag.TitleID = secilenBaslik.ID;
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateEntry(Entry model)
        {
            if (Session["MemberSession"] == null)
            {
                TempData["Mesaj"] = "Üye girişi yapmanız gerekmektedir.";
                return RedirectToAction("Index", "HomePageMember");
            }

            if (ModelState.IsValid)
            {
                Member uye = (Member)Session["MemberSession"];
                model.MemberID = uye.ID;
                model.CreationTime = DateTime.Now;
                model.IsActive = true;
                model.Deleted = false;

                db.Entries.Add(model);
                db.SaveChanges();

                TempData["Mesaj"] = "Yazı başarılı şekilde oluşturuldu.";
                return RedirectToAction("Detail", "Title", new { id = model.TitleID });
            }

            TempData["Mesaj"] = "Karakter sınırı maksimum 500 olmalıdır.";
            return RedirectToAction("Detail", "Title", new { id = model.TitleID });
        }

    }
}