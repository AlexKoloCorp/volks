using Android.App;
using Android.OS;
using Android.Support.V7.App;
using Android.Runtime;
using Android.Widget;
using System;
using System.Threading.Tasks;

namespace volks
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        EditText username, password;      
        Button button;
        protected override void OnCreate(Bundle savedInstanceState)
        {      
            base.OnCreate(savedInstanceState);
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.activity_main);
             username = FindViewById<EditText>(Resource.Id.Username_zone);
             password = FindViewById<EditText>(Resource.Id.Password_zone);
             button = FindViewById<Button>(Resource.Id.Login_button);
            button.Click += Button_Click;

        }

        private void Button_Click(object sender, System.EventArgs e)
        {
            //string usernameText=username.Text.ToString();
            //string pswd = password.Text.ToString();
            User user = new User(username.Text.ToString(), password.Text.ToString());
            if (user.CheckInfo())
            {
                Toast.MakeText(this,"logined",ToastLength.Short).Show();
            }
            else {
                Toast.MakeText(this, "you didn't fill all fields", ToastLength.Short).Show();
            }
            //throw new System.NotImplementedException();
        }

      
    }
}