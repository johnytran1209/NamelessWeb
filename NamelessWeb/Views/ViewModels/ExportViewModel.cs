using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NamelessWeb.Views.ViewModels
{
    public class ExportViewModel
    {
        public int Bid { get; set; }
        public string ImageLink { get; set; }
        public string Product { get; set; }
        public float Cost { get; set; }
        public string CusName { get; set; }
        public string BillDes { get; set; }
        public DateTime BillDate { get; set; }
        public string EmployeeName { get; set; }
        public string EmployeephoneNo { get; set; }
    }
}