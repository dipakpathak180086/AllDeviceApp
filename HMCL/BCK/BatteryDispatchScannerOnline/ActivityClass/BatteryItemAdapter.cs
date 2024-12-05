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
using BatteryDispatchScannerOnline;

namespace BatteryDispatchScannerOnline
{

    #region Frame Scan List Adapter
    public class BatteryItemAdapter : RecyclerView.Adapter
    {
        private int mSelectedItem = -1;
        public event EventHandler<int> btnCheck;
        private Context context;
        public List<ViewBatteryData> data;
        LayoutInflater inflater = null;

        public BatteryItemAdapter(Context context, List<ViewBatteryData> models)
        {
            this.context = context;
            this.data = models;
            //inflater = (LayoutInflater)context.
            //        GetSystemService(Context.LayoutInflaterService);
        }

        //public override int Count
        //{
        //    get
        //    { return data.Count; }
        //}


        //public override Java.Lang.Object GetItem(int position)
        //{
        //    return data[position].ToString();
        //}

        public override long GetItemId(int position)
        {
            return position;
        }
        private void ItemCheck(int obj)
        {
            try
            {
                if (btnCheck != null)
                {

                    btnCheck(this, obj);
                }
            }
            catch (Exception ex) { Toast.MakeText(context, ex.Message, ToastLength.Long).Show(); }
        }
        public class ViewHolder : RecyclerView.ViewHolder
        {
            public TextView Plant;
            public TextView BatteryType;
            public TextView Balance;
            public TextView Qty;
            public TextView ScanQty;
            public ViewHolder(View v) : base(v)
            {
                Plant = (TextView)v.FindViewById(Resource.Id.listtxtPlant);
                BatteryType = (TextView)v.FindViewById(Resource.Id.listtxtBatteryType);
                Qty = (TextView)v.FindViewById(Resource.Id.listtxtQty);
                ScanQty = (TextView)v.FindViewById(Resource.Id.listtxtSQty);
                Balance = (TextView)v.FindViewById(Resource.Id.listtxtBalance);
            }
        }


        //public override View GetView(int position, View convertView, ViewGroup parent)
        //{
        //    ViewHolder holder;

        //    View view = inflater.Inflate(Resource.Layout.view_case_item, parent, false);

        //    holder = new ViewHolder(view);

        //    holder.Material.Text = data[position]._Material;
        //    holder.Line.Text = data[position]._Line;
        //    holder.Qty.Text = data[position]._Qty;
        //    holder.ScanQty.Text = data[position]._ScanQty;

        //    return view;
        //}

        public override int ItemCount
        {
            get { return data.Count; }
        }

        public override void OnBindViewHolder(RecyclerView.ViewHolder holder, int position)
        {
            try
            {

                ViewHolder vh = holder as ViewHolder;
                vh.Plant.Text = data[position].Plant.ToString();
                vh.BatteryType.Text = data[position].ShowBatteryType.ToString();
                vh.Qty.Text = data[position].Qty.ToString();
                vh.ScanQty.Text = data[position].ScanQty.ToString();
                vh.Balance.Text = data[position].Balance.ToString();

            }
            catch (System.Exception ex) { Toast.MakeText(context, ex.Message, ToastLength.Long).Show(); }
        }
        public override RecyclerView.ViewHolder OnCreateViewHolder(ViewGroup parent, int viewType)
        {
            ViewHolder vh = null;
            try
            {
                View itemView = LayoutInflater.From(parent.Context).Inflate(Resource.Layout.ViewBatterydata, parent, false);
                vh = new ViewHolder(itemView);


            }
            catch (Exception ex) { Toast.MakeText(context, ex.Message, ToastLength.Long).Show(); }
            return vh;
        }
    }
    #endregion

}