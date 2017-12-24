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
using System.Net;
using Microsoft.AspNet.Identity;

namespace NamelessWeb.Controllers
{
    public class ExportController : Controller
    {

        //SqlConnection a = new SqlConnection(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=NamelessWeb;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
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
            DataTable table = new DataTable();
            DataColumn column;
            DataRow row;

            column = new DataColumn()
            {
                DataType = Type.GetType("System.Int32"),
                ColumnName = "ExpBillId"
            };
            column = new DataColumn
            {
                DataType = Type.GetType("System.String"),
                ColumnName = "Imagelink"
            };
            table.Columns.Add(column);

            column = new DataColumn
            {
                DataType = Type.GetType("System.String"),
                ColumnName = "Product"
            };
            table.Columns.Add(column);
            column = new DataColumn
            {
                DataType = Type.GetType("System.String"),
                ColumnName = "Cost"
            };
            table.Columns.Add(column);

            column = new DataColumn
            {
                DataType = Type.GetType("System.String"),
                ColumnName = "ExpCus"
            };
            table.Columns.Add(column);

            column = new DataColumn
            {
                DataType = Type.GetType("System.String"),
                ColumnName = "ExpDes"
            };
            table.Columns.Add(column);

            column = new DataColumn
            {
                DataType = Type.GetType("System.DateTime"),
                ColumnName = "ExpDate"
            };
            table.Columns.Add(column);

            column = new DataColumn
            {
                DataType = Type.GetType("System.String"),
                ColumnName = "ExpEmp"
            };
            table.Columns.Add(column);

            column = new DataColumn
            {
                DataType = Type.GetType("System.String"),
                ColumnName = "PhoneNumber"
            };
            table.Columns.Add(column);

