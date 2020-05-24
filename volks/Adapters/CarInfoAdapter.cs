using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Support.V7.Widget;
using Android.Views;
using Android.Widget;

namespace volks.Adapters
{
    class CarViewHolder: RecyclerView.ViewHolder
    {
        public TextView title_text { get; set; }
        public TextView text_from_db { get; set; }
        public CarViewHolder(View itemView) : base(itemView)
        {
            title_text = itemView.FindViewById<TextView>(Resource.Id.car_title);
            text_from_db = itemView.FindViewById<TextView>(Resource.Id.info_from_db);
        }
    }
    class CarInfoAdapter : RecyclerView.Adapter
    {
        public List<Data> lstData = new List<Data>();

        public CarInfoAdapter(List<Data> lstData)
        {
            this.lstData = lstData;
        }

        public override int ItemCount
        {
            get
            {
                return lstData.Count;
            }
        }

        public override void OnBindViewHolder(RecyclerView.ViewHolder holder, int position)
        {
            CarViewHolder viewHolder = holder as CarViewHolder;
            viewHolder.title_text.Text = lstData[position].text_title;
            viewHolder.text_from_db.Text = lstData[position].text_data_from_db;
        }

        public override RecyclerView.ViewHolder OnCreateViewHolder(ViewGroup parent, int viewType)
        {
            LayoutInflater inflater = LayoutInflater.From(parent.Context);
            View itemView = inflater.Inflate(Resource.Layout.car_info_layout, parent, false);
            return new CarViewHolder(itemView);
        }
    }
}
