using Microsoft.AspNet.Identity;
using NamelessWeb.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NamelessWeb.Controllers
{
    public class DangKyLichLamViecController : Controller
    {

        private readonly ApplicationDbContext dbContext;
        SqlConnection connect = new SqlConnection(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=NamelessWeb;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
        public DangKyLichLamViecController()
        {
            dbContext = new ApplicationDbContext();
        }
        // GET: DangKyLichLamViec
        [Authorize]
        public ActionResult DangKyLichLamViec()
        {
            var userId = User.Identity.GetUserId();
            if (dbContext.DangKyLichLamViec.Count(l => l.idUser == userId) > 0)
            {
                return RedirectToAction("CapNhatLichLamViec", "DangKyLichLamViec");
            }
            return View(new LichLamViecModel { heading = "add schedule" });
        }

        [HttpPost]
        [Authorize]
        public ActionResult DangKyLichLamViec(LichLamViecModel lichLamViec)
        {
            string userId = User.Identity.GetUserId();
            lichLamViec.idUser = userId;
            lichLamViec.idLich = userId + "_" + DateTime.Now.ToString();
            String userName = User.Identity.GetUserName();
            lichLamViec.userName = userName;
            lichLamViec.confirmed = false;
            dbContext.DangKyLichLamViec.Add(lichLamViec);
            dbContext.SaveChanges();
            return RedirectToAction("Index", "Home");
        }

        //Cập nhật lịch làm việc
        [Authorize]
        public ActionResult CapNhatLichLamViec()
        {
            string userId = User.Identity.GetUserId();
            LichLamViecModel lichLamViec = dbContext.DangKyLichLamViec.Single(c => c.idUser.CompareTo(userId) == 0);
            lichLamViec.heading = "edit schedule";
            return View("DangKyLichLamViec", lichLamViec);
        }

        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        public ActionResult CapNhatLichLamViec(LichLamViecModel lichLamViec)
        {

            string userId = lichLamViec.idUser;
            connect.Open();
            string stringSQL = string.Format("update dbo.LichLamViecModels set sang2='{0}',sang3='{1}',sang4='{2}',sang5='{3}',sang6='{4}',sang7='{5}',sangCN='{6}',chieu2='{7}',chieu3='{8}',chieu4='{9}',chieu5='{10}',chieu6='{11}',chieu7='{12}',chieuCN='{13}',userName='{14}' where idLich='{15}'", lichLamViec.sang2, lichLamViec.sang3, lichLamViec.sang4, lichLamViec.sang5, lichLamViec.sang6, lichLamViec.sang7, lichLamViec.sangCN, lichLamViec.chieu2, lichLamViec.chieu3, lichLamViec.chieu4, lichLamViec.chieu5, lichLamViec.chieu6, lichLamViec.chieu7, lichLamViec.chieuCN, lichLamViec.userName, lichLamViec.idLich);
            SqlCommand commandSQL = new SqlCommand(stringSQL, connect);
            commandSQL.ExecuteNonQuery();
            return RedirectToAction("Index", "Home");
        }


    }
}