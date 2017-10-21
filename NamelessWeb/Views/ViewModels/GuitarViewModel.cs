using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Drawing;
using System.Linq;
using System.Web;

namespace NamelessWeb.Views.ViewModels
{
    public class GuitarViewModel
    {

        //public byte Choice { get; set; }
        [Required]
        public int GuitarId { get; set; }
        [Required]
        public string GuitarModel { get; set; }
        [Required]
        public string BrandId { get; set; }
        public IEnumerable<Models.Company.Brand> BrandIds { get; set; }
        [Required]
        public string TypeId { get; set; }
        public IEnumerable<Models.Guitar.GuitarTypes> TypeIds { get; set; }
        [Required]
        public string Top { get; set; }
        public IEnumerable<Models.Guitar.Wood.GoTop> Tops { get; set; }
        [Required]
        public string Side { get; set; }
        public IEnumerable<Models.Guitar.Wood.GoSide> Sides { get; set; }
        [Required]
        public string Back { get; set; }
        public IEnumerable<Models.Guitar.Wood.GoBack> Backs { get; set; }
        [Required]
        public string Neck { get; set; }
        public IEnumerable<Models.Guitar.Wood.GoNeck> Necks { get; set; }
        [Required]
        public string Fing { get; set; }
        public IEnumerable<Models.Guitar.Wood.GoFing> Fings { get; set; }
        [Required]
        public int Insurance { get; set; }
        public IEnumerable<Models.Guitar.Warranties> Insurances { get; set; }
        [Required]
        public float Price { get; set; }
        [Required]
        public byte Electricfied { get; set; }
        public string Description { get; set; }
        public string ImageLink { get; set; }
    }
}