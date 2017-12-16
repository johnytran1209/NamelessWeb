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
    public class GuitarRatingViewModel
    {
        
        public int feedId { get; set;}
        public int guitarid { get; set; }
        public string guitarmdl { get; set; }
        [Required]
        public int stars { get; set; }
        [Required]
        public string GuitarMess { get; set; }
        public string guitarimg { get; set; }
        public string username { get; set; }
        public string heading { get; set; }
        public string action
        {
            get
            {
                if (feedId > -1)
                    return "Edit";
                else
                    return "Create";
            }
        }
    }
}
