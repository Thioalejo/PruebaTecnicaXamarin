using System.Net;

namespace PruebaTecnicaXamarin.Model
{
    public class HttpResponse
    {
        public bool IsSucces { get; set; }
        public string Message { get; set; }
        public object Result { get; set; }
    }
}