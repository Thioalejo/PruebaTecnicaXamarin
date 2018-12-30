using System.Collections.Generic;

namespace PruebaTecnicaXamarin
{


    public class Libro
    {
        public string error { get; set; }
        public string total { get; set; }
        public string page { get; set; }
        public List<Book> books { get; set; }
        public List<DetailBook> detailbooks { get; set; }

    }

    public class Book
    {
        public string title { get; set; }
        public string subtitle { get; set; }
        public string isbn13 { get; set; }
        public string price { get; set; }
        public string image { get; set; }
        public string url { get; set; }
    }

    public class DetailBook
    {
        public string error { get; set; }
        public string title { get; set; }
        public string subtitle { get; set; }
        public string authors { get; set; }
        public string publisher { get; set; }
        public string language { get; set; }
        public string isbn10 { get; set; }
        public string isbn13 { get; set; }
        public string pages { get; set; }
        public string year { get; set; }
        public string rating { get; set; }
        public string desc { get; set; }
        public string price { get; set; }
        public string image { get; set; }
        public string url { get; set; }
    }

}