using AciSozlukWebApp.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AciSozlukWebApp.Areas.ManagerPanel.Controllers
{
    public class MemberController : Controller
    {
        AciSozlukDB db= new AciSozlukDB();
        public ActionResult Index()
        {
            return View(db.Members.Where(x=>x.IsActive==true).ToList());
        }
        
    }
}