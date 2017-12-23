using NamelessWeb.Models;
using NamelessWeb.Models.Guitar;
using NamelessWeb.Views.ViewModels;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Net;
using Microsoft.AspNet.Identity;


namespace NamelessWeb.Controllers
{
    public class GuitarController : Controller
    {
        //SqlConnection a = new SqlConnection(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=NamelessWeb;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
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

            if (viewModel.ImageLink1 == null)
            {
                viewModel.ImageLink1 = "";
            }
            if (viewModel.ImageLink2 == null)
            {
                viewModel.ImageLink2 = "";
            }
            if (viewModel.ImageLink3 == null)
            {
                viewModel.ImageLink3 = "";
            }
            if (viewModel.ImageLink4 == null)
            {
                viewModel.ImageLink4 = "";
            }
            if (viewModel.ImageLink5 == null)
            {
                viewModel.ImageLink5 = "";
            }
            if (viewModel.ImageLink6 == null)
            {
                viewModel.ImageLink6 = "";
            }
            if (viewModel.VideoLink == null)
            {
                viewModel.VideoLink = "";
            }
            
            //int c = _DbContext.Guitars.ToList().Count();
            //int b = 0;
            //viewModel.GuitarId = b;
            //for (int i = 0; i < c; i++)
            //{
            //    var gui = _DbContext.Guitars.Single(m => m.GuitarId == i);
            //        if (gui==null)
            //        {
            //            b = i;
            //            break;
            //        }
            //        c = i + 1;   
            //}
            var guitar = new Guitars
            {
                GuitarId = viewModel.GuitarId,
                MDL = viewModel.GuitarModel,
                BrandId = viewModel.BrandId
             ,
                Availability = 0,
                ELE = viewModel.Electricfied,
                TypeId = viewModel.TypeId,
                MSRP = viewModel.Price,
                WarrId = viewModel.Insurance
             ,
                ImageLink1 = viewModel.ImageLink1,
                ImageLink2 = viewModel.ImageLink2,
                ImageLink3 = viewModel.ImageLink3
             ,
                ImageLink4 = viewModel.ImageLink4,
                ImageLink5 = viewModel.ImageLink5,
                ImageLink6 = viewModel.ImageLink6
             ,
                Videolink = viewModel.VideoLink
            };
            var guitarspec = new GuitarSpecs()
            {
                GuitarId = viewModel.GuitarId,
                TopId = viewModel.Top,
                SideId = viewModel.Side
                ,
                BackId = viewModel.Back,
                FingId = viewModel.Back,
                NeckId = viewModel.Neck,
                Descript = viewModel.Description
            };
            _DbContext.Guitars.Add(guitar);
            _DbContext.GuitarSpecs.Add(guitarspec);
            _DbContext.SaveChanges();
            return RedirectToAction("Index", "Home");

            //try
            //{
            //    var content = _DbContext.Guitars.ToList();
            //    int b = content.Count();
            //    a.Open();
            //    SqlCommand x = new SqlCommand("" +
            //        "select * from Guitars", a);
            //    SqlDataReader danhsachtam = x.ExecuteReader();
            //    dt2.Load(danhsachtam);
            //    a.Close();
            //    for (int i = 0; i < content.Count; i++)
            //    {
            //        for (int j = i + 1; j < content.Count; j++)
            //        {
            //            if (int.Parse((dt2.Rows[j][0]).ToString()) != int.Parse((dt2.Rows[i][0]).ToString()) + 1)
            //            {
            //                b = int.Parse((dt2.Rows[i][0]).ToString()) + 1;
            //                break;
            //                //goto done;
            //            }
            //            b = j + 1;

