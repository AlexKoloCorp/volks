using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace volks.volksActivities
{
    [Activity(Label = "UserCarLog")]
    public class UserCarLog : Activity
    {
        List<string> list;           
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.user_carLog);
            var listView = FindViewById<ListView>(Resource.Id.Car_Info_List);
            list = new List<string>();
            list.AddRange(new string[] { "Color", "Date of purchase", "Warranty period" });
            ArrayAdapter<string> adapter = new ArrayAdapter<string>(this, Android.Resource.Layout.SimpleListItem1, list);
            listView.Adapter = adapter;
        }
    }
}