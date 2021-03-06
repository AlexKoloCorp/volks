﻿
using Android.App;
using Android.Content;
using Android.Content.Res;
using Android.OS;
using Android.Support.V4.Widget;
using Android.Support.V7.App;
using Android.Views;
using Android.Widget;
using System.Collections.Generic;
using volks.model;
using SupportToolbar = Android.Support.V7.Widget.Toolbar;

namespace volks.volksActivities
{
    [Activity(Label = "NewsActivity", Theme = "@style/AppTheme.NoActionBar")]
    public class NewsActivity : AppCompatActivity 
    {
        private SupportToolbar myToolBar;
        private MyActionBarDrawerToggle myDrawerToggle;
        private DrawerLayout myDrawerLayout;
        private ListView myLeftDrawer;
        private ArrayAdapter leftArrayAdapter;
        private List<string> leftDataSet;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.news_feed);
            myDrawerLayout = FindViewById<DrawerLayout>(Resource.Id.drawer_layout);
            myLeftDrawer = FindViewById<ListView>(Resource.Id.left_drawer);
            myToolBar = FindViewById<SupportToolbar>(Resource.Id.toolBar);
            SetSupportActionBar(myToolBar);

            leftDataSet = new List<string>();
            leftDataSet.Add("my cabinet");
            leftDataSet.Add("news");
            leftDataSet.Add("configurator");
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
                    break;
                case 1:
                    Toast.MakeText(this, "This page is already start", ToastLength.Short).Show();                    
                    break;
                case 2:
                    Intent MyConfigurator = new Intent(this, typeof(Configurator_Activity));
                    StartActivity(MyConfigurator);
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