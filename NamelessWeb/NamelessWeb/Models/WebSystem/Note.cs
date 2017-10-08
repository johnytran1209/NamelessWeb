using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace NamelessWeb.Models.WebSystem
{
    public class Note
    {
        [Key]
        public string NoteId { get; set; }
        public string NoteMess { get; set; }
    }
}