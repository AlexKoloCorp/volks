using System.Collections.Generic;
using Android.Support.V7.Widget;
using Android.Views;
using Android.Widget;

namespace volks.Adapters
{
    class UserViewHolder : RecyclerView.ViewHolder
    {
        public TextView title_text { get; set; }
        public TextView text_from_db { get; set; }
        public UserViewHolder(View itemView) : base(itemView)
        {
            title_text = itemView.FindViewById<TextView>(Resource.Id.user_title);
            text_from_db = itemView.FindViewById<TextView>(Resource.Id.info_from_user_db);
        }
    }
    class UserInfoAdapter : RecyclerView.Adapter
    {
        public List<UserData> lstData = new List<UserData>();

        public UserInfoAdapter(List<UserData> lstData)
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
            UserViewHolder viewHolder = holder as UserViewHolder;
            viewHolder.title_text.Text = lstData[position].text_title;
            viewHolder.text_from_db.Text = lstData[position].text_data_from_db;
        }

        public override RecyclerView.ViewHolder OnCreateViewHolder(ViewGroup parent, int viewType)
        {
            LayoutInflater inflater = LayoutInflater.From(parent.Context);
            View itemView = inflater.Inflate(Resource.Layout.user_info_layout, parent, false);
            return new UserViewHolder(itemView);
        }
    }
}