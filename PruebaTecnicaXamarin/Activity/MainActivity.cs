using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.OS;
using Android.Support.V7.App;
using Android.Widget;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace PruebaTecnicaXamarin
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true, ScreenOrientation = ScreenOrientation.Portrait)]
    public class MainActivity : AppCompatActivity
    {
        private EditText txtBuscar;

        private ImageButton btnConsularLibro;
        private string IdLibro;
        private ListView lista;
        private List<string> datos;


        private ApiService client = new ApiService();
        private Libro consultar;
        private Utils.Constantes constantes;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.activity_main);
            txtBuscar = (EditText)FindViewById(Resource.Id.txtBuscar);

            btnConsularLibro = (ImageButton)FindViewById(Resource.Id.btnConsultar);
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

                    //StartActivity(Activity.ActivityDetalleLibro);
                    Intent i = new Intent(this, typeof(Activity.ActivityDetalleLibro));
                    i.PutExtra("key", item.isbn13);
                    StartActivity(i);
                    //StartActivity(new Intent(Application.Context, typeof(Activity.ActivityDetalleLibro)));
                }
            }
        }
    }
}