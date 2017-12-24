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
        //khởi tạo cái view
        [Authorize(Roles = "Admin, Employee")]
        public ActionResult Create()
        {
            try
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
                    Heading = "Add new Guitar",
                    GuitarId= -1,
                    Id=-1,
                };
                return View(viewModel);
            }
            catch
            {
                return RedirectToAction("Index", "Home");
            }
        }

        [Authorize(Roles = "Admin, Employee")]
        [HttpPost]
        [ValidateAntiForgeryToken]
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
                // return View("create", viewModel);
            }
            if(viewModel.ImageLink1 == "")
            {
                viewModel.ImageLink1 = "https://scontent.fsgn4-1.fna.fbcdn.net/v/t1.0-9/14322177_1827252967505330_4313197727578070295_n.jpg?_nc_eui2=v1%3AAeFSMHqfkDeFc-RuhMuE0qMvbDqkBiibsnmDR273uJiXNJT0jMCARmkH9Tv59VLc9JsUR0jcSzz6xY3pUo6EfS-1jOUpnKMGKiCB81wRACRurA&oh=e6c4e20566a3420a44ca3f5827165445&oe=5A9C8148";
            }
            if (viewModel.ImageLink2 == "")
            {
                viewModel.ImageLink2 = "https://scontent.fsgn4-1.fna.fbcdn.net/v/t1.0-9/14322177_1827252967505330_4313197727578070295_n.jpg?_nc_eui2=v1%3AAeFSMHqfkDeFc-RuhMuE0qMvbDqkBiibsnmDR273uJiXNJT0jMCARmkH9Tv59VLc9JsUR0jcSzz6xY3pUo6EfS-1jOUpnKMGKiCB81wRACRurA&oh=e6c4e20566a3420a44ca3f5827165445&oe=5A9C8148";
            }
            if (viewModel.ImageLink3 == "")
            {
                viewModel.ImageLink3 = "https://scontent.fsgn4-1.fna.fbcdn.net/v/t1.0-9/14322177_1827252967505330_4313197727578070295_n.jpg?_nc_eui2=v1%3AAeFSMHqfkDeFc-RuhMuE0qMvbDqkBiibsnmDR273uJiXNJT0jMCARmkH9Tv59VLc9JsUR0jcSzz6xY3pUo6EfS-1jOUpnKMGKiCB81wRACRurA&oh=e6c4e20566a3420a44ca3f5827165445&oe=5A9C8148";
            }
            if (viewModel.ImageLink4 == "")
            {
                viewModel.ImageLink4 = "https://scontent.fsgn4-1.fna.fbcdn.net/v/t1.0-9/14322177_1827252967505330_4313197727578070295_n.jpg?_nc_eui2=v1%3AAeFSMHqfkDeFc-RuhMuE0qMvbDqkBiibsnmDR273uJiXNJT0jMCARmkH9Tv59VLc9JsUR0jcSzz6xY3pUo6EfS-1jOUpnKMGKiCB81wRACRurA&oh=e6c4e20566a3420a44ca3f5827165445&oe=5A9C8148";
            }
            if (viewModel.ImageLink5 == "")
            {
                viewModel.ImageLink5 = "https://scontent.fsgn4-1.fna.fbcdn.net/v/t1.0-9/14322177_1827252967505330_4313197727578070295_n.jpg?_nc_eui2=v1%3AAeFSMHqfkDeFc-RuhMuE0qMvbDqkBiibsnmDR273uJiXNJT0jMCARmkH9Tv59VLc9JsUR0jcSzz6xY3pUo6EfS-1jOUpnKMGKiCB81wRACRurA&oh=e6c4e20566a3420a44ca3f5827165445&oe=5A9C8148";
            }
            if (viewModel.ImageLink6 == "")
            {
                viewModel.ImageLink6 = "https://scontent.fsgn4-1.fna.fbcdn.net/v/t1.0-9/14322177_1827252967505330_4313197727578070295_n.jpg?_nc_eui2=v1%3AAeFSMHqfkDeFc-RuhMuE0qMvbDqkBiibsnmDR273uJiXNJT0jMCARmkH9Tv59VLc9JsUR0jcSzz6xY3pUo6EfS-1jOUpnKMGKiCB81wRACRurA&oh=e6c4e20566a3420a44ca3f5827165445&oe=5A9C8148";
            }

            try
            {
                var content = _DbContext.Guitars.ToList();
                int b=content.Count();
                a.Open();
                SqlCommand x = new SqlCommand("" +
                    "select * from Guitars", a);
                SqlDataReader danhsachtam = x.ExecuteReader();
                dt2.Load(danhsachtam);
                a.Close();
                for (int i = 0; i < content.Count; i++)
                {
                    for (int j = i+1;j< content.Count; j++)
                    {
                        if (int.Parse((dt2.Rows[j][0]).ToString()) != int.Parse((dt2.Rows[i][0]).ToString()) + 1)
                        {
                            b = int.Parse((dt2.Rows[i][0]).ToString()) + 1;
                            break;
                            //goto done;
                        }
                        b = j+1;

                    }
                }
                a.Open();
                string y = string.Format("insert into dbo.Guitars values('{0}','{1}','{2}','{3}','{4}','{5}','{6}','0','{7}','{8}','{9}','{10}','{11}','{12}','{13}')",
                    b,
                    viewModel.GuitarModel.ToString(),
                    viewModel.BrandId.ToString(),
                    viewModel.TypeId.ToString(),
                    viewModel.Price,
                    viewModel.Electricfied,
                    viewModel.Insurance,
                    viewModel.ImageLink1,
                    viewModel.ImageLink2,
                    viewModel.ImageLink3,
                    viewModel.ImageLink4,
                    viewModel.ImageLink5,
                    viewModel.ImageLink6,
                    viewModel.VideoLink
                    );
                
                SqlCommand vaoguitar = new SqlCommand(y, a);
                string z = string.Format("insert into dbo.GuitarSpecs values('{0}','{1}','{2}','{3}','{4}','{5}','{6}')",
                    b,
                    viewModel.Top.ToString(),
                    viewModel.Side.ToString(),
                    viewModel.Back.ToString(),
                    viewModel.Neck.ToString(),
                    viewModel.Fing.ToString(),
                    viewModel.Description.ToString());
                SqlCommand u = new SqlCommand(z, a);
                vaoguitar.ExecuteNonQuery();
                u.ExecuteNonQuery();
                a.Close();
            }
            catch (Exception)
            {
                return View("create", viewModel);
            }



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
            //_DbContext.Guitars.Add(guitar);
            //_DbContext.SaveChanges();

            //var guitarSpecs = new GuitarSpecs
            //{

            //    GuitarId = x,
            //    TopId = viewModel.Top,
            //    SideId = viewModel.Side,
            //    BackId = viewModel.Back,
            //    NeckId =viewModel.Neck,
            //    FingId = viewModel.Fing,
            //    Descript = viewModel.Description
            //};
            //_DbContext.GuitarSpecs.Add(guitarSpecs);
            //_DbContext.SaveChanges();

            return RedirectToAction("Index", "Home");          
        }
        public ActionResult Rating()
        {
            return View(_DbContext.GuitarRating.ToList());
        }

        public ActionResult Inventory()
        {
            return View(_DbContext.Guitars.ToList());
        }
        public ActionResult Sold()
        {
            return View(_DbContext.Guitars.ToList());
        }
        public ActionResult Archive()
        {
            return View(_DbContext.Guitars.ToList());
        }

        [Authorize(Roles = "Admin, Employee")]
        public ActionResult List()
        {
            return View(_DbContext.Guitars.ToList());
        }

        [Authorize]
        public ActionResult Details(int id)
        {
            try
            {
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
                    GuitarId = id,
                    GuitarModel = guitar.MDL,
                    BrandName = dt2.Rows[0][0].ToString(),
                    TypeName = dt2.Rows[0][1].ToString(),
                    Price = guitar.MSRP,
                    Electricfied = guitar.ELE,
                    InsuranceName = dt2.Rows[0][7].ToString(),
                    ImageLink1 = guitar.ImageLink1,
                    ImageLink2 = guitar.ImageLink2,
                    ImageLink3 = guitar.ImageLink3,
                    ImageLink4 = guitar.ImageLink4,
                    ImageLink5 = guitar.ImageLink5,
                    ImageLink6 = guitar.ImageLink6,
                    VideoLink=guitar.Videolink,
                    Availability = guitar.Availability,
                    TopName = dt2.Rows[0][2].ToString(),
                    SideName = dt2.Rows[0][3].ToString(),
                    BackName = dt2.Rows[0][4].ToString(),
                    NeckName = dt2.Rows[0][5].ToString(),
                    FingsName = dt2.Rows[0][6].ToString(),
                    Description = guitarspec.Descript,
                    Id = guitarspec.GuitarId
                };
                a.Close();
                return View("Details", viewModel);
            }
            catch
            {
                return RedirectToAction("Index", "Home");
            }
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
                    return RedirectToAction("Index", "Home");
                }
                catch (Exception)
                {
                    return RedirectToAction("Home", "Index");
                }
            }
            return RedirectToAction("Home", "Index");

        }

        [Authorize(Roles = "Admin, Employee")]
        public ActionResult Edit(int id)
        {
            try
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
                    GuitarId = guitar.GuitarId,
                    GuitarModel = guitar.MDL,
                    TypeId = guitar.TypeId,
                    BrandId = guitar.BrandId,
                    Insurance = guitar.WarrId,
                    Price = guitar.MSRP,
                    Electricfied = guitar.ELE,
                    ImageLink1 = guitar.ImageLink1,
                    ImageLink2 = guitar.ImageLink2,
                    ImageLink3 = guitar.ImageLink3,
                    ImageLink4 = guitar.ImageLink4,
                    ImageLink5 = guitar.ImageLink5,
                    ImageLink6 = guitar.ImageLink6,
                    VideoLink=guitar.Videolink,
                    Top = guitarspec.TopId.ToString(),
                    Side = guitarspec.SideId.ToString(),
                    Back = guitarspec.BackId.ToString(),
                    Neck = guitarspec.NeckId.ToString(),
                    Fing = guitarspec.FingId.ToString(),
                    Description = guitarspec.Descript,
                    Heading = "Edit Information",
                    Id = guitar.GuitarId
                };
                return View("Create", viewModel);
            }
            catch
            {
                return RedirectToAction("List", "Guitar");
            }
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
            try
            {
                a.Open();
                string y = string.Format("update dbo.guitars set MDL='{0}', BrandId='{1}', TypeId='{2}',MSRP='{3}',ELE='{4}',WarrId='{5}',ImageLink1='{6}',ImageLink2='{7}',ImageLink3='{8}',ImageLink4='{9}',ImageLink5='{10}',ImageLink6='{11}',VideoLink='{12}',Availability='0'  where GuitarId='{13}'",

                    viewModel.GuitarModel.ToString(),
                    viewModel.BrandId.ToString(),
                    viewModel.TypeId.ToString(),
                    viewModel.Price,
                    viewModel.Electricfied,
                    viewModel.Insurance,
                    viewModel.ImageLink1,
                    viewModel.ImageLink2,
                    viewModel.ImageLink3,
                    viewModel.ImageLink4,
                    viewModel.ImageLink5,
                    viewModel.ImageLink6,
                    viewModel.VideoLink,
                    viewModel.Id);
                SqlCommand x = new SqlCommand(y, a);
                x.ExecuteNonQuery();
                string z = string.Format("update dbo.GuitarSpecs set TopId='{0}',SideId='{1}',BackId='{2}', NeckId='{3}', FingId='{4}', Descript='{5}' where GuitarId='{6}'",
                    viewModel.Top.ToString(),
                    viewModel.Side.ToString(),
                    viewModel.Back.ToString(),
                    viewModel.Neck.ToString(),
                    viewModel.Fing.ToString(),
                    viewModel.Description.ToString(),
                    viewModel.Id);
                SqlCommand u = new SqlCommand(z, a);                
                u.ExecuteNonQuery();
                a.Close();
                return RedirectToAction("List", "Guitar");
            }
            catch
            {
                return RedirectToAction("List", "Guitar");
            }
            
        }



        [Authorize(Roles = "Admin, Employee")]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            try
            {
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
                    ImageLink1 = guitar.ImageLink1,
                    ImageLink2 = guitar.ImageLink2,
                    ImageLink3 = guitar.ImageLink3,
                    ImageLink4 = guitar.ImageLink4,
                    ImageLink5 = guitar.ImageLink5,
                    ImageLink6 = guitar.ImageLink6,
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
            catch
            {
                return RedirectToAction("List", "Guitar");
            }

        }

        [Authorize(Roles = "Admin, Employee")]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            try
            {
                var guitar = _DbContext.Guitars.Single(c => c.GuitarId == id);
                var guitarspec = _DbContext.GuitarSpecs.Single(c => c.GuitarId == id);
                _DbContext.Guitars.Remove(guitar);
                _DbContext.GuitarSpecs.Remove(guitarspec);
                _DbContext.SaveChanges();
                return RedirectToAction("List", "Guitar");
            }
            catch
            {
                return RedirectToAction("List", "Guitar");
            }
            
        }

        public ActionResult Search(FormCollection f, int id = 1)
        {
            string searchtext = f["searchtext"];
            var content = _DbContext.Guitars.Where(n => n.MDL.Contains(searchtext)).ToList();

            return View(content);
        }
       
    }
}