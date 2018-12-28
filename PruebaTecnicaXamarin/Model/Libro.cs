using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace PruebaTecnicaXamarin
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

    public class Libro
    {
        public string error { get; set; }
        public string total { get; set; }
        public string page { get; set; }
        public List<Book> books { get; set; }
    }


}