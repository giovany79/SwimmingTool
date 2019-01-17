using System;
using Android.App;
using Android.Widget;
using Android.OS;
using Android.Content;
using Android.Content.PM;
using Android;
using Android.Support.V4.App;

namespace SwimmingTool
{
    [Activity(Label = "SwimmingTool", MainLauncher = true, Icon = "@mipmap/icon")]
    public class MainActivity : Activity
    {

        private string[] requiredPermissions = { Manifest.Permission.Camera };

        public static RegistroRepository PersonRepo { get; private set; }
        public static Boolean isCammeraPermissionEnabled = false;
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

            if (((int)Build.VERSION.SdkInt) >= (int)BuildVersionCodes.M)
            {
                RequestAllPersmissions();
            }
            else
            {
                isCammeraPermissionEnabled = true;
            }
        }

        void OnAcceptClick(object sender, EventArgs e)
        {
            if (!isCammeraPermissionEnabled)
            {
                Toast.MakeText(this, "Debes aceptar permisos para usar la cámara!", ToastLength.Short).Show();
                return;
            }

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

        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, Permission[] grantResults)
        {
            switch (requestCode)
            {
                case 1000:
                    {
                        // If request is cancelled, the result arrays are empty.
                        if (grantResults.Length > 0 && grantResults[0] == Permission.Granted)
                        {
                            isCammeraPermissionEnabled = true;
                        }
                        else
                        {
                            isCammeraPermissionEnabled = false;
                        }
                        return;
                    }
            }
        }

        private void RequestAllPersmissions()
        {
            ActivityCompat.RequestPermissions(this, requiredPermissions, 1000);
        }

    }
}

