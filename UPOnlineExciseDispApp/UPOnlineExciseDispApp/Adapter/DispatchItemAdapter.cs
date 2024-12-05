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
using IOCLAndroidApp.Models;
using Java.Lang;
using Exception = System.Exception;

namespace UPOnlineExciseDispApp.Adapter
{
    public class DispatchItemAdapter : RecyclerView.Adapter
    {
        public List<DispatchItem> lstItem;
        Context context;
        public DispatchItemAdapter(List<DispatchItem> itemDetails, Context cont)
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
                DispatchItemHolder vh = holder as DispatchItemHolder;
                vh.txtGipNo.Text = lstItem[position].GipNo;
                vh.txtCaseQty.Text = lstItem[position].CaseQty.ToString();
                vh.txtDispatchQty.Text = lstItem[position].DispatchQty.ToString();
                vh.txtETIN.Text = lstItem[position].ETIN;
                vh.txtBrandShortName.Text = lstItem[position].BrandShotName;
            }
            catch (System.Exception ex) { Toast.MakeText(context, ex.Message, ToastLength.Long).Show(); }
        }
        public override RecyclerView.ViewHolder OnCreateViewHolder(ViewGroup parent, int viewType)
        {
            DispatchItemHolder vh = null;
            try
            {
                View itemView = LayoutInflater.From(parent.Context).Inflate(Resource.Layout.view_dispatch_item, parent, false);
                vh = new DispatchItemHolder(itemView);

            }
            catch (Exception ex) { Toast.MakeText(context, ex.Message, ToastLength.Long).Show(); }
            return vh;
        }
    }

    public class DispatchItemHolder : RecyclerView.ViewHolder
    {
        public TextView txtGipNo;
        public TextView txtCaseQty;
        public TextView txtDispatchQty;
        public TextView txtETIN;
        public TextView txtBrandShortName;
        public DispatchItemHolder(View itemview) : base(itemview)
        {
            try
            {
                txtGipNo = itemview.FindViewById<TextView>(Resource.Id.txtGipNo);
                txtCaseQty = itemview.FindViewById<TextView>(Resource.Id.txtCaseQty);
                txtDispatchQty = itemview.FindViewById<TextView>(Resource.Id.txtDispatchQty);
                txtETIN = itemview.FindViewById<TextView>(Resource.Id.txtETIN);
                txtBrandShortName = itemview.FindViewById<TextView>(Resource.Id.txtBrandShortName);
            }
            catch (Exception ex) { throw ex; }
        }
    }
}