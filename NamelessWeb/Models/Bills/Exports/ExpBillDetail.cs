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
        [Required]
        public string Product { get; set; }
        public string GuitarId { get; set; }
        [Required]
        public float Cost { get; set; }
    }
}