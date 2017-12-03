using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace NamelessWeb.Models.Guitar
{
    public class Guitars
    {
        [Key]
        [Required]
        public int GuitarId { get; set; }
        [Required]
        [StringLength(40)]
        public string MDL { get; set; }
        [Required]
        [StringLength(3)]
        public string BrandId { get; set; }
        [Required]
        [StringLength(3)]
        public string TypeId { get; set; }
        [Required]
        public float MSRP { get; set; }
        [Required]
        public int WarrId { get; set; }
        [Required]
        public bool ELE { get; set; }
        //[Required]
        public string ImageLink1 { get; set; }
        public string ImageLink2 { get; set; }
        public string ImageLink3 { get; set; }
        public string ImageLink4 { get; set; }
        public string ImageLink5 { get; set; }
        public string ImageLink6 { get; set; }
        public string Videolink { get; set; }
        [Required]
        public byte Availability { get; set; }
       }
}