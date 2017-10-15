using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using NamelessWeb.Models;
using NamelessWeb.Models.Guitar.Wood;

namespace NamelessWeb.Controllers
{
    public class NewTypesController : Controller
    {
        private readonly ApplicationDbContext _dbContext;

        public NewTypesController()
        {
            _dbContext = new ApplicationDbContext();
        }

        // GET: NewTypes
        public ActionResult Index()
        {
            return View();
        }

        [Authorize]
        public ActionResult NewTop()
        {
            return View();
        }

        [HttpPost]
        [Authorize]
        public ActionResult NewTop(GoTop viewModel)
        {
            var top = new GoTop
            {
                TopId = viewModel.TopId,
                TopName = viewModel.TopName
            };
            _dbContext.GoTop.Add(top);
            _dbContext.SaveChanges();
            return RedirectToAction("Index", "Home");
        }

        [Authorize]
        public ActionResult NewNeck()
        {

            return View();
        }

        [HttpPost]
        [Authorize]
        public ActionResult NewNeck(GoNeck viewModel)
        {
            var neck = new GoNeck
            {
                NeckId = viewModel.NeckId,
                NeckName = viewModel.NeckName
            };
            _dbContext.GoNeck.Add(neck);
            _dbContext.SaveChanges();
            return RedirectToAction("Index", "Home");
        }

        [Authorize]
        public ActionResult NewBack()
        {

            return View();
        }

        [HttpPost]
        [Authorize]
        public ActionResult NewBack(GoBack viewModel)
        {
            var back = new GoBack
            {
                BackId = viewModel.BackId,
                BackName = viewModel.BackName
            };
            _dbContext.GoBack.Add(back);
            _dbContext.SaveChanges();
            return RedirectToAction("Index", "Home");
        }

        [Authorize]
        public ActionResult NewSide()
        {

            return View();
        }

        [HttpPost]
        [Authorize]
        public ActionResult NewSide(GoSide viewModel)
        {
            var side = new GoSide
            {
                SideId = viewModel.SideId,
                SideName = viewModel.SideName
            };
            _dbContext.GoSide.Add(side);
            _dbContext.SaveChanges();
            return RedirectToAction("Index", "Home");
        }

        [Authorize]
        public ActionResult NewFing()
        {

            return View();
        }

        [HttpPost]
        [Authorize]
        public ActionResult NewFing(GoFing viewModel)
        {
            var fing = new GoFing
            {
                FingId = viewModel.FingId,
                FingName = viewModel.FingName
            };
            _dbContext.GoFing.Add(fing);
            _dbContext.SaveChanges();
            return RedirectToAction("Index", "Home");
        }
    }
}