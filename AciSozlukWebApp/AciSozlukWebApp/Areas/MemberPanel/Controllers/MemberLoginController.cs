using AciSozlukWebApp.Models;
using AciSozlukWebApp.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AciSozlukWebApp.Areas.MemberPanel.Controllers
{
    
    public class MemberLoginController : Controller
    {
        AciSozlukDB db = new AciSozlukDB();
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(MemberLoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                Member m = db.Members.FirstOrDefault(x => x.NickName == model.NickName && x.Password == model.Password);
                if(m != null)
                {
                    if(m.IsActive)
                    {
                        Session["MemberSession"] = m;
                        return RedirectToAction("Index", "Default");
                    }
                    else 
                    {
                        TempData["Mesaj"] = "Hesabınız Askıya Alınmıştır";
                    }
                }
                else
                {
                    TempData["Mesaj"] = "Üye Bulunamadı. Lütfen Bilgilerinizi Kontrol Edin";
                }
            }        
            return View();
        }
        public ActionResult Logout()
        {
            Session["MemberSession"] = null;

            return RedirectToAction("Index","MemberLogin");
        }
    }
    
}