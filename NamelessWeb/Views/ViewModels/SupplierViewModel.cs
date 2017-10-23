using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Data.SqlClient;

namespace NamelessWeb.Views.ViewModels
{
    public class SupplierViewModel
    {
        [Required]
        public string BrandId { get; set; }
        [Required]
        public string BrandName { get; set; }
        [Required]
        public string SupplierId { get; set; }
        public IEnumerable<Models.Company.Supplier> SuppIds { get; set; }
        public string SupplierName { get; set; }
    }
}