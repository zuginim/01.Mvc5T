﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DebuggingDEMO.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            //16.08.28
            int firstVal = 10;
            int secondVal = 0;
            int result = firstVal / 2;

            //16.08.28
            //ViewBag.Message = "Welcome to ASP.NET MVC!";

            return View(result);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}