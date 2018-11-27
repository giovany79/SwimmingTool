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
        public static RegistroRepository PersonRepo { get; private set; }
        public RegistroRepository registroDB;
        private EditText nombreEditText;
        private EditText documentoEditText;
        private RadioButton hombreRadioButon;
        private EditText brazoEditText;
        private EditText estatutaEditText;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);

            string dbPath = FileAccessHelper.GetLocalFilePath("people.db3");
            registroDB = new RegistroRepository(dbPath);

            FindViewById<Button>(Resource.Id.acceptButton).Click += OnAcceptClick;
            FindViewById<Button>(Resource.Id.cancelButton).Click += OnCancelClick;
            nombreEditText = FindViewById<EditText>(Resource.Id.nombreEditText);
            documentoEditText = FindViewById<EditText>(Resource.Id.documentEditText);
            brazoEditText = FindViewById<EditText>(Resource.Id.brazoEditText);
            estatutaEditText= FindViewById<EditText>(Resource.Id.estaturaEditText);
            hombreRadioButon = FindViewById<RadioButton>(Resource.Id.hombreRadioButton);
        }

        void OnAcceptClick(object sender, EventArgs e)
        {

            Nadador nadador = new Nadador();
            nadador.documentId = documentoEditText.Text;
            nadador.nombre = nombreEditText.Text;
            nadador.sexo = hombreRadioButon.Checked;
            nadador.estatura = Convert.ToInt32(estatutaEditText.Text);
            nadador.longitudBrazo = Convert.ToInt32(brazoEditText.Text); ;
            registroDB.addNewNadador(nadador);

            Bundle bundle = new Bundle();
            var intent = new Intent(this, typeof(Brazada));
            bundle.PutString("documento", nadador.documentId);
            intent.PutExtras(bundle);
            StartActivity(intent);
        }

        void OnCancelClick(object sender, EventArgs e)
        {

        }


    }
}

