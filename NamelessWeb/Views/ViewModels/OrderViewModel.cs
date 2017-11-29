using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NamelessWeb.Views.ViewModels
{
    public class OrderViewModel
    {
        
        public string BrandName { get; set; }
        public int GuitarId { get; set;}
        public string GuitarModel { get; set;}
        public string GuitarImage { get; set; }
        public float Price { get; set; }
        public string InsuranceName { get; set; }
        public string Imagelink1 { get; set; }
        public string BuyerName { get; set; }
        public string BuyerId { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public DateTime DateReserve { get; set; }
    }
    

}