using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace NamelessWeb.Models.Company
{
    public class Brand
    {
        [Key]
        [Required]
        [StringLength(3)]
        public string BrandId { get; set; }
        [Required]
        [StringLength(40)]
        public string BrandName { get; set; }
        [Required]
        [StringLength(3)]
        public string SuppId { get; set; }
    }
}