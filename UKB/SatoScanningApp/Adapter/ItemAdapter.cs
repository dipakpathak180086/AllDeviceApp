using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.Graphics;
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
    class ItemAdapter : RecyclerView.Adapter
    {
        public List<ItemView> lstItem;
        Context context;
        public ItemAdapter(List<ItemView> itemDetails, Context cont)
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
                ReceiveItemHolder vh = holder as ReceiveItemHolder;
                vh.txtAssetCode.Text = lstItem[position].Asset.ToString();
                if (lstItem[position].RFIDTag.ToString().Length > 0)
                {
                    if (lstItem[position].Qty.ToString() == lstItem[position].ScanQty.ToString())
                    {
                        vh.txtAssetCode.SetBackgroundColor(Color.DarkGreen);
                        vh.txtRFIDTag.SetBackgroundColor(Color.DarkGreen);
                    }
                    else if (lstItem[position].RFIDTag.ToString() != lstItem[position].ScannedRFIDTag.ToString())
                    {
                        vh.txtAssetCode.SetBackgroundColor(Color.DarkRed);
                        vh.txtRFIDTag.SetBackgroundColor(Color.DarkRed);
                    }

                    else
                    {
                        vh.txtAssetCode.SetBackgroundColor(Color.DarkGreen);
                        vh.txtRFIDTag.SetBackgroundColor(Color.DarkGreen);
                    }
                }
                vh.txtRFIDTag.Text = lstItem[position].RFIDTag.ToString();

            }
            catch (System.Exception ex) { Toast.MakeText(context, ex.Message, ToastLength.Long).Show(); }
        }
        public override RecyclerView.ViewHolder OnCreateViewHolder(ViewGroup parent, int viewType)
        {
            ReceiveItemHolder vh = null;
            try
            {
                View itemView = LayoutInflater.From(parent.Context).Inflate(Resource.Layout.view_Item, parent, false);
                vh = new ReceiveItemHolder(itemView);

            }
            catch (Exception ex) { Toast.MakeText(context, ex.Message, ToastLength.Long).Show(); }
            return vh;
        }
    }

    public class ReceiveItemHolder : RecyclerView.ViewHolder
    {
      
        public TextView txtAssetCode;
        public TextView txtRFIDTag;
        public TextView txtScanedRFIDTag;

        public ReceiveItemHolder(View itemview) : base(itemview)
        {
            try
            {
               
                txtAssetCode = itemview.FindViewById<TextView>(Resource.Id.txtAsset);
                txtRFIDTag = itemview.FindViewById<TextView>(Resource.Id.txtRFIDTag);
                txtScanedRFIDTag= itemview.FindViewById<TextView>(Resource.Id.txtScannedRFIDTag);
            }
            catch (Exception ex) { throw ex; }
        }
    }
}