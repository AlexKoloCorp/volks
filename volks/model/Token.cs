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

namespace volks.model
{
    public class Token
    {
        public int Id { get; set; }
        public string access_token { get; set; }
        public string arror_description { get; set; }
        public DateTime expire_date { get; set; }
        public Token() { }
    }
}