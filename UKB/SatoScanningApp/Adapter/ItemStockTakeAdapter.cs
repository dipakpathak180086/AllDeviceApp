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
using IOCLAndroidApp;
using IOCLAndroidApp.Models;
using SatoScanningApp;

namespace SatoScanningApp
{
    class ItemStockTakeAdapter : RecyclerView.Adapter
    {
        public List<ItemView> lstItem;
        Context context;
        public ItemStockTakeAdapter(List<ItemView> itemDetails, Context cont)
        {
            lstItem = itemDetails;
            context = cont;
        }
        public override int ItemCount
        {
            get { return lstItem.Count; }
        }
        public override void OnBindViewHolder(RecyclerView.ViewHolder holder, int position)
        {
            try
            {
                StockTakeItemHolder vh = holder as StockTakeItemHolder;
                if (!string.IsNullOrEmpty( lstItem[position].ScannedRFIDTag))
                {
                    vh.txtAssetCode.SetBackgroundColor(Android.Graphics.Color.LightGreen);
                    vh.txtRFIDTag.SetBackgroundColor(Android.Graphics.Color.LightGreen);
                }
                else
                {
                    vh.txtAssetCode.SetBackgroundResource(Resource.Drawable.BorderStyle);
                    vh.txtRFIDTag.SetBackgroundResource(Resource.Drawable.BorderStyle);
                }
                vh.txtAssetCode.Text = lstItem[position].Asset.ToString();
                vh.txtRFIDTag.Text = lstItem[position].RFIDTag.ToString();
                if (!string.IsNullOrEmpty(lstItem[position].ScannedRFIDTag))
                {
                    vh.txtScannedTag.Text = lstItem[position].ScannedRFIDTag.ToString();
                }
                else
                {
                    vh.txtScannedTag.Text = "";
                }

            }
            catch (System.Exception ex) { Toast.MakeText(context, ex.Message, ToastLength.Long).Show(); }
        }
        public override RecyclerView.ViewHolder OnCreateViewHolder(ViewGroup parent, int viewType)
        {
            StockTakeItemHolder vh = null;
            try
            {
                View itemView = LayoutInflater.From(parent.Context).Inflate(Resource.Layout.view_ItemStockTake, parent, false);
                vh = new StockTakeItemHolder(itemView);

            }
            catch (Exception ex) { Toast.MakeText(context, ex.Message, ToastLength.Long).Show(); }
            return vh;
        }
    }

    public class StockTakeItemHolder : RecyclerView.ViewHolder
    {
      
        public TextView txtAssetCode;
        public TextView txtRFIDTag;
        public TextView txtScannedTag;
        public StockTakeItemHolder(View itemview) : base(itemview)
        {
            try
            {
               
                txtAssetCode = itemview.FindViewById<TextView>(Resource.Id.txtAsset);
                txtRFIDTag = itemview.FindViewById<TextView>(Resource.Id.txtRFIDTag);
                txtScannedTag = itemview.FindViewById<TextView>(Resource.Id.txtScannedTag);

            }
            catch (Exception ex) { throw ex; }
        }
    }
}