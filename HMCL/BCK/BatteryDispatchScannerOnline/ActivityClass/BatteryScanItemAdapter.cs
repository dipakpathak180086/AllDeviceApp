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
    public class BatteryScanItemAdapter : RecyclerView.Adapter
    {
        private int mSelectedItem = -1;
        public event EventHandler<int> btnClick;
        private Context context;
        public List<ViewBatteryScanData> data;
        LayoutInflater inflater = null;

        public BatteryScanItemAdapter(Context context, List<ViewBatteryScanData> models)
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
        private void ItemClick(int obj)
        {
            try
            {
                if (btnClick != null)
                {

                    btnClick(this, obj);
                }
            }
            catch (Exception ex) { Toast.MakeText(context, ex.Message, ToastLength.Long).Show(); }
        }
        public class ViewHolder : RecyclerView.ViewHolder
        {
            public ImageButton imgClick;
            public TextView Deilvery;
            public TextView BatteryNo;
            public TextView SrNo;

            public ViewHolder(View v, Action<int> listener) : base(v)
            {


                Deilvery = (TextView)v.FindViewById(Resource.Id.listtxtDelivery);
                SrNo = (TextView)v.FindViewById(Resource.Id.listtxtSrNo);
                BatteryNo = (TextView)v.FindViewById(Resource.Id.listtxtBatteryBarcode);
                imgClick = v.FindViewById<ImageButton>(Resource.Id.listtxtDelete);
                imgClick.Click += (sender, e) => listener(base.Position);
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
                vh.SrNo.Text = data[position].SrNo.ToString();
                vh.Deilvery.Text = data[position].Delivery.ToString();
                vh.BatteryNo.Text = data[position].BatteryType.ToString();

            }
            catch (System.Exception ex) { Toast.MakeText(context, ex.Message, ToastLength.Long).Show(); }
        }
        public override RecyclerView.ViewHolder OnCreateViewHolder(ViewGroup parent, int viewType)
        {
            ViewHolder vh = null;
            try
            {
                View itemView = LayoutInflater.From(parent.Context).Inflate(Resource.Layout.ViewBatteryScandata, parent, false);
                vh = new ViewHolder(itemView, ItemClick);


            }
            catch (Exception ex) { Toast.MakeText(context, ex.Message, ToastLength.Long).Show(); }
            return vh;
        }
    }
    #endregion

}