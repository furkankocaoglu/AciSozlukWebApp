using AciSozlukWebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AciSozlukWebApp.Areas.ManagerPanel.Controllers
{
    public class RoleController : Controller
    {
        AciSozlukDB db = new AciSozlukDB();
        public ActionResult Index()
        {
            return View(db.MemberRoles.Where(x => x.IsActive == true).ToList());
        }
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(MemberRole model)
        {
            if (ModelState.IsValid)
            {
                db.MemberRoles.Add(model);
                db.SaveChanges();
                TempData["Mesaj"] = "Rol eklendi";
                return RedirectToAction("Index","Role");
            }
            return View(model);

        }
        public ActionResult Sign()
        {
            return View(db.ManagerRoles.Where(x => x.IsActive == true).ToList());
        }
        [HttpGet]
        public ActionResult Constitute()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Constitute(ManagerRole model)
        {
            if (ModelState.IsValid)
            {
                db.ManagerRoles.Add(model);
                db.SaveChanges();
                TempData["Mesaj"] = "Rol eklendi";
                return RedirectToAction("Sign", "Role");
            }
            return View(model);
        }
    }
}