            //        }
            //    }
            //    a.Open();
            //    string y = string.Format("insert into dbo.Guitars values('{0}','{1}','{2}','{3}','{4}','{5}','{6}','0','{7}','{8}','{9}','{10}','{11}','{12}','{13}')",
            //        b,
            //        viewModel.GuitarModel.ToString(),
            //        viewModel.BrandId.ToString(),
            //        viewModel.TypeId.ToString(),
            //        viewModel.Price,
            //        viewModel.Electricfied,
            //        viewModel.Insurance,
            //        viewModel.ImageLink1,
            //        viewModel.ImageLink2,
            //        viewModel.ImageLink3,
            //        viewModel.ImageLink4,
            //        viewModel.ImageLink5,
            //        viewModel.ImageLink6,
            //        viewModel.VideoLink
            //        );

            //    SqlCommand vaoguitar = new SqlCommand(y, a);
            //    string z = string.Format("insert into dbo.GuitarSpecs values('{0}','{1}','{2}','{3}','{4}','{5}','{6}')",
            //        b,
            //        viewModel.Top.ToString(),
            //        viewModel.Side.ToString(),
            //        viewModel.Back.ToString(),
            //        viewModel.Neck.ToString(),
            //        viewModel.Fing.ToString(),
            //        viewModel.Description.ToString());
            //    SqlCommand u = new SqlCommand(z, a);
            //    vaoguitar.ExecuteNonQuery();
            //    u.ExecuteNonQuery();
            //    a.Close();
            //}
            //catch (Exception)
            //{
            //    return View("create", viewModel);
            //}
            //return RedirectToAction("Index", "Home");
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
            //try
            //{
                //a.Open();
                var guitar = _DbContext.Guitars.Single(c => c.GuitarId == id);
                var guitarspec = _DbContext.GuitarSpecs.Single(c => c.GuitarId == id);
                var brand = _DbContext.Brand.Where(c => c.BrandId == guitar.BrandId).Single().BrandName;
                var type = _DbContext.GuitarType.Where(c => c.TypeId == guitar.TypeId).Single().TypeName;
                var insurance = _DbContext.Warranty.Where(c => c.WarrId == guitar.WarrId).Single().WarrLength;
                var top = _DbContext.GoTop.Where(c => c.TopId == guitarspec.TopId).Single().TopName;
                var side = _DbContext.GoSide.Where(c => c.SideId == guitarspec.SideId).Single().SideName;
                var back = _DbContext.GoBack.Where(c => c.BackId == guitarspec.BackId).Single().BackName;
                var neck = _DbContext.GoNeck.Where(c => c.NeckId == guitarspec.NeckId).Single().NeckName;
                var fing = _DbContext.GoFing.Where(c => c.FingId == guitarspec.FingId).Single().FingName;
            //SqlCommand x = new SqlCommand("" +
            //    "select G.BrandName, T.TypeName,GT.TopName,GS.SideName,GB.BackName,GN.NeckName,GF.FingName,W.WarrLength " +
            //    "from dbo.Brands G, dbo.GuitarTypes T, dbo.GoTops GT, dbo.GoSides GS, dbo.GoBacks GB, dbo.GoNecks GN, dbo.GoFings GF,dbo.Warranties W " +
            //    "where G.BrandId='" + guitar.BrandId + "' and T.TypeId='" + guitar.TypeId + "' and GT.TopId = '" + guitarspec.TopId + "' and GS.SideId = '" + guitarspec.SideId + "' and GB.BackId = '" + guitarspec.BackId + "' and GN.NeckId = '" + guitarspec.NeckId + "' and GF.FingId = '" + guitarspec.FingId + "' and W.WarrId = '" + guitar.WarrId + "'", a);
            //SqlDataReader b = x.ExecuteReader();
            //dt2.Load(b);
            //var list = _DbContext.GuitarRating.ToList();
            //string Try = list.Single(c => c.GuitarId == guitar.GuitarId).GuitarId.ToString();
            //var rating = _DbContext.GuitarRating.Single(c => c.GuitarId==guitar.GuitarId);
            var rating = _DbContext.GuitarRating.Select(c => c.GuitarId).ToList();
            
