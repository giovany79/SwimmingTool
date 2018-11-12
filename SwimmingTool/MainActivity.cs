using System;
using Android.App;
using Android.Widget;
using Android.OS;
using Android.Content;
using System.Collections.Generic;

namespace SwimmingTool
{
    [Activity(Label = "SwimmingTool", MainLauncher = true, Icon = "@mipmap/icon")]
    public class MainActivity : Activity
    {


        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);

            FindViewById<Button>(Resource.Id.acceptButton).Click += OnAcceptClick;
            FindViewById<Button>(Resource.Id.cancelButton).Click += OnCancelClick;

        }

        void OnAcceptClick(object sender, EventArgs e)
        {
            var intent = new Intent(this, typeof(Brazada));
            StartActivity(intent);
        }

        void OnCancelClick(object sender, EventArgs e)
        {

        }


    }
}

