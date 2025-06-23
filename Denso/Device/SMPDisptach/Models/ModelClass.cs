using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace SMPDisptach
{
    [Activity(Label = "ListModel")]
    public class ScanCaseModel
    {
        public string _Material;
        public string _Line;
        public string _Qty;
        public string _ScanQty;

        public ScanCaseModel(string Material, string Line, string qty, string scanqty)
        {
            _Material = Material;
            _Line = Line;
            _Qty = qty;
            _ScanQty = scanqty;
        }
    }

    #region All Master
    public class PL_DNHA_MASTER
    {
        public string DNHAPartNo { get; set; }
        // Property for ExpDays
        public string ExpDays { get; set; }

        // Property for Ship Days
        public string MFGShipDays { get; set; }

        public string EXPShipDays { get; set; }

        // Property for IsMfgExp (manual set/get, no calculation)
        public bool IsMfgDate { get; set; }

        // Property for IsExpDate (manual set/get, no calculation)
        public bool IsExpDate { get; set; }
        public string LotSize { get; set; }
    }
    public class PL_CUSTOMER_MASTER
    {
        public string CustomerPartNo { get; set; }
        public string CustomerCode { get; set; }
        public string CustomerName { get; set; }
        public int ExpDays { get; set; }
        public string DNHAPartNo { get; set; }

        public int QTY { get; set; }
    }
    public class PL_SUPPLIER_MASTER
    {
        public string SupplierPartNo { get; set; }
        public string SupplierCode { get; set; }
        public string SupplierName { get; set; }
       
        public string DNHAPartNo { get; set; }
        public string ExpDays { get; set; }

        // Property for Ship Days
        public string MFGShipDays { get; set; }
        public string EXPShipDays { get; set; }

        // Property for IsMfgExp (manual set/get, no calculation)
        public bool IsMfgDate { get; set; }

        // Property for IsExpDate (manual set/get, no calculation)
        public bool IsExpDate { get; set; }

        public string LotQty { get; set; }
    }
    public class PL_SUSPECTED_LOT
    {
        public string DNHAPartNo { get; set; }
        public string LotNo { get; set; } 
    }
    public class PL_CUST_EXP_MASTER
    {
        public string CustomerCode { get; set; }
        public string DNHAPartNo { get; set; }
        public string ExpDays { get; set; }

        // Property for Ship Days
        public string MFGShipDays { get; set; }
        public string EXPShipDays { get; set; }

        // Property for IsMfgExp (manual set/get, no calculation)
        public bool IsMfgDate { get; set; }

        // Property for IsExpDate (manual set/get, no calculation)
        public bool IsExpDate { get; set; }
    }
    #endregion

    #region Validate User
    public class Login
    {
        public string UserId { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
    }

    #endregion

    #region HHTDowload

   

    #endregion

    #region SILScanning
    public class KanbanData
    {
        public int ColumnId { get; set; } // Identity column in SQL
        public string Kanban { get; set; }
        public string TruckNo { get; set; }
        public string CustomerCode { get; set; }
        public string ShipToLoc { get; set; }
        public string PointCheck { get; set; }
        public string Part { get; set; }
        public decimal Qty { get; set; }
        public string Result { get; set; }
        public int Minus { get; set; }
    }
    public class SILKanbanBarcodeScannedData
    {
        public string SILBarcode { get; set; }
        public string Barcode1 { get; set; }
        public string Barcode2 { get; set; }
        public string Barcode1SEQNo { get; set; }
        public bool isMatchBarcode1SeqNo { get; set; }=false;
        public string Barcode2SEQNo { get; set; }
        public bool isMatchBarcode2SeqNo { get; set; } = false;
    }
    public class ViewSILScanData
    {
        public bool chkCheck { get; set; }
        public string PartNo { get; set; }
        public string Qty { get; set; }
        public string ScanQty { get; set; }

        public string Bin { get; set; }
        public string Plant { get; set; }
        public string MSG { get; set; }
        public string SrNo { get; set; }
        public string TruckNoSILCode { get; set; }
        public string CheckPoint { get; set; }
        public string Balance { get; set; }
    }
    public class ViewFTPScanData
    {
      
        public string PartNo { get; set; }
        public string SILQty { get; set; }
        public string DensoQty { get; set; }
        public string Bin { get; set; }
        public string CustQty { get; set; }
    }
    public class ViewFraction
    {
        public string PartNo { get; set; }
        public int Qty { get; set; }
        public int ScanQty { get; set; }
        public int Balance { get; set; }
    }
    public class PL_PATTERN
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public string Patterns { get; set; }
        public string Seperater { get; set; }
        public string ThreePointCheckDigit { get; set; }
        public string Fields { get; set; }
       // public Hashtable hsKeyValueData {  get; set; }=new Hashtable();
       public List<Tuple<string, string>> keyValueData = new List<Tuple<string, string>>();
    }
    #endregion

  
}