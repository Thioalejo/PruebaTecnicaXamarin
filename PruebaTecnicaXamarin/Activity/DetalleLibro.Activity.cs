using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.OS;
using Android.Runtime;
using Android.Support.V7.App;
using Android.Views;
using Android.Widget;
using Newtonsoft.Json;
using Square.Picasso;

namespace PruebaTecnicaXamarin.Activity
{
    [Activity(Label = "@string/detalle_libro", Theme = "@style/AppTheme", ScreenOrientation = ScreenOrientation.Portrait)]
    public class ActivityDetalleLibro : AppCompatActivity
    {

        private TextView title;
        private ImageView imagen;
        private TextView autor;
        private TextView lenguaje;
        private TextView price;
        private TextView descripcion;
        private Utils.Constantes constantes;
        private ApiService client = new ApiService();
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

        //protected override void OnResume()
        //{
        //    BuscarDetalleLibro();
        //}



        public async void BuscarDetalleLibro()
        {

            string obj = this.Intent.GetStringExtra("key");
            consultar = await client.Get<DetailBook>("https://api.itbook.store/1.0" + "/books/", obj.ToString());

           
                title.Text = consultar.title;
            // Android.Net.Uri urlImagen = Android.Net.Uri.Parse(consultar.image);


            Picasso.With(this)
            .Load(consultar.image)
            .Into(imagen);
                //Android.Net.Uri url = Android.Net.Uri.Parse("");
                //imagen.SetImageURI(url);

                autor.Text = consultar.authors;
                lenguaje.Text = consultar.language;
                price.Text = consultar.price;
                descripcion.Text = consultar.desc;
            
        }
    }
}