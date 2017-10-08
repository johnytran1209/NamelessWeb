using NamelessWeb.Models;
using NamelessWeb.Views.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NamelessWeb.Controllers
{
    public class GuitarController : Controller
    {
        private readonly ApplicationDbContext _DbContext;
        public GuitarController()
        {
            _DbContext = new ApplicationDbContext();
        }
        // GET: Guitar
        public ActionResult Create()
        {
            var viewModel = new GuitarViewModel
            {
                TypeId = _DbContext.GuitarType.ToList(),
                BrandId = _DbContext.Brand.ToList(),
                Top = _DbContext.GoTop.ToList(),
                Side = _DbContext.GoSide.ToList(),
                Back = _DbContext.GoBack.ToList(),
                Neck = _DbContext.GoNeck.ToList(),
                Fing = _DbContext.GoFing.ToList(),
                Insurance = _DbContext.Warranty.ToList()
            };
            return View(viewModel);
        }
    }
}