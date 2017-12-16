﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace NamelessWeb.Models.WebSystem
{
    public class GuitarRating
    {
        [Key]
        public int FeedId { get; set; }
        public int GuitarId { get; set; }
        public string CusName { get; set; }
        public int Stars { get; set; }
        [Required]
        [StringLength(200)]
        [MinLength(50)]
        public string FeedMes { get; set; }
    }
}