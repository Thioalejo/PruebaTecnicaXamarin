using System;
using System.Collections.Generic;
using System.Text;

namespace Libros.Core.Model
{
   public class Book
    {
        public string title { get; set; }
        public string subtitle { get; set; }
        public string isbn13 { get; set; }
        public string price { get; set; }
        public string image { get; set; }
        public string url { get; set; }
    }
}
