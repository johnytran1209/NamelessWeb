using NamelessWeb.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NamelessWeb.Controllers
{
    public class QuanLyLichLamViecController : Controller
    {
        private ApplicationDbContext dbContext;
        SqlConnection connect = new SqlConnection(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=NamelessWeb;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
        public QuanLyLichLamViecController() {
            dbContext = new ApplicationDbContext();
        }
        // GET: QuanLyLichLamViec
        [Authorize]
        public ActionResult QuanLyLichLamViec()
        {
            var danhSachLichLamViec = dbContext.DangKyLichLamViec.ToList();
            return View("QuanLyLichLamViec",danhSachLichLamViec);
        }
        [Authorize]
        [HttpPost]
        public ActionResult QuanLyLichLamViec(IList<LichLamViecModel> danhSachLichLamViec) 
        {
            for (int i = 0; i < danhSachLichLamViec.Count(); i++)
            {
                LichLamViecModel lichLamViec = danhSachLichLamViec.ElementAt(i);
                string stringSQL = string.Format("update dbo.LichLamViecModels set sang2='{0}',sang3='{1}',sang4='{2}',sang5='{3}',sang6='{4}',sang7='{5}',sangCN='{6}',chieu2='{7}',chieu3='{8}',chieu4='{9}',chieu5='{10}',chieu6='{11}',chieu7='{12}',chieuCN='{13}',userName='{14}',confirmed='{15}' where idLich='{16}'", lichLamViec.sang2, lichLamViec.sang3, lichLamViec.sang4, lichLamViec.sang5, lichLamViec.sang6, lichLamViec.sang7, lichLamViec.sangCN, lichLamViec.chieu2, lichLamViec.chieu3, lichLamViec.chieu4, lichLamViec.chieu5, lichLamViec.chieu6, lichLamViec.chieu7, lichLamViec.chieuCN, lichLamViec.userName, true, lichLamViec.idLich);
                    connect.Open();
                    SqlCommand commandSQL = new SqlCommand(stringSQL, connect);
                    commandSQL.ExecuteNonQuery();
        }
                return RedirectToAction("Index", "Home");   
        }
    }
}