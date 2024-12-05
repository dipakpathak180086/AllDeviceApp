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
    #region DispatchItem
    public class DispatchItem
    {
        public string GipNo { get; set; }
        public int CaseQty { get; set; }
        public int DispatchQty { get; set; }
        public string ETIN { get; set; }
        public string BrandShotName { get; set; }
    }

    #endregion

    #region DispatchItem
    public class CaseItem
    {
      
        public string BottelBarcode { get; set; }
    
    }

    #endregion

}