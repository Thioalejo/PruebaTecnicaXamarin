
using Android.App;
using Android.Content.PM;
using Android.OS;
using Android.Support.V7.App;
using Android.Widget;
using Libros.Core.Utils;
using Libros.Core.Model;
using Square.Picasso;
using Libros.Core.Service;

namespace PruebaTecnicaXamarin.Activity
{
    [Activity(Label = "@string/detail_book", Theme = "@style/AppTheme", ScreenOrientation = ScreenOrientation.Portrait)]
    public class ActivityDetalleLibro : AppCompatActivity
    {
        private TextView title;
        private ImageView imagen;
        private TextView autor;
        private TextView lenguaje;
        private TextView price;
        private TextView descripcion;
        private ApiService client = new ApiService();
        private CheckConnectionInternet checkConnection = new CheckConnectionInternet();
        private DetailBook consultar;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.activity_detalle_libro);
            // Create your application here
            title = (TextView)FindViewById(Resource.Id.tvTitle);
            imagen = (ImageView)FindViewById(Resource.Id.imageViewLibro);
            autor = (TextView)FindViewById(Resource.Id.tvAuthorsDescription);
            lenguaje = (TextView)FindViewById(Resource.Id.tvLanguageDescription);
            price = (TextView)FindViewById(Resource.Id.tvPriceDescription);
            descripcion = (TextView)FindViewById(Resource.Id.tvDescription);
            BuscarDetalleLibro();
        }

        public async void BuscarDetalleLibro()
        {
            string obj = this.Intent.GetStringExtra("key");

            //para verificar internet
            var connection = await this.checkConnection.CheckConnection();

            if (!connection.IsSucces)
            {
                Android.App.AlertDialog.Builder alertDialog = new Android.App.AlertDialog.Builder(this);
                alertDialog.SetTitle("");
                alertDialog.SetMessage("");
                alertDialog.SetNeutralButton("Ok", delegate
                {
                    alertDialog.Dispose();
                });

                return;
            }
            consultar = await client.Get<DetailBook>(Constants.URLDETAILBOOK, obj.ToString());

            title.Text = consultar.title;
            
            Picasso.With(this)
            .Load(consultar.image)
            .Into(imagen);
   
            autor.Text = consultar.authors;
            lenguaje.Text = consultar.language;
            price.Text = consultar.price;
            descripcion.Text = consultar.desc;
        }
    }
}