using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace NamelessWeb.Models.Bills.Imports
{
    public class ImportBill
    {
        [Key]
        public string ImpBId { get; set; }
        public DateTime ImpDate { get; set; }
        public string ImpEmp { get; set; }
        public string NoteId { get; set; }
    }
}