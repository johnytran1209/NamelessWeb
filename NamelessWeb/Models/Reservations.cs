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
        [Key]
        public int No { get; set; }
        [Required]
        public string UserId { get; set; }
        [Required]
        public int GuitarId { get; set; }
        [Required]
        public DateTime DateReserve { get; set; }
    }
}