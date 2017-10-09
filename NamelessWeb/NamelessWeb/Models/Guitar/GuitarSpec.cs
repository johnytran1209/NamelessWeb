using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace NamelessWeb.Models.Guitar
{
    public class GuitarSpec
    {
        [Key]
        [Required]
        [StringLength(40)]
        public string GuitarId { get; set; }
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
        public string NeckId
        { get; set; }
        [Required]
        [StringLength(3)]
        public string FingId   { get; set; }
        [Required]
        [StringLength(1200)]
        public string Descript { get; set; }
    }
}