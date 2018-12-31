using System.Net;

namespace PruebaTecnicaXamarin.Model
{
    public class HttpResponse
    {
        public string Content { get; set; }
        public HttpStatusCode HttpStatusCode { get; set; }
    }
}