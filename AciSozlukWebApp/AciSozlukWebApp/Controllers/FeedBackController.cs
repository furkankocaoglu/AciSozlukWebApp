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
                TempData["Mesaj"] = "Geri bildiriminiz iletilmiştir. Görüşlerinizi paylaştığınız için teşekkür ederiz!";
                return RedirectToAction("Create","FeedBack");
            }
            else
            {
                TempData["Mesaj"] = "Bir hata oluştu. İlgili alanları eksiksiz doldurun.";
            }
            return View(Model);
        }
    }
}