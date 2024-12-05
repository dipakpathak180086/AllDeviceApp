using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SMPDisptach
{

    static class ModInit
    {
        public static string GstrMsgApp = "HHML_FG";
        public static bool GboolLogin = false;
        public static string GstrPath = global::Android.OS.Environment.ExternalStorageDirectory.AbsolutePath;
        public static string GstrServerIP;
        public static int GintServerPort = 0;

        public static string GstrLoadingData;
        public static string strUser, strPwd;
        public static  string strlocation;
        public static  string strBikeID;
        public static  string strFrameID;
        public static  string strScanFlag;
        public static  string barcode;
        public static  string strPicklistNo;
        public static  string strDealerCode;
        public static  string strTruckNo;
        public static  int i;
        public static  string[] Gstrarr;
        public static  string GstrResult;
        public static  long LCount;
        public static  string GstrDeliveryNo;
        public static  string GstrDQuery;
        public static  string GstrMarkingLocation="";
        public static string PreviousActivity;

       
    }

}