
using Android.App;
using Android.Content.PM;
using Android.OS;
using Android.Support.V7.App;
using Android.Widget;
using Libros.Core.Model;
using Libros.Core.Service;
using Libros.Core.Utils;
using Square.Picasso;

namespace PruebaTecnicaXamarin.Activity
{
    [Activity(Label = "@string/detail_book", Theme = "@style/AppTheme", ScreenOrientation = ScreenOrientation.Portrait)]
    public class DetailsBookActivity : AppCompatActivity
    {
        private TextView title;
        private ImageView imagen;
        private TextView autor;
        private TextView lenguaje;
        private TextView price;
        private TextView descripcion;
        private ApiService client = new ApiService();
        private CheckConnectionInternet checkConnection = new CheckConnectionInternet();
        private DetailBook detailbook;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.activity_details_book);
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
                alertDialog.SetTitle("Alert connectivity");
                alertDialog.SetMessage("Please check your internet connection.");
                alertDialog.SetNeutralButton("Ok", delegate
                {
                    alertDialog.Dispose();
                });
                alertDialog.Show();
                return;
            }
            detailbook = await client.Get<DetailBook>(Constants.URLDETAILBOOK, obj.ToString());

            title.Text = detailbook.title;

            Picasso.With(this)
            .Load(detailbook.image)
            .Into(imagen);

            autor.Text = detailbook.authors;
            lenguaje.Text = detailbook.language;
            price.Text = detailbook.price;
            descripcion.Text = detailbook.desc;
        }
    }
}