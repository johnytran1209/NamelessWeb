using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace NamelessWeb.Views.ViewModels
{
    public class GuitarViewModel
    {

        public byte Choice { get; set; }
        public string GuiId { get; set; }
        public string GuitarModel { get; set; }
        public IEnumerable<Models.Company.Brand> BrandId { get; set; }
        [Required]
        public IEnumerable<Models.Guitar.GuitarType> TypeId { get; set; }
        public IEnumerable<Models.Guitar.Wood.GoTop> Top { get; set; }
        public IEnumerable<Models.Guitar.Wood.GoSide> Side { get; set; }
        public IEnumerable<Models.Guitar.Wood.GoBack> Back { get; set; }
        public IEnumerable<Models.Guitar.Wood.GoNeck> Neck { get; set; }
        public IEnumerable<Models.Guitar.Wood.GoFing> Fing { get; set; }
        public IEnumerable<Models.Guitar.Warranties> Insurance { get; set; }
        public float Price { get; set; }
        public byte Electricfied { get; set; }

    }
}