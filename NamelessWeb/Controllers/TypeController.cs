using NamelessWeb.Models;
using NamelessWeb.Views.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NamelessWeb.Controllers
{
    public class TypeController : Controller
    {
        private readonly ApplicationDbContext _DbContext;
        public TypeController()
        {
            _DbContext = new ApplicationDbContext();
        }
        // GET: Type
        public ActionResult CreateType()
        {
            var viewModel1 = new TypeViewModel { };
            return View(viewModel1);
        }
        [HttpPost]
        public ActionResult CreateType(TypeViewModel viewModel1)
        {
            var Type = new NamelessWeb.Models.Guitar.GuitarType
            {
                TypeId = viewModel1.TypeId,
                TypeName = viewModel1.TypeName,
            };
            _DbContext.GuitarType.Add(Type);
            _DbContext.SaveChanges();

            return View();
        }
    }
}