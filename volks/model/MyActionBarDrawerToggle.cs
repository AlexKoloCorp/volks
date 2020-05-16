using Android.Support.V4.Widget;
using Android.Support.V7.App;
using Android.Views;
using SupportActionBarDrawerToggle = Android.Support.V7.App.ActionBarDrawerToggle;
namespace volks.model
{
    class MyActionBarDrawerToggle:SupportActionBarDrawerToggle
    {
        private AppCompatActivity mAppCompatActivity;
        private int mOpenedResourse;
        private int mClosedResourse;


        public MyActionBarDrawerToggle(AppCompatActivity host, DrawerLayout drawerLayout, int openedResourse, int closedResourse )
            :base(host, drawerLayout, openedResourse, closedResourse)
        {
            mAppCompatActivity = host;
            mOpenedResourse = openedResourse;
            mClosedResourse = closedResourse;
        }
        public override void OnDrawerOpened(View drawerView)
        {
            base.OnDrawerOpened(drawerView);
        }
        public override void OnDrawerClosed(View drawerView)
        {
            base.OnDrawerClosed(drawerView);
        }
        public override void OnDrawerSlide(View drawerView, float slideOffset)
        {
            base.OnDrawerSlide(drawerView, slideOffset);
        }
    }
}