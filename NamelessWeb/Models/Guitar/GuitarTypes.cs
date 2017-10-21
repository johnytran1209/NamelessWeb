using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace NamelessWeb.Models.Guitar
{
    public class GuitarTypes
    {
        [Key]
        [Required]
        [StringLength(3)]
        public string TypeId { get; set; }
        [Required]
        [StringLength (40)]
        public string TypeName { get; set; }
    }
}