using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AciSozlukWebApp.Areas.MemberPanel.Controllers
{
    public class DefaultController : Controller
    {
        // GET: MemberPanel/Default
        public ActionResult Index()
        {
            return View();
        }
    }
}