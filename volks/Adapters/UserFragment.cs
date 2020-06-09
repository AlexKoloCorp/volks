using System.Collections.Generic;

using Android.App;
using Android.OS;
using Android.Support.V7.Widget;
using Android.Views;

namespace volks.Adapters
{
    public class UserFragment:Fragment
    {
        private RecyclerView my_user_list;
        private UserInfoAdapter adapter;
        private RecyclerView.LayoutManager layoutManager;
        private List<UserData> lstData = new List<UserData>();
        
        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            View view = inflater.Inflate(Resource.Layout.UserFragment, container, false);
            my_user_list = view.FindViewById<RecyclerView>(Resource.Id.User_list);
            //my_car_list.HasFixedSize = true;
            layoutManager = new LinearLayoutManager(Activity);
            my_user_list.SetLayoutManager(layoutManager);
            adapter = new UserInfoAdapter(lstData);
            my_user_list.SetAdapter(adapter);

            initData();
            

            return view;
        }
        public void freeData() {
            lstData.Clear();
        }
        private void initData()
        {
            if (lstData.Count < 3)
            {
                lstData.Add(new UserData() { text_title = "Name", text_data_from_db = "Alex" });
                lstData.Add(new UserData() { text_title = "Second name", text_data_from_db = "Nevermind" });
                lstData.Add(new UserData() { text_title = "Country", text_data_from_db = "Ukraine" });
            }            
        }
    }
}