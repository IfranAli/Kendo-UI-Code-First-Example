using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KendoUI_CodeFirst_Testing.Models
{
    public class Book
    {
        public int BookId { get; set; }
        public String Title { get; set; }
        public virtual Library Library { get; set; }
    }
}