using Android.App;
using Android.Widget;
using Android.OS;
using Android.Content;
using System;
using System.Net.Http;
using System.Text;
using BatteryDispatchScannerOnline;
using System.Collections.Generic;
using System.IO;
using Android.Content.PM;
using Android.Views;
using Android.Net;
using System.Net.Sockets;

namespace BatteryDispatchScannerOnline
{
    public enum MessageTitle
    {
        ERROR = 1,
        CONFIRM = 2,
        INFORMATION = 3,
    }

    public class clsGlobal : Activity
    {
        public static string FileFolder = "SatoFiles";
        public static string CaseFileName = "CaseBarcode.txt";
        public static string ServerIpFileName = "ServerIP.txt";
        public static string FilePath = global::Android.OS.Environment.ExternalStorageDirectory.AbsolutePath;
        public static TcpClient mTcpClient;
        internal static string mSockIp = "";
        internal static Int32 mSockPort = 0;
        public static string LineId = "";
        public static string mEnterDelivery = "";

        //***************************************
        public void ShowMessage(string msg, Activity activity, MessageTitle MsgTitle)
        {
            AlertDialog.Builder builder = new AlertDialog.Builder(activity);
            builder.SetTitle(MsgTitle.ToString());
            builder.SetMessage(msg);
            builder.SetCancelable(false);
            builder.SetPositiveButton("OK", delegate { Finish(); });
            builder.Show();
        }
       
        public void showToastNGMessage(string Message, Context con)
        {
            Toast tost = Toast.MakeText(con, Message, ToastLength.Long);
            View v = tost.View;

            v.SetBackgroundColor(Android.Graphics.Color.Red);
            tost.Show();
        }
        public void showToastOKMessage(string Message, Context con)
        {
            Toast tost = Toast.MakeText(con, Message, ToastLength.Long);
            View v = tost.View;

            v.SetBackgroundColor(Android.Graphics.Color.Green);
            tost.Show();
        }
    }

    public class ViewBatteryData
    {
        public bool chkCheck { get; set; }
        public string Delivery { get; set; }
        public string SKU { get; set; }
        public string BatteryType { get; set; }
        public string ShowBatteryType { get; set; }
        public string Qty { get; set; }
        public string ScanQty { get; set; }

        public string Plant { get; set; }
        public string MSG { get; set; }
        public string SrNo { get; set; }
        public string TruckNo { get; set; }
        public string TransporterName { get; set; }
        public string Balance { get; set; }
    }
    public class ViewBatteryScanData
    {
        public bool chkCheck { get; set; }
        public string Delivery { get; set; }
        public string SKU { get; set; }
        public string ShowBatteryType { get; set; }
        public string BatteryType { get; set; }
        public string Qty { get; set; }
        public string ScanQty { get; set; }

        public string Plant { get; set; }
        public string MSG { get; set; }
        public string SrNo { get; set; }
        public string Balance { get; set; }
    }


}
