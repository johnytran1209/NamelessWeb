using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NamelessWeb.Models
{
    public class DanhSachLichLamViec
    {
        ApplicationDbContext dbContext = new ApplicationDbContext();
        public List<BangPhanCongViewModel> danhSachLichlamViec { get; set; }

        public DanhSachLichLamViec()
        {
            
        }
    }
}