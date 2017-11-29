using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NamelessWeb.Views.ViewModels
{
    public class OrderViewModel
    {
        public string UserName { get; set; }
        public string UserId { get; set; }
        public string GuitarId { get; set;}
        public string GuitarModel { get; set;}
        public string GuitarImage { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public DateTime DateReserve { get; set; }
    }
    

}