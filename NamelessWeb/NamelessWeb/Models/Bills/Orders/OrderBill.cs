using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace NamelessWeb.Models.Bills.Orders
{
    public class OrderBill
    {
        [Key]
        public string OrdBId { get; set; }
        public DateTime OrdDate { get; set; }
        public string OrdEmp { get; set; }
    }
}