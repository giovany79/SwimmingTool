
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
    [Activity(Label = "Brazada")]
    public class Brazada : Activity
    {

        int numeroBrazadas = 0;
        TextView numBrazadaTV;
        Chronometer simpleChronometer;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.Brazadas);

            simpleChronometer = FindViewById<Chronometer>(Resource.Id.simpleChronometer);
            FindViewById<Button>(Resource.Id.finishButton).Click += OnFinishClick;
            FindViewById<Button>(Resource.Id.brazadaButton).Click += OnBrazadaClick;
            numBrazadaTV = FindViewById<TextView>(Resource.Id.numBrazadaTextView);


        }

        void OnFinishClick(object sender, EventArgs e)
        {
            var intent = new Intent(this, typeof(Resultado));
            StartActivity(intent);
        }

        void OnBrazadaClick(object sender, EventArgs e)
        {
            numeroBrazadas = numeroBrazadas + 1;
            numBrazadaTV.Text = numeroBrazadas.ToString();
        }


    }
}
