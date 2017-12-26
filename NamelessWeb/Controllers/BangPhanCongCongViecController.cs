using NamelessWeb.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NamelessWeb.Controllers
{
    public class BangPhanCongCongViecController : Controller
    {
        private readonly ApplicationDbContext dbContext;
        SqlConnection connect = new SqlConnection(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=NamelessWeb;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
        public BangPhanCongCongViecController()
        {
            dbContext = new ApplicationDbContext();
        }

        // GET: BangPhanCongCongViec
        public ActionResult BangPhanCongCongViec()
        {
            DanhSachLichLamViec danhSachDangKyViewModel=new DanhSachLichLamViec();
            var danhSachDangKy = dbContext.DangKyLichLamViec.ToList();
            for (int i = 0; i < danhSachDangKy.Count(); i++) {
                var lichLamViec = new BangPhanCongViewModel()
                {
                    idBangPhanCong = danhSachDangKy.ElementAt(i).idUser + "BPCCV",
                    idUser = danhSachDangKy.ElementAt(i).idUser,
                    userName = danhSachDangKy.ElementAt(i).userName,
                    sang2 = danhSachDangKy.ElementAt(i).sang2,
                    sang3 = danhSachDangKy.ElementAt(i).sang2,
                    sang4 = danhSachDangKy.ElementAt(i).sang2,
                    sang5 = danhSachDangKy.ElementAt(i).sang2,
                    sang6 = danhSachDangKy.ElementAt(i).sang2,
                    sang7 = danhSachDangKy.ElementAt(i).sang2,
                    sangCN = danhSachDangKy.ElementAt(i).sang2,
                    chieu2 = danhSachDangKy.ElementAt(i).chieu2,
                    chieu3 = danhSachDangKy.ElementAt(i).chieu3,
                    chieu4 = danhSachDangKy.ElementAt(i).chieu4,
                    chieu5 = danhSachDangKy.ElementAt(i).chieu5,
                    chieu6 = danhSachDangKy.ElementAt(i).chieu6,
                    chieu7 = danhSachDangKy.ElementAt(i).chieu7,
                    chieuCN = danhSachDangKy.ElementAt(i).chieuCN,
                    thu2 = false,
                    thu3 = false,
                    thu4 = false,
                    thu5 = false,
                    thu6 = false,
                    thu7 = false,
                    thuCN = false    
                };
                danhSachDangKyViewModel.danhSachLichlamViec.Add(lichLamViec);
                
            }
            return View("BangPhanCongCongViec",danhSachDangKyViewModel);
        }
        [HttpPost]
        public ActionResult BangPhanCongCongViec(DanhSachLichLamViec danhSachLichLamViec) {
            for (int i = 0; i < danhSachLichLamViec.danhSachLichlamViec.Count(); i++)
            {
                BangPhanCongViewModel bangPhanCongViewModel = danhSachLichLamViec.danhSachLichlamViec.ElementAt(i);
                var bangPhanCongCongViec = new BangPhanCongCongViec()
                {
                    idBangPhanCong = bangPhanCongViewModel.idBangPhanCong,
                    idUser = bangPhanCongViewModel.idUser,
                    thoigian = DateTime.Now.ToString(),
                    sang2 = false,
                    sang3 = false,
                    sang4 = false,
                    sang5 = false,
                    sang6 = false,
                    sang7 = false,
                    sangCN = false,
                    chieu2 = false,
                    chieu3 = false,
                    chieu4 = false,
                    chieu5 = false,
                    chieu6 = false,
                    chieu7 = false,
                    chieuCN = false,
                };
                if (bangPhanCongViewModel.thu2 == true)
                {
                    bangPhanCongCongViec.sang2 = bangPhanCongViewModel.sang2;
                    bangPhanCongCongViec.chieu2 = bangPhanCongViewModel.chieu2;
                }
                if (bangPhanCongViewModel.thu3 == true)
                {
                    bangPhanCongCongViec.sang3 = bangPhanCongViewModel.sang3;
                    bangPhanCongCongViec.chieu3 = bangPhanCongViewModel.chieu3;
                }
                if (bangPhanCongViewModel.thu4 == true)
                {
                    bangPhanCongCongViec.sang4 = bangPhanCongViewModel.sang4;
                    bangPhanCongCongViec.chieu4 = bangPhanCongViewModel.chieu4;
                }
                if (bangPhanCongViewModel.thu5 == true)
                {
                    bangPhanCongCongViec.sang5 = bangPhanCongViewModel.sang4;
                    bangPhanCongCongViec.chieu5 = bangPhanCongViewModel.chieu4;
                }
                if (bangPhanCongViewModel.thu6 == true)
                {
                    bangPhanCongCongViec.sang6 = bangPhanCongViewModel.sang4;
                    bangPhanCongCongViec.chieu6 = bangPhanCongViewModel.chieu4;
                }
                if (bangPhanCongViewModel.thu7 == true)
                {
                    bangPhanCongCongViec.sang7 = bangPhanCongViewModel.sang4;
                    bangPhanCongCongViec.chieu7 = bangPhanCongViewModel.chieu4;
                }
                if (bangPhanCongViewModel.thuCN == true)
                {
                    bangPhanCongCongViec.sangCN = bangPhanCongViewModel.sang4;
                    bangPhanCongCongViec.chieuCN = bangPhanCongViewModel.chieu4;
                }
                if (dbContext.BangPhanCongCongViec.Count(c => c.idUser == bangPhanCongViewModel.idUser) < 0)
                {
                    dbContext.BangPhanCongCongViec.Add(bangPhanCongCongViec);
                    dbContext.SaveChanges();
                    return RedirectToAction("BangPhanCongCongViec", "BangPhanCongViec");
                }
                else
                {
                    connect.Open();
                    String stringSQL = string.Format("update dbo.BangPhanCongCongViecs set idBangPhanCong='{0}',idUser='{1}',thoigian='{2}',sang2='{3}',sang3='{4}',sang4='{5}',sang5='{6}',sang6='{7}',sang7='{8}',sangCN='{9}',chieu2='{10}',chieu3='{11}' ,chieu4='{12}',chieu5='{13}',chieu6='{14}',chieu7='{15}',chieuCN='{16}'",
                        bangPhanCongCongViec.idBangPhanCong, bangPhanCongCongViec.idUser, bangPhanCongCongViec.thoigian,
                        bangPhanCongCongViec.sang2, bangPhanCongCongViec.sang3, bangPhanCongCongViec.sang4, bangPhanCongCongViec.sang5
                        , bangPhanCongCongViec.sang6, bangPhanCongCongViec.sang7, bangPhanCongCongViec.sangCN, bangPhanCongCongViec.chieu2
                        , bangPhanCongCongViec.chieu3, bangPhanCongCongViec.chieu4, bangPhanCongCongViec.chieu5, bangPhanCongCongViec.chieu6
                        , bangPhanCongCongViec.chieu5, bangPhanCongCongViec.chieuCN);
                    SqlCommand sqlCommand = new SqlCommand(stringSQL, connect);
                    sqlCommand.ExecuteNonQuery();
                    return RedirectToAction("BangPhanCongCongViec", "BangPhanCongCongViec");
                }
            }
            return RedirectToAction("BangPhanCongCongViec", "BangPhanCongCongViec");
            
        }
    }
}