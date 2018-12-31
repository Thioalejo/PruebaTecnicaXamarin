using Libros.Core.Model;
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
}