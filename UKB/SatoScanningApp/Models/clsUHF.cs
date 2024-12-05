using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Util;
using Android.Views;
using Android.Widget;
using Com.Rscja.Deviceapi;

namespace SatoScanningApp.Models
{
  
    public class clsUHF
    {
        public RFIDWithUHF uhfAPI;
        private void StopInventory()
        {

            uhfAPI.StopInventory();


        }
        private class InitTask : AsyncTask<Java.Lang.Void, Java.Lang.Void, string[]>
        {

            ReceivingActivity mainActivity;
            ProgressDialog proDialg = null;

            public InitTask(ReceivingActivity _mainActivity)
            {
                mainActivity = _mainActivity;
            }
            protected override string[] RunInBackground(params Java.Lang.Void[] @params)
            {
                //throw new NotImplementedException ();
                return null;
            }

            //后台要执行的任务
            protected override Java.Lang.Object DoInBackground(params Java.Lang.Object[] @params)
            {
                string result = "No";
                if (mainActivity.uhfAPI != null)
                {
                    for (int i = 1; i <= 3; i++)
                    {
                        if (i != 3)
                        {
                            if (!mainActivity.uhfAPI.Init())
                                mainActivity.uhfAPI.Free();
                            else
                                return "OK";

                        }
                        else
                        {
                            if (mainActivity.uhfAPI.Init())
                            {
                                result = "OK";
                            }
                        }


                    }

                }
                return result;
            }
            protected override void OnPostExecute(Java.Lang.Object result)
            {
                proDialg.Cancel();
                Log.Debug("结果", result.ToString());
                if (result.ToString() != "OK")
                    Toast.MakeText(mainActivity, "Init failure!", ToastLength.Short);
            }

            //开始执行任务
            protected override void OnPreExecute()
            {
                proDialg = new ProgressDialog(mainActivity);
                proDialg.SetMessage("init.....");
                proDialg.Show();
            }
        }
    }
}