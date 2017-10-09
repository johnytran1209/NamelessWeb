using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace NamelessWeb.Models.Company
{
    public class Supplier
    {
        [Key]
        [Required]
        [StringLength(3)]
        public string SuppId { get; set; }
        [Required]
        [StringLength(50)]
        public string SuppName { get; set; }
        [Required]
        [StringLength(50)]
        public string SuppEmail { get; set; }
        [Required]
        [StringLength(20)]
        public string SuppPhone { get; set; }
        [Required]
        [StringLength(50)]
        public string SuppWeb { get; set; }
        [Required]
        [StringLength(60)]
        public string SuppAddr { get; set; }
    }
}