﻿using System;
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
    [Activity(Label = "@string/detalle_libro", Theme = "@style/AppTheme")]
    public class ActivityDetalleLibro : AppCompatActivity
    {

        private TextView title;
        private TextView autor;
        private TextView lenguaje;
        private TextView descripcion;
        private ImageView imagen;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.activity_detalle_libro);
            // Create your application here
        }
    }
}