using NamelessWeb.Models;
using NamelessWeb.Models.Guitar;
using NamelessWeb.Views.ViewModels;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.SqlClient;
using Microsoft.AspNet.Identity;


namespace NamelessWeb.Controllers
{
    public class GuitarController : Controller
    {
        SqlConnection a = new SqlConnection(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=NamelessWeb;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
        DataTable dt2 = new DataTable();
        private ApplicationDbContext _DbContext;
        public GuitarController()
        {
            _DbContext = new ApplicationDbContext();
        }
        // GET: Guitar
        [Authorize]
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
        [ValidateAntiForgeryToken]
        public ActionResult Create(GuitarViewModel viewModel)
        {
            try
            {
                a.Open();
                string y = string.Format("insert into dbo.Guitars values('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','0')",
                    viewModel.GuitarId,
                    viewModel.GuitarModel.ToString(),
                    viewModel.BrandId.ToString(),
                    viewModel.TypeId.ToString(),
                    viewModel.Price,
                    viewModel.Electricfied,
                    viewModel.Insurance,
                    viewModel.ImageLink);
                SqlCommand x = new SqlCommand(y, a);
                string z = string.Format("insert into dbo.GuitarSpecs values('{0}','{1}','{2}','{3}','{4}','{5}','{6}')",
                    viewModel.GuitarId,
                    viewModel.Top.ToString(),
                    viewModel.Side.ToString(),
                    viewModel.Back.ToString(),
                    viewModel.Neck.ToString(),
                    viewModel.Fing.ToString(),
                    viewModel.Description.ToString());
                SqlCommand u = new SqlCommand(z, a);
                x.ExecuteNonQuery();
                u.ExecuteNonQuery();
                a.Close();
            }
            catch(Exception)
            {
                return View("create", viewModel);
            }
            

            //if (!ModelState.IsValid)
            //{
            //    viewModel.TypeIds = _DbContext.GuitarType.ToList();
            //    viewModel.BrandIds = _DbContext.Brand.ToList();
            //    viewModel.Tops = _DbContext.GoTop.ToList();
            //    viewModel.Sides = _DbContext.GoSide.ToList();
            //    viewModel.Backs = _DbContext.GoBack.ToList();
            //    viewModel.Necks = _DbContext.GoNeck.ToList();
            //    viewModel.Fings = _DbContext.GoFing.ToList();
            //    viewModel.Insurances = _DbContext.Warranty.ToList();
            //   // return View("create", viewModel);
            //}
            //int x = viewModel.GuitarId;
            //var guitar = new Guitars
            //{
            //    GuitarId = x,
            //    MDL = viewModel.GuitarModel,
            //    BrandId = viewModel.BrandId,
            //    TypeId = viewModel.TypeId,
            //    MSRP = viewModel.Price,
            //    ELE = viewModel.Electricfied,
            //    WarrId = viewModel.Insurance,
            //    ImageLink = viewModel.ImageLink
            //};
            //    _DbContext.Guitars.Add(guitar);
            //    _DbContext.SaveChanges();

            //var guitarSpecs = new GuitarSpecs
            //{
            //    GuitarId = 
            //    TopId =    
            //    SideId =   
            //    BackId =   
            //    NeckId =   
            //    FingId =   
            //    Descript = 
            //};
            //_DbContext.GuitarSpecs.Add(guitarSpecs);
            //_DbContext.SaveChanges();

            return RedirectToAction("Index", "Home");          
        }

        [Authorize]
        public ActionResult List()
        {
            return View(_DbContext.Guitars.ToList());
        }

        public ActionResult Details(int id)
        {
            a.Open();
            var guitar = _DbContext.Guitars.Single(c=>c.GuitarId==id);
            var guitarspec = _DbContext.GuitarSpecs.Single(c => c.GuitarId == id);
            SqlCommand x = new SqlCommand("" +
                "select G.BrandName, T.TypeName,GT.TopName,GS.SideName,GB.BackName,GN.NeckName,GF.FingName,W.WarrLength " +
                "from dbo.Brands G, dbo.GuitarTypes T, dbo.GoTops GT, dbo.GoSides GS, dbo.GoBacks GB, dbo.GoNecks GN, dbo.GoFings GF,dbo.Warranties W " +
                "where G.BrandId='"+guitar.BrandId+ "' and T.TypeId='" + guitar.TypeId + "' and GT.TopId = '" + guitarspec.TopId + "' and GS.SideId = '" + guitarspec.SideId + "' and GB.BackId = '" + guitarspec.BackId + "' and GN.NeckId = '" + guitarspec.NeckId + "' and GF.FingId = '" + guitarspec.FingId + "' and W.WarrId = '" + guitar.WarrId + "'", a);
            SqlDataReader b = x.ExecuteReader();
            dt2.Load(b);
            var viewModel = new GuitarViewModel
            {
                GuitarModel = guitar.MDL,
                BrandName = dt2.Rows[0][0].ToString(),
                TypeName = dt2.Rows[0][1].ToString(),
                Price = guitar.MSRP,
                Electricfied = guitar.ELE,
                InsuranceName = dt2.Rows[0][7].ToString(),
                ImageLink = guitar.ImageLink,
                Top = guitarspec.TopId,
                Side = guitarspec.SideId,
                Back = guitarspec.BackId,
                Neck = guitarspec.NeckId,
                Fing = guitarspec.FingId,
                Description = guitarspec.Descript,
                Availability = guitar.Availability
                TopName = dt2.Rows[0][2].ToString(),
                SideName= dt2.Rows[0][3].ToString(),
                BackName= dt2.Rows[0][4].ToString(),
                NeckName= dt2.Rows[0][5].ToString(),
                FingsName= dt2.Rows[0][6].ToString(),
                Description = guitarspec.Descript
            };
            a.Close();
            return View("Details",viewModel);
        }

        [HttpPost]
        [Authorize]
        public ActionResult Details(GuitarViewModel viewModel)
        {
            var reserved = _DbContext.Reservation.Single(c => c.GuitarId == viewModel.GuitarId);
            if (reserved == null)
            {
                try
                {
                    a.Open();
                    string z = string.Format("insert into dbo.Reservations values('{0}','{1}'",
                        User.Identity.GetUserId(),
                        viewModel.GuitarId);
                    SqlCommand u = new SqlCommand(z, a);
                    u.ExecuteNonQuery();
                    a.Close();
                }
                catch (Exception)
                {
                    return View("Details", viewModel);
                }
                return RedirectToAction("Index", "Home");
            }
            return View("Details", viewModel);
        }
    }
}