﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookStore.Models
{
    public class BooksViewModel
    {

        public string Author { get; set; }
        public string Title { get; set; }
        public string Category { get; set; }
        public string Description { get; set; }
        public Nullable<decimal> Price { get; set; }
        public string Coverimg { get; set; }
        public string Content{ get; set; }

    }
}