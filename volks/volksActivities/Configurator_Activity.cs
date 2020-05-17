
using Android.App;
using Android.OS;
using Android.Support.V7.App;

namespace volks.volksActivities
{
    [Activity(Label = "Configurator_Activity")]
    public class Configurator_Activity : AppCompatActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.configurator_layout);
            // Create your application here
        }
    }
}