using System;
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
            _DbContext=new ApplicationDbContext();
        }

        public ActionResult Index()
        {
            return View(_DbContext.Guitars.ToList());
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

        public ActionResult Search(FormCollection f, int id = 1)
        {
            string searchtext = f["searchtext"];
            var content = _DbContext.Guitars.Where(n => n.MDL.Contains(searchtext)).ToList();

            return View(content);
        }
    }
}