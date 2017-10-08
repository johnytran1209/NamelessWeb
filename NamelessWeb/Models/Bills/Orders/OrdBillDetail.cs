using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace NamelessWeb.Models.Bills.Orders
{
    public class OrdBillDetail
    {
        [Key]
        public string OrdBId { get; set; }
        public string Model { get; set; }
        public int Qtt { get; set; }
        public float OrdCost { get; set; }
        public string OrdEmp { get; set; }
    }
}