using System;
using System.Collections.Generic;

using Android.App;
using Android.Content;
using Android.Content.Res;
using Android.OS;
using Android.Support.V4.Widget;
using Android.Support.V7.App;
using Android.Views;
using Android.Widget;
using Firebase.Auth;
using volks.Adapters;
using volks.model;
using static Android.Views.View;
using SupportToolbar = Android.Support.V7.Widget.Toolbar;

namespace volks.volksActivities
{
    [Activity(Label = "UserCarLog", Theme = "@style/AppTheme.NoActionBar")]
    public class UserCarLog : AppCompatActivity, IOnClickListener
    {
        public static readonly int PickImageId = 1000;
        private SupportToolbar myToolBar;
        private MyActionBarDrawerToggle myDrawerToggle;
        private DrawerLayout myDrawerLayout;
        private ListView myLeftDrawer;
        private ArrayAdapter leftArrayAdapter;
        private List<string> leftDataSet;
        private TextView user_email, car_info_switcher, user_info_switcher;

        public UserFragment user_frag;
        public CarFragment car_frag;
        public FragmentTransaction fragmentTransaction;

        //private RecyclerView my_car_list;
        //private CarInfoAdapter adapter;
        //private RecyclerView.LayoutManager layoutManager;
        //private List<Data> lstData = new List<Data>();        
        Refractored.Controls.CircleImageView userImage;
        FirebaseAuth auth;
        protected override void OnCreate(Bundle savedInstanceState)
        {        
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.user_carLog);
            user_email = FindViewById<TextView>(Resource.Id.Ueser_email);
            
            //string to_email= Intent.GetStringExtra("username")?? "posht@gmail.com";
            user_email.Text=Intent.GetStringExtra("key_username");

            //add fragments
            car_info_switcher = FindViewById<TextView>(Resource.Id.Car_Info);
            user_info_switcher = FindViewById<TextView>(Resource.Id.Car_Log_User_Info);

            car_info_switcher.SetOnClickListener(this);
            user_info_switcher.SetOnClickListener(this);

            user_frag = new UserFragment();
            car_frag = new CarFragment();
            //end fragments

            myDrawerLayout = FindViewById<DrawerLayout>(Resource.Id.drawer_layout);
            myLeftDrawer = FindViewById<ListView>(Resource.Id.left_drawer);
            myToolBar = FindViewById<SupportToolbar>(Resource.Id.toolBar);
            SetSupportActionBar(myToolBar);

            userImage = FindViewById<Refractored.Controls.CircleImageView>(Resource.Id.User_avatar_Image);
            userImage.Click += UserImage_Click;

            ////action with lists
            //my_car_list = FindViewById<RecyclerView>(Resource.Id.Car_list);
            ////my_car_list.HasFixedSize = true;
            //layoutManager = new LinearLayoutManager(this);
            //my_car_list.SetLayoutManager(layoutManager);
            //adapter = new CarInfoAdapter(lstData);
            //my_car_list.SetAdapter(adapter);

            //initData();

           
            
            //init Firebase
            auth = FirebaseAuth.GetInstance(MainActivity.app);

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

        public void OnClick(View v)
        {
            
            fragmentTransaction = this.FragmentManager.BeginTransaction();
            switch (v.Id)
            {
                case Resource.Id.Car_Info:
                    fragmentTransaction.Replace(Resource.Id.container_fragments, car_frag,"test");
                    fragmentTransaction.Commit();     
                     
                    break;
                case Resource.Id.Car_Log_User_Info:
                    fragmentTransaction.Replace(Resource.Id.container_fragments, user_frag,"puw");
                    fragmentTransaction.Commit();                    
                    break;
            }
        }


        private void UserImage_Click(object sender, EventArgs e)
        {
            Intent = new Intent();
            Intent.SetType("image/*");
            Intent.SetAction(Intent.ActionGetContent);
            StartActivityForResult(Intent.CreateChooser(Intent, "Select Picture"), PickImageId);
        }
        protected override void OnActivityResult(int requestCode, Result resultCode, Intent data)
        {
            if ((requestCode == PickImageId) && (resultCode == Result.Ok) && (data != null))
            {
                Android.Net.Uri uri = data.Data;
                userImage.SetImageURI(uri);
            }
        }


        //private void initData()
        //{
        //    lstData.Add(new Data() { text_title = "Date of purchase", text_data_from_db = "24.05.2020" });
        //    lstData.Add(new Data() { text_title = "Warranty period", text_data_from_db = "3 years" });
        //}

        private void MyLeftDrawer_ItemClick(object sender, AdapterView.ItemClickEventArgs e)
        {
            int menuItemSwitcher = e.Position;
            switch (menuItemSwitcher)
            {
                case 0:
                    Toast.MakeText(this, "This page is already start", ToastLength.Short).Show();                   
                    
                    break;
                case 1:
                    Intent NewsFeed = new Intent(this, typeof(NewsActivity));
                    StartActivity(NewsFeed);
                    Finish();
                    break;
                case 2:
                    Intent MyConfigurator = new Intent(this, typeof(Configurator_Activity));
                    StartActivity(MyConfigurator);
                    Finish();
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

        
    }
}