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

namespace RJExciseApp.Adapter
{
   public class CaseItemAdapter : RecyclerView.Adapter
    {
        public List<CaseItem> lstItem;
        Context context;
        public CaseItemAdapter(List<CaseItem> itemDetails, Context cont)
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
                CaseItemHolder vh = holder as CaseItemHolder;
                vh.txtBottelBarcode.Text = lstItem[position].BottelBarcode;
             
            }
            catch (System.Exception ex) { Toast.MakeText(context, ex.Message, ToastLength.Long).Show(); }
        }
        public override RecyclerView.ViewHolder OnCreateViewHolder(ViewGroup parent, int viewType)
        {
            CaseItemHolder vh = null;
            try
            {
                View itemView = LayoutInflater.From(parent.Context).Inflate(Resource.Layout.view_Rework_item, parent, false);
                vh = new CaseItemHolder(itemView);

            }
            catch (Exception ex) { Toast.MakeText(context, ex.Message, ToastLength.Long).Show(); }
            return vh;
        }
    }

    public class CaseItemHolder : RecyclerView.ViewHolder
    {
        public TextView txtBottelBarcode;
       
        public CaseItemHolder(View itemview) : base(itemview)
        {
            try
            {
                txtBottelBarcode = itemview.FindViewById<TextView>(Resource.Id.txtBottelBarcode);
                
            }
            catch (Exception ex) { throw ex; }
        }
    }
}