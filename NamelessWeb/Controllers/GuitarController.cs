using NamelessWeb.Models;
using NamelessWeb.Models.Guitar;
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
                TypeIds = _DbContext.GuitarType.ToList(),
                BrandIds = _DbContext.Brand.ToList(),
                Tops = _DbContext.GoTop.ToList(),
                Sides = _DbContext.GoSide.ToList(),
                Backs = _DbContext.GoBack.ToList(),
                Necks = _DbContext.GoNeck.ToList(),
                Fings = _DbContext.GoFing.ToList(),
                Insurances = _DbContext.Warranty.ToList()
            };
            return View(viewModel);
        }

        [Authorize]
        [HttpPost]
        public ActionResult Create(GuitarViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                viewModel.TypeIds = _DbContext.GuitarType.ToList();
                viewModel.BrandIds = _DbContext.Brand.ToList();
                viewModel.Tops = _DbContext.GoTop.ToList();
                viewModel.Sides = _DbContext.GoSide.ToList();
                viewModel.Backs = _DbContext.GoBack.ToList();
                viewModel.Necks = _DbContext.GoNeck.ToList();
                viewModel.Fings = _DbContext.GoFing.ToList();
                viewModel.Insurances = _DbContext.Warranty.ToList();
                //return View(viewModel);
            }
            int x = viewModel.GuitarId;
            var guitar = new Guitars
            {
                GuitarId = x,
                MDL = viewModel.GuitarModel,
                BrandId = viewModel.BrandId,
                TypeId = viewModel.TypeId,
                MSRP = viewModel.Price,
                ELE = viewModel.Electricfied,
                WarrId = viewModel.Insurance,
                ImageLink = viewModel.ImageLink
            };
            var guitarSpecs = new GuitarSpecs
            {
                GuitarId = x,
                TopId = viewModel.Top,
                SideId = viewModel.Side,
                BackId = viewModel.Back,
                NeckId = viewModel.Neck,
                FingId = viewModel.Fing,
                Descript = viewModel.Description
            };
            _DbContext.Guitars.Add(guitar);
            _DbContext.GuitarSpecs.Add(guitarSpecs);
            _DbContext.SaveChanges();
            return RedirectToAction("Index","Home");
        }
    }
}