using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Data.SqlClient;

namespace NamelessWeb.Views.ViewModels
{
    public class GuitarViewModel
    {
        //SqlConnection a = new SqlConnection(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=NamelessWeb;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int GuitarId { get; set; }
        [Required]
        public string GuitarModel { get; set; }
        [Required]
        public string BrandId { get; set; }
        public IEnumerable<Models.Company.Brand> BrandIds { get; set; }
        public string BrandName { get; set; }
        [Required]
        public string TypeId { get; set; }
        public IEnumerable<Models.Guitar.GuitarTypes> TypeIds { get; set; }
        public string TypeName { get; set; }
        [Required]
        public string Top { get; set; }
        public IEnumerable<Models.Guitar.Wood.GoTop> Tops { get; set; }
        public string TopName { get; set; }
        [Required]
        public string Side { get; set; }
        public IEnumerable<Models.Guitar.Wood.GoSide> Sides { get; set; }
        public string SideName { get; set; }
        [Required]
        public string Back { get; set; }
        public IEnumerable<Models.Guitar.Wood.GoBack> Backs { get; set; }
        public string BackName { get; set; }
        [Required]
        public string Neck { get; set; }
        public IEnumerable<Models.Guitar.Wood.GoNeck> Necks { get; set; }
        public string NeckName { get; set; }
        [Required]
        public string Fing { get; set; }
        public IEnumerable<Models.Guitar.Wood.GoFing> Fings { get; set; }
        public string FingsName { get; set; }
        [Required]
        public int Insurance { get; set; }
        public IEnumerable<Models.Guitar.Warranties> Insurances { get; set; }
        public string InsuranceName { get; set; }
        [Required]
        public float Price { get; set; }
        [Required]
        public bool Electricfied { get; set; }
        public string Description { get; set; }
        public string ImageLink { get; set; }
        [Required]
        public byte Availability { get; set; }
    }
}