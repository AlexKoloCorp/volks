
using Android.App;
using Android.Content;
using Android.Content.Res;
using Android.OS;
using Android.Support.V4.Widget;
using Android.Support.V7.App;
using Android.Util;
using Android.Views;
using Android.Widget;
using Firebase.Auth;
using Firebase.Storage;
using Square.Picasso;
using System;
using System.Collections.Generic;
using volks.model;
using static Android.Views.View;
using SupportToolbar = Android.Support.V7.Widget.Toolbar;


namespace volks.volksActivities
{
    [Activity(Label = "Configurator_Activity", Theme = "@style/AppTheme.NoActionBar")]
    public class Configurator_Activity : AppCompatActivity, IOnClickListener
    {
        private SupportToolbar myToolBar;
        private MyActionBarDrawerToggle myDrawerToggle;
        private DrawerLayout myDrawerLayout;
        private ListView myLeftDrawer;
        private ArrayAdapter leftArrayAdapter;
        private List<string> leftDataSet;
        public View color_grey;
        public ImageView colorImage;
        
        FirebaseAuth auth;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.configurator_layout);

            //For left menu
            myDrawerLayout = FindViewById<DrawerLayout>(Resource.Id.drawer_layout);
            myLeftDrawer = FindViewById<ListView>(Resource.Id.left_drawer);
            myToolBar = FindViewById<SupportToolbar>(Resource.Id.toolBar);
            SetSupportActionBar(myToolBar);

            //init Firebase
            auth = FirebaseAuth.GetInstance(MainActivity.app);


            colorImage = FindViewById<ImageView>(Resource.Id.CarImage);
            


            //color picker
            color_grey = FindViewById<View>(Resource.Id.c_grey);
            View color_yellow = FindViewById<View>(Resource.Id.c_yellow);
            View color_red = FindViewById<View>(Resource.Id.c_red);
            View color_black = FindViewById<View>(Resource.Id.c_black);
            View color_blue = FindViewById<View>(Resource.Id.c_blue);
            View color_green = FindViewById<View>(Resource.Id.c_green);
            View color_white = FindViewById<View>(Resource.Id.c_white);

            color_grey.SetOnClickListener(this);
            color_yellow.SetOnClickListener(this);
            color_red.SetOnClickListener(this);
            color_black.SetOnClickListener(this);
            color_blue.SetOnClickListener(this);
            color_green.SetOnClickListener(this);
            color_white.SetOnClickListener(this);
            
