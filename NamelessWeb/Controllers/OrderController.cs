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
    public class OrderController : Controller
    {
        SqlConnection a = new SqlConnection(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=NamelessWeb;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
        DataTable dt2 = new DataTable();
        private ApplicationDbContext _DbContext;
        public OrderController()
        {
            _DbContext = new ApplicationDbContext();
        }
        // GET: Order
        [Authorize(Roles = "Admin, Employee")]

        public ActionResult List()
        {
            var guitar = _DbContext.Reservation.ToList();
            a.Open();
            SqlCommand x = new SqlCommand("" +
                "select G.GuitarId,G.MDL,G.ImageLink1, U.FullName, u.Email,U.Address, u.PhoneNumber, r.DateReserve from Guitars G, AspNetUsers U, Reservations R where G.GuitarId = R.GuitarId and R.UserId = U.Id", a);
            SqlDataAdapter da = new SqlDataAdapter(x);
            da.Fill(dt2);
            return View(dt2);
        }
        public ActionResult Index()
        {
            return View();
        }
    }
}