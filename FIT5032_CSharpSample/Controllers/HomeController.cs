﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FIT5032_CSharpSample.Models.HelloWorld;
using FIT5032_CSharpSample.Models.Exercise;


namespace FIT5032_CSharpSample.Controllers
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
            Hello hello = new Hello();
            ViewBag.Message = hello.GetHello();

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}