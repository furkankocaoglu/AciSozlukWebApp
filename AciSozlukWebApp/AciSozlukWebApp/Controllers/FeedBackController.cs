using AciSozlukWebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AciSozlukWebApp.Controllers
{
    public class FeedBackController : Controller
    {
        AciSozlukDB db = new AciSozlukDB();
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ActionResult Create()
        {

            return View();
        }
        [HttpPost]
        public ActionResult Create(FeedBack Model)
        {
            if(ModelState.IsValid)
            {
                db.FeedBacks.Add(Model);
                db.SaveChanges();
                TempData["Mesaj"] = "Geri Bildiriminiz İletilmiştir. Görüşlerinizi Paylaştığınız İçin Teşekkür Ederiz.";
                return RedirectToAction("Create","FeedBack");
            }
            else
            {
                TempData["Mesaj"] = "Bir Hata Oluştu. İlgili Alanları Eksiksiz Doldurun.";
            }
            return View(Model);
        }
    }
}