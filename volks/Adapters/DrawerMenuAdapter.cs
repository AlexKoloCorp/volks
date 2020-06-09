using System;
using System.Collections.Generic;
using Android.Support.V7.Widget;
using Android.Views;
using Android.Widget;

namespace volks.Adapters
{
    class DrawerMenuViewHolder : RecyclerView.ViewHolder, View.IOnClickListener
    {
        public IItemClickListener ItemClickListener;
        public ImageView menu_icon { get; set; }
        public TextView menu_text { get; set; }
        public DrawerMenuViewHolder(View itemView) : base(itemView)
        {
            menu_icon = itemView.FindViewById<ImageView>(Resource.Id.left_menu_Icon);
            menu_text = itemView.FindViewById<TextView>(Resource.Id.left_menu_Icon);
            itemView.SetOnClickListener(this);
        }
        public void SetItemClickListener(IItemClickListener itemClickListener)
        {
            this.ItemClickListener = itemClickListener;
        }

        public void OnClick(View v)
        {
            ItemClickListener.OnClick(v, AdapterPosition, false);
        }

    }
    class DrawerMenuAdapter:RecyclerView.Adapter, IItemClickListener
    {
        public List<LeftMenuData> menuListData = new List<LeftMenuData>();


        public DrawerMenuAdapter(List<LeftMenuData> menuListData)
        {
            this.menuListData = menuListData;
        }

        public override int ItemCount
        {
            get
            {
                return menuListData.Count;
            }
        }

        public override void OnBindViewHolder(RecyclerView.ViewHolder holder, int position)
        {
            DrawerMenuViewHolder viewHolder = holder as DrawerMenuViewHolder;
            viewHolder.menu_icon.SetImageResource(menuListData[position].menu_icon);
            viewHolder.menu_text.Text = menuListData[position].menu_text;
            viewHolder.SetItemClickListener(this);

        }

        public void OnClick(View itemView, int position, bool isLongClick)
        {
            throw new NotImplementedException();
        }

        public override RecyclerView.ViewHolder OnCreateViewHolder(ViewGroup parent, int viewType)
        {
            LayoutInflater inflater = LayoutInflater.From(parent.Context);
            View itemView = inflater.Inflate(Resource.Layout.left_drawer_menu_items, parent, false);
            return new DrawerMenuViewHolder(itemView);
        }
    }
}