using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace NamelessWeb.Models.Bills.Exports
{
    public class ExpBillDetail
    {
        [Key]
        public string ExpBId { get; set; }
        public string Model { get; set; }
        public float Cost { get; set; }
        public string ExpEmp { get; set; }
    }
}