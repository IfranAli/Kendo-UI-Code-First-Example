using KendoUI_CodeFirst_Testing.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace KendoUI_CodeFirst_Testing.Context
{
    public class LibraryContext : DbContext
    {
        public DbSet<Library> Libraries{ get; set; }
        public DbSet<Book> Books { get; set; }
    }
}