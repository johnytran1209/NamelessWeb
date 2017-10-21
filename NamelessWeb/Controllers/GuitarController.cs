using NamelessWeb.Models;
using NamelessWeb.Models.Guitar;
using NamelessWeb.Views.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.SqlClient;


namespace NamelessWeb.Controllers
{
    public class GuitarController : Controller
    {
        SqlConnection a = new SqlConnection(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=NamelessWeb;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
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
                string y = string.Format("insert into dbo.Guitars values('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}')",
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
    }
}