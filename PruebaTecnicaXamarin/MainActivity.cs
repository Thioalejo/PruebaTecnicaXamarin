using Android.App;
using Android.OS;
using Android.Support.V7.App;
using Android.Runtime;
using Android.Widget;

namespace PruebaTecnicaXamarin
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        private EditText txtBuscar;
        private ImageView imageView;
        private TextView tvResultado;
        private Button btnConsularLibro;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.activity_main);

            tvResultado = (TextView)FindViewById(Resource.Id.tvResultado);
            txtBuscar = (EditText)FindViewById(Resource.Id.txtBuscar);
            imageView = (ImageView)FindViewById(Resource.Id.imageView);

            var btnConsultar = (Button)FindViewById(Resource.Id.btnConsultar);
            btnConsultar.Click += BtnConsultar_Click;

        }

        private void BtnConsultar_Click(object sender, System.EventArgs e)
        {
            
        }
    }
}