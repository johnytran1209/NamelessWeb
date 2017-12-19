using Microsoft.AspNet.Identity;
using NamelessWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NamelessWeb.Controllers
{
    public class DangKyLichLamViecController : Controller
    {
        private readonly ApplicationDbContext dbContext;
        public DangKyLichLamViecController() {
            dbContext = new ApplicationDbContext();
        }
        // GET: DangKyLichLamViec
        public ActionResult DangKyLichLamViec()
        {
            return View(new LichLamViecModel { heading="add schedule"});
        }
        [HttpPost]
        [Authorize]
        public ActionResult DangKyLichLamViec(LichLamViecModel lichLamViec)
        {
            string userId = User.Identity.GetUserId();
            lichLamViec.idUser = userId;
            lichLamViec.idLich = userId +"_"+ DateTime.Now.ToString();
            lichLamViec.confirmed = false;
            dbContext.DangKyLichLamViec.Add(lichLamViec);
            dbContext.SaveChanges();
            return RedirectToAction("Index", "Home"); 
        }
        //Cập nhật lịch làm việc
        [Authorize]
        public ActionResult CapNhatLichLamViec() {
            LichLamViecModel lichLamViec = dbContext.DangKyLichLamViec.Single(c => c.idUser.CompareTo(User.Identity.GetUserId())==0);
            lichLamViec.heading = "edit schedule";
            return View("DangKyLichLamViec",lichLamViec);
        }
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CapNhatLichLamViec(LichLamViecModel lichLamViec)
        {
            var lichtemp = dbContext.DangKyLichLamViec.Single(c => c.idLich.CompareTo(lichLamViec.idLich)==0);
            lichtemp = lichLamViec;
            dbContext.SaveChanges();
            return RedirectToAction("Index", "Home");
        }
      

    }
}