using Android.Widget;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ThreePointCheck_App.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SIL_Scanning : ContentPage
    {
        public SIL_Scanning()
        {
            InitializeComponent();
        }
        CommonClass.SoundPlay obj = DependencyService.Get<CommonClass.SoundPlay>();
        string SILbarcode = "";
        string SILHeader = "";
        string TruckNo = "";
        private bool ControlValidation()
        {
            if (txtSILBarcode.Text == (null) && txtSILBarcode.Text != "")
            {
                Toast.MakeText(Android.App.Application.Context, "PLEASE SCAN SIL BARCODE", ToastLength.Long).Show();
                obj.PlaySound("Error");
                txtSILBarcode.Focus();
                return false;
            }
            return true;
        }
        private void TxtSILBarcode_Completed(object sender, EventArgs e)
        {
            try
            {
                if (ControlValidation())
                {

                     SILbarcode = txtSILBarcode.Text;
                     SILHeader = SILbarcode.Substring(0, 20);
                     TruckNo = SILHeader.Substring(0, 7);
                     lblTruck.Text = TruckNo;
                    if (DataCheck())
                    {
                        string str = TruckNo + "," + txtSILBarcode.Text+","+System.DateTime.Now+","+"";
                        CommonClass.CommonMethods.WriteFile(CommonClass.CommonVariable.Path + "/SIL_LIST.csv", str);
                        Toast.MakeText(Android.App.Application.Context, "DATA SAVED", ToastLength.Long).Show(); ;
                        obj.PlaySound("Success");
                        txtSILBarcode.Text = "";
                        txtSILBarcode.Focus();
                        DataCheck();
                    }
                }
            }
            catch (Exception ex)
            {
                obj.PlaySound("Error");
                DisplayAlert("Error", ex.Message, "OK");
            }
        }

        private void BtnExit_Clicked(object sender, EventArgs e)
        {
            try
            {
                App.Current.MainPage = new Pages.MainWIndow();
            }
            catch (Exception ex)
            {
                obj.PlaySound("Error");
                DisplayAlert("Error", ex.Message, "OK");
            }
        }

        private void ContentPage_Appearing(object sender, EventArgs e)
        {
            try
            {
                if (!File.Exists(CommonClass.CommonVariable.Path + "/SIL_LIST.csv"))
                {
                    string str = "TRUCKNO" + "," + "SIL_BARCODE" + "," + "SCANNEDON" + "," + "Status";
                    CommonClass.CommonMethods.WriteFile(CommonClass.CommonVariable.Path + "/SIL_LIST.csv", str);
                }
                txtSILBarcode.Focus();
                DataCheck();
            }
            catch (Exception ex)
            {
                obj.PlaySound("Error");
                DisplayAlert("Error", ex.Message, "OK");
            }
        }


        private bool DataCheck()
        {
            string Data = CommonClass.CommonMethods.ReadFile(CommonClass.CommonVariable.Path + "/SIL_LIST.csv");
           DataTable dt = CommonClass.CommonMethods.StringToDataTable(Data);

            //bool Flag = false;
            if (txtSILBarcode.Text != "" && txtSILBarcode.Text != (null))
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    if (dt.Rows[i]["TRUCKNO"].ToString() == lblTruck.Text)
                    {
                        //  Flag = true;
                        obj.PlaySound("Error");
                        //Toast.MakeText(Android.App.Application.Context, "THIS SIL BARCODE ALREADY SCANNED", ToastLength.Long).Show();

                        Device.BeginInvokeOnMainThread(async () =>
                        {
                            bool Result = false;
                            if (App.Current != null)
                            {

                                Result = await App.Current.MainPage.DisplayAlert("Alter!", "THIS SIL BARCODE ALREADY SCANNED, DO YOU WANT TO DELETE IT", "OK", "Cancel");
                                if (Result)
                                {
                                    if (File.Exists(CommonClass.CommonVariable.Path + "/SIL_LIST.csv"))
                                    {

                                        File.Delete(CommonClass.CommonVariable.Path + "/SIL_LIST.csv");
                                        string str = "TRUCKNO" + "," + "SIL_BARCODE" + "," + "SCANNEDON" + "," + "Status";
                                        CommonClass.CommonMethods.WriteFile(CommonClass.CommonVariable.Path + "/SIL_LIST.csv", str);

                                        for (int J = 0; J < dt.Rows.Count; J++)
                                        {
                                            if (lblTruck.Text != dt.Rows[J]["TRUCKNO"].ToString())
                                            {
                                                string str1 = dt.Rows[J]["TRUCKNO"].ToString() + "," + dt.Rows[J]["SIL_BARCODE"].ToString() + "," + dt.Rows[J]["SCANNEDON"].ToString() + "," + dt.Rows[J]["Status"].ToString();
                                                CommonClass.CommonMethods.WriteFile(CommonClass.CommonVariable.Path + "/SIL_LIST.csv", str1);
                                            }
                                        }

                                    }
                                    if (File.Exists(CommonClass.CommonVariable.Path_1 + "/Barcode.csv"))
                                    {
                                        string Data1 = CommonClass.CommonMethods.ReadFile(CommonClass.CommonVariable.Path_1 + "/Barcode.csv");
                                        DataTable dtBackup = CommonClass.CommonMethods.StringToDataTable(Data1);
                                        File.Delete(CommonClass.CommonVariable.Path_1 + "/Barcode.csv");
                                        File.Delete(CommonClass.CommonVariable.Path_1 + "/"+SILHeader+".csv");

                                        if (!File.Exists(CommonClass.CommonVariable.Path_1 + "/Barcode.csv"))
                                        {
                                            string str = "SIL_Barcode" + "," + "DNKI_Barcode" + "," + "CUSTOMER_Barcode" + "," + "DNKI_PartNo" + "," + "CUST_PartNo" + "," + "DNKI_PartQty" + "," + "CUST_PartQty" + "," + "DNKI_ProcessID" + "," + "SIL_TruckNo" + "," + "SIL_ShipTo" + "," + "SIL_CustNo" + "," + "DNKI_Sequence" + "," + "CUST_Sequence" + "," + "ScannedBy" + "," + "SILScannedOn" + "," + "DNKIScannedOn" + "," + "CustScannedOn";
                                            CommonClass.CommonMethods.WriteFile(CommonClass.CommonVariable.Path_1 + "/Barcode.csv", str);

                                            if (Directory.Exists(CommonClass.CommonVariable.Path_1))
                                            {
                                                for (int j = 0; j < dtBackup.Rows.Count; j++)
                                                {
                                                    if (lblTruck.Text != dtBackup.Rows[j]["SIL_TruckNo"].ToString())
                                                    {
                                                        str = dtBackup.Rows[j][0].ToString() + "," + dtBackup.Rows[j][1].ToString() + "," + dtBackup.Rows[j][2].ToString() + "," + dtBackup.Rows[j][3].ToString() + "," + dtBackup.Rows[j][4].ToString() + "," + dtBackup.Rows[j][5].ToString() + "," + dtBackup.Rows[j][6].ToString() + "," + dtBackup.Rows[j][7].ToString() + "," + dtBackup.Rows[j][8].ToString() + "," + dtBackup.Rows[j][9].ToString() + "," + dtBackup.Rows[j][10].ToString() + "," + dtBackup.Rows[j][11].ToString() + "," + dtBackup.Rows[j][12].ToString() + "," + dtBackup.Rows[j][13].ToString() + "," + dtBackup.Rows[j][14].ToString() + "," + dtBackup.Rows[j][15].ToString() + "," + dtBackup.Rows[j][16].ToString();
                                                        CommonClass.CommonMethods.WriteFile(CommonClass.CommonVariable.Path_1 + "/Barcode.csv", str);
                                                    }
                                                }

                                            }
                                        }
                                    }

                                    Data = CommonClass.CommonMethods.ReadFile(CommonClass.CommonVariable.Path + "/SIL_LIST.csv");
                                    dt = CommonClass.CommonMethods.StringToDataTable(Data);
                                  
                                    ListTag.ItemsSource = dt.Rows;
                                    lblqty.Text = dt.Rows.Count.ToString();
                                    obj.PlaySound("Success");
                                }
                            }
                        });

                        txtSILBarcode.Text = "";
                        txtSILBarcode.Focus();
                      
                        //DisplayAlert("Error", "BARCODE ALREADY SCANNED", "OK");
                        return false;
                    }
                }
            }
            lblqty.Text = dt.Rows.Count.ToString();
           
            ListTag.ItemsSource = dt.Rows;
         //   ListTag.
            return true;
        }

        //private void BtnDelete_Clicked(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        Device.BeginInvokeOnMainThread(async () =>
        //        {


        //            bool Result = false;
        //            if (App.Current != null)
        //            {

        //                Result = await App.Current.MainPage.DisplayAlert("Alter!", "DO YOU WANT DELETE ALL SIL DATA", "OK", "Cancel");
        //                if (Result)
        //                {
        //                    if (File.Exists(CommonClass.CommonVariable.Path + "/SIL_LIST.csv"))
        //                    {
        //                        File.Delete(CommonClass.CommonVariable.Path + "/SIL_LIST.csv");
        //                        string str = "TRUCKNO" + "," + "SIL_BARCODE" + "," + "SCANNEDON" + "," + "Status";
        //                        CommonClass.CommonMethods.WriteFile(CommonClass.CommonVariable.Path + "/SIL_LIST.csv", str);
        //                        obj.PlaySound("Success");
        //                        lblTruck.Text = "";
        //                        DataCheck();
        //                    }
        //                }

        //            }
        //        });

        //    }
        //    catch (Exception ex)
        //    {
        //        obj.PlaySound("Error");
        //        DisplayAlert("Error", ex.Message, "OK");
        //    }
        //}
    }
}