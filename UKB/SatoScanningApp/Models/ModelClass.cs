using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace IOCLAndroidApp.Models
{

    #region FG Feeding
    public class ItemView
    {
        public string Asset { get; set; }
        public string RFIDTag { get; set; }
        public string ScannedRFIDTag { get; set; }
        public int Qty { get; set; }
        public int ScanQty { get; set; }
        public string Status { get; set; }
    }

    #endregion

}