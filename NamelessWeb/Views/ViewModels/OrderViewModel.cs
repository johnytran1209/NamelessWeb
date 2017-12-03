using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace NamelessWeb.Views.ViewModels
{
    public class OrderViewModel
    {
        public string BrandName { get; set; }
        [Required]
        public int GuitarId { get; set;}
        [Required]
        public string GuitarModel { get; set;}
        [Required]
        public string GuitarImage { get; set; }
        [Required]
        public float Price { get; set; }
        public string InsuranceName { get; set; }
        public string Imagelink1 { get; set; }
        [Required]
        public string BuyerName { get; set; }
        [Required]
        public string BuyerId { get; set; }
        [Required]
        public string Phone { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Address { get; set; }
        public DateTime DateReserve { get; set; }
        public DateTime DateOrder { get; set; }
        public string Des { get; set; }
    }
    

}