using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace KendoUI_CodeFirst_Testing.Models
{
    public class Library
    {
        [Display(Name="Id")]
        public int LibraryId { get; set; }
        public String Name { get; set; }
        public String Location { get; set; }
        public virtual List<Book> Books { get; set; }
    }
}