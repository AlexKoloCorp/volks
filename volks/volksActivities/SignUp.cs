using System;
using Android.App;
using Android.Content;
using Android.Gms.Tasks;
using Android.OS;
using Android.Support.V7.App;
using Android.Widget;
using Firebase.Auth;

namespace volks.volksActivities
{
    [Activity(Label = "SignUp", Theme = "@style/AppTheme.NoActionBar")]
    public class SignUp : AppCompatActivity, IOnCompleteListener
    {
        private EditText input_email, input_password, confirm_password;
        private Button btn_register, btn_back;
        private LinearLayout activity_signUp;

        FirebaseAuth auth;       

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.signUp_layout);

            input_email = FindViewById<EditText>(Resource.Id.registerEmail);
            input_password = FindViewById<EditText>(Resource.Id.register_password);
            confirm_password = FindViewById<EditText>(Resource.Id.Confirm_password_zone);
            btn_back = FindViewById<Button>(Resource.Id.Back_button);
            btn_back.Click += Btn_back_Click;
            btn_register = FindViewById<Button>(Resource.Id.Register_button);

            btn_register.Click += Btn_register_Click;
            //init Firebase
            auth = FirebaseAuth.GetInstance(MainActivity.app);

        }
        private void Btn_back_Click(object sender, EventArgs e)
        {
            Intent Back = new Intent(this, typeof(MainActivity));
            StartActivity(Back);
            Finish();
        }

        private void Btn_register_Click(object sender, EventArgs e)
        {
            if((input_email.Text.ToString() != null && input_password.Text.ToString() !=null && confirm_password.Text.ToString() != null) &&(input_password.Text.ToString() == confirm_password.Text.ToString()))
            {
                SignUpUser(input_email.Text, input_password.Text);
                StartActivity(new Android.Content.Intent(this, typeof(MainActivity)));
                Finish();
            }
            else if (!(input_password.Text.ToString() == confirm_password.Text.ToString()))
            {
                Toast.MakeText(this, "passwords are not equal ", ToastLength.Short).Show();
            }
            else if(input_email.Text.ToString() == null || input_password.Text.ToString() == null || confirm_password.Text.ToString() == null)
            {
                Toast.MakeText(this, "you didn't fill all fields", ToastLength.Short).Show();
            }
        }

        private void SignUpUser(string email, string password)
        {
            auth.CreateUserWithEmailAndPassword(email, password)
                .AddOnCompleteListener(this,this);
        }
        public void OnComplete(Task task)
        {
            if (task.IsSuccessful == true)
            {
                Toast.MakeText(this, "Register successfully", ToastLength.Short).Show();
            }
            else
            {
                Toast.MakeText(this, "Register failed", ToastLength.Short).Show();
            }
        }
    }
}