using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace NamelessWeb.Models.Bills.Exports
{
    public class ExportBill
    {
        [Key]
        public string ExpBId { get; set; }
        public DateTime ExpDate { get; set; }
        public string ExpEmp { get; set; }
        public string ExpCus { get; set; }           
    }
}