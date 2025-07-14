using AciSozlukWebApp.Models;
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
        AciSozlukDB db= new AciSozlukDB();  
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
        public ActionResult Create(Member Model, HttpPostedFileBase image)
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
                            Model.Image = name;
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
                        Model.Image = "none.jpg";
                    }
                    if (isvalidimage)
                    {
                        db.Members.Add(Model);
                        db.SaveChanges();
                        TempData["Mesaj"] = "Üyeliğiniz başarılı bir şekilde oluşturuldu";
                        return RedirectToAction("Create", "HomePageMember");
                    }
                }
                catch
                {
                    TempData["Mesaj"] = "Kayıt esnasında hata oluştu";
                }
            }
            return View(Model);
        }
    }
}