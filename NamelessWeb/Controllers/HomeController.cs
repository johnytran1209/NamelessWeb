﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using NamelessWeb.Models;

namespace NamelessWeb.Controllers
{
    public class HomeController : Controller
    {
        private ApplicationDbContext _DbContext;

        public HomeController()
        {
            _DbContext = new ApplicationDbContext();
        }

        public ActionResult Index()
        {
            return View(_DbContext.Guitars.ToList());
        }

        public ActionResult About()
        {
            return View();
        }

        public ActionResult Contact()
        {
            return View();
        }


    }
}