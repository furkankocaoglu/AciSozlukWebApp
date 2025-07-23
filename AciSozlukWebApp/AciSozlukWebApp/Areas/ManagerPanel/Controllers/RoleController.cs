using AciSozlukWebApp.Models;
using System;
using System.Collections.Generic;
using System.Data.Common;
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
        public ActionResult MemberRole()
        {
            return View(db.Members.Where(x=>x.IsActive==true).ToList());
        }
        [HttpGet]
        public ActionResult EditRole(int? id)
        {
            if(id!=null)
            {
                Member m = db.Members.Find(id);
                if (m!=null)
                {
                    ViewBag.Roles=new SelectList(db.MemberRoles.ToList(), "ID","Name", m.MemberRole_ID);
                    return View(m);
                }
            }
            return RedirectToAction("Index", "Role");
            
        }
        [HttpPost]
        public ActionResult EditRole(Member model)
        {
            if (!ModelState.IsValid)
            {
                try
                {
                    Member m= db.Members.Find(model.ID); 
                    if(m == null)
                    {
                        ViewBag.mesaj = "Üye bulunamadı.";
                        ViewBag.Roles = new SelectList(db.MemberRoles.ToList(), "ID", "Name", m.MemberRole_ID);
                        return View(model);

                    }
                    m.MemberRole_ID = model.MemberRole_ID;
                    db.SaveChanges();
                    TempData["Mesaj"] = "Yetki düzenleme başarılı!";
                    return RedirectToAction("MemberRole", "Role");
                }
                catch
                {
                    ViewBag.mesaj = "Bir hata oluştu";
                }
            }
            ViewBag.Roles = new SelectList(db.MemberRoles.ToList(), "ID", "Name", model.MemberRole_ID);
            return View(model) ;

        }
    }
}