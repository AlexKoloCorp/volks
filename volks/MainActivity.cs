using Android.App;
using Android.OS;
using Android.Support.V7.App;
using Android.Widget;
using System;
using Android.Content;
using volks.volksActivities;
using Firebase.Auth;
using Firebase;
using Android.Gms.Tasks;

namespace volks
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme.NoActionBar", MainLauncher = true)]
    public class MainActivity : AppCompatActivity,IOnCompleteListener
    {
        private EditText username, password;      
        private Button btn_logIn, btn_sigIn;
        private TextView forgot_pass;
        private LinearLayout activity_main;

        public static FirebaseApp app;
        FirebaseAuth auth;

        protected override void OnCreate(Bundle savedInstanceState)
        {      
            base.OnCreate(savedInstanceState);
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.activity_main);
            username = FindViewById<EditText>(Resource.Id.Username_zone);
            password = FindViewById<EditText>(Resource.Id.Password_zone);
           
            //login
            btn_logIn = FindViewById<Button>(Resource.Id.Login_button);
            btn_logIn.Click += Button_Click;
            
            //sigin
            btn_sigIn = FindViewById<Button>(Resource.Id.Sigin_button);
            btn_sigIn.Click += Btn_sigIn_Click;

            //forgot your password
            forgot_pass = FindViewById<TextView>(Resource.Id.Forgot_Pass);
            forgot_pass.Click += Forgot_pass_Click;

            activity_main = FindViewById<LinearLayout>(Resource.Id.activity_main);          

            //init firebase
            InitFirebaseAuth();
        }

        private void Forgot_pass_Click(object sender, EventArgs e)
        {
            StartActivity(new Android.Content.Intent(this, typeof(ForgotPass)));
            Finish();
        }

        private void Btn_sigIn_Click(object sender, EventArgs e)
        {
            Intent NextActivity = new Intent(this, typeof(SignUp));
            StartActivity(NextActivity);
        }

        private void InitFirebaseAuth()
        {
            var options = new FirebaseOptions.Builder()
                .SetApplicationId("1:483659150895:android:26fb0ce4899d33a115f8da")
                .SetApiKey("AIzaSyCSdWggkeyxjQxstcABdc90_hQlV_uVWr0")
                .Build();
            if (app == null)
                app = FirebaseApp.InitializeApp(this, options);
            auth = FirebaseAuth.GetInstance(app);

        }  

        private void Button_Click(object sender, System.EventArgs e)
        {
            //string usernameText=username.Text.ToString();
            //string pswd = password.Text.ToString();
            User user = new User(username.Text.ToString(), password.Text.ToString());
            if (user.CheckInfo())
            {               
                LoginUser(username.Text, password.Text);
            }
            else {
                Toast.MakeText(this, "you didn't fill all fields", ToastLength.Short).Show();
            }
            //throw new System.NotImplementedException();
        }

        private void LoginUser(string username, string password)
        {
            auth.SignInWithEmailAndPassword(username, password)
                .AddOnCompleteListener(this);
        }

        public void OnComplete(Task task)
        {
            if (task.IsSuccessful)
            {
                StartActivity(new Android.Content.Intent(this, typeof(NewsActivity)));
                Finish();
            }
            else
            {
                Toast.MakeText(this, "Login failed", ToastLength.Short).Show();
            }
        }
    }
}