            if (_DbContext.ExportBill.ToList().Count() != 0)
            {
                int l = _DbContext.ExportBill.ToList().Last().ExpBId;
                int f = _DbContext.ExportBill.ToList().First().ExpBId;
                for (int i = f; i <= l; i++)
                {
                    row = table.NewRow();
                    var exp = _DbContext.ExportBill.Single(c => c.ExpBId == i);
                    row["ExpId"] = exp.ExpBId;
                    var expdet = _DbContext.ExpBillDetail.Single(c => c.ExpBId == exp.ExpBId);
                    var guit = _DbContext.Guitars.Single(c => c.GuitarId == expdet.GuitarId);
                    row["ImageLink"] = guit.GuitarId;
                    row["Product"] = expdet.Product;
                    row["Cost"] = expdet.Cost;
                    row["ExpCus"] = exp.ExpCus;
                    row["ExpDes"] = exp.ExpDes;
                    row["ExpDate"] = exp.ExpDate;
                    row["ExpEmp"] = _DbContext.Users.Single(c => c.Id == exp.ExpEmpId).FullName;
                    row["PhoneNumber"] = _DbContext.Users.Single(c => c.Id == exp.ExpEmpId).PhoneNumber;
                    table.Rows.Add(row);
                }
            }
            //a.Open();
            //SqlCommand x = new SqlCommand("" +
            //    "select b.ExpBId,g.ImageLink1, d.Product, d.Cost, b.ExpCus, b.ExpDes, b.ExpDate, u.FullName,u.PhoneNumber from AspNetUsers U, ExportBills B, ExpBillDetails D, Guitars G where d.GuitarId = g.GuitarId and b.ExpBId = d.ExpBId and b.ExpEmpid = u.Id", a);
            //SqlDataAdapter da = new SqlDataAdapter(x);
            //da.Fill(dt2);
            return View(table);
        }
        [Authorize(Roles = "Admin, Employee")]
        public ActionResult WListEdit(int? id)
        {
            //a.Open();
            var exp = _DbContext.ExportBill.Single(c => c.ExpBId == id);
            var expdet = _DbContext.ExpBillDetail.Single(c => c.ExpBId == exp.ExpBId);
            var guitar = _DbContext.Guitars.Single(c => c.GuitarId == expdet.GuitarId);
            var user = _DbContext.Users.Single(c => c.Id == exp.ExpEmpId);
            string z = string.Format("select b.ExpBId,g.ImageLink1, d.Product, d.Cost, b.ExpCus, b.ExpDes, b.ExpDate, u.FullName,u.PhoneNumber from AspNetUsers U, ExportBills B, ExpBillDetails D, Guitars G where d.GuitarId = g.GuitarId and b.ExpBId = d.ExpBId and b.ExpEmpid = u.Id and b.ExpBId='{0}'", id);
            //SqlCommand x = new SqlCommand(z, a);
            //SqlDataAdapter da = new SqlDataAdapter(x);
            //da.Fill(dt2);
            var viewModel = new ExportViewModel
            {
                Bid = exp.ExpBId,
                ImageLink = guitar.ImageLink1,
                Product = expdet.Product,
                Cost = expdet.Cost,
                CusName = exp.ExpCus,
                BillDes = exp.ExpDes,
                BillDate = exp.ExpDate,
                EmployeeName = user.FullName,
                EmployeephoneNo = user.PhoneNumber
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
                var exp = _DbContext.ExportBill.Single(c => c.ExpBId == viewModel.Bid);
                exp.ExpDes = viewModel.BillDes;
                _DbContext.SaveChanges();
                //a.Open();
                //string y = string.Format("update dbo.ExportBills set ExpDes='{0}'where ExpBId='{1}'", viewModel.BillDes, viewModel.Bid);
                //SqlCommand x = new SqlCommand(y, a);
                //x.ExecuteNonQuery();
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

            DataTable table = new DataTable();
            DataColumn column;
            DataRow row;

            column = new DataColumn
            {
                DataType = Type.GetType("System.String"),
                ColumnName = "Imagelink"
            };
            table.Columns.Add(column);

            column = new DataColumn
            {
                DataType = Type.GetType("System.String"),
                ColumnName = "Product"
            };
            table.Columns.Add(column);

            column = new DataColumn
            {
                DataType = Type.GetType("System.String"),
                ColumnName = "Cost"
            };
            table.Columns.Add(column);

            column = new DataColumn
            {
                DataType = Type.GetType("System.String"),
                ColumnName = "ExpCus"
            };
            table.Columns.Add(column);

            column = new DataColumn
            {
                DataType = Type.GetType("System.String"),
                ColumnName = "ExpDes"
            };
            table.Columns.Add(column);

            column = new DataColumn
            {
                DataType = Type.GetType("System.DateTime"),
                ColumnName = "ExpDate"
            };
            table.Columns.Add(column);

            column = new DataColumn
            {
                DataType = Type.GetType("System.String"),
                ColumnName = "ExpEmp"
            };
            table.Columns.Add(column);

            column = new DataColumn
            {
                DataType = Type.GetType("System.String"),
                ColumnName = "ExpPhoneNumber"
            };
            table.Columns.Add(column);
            column = new DataColumn
            {
                DataType = Type.GetType("System.String"),
                ColumnName = "GuitarIdr"
            };
            table.Columns.Add(column);
            //Imagelink,product,cost,expcus,expdes,expdate,fullname,phonenumber, guitarid
            //a.Open();
            //string z = string.Format("select g.ImageLink1, d.Product, d.Cost, b.ExpCus, b.ExpDes, b.ExpDate, u.FullName,u.PhoneNumber, D.GuitarId from AspNetUsers U, ExportBills B, ExpBillDetails D, Guitars G where d.GuitarId = g.GuitarId and b.ExpBId = d.ExpBId and b.ExpEmpid = u.Id and b.ExpCusId='{0}'", User.Identity.GetUserId());
            //SqlCommand x = new SqlCommand(z, a);
            //SqlDataAdapter da = new SqlDataAdapter(x);
            var explist = _DbContext.ExportBill.ToList();
            if (explist.Select(c=>c.ExpCusId).Contains(User.Identity.GetUserId()))
            {
                int l = _DbContext.ExportBill.Where(c=> c.ExpCusId==User.Identity.GetUserId()).ToList().Last().ExpBId;
                int f = _DbContext.ExportBill.Where(c => c.ExpCusId == User.Identity.GetUserId()).ToList().First().ExpBId;
                for (int i = f; i <= l; i++)
                {
                   
                    var exp = _DbContext.ExportBill.Single(c => c.ExpCusId == User.Identity.GetUserId());
                    var expdet = _DbContext.ExpBillDetail.Single(c => c.ExpBId == exp.ExpBId);
                    var guit = _DbContext.Guitars.Single(c => c.GuitarId == expdet.GuitarId);

                    row = table.NewRow();
                    row["ImageLink"] = guit.GuitarId;
                    row["Product"] = expdet.Product;
                    row["Cost"] = expdet.Cost;
                    row["ExpCus"] = exp.ExpCus;
                    row["ExpDes"] = exp.ExpDes;
                    row["ExpDate"] = exp.ExpDate;
                    row["ExpEmp"] = _DbContext.Users.Single(c => c.Id == exp.ExpEmpId).FullName;
                    row["ExpPhoneNumber"] = _DbContext.Users.Single(c => c.Id == exp.ExpEmpId).PhoneNumber;
                    row["ExpGuitarId"] = guit.GuitarId;
                    table.Rows.Add(row);
                }
                return View(table);
            }
            return View();
        }

        [Authorize]
        public ActionResult Rating(int id)
        {
            try
            {
                var guitar = _DbContext.Guitars.Single(c => c.GuitarId == id);
                var user = _DbContext.Users.Single(c => c.Id == User.Identity.GetUserId());
                //int b = id;
                //string z = string.Format("select g.ImageLink1, g.MDL, g.GuitarId from Guitars g where g.GuitarId ='{0}'",b);
                //SqlCommand x = new SqlCommand(z, a);
                //SqlDataAdapter da = new SqlDataAdapter(x);
                //da.Fill(dt1);

                var viewModel = new GuitarRatingViewModel()
                {
                    feedId = -1,
                    guitarid = id,
                    guitarimg = guitar.ImageLink1,
                    username = user.FullName,
                    guitarmdl = guitar.MDL,
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
                //a.Open();
                //string g = string.Format("select count(*) from GuitarRatings G");
                //SqlCommand y = new SqlCommand(g, a);
                //SqlDataAdapter da = new SqlDataAdapter(y);
                //da.Fill(dt2);

                //string h = string.Format("select  FullName from AspNetUsers where Id='{0}'", User.Identity.GetUserId());
                //SqlCommand w = new SqlCommand(h, a);
                //SqlDataAdapter db = new SqlDataAdapter(w);
                //db.Fill(dt1);
                //string name = dt1.Rows[0][0].ToString();
                //int c = int.Parse(dt2.Rows[0][0].ToString());
                //    string z = string.Format("insert into dbo.GuitarRatings values('{0}','{1}','{2}','{3}','{4}')", c, viewModel.guitarid, name, viewModel.stars, viewModel.GuitarMess);
                //    SqlCommand x = new SqlCommand(z, a);
                //    x.ExecuteNonQuery();
                //    a.Close();
                var rate = new GuitarRating() { CusName = viewModel.username, Stars = viewModel.stars, GuitarId = viewModel.guitarid, FeedMes = viewModel.GuitarMess };
                _DbContext.GuitarRating.Add(rate);
                _DbContext.SaveChanges();
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
            //a.Open();
            //string g = string.Format("select  g.FeedId, g.FeedMes,g.CusName,g.Stars from GuitarRatings G where g.GuitarId='{0}'", id);
            //SqlCommand y = new SqlCommand(g, a);
            //SqlDataAdapter da = new SqlDataAdapter(y);
            //da.Fill(dt2);

            //string h = string.Format("select MDL,ImageLink1 from Guitars where GuitarId='{0}'", id);
            //SqlCommand w = new SqlCommand(h, a);
            //SqlDataAdapter db = new SqlDataAdapter(w);
            //db.Fill(dt1);
            var feed = _DbContext.GuitarRating.Single(c => c.GuitarId == id);
            var guitar = _DbContext.Guitars.Single(c => c.GuitarId == id);
            var user = _DbContext.Users.Single(c => c.Id == User.Identity.GetUserId());
            var viewModel = new GuitarRatingViewModel
            {
                feedId = feed.FeedId,
                guitarid = id,
                GuitarMess = feed.FeedMes,
                stars = feed.Stars,
                username = user.FullName,
                guitarimg = guitar.ImageLink1,
                guitarmdl = guitar.MDL,
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
            try
            {
                var rate = _DbContext.GuitarRating.Single(c => c.FeedId == viewModel.feedId);
                rate.FeedMes = viewModel.GuitarMess;
                rate.Stars = viewModel.stars;
                _DbContext.SaveChanges();
                //a.Open();
                //string z = string.Format("update dbo.GuitarRatings set FeedMes='{0}', Stars='{1}' where FeedId='{2}'", viewModel.GuitarMess, viewModel.stars, viewModel.feedId);
                //    SqlCommand x = new SqlCommand(z, a);
                //    x.ExecuteNonQuery();
                //    a.Close();
                return RedirectToAction("Clist", "Export");
            }
            catch
            {
                return RedirectToAction("Clist", "Export");
            }
        }

    }
}