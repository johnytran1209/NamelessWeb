using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace NamelessWeb.Models.Bills.Imports
{
    public class ImpBillDetail
    {
        [Key]
        public string ImpBId { get; set; }
        public string Model { get; set; }
        public float ImpCost { get; set; }
        public string ImpEmp { get; set; }
    }
}