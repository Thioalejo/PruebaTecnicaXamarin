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
using System;
using Android.Content;

namespace PruebaTecnicaXamarin
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        private EditText txtBuscar;

        private Button btnConsularLibro;
        private string IdLibro;
        private ListView lista;
        private List<string> datos;


        private ApiService client = new ApiService();
        private Libro consultar;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.activity_main);
            txtBuscar = (EditText)FindViewById(Resource.Id.txtBuscar);

            btnConsularLibro = (Button)FindViewById(Resource.Id.btnConsultar);
            btnConsularLibro.Click += BtnConsultar_Click;
            lista = FindViewById<ListView>(Resource.Id.LvLibros);
            datos = new List<string>();

        }

        private void BtnConsultar_Click(object sender, System.EventArgs e)
        {
            ConsultarLibros();
        }

        private async void ConsultarLibros()
        {
            datos.Clear();

            consultar = await client.Get<Libro>("https://api.itbook.store/1.0/search/", txtBuscar.Text);

            foreach (var Libro in consultar.books)
            {
                datos.Add("Title:" + Libro.title);

                
            }
            ListView();
        }

        private void ListView()
        {

            //lo que va a mostrar la vista listview
            lista.Adapter = new ArrayAdapter(this, Android.Resource.Layout.SimpleListItem1, datos);

            lista.ItemClick += Lista_ItemClick;
        }
        string Id;
        private void Lista_ItemClick(object sender, AdapterView.ItemClickEventArgs e)
        {
            EncotrarLibroSeleccionado(e.Position);         
        }

        private void EncotrarLibroSeleccionado(int posicion)
        {
            // var consultar = await client.Get<Libro>("https://api.itbook.store/1.0/search/", txtBuscar.Text);
            //string textItemList = lista.GetItemAtPosition(tituloItemSeleccionado).ToString();
            string tituloItemSeleccionado = lista.GetItemAtPosition(posicion).ToString();

            foreach (var item in consultar.books)
            {
                if (tituloItemSeleccionado.Contains(item.title))
                {
                    StartActivity(new Intent(Application.Context, typeof(Activity.ActivityDetalleLibro)));
                }
            }
        }
    }
}