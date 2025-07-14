using AciSozlukWebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AciSozlukWebApp.Areas.ManagerPanel.Controllers
{
    public class FeedBackController : Controller
    {
        AciSozlukDB db= new AciSozlukDB();
        public ActionResult Index()
        {
            return View(db.FeedBacks.Where(x => x.IsActive==true).ToList());        }
        public ActionResult Deleted()
        {
            return View(db.FeedBacks.Where(x => x.IsActive == false).ToList());
        }
        public ActionResult Solved(int? id)
        {
            if (id != null)
            {
                FeedBack f = db.FeedBacks.Find(id);

                if (f != null)
                {
                    f.Deleted = true;
                    f.IsActive = false;
                    db.SaveChanges();
                    TempData["Mesaj"] = "Değerlendirildi";
                }
            }
            return RedirectToAction("Index", "FeedBack");
        }
    }
}