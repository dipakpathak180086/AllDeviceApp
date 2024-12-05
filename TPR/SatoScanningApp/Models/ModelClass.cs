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
    [Activity(Label = "ListModel")]
    public class ScanCaseModel
    {
        public string _caseNo;

        public ScanCaseModel(string CaseNo)
        {
            _caseNo = CaseNo;
        }
    }


    #region Machining
    public class Machining
    {
        public string ModelNo { get; set; }
        public string LotNo { get; set; }
        public string LotNoDate { get; set; }
        public string LineNo { get; set; }
        public string CuttingTrolleyCard { get; set; }
        public int TotalQty { get; set; }
        public int OkQty { get; set; }
        public int NgQty { get; set; }
        public int DefectQty { get; set; }
        public string TrolleyNo { get; set; }
        public string TrolleyCard { get; set; }
        public int Status { get; set; }
        public string CreatedBy { get; set; }

        //Defect
        public int InnerCavity { get; set; }
        public int OuterCavity { get; set; }
        public int Slag { get; set; }
        public int Dent { get; set; }
        public int Spine { get; set; }
        public int ForgMat { get; set; }
        public int Rust { get; set; }
        public int PinHole { get; set; }
        public int MachineOutsideCavity { get; set; }
        public int Other { get; set; }
        public int IDPlus { get; set; }
        public int IDMinus { get; set; }
        public int PowerCut { get; set; }
        public int ExtraParam4 { get; set; }
        public int ExtraParam5 { get; set; }

        public int TotalLengthMinus { get; set; }
        public int TotalLengthPlus { get; set; }
        public int RCenterMinus { get; set; }
        public int RCenterPlus { get; set; }
        public int NoCleanUp { get; set; }
        public int Crack { get; set; }
    }

    #endregion

    #region ReOiling
    public class ReOiling
    {
        public string ModelNo { get; set; }
        public string LotNo { get; set; }
        public string LotNoDate { get; set; }
        public string MachiningTrolleyCard { get; set; }
        public int TotalQty { get; set; }
        public int OkQty { get; set; }
        public int NgQty { get; set; }
        public int DefectQty { get; set; }
        public int MachiningStatus { get; set; }
        public string CreatedBy { get; set; }

        //Defect
        public int InnerCavity { get; set; }
        public int OuterCavity { get; set; }
        public int Slag { get; set; }
        public int Dent { get; set; }
        public int Spine { get; set; }
        public int RONg { get; set; }
        public int Other { get; set; }
        public int ExtraParam1 { get; set; }
        public int ExtraParam2 { get; set; }
        public int ExtraParam3 { get; set; }
        public int ExtraParam4 { get; set; }
        public int ExtraParam5 { get; set; }
    }

    #endregion

    #region Final Packing
    public class FinalPacking
    {
        public string Shift { get; set; }
        public string ModelNo { get; set; }
        public string TrolleyNo { get; set; }
        public string LotNo { get; set; }
        public string LotNoDate { get; set; }
        public string MachiningTrolleyCard { get; set; }
        public int TotalQty { get; set; }
        public int OkQty { get; set; }
        public int NgQty { get; set; }
        public int DefectQty { get; set; }
        public int MachiningStatus { get; set; }
        public int Status { get; set; }
        public string CreatedBy { get; set; }

        //Defect
        public int InnerCavity { get; set; }
        public int OuterCavity { get; set; }
        public int Slag { get; set; }
        public int Dent { get; set; }
        public int Spine { get; set; }
        public int PackNg { get; set; }
        public int Other { get; set; }
        public int Rust { get; set; }
        public int ExtraParam2 { get; set; }
        public int ExtraParam3 { get; set; }
        public int ExtraParam4 { get; set; }
        public int ExtraParam5 { get; set; }
    }

    #endregion

    #region TrolleyReceiving
    public class TrolleyReceiving
    {
        public string TrolleyNo { get; set; }
        public int TrayQty { get; set; }
        public string ColorName { get; set; }
        public string CreatedBy { get; set; }
    }
    #endregion
    #region TrolleyDispatch
    public class DispatchTrolley
    {
        public string Date { get; set; }
        public string Customer { get; set; }
        public string Location { get; set; }
        public string Id { get; set; }
        public string Model { get; set; }
        public int DisQty { get; set; }
        public int Sqty { get; set; }
        
    }
    #endregion
}