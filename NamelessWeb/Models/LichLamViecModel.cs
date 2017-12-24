using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace NamelessWeb.Models
{
    public class LichLamViecModel
    {
        [Key]
        public String idLich { get; set; }
        public String idUser { get; set; }
        public String userName { get; set; }
        public bool sang2 { get; set; }
        public bool sang3 { get; set; }
        public bool sang4 { get; set; }
        public bool sang5 { get; set; }
        public bool sang6 { get; set; }
        public bool sang7 { get; set; }
        public bool sangCN { get; set; }
        public bool chieu2 { get; set; }
        public bool chieu3 { get; set; }
        public bool chieu4 { get; set; }
        public bool chieu5 { get; set; }
        public bool chieu6 { get; set; }
        public bool chieu7 { get; set; }
        public bool chieuCN { get; set; }
        public bool confirmed { get; set; }
        public string heading { get; set; }
        public string action {
            get { return (idLich !=null) ? "CapNhatLichLamViec" : "DangKyLichLamViec"; }
        }
    }
}