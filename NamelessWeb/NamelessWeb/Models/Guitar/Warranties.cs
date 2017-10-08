using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace NamelessWeb.Models.Guitar
{
    public class Warranties
    {
        [Key]
        [Required]
        public int WarrId { get; set; }
        [Required]
        public int WarrLength { get; set;}
    }
}