            if (guitar.Availability==2)
                {
                     if (rating.Contains(guitar.GuitarId))
                     {
                        var feed = _DbContext.GuitarRating.Single(c => c.GuitarId == id);
                        var viewModel2 = new GuitarViewModel
                        {
                        GuitarId = id,
                        GuitarModel = guitar.MDL,
                        BrandName = brand.ToString(),
                        TypeName = type.ToString(),
                        Price = guitar.MSRP,
                        Electricfied = guitar.ELE,
                        InsuranceName = insurance.ToString(),
                        ImageLink1 = guitar.ImageLink1,
                        ImageLink2 = guitar.ImageLink2,
                        ImageLink3 = guitar.ImageLink3,
                        ImageLink4 = guitar.ImageLink4,
                        ImageLink5 = guitar.ImageLink5,
                        ImageLink6 = guitar.ImageLink6,
                        VideoLink = guitar.Videolink,
                        Availability = guitar.Availability,
                        TopName = top.ToString(),
                        SideName = side.ToString(),
                        BackName = back.ToString(),
                        NeckName = neck.ToString(),
                        FingsName = fing.ToString(),
                        Description = guitarspec.Descript,
                        Id = guitarspec.GuitarId,
                        customername = feed.CusName,
                        point = feed.Stars,
                        feedback = feed.FeedMes
                        };
                        //a.Close();
                        return View("Details", viewModel2);
                    }
                else
                {
                    var viewModel2 = new GuitarViewModel
                    {
                        GuitarId = id,
                        GuitarModel = guitar.MDL,
                        BrandName = brand.ToString(),
                        TypeName = type.ToString(),
                        Price = guitar.MSRP,
                        Electricfied = guitar.ELE,
                        InsuranceName = insurance.ToString(),
                        ImageLink1 = guitar.ImageLink1,
                        ImageLink2 = guitar.ImageLink2,
                        ImageLink3 = guitar.ImageLink3,
                        ImageLink4 = guitar.ImageLink4,
                        ImageLink5 = guitar.ImageLink5,
                        ImageLink6 = guitar.ImageLink6,
                        VideoLink = guitar.Videolink,
                        Availability = guitar.Availability,
                        TopName = top.ToString(),
                        SideName = side.ToString(),
                        BackName = back.ToString(),
                        NeckName = neck.ToString(),
                        FingsName = fing.ToString(),
                        Description = guitarspec.Descript,
                        Id = guitarspec.GuitarId
                    };
                    return View("Details", viewModel2);
                }
                    
                
                }
                var viewModel = new GuitarViewModel
                {
                    GuitarId = id,
                    GuitarModel = guitar.MDL,
                    BrandName = brand.ToString(),
                    TypeName = type.ToString(),
                    Price = guitar.MSRP,
                    Electricfied = guitar.ELE,
                    InsuranceName = insurance.ToString(),
                    ImageLink1 = guitar.ImageLink1,
                    ImageLink2 = guitar.ImageLink2,
                    ImageLink3 = guitar.ImageLink3,
                    ImageLink4 = guitar.ImageLink4,
                    ImageLink5 = guitar.ImageLink5,
                    ImageLink6 = guitar.ImageLink6,
                    VideoLink = guitar.Videolink,
                    Availability = guitar.Availability,
                    TopName = top.ToString(),
                    SideName = side.ToString(),
                    BackName = back.ToString(),
                    NeckName = neck.ToString(),
                    FingsName = fing.ToString(),
                    Description = guitarspec.Descript,
                    Id = guitarspec.GuitarId
                };
                return View("Details", viewModel);
            //}
            //catch
            //{
            //    return RedirectToAction("Index", "Home");
            //}
        }

