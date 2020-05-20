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
    [Activity(Label = "ForgotPass", Theme = "@style/AppTheme.NoActionBar")]
    public class ForgotPass : AppCompatActivity, IOnCompleteListener
    {
        private EditText exist_email;
        private Button btn_change, btn_back;
        private LinearLayout activity_changePass;

        FirebaseAuth auth;       

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.forgotPass_layout);

            exist_email = FindViewById<EditText>(Resource.Id.current_email);           
            btn_change = FindViewById<Button>(Resource.Id.Change_password_button);
            btn_back = FindViewById<Button>(Resource.Id.Back_button);
            btn_back.Click += Btn_back_Click;
            btn_change.Click += Btn_change_Click;

            //init Firebase
            auth = FirebaseAuth.GetInstance(MainActivity.app);

        }

        private void Btn_back_Click(object sender, EventArgs e)
        {
            Intent Back = new Intent(this, typeof(MainActivity));
            StartActivity(Back);
            Finish();
        }

        private void Btn_change_Click(object sender, EventArgs e)
        {
            ChangePassword(exist_email.Text);
            Intent changePassword = new Intent(this, typeof(MainActivity));
            StartActivity(changePassword);
            Finish();

        }

        private void ChangePassword(string email)
        {
            auth.SendPasswordResetEmail(email)
                .AddOnCompleteListener(this, this);
        }
        public void OnComplete(Task task)
        {
            if (task.IsSuccessful == true)
            {
                Toast.MakeText(this, "Reset password ling sent to email: "+ exist_email.Text, ToastLength.Short).Show();
            }
            else
            {
                Toast.MakeText(this, "Password change failed", ToastLength.Short).Show();
            }
        }
    }
}