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
        [Required]
        public DateTime ExpDate { get; set; }
        [Required]
        public string ExpEmp { get; set; }
        [Required]
        public string ExpEmpId { get; set; }
        [Required]
        public string ExpCus { get; set; }           
        [Required]
        public string ExpCusId { get; set; }
        [Required]
        public string ExpDes { get; set; }
    }
}