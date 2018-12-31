using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace PruebaTecnicaXamarin
{
    public class ApiService
    {
        public async Task<T> Get<T>(string urlBase, string prefijo)
        {

            try
            {
                HttpClient client = new HttpClient();
                var response = await client.GetAsync(urlBase + prefijo);

                if(response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    var jsonstring = await response.Content.ReadAsStringAsync();
                    return Newtonsoft.Json.JsonConvert.DeserializeObject<T>(jsonstring);
                }
            }
            catch (Exception)
            {

                throw;
            }
            return default(T);
        }
    }
}