 using NamelessWeb.Models;
using NamelessWeb.Models.Guitar;
using NamelessWeb.Views.ViewModels;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;
//using System.Data.SqlClient;
using System.Net;
using Microsoft.AspNet.Identity;
using NamelessWeb.Models.Bills.Exports;

namespace NamelessWeb.Controllers
{
    public class OrderController : Controller
    {
        //SqlConnection a = new SqlConnection(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=NamelessWeb;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
        DataTable dt2 = new DataTable();
        DataTable dt1 = new DataTable();
        private ApplicationDbContext _DbContext;
        public OrderController()
        {
            _DbContext = new ApplicationDbContext();
        }
        // GET: Order
        [Authorize(Roles = "Admin, Employee")]
        public ActionResult List()
        {
            DataTable table = new DataTable();
            DataColumn column;
            DataRow row;

            column = new DataColumn()
            {
                DataType = Type.GetType("System.Int32"),
                ColumnName = "Guitarid"
            };
            
            table.Columns.Add(column);

            column = new DataColumn
            {
                DataType = Type.GetType("System.String"),
                ColumnName = "MDL"
            };
            table.Columns.Add(column);

            column = new DataColumn
            {
                DataType = Type.GetType("System.String"),
                ColumnName = "Imagelink"
            };
            table.Columns.Add(column);

            column = new DataColumn
            {
                DataType = Type.GetType("System.String"),
                ColumnName = "FullName"
            };
            table.Columns.Add(column);

            column = new DataColumn
            {
                DataType = Type.GetType("System.String"),
                ColumnName = "Email"
            };
            table.Columns.Add(column);

            column = new DataColumn
            {
                DataType = Type.GetType("System.String"),
                ColumnName = "Address"
            };
            table.Columns.Add(column);

            column = new DataColumn
            {
                DataType = Type.GetType("System.String"),
                ColumnName = "PhoneNumber"
            };
            table.Columns.Add(column);

            column = new DataColumn
            {
                DataType = Type.GetType("System.DateTime"),
                ColumnName = "Date"
            };
            table.Columns.Add(column);
            if(_DbContext.Reservation.ToList().Count()!=0)
            {
                int l = _DbContext.Reservation.ToList().Last().No;
                int f = _DbContext.Reservation.ToList().First().No;
                for (int i = f; i <= l; i++)
                {
                    row = table.NewRow();
                    var rese = _DbContext.Reservation.Single(c => c.No == i);
                    row["GuitarId"] = rese.GuitarId;
                    row["Date"] = rese.DateReserve;
                    var guit = _DbContext.Guitars.Single(c => c.GuitarId == rese.GuitarId);
                    row["MDL"] = guit.MDL;
                    row["ImageLink"] = guit.ImageLink1;
                    var use = _DbContext.Users.Single(c => c.Id == rese.UserId);
                    row["FullName"] = use.FullName;
                    row["Email"] = use.Email;
                    row["Address"] = use.Address;
                    row["PhoneNumber"] = use.PhoneNumber;
                    table.Rows.Add(row);
                }
            }
            
            else
            {
                table = null;
            }
            

            //a.Open();
            //SqlCommand x = new SqlCommand("" +
            //    "select G.GuitarId,G.MDL,G.ImageLink1, U.FullName, u.Email,U.Address, u.PhoneNumber, r.DateReserve from Guitars G, AspNetUsers U, Reservations R where G.GuitarId = R.GuitarId and R.UserId = U.Id", a);
            //SqlDataAdapter da = new SqlDataAdapter(x);
            //da.Fill(dt2);
            return View(table);
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
                //a.Open();
                var guitar = _DbContext.Guitars.Single(c => c.GuitarId == id);
                var guitarspec = _DbContext.GuitarSpecs.Single(c => c.GuitarId == id);
                var brand = _DbContext.Brand.Single(c => c.BrandId == guitar.BrandId);
                var insu = _DbContext.Warranty.Single(c => c.WarrId == guitar.WarrId);
                var date = _DbContext.Reservation.Single(c => c.GuitarId == id);
                var use = _DbContext.Users.Single(c => c.Id == date.UserId);
                //SqlCommand x = new SqlCommand("select U.FullName, u.Email,U.Address, u.PhoneNumber, r.DateReserve from Guitars G, AspNetUsers U, Reservations R where G.GuitarId = R.GuitarId and R.UserId = U.Id", a);
                //SqlDataReader b = x.ExecuteReader();
                //dt2.Load(b);
                var viewModel = new OrderViewModel
                {
                    GuitarId = guitar.GuitarId,
                    GuitarModel = guitar.MDL,
                    BrandName = brand.BrandName,
                    Price = guitar.MSRP,
                    InsuranceName = insu.WarrLength.ToString(),
                    Imagelink1 = guitar.ImageLink1,
                    BuyerName = use.FullName,
                    Email = use.Email,
                    Phone = use.PhoneNumber,
                    Address = use.Address,
                    DateReserve = date.DateReserve
                };
                //a.Close();
                return View("Delete", viewModel);
            }
            catch
            {
                return RedirectToAction("List", "Order");
            }
        }
        [Authorize(Roles = "Admin, Employee")]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        { 
            var reserve = _DbContext.Reservation.Single(c => c.GuitarId == id);
            _DbContext.Reservation.Remove(reserve);
            _DbContext.SaveChanges();
            var guitar = _DbContext.Guitars.Single(c => c.GuitarId == id);
            guitar.Availability = 0;
            _DbContext.SaveChanges();
            //string z = string.Format("Update Guitars set Availability='0' where GuitarId='{0}'", id);               
            //SqlCommand u = new SqlCommand(z, a);
            return RedirectToAction("List", "Order");
        }
        [Authorize(Roles = "Admin, Employee")]
        public ActionResult Proceed(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            
            try
            {
                var rese = _DbContext.Reservation.Single(c => c.GuitarId == id);

                if(User.Identity.GetUserId()==rese.UserId && User.IsInRole("Employee"))
                {
                    return RedirectToAction("List", "Order");
                }
                //a.Open();
                var guitar = _DbContext.Guitars.Single(c => c.GuitarId == id);
                var guitarspec = _DbContext.GuitarSpecs.Single(c => c.GuitarId == id);
                var brand = _DbContext.Brand.Single(c => c.BrandId == guitar.BrandId);
                var insu = _DbContext.Warranty.Single(c => c.WarrId == guitar.WarrId);
                var use = _DbContext.Users.Single(c=>c.Id==rese.UserId);
                //SqlCommand x = new SqlCommand("select U.FullName, u.Email,U.Address, u.PhoneNumber, r.DateReserve from Guitars G, AspNetUsers U, Reservations R where G.GuitarId = R.GuitarId and R.UserId = U.Id", a);
                //SqlDataReader b = x.ExecuteReader();
                //dt2.Load(b);
                var viewModel = new OrderViewModel
                {
                    GuitarId = guitar.GuitarId,
                    GuitarModel = guitar.MDL,
                    BrandName = brand.BrandName,
                    Price = guitar.MSRP,
                    InsuranceName = insu.WarrLength.ToString(),
                    Imagelink1 = guitar.ImageLink1,
                    BuyerName = use.FullName,
                    Email = use.Email,
                    Phone = use.PhoneNumber,
                    Address = use.Address,
                    DateReserve = rese.DateReserve
                };
                //a.Close();
                return View("Proceed", viewModel);
            }
            catch
            {
                return RedirectToAction("List", "Order");
            }
        }
        [Authorize(Roles = "Admin, Employee")]
        [HttpPost, ActionName("Proceed")]
        [ValidateAntiForgeryToken]
        public ActionResult ProceedConfirmed(OrderViewModel viewModel)
        {
            //try
            //{
                int id = viewModel.GuitarId;
                var date = _DbContext.Reservation.Single(c => c.GuitarId == id);
                var exp = _DbContext.ExportBill.ToList();
                int expcount = exp.Count();
                string newo = viewModel.Des.ToString();
                var guitar = _DbContext.Guitars.Single(c => c.GuitarId == id);
                var brand = _DbContext.Brand.Single(c => c.BrandId == guitar.BrandId);
                var use = _DbContext.Users.Single(c => c.Id == date.UserId);

                //a.Open();
                //string gc = string.Format("select b.BrandName,G.MDL, G.MSRP from Guitars G ,Brands B where g.BrandId=b.BrandId and g.GuitarId='{0}'", viewModel.GuitarId);
                //SqlCommand y = new SqlCommand(gc, a);
                //SqlDataReader d = y.ExecuteReader();
                //dt1.Load(d);
                var expdetail = new ExpBillDetail()
                {
                    //ExpBId=expcount,
                    GuitarId = id,
                    Cost =guitar.MSRP,
                    Product=string.Format(""+brand.BrandName+ " " + guitar.MDL)
                };
                //string z = string.Format("insert into ExpBillDetails values ('{0}','{1}','{2} {3}',{4})", expcount, dt1.Rows[0][2].ToString(), dt1.Rows[0][0].ToString(), dt1.Rows[0][1].ToString(), viewModel.GuitarId);
                //SqlCommand vaoexpbilldet = new SqlCommand(z, a);
                //vaoexpbilldet.ExecuteNonQuery();

                //string bc = string.Format("select U.FullName, u.Email, U.Address, u.PhoneNumber, r.DateReserve from AspNetUsers U, Reservations R where  R.UserId = U.Id and R.userId = '{0}'", date.UserId);
                //SqlCommand x = new SqlCommand(bc, a);
                //SqlDataReader b = x.ExecuteReader();
                //dt2.Load(b);
                var user2 = User.Identity.GetUserId();
            //var user1 = _DbContext.Users.Single(c=>c.Id=user2.)

            var expbill = new ExportBill()
            {
                //ExpBId = expcount,
                ExpDate = DateTime.Now,
                ExpCus = use.FullName,
                ExpCusId = date.UserId,
                ExpEmp = _DbContext.Users.Single(c => c.Id == user2).FullName,
                ExpEmpId = User.Identity.GetUserId(),
                ExpDes = String.Format("Customer Email:" + use.Email + "\n Customer Phone number:" + use.PhoneNumber + "\n Extra" + viewModel.Des)
                };
                //string ab = string.Format("insert into ExportBills values ('{0}',CURRENT_TIMESTAMP,'{1}','{2}','{3}','{4}',
                //'Customer Email:{5} Customer Phone number:{6} Additional Information: {7}')", expcount, User.Identity.GetUserName(), dt2.Rows[0][0].ToString(), User.Identity.GetUserId(), date.UserId.ToString(), dt2.Rows[0][1].ToString(), dt2.Rows[0][3].ToString(), newo);
                //SqlCommand vaoexpbill = new SqlCommand(ab, a);
                //vaoexpbill.ExecuteNonQuery();

                //string zu = string.Format("Update Guitars set Availability='2' where GuitarId='{0}'", viewModel.GuitarId);
                //SqlCommand cd = new SqlCommand(zu, a);
                //cd.ExecuteNonQuery();

                //a.Close();
                guitar.Availability = 2;
                _DbContext.ExpBillDetail.Add(expdetail);
                _DbContext.SaveChanges();
                _DbContext.ExportBill.Add(expbill);
                _DbContext.SaveChanges();
                _DbContext.Reservation.Remove(date);
                _DbContext.SaveChanges();
                return RedirectToAction("List", "Order");
            //}
            //catch
            //{
            //    return RedirectToAction("List", "Order");
            //}        
        }

        public ActionResult Index()
        {
            return View();
        }
    }
}