using Android.App;
using Android.Widget;
using Android.OS;
using Android.Content;
using System;
using System.Net.Http;
using System.Text;
using IOCLAndroidApp.Models;
using System.Collections.Generic;
using System.IO;
using Android.Content.PM;
using Android.Views;
using Android.Net;
using System.Net.Sockets;

namespace IOCLAndroidApp
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
        public static string CaseFileName = "CaseBarcode.xls";
        public static string ServerIpFileName = "ServerIP.txt";
        public static string FilePath = global::Android.OS.Environment.ExternalStorageDirectory.AbsolutePath;
        public static TcpClient mTcpClient;
        internal static string mSockIp = "";
        internal static string mMachingPrinterIp = "";
        internal static Int32 mSockPort = 0;
        public static string LineId = "";
        public static string UserId { get; set; }
        public static string UserName { get; set; }
        public static string UserGroup { get; set; }
        public static Machining Machining { get; set; }
        public static ReOiling ReOiling { get; set; }
        public static FinalPacking FinalPacking { get; set; }

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
    }
}