        [HttpPost]
        [Authorize]
        public ActionResult Details(GuitarViewModel viewModel)
        {
            //var content = _DbContext.Reservation.Where(n => n.GuitarId==viewModel.Id).ToList();
            //if (content.Count == 0)
            //{
            //    try
            //    {
            var rese = new Reservations()
            {
                DateReserve = DateTime.Now,
                GuitarId = viewModel.GuitarId,
                UserId = User.Identity.GetUserId()
            };
           
            var guit = _DbContext.Guitars.Single(c => c.GuitarId == viewModel.GuitarId);
            guit.Availability = 1;
            _DbContext.Reservation.Add(rese);
            _DbContext.SaveChanges();
                    //a.Open();
                    //string z = string.Format("insert into dbo.Reservations values('{0}','{1}',CURRENT_TIMESTAMP)",
                    //    User.Identity.GetUserId(),
                    //    viewModel.Id);
                    //SqlCommand u = new SqlCommand(z, a);
                    //string x = string.Format("update dbo.Guitars set Availability='1' where GuitarId='{0}'",viewModel.GuitarId);
                    //SqlCommand y = new SqlCommand(x, a);
                    //u.ExecuteNonQuery();
                    //y.ExecuteNonQuery();
                    //a.Close();
                    return RedirectToAction("Index", "Home");
            //    }
            //    catch (Exception)
            //    {
            //        return RedirectToAction("Home", "Index");
            //    }
            //}
            //return RedirectToAction("Home", "Index");

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
            //    return View("Create", viewModel);
            //}
            var userId = User.Identity.GetUserId();
            var guitar = _DbContext.Guitars.Single(c => c.GuitarId == viewModel.GuitarId);

            guitar.MDL = viewModel.GuitarModel.ToString();
            guitar.BrandId = viewModel.BrandId.ToString();
            guitar.TypeId = viewModel.TypeId.ToString();
            guitar.MSRP = viewModel.Price;
            guitar.ELE = viewModel.Electricfied;
            guitar.WarrId = viewModel.Insurance;
            guitar.ImageLink1 = viewModel.ImageLink1;
            guitar.ImageLink2 = viewModel.ImageLink2;
            guitar.ImageLink3 = viewModel.ImageLink3;
            guitar.ImageLink4 = viewModel.ImageLink4;
            guitar.ImageLink5 = viewModel.ImageLink5;
            guitar.ImageLink6 = viewModel.ImageLink6;
            guitar.Videolink = viewModel.VideoLink;
            guitar.GuitarId = viewModel.GuitarId;

            var guitarspec = _DbContext.GuitarSpecs.Single(c => c.GuitarId == viewModel.GuitarId);
            guitarspec.TopId = viewModel.Top;
            guitarspec.SideId = viewModel.Side;
            guitarspec.BackId = viewModel.Back;
            guitarspec.NeckId = viewModel.Neck;
            guitarspec.FingId = viewModel.Fing;
            guitarspec.Descript = viewModel.Description;

            _DbContext.SaveChanges();
            return RedirectToAction("List", "Guitar");
            //try
            //{
            //    a.Open();
            //    string y = string.Format("update dbo.guitars set MDL='{0}', BrandId='{1}', TypeId='{2}',MSRP='{3}',ELE='{4}',WarrId='{5}',ImageLink1='{6}',ImageLink2='{7}',ImageLink3='{8}',ImageLink4='{9}',ImageLink5='{10}',ImageLink6='{11}',VideoLink='{12}',Availability='0'  where GuitarId='{13}'",

            //        viewModel.GuitarModel.ToString(),
            //        viewModel.BrandId.ToString(),
            //        viewModel.TypeId.ToString(),
            //        viewModel.Price,
            //        viewModel.Electricfied,
            //        viewModel.Insurance,
            //        viewModel.ImageLink1,
            //        viewModel.ImageLink2,
            //        viewModel.ImageLink3,
            //        viewModel.ImageLink4,
            //        viewModel.ImageLink5,
            //        viewModel.ImageLink6,
            //        viewModel.VideoLink,
            //        viewModel.Id);
            //    SqlCommand x = new SqlCommand(y, a);
            //    x.ExecuteNonQuery();
            //    string z = string.Format("update dbo.GuitarSpecs set TopId='{0}',SideId='{1}',BackId='{2}', NeckId='{3}', FingId='{4}', Descript='{5}' where GuitarId='{6}'",
            //        viewModel.Top.ToString(),
            //        viewModel.Side.ToString(),
            //        viewModel.Back.ToString(),
            //        viewModel.Neck.ToString(),
            //        viewModel.Fing.ToString(),
            //        viewModel.Description.ToString(),
            //        viewModel.Id);
            //    SqlCommand u = new SqlCommand(z, a);                
            //    u.ExecuteNonQuery();
            //    a.Close();
            //    return RedirectToAction("List", "Guitar");
            //}
            //catch
            //{
            //    return RedirectToAction("List", "Guitar");
            //}

        }



