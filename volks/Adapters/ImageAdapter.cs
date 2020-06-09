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
using Java.Lang;

namespace volks.Adapters
{
    public class ImageAdapter : BaseAdapter
    {
        Context context;

        public ImageAdapter(Context c)
        {
            context = c;
        }
       
        public override int Count
        {
            get { return thumbIds.Length; }
        }

    public override Java.Lang.Object GetItem(int position)
        {
            return null;
        }

        public override long GetItemId(int position)
        {
            return 0;
        }

        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            ImageView i = new ImageView(context);

            i.SetImageResource(thumbIds[position]);
            i.LayoutParameters = new Gallery.LayoutParams(1500, 700);
            i.SetScaleType(ImageView.ScaleType.FitXy);

            return i;
        }
        int[] thumbIds = {
            Resource.Drawable.porshe_blue,
            Resource.Drawable.porshe_green,
            Resource.Drawable.porshe_red,
            Resource.Drawable.porshe_white,
            Resource.Drawable.porshe_yellow,
            Resource.Drawable.porshe_black,
            Resource.Drawable.porshe_grey
     };
    }
}