
using Android.App;
using Android.OS;
using Android.Support.V4.Widget;
using Android.Support.V7.App;
using Android.Views;
using Android.Widget;
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

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.news_feed);
            myDrawerLayout = FindViewById<DrawerLayout>(Resource.Id.drawer_layout);
            myLeftDrawer = FindViewById<ListView>(Resource.Id.left_drawer);
            myToolBar = FindViewById<SupportToolbar>(Resource.Id.toolBar);
            SetSupportActionBar(myToolBar);
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
            myDrawerToggle.SyncState();
        }
        public override bool OnOptionsItemSelected(IMenuItem item)
        {
            myDrawerToggle.OnOptionsItemSelected(item);
            return base.OnOptionsItemSelected(item);
        }
    }
}