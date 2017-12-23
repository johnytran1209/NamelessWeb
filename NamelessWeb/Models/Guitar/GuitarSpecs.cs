using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;

namespace NamelessWeb.Models.Guitar
{
    public class GuitarSpecs
    {
        [Key]
        public int GuitarId { get; set; }
        [Required]
        [StringLength(3)]
        public string TopId { get; set; }
        [Required]
        [StringLength(3)]
        public string SideId { get; set; }
        [Required]
        [StringLength(3)]
        public string BackId { get; set; }
        [Required]
        [StringLength(3)]
        public string NeckId { get; set; }
        [Required]
        [StringLength(3)]
        public string FingId   { get; set; }
        [StringLength(1200)]
        public string Descript { get; set; }
    }
}