
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace SwimmingTool
{
    [Activity(Label = "Resultado")]
    public class Resultado : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.Resultado);

            FindViewById<Button>(Resource.Id.sessionButton).Click += OnSessionClick;
            FindViewById<Button>(Resource.Id.HomeButton).Click += OnHomeClick;

        }


        void OnSessionClick(object sender, EventArgs e)
        {
            var intent = new Intent(this, typeof(Tabla));
            StartActivity(intent);
        }

        void OnHomeClick(object sender, EventArgs e)
        {
            var intent = new Intent(this, typeof(MainActivity));
            StartActivity(intent);
        }
    }
}
