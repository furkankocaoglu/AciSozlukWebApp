using AciSozlukWebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AciSozlukWebApp.Controllers
{
    public class MenuController : Controller
    {
        AciSozlukDB db= new AciSozlukDB();
        public ActionResult Index()
        {
            List<Category> categories=db.Categories.Where (x=>x.IsActive==true).ToList();

            return PartialView(categories);
        }
    }
}