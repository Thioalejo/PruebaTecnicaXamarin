using Plugin.Connectivity;
using PruebaTecnicaXamarin.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Libros.Core.Service
{
    public class CheckConnectionInternet
    {
        public async Task<HttpResponse> CheckConnection()
        {
            if (!CrossConnectivity.Current.IsConnected)
            {
                return new HttpResponse
                {
                    IsSucces = false,
                    Message = "Por favor enciende tu internet en configuraciones",
                };
            }

            var isReachable = await CrossConnectivity.Current.IsRemoteReachable("https://www.google.com.co/");
            if (!isReachable)
            {
                return new HttpResponse
                {
                    IsSucces = false,
                    Message = "No tienes conexión a internet"
                };
            }

            return new HttpResponse
            {
                IsSucces = true,
            };
        }

    }
}
