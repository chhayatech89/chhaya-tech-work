﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Chhayatech.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
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

        public ActionResult EdFund()
        {
            return View();
        }

        public ActionResult Tour()
        {
            return View();

        }


        public ActionResult Technews()
        {

            return View();

        }


        public ActionResult Healthinfo()
        {
            return View();
        }


        public ActionResult carousel()
        {
            return View();
        
        }


        public ActionResult Career()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

    }
}