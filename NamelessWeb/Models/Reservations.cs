using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Linq;
using System.Web;

namespace NamelessWeb.Models
{
    public class Reservations
    {
        [Required]
        public string UserId { get; set; }
        [Key]
        [Required]
        public int GuitarId { get; set; }
    }
}