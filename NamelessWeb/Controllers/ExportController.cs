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
                ImageLink= dt2.Rows[0][1].ToString(),
                Product= dt2.Rows[0][2].ToString(),
                Cost= float.Parse(dt2.Rows[0][3].ToString()),
                CusName= dt2.Rows[0][4].ToString(),
                BillDes= dt2.Rows[0][5].ToString(),
                BillDate= DateTime.Parse(dt2.Rows[0][6].ToString()),
                EmployeeName= dt2.Rows[0][7].ToString(),
                EmployeephoneNo=dt2.Rows[0][8].ToString()
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
                string y = string.Format("update dbo.ExportBills set ExpDes='{0}'where ExpBId='{1}'",viewModel.BillDes,viewModel.Bid);
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
            string z = string.Format("select g.ImageLink1, d.Product, d.Cost, b.ExpCus, b.ExpDes, b.ExpDate, u.FullName,u.PhoneNumber from AspNetUsers U, ExportBills B, ExpBillDetails D, Guitars G where d.GuitarId = g.GuitarId and b.ExpBId = d.ExpBId and b.ExpEmpid = u.Id and b.ExpCusId='{0}'", User.Identity.GetUserId());
            SqlCommand x = new SqlCommand(z,a);
            SqlDataAdapter da = new SqlDataAdapter(x);
            da.Fill(dt2);
            return View(dt2);
        }

    }
}