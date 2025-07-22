using AciSozlukWebApp.Models;
using AciSozlukWebApp.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AciSozlukWebApp.Controllers
{
    public class HomePageMemberController : Controller
    {
        AciSozlukDB db = new AciSozlukDB();
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ActionResult Create()
        {
            ViewBag.CinsiyetSecim = new SelectList(new List<string>
            {
                "Erkek",
                "Kadın",
                "Belirtmek İstemiyorum"
            });
            return View();
        }
        [HttpPost]
        public ActionResult Create(Member model, HttpPostedFileBase image)
        {
            ViewBag.CinsiyetSecim = new SelectList(new List<string>
            {
                "Erkek",
                "Kadın",
                "Belirtmek İstemiyorum"
            });

            if (ModelState.IsValid)
            {
                try
                {
                    bool isvalidimage = true;

                    if (image != null)
                    {
                        FileInfo fi = new FileInfo(image.FileName);
                        string extension = fi.Extension;
                        if (extension == ".jpg" || extension == ".jpeg" || extension == ".png")
                        {
                            string name = Guid.NewGuid().ToString() + extension;
                            model.Image = name;
                            image.SaveAs(Server.MapPath("~/Assets/MemberImages/" + name));
                        }
                        else
                        {
                            isvalidimage = false;
                            TempData["Mesaj"] = "Resim uzantısı .png, .jpg veya .jpeg olabilir";
                        }
                    }
                    else
                    {
                        model.Image = "none.jpg";
                    }
                    if (isvalidimage)
                    {
                        int count = db.Members.Count(x => x.NickName == model.NickName || x.Email == model.Email);

                        if (count == 0)
                        {
                            MemberRole caylakRol = db.MemberRoles.FirstOrDefault(x => x.ID == 2);

                            if(caylakRol != null)
                            {
                                model.MemberRole_ID = caylakRol.ID;
                            }
                            db.Members.Add(model);
                            db.SaveChanges();
                            TempData["Mesaj"] = "Üyeliğiniz başarılı bir şekilde oluşturuldu.";
                            return RedirectToAction("Create", "HomePageMember");
                        }
                        else
                        {
                            TempData["Mesaj"] = "Bu bilgilerle daha önce oluşturulan üyelik bulunmaktadır.";
                        }
                    }
                }
                catch
                {
                    TempData["Mesaj"] = "Kayıt esnasında hata oluştu";
                }
            }
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(MemberLoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                Member m = db.Members.FirstOrDefault(x => x.NickName == model.NickName && x.Password == model.Password);
                if (m != null)
                {
                    if (m.IsActive)
                    {
                        Session["MemberSession"] = m;
                        return RedirectToAction("Index","Home");
                    }
                    else
                    {
                        TempData["Mesaj"] = "Hesabınız Askıya Alınmıştır";
                    }
                }
                else
                {
                    TempData["Mesaj"] = "Üye Bulunamadı. Lütfen Bilgilerinizi Kontrol Edin.";
                }
            }
            return View(model);
        }
        public ActionResult LogOut()
        {
            Session["MemberSession"] = null;

            return RedirectToAction("Index", "HomePageMember");
        }
    }
}