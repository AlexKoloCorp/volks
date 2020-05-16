﻿using Android.App;
using Android.OS;
using Android.Support.V7.App;
using Android.Widget;
using System;
using Android.Content;
using volks.volksActivities;

namespace volks
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme.NoActionBar", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        private EditText username, password;      
        private Button btn_logIn, btn_go_to_carLog, btn_news;
        protected override void OnCreate(Bundle savedInstanceState)
        {      
            base.OnCreate(savedInstanceState);
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.activity_main);
            username = FindViewById<EditText>(Resource.Id.Username_zone);
            password = FindViewById<EditText>(Resource.Id.Password_zone);
           

            btn_logIn = FindViewById<Button>(Resource.Id.Login_button);
            btn_logIn.Click += Button_Click;
            btn_go_to_carLog = FindViewById<Button>(Resource.Id.Sigin_button);
            btn_go_to_carLog.Click += Btn_go_to_carLog_Click;
            btn_news = FindViewById<Button>(Resource.Id.Temp);
            btn_news.Click += Btn_news_Click;
        }

        private void Btn_news_Click(object sender, EventArgs e)
        {
            Intent NextActivity = new Intent(this, typeof(NewsActivity));
            StartActivity(NextActivity);
        }

        private void Btn_go_to_carLog_Click(object sender, EventArgs e)
        {
            Intent NextActivity = new Intent(this, typeof(UserCarLog));
            StartActivity(NextActivity);
            //throw new NotImplementedException();
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