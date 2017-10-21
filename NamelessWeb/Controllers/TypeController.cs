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
    }
}