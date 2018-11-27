
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
using System.Timers;

namespace SwimmingTool
{
    [Activity(Label = "Brazada")]
    public class Brazada : Activity
    {

        private int numeroBrazadas = 0;
        private TextView numBrazadaTV;
        private int mins = 0, secs = 0, milliseconds = 0;
        private Timer timer;
        private TextView txtTimer;
        private Boolean isStart = false;
        private String documento;
        public RegistroRepository registroDB;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.Brazadas);
            documento = Intent.GetStringExtra("documento");

            string dbPath = FileAccessHelper.GetLocalFilePath("people.db3");
            registroDB = new RegistroRepository(dbPath);

            FindViewById<Button>(Resource.Id.finishButton).Click += OnFinishClick;
            FindViewById<Button>(Resource.Id.brazadaButton).Click += OnBrazadaClick;
            FindViewById<Button>(Resource.Id.startStopButton).Click += OnStartStopClick;
            FindViewById<Button>(Resource.Id.resetButton).Click += OnResetClick;
            numBrazadaTV = FindViewById<TextView>(Resource.Id.numBrazadaTextView);
            txtTimer = FindViewById<TextView>(Resource.Id.timeTextView);


        }

        void OnFinishClick(object sender, EventArgs e)
        {
            var intent = new Intent(this, typeof(Resultado));
            StartActivity(intent);

            Registro registro = new Registro();
            registro.documento = documento;
            registro.numBrazadas = numeroBrazadas;
            registro.feha = DateTime.Now.ToString();
            registro.time = txtTimer.Text;
            registroDB.addNewRegistro(registro);

        }

        void OnBrazadaClick(object sender, EventArgs e)
        {
            numeroBrazadas = numeroBrazadas + 1;
            numBrazadaTV.Text = numeroBrazadas.ToString();
        }

        void OnStartStopClick(object sender, EventArgs e)
        {
            if (isStart){
                isStart = false;
                timer.Stop();
                timer = null;
            }
            else
            {
                timer = new Timer();
                timer.Interval = 1;
                timer.Elapsed += Timer_Elapsed;
                isStart = true;
                timer.Start();
            }
        }

        void OnResetClick(object sender, EventArgs e){
            numeroBrazadas = 0;
            numBrazadaTV.Text = numeroBrazadas.ToString();

            timer = new Timer();
            isStart = false;
            timer.Stop();
            timer = null;
            milliseconds = 0;
            secs = 0;
            mins = 0;
            txtTimer.Text = String.Format("{0}:{1:00}:{2:000}", mins, secs, milliseconds);

        }




        void Timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            milliseconds++;
            if(milliseconds>1000){
                secs++;
                milliseconds = 0;
            }
            if(secs==59){
                mins++;
                secs = 0;
            }
            RunOnUiThread(()=>{
                txtTimer.Text = String.Format("{0}:{1:00}:{2:000}", mins, secs, milliseconds);  
            });
        }

    }
}
