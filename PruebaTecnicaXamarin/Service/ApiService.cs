using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace PruebaTecnicaXamarin
{
    public class ApiService
    {
        public async Task<T> Get<T>(string url, string tecnologia)
        {

            try
            {
                HttpClient client = new HttpClient();
                var response = await client.GetAsync(url+tecnologia);

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