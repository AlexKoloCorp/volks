using System.Collections.Generic;

using Android.App;
using Android.OS;
using Android.Support.V7.Widget;
using Android.Views;

namespace volks.Adapters
{
    public class CarFragment:Fragment
    {
        private RecyclerView my_car_list;
        private CarInfoAdapter adapter;
        private RecyclerView.LayoutManager layoutManager;
        private List<Data> lstData = new List<Data>();

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            View view = inflater.Inflate(Resource.Layout.CarFragment, container, false);
            //action with lists
            my_car_list = view.FindViewById<RecyclerView>(Resource.Id.Car_list);
            //my_car_list.HasFixedSize = true;
            layoutManager = new LinearLayoutManager(Activity);
            my_car_list.SetLayoutManager(layoutManager);
            adapter = new CarInfoAdapter(lstData);
            my_car_list.SetAdapter(adapter);

            initData();
            return view;
        }
        private void initData()
        {
            if (lstData.Count < 2)
            {
                lstData.Add(new Data() { text_title = "Date of purchase", text_data_from_db = "24.05.2020" });
                lstData.Add(new Data() { text_title = "Warranty period", text_data_from_db = "3 years" });
            }            
        }
    }
}