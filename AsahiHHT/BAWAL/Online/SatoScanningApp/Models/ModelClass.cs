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





    #region  Printing
    public class Part
    {
        public string PartNo { get; set; }
    }

    #endregion
    #region PLCFTPLinking
    public class PLCFTPLink
    {
        public string RefLine { get; set; }
        public string Line { get; set; }
        public string PLCIp { get; set; }
        public int PLCPort { get; set; }
        public string FTPPath { get; set; }
        public string FTPUser { get; set; }
        public int FTPPort { get; set; }
        public string FTPPassword { get; set; }
        public List<PLCFTPLink> lstPLCLink { get; set; } = new List<PLCFTPLink>();
    }
    #endregion
    #region  Picking
    public class BarcodeStatus
    {
        public string PartNo { get; set; }
        public string Barcode { get; set; }
        public string Status { get; set; }
        public bool IsCustomerKanbanEnable { get; set; }
    }

    #endregion

    #region Picking Location
    public class ItemLocation
    {
        public string LocationCode { get; set; }
        public string ItemBarcode { get; set; }
        public Decimal ScanQty { get; set; }
    }

    #endregion
}