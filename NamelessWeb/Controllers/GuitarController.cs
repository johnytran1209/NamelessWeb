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
using System.Net;
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
        [Authorize(Roles = "Admin, Employee")]
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
                Insurances = _DbContext.Warranty.ToList(),
                Heading = "Add new Guitar"
            };
            return View(viewModel);
        }

        [Authorize(Roles = "Admin, Employee")]
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

        [Authorize(Roles = "Admin, Employee")]
        public ActionResult List()
        {
            return View(_DbContext.Guitars.ToList());
        }

        [Authorize(Roles = "Admin, Employee")]
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
                GuitarId = id,
                GuitarModel = guitar.MDL,
                BrandName = dt2.Rows[0][0].ToString(),
                TypeName = dt2.Rows[0][1].ToString(),
                Price = guitar.MSRP,
                Electricfied = guitar.ELE,
                InsuranceName = dt2.Rows[0][7].ToString(),
                ImageLink = guitar.ImageLink,
                Availability = guitar.Availability,
                TopName = dt2.Rows[0][2].ToString(),
                SideName= dt2.Rows[0][3].ToString(),
                BackName= dt2.Rows[0][4].ToString(),
                NeckName= dt2.Rows[0][5].ToString(),
                FingsName= dt2.Rows[0][6].ToString(),
                Description = guitarspec.Descript,
                Id=guitarspec.GuitarId
          
            };
            a.Close();
            return View("Details",viewModel);
        }

        [HttpPost]
        [Authorize]
        public ActionResult Details(GuitarViewModel viewModel)
        {
            var content = _DbContext.Reservation.Where(n => n.GuitarId==viewModel.Id).ToList();
            if (content.Count == 0)
            {
                try
                {
                    a.Open();
                    string z = string.Format("insert into dbo.Reservations values('{0}','{1}',CURRENT_TIMESTAMP)",
                        User.Identity.GetUserId(),
                        viewModel.Id);
                    SqlCommand u = new SqlCommand(z, a);
                    string x = string.Format("update dbo.Guitars set Availability='1' where GuitarId='{0}'",viewModel.GuitarId);
                    SqlCommand y = new SqlCommand(x, a);
                    u.ExecuteNonQuery();
                    y.ExecuteNonQuery();
                    a.Close();
                }
                catch (Exception)
                {
                    return View("Details", viewModel);
                }
                return View("Details", viewModel);
            }
            return View("Details", viewModel);

        }

        [Authorize(Roles = "Admin, Employee")]
        public ActionResult Edit(int id)
        {
            var userId = User.Identity.GetUserId();
            var guitar = _DbContext.Guitars.Single(c => c.GuitarId == id);
            var guitarspec = _DbContext.GuitarSpecs.Single(c => c.GuitarId == id);
            var viewModel = new GuitarViewModel
            {
                TypeIds = _DbContext.GuitarType.ToList(),
                BrandIds = _DbContext.Brand.ToList(),
                Tops = _DbContext.GoTop.ToList(),
                Sides = _DbContext.GoSide.ToList(),
                Backs = _DbContext.GoBack.ToList(),
                Necks = _DbContext.GoNeck.ToList(),
                Fings = _DbContext.GoFing.ToList(),
                Insurances = _DbContext.Warranty.ToList(),
                GuitarId=guitar.GuitarId,
                GuitarModel=guitar.MDL,
                TypeId=guitar.TypeId,
                BrandId=guitar.BrandId,
                Insurance=guitar.WarrId,
                Price=guitar.MSRP,
                Electricfied=guitar.ELE,
                ImageLink=guitar.ImageLink,
                Top = guitarspec.TopId.ToString(),
                Side= guitarspec.SideId.ToString(),
                Back=guitarspec.BackId.ToString(),
                Neck=guitarspec.NeckId.ToString(),
                Fing=guitarspec.FingId.ToString(),
                Description=guitarspec.Descript,
                Heading = "Edit Information",
                Id= guitar.GuitarId
            };
            return View("Create",viewModel);
        }

        [Authorize(Roles = "Admin, Employee")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Update(GuitarViewModel viewModel)
        {

            //if(!ModelState.IsValid)
            //{
            //  viewModel.  TypeIds = _DbContext.GuitarType.ToList();
            //  viewModel.  BrandIds = _DbContext.Brand.ToList();
            //  viewModel.  Tops = _DbContext.GoTop.ToList();
            //  viewModel.  Sides = _DbContext.GoSide.ToList();
            //  viewModel.  Backs = _DbContext.GoBack.ToList();
            //  viewModel.Necks = _DbContext.GoNeck.ToList();
            //    viewModel.Fings = _DbContext.GoFing.ToList();
            //    viewModel.Insurances = _DbContext.Warranty.ToList();
            //    return View("Create", viewModel);
            //}
            //var userId = User.Identity.GetUserId();
            //var guitar = _DbContext.Guitars.Single(c => c.GuitarId == viewModel.GuitarId);

            //    guitar.MDL = viewModel.GuitarModel.ToString();
            //    guitar.MDL = viewModel.BrandId.ToString();
            //    guitar.TypeId = viewModel.TypeId.ToString();
            //    guitar.MSRP = viewModel.Price;
            //    guitar.ELE = viewModel.Electricfied;
            //    guitar.WarrId = viewModel.Insurance;
            //    guitar.ImageLink = viewModel.ImageLink;
            //    guitar.GuitarId=viewModel.GuitarId;

            //var guitarspec = _DbContext.GuitarSpecs.Single(c => c.GuitarId == viewModel.GuitarId);
            //guitarspec.TopId = viewModel.Top;
            //    guitarspec.SideId=viewModel.Side;
            //guitarspec.BackId = viewModel.Back;
            //guitarspec.NeckId = viewModel.Neck;
            //guitarspec.FingId = viewModel.Fing;
            //guitarspec.Descript = viewModel.Description;

            //_DbContext.SaveChanges();
            a.Open();
            string y = string.Format("update dbo.guitars set MDL='{0}', BrandId='{1}', TypeId='{2}',MSRP='{3}',ELE='{4}',WarrId='{5}',ImageLink='{6}',Availability='0' where GuitarId='{7}'",

                viewModel.GuitarModel.ToString(),
                viewModel.BrandId.ToString(),
                viewModel.TypeId.ToString(),
                viewModel.Price,
                viewModel.Electricfied,
                viewModel.Insurance,
                viewModel.ImageLink,
                viewModel.GuitarId);
            SqlCommand x = new SqlCommand(y, a);
            string z = string.Format("update dbo.GuitarSpecs set TopId='{0}',SideId='{1}',BackId='{2}', NeckId='{3}', FingId='{4}', Descript='{5}' where GuitarId='{6}'",
                viewModel.Top.ToString(),
                viewModel.Side.ToString(),
                viewModel.Back.ToString(),
                viewModel.Neck.ToString(),
                viewModel.Fing.ToString(),
                viewModel.Description.ToString(),
                viewModel.GuitarId);
            SqlCommand u = new SqlCommand(z, a);
            x.ExecuteNonQuery();
            u.ExecuteNonQuery();
            a.Close();

            return RedirectToAction("List", "Guitar");
            
        }



        [Authorize(Roles = "Admin, Employee")]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            a.Open();
            var guitar = _DbContext.Guitars.Single(c => c.GuitarId == id);
            var guitarspec = _DbContext.GuitarSpecs.Single(c => c.GuitarId == id);
            SqlCommand x = new SqlCommand("" +
                                          "select G.BrandName, T.TypeName,GT.TopName,GS.SideName,GB.BackName,GN.NeckName,GF.FingName,W.WarrLength " +
                                          "from dbo.Brands G, dbo.GuitarTypes T, dbo.GoTops GT, dbo.GoSides GS, dbo.GoBacks GB, dbo.GoNecks GN, dbo.GoFings GF,dbo.Warranties W " +
                                          "where G.BrandId='" + guitar.BrandId + "' and T.TypeId='" + guitar.TypeId + "' and GT.TopId = '" + guitarspec.TopId + "' and GS.SideId = '" + guitarspec.SideId + "' and GB.BackId = '" + guitarspec.BackId + "' and GN.NeckId = '" + guitarspec.NeckId + "' and GF.FingId = '" + guitarspec.FingId + "' and W.WarrId = '" + guitar.WarrId + "'", a);
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
                Availability = guitar.Availability,
                TopName = dt2.Rows[0][2].ToString(),
                SideName = dt2.Rows[0][3].ToString(),
                BackName = dt2.Rows[0][4].ToString(),
                NeckName = dt2.Rows[0][5].ToString(),
                FingsName = dt2.Rows[0][6].ToString(),
                Description = guitarspec.Descript

            };
            a.Close();
            return View("Delete", viewModel);
            
            //string g = string.Format("delete from dbo.Guitars where GuitarId='" + id + "'");
            //SqlCommand y = new SqlCommand(g, a);
            //string d = string.Format("delete from dbo.GuitarSpecs where GuitarId='" + id + "'");
            //SqlCommand v = new SqlCommand(d, a);
            //y.ExecuteNonQuery();
            //v.ExecuteNonQuery();
            ////_DbContext.Guitars.DeleteOnSubmit(guitar);
            ////_DbContext.Guitars.
        }

        [Authorize(Roles = "Admin, Employee")]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            var guitar = _DbContext.Guitars.Single(c => c.GuitarId == id);
            var guitarspec = _DbContext.GuitarSpecs.Single(c => c.GuitarId == id);
            _DbContext.Guitars.Remove(guitar);
            _DbContext.GuitarSpecs.Remove(guitarspec);
            _DbContext.SaveChanges();
            return RedirectToAction("Index", "Home");
        }

        public ActionResult Search(FormCollection f, int id = 1)
        {
            string searchtext = f["searchtext"];
            var content = _DbContext.Guitars.Where(n => n.MDL.Contains(searchtext)).ToList();

            return View(content);
        }
        public ActionResult OrderList()
        {
            var orders = _DbContext.Reservation.ToList();
            foreach(var order in orders)
            {
                var user = _DbContext.Users.Single(c => c.Id == order.UserId);
            }
            return View();
        }
    }
}