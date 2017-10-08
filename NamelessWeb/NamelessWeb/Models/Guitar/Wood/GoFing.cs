using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace NamelessWeb.Models.Guitar.Wood
{
    public class GoFing
    {
        [Key]
        [Required]
        [StringLength(3)]
        public string FingId { get; set; }
        [Required]
        [StringLength(40)]
        public string FingName { get; set; }
    }
}