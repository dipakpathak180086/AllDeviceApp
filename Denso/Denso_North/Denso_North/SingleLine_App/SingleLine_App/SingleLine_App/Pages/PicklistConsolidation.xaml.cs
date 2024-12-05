using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System;
using System.ComponentModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Android.Views.InputMethods;
using Android.Widget;
using System.IO;
using System.Data;
using System.Net;
using System.Collections;
using ThreePointCheck_App.CommonClass;
using System.Threading;

namespace ThreePointCheck_App.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PicklistConsolidation : ContentPage
    {
        public PicklistConsolidation()
        {
            InitializeComponent();
        }

        CommonClass.SoundPlay obj = DependencyService.Get<CommonClass.SoundPlay>();
        DataTable dt = new DataTable();
        int ScannedQty = 0;
        string PartNo = "";
        string CustPart = "";
        string ProcessCode = "";
        string SequenceNo = "";
        string TruckNo = "";
        string CustCode = "";
        string ShipTo = "";
        string SILbarcode = "";
        string DensoBarcode = "";
        string Possition = "";
        int Qty = 0;
        string CustPossion = "";
        string QtyPossion = "";
        string SequePossion = "";
        string Separator = "";
        string DensoPossion = "";
        string CustPart1 = "";
        string CustQty1 = "";
        string CustSequ1 = "";
        string DensoPart = "";
        string CustQty2 = "";
        string SILScannedon = "";
        string DNKIScannedOn = "";
        DataTable DtSIL = new DataTable();
        DataTable DtSIL_List = new DataTable();

        string SILHeader = "";

        private void Clear()
        {
            lblqty.Text = "COUNT : 0";
            pkSIL.SelectedIndex = -1;
            txtDenso.Text = "";
            txtCustomer.Text = "";
            ListTag.ItemsSource = null;
            lblCust.Text = "";
            lblTotqty.Text = "";
            lblqty.Text = "";
            //   txtSIL.Focus();

        }



        private bool PackingList()
        {
            string Data = CommonClass.CommonMethods.ReadFile(CommonClass.CommonVariable.Path_1 + "/Barcode.csv");
            dt = CommonClass.CommonMethods.StringToDataTable(Data);


            //bool Flag = false;
            if (txtCustomer.Text != "" && txtCustomer.Text != (null))
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    if (dt.Rows[i]["CUSTOMER_Barcode"].ToString() == txtCustomer.Text.Replace(",", "+"))
                    {
                        //  Flag = true;
                        obj.PlaySound("Error");
                        Toast.MakeText(Android.App.Application.Context, "THIS KANBAN ALREADY SCANNED", ToastLength.Long).Show();
                        Lock_ScreenPopUp("SCANNED SAME CUSTOMER KANBAN AGAIN");
                        txtCustomer.Text = "";
                        txtCustomer.Focus();
                        //DisplayAlert("Error", "BARCODE ALREADY SCANNED", "OK");
                        return false;
                    }
                }
            }


            return true;
        }
        private void Pick_Appearing(object sender, EventArgs e)
        {
            try
            {
                btnClear.IsEnabled = false;
                if (CommonClass.CommonVariable.UserType == "ADMIN" || CommonClass.CommonVariable.UserType == "SUPER ADMIN")
                {
                    btnClear.IsEnabled = true;
                }

                if (!File.Exists(CommonClass.CommonVariable.Path_1 + "//Barcode.csv"))
                {
                    string str = "SIL_Barcode" + "," + "DNKI_Barcode" + "," + "CUSTOMER_Barcode" + "," + "DNKI_PartNo" + "," + "CUST_PartNo" + "," + "DNKI_PartQty" + "," + "CUST_PartQty" + "," + "DNKI_ProcessID" + "," + "SIL_TruckNo" + "," + "SIL_ShipTo" + "," + "SIL_CustNo" + "," + "DNKI_Sequence" + "," + "CUST_Sequence" + "," + "ScannedBy" + "," + "SILScannedOn" + "," + "DNKIScannedOn" + "," + "CustScannedOn";
                    CommonClass.CommonMethods.WriteFile(CommonClass.CommonVariable.Path_1 + "//Barcode.csv", str);
                }
                PackingList();

                if (File.Exists(CommonClass.CommonVariable.Path + "//Settings.txt"))
                {
                    string Data = CommonClass.CommonMethods.ReadFile(CommonClass.CommonVariable.Path + "/Settings.txt");
                    DataTable dtSettings = CommonClass.CommonMethods.StringToDataTable(Data);
                    if (dtSettings.Rows.Count > 0)
                    {
                        CommonClass.CommonVariable.WareHouseNo = dtSettings.Rows[0]["WH_ID"].ToString();
                        CommonClass.CommonVariable.DeviceID = dtSettings.Rows[0]["Device_ID"].ToString();
                        CommonClass.CommonVariable.FTPIP = dtSettings.Rows[0]["FTP_Ip"].ToString();
                        CommonClass.CommonVariable.FTOUserID = dtSettings.Rows[0]["FTP_UserID"].ToString();
                        CommonClass.CommonVariable.FTPPassword = dtSettings.Rows[0]["FTP_Password"].ToString();
                        CommonClass.CommonVariable.ApplicationType = dtSettings.Rows[0]["Application_Type"].ToString();

                    }
                }

                GetSil_List();




                lblUser.Text = "DEVICE ID : " + CommonClass.CommonVariable.DeviceID;
                lblWH.Text = "WAREHOUSE NO : " + CommonClass.CommonVariable.WareHouseNo;
                lblHeader.Text = CommonClass.CommonVariable.ApplicationType + " CHECK SYSTEM";


            }

            catch (Exception ex)
            {
                obj.PlaySound("Error");
                Toast.MakeText(Android.App.Application.Context, ex.Message.ToString(), ToastLength.Long).Show();
            }
        }

        private void GetSil_List()
        {
            if (File.Exists(CommonClass.CommonVariable.Path + "//SIL_LIST.csv"))
            {
                string Data = CommonClass.CommonMethods.ReadFile(CommonClass.CommonVariable.Path + "/SIL_LIST.csv");
                DtSIL_List = CommonClass.CommonMethods.StringToDataTable(Data);
                pkSIL.ItemsSource = null;
                if (DtSIL_List.Rows.Count > 0)
                {
                    pkSIL.ItemsSource = (IList)null;
                    List<string> list = DtSIL_List.Rows.OfType<DataRow>().Select<DataRow, string>((Func<DataRow, string>)(dr => (string)dr["TRUCKNO"])).ToList<string>();
                    pkSIL.ItemsSource = (IList)list;
                }
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
                Toast.MakeText(Android.App.Application.Context, ex.Message.ToString(), ToastLength.Long).Show();
            }
        }
        private void GetCustPossion()
        {
            string[] CustBarcode = null;
            CustPart1 = "";
            CustQty1 = "0";
            CustSequ1 = "";
            DensoPart = "";
            CustQty2 = "0";
            if (Separator != "")
            {
                CustBarcode = txtCustomer.Text.Split(Convert.ToChar(Separator));
                if (CustPossion != "")
                {
                    if (CustPossion.Contains("-"))
                    {
                        string[] partPos = CustPossion.Split(',');
                        int Len = 0;
                        if (partPos.Length > 0)
                        {
                            for (int i = 0; i < partPos.Length; i++)
                            {
                                Len = Convert.ToInt32(partPos[i].Split('-')[1]) - Convert.ToInt32(partPos[i].Split('-')[0]);
                                CustPart1 = CustPart1 + txtCustomer.Text.Substring(Convert.ToInt32(partPos[i].Split('-')[0]) - 1, Len + 1);
                            }
                        }
                        else
                        {
                            Len = Convert.ToInt32(partPos[0].Split('-')[1]) - Convert.ToInt32(partPos[0].Split('-')[0]);
                            CustPart1 = txtCustomer.Text.Substring(Convert.ToInt32(partPos[0].Split('-')[0]) - 1, Len + 1);
                        }
                    }
                    else
                    {
                        CustPart1 = CustBarcode[Convert.ToInt32(CustPossion) - 1];
                    }

                }
                else
                {
                    CustPart1 = "";
                }
                if (DensoPossion != "")
                {
                    DensoPart = PartNo;
                }
                else
                {
                    DensoPart = "";
                }

                if (CustQty1 == "")
                    CustQty1 = "0";
                if (CustQty2 == "")
                    CustQty2 = "0";

                if (QtyPossion != "")
                {
                    if (QtyPossion.Contains("-"))
                    {
                        string[] partPos = QtyPossion.Split(',');
                        int Len = 0;
                        if (partPos.Length > 0)
                        {
                            for (int i = 0; i < partPos.Length; i++)
                            {
                                Len = Convert.ToInt32(partPos[i].Split('-')[1]) - Convert.ToInt32(partPos[i].Split('-')[0]);

                                CustQty1 = (Convert.ToInt32(CustQty1) + Convert.ToInt32(txtCustomer.Text.Substring(Convert.ToInt32(partPos[i].Split('-')[0]) - 1, Len + 1))).ToString();
                                CustQty2 = CustQty1;// + txtCustomer.Text.Substring(Convert.ToInt32(partPos[i].Split('-')[0]) - 1, Len + 1);
                            }
                        }
                        else
                        {
                            Len = Convert.ToInt32(partPos[0].Split('-')[1]) - Convert.ToInt32(partPos[0].Split('-')[0]);
                            CustQty1 = txtCustomer.Text.Substring(Convert.ToInt32(partPos[0].Split('-')[0]) - 1, Len + 1);
                            CustQty2 = txtCustomer.Text.Substring(Convert.ToInt32(partPos[0].Split('-')[0]) - 1, Len + 1);
                        }
                    }
                    else
                    {
                        CustQty1 = CustBarcode[Convert.ToInt32(QtyPossion) - 1];
                        CustQty2 = CustBarcode[Convert.ToInt32(QtyPossion) - 1];
                    }

                }
                else
                {
                    CustQty2 = Qty.ToString();
                    CustQty1 = "0";

                }

                if (SequePossion != "")
                {
                    if (SequePossion.Contains("-"))
                    {
                        string[] partPos = SequePossion.Split(',');
                        int Len = 0;
                        if (partPos.Length > 0)
                        {
                            for (int i = 0; i < partPos.Length; i++)
                            {
                                Len = Convert.ToInt32(partPos[i].Split('-')[1]) - Convert.ToInt32(partPos[i].Split('-')[0]);
                                CustSequ1 = CustSequ1 + txtCustomer.Text.Substring(Convert.ToInt32(partPos[i].Split('-')[0]) - 1, Len + 1);
                            }
                        }
                        else
                        {
                            Len = Convert.ToInt32(partPos[0].Split('-')[1]) - Convert.ToInt32(partPos[0].Split('-')[0]);
                            CustSequ1 = txtCustomer.Text.Substring(Convert.ToInt32(partPos[0].Split('-')[0]) - 1, Len + 1);
                        }
                    }
                    else
                    {
                        CustSequ1 = CustBarcode[Convert.ToInt32(QtyPossion) - 1];
                    }

                }
                else
                {
                    CustSequ1 = "";
                }

            }
            else
            {
                if (CustPossion != "")
                {
                    if (CustPossion.Contains("-"))
                    {
                        string[] partPos = CustPossion.Split(',');
                        int Len = 0;
                        if (partPos.Length > 0)
                        {
                            for (int i = 0; i < partPos.Length; i++)
                            {
                                Len = Convert.ToInt32(partPos[i].Split('-')[1]) - Convert.ToInt32(partPos[i].Split('-')[0]);
                                CustPart1 = CustPart1 + txtCustomer.Text.Substring(Convert.ToInt32(partPos[i].Split('-')[0]) - 1, Len + 1);
                            }
                        }
                        else
                        {
                            Len = Convert.ToInt32(partPos[0].Split('-')[1]) - Convert.ToInt32(partPos[0].Split('-')[0]);
                            CustPart1 = txtCustomer.Text.Substring(Convert.ToInt32(partPos[0].Split('-')[0]) - 1, Len + 1);
                        }
                    }
                }
                else
                {
                    CustPart1 = "";
                }
                if (DensoPossion != "")
                {
                    DensoPart = PartNo;
                }
                else
                {
                    DensoPart = "";
                }
                if (CustQty1 == "")
                    CustQty1 = "0";
                if (CustQty2 == "")
                    CustQty2 = "0";
                if (QtyPossion != "")
                {
                    if (QtyPossion.Contains("-"))
                    {
                        string[] partPos = QtyPossion.Split(',');
                        int Len = 0;
                        if (partPos.Length > 0)
                        {
                            for (int i = 0; i < partPos.Length; i++)
                            {
                                Len = Convert.ToInt32(partPos[i].Split('-')[1]) - Convert.ToInt32(partPos[i].Split('-')[0]);
                                string data4 = ((txtCustomer.Text.Substring(Convert.ToInt32(partPos[i].Split('-')[0]) - 1, Len + 1))).ToString();

                                CustQty1 = (Convert.ToInt32( CustQty1) + Convert.ToInt32( txtCustomer.Text.Substring(Convert.ToInt32(partPos[i].Split('-')[0]) - 1, Len + 1))).ToString();
                                CustQty2 = CustQty1; //+ txtCustomer.Text.Substring(Convert.ToInt32(partPos[i].Split('-')[0]) - 1, Len + 1);

                            }
                        }
                        else
                        {
                            Len = Convert.ToInt32(partPos[0].Split('-')[1]) - Convert.ToInt32(partPos[0].Split('-')[0]);
                            CustQty1 = txtCustomer.Text.Substring(Convert.ToInt32(partPos[0].Split('-')[0]) - 1, Len + 1);
                            CustQty2 = txtCustomer.Text.Substring(Convert.ToInt32(partPos[0].Split('-')[0]) - 1, Len + 1);

                        }
                    }

                }
                else
                {
                    CustQty2 = Qty.ToString();
                    CustQty1 = "0";

                }

                if (SequePossion != "")
                {
                    if (SequePossion.Contains("-"))
                    {
                        string[] partPos = SequePossion.Split(',');
                        int Len = 0;
                        if (partPos.Length > 0)
                        {
                            for (int i = 0; i < partPos.Length; i++)
                            {
                                Len = Convert.ToInt32(partPos[i].Split('-')[1]) - Convert.ToInt32(partPos[i].Split('-')[0]);
                                CustSequ1 = CustSequ1 + txtCustomer.Text.Substring(Convert.ToInt32(partPos[i].Split('-')[0]) - 1, Len + 1);
                            }
                        }
                        else
                        {
                            Len = Convert.ToInt32(partPos[0].Split('-')[1]) - Convert.ToInt32(partPos[0].Split('-')[0]);
                            CustSequ1 = txtCustomer.Text.Substring(Convert.ToInt32(partPos[0].Split('-')[0]) - 1, Len + 1);
                        }
                    }

                }
                else
                {
                    CustSequ1 = "";
                }
            }

        }
        private void BtnClear_Clicked(object sender, EventArgs e)
        {
            try
            {
                Device.BeginInvokeOnMainThread(async () =>
                {


                    bool Result = false;
                    if (App.Current != null)
                    {
                        DataTable dtBackup = new DataTable();
                        Result = await App.Current.MainPage.DisplayAlert("Alter!", "DO YOU WANT CLEAR THE ALL THE DATA BY TAKING BACK UP", "OK", "Cancel");
                        if (Result)
                        {

                            if (Directory.Exists(CommonClass.CommonVariable.Path_1))
                            {
                                if (!File.Exists(CommonClass.CommonVariable.Path + "//BackUp_Barcode.csv"))
                                {
                                    string str = "SIL_Barcode" + "," + "DNKI_Barcode" + "," + "CUSTOMER_Barcode" + "," + "DNKI_PartNo" + "," + "CUST_PartNo" + "," + "DNKI_PartQty" + "," + "CUST_PartQty" + "," + "DNKI_ProcessID" + "," + "SIL_TruckNo" + "," + "SIL_ShipTo" + "," + "SIL_CustNo" + "," + "DNKI_Sequence" + "," + "CUST_Sequence" + "," + "ScannedBy" + "," + "SILScannedOn" + "," + "DNKIScannedOn" + "," + "CustScannedOn";
                                    CommonClass.CommonMethods.WriteFile(CommonClass.CommonVariable.Path + "//BackUp_Barcode.csv", str);
                                }
                                if (File.Exists(CommonClass.CommonVariable.Path_1 + "//Barcode.csv"))
                                {
                                    string Data = CommonClass.CommonMethods.ReadFile(CommonClass.CommonVariable.Path_1 + "//Barcode.csv");
                                    dtBackup = CommonClass.CommonMethods.StringToDataTable(Data);
                                }
                            }

                            if (File.Exists(CommonClass.CommonVariable.Path + "/SIL_LIST.csv"))
                            {
                                File.Delete(CommonClass.CommonVariable.Path + "/SIL_LIST.csv");
                                string str = "TRUCKNO" + "," + "SIL_BARCODE" + "," + "SCANNEDON"+","+"Status"; ;
                                CommonClass.CommonMethods.WriteFile(CommonClass.CommonVariable.Path + "/SIL_LIST.csv", str);
                            }
                            if (Directory.Exists(CommonClass.CommonVariable.Path_1))
                            {
                                Directory.Delete(CommonClass.CommonVariable.Path_1, true);
                                Directory.CreateDirectory(CommonClass.CommonVariable.Path_1);
                                for (int j = 0; j < dtBackup.Rows.Count; j++)
                                {
                                    string str = dtBackup.Rows[j][0].ToString() + "," + dtBackup.Rows[j][1].ToString() + "," + dtBackup.Rows[j][2].ToString() + "," + dtBackup.Rows[j][3].ToString() + "," + dtBackup.Rows[j][4].ToString() + "," + dtBackup.Rows[j][5].ToString() + "," + dtBackup.Rows[j][6].ToString() + "," + dtBackup.Rows[j][7].ToString() + "," + dtBackup.Rows[j][8].ToString() + "," + dtBackup.Rows[j][9].ToString() + "," + dtBackup.Rows[j][10].ToString() + "," + dtBackup.Rows[j][11].ToString() + "," + dtBackup.Rows[j][12].ToString() + "," + dtBackup.Rows[j][13].ToString() + "," + dtBackup.Rows[j][14].ToString() + "," + dtBackup.Rows[j][15].ToString() + "," + dtBackup.Rows[j][16].ToString();
                                    CommonClass.CommonMethods.WriteFile(CommonClass.CommonVariable.Path + "/BackUp_Barcode.csv", str);
                                }
                                Toast.MakeText(Android.App.Application.Context, "DATA BACK-UP IS DONE SUCCESSFULLY BY CLEARING ALL THE RECORDS", ToastLength.Long).Show();
                                Clear();
                                obj.PlaySound("Success");
                            }

                            GetSil_List();
                        }
                    }
                });
                //Clear();
            }
            catch (Exception ex)
            {
                obj.PlaySound("Error");
                Toast.MakeText(Android.App.Application.Context, ex.Message.ToString(), ToastLength.Long).Show();
            }
        }


        private void TxtDenso_Completed(object sender, EventArgs e)
        {
            try
            {
                if (pkSIL.SelectedIndex == -1)
                {
                    Toast.MakeText(Android.App.Application.Context, "PLEASE SELECT SIL TRUCK NO", ToastLength.Long).Show();
                    obj.PlaySound("Error");
                    return;
                }
                if (txtDenso.Text == "" || txtDenso.Text == (null))
                {
                    Toast.MakeText(Android.App.Application.Context, "PLEASE SCAN DENSO BARCODE", ToastLength.Long).Show();
                    obj.PlaySound("Error");
                    return;
                }

                CustPart = txtDenso.Text.Substring(66, 25);
                PartNo = txtDenso.Text.Substring(91, 15);
                Qty = Convert.ToInt32(txtDenso.Text.Substring(106, 7));
                ProcessCode = txtDenso.Text.Substring(113, 5);
                SequenceNo = txtDenso.Text.Substring(118, 7);
                DensoBarcode = txtDenso.Text.Substring(0, 150);
                txtDenso.Text = PartNo;
                if (!SILbarcode.Contains(PartNo))
                {
                    Toast.MakeText(Android.App.Application.Context, "INVALID PART NO", ToastLength.Long).Show();
                    obj.PlaySound("Error");
                    CommonClass.CommonVariable.Error = "DENSO INVALID PART NO SCANNED";
                    Lock_ScreenPopUp(CommonClass.CommonVariable.Error);
                    txtDenso.Text = "";
                    txtDenso.Focus();
                    return;
                }

                //for (int j = 0; j < DtSIL.Rows.Count; j++)
                //{
                //    if (DtSIL.Rows[j]["PartNo"].ToString() == PartNo.ToString())
                //    {


                lblqty.Text = Convert.ToString(Qty) + "/0";
                if (dt.Rows.Count > 0)
                {

                    DataView DV = new DataView(dt);
                    DV.RowFilter = "SIL_Barcode='" + SILbarcode + "' and DNKI_Barcode='" + DensoBarcode + "'";
                    DataTable dt5 = DV.ToTable();
                    int KanbanQty = 0;
                    for (int N = 0; N < dt5.Rows.Count; N++)
                    {
                        if (dt5.Rows[N]["CUST_PartQty"].ToString() != "")
                            KanbanQty = KanbanQty + Convert.ToInt32(dt5.Rows[N]["CUST_PartQty"].ToString());
                    }
                    lblqty.Text = Convert.ToString(Qty) + "/" + KanbanQty.ToString();

                }

                if (lblqty.Text.Split('/')[0] == lblqty.Text.Split('/')[1])
                {
                    Toast.MakeText(Android.App.Application.Context, "KANBAN FULLY SCANNED SUCCESSFULLY", ToastLength.Long).Show();
                    obj.PlaySound("Error");
                    lblqty.Text = "0/0";
                    txtDenso.Text = "";
                    txtCustomer.Text = "";
                    txtDenso.Focus();
                    return;
                }

                //    }
                //}

                DNKIScannedOn = System.DateTime.Now.ToString();
                txtCustomer.Focus();

            }
            catch (Exception ex)
            {
                obj.PlaySound("Error");
                Toast.MakeText(Android.App.Application.Context, ex.Message.ToString(), ToastLength.Long).Show();
                txtDenso.Text = "";
                txtDenso.Focus();

            }
        }

        private void FileGaneration()
        {
            if (lblTotqty.Text.Split('/')[0] == lblTotqty.Text.Split('/')[1])
            {

                DataView dv = new DataView(dt);
                dv.RowFilter = "SIL_Barcode='" + SILbarcode + "'";
                DataTable dt1 = dv.ToTable();

                //for (int M = 0; M < dt1.Rows.Count; M++)
                //{

                if (!File.Exists(CommonClass.CommonVariable.Path_1 + "//Sequnce.txt"))
                {
                    CommonClass.CommonMethods.WriteFile(CommonClass.CommonVariable.Path_1 + "//Sequnce.txt", "0");
                }

                string Sequence = CommonClass.CommonMethods.ReadFile(CommonClass.CommonVariable.Path_1 + "//Sequnce.txt").Replace("\n", "");

                if (Sequence == "1000")
                {
                    File.Delete(CommonClass.CommonVariable.Path_1 + "//Sequnce.txt");
                    CommonClass.CommonMethods.WriteFile(CommonClass.CommonVariable.Path_1 + "//Sequnce.txt", "0");
                }

                if (File.Exists(CommonClass.CommonVariable.Path_1 + "//" + SILHeader + ".DAT"))
                {
                    File.Delete(CommonClass.CommonVariable.Path_1 + "//" + SILHeader + ".DAT");
                }
                //date = Convert.ToDateTime(date).ToString("yyyyMMddHHmmss");
                //177, Change by mayank
                CommonClass.CommonMethods.WriteFileNew(CommonClass.CommonVariable.Path_1 + "//" + SILHeader + ".DAT", dt1.Rows.Count.ToString().Trim().PadRight(177, ' ') + "\r\n");

                for (int L = 0; L < DtSIL.Rows.Count; L++)
                {
                    DataView Dv1 = new DataView(dt1);
                    Dv1.RowFilter = "DNKI_PartNo='" + DtSIL.Rows[L]["PartNo"].ToString() + "'";
                    //Dv1.Sort = "CustScannedOn desc";
                    DataTable dt3 = Dv1.ToTable(true, "DNKI_Barcode", "DNKI_PartNo", "DNKI_ProcessID", "DNKI_Sequence", "DNKI_PartQty", "CUST_PartQty", "CUST_PartNo");
                    for (int A = 0; A < dt3.Rows.Count; A++)
                    {                                                                                                                                                                                                                                                                                                                                                                       //["CUST_PartQty"] it was writtem before, Change by Mayank                                    
                        string str = " 0521" + dt3.Rows[A]["DNKI_PartNo"].ToString().PadRight(15, ' ') + "        " + dt3.Rows[A]["DNKI_ProcessID"].ToString().PadRight(5, ' ') + dt3.Rows[A]["DNKI_Sequence"].ToString().PadRight(7, ' ') + "         " + dt3.Rows[A]["DNKI_PartQty"].ToString().PadLeft(7, '0') + TruckNo + Convert.ToDateTime(Dv1.ToTable().Rows[Dv1.ToTable().Rows.Count - 1]["CustScannedOn"]).ToString("yyyyMMdd") + "1" + dt3.Rows[A]["DNKI_PartQty"].ToString().PadLeft(7, '0') + CustCode + CommonClass.CommonVariable.WareHouseNo + Convert.ToDateTime(Dv1.ToTable().Rows[Dv1.ToTable().Rows.Count - 1]["CustScannedOn"]).ToString("yyyyMMddHHmmss") + CommonClass.CommonVariable.DeviceID + ShipTo + dt3.Rows[A]["CUST_PartNo"].ToString().PadRight(30, ' ') + "00000000                         " + CommonClass.CommonVariable.UserID.PadRight(7, ' ');
                        CommonClass.CommonMethods.WriteFileNew(CommonClass.CommonVariable.Path_1 + "//" + SILHeader + ".DAT", str + "\r\n");
                    }
                }
                for (int L = 0; L < DtSIL.Rows.Count; L++)
                {
                    DataView Dv1 = new DataView(dt1);
                    Dv1.RowFilter = "DNKI_PartNo='" + DtSIL.Rows[L]["PartNo"].ToString() + "'";
                    DataTable dt3 = Dv1.ToTable(true, "DNKI_Barcode", "DNKI_PartNo", "DNKI_ProcessID", "DNKI_Sequence", "DNKI_PartQty", "CUST_PartQty", "CUST_PartNo");
                    string PartNo1 = "";
                    int Qty = 0;

                    DataView dv2 = new DataView(dt3);

                    for (int B = 0; B < dv2.ToTable(true, "DNKI_PartNo").Rows.Count; B++)
                    {
                        Sequence = (Convert.ToInt32(Sequence) + 1).ToString();
                        PartNo1 = dv2.ToTable(true, "DNKI_PartNo").Rows[B]["DNKI_PartNo"].ToString();

                        for (int A = 0; A < dt3.Rows.Count; A++)
                        {
                            if (dt3.Rows[B]["DNKI_PartNo"].ToString() == PartNo1)
                                Qty = Qty + Convert.ToInt32(dt3.Rows[B]["DNKI_PartQty"]);
                            else
                                Qty = Convert.ToInt32(dt3.Rows[B]["DNKI_PartQty"]);
                        }
                        string str = "L" + Sequence.PadLeft(4, '0') + CommonClass.CommonVariable.WareHouseNo.PadLeft(2, '0') +
                        CommonClass.CommonVariable.DeviceID.PadLeft(2, '0') + "    " + CommonClass.CommonVariable.UserID.PadRight(7, ' ') + Convert.ToDateTime(SILScannedon).ToString("yyyyMMdd") + "1000101000" +
                        TruckNo + CustCode + ShipTo + Possition + dt3.Rows[B]["DNKI_PartNo"].ToString().PadRight(15, ' ') +
                        Qty.ToString().PadLeft(7, '0') + "                                                        " +
                        Convert.ToDateTime(SILScannedon).ToString("yyyyMMddHHmmss") + "                             ";
                        CommonClass.CommonMethods.WriteFileNew(CommonClass.CommonVariable.Path_1 + "//" + SILHeader + ".DAT", str + "\r\n");
                    }
                }
                int coUNT = 1;
                for (int B = 0; B < dt1.Rows.Count; B++)
                {
                    coUNT = coUNT + 1;
                    Sequence = (Convert.ToInt32(Sequence) + 1).ToString();
                    if (lblHeader.Text.Contains("4 POINT"))
                    {
                        string str = "L" + Sequence.PadLeft(4, '0') + CommonClass.CommonVariable.WareHouseNo.PadLeft(2, '0') +
                        CommonClass.CommonVariable.DeviceID.PadLeft(2, '0') + "    " + CommonClass.CommonVariable.UserID.PadRight(7, ' ') + Convert.ToDateTime(dt1.Rows[B]["DNKIScannedOn"]).ToString("yyyyMMdd") + "1000" + coUNT.ToString().PadRight(2, '0') + "2000" +
                        TruckNo + CustCode + ShipTo + Possition + "                      21" + dt1.Rows[B]["DNKI_PartNo"].ToString().PadRight(15, ' ') + dt1.Rows[B]["CUST_PartNo"].ToString().PadRight(25, ' ') +
                        dt1.Rows[B]["DNKI_PartQty"].ToString().PadLeft(7, ' ') + dt1.Rows[B]["DNKI_Sequence"].ToString().PadLeft(7, '0') +
                        Convert.ToDateTime(dt1.Rows[B]["DNKIScannedOn"]).ToString("yyyyMMddHHmmss") + "        " + dt1.Rows[B]["DNKI_Sequence"].ToString().PadLeft(7, '0') + "              ";
                        CommonClass.CommonMethods.WriteFileNew(CommonClass.CommonVariable.Path_1 + "//" + SILHeader + ".DAT", str + "\r\n");
                        coUNT = coUNT + 1;

                        if (DensoPart != "")
                        {
                            Sequence = (Convert.ToInt32(Sequence) + 1).ToString();
                            string str1 = "L" + Sequence.PadLeft(4, '0') + CommonClass.CommonVariable.WareHouseNo.PadLeft(2, '0') +
                            CommonClass.CommonVariable.DeviceID.PadLeft(2, '0') + "    " + CommonClass.CommonVariable.UserID.PadRight(7, ' ') + Convert.ToDateTime(dt1.Rows[B]["CustScannedOn"]).ToString("yyyyMMdd") + "1000" + coUNT.ToString().PadRight(2, '0') + "3000" +
                            TruckNo + CustCode + ShipTo + Possition + "                      CS" + dt1.Rows[B]["DNKI_PartNo"].ToString().PadRight(15, ' ') + dt1.Rows[B]["CUST_PartNo"].ToString().PadRight(25, ' ') + dt1.Rows[B]["CUST_PartQty"].ToString().PadRight(7, ' ') + dt1.Rows[B]["CUST_Sequence"].ToString().PadLeft(7, ' ') +
                            //dt1.Rows[B]["DNKI_PartQty"].ToString() + dt1.Rows[B]["DNKI_PartQty"].ToString() + dt1.Rows[B]["DNKI_Sequence"].ToString().PadLeft(7, '0') +
                            Convert.ToDateTime(dt1.Rows[B]["CustScannedOn"]).ToString("yyyyMMddHHmmss")  + "        " + dt1.Rows[B]["CUST_Sequence"].ToString().PadLeft(7, ' ') + "              ";
                            CommonClass.CommonMethods.WriteFileNew(CommonClass.CommonVariable.Path_1 + "//" + SILHeader + ".DAT", str1 + "\r\n");
                        }
                        else
                        {
                            Sequence = (Convert.ToInt32(Sequence) + 1).ToString();
                            string str1 = "L" + Sequence.PadLeft(4, '0') + CommonClass.CommonVariable.WareHouseNo.PadLeft(2, '0') +
                            CommonClass.CommonVariable.DeviceID.PadLeft(2, '0') + "    " + CommonClass.CommonVariable.UserID.PadRight(7, ' ') + Convert.ToDateTime(dt1.Rows[B]["CustScannedOn"]).ToString("yyyyMMdd") + "1000" + coUNT.ToString().PadRight(2, '0') + "3000" +
                            TruckNo + CustCode + ShipTo + Possition + "                      CS" + DensoPart.ToString().PadRight(15, ' ') + dt1.Rows[B]["CUST_PartNo"].ToString().PadRight(25, ' ') + dt1.Rows[B]["CUST_PartQty"].ToString().PadRight(7, ' ') + dt1.Rows[B]["CUST_Sequence"].ToString().PadLeft(7, ' ') +
                            //dt1.Rows[B]["DNKI_PartQty"].ToString() + dt1.Rows[B]["DNKI_PartQty"].ToString() + dt1.Rows[B]["DNKI_Sequence"].ToString().PadLeft(7, '0') +
                            Convert.ToDateTime(dt1.Rows[B]["CustScannedOn"]).ToString("yyyyMMddHHmmss") +"        " + dt1.Rows[B]["CUST_Sequence"].ToString().PadLeft(7, ' ') + "              ";
                            CommonClass.CommonMethods.WriteFileNew(CommonClass.CommonVariable.Path_1 + "//" + SILHeader + ".DAT", str1 + "\r\n");

                        }
                    }
                    if (lblHeader.Text.Contains("3 POINT"))
                    {
                        string str = "L" + Sequence.PadLeft(4, '0') + CommonClass.CommonVariable.WareHouseNo.PadLeft(2, '0') +
                        CommonClass.CommonVariable.DeviceID.PadLeft(2, '0') + "    " + CommonClass.CommonVariable.UserID.PadRight(7, ' ') + Convert.ToDateTime(dt1.Rows[B]["DNKIScannedOn"]).ToString("yyyyMMdd") + "1000" + coUNT.ToString().PadRight(2, '0') + "2000" +
                        TruckNo + CustCode + ShipTo + Possition + "                      21" + dt1.Rows[B]["DNKI_PartNo"].ToString().PadRight(15, ' ') + dt1.Rows[B]["CUST_PartNo"].ToString().PadRight(25, ' ') +
                        dt1.Rows[B]["DNKI_PartQty"].ToString().PadLeft(7, ' ') + dt1.Rows[B]["DNKI_Sequence"].ToString().PadLeft(7, '0') +
                        Convert.ToDateTime(dt1.Rows[B]["DNKIScannedOn"]).ToString("yyyyMMddHHmmss")  + "                             ";
                        CommonClass.CommonMethods.WriteFileNew(CommonClass.CommonVariable.Path_1 + "//" + SILHeader + ".DAT", str + "\r\n");
                        coUNT = coUNT + 1;

                        if (DensoPart != "")
                        {
                            Sequence = (Convert.ToInt32(Sequence) + 1).ToString();
                            string str1 = "L" + Sequence.PadLeft(4, '0') + CommonClass.CommonVariable.WareHouseNo.PadLeft(2, '0') +
                            CommonClass.CommonVariable.DeviceID.PadLeft(2, '0') + "    " + CommonClass.CommonVariable.UserID.PadRight(7, ' ') + Convert.ToDateTime(dt1.Rows[B]["CustScannedOn"]).ToString("yyyyMMdd") + "1000" + coUNT.ToString().PadRight(2, '0') + "3000" +
                            TruckNo + CustCode + ShipTo + Possition + "                      CS" + dt1.Rows[B]["DNKI_PartNo"].ToString().PadRight(15, ' ') + dt1.Rows[B]["CUST_PartNo"].ToString().PadRight(25, ' ') + dt1.Rows[B]["CUST_PartQty"].ToString().PadRight(7, ' ') + dt1.Rows[B]["CUST_Sequence"].ToString().PadLeft(7, ' ') +
                            //dt1.Rows[B]["DNKI_PartQty"].ToString() + dt1.Rows[B]["DNKI_PartQty"].ToString() + dt1.Rows[B]["DNKI_Sequence"].ToString().PadLeft(7, '0') +
                            Convert.ToDateTime(dt1.Rows[B]["CustScannedOn"]).ToString("yyyyMMddHHmmss") + "                             ";
                            CommonClass.CommonMethods.WriteFileNew(CommonClass.CommonVariable.Path_1 + "//" + SILHeader + ".DAT", str1 + "\r\n");
                        }
                        else
                        {
                            Sequence = (Convert.ToInt32(Sequence) + 1).ToString();
                            string str1 = "L" + Sequence.PadLeft(4, '0') + CommonClass.CommonVariable.WareHouseNo.PadLeft(2, '0') +
                            CommonClass.CommonVariable.DeviceID.PadLeft(2, '0') + "    " + CommonClass.CommonVariable.UserID.PadRight(7, ' ') + Convert.ToDateTime(dt1.Rows[B]["CustScannedOn"]).ToString("yyyyMMdd") + "1000" + coUNT.ToString().PadRight(2, '0') + "3000" +
                            TruckNo + CustCode + ShipTo + Possition + "                      CS" + DensoPart.PadRight(15, ' ') + dt1.Rows[B]["CUST_PartNo"].ToString().PadRight(25, ' ') + dt1.Rows[B]["CUST_PartQty"].ToString().PadRight(7, ' ') + dt1.Rows[B]["CUST_Sequence"].ToString().PadLeft(7, ' ') +
                            //dt1.Rows[B]["DNKI_PartQty"].ToString() + dt1.Rows[B]["DNKI_PartQty"].ToString() + dt1.Rows[B]["DNKI_Sequence"].ToString().PadLeft(7, '0') +
                            Convert.ToDateTime(dt1.Rows[B]["CustScannedOn"]).ToString("yyyyMMddHHmmss")  + "                             ";
                            CommonClass.CommonMethods.WriteFile(CommonClass.CommonVariable.Path_1 + "//" + SILHeader + ".DAT", str1 + "\r\n");// it should be enable for hariyana plant hariyana plant
                           // CommonClass.CommonMethods.WriteFile(CommonClass.CommonVariable.Path_1 + "//" + SILHeader + ".DAT", str1);

                        }
                    }
                }
                coUNT = coUNT + 1;
                Thread.Sleep(2000);
                Sequence = (Convert.ToInt32(Sequence) + 1).ToString();
                string str2 = "L" + Sequence.PadLeft(4, '0') + CommonClass.CommonVariable.WareHouseNo.PadLeft(2, '0') +
                    CommonClass.CommonVariable.DeviceID.PadLeft(2, '0') + "    " + CommonClass.CommonVariable.UserID.PadRight(7, ' ') + System.DateTime.Now.ToString("yyyyMMdd") + "3000" + coUNT.ToString().PadRight(2, '0') + "0000" +
                TruckNo + CustCode + ShipTo + Possition + "                                                                              " +
                //+ dt1.Rows[B]["CUST_PartNo"].ToString().PadRight(34, ' ') + "0001" +dt1.Rows[B]["DNKI_PartQty"].ToString() + dt1.Rows[B]["DNKI_PartQty"].ToString() + dt1.Rows[B]["DNKI_Sequence"].ToString().PadLeft(7, '0') +
                System.DateTime.Now.ToString("yyyyMMdd") + System.DateTime.Now.ToString("HHmmss") + "                             ";
                CommonClass.CommonMethods.WriteFileNew(CommonClass.CommonVariable.Path_1 + "//" + SILHeader + ".DAT", str2 + "\r\n");


                File.Delete(CommonClass.CommonVariable.Path_1 + "//Sequnce.txt");
                CommonClass.CommonMethods.WriteFile(CommonClass.CommonVariable.Path_1 + "//Sequnce.txt", Sequence);

                //if (File.Exists(CommonClass.CommonVariable.Path + "/SIL_LIST.csv"))
                //{
                //    string Data = CommonClass.CommonMethods.ReadFile(CommonClass.CommonVariable.Path + "/SIL_LIST.csv");
                //    DataTable dt = CommonClass.CommonMethods.StringToDataTable(Data);

                //    File.Delete(CommonClass.CommonVariable.Path + "/SIL_LIST.csv");
                //    string str = "TRUCKNO" + "," + "SIL_BARCODE" + "," + "SCANNEDON";
                //    CommonClass.CommonMethods.WriteFile(CommonClass.CommonVariable.Path + "/SIL_LIST.csv", str);

                //    for (int i = 0; i < dt.Rows.Count; i++)
                //    {
                //        if (TruckNo != dt.Rows[i]["TRUCKNO"].ToString())
                //        {
                //            string str1 = dt.Rows[i]["TRUCKNO"].ToString() + "," + dt.Rows[i]["SIL_BARCODE"].ToString() + "," + dt.Rows[i]["SCANNEDON"].ToString();
                //            CommonClass.CommonMethods.WriteFile(CommonClass.CommonVariable.Path + "/SIL_LIST.csv", str1);
                //        }
                //    }

                //}

                WriteFTPFile("ftp://" + CommonClass.CommonVariable.FTPIP + "/SS" + System.DateTime.Now.ToString("yyMMdd") + System.DateTime.Now.ToString("HHmmss") + CommonClass.CommonVariable.DeviceID + ".DAT", CommonClass.CommonVariable.FTOUserID, CommonClass.CommonVariable.FTPPassword);

                Toast.MakeText(Android.App.Application.Context, "FTP FILE GENERATED SUCCESSFULLY", ToastLength.Long).Show();
                obj.PlaySound("Success");
                txtDenso.Text = "";
                DeleteSIL();
                GetSil_List();
                Clear();

                // System.IO.Directory.Delete()

                //}
            }

        }
        private void DeleteSIL()
        {
            if (File.Exists(CommonClass.CommonVariable.Path + "/SIL_LIST.csv"))
            {

                File.Delete(CommonClass.CommonVariable.Path + "/SIL_LIST.csv");
                string str = "TRUCKNO" + "," + "SIL_BARCODE" + "," + "SCANNEDON" + "," + "Status";
                CommonClass.CommonMethods.WriteFile(CommonClass.CommonVariable.Path + "/SIL_LIST.csv", str);

                for (int J = 0; J < DtSIL_List.Rows.Count; J++)
                {
                    if (pkSIL.SelectedItem.ToString() != DtSIL_List.Rows[J]["TRUCKNO"].ToString())
                    {
                        string str1 = DtSIL_List.Rows[J]["TRUCKNO"].ToString() + "," + DtSIL_List.Rows[J]["SIL_BARCODE"].ToString() + "," + DtSIL_List.Rows[J]["SCANNEDON"].ToString() + "," + DtSIL_List.Rows[J]["Status"].ToString();
                        CommonClass.CommonMethods.WriteFile(CommonClass.CommonVariable.Path + "/SIL_LIST.csv", str1);
                    }
                }

            }
        }
        private void UpdateComplteSILStatus()
        {
            if (File.Exists(CommonClass.CommonVariable.Path + "/SIL_LIST.csv"))
            {

                File.Delete(CommonClass.CommonVariable.Path + "/SIL_LIST.csv");
                string str = "TRUCKNO" + "," + "SIL_BARCODE" + "," + "SCANNEDON" + "," + "Status";
                CommonClass.CommonMethods.WriteFile(CommonClass.CommonVariable.Path + "/SIL_LIST.csv", str);

                for (int J = 0; J < DtSIL_List.Rows.Count; J++)
                {
                    if (pkSIL.SelectedItem.ToString() == DtSIL_List.Rows[J]["TRUCKNO"].ToString())
                    {
                        string str1 = DtSIL_List.Rows[J]["TRUCKNO"].ToString() + "," + DtSIL_List.Rows[J]["SIL_BARCODE"].ToString() + "," + DtSIL_List.Rows[J]["SCANNEDON"].ToString() + "," + "Completed";
                        CommonClass.CommonMethods.WriteFile(CommonClass.CommonVariable.Path + "/SIL_LIST.csv", str1);
                    }
                    else
                    {
                        string str1 = DtSIL_List.Rows[J]["TRUCKNO"].ToString() + "," + DtSIL_List.Rows[J]["SIL_BARCODE"].ToString() + "," + DtSIL_List.Rows[J]["SCANNEDON"].ToString() + "," + "";
                        CommonClass.CommonMethods.WriteFile(CommonClass.CommonVariable.Path + "/SIL_LIST.csv", str1);
                    }
                }

            }
        }
        private string ReadFTPFile(string path, string Username, string password)
        {
            string fileString = "";
            using (WebClient request = new WebClient())
            {

                string url = path;
                request.Credentials = new NetworkCredential(Username, password);

                byte[] newFileData = request.DownloadData(url);
                fileString = System.Text.Encoding.UTF8.GetString(newFileData);
            }
            return fileString;

            //string line = "";
            //Uri severUri = new Uri(path);

            //FtpWebRequest request = (FtpWebRequest)WebRequest.Create(severUri);
            //request.UseBinary = true;
            //request.UsePassive = false;//true;
            //request.KeepAlive = false;
            //request.Timeout = System.Threading.Timeout.Infinite;
            //request.AuthenticationLevel = System.Net.Security.AuthenticationLevel.None;
            //request.Credentials = new NetworkCredential(Username, password);
            //request.Method = WebRequestMethods.Ftp.DownloadFile;

            //using (Stream stream = request.GetResponse().GetResponseStream())
            //using (StreamReader reader = new StreamReader(stream))
            //{
            //    while (!reader.EndOfStream)
            //    {
            //        line = reader.ReadLine();
            //        // process the line
            //    }
            //}
            // return line;
        }
        private string WriteFTPFile(string path, string Username, string password)
        {

            string filePath = CommonClass.CommonVariable.Path_1 + "//" + SILHeader + ".DAT";
            Uri severUri = new Uri(path);
            if (severUri.Scheme != Uri.UriSchemeFtp)
                return "";


            using (var client = new WebClient())
            {
                client.Credentials = new NetworkCredential(Username, password);
                client.UploadFile(path, WebRequestMethods.Ftp.UploadFile, filePath);
                client.Dispose();
            }
            //FtpWebRequest request = (FtpWebRequest)WebRequest.Create(severUri);
            //request.Method = WebRequestMethods.Ftp.UploadFile;
            //request.UseBinary = false;
            //request.UsePassive = false;//true;
            //request.KeepAlive = false;
            //request.Timeout = System.Threading.Timeout.Infinite;
            //request.AuthenticationLevel = System.Net.Security.AuthenticationLevel.None;
            //request.Credentials = new NetworkCredential(Username, password);
            //StreamReader sourceStream = new StreamReader(filePath);
            //byte[] fileContents = Encoding.UTF8.GetBytes(sourceStream.ReadToEnd());
            //sourceStream.Close();
            //request.ContentLength = fileContents.Length;
            //Stream requestStream = request.GetRequestStream();
            //requestStream.Write(fileContents, 0, fileContents.Length);
            //requestStream.Close();
            //requestStream.Dispose();
            //FtpWebResponse response = (FtpWebResponse)request.GetResponse();
            //response.Close();
            //response.Dispose();
            return filePath;
        }
        private void Lock_ScreenPopUp(string Error)
        {
            CommonClass.CommonMethods.WriteFile(CommonClass.CommonVariable.Path + "//" + "Lock.txt", Error);
            App.Current.MainPage = new Pages.Lock_Screen();
        }
        private void TxtCustomer_Completed(object sender, EventArgs e)
        {
            try
            {
                if (pkSIL.SelectedIndex == -1)
                {
                    Toast.MakeText(Android.App.Application.Context, "PLEASE SELECT SIL TRUCK NO", ToastLength.Long).Show();
                    obj.PlaySound("Error");
                    return;
                }
                if (txtCustomer.Text == "" || txtCustomer.Text == (null))
                {
                    Toast.MakeText(Android.App.Application.Context, "PLEASE SCAN CUSTOMER BARCODE", ToastLength.Long).Show();

                    obj.PlaySound("Error");
                    txtCustomer.Focus();
                    return;
                }
                if (PackingList())
                {
                   
                    GetCustPossion();
                    //if(CustBarcode[12]=="")
                    //{
                    //    Toast.MakeText(Android.App.Application.Context, "PART NO IS NOT AVAILABLE IN THE PLACE", ToastLength.Long).Show();
                    //    obj.PlaySound("Error");
                    //    txtCustomer.Text = "";
                    //    txtCustomer.Focus();
                    //    return;
                    //}

                    if (!CustPart.Contains("-"))
                    {
                        if (CustPart1.Contains("-"))
                        {
                            string PartNo = CustPart1.Replace("-", "");
                            if (PartNo.TrimEnd() == CustPart.TrimEnd())
                            {
                                CustPart1= CustPart.TrimEnd();
                            }
                        }
                    }

                    if (CustPart1 != "")
                    {
                        if (!CustPart.TrimEnd().Contains(CustPart1))
                        {
                            Toast.MakeText(Android.App.Application.Context, "INVALID PART NO", ToastLength.Long).Show();
                            CommonClass.CommonVariable.Error = "CUSTOMER INVALID PART NO SCANNED";

                            Lock_ScreenPopUp(CommonClass.CommonVariable.Error);
                            obj.PlaySound("Error");
                            txtCustomer.Text = "";
                            txtCustomer.Focus();

                            return;
                        }
                    }

                    if (txtCustomer.Text.Contains("\r\n") || txtCustomer.Text.Contains("\n") || txtCustomer.Text.Contains(","))
                    {
                        txtCustomer.Text = txtCustomer.Text.Replace("\r\n", "+");
                        txtCustomer.Text = txtCustomer.Text.Replace("\n", "+");
                        txtCustomer.Text = txtCustomer.Text.Replace(",", "+");
                    }

                    //string str = "SIL_Barcode" + "," + "DNKI_Barcode" + "," + "CUSTOMER_Barcode" + "," + "DNKI_PartNo" + "," + "CUST_PartNo" + "," + "DNKI_PartQty" + "," + "CUST_PartQty" + ","  + "CUST_ProcessID" + "," + "SIL_TruckNo" + "," + "SIL_ShipTo" + "," + "SIL_CustNo" + "," + "DENSO_Sequence" + "," + "ScannedBy" + "," + "ScannedOn";

                    lblqty.Text = Convert.ToString(Qty) + "/" + (Convert.ToInt32(lblqty.Text.Split('/')[1]) + Convert.ToInt32(CustQty2)).ToString();

                    string str = SILbarcode + "," + DensoBarcode + "," + txtCustomer.Text + "," + PartNo + "," + CustPart.TrimEnd() + "," + lblqty.Text.Split('/')[0].ToString() + "," + CustQty1.ToString() + "," + ProcessCode + "," + TruckNo + "," + ShipTo + "," + CustCode + "," + SequenceNo + "," + CustSequ1 + "," + CommonClass.CommonVariable.UserID + "," + SILScannedon + "," + DNKIScannedOn + "," + System.DateTime.Now;

                    CommonClass.CommonMethods.WriteFile(CommonClass.CommonVariable.Path_1 + "//Barcode.csv", str);
                    txtCustomer.Text = "";
                    txtCustomer.Focus();

                    if (!File.Exists(CommonClass.CommonVariable.Path_1 + "//" + SILHeader + ".csv"))
                    {
                        string str10 = "PartNo" + "," + "SILQty" + "," + "DensoQty" + "," + "CustQty";
                        CommonClass.CommonMethods.WriteFile(CommonClass.CommonVariable.Path_1 + "//" + SILHeader + ".csv", str10);
                    }
                    else
                    {
                        File.Delete(CommonClass.CommonVariable.Path_1 + "//" + SILHeader + ".csv");
                        string str10 = "PartNo" + "," + "SILQty" + "," + "DensoQty" + "," + "CustQty";
                        CommonClass.CommonMethods.WriteFile(CommonClass.CommonVariable.Path_1 + "//" + SILHeader + ".csv", str10);
                    }

                    for (int j = 0; j < DtSIL.Rows.Count; j++)
                    {
                        if (DtSIL.Rows[j]["PartNo"].ToString() == PartNo.ToString())
                        {
                            if (Convert.ToInt32(DtSIL.Rows[j]["DensoQty"]) < Convert.ToInt32(DtSIL.Rows[j]["SILQty"]))
                                DtSIL.Rows[j]["DensoQty"] = (Convert.ToInt32(DtSIL.Rows[j]["CustQty"]) + Convert.ToInt32(CustQty2)).ToString();
                            if (Convert.ToInt32(DtSIL.Rows[j]["CustQty"]) < Convert.ToInt32(DtSIL.Rows[j]["SILQty"]))
                                DtSIL.Rows[j]["CustQty"] = (Convert.ToInt32(DtSIL.Rows[j]["CustQty"]) + Convert.ToInt32(CustQty2)).ToString();
                        }
                    }
                    int ToatlSil = 0;
                    int ToatlCust = 0;
                    for (int j = 0; j < DtSIL.Rows.Count; j++)
                    {
                        string str2 = DtSIL.Rows[j]["PartNo"].ToString() + "," + DtSIL.Rows[j]["SILQty"].ToString() + "," + DtSIL.Rows[j]["DensoQty"] + "," + DtSIL.Rows[j]["CustQty"];
                        CommonClass.CommonMethods.WriteFile(CommonClass.CommonVariable.Path_1 + "//" + SILHeader + ".csv", str2);
                        ToatlSil = (ToatlSil + Convert.ToInt32(DtSIL.Rows[j]["SILQty"]));
                        ToatlCust = (ToatlCust + Convert.ToInt32(DtSIL.Rows[j]["CustQty"]));
                    }

                    lblTotqty.Text = ToatlSil.ToString() + "/" + ToatlCust.ToString();

                    ListTag.ItemsSource = null;
                    ListTag.ItemsSource = DtSIL.Rows;
                    PackingList();

                    if (lblTotqty.Text.Split('/')[0] == lblTotqty.Text.Split('/')[1])
                    {
                        Toast.MakeText(Android.App.Application.Context, "SIL IS COMPLETED SUCCESSFULLY", ToastLength.Long).Show();
                        obj.PlaySound("Confirmation");
                        lblqty.Text = "0/0";
                        txtDenso.Text = "";
                        txtCustomer.Text = "";
                        txtDenso.Focus();
                        UpdateComplteSILStatus();
                        return;
                    }
                    if (lblqty.Text.Split('/')[0] == lblqty.Text.Split('/')[1])
                    {
                        Toast.MakeText(Android.App.Application.Context, "KANBAN FULLY SCANNED SUCCESSFULLY", ToastLength.Long).Show();
                        obj.PlaySound("Success");
                        lblqty.Text = "0/0";
                        txtDenso.Text = "";
                        txtCustomer.Text = "";
                        txtDenso.Focus();
                    }
                   
                }
            }
            catch (Exception ex)
            {
                obj.PlaySound("Error");
                Toast.MakeText(Android.App.Application.Context, ex.Message.ToString(), ToastLength.Long).Show();
                txtCustomer.Text = "";
                txtCustomer.Focus();
                //  DisplayAlert("Error", ex.Message, "OK");
            }
        }

        private void BtnGen_Clicked(object sender, EventArgs e)
        {
            try
            {
                if (pkSIL.SelectedIndex == -1)
                {
                    obj.PlaySound("Error");
                    Toast.MakeText(Android.App.Application.Context, "PLEASE SELECT SIL TRUCK NO", ToastLength.Long).Show();
                    return;
                }
                if (lblTotqty.Text.Split('/')[0] != lblTotqty.Text.Split('/')[1])
                {
                    obj.PlaySound("Error");
                    Toast.MakeText(Android.App.Application.Context, "PLEASE COMPLETE THE SCANNING", ToastLength.Long).Show();
                    return;
                }

                FileGaneration();
            }
            catch (Exception ex)
            {
                obj.PlaySound("Error");
                Toast.MakeText(Android.App.Application.Context, ex.Message.ToString(), ToastLength.Long).Show();
                txtCustomer.Text = "";
                txtCustomer.Focus();
                //  DisplayAlert("Error", ex.Message, "OK");
            }
        }

        private void PkSIL_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (pkSIL.SelectedIndex > -1)
                {
                    for (int i = 0; i < DtSIL_List.Rows.Count; i++)
                    {
                        if (DtSIL_List.Rows[i]["TRUCKNO"].ToString() == pkSIL.SelectedItem.ToString())
                        {
                            SILbarcode = DtSIL_List.Rows[i]["SIL_BARCODE"].ToString();
                            SILScannedon = DtSIL_List.Rows[i]["SCANNEDON"].ToString();
                        }
                    }
                    SILHeader = SILbarcode.Substring(0, 20);
                    TruckNo = SILHeader.Substring(0, 7);
                    CustCode = SILHeader.Substring(7, 8);
                    ShipTo = SILHeader.Substring(15, 2);
                    Possition = SILHeader.Substring(17, 1);
                    lblCust.Text = "CUST NO: " + CustCode + ", DATE: " + System.DateTime.Now.ToString("dd-MM-yyyy");
                    string PartDeatils = SILbarcode.Substring(20);

                    string CustPosFile = "";

                    CustPosFile = ReadFTPFile("ftp://" + CommonClass.CommonVariable.FTPIP + "/Cutomer_Position.txt", CommonClass.CommonVariable.FTOUserID, CommonClass.CommonVariable.FTPPassword);

                    // CustPosFile = CommonMethods.ReadFile(CommonClass.CommonVariable.Path + "//Cutomer_Position.txt");
                    string[] CustPosFile1 = CustPosFile.Replace("\r\n", "|").Split('|');
                    DensoPossion = "";
                    CustPossion = "";
                    QtyPossion = "";
                    SequePossion = "";
                    Separator = "";
                    for (int i = 1; i < CustPosFile1.Length; i++)
                    {
                        string[] CustPosFile2 = CustPosFile1[i].Split('+');
                        if (CustPosFile2[0].Trim().ToString() == Possition)
                        {
                            DensoPossion = CustPosFile2[1].Trim();
                            CustPossion = CustPosFile2[2].Trim();
                            QtyPossion = CustPosFile2[3].Trim();
                            SequePossion = CustPosFile2[4].Trim();
                            Separator = CustPosFile2[5].Trim();
                            if (Separator == "\\n")
                            {
                                Separator = "|";
                            }
                        }


                    }

                    if (CustPossion == "")
                    {
                        obj.PlaySound("Error");
                        Toast.MakeText(Android.App.Application.Context, "POSSITION VALUE IS NOT FOUND IN THE FTP FILE", ToastLength.Long).Show();
                        pkSIL.SelectedIndex = -1;
                        return;
                    }


                    if (File.Exists(CommonClass.CommonVariable.Path_1 + "//" + SILHeader + ".csv"))
                    {
                        string Data = CommonClass.CommonMethods.ReadFile(CommonClass.CommonVariable.Path_1 + "/" + SILHeader + ".csv");
                        //DataTable  DtSIL1 = CommonClass.CommonMethods.StringToDataTable(Data);
                        DtSIL = CommonClass.CommonMethods.StringToDataTable(Data);
                    }
                    else
                    {
                        DtSIL = new DataTable();
                        DtSIL.Columns.Add("PartNo");
                        DtSIL.Columns.Add("SILQty");
                        DtSIL.Columns.Add("DensoQty");
                        DtSIL.Columns.Add("CustQty");

                        for (int i = 0; i < PartDeatils.Length - 1; i++)
                        {
                            string PartNo = PartDeatils.Substring(i, 15);
                            i = i + PartNo.Length;
                            string Qty = PartDeatils.Substring(i, 7);
                            DtSIL.Rows.Add(PartNo, Convert.ToInt16(Qty), "0", "0");
                            i = i + Qty.Length - 1;
                        }
                    }
                    ListTag.ItemsSource = null;
                    int ToatlSil = 0;
                    int ToatlCust = 0;

                    for (int K = 0; K < DtSIL.Rows.Count; K++)
                    {
                        ToatlSil = (ToatlSil + Convert.ToInt32(DtSIL.Rows[K]["SILQty"]));
                        ToatlCust = (ToatlCust + Convert.ToInt32(DtSIL.Rows[K]["CustQty"]));
                    }

                    lblTotqty.Text = ToatlSil.ToString() + "/" + ToatlCust.ToString();

                    ListTag.ItemsSource = DtSIL.Rows;
                    txtDenso.Focus();
                }
            }
            catch (Exception ex)
            {
                obj.PlaySound("Error");
                Toast.MakeText(Android.App.Application.Context, ex.Message.ToString(), ToastLength.Long).Show();
                //  DisplayAlert("Error", ex.Message, "OK");
            }
        }

    }
}
