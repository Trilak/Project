using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BookStore.Models
{
    public class LibraryViewModel
    {

        [Key]
        public Int32 Id { get; set; }
        public string Author { get; set; }
        public string Title { get; set; }
        public string Category { get; set; }
        public string Description { get; set; }
        public Nullable<decimal> Price { get; set; }
        public string Coverimg { get; set; }
        public string Content { get; set; }

    }
}