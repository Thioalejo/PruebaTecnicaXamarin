using Android.App;
using Android.OS;
using Android.Support.V7.App;
using Android.Runtime;
using Android.Widget;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Net.Http;
using Newtonsoft.Json;
using PruebaTecnicaXamarin.Model;
using AlertDialog = Android.App.AlertDialog;

namespace PruebaTecnicaXamarin
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        private EditText txtBuscar;
      
        private Button btnConsularLibro;
        private string ProductoCompleto;
        private ListView lista;
        private List<string> datos;
        

        private ApiService apiService = new ApiService();

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.activity_main);
            txtBuscar = (EditText)FindViewById(Resource.Id.txtBuscar);

            btnConsularLibro = (Button)FindViewById(Resource.Id.btnConsultar);
            btnConsularLibro.Click += BtnConsultar_Click;
            datos = new List<string>();

        }

        private void BtnConsultar_Click(object sender, System.EventArgs e)
        {
            ConsultarAsync();
        }
        
        private async void ConsultarAsync()
        {
            datos.Clear();
            ApiService client = new ApiService();
            var consultar = await client.Get<Libro>("https://api.itbook.store/1.0/search/", txtBuscar.Text);

            foreach (var Libro in consultar.books)
            {
                ProductoCompleto = "Title:" + Libro.title;

                ListView();
            }
        }
        
        private void ListView()
        {
            lista = FindViewById<ListView>(Resource.Id.LvLibros);

            datos.Add(ProductoCompleto);

            //lo que va a mostrar la vista listview
            lista.Adapter = new ArrayAdapter(this, Android.Resource.Layout.SimpleListItem1, datos);

            lista.ItemClick += Lista_ItemClick;
        }

        private void Lista_ItemClick(object sender, AdapterView.ItemClickEventArgs e)
        {
            string itemSeleccionado= lista.GetItemAtPosition(e.Position).ToString();
            txtBuscar.Text = itemSeleccionado;
        }
    }
}