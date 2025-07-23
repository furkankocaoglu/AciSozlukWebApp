using AciSozlukWebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AciSozlukWebApp.Areas.ManagerPanel.Controllers
{
    public class EntryController : Controller
    {
        AciSozlukDB db = new AciSozlukDB();
        public ActionResult Index()
        {
            return View(db.Entries.Where(x => x.IsActive == true).ToList());
        }
        public ActionResult Deleted()
        {
            return View(db.Entries.Where(x => x.IsActive == false).ToList());
        }
        public ActionResult Delete(int? id)
        {
            Entry e = db.Entries.Find(id);

            if (e != null)
            {
                e.Deleted = true;
                e.IsActive = false;
                db.SaveChanges();
            }

            return RedirectToAction("Index","Entry");
        }
        public ActionResult Back(int? id)
        {
            Entry b =db.Entries.Find(id);

            if (b!= null)
            {
                b.IsActive = true;
                b.Deleted = false;
                db.SaveChanges();
                
            }
            return RedirectToAction("Index", "Entry");
        }

    }
}