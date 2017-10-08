using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace NamelessWeb.Models.Guitar.Wood
{
    public class GoTop
    {
        [Key]
        [Required]
        [StringLength(3)]
        public string TopId { get; set; }
        [Required]
        [StringLength(40)]
        public string TopName { get; set; }
    }
}