            //left menu items
            leftDataSet = new List<string>();
            leftDataSet.Add("my cabinet");
            leftDataSet.Add("news");
            leftDataSet.Add("configurator");
            leftDataSet.Add("LogOut");
            leftArrayAdapter = new ArrayAdapter<string>(this, Android.Resource.Layout.SimpleListItem1, leftDataSet);
            myLeftDrawer.Adapter = leftArrayAdapter;
            myLeftDrawer.ItemClick += MyLeftDrawer_ItemClick;
            myDrawerToggle = new MyActionBarDrawerToggle(
                this,
                myDrawerLayout,
                Resource.String.openDraver,
                Resource.String.closeDraver
                );
#pragma warning disable CS0618 // Type or member is obsolete
            myDrawerLayout.SetDrawerListener(myDrawerToggle);
#pragma warning restore CS0618 // Type or member is obsolete
            SupportActionBar.SetHomeButtonEnabled(true);
            SupportActionBar.SetDisplayHomeAsUpEnabled(true);
            SupportActionBar.SetDisplayShowTitleEnabled(false);
            myDrawerToggle.SyncState();
        }

        private void MyLeftDrawer_ItemClick(object sender, AdapterView.ItemClickEventArgs e)
        {
            int menuItemSwitcher = e.Position;
            switch (menuItemSwitcher)
            {
                case 0:
                    Intent UserCabinet = new Intent(this, typeof(UserCarLog));
                    StartActivity(UserCabinet);
                    Finish();
                    break;
                case 1:
                    Intent NewsFeed = new Intent(this, typeof(NewsActivity));
                    StartActivity(NewsFeed);
                    Finish();
                    break;
                case 2:
                    Toast.MakeText(this, "This page is already start", ToastLength.Short).Show();
                    break;
                case 3:
                    auth.SignOut();
                    if (auth.CurrentUser == null)
                    {
                        Intent LogOut = new Intent(this, typeof(MainActivity));
                        StartActivity(LogOut);
                        Finish();
                    }
                    break;
            }
            //throw new System.NotImplementedException();
        }

        public override bool OnOptionsItemSelected(IMenuItem item)
        {
            myDrawerToggle.OnOptionsItemSelected(item);
            return base.OnOptionsItemSelected(item);
        }
        public override void OnConfigurationChanged(Configuration newConfig)
        {
            base.OnConfigurationChanged(newConfig);
            myDrawerToggle.OnConfigurationChanged(newConfig);
        }

        public void OnClick(View v)
        {
            string imageUrl;
            int temp = dpToPx(55);
            if (v.Id == Resource.Id.c_grey)
            {
                imageUrl = "https://firebasestorage.googleapis.com/v0/b/volkswagen-acf75.appspot.com/o/porshe%2Fcolors%2Fporshe_grey.png?alt=media&token=2d82286b-6fa8-438f-b7cc-c0020741a30d";
                Picasso.With(this).Load(imageUrl).Into(colorImage);
            }
            if (v.Id == Resource.Id.c_black)
            {
                imageUrl = "https://firebasestorage.googleapis.com/v0/b/volkswagen-acf75.appspot.com/o/porshe%2Fcolors%2Fporshe_black.png?alt=media&token=a0159147-cffe-4e95-8c58-b2fa5a8b4c52";
                Picasso.With(this).Load(imageUrl).Into(colorImage);
            }
            if (v.Id == Resource.Id.c_blue)
            {
                imageUrl = "https://firebasestorage.googleapis.com/v0/b/volkswagen-acf75.appspot.com/o/porshe%2Fcolors%2Fporshe_blue.png?alt=media&token=48723e47-35ee-41eb-bcba-1906f31110a3";
                Picasso.With(this).Load(imageUrl).Into(colorImage);
            }
            if (v.Id == Resource.Id.c_green)
            {
                imageUrl = "https://firebasestorage.googleapis.com/v0/b/volkswagen-acf75.appspot.com/o/porshe%2Fcolors%2Fporshe_green.png?alt=media&token=a5f19781-a832-4ac6-86ef-d3d98967efe6";
                Picasso.With(this).Load(imageUrl).Into(colorImage);
            }
            if (v.Id == Resource.Id.c_red)
            {
                imageUrl = "https://firebasestorage.googleapis.com/v0/b/volkswagen-acf75.appspot.com/o/porshe%2Fcolors%2Fporshe_red.png?alt=media&token=2a49d4fe-ab36-446e-9832-f55b98ac5882";
                Picasso.With(this).Load(imageUrl).Into(colorImage);
            }
            if (v.Id == Resource.Id.c_yellow)
            {
                imageUrl = "https://firebasestorage.googleapis.com/v0/b/volkswagen-acf75.appspot.com/o/porshe%2Fcolors%2Fporshe_yellow.png?alt=media&token=6d38a46c-3178-4b8e-97ea-38b8e4223ee9";
                Picasso.With(this).Load(imageUrl).Into(colorImage);
            }
            if (v.Id == Resource.Id.c_white)
            {
                imageUrl = "https://firebasestorage.googleapis.com/v0/b/volkswagen-acf75.appspot.com/o/porshe%2Fcolors%2Fporshe_white.png?alt=media&token=f21c83da-d669-4f9f-a360-dac0a81bc3f1";
                Picasso.With(this).Load(imageUrl).Into(colorImage);
            }

        }
        public static int dpToPx(int dp)
        {
            return dp * (560 / 160);
        }
    }
}