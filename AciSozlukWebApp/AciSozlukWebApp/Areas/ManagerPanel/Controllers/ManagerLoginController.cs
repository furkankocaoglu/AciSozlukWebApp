using AciSozlukWebApp.Models;
using AciSozlukWebApp.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Web;
using System.Web.Mvc;

namespace AciSozlukWebApp.Areas.ManagerPanel.Controllers
{
    public class ManagerLoginController : Controller
    {
        AciSozlukDB db = new AciSozlukDB();
        public ActionResult Index()
        {         
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(ManagerLoginViewModel model)
        {
            if(ModelState.IsValid)//bu yapı tabloda required olan kısımlar varsa onları kontrol eder ve formdan gelen verilerin doğrulama kurallarına uygun olup olmadığını kontrol eder.
            {
                Manager m = db.Managers.FirstOrDefault(x => x.UserName == model.UserName && x.Password == model.Password);
                if (m != null)
                {
                    if(m.IsActive)
                    {
                        Session["ManagerSession"] = m;
                        return RedirectToAction("Index","Home");
                    }
                    else
                    {
                        TempData["mesaj"] = "Hesabınız askıya alınmıştır.";
                    }
                }
                else
                {
                    TempData["mesaj"] = "Kullanıcı Bulunamadı";
                }
            }           
            return View();
        }
    }
}