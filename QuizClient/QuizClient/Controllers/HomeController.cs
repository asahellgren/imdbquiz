﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QuizClient.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Rules()
        {
            return View();
        }

        public ActionResult Api()
        {
            return View();
        }

        public ActionResult HighScore()
        {
            return View();
        }
    }
}