        [Authorize(Roles = "Admin")]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            try
            {
                //a.Open();
                int b = int.Parse(id.ToString());
                var guitar = _DbContext.Guitars.Single(c => c.GuitarId == id);
                var guitarspec = _DbContext.GuitarSpecs.Single(c => c.GuitarId == id);
                var brand = _DbContext.Brand.Where(c => c.BrandId == guitar.BrandId).Single().BrandName;
                var type = _DbContext.GuitarType.Where(c => c.TypeId == guitar.TypeId).Single().TypeName;
                var insurance = _DbContext.Warranty.Where(c => c.WarrId == guitar.WarrId).Single().WarrLength;
                var top = _DbContext.GoTop.Where(c => c.TopId == guitarspec.TopId).Single().TopName;
                var side = _DbContext.GoSide.Where(c => c.SideId == guitarspec.SideId).Single().SideName;
                var back = _DbContext.GoBack.Where(c => c.BackId == guitarspec.BackId).Single().BackName;
                var neck = _DbContext.GoNeck.Where(c => c.NeckId == guitarspec.NeckId).Single().NeckName;
                var fing = _DbContext.GoFing.Where(c => c.FingId == guitarspec.FingId).Single().FingName;
                //SqlCommand x = new SqlCommand("" +
                //                              "select G.BrandName, T.TypeName,GT.TopName,GS.SideName,GB.BackName,GN.NeckName,GF.FingName,W.WarrLength " +
                //                              "from dbo.Brands G, dbo.GuitarTypes T, dbo.GoTops GT, dbo.GoSides GS, dbo.GoBacks GB, dbo.GoNecks GN, dbo.GoFings GF,dbo.Warranties W " +
                //                              "where G.BrandId='" + guitar.BrandId + "' and T.TypeId='" + guitar.TypeId + "' and GT.TopId = '" + guitarspec.TopId + "' and GS.SideId = '" + guitarspec.SideId + "' and GB.BackId = '" + guitarspec.BackId + "' and GN.NeckId = '" + guitarspec.NeckId + "' and GF.FingId = '" + guitarspec.FingId + "' and W.WarrId = '" + guitar.WarrId + "'", a);
                //SqlDataReader b = x.ExecuteReader();
                //dt2.Load(b);
                var viewModel = new GuitarViewModel
                {
                    GuitarId = b,
                    GuitarModel = guitar.MDL,
                    BrandName = brand,
                    TypeName = type,
                    Price = guitar.MSRP,
                    Electricfied = guitar.ELE,
                    InsuranceName = insurance.ToString(),
                    ImageLink1 = guitar.ImageLink1,
                    ImageLink2 = guitar.ImageLink2,
                    ImageLink3 = guitar.ImageLink3,
                    ImageLink4 = guitar.ImageLink4,
                    ImageLink5 = guitar.ImageLink5,
                    ImageLink6 = guitar.ImageLink6,
                    VideoLink = guitar.Videolink,
                    Availability = guitar.Availability,
                    TopName = top.ToString(),
                    SideName = side.ToString(),
                    BackName = back.ToString(),
                    NeckName = neck.ToString(),
                    FingsName = fing.ToString(),
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