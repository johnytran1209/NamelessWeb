using NamelessWeb.Models;
using NamelessWeb.Models.Guitar;
using NamelessWeb.Models.WebSystem;
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
    public class ExportController : Controller
    {

        SqlConnection a = new SqlConnection(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=NamelessWeb;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
        DataTable dt2 = new DataTable();
        DataTable dt1 = new DataTable();
        private ApplicationDbContext _DbContext;

        // GET: Export
        public ActionResult Index()
        {
            return View();
        }
        [Authorize(Roles = "Admin, Employee")]
        public ActionResult WList()
        {
            a.Open();
            SqlCommand x = new SqlCommand("" +
                "select b.ExpBId,g.ImageLink1, d.Product, d.Cost, b.ExpCus, b.ExpDes, b.ExpDate, u.FullName,u.PhoneNumber from AspNetUsers U, ExportBills B, ExpBillDetails D, Guitars G where d.GuitarId = g.GuitarId and b.ExpBId = d.ExpBId and b.ExpEmpid = u.Id", a);
            SqlDataAdapter da = new SqlDataAdapter(x);
            da.Fill(dt2);
            return View(dt2);
        }
        [Authorize(Roles = "Admin, Employee")]
        public ActionResult WListEdit(int? id)
        {
            a.Open();
            string z = string.Format("select b.ExpBId,g.ImageLink1, d.Product, d.Cost, b.ExpCus, b.ExpDes, b.ExpDate, u.FullName,u.PhoneNumber from AspNetUsers U, ExportBills B, ExpBillDetails D, Guitars G where d.GuitarId = g.GuitarId and b.ExpBId = d.ExpBId and b.ExpEmpid = u.Id and b.ExpBId='{0}'", id);
            SqlCommand x = new SqlCommand(z, a);
            SqlDataAdapter da = new SqlDataAdapter(x);
            da.Fill(dt2);
            var viewModel = new ExportViewModel
            {
                Bid = Int16.Parse(dt2.Rows[0][0].ToString()),
                ImageLink = dt2.Rows[0][1].ToString(),
                Product = dt2.Rows[0][2].ToString(),
                Cost = float.Parse(dt2.Rows[0][3].ToString()),
                CusName = dt2.Rows[0][4].ToString(),
                BillDes = dt2.Rows[0][5].ToString(),
                BillDate = DateTime.Parse(dt2.Rows[0][6].ToString()),
                EmployeeName = dt2.Rows[0][7].ToString(),
                EmployeephoneNo = dt2.Rows[0][8].ToString()
            };
            return View(viewModel);
        }
        [Authorize(Roles = "Admin, Employee")]
        [HttpPost, ActionName("WListEdit")]
        [ValidateAntiForgeryToken]
        public ActionResult WListEdit(ExportViewModel viewModel)
        {
            try
            {
                a.Open();
                string y = string.Format("update dbo.ExportBills set ExpDes='{0}'where ExpBId='{1}'", viewModel.BillDes, viewModel.Bid);
                SqlCommand x = new SqlCommand(y, a);
                x.ExecuteNonQuery();
                return RedirectToAction("WList", "Export");
            }
            catch
            {
                return RedirectToAction("WList", "Export");
            }

        }
        [Authorize]
        public ActionResult Clist()
        {
            a.Open();
            string z = string.Format("select g.ImageLink1, d.Product, d.Cost, b.ExpCus, b.ExpDes, b.ExpDate, u.FullName,u.PhoneNumber, D.GuitarId from AspNetUsers U, ExportBills B, ExpBillDetails D, Guitars G where d.GuitarId = g.GuitarId and b.ExpBId = d.ExpBId and b.ExpEmpid = u.Id and b.ExpCusId='{0}'", User.Identity.GetUserId());
            SqlCommand x = new SqlCommand(z, a);
            SqlDataAdapter da = new SqlDataAdapter(x);
            da.Fill(dt2);
            return View(dt2);
        }

        [Authorize]
        public ActionResult Rating(int id)
        {
            try
            {
                
                int b = id;
                string z = string.Format("select g.ImageLink1, g.MDL, g.GuitarId from Guitars g where g.GuitarId ='{0}'",b);
                SqlCommand x = new SqlCommand(z, a);
                SqlDataAdapter da = new SqlDataAdapter(x);
                da.Fill(dt1);

                var viewModel = new GuitarRatingViewModel()
                {
                    feedId = -1,
                    guitarid = b,
                    guitarimg = dt1.Rows[0][0].ToString(),
                    username = User.Identity.GetUserName(),
                    guitarmdl=dt1.Rows[0][1].ToString(),
                    heading = "Giving Feed Back"
                };
               return View(viewModel);
             }
            catch
            {
                return RedirectToAction("Index", "Home");
            }
}

        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(GuitarRatingViewModel viewModel)
        {
            try
            {

                a.Open();
            string g = string.Format("select count(*) from GuitarRatings G");
            SqlCommand y = new SqlCommand(g, a);
            SqlDataAdapter da = new SqlDataAdapter(y);
            da.Fill(dt2);

            string h = string.Format("select  FullName from AspNetUsers where Id='{0}'", User.Identity.GetUserId());
            SqlCommand w = new SqlCommand(h, a);
            SqlDataAdapter db = new SqlDataAdapter(w);
            db.Fill(dt1);
            string name = dt1.Rows[0][0].ToString();
            int c = int.Parse(dt2.Rows[0][0].ToString());
                string z = string.Format("insert into dbo.GuitarRatings values('{0}','{1}','{2}','{3}','{4}')", c, viewModel.guitarid, name, viewModel.stars, viewModel.GuitarMess);
                SqlCommand x = new SqlCommand(z, a);
                x.ExecuteNonQuery();
                a.Close();
                return RedirectToAction("Clist", "Export");
            }
            catch
            {
                return RedirectToAction("Clist", "Export");
            }
        }
        [Authorize]
        public ActionResult Update(int id)
        {
            //try
            //{
            a.Open();
            string g = string.Format("select  g.FeedId, g.FeedMes,g.CusName,g.Stars from GuitarRatings G where g.GuitarId='{0}'", id);
            SqlCommand y = new SqlCommand(g, a);
            SqlDataAdapter da = new SqlDataAdapter(y);
            da.Fill(dt2);

            string h = string.Format("select MDL,ImageLink1 from Guitars where GuitarId='{0}'", id);
            SqlCommand w = new SqlCommand(h, a);
            SqlDataAdapter db = new SqlDataAdapter(w);
            db.Fill(dt1);
            var viewModel = new GuitarRatingViewModel
            {
                    feedId = int.Parse(dt2.Rows[0][0].ToString()),
                    guitarid = id,
                    GuitarMess = dt2.Rows[0][1].ToString(),
                    stars = int.Parse(dt2.Rows[0][3].ToString()),
                    username = dt2.Rows[0][2].ToString(),
                    guitarimg = dt1.Rows[0][1].ToString(),
                    guitarmdl = dt1.Rows[0][0].ToString(),
                    heading = "Update Feedback"
                };
                return View("Rating", viewModel);
            //}
            //catch
            //{
            //    return RedirectToAction("Clist", "Export");
            //}
        }
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(GuitarRatingViewModel viewModel)
        {
            //try
            //{
            
            a.Open();
            string z = string.Format("update dbo.GuitarRatings set FeedMes='{0}', Stars='{1}' where FeedId='{2}'", viewModel.GuitarMess, viewModel.stars, viewModel.feedId);
                SqlCommand x = new SqlCommand(z, a);
                x.ExecuteNonQuery();
                a.Close();
                return RedirectToAction("Clist", "Export");
            //}
            //catch
            //{
            //    return RedirectToAction("Clist", "Export");
            //}
        }

    }
}