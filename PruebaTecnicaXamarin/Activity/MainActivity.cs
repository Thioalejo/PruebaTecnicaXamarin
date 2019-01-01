using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.OS;
using Android.Support.V7.App;
using Android.Views.InputMethods;
using Android.Widget;
using Libros.Core.Service;
using Libros.Core.Utils;
using System.Collections.Generic;

namespace PruebaTecnicaXamarin
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true, ScreenOrientation = ScreenOrientation.Portrait)]
    public class MainActivity : AppCompatActivity
    {
        private TextView loading;
        private ProgressBar progressBar;
        private EditText txtBuscar;
        private ImageButton btnConsularLibro;
        private ListView lista;
        private List<string> datos;
        private ApiService client = new ApiService();
        private CheckConnectionInternet checkConnection = new CheckConnectionInternet();
        private Libro detailbook;


        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.activity_main);
            loading = (TextView)FindViewById(Resource.Id.tvLoading);
            progressBar = (ProgressBar)FindViewById(Resource.Id.progressBarList);
            loading.Visibility = Android.Views.ViewStates.Invisible;
            progressBar.Visibility = Android.Views.ViewStates.Invisible;
            txtBuscar = (EditText)FindViewById(Resource.Id.txtBuscar);
            btnConsularLibro = (ImageButton)FindViewById(Resource.Id.btndetailbook);
            btnConsularLibro.Click += Btndetailbook_Click;
            lista = FindViewById<ListView>(Resource.Id.LvLibros);
            datos = new List<string>();
            lista.ItemClick += Lista_ItemClick;
        }

        private void Btndetailbook_Click(object sender, System.EventArgs e)
        {
            detailbookLibros();
        }

        private async void detailbookLibros()
        {
            //para verificar internet
            var connection = await this.checkConnection.CheckConnection();

            if (!connection.IsSucces)
            {
                Android.App.AlertDialog.Builder alertDialog = new Android.App.AlertDialog.Builder(this);
                alertDialog.SetTitle("Alert connectivity");
                alertDialog.SetMessage("Please check your internet connection.");
                alertDialog.SetNeutralButton("Ok", delegate
                {
                    alertDialog.Dispose();
                });
                alertDialog.Show();
                return;
            }

            if (txtBuscar.Text != "")
            {
                loading.Visibility = Android.Views.ViewStates.Visible;
                progressBar.Visibility = Android.Views.ViewStates.Visible;
                datos.Clear();
                detailbook = await client.Get<Libro>(Constants.URLSEARCH, txtBuscar.Text);

                foreach (var Libro in detailbook.books)
                {
                    datos.Add("Title: " + Libro.title);
                }
                loading.Visibility = Android.Views.ViewStates.Invisible;
                progressBar.Visibility = Android.Views.ViewStates.Invisible;

            }
            else
            {
                Toast.MakeText(this, Resource.String.aler_type_book, ToastLength.Long).Show();
            }
            ListView();

            //para cerrar el teclado una vez finalice la busqueda.
            InputMethodManager inputManager = (InputMethodManager)this.GetSystemService(Context.InputMethodService);
            inputManager.HideSoftInputFromWindow(this.CurrentFocus.WindowToken, HideSoftInputFlags.NotAlways);
        }

        private void ListView()
        {
            //lo que va a mostrar la vista listview
            lista.Adapter = new ArrayAdapter(this, Android.Resource.Layout.SimpleListItem1, datos);
        }

        private void Lista_ItemClick(object sender, AdapterView.ItemClickEventArgs e)
        { 
            EncotrarLibroSeleccionado(e.Position);
        }

        private void EncotrarLibroSeleccionado(int posicion)
        {
            string tituloItemSeleccionado = lista.GetItemAtPosition(posicion).ToString();

            foreach (var item in detailbook.books)
            {
                if (tituloItemSeleccionado.Contains(item.title))
                {
                    Intent activityDetalleLibro = new Intent(this, typeof(Activity.DetailsBookActivity));
                    activityDetalleLibro.PutExtra("key", item.isbn13);
                    StartActivity(activityDetalleLibro);
                }
            }
        }
    }
}