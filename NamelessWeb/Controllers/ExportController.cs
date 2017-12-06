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
                "select g.ImageLink1, d.Product, d.Cost, b.ExpCus, b.ExpDes, b.ExpDate, u.FullName,u.PhoneNumber from AspNetUsers U, ExportBills B, ExpBillDetails D, Guitars G where d.GuitarId = g.GuitarId and b.ExpBId = d.ExpBId and b.ExpEmpid = u.Id", a);
            SqlDataAdapter da = new SqlDataAdapter(x);
            da.Fill(dt2);
            return View(dt2);
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