using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using NamelessWeb.Models;
using NamelessWeb.Models.Guitar.Wood;
using NamelessWeb.Models.Guitar;
using NamelessWeb.Models.Company;
using NamelessWeb.Views.ViewModels;
using System.Data.SqlClient;

namespace NamelessWeb.Controllers
{
    public class NewTypesController : Controller
    {
        SqlConnection a = new SqlConnection(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=NamelessWeb;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");

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
        [Authorize(Roles = "Admin,Employee")]
        public ActionResult NewType()
        {
            return View();
        }

        [HttpPost]
        [Authorize(Roles = "Admin,Employee")]
        public ActionResult NewType(GuitarTypes viewModel)
        {
            var type = new GuitarTypes
            {
                TypeId = viewModel.TypeId,
                TypeName = viewModel.TypeName
            };
            _dbContext.GuitarType.Add(type);
            _dbContext.SaveChanges();
            return RedirectToAction("Create", "Guitar");
        }

        [Authorize(Roles = "Admin,Employee")]
        public ActionResult NewTop()
        {
            return View();
        }

        [HttpPost]
        [Authorize(Roles = "Admin,Employee")]
        public ActionResult NewTop(GoTop viewModel)
        {
            var top = new GoTop
            {
                TopId = viewModel.TopId,
                TopName = viewModel.TopName
            };
            _dbContext.GoTop.Add(top);
            _dbContext.SaveChanges();
            return RedirectToAction("Create", "Guitar");
        }

        [Authorize(Roles = "Admin,Employee")]
        public ActionResult NewNeck()
        {

            return View();
        }

        [HttpPost]
        [Authorize(Roles = "Admin,Employee")]
        public ActionResult NewNeck(GoNeck viewModel)
        {
            var neck = new GoNeck
            {
                NeckId = viewModel.NeckId,
                NeckName = viewModel.NeckName
            };
            _dbContext.GoNeck.Add(neck);
            _dbContext.SaveChanges();
            return RedirectToAction("Create", "Guitar");
        }

        [Authorize(Roles = "Admin,Employee")]
        public ActionResult NewBack()
        {

            return View();
        }

        [HttpPost]
        [Authorize(Roles = "Admin,Employee")]
        public ActionResult NewBack(GoBack viewModel)
        {
            var back = new GoBack
            {
                BackId = viewModel.BackId,
                BackName = viewModel.BackName
            };
            _dbContext.GoBack.Add(back);
            _dbContext.SaveChanges();
            return RedirectToAction("Create", "Guitar");
        }

        [Authorize(Roles = "Admin,Employee")]
        public ActionResult NewSide()
        {

            return View();
        }

        [HttpPost]
        [Authorize(Roles = "Admin,Employee")]
        public ActionResult NewSide(GoSide viewModel)
        {
            var side = new GoSide
            {
                SideId = viewModel.SideId,
                SideName = viewModel.SideName
            };
            _dbContext.GoSide.Add(side);
            _dbContext.SaveChanges();
            return RedirectToAction("Create", "Guitar");
        }

        [Authorize(Roles = "Admin,Employee")]
        public ActionResult NewFing()
        {

            return View();
        }

        [HttpPost]
        [Authorize(Roles = "Admin,Employee")]
        public ActionResult NewFing(GoFing viewModel)
        {
            var fing = new GoFing
            {
                FingId = viewModel.FingId,
                FingName = viewModel.FingName
            };
            _dbContext.GoFing.Add(fing);
            _dbContext.SaveChanges();
            return RedirectToAction("Create", "Guitar");
        }
        [Authorize(Roles = "Admin,Employee")]
        public ActionResult NewSupplier()
        {
            return View();
        }
        [Authorize(Roles = "Admin,Employee")]
        [HttpPost]
        public ActionResult NewSupplier (Supplier viewModel )
        {
            var supp = new Supplier
            {
                SuppId = viewModel.SuppId,
                SuppName = viewModel.SuppName,
                SuppEmail = viewModel.SuppEmail,
                SuppPhone = viewModel.SuppPhone,
                SuppWeb = viewModel.SuppWeb,
                SuppAddr = viewModel.SuppAddr
            };
            _dbContext.Supplier.Add(supp);
            _dbContext.SaveChanges();
            return RedirectToAction("Create", "Guitar");
        }
        [Authorize(Roles = "Admin,Employee")]
        public ActionResult NewBrand()
        {
            var viewModel = new SupplierViewModel
            {
                SuppIds = _dbContext.Supplier.ToList()
            };
            return View(viewModel);
        }
        [Authorize(Roles = "Admin,Employee")]
        [HttpPost]
        public ActionResult NewBrand(SupplierViewModel viewModel)
        {
            var brand = new Brand()
            {
                BrandId = viewModel.BrandId,
                BrandName=viewModel.BrandName,
                SuppId=viewModel.SupplierId
            };
            _dbContext.Brand.Add(brand);
            _dbContext.SaveChanges();
            //a.Open();
            //string y = string.Format("insert into dbo.Brands values('{0}','{1}','{2}')",
            //    viewModel.BrandId,
            //    viewModel.BrandName.ToString(),
            //    viewModel.SupplierId.ToString());
            //SqlCommand x = new SqlCommand(y, a);
            //x.ExecuteNonQuery();
            //a.Close();
            return RedirectToAction("Create", "Guitar");
        }
    }
}