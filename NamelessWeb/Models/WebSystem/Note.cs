using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace NamelessWeb.Models.WebSystem
{
    public class Note
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int NoteId { get; set; }
        [Required]
        public string NoteMess { get; set; }
        [Required]
        public string UserName { get; set; }
        public DateTime Date { get; set; }
    }
}