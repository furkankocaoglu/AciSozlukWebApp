﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AciSozlukWebApp.Areas.ManagerPanel.Controllers
{
    public class HomeController : Controller
    {
        // GET: ManagerPanel/Home
        public ActionResult Index()
        {
            return View();
        }
    }
}