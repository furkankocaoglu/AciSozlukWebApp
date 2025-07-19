using AciSozlukWebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AciSozlukWebApp.Areas.ManagerPanel.Controllers
{
    public class TitleController : Controller
    {
        AciSozlukDB db = new AciSozlukDB();
        public ActionResult Index()
        {
            return View(db.Titles.Where(x => x.IsActive == false).ToList());
        }
        public ActionResult Delete(int? id)
        {
            if (id != null)
            {
                Title t = db.Titles.Find(id);

                if (t != null)
                {
                    t.Deleted = true;
                    t.IsActive = false;
                    db.SaveChanges();
                    TempData["Mesaj"] = "Başlık kaldırıldı";
                    
                }
                return RedirectToAction("Index","Title");
            }
            return View();
        }
        public ActionResult Verification(int? id)
        {
            if (id != null)
            {
                Title t = db.Titles.Find(id);

                if (t != null)
                {
                    t.IsActive = true;
                    t.Deleted = false;
                    db.SaveChanges();
                    TempData["Mesaj"] = "Başlık anasayfada onaylandı";

                }
                return RedirectToAction("Index", "Title");
            }
            return View();
        }
        public ActionResult Waiting()
        {
            DateTime today = DateTime.Today;
            DateTime tomorrow =today.AddDays(1);

            List<Title> titleList= db.Titles.Where(t => t.CreationTime >= today && t.CreationTime < tomorrow && t.Deleted == true).ToList();

            return View(titleList);
        }

    }
}