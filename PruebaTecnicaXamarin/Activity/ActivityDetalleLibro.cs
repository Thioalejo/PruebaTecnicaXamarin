using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Support.V7.App;
using Android.Views;
using Android.Widget;

namespace PruebaTecnicaXamarin.Activity
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme")]
    public class ActivityDetalleLibro : AppCompatActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.ActivityDetalleLibro);
            // Create your application here
        }
    }
}