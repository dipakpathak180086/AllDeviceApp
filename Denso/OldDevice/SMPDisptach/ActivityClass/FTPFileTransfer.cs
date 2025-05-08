using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.Media;
using Android.OS;
using Android.Runtime;
using Android.Support.V7.Widget;
using Android.Views;
using Android.Views.InputMethods;
using Android.Widget;
using System.Collections;
using Org.Apache.Http;
using static Android.Support.V7.Widget.RecyclerView;
using System.Net;
using static Android.Telecom.Call;
using Java.Sql;

namespace SMPDisptach.ActivityClass
{
    [Activity(Label = "FTPFileTransfer", WindowSoftInputMode = Android.Views.SoftInput.StateAlwaysHidden, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation, ScreenOrientation = ScreenOrientation.Portrait)]
    public class FTPFileTransfer : Activity
    {

        clsGlobal clsGLB;
        Spinner spinnerSIL;
        Button btnFTPTransfer;
        //ModNet modnet;
        List<string> _lstFlag = new List<string>();
        List<ViewFTPScanData> _ListItem = new List<ViewFTPScanData>();
        SILFTPScanningItemAdapter receivingItemAdapter;
        RecyclerView recyclerViewItem;
        MediaPlayer mediaPlayerSound;
        RecyclerView.LayoutManager mLayoutManager;
        ProgressBar editProgressbar;
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
        string SILHeader = "";
        DataTable DtSIL = new DataTable();
        public FTPFileTransfer()
        {
            try
            {
                clsGLB = new clsGlobal();

                //modnet = new ModNet();

            }
            catch (Exception ex)
            {
                Toast.MakeText(this, ex.Message, ToastLength.Long).Show();
            }
        }
        public void ShowConfirmBox(string msg, Activity activity, EventHandler<DialogClickEventArgs> handler)
        {
            //scanningComplete = true;
            //SoundForFinalSave();
            Android.App.AlertDialog.Builder builder = new Android.App.AlertDialog.Builder(activity);
            builder.SetTitle("Message");
            builder.SetMessage(msg);
            builder.SetCancelable(false);
            builder.SetPositiveButton("Yes", handler);
            builder.SetNegativeButton("No", handllerCancelButton);
            builder.Show();
        }
        public void ShowMessageBox(string msg, Activity activity)
        {
            Android.App.AlertDialog.Builder builder = new Android.App.AlertDialog.Builder(activity);
            builder.SetTitle("Message");
            builder.SetMessage(msg);
            builder.SetCancelable(false);
            builder.SetPositiveButton("Ok", handleOkMessage);
            // builder.SetNegativeButton("No", handllerCancelButton);
            builder.Show();
        }
        void handllerCancelButton(object sender, DialogClickEventArgs e)
        {
            try
            {
                StopPlayingSound();
            }
            catch (Exception ex)
            {
                clsGLB.ShowMessage(ex.Message, this, MessageTitle.ERROR);
            }
        }

        void handleOkMessage(object sender, DialogClickEventArgs e)
        {
            try
            {
                StopPlayingSound();
            }
            catch (Exception ex)
            {
                clsGLB.ShowMessage(ex.Message, this, MessageTitle.ERROR);
            }
        }
        private void StartPlayingSound(bool isSaved = false)
        {
            try
            {



                if (isSaved)
                {
                    mediaPlayerSound = MediaPlayer.Create(this, Resource.Raw.SavedSound);
                }
                else
                {
                    StopPlayingSound();
                    mediaPlayerSound = MediaPlayer.Create(this, Resource.Raw.Beep);
                }
                mediaPlayerSound.Start();
            }
            catch (Exception ex) { throw ex; }
        }
        private void StopPlayingSound()
        {
            try
            {
                if (mediaPlayerSound != null)
                {
                    mediaPlayerSound.Stop();
                    mediaPlayerSound.Release();
                    mediaPlayerSound = null;
                    //scanningComplete = false;
                }
            }
            catch (Exception ex) { throw ex; }
        }
        private void SoundForNG()
        {
            try
            {
                Task.Run(() =>
                {
                    StopPlayingSound();
                    StartPlayingSound();
                    Thread.Sleep(3000);
                    StopPlayingSound();
                });

            }
            catch (Exception ex) { throw ex; }
        }

        protected override void OnCreate(Bundle savedInstanceState)
        {
            try
            {
                base.OnCreate(savedInstanceState);
                SetContentView(Resource.Layout.activity_FTPTransfer);


                //cmbSite = FindViewById<Spinner>(Resource.Id.cmbSite);
                btnFTPTransfer = FindViewById<Button>(Resource.Id.btnFTPTransfer);
                btnFTPTransfer.Click += btnFTPTransfer_Click;


                spinnerSIL = FindViewById<Spinner>(Resource.Id.spinnerSIL);
                spinnerSIL.ItemSelected += SpinnerSIL_ItemSelected;
                BindSpinnerCompltedSIL();
                Button btnBack = FindViewById<Button>(Resource.Id.btnBack);
                btnBack.Click += (e, a) =>
                {
                    this.Finish();
                };
                recyclerViewItem = FindViewById<RecyclerView>(Resource.Id.recycleViewReceiveItem);
                mLayoutManager = new LinearLayoutManager(this);
                recyclerViewItem.SetLayoutManager(mLayoutManager);

                editProgressbar = FindViewById<ProgressBar>(Resource.Id.progressBar);

                //txtBattery.Enabled = txtTruckNo.Enabled = false;
            }
            catch (Exception ex)
            {
                clsGLB.ShowMessage(ex.Message, this, MessageTitle.ERROR);
            }
        }

        private void SpinnerSIL_ItemSelected(object sender, AdapterView.ItemSelectedEventArgs e)
        {
            try
            {
                if (spinnerSIL.SelectedItemPosition > 0)
                {
                    BindRecycleView();
                }
            }
            catch (Exception ex)
            {
                clsGLB.ShowMessage(ex.Message, this, MessageTitle.ERROR);
            }
        }

        private void btnFTPTransfer_Click(object sender, EventArgs e)
        {
            if (spinnerSIL.SelectedItemPosition > 0)
            {
                FinalDeleteData();
            }
        }

        private void FinalDeleteData()
        {
            try
            {

                ShowConfirmBox($"Are you sure want to Generate the File and Transfer to this SIL {spinnerSIL.SelectedItem.ToString().Replace("*", "")} Data on FTP?", this, FileGenerateData);

            }
            catch (Exception ex)
            {
                clsGLB.ShowMessage(ex.Message, this, MessageTitle.ERROR);
            }


        }
        public static DataTable ToDataTable<T>(List<T> items)
        {
            var dataTable = new DataTable();

            // Get the properties of the type T
            var properties = typeof(T).GetProperties();

            // Create columns in the DataTable for each property
            foreach (var property in properties)
            {
                dataTable.Columns.Add(property.Name, Nullable.GetUnderlyingType(property.PropertyType) ?? property.PropertyType);
            }

            // Add rows to the DataTable for each item in the list
            foreach (var item in items)
            {
                var row = dataTable.NewRow();
                foreach (var property in properties)
                {
                    row[property.Name] = property.GetValue(item) ?? DBNull.Value;
                }
                dataTable.Rows.Add(row);
            }

            return dataTable;
        }

        private async void FileGenerate(DataTable dt)
        {
            try
            {
                //editProgressbar.Visibility = ViewStates.Visible;
                //await Task.Run(() =>
                //{
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    if (dt.Rows[i]["SIL_TruckNo"].ToString() == spinnerSIL.SelectedItem.ToString().Replace("*", ""))
                    {
                        SILbarcode = dt.Rows[i]["SIL_Barcode"].ToString();
                        SILScannedon = dt.Rows[i]["SILScannedOn"].ToString();
                        break;
                    }
                }
                SILHeader = SILbarcode.Substring(0, 20);
                TruckNo = SILHeader.Substring(0, 7);
                CustCode = SILHeader.Substring(7, 8);
                ShipTo = SILHeader.Substring(15, 2);
                Possition = SILHeader.Substring(17, 1);
                string strTranscationPath = Path.Combine(clsGlobal.FilePath, clsGlobal.TranscationFolder);
                string Path_1 = Path.Combine(strTranscationPath, spinnerSIL.SelectedItem.ToString().Replace("*", ""));
                DataView dv = new DataView(dt);
                dv.RowFilter = "SIL_Barcode='" + SILbarcode.ToString() + "'";
                DataTable dt1 = dv.ToTable();

                string sequencePath = Path_1 + "//Sequnce.txt";
                if (!File.Exists(sequencePath))
                    clsGlobal.WriteToFile(sequencePath, "0");

                string Sequence = clsGlobal.ReadFromFile(sequencePath).Trim();
                if (Sequence == "1000")
                {
                    File.Delete(sequencePath);
                    clsGlobal.WriteToFile(sequencePath, "0");
                }

                string datFilePath = Path_1 + "//" + SILHeader + ".DAT";
                if (File.Exists(datFilePath)) File.Delete(datFilePath);
                clsGlobal.WriteToFTPFile(datFilePath, dt1.Rows.Count.ToString().PadRight(177, ' ') + "\r\n");

                foreach (DataRow row in DtSIL.Rows)
                {
                    DataView Dv1 = new DataView(dt1);
                    Dv1.RowFilter = "DNKI_PartNo='" + row["PartNo"].ToString() + "'";
                    DataTable dt3 = Dv1.ToTable(true, "DNKI_Barcode", "DNKI_PartNo", "DNKI_ProcessID", "DNKI_Sequence", "DNKI_PartQty", "CUST_PartQty", "CUST_PartNo");

                    for (int A = 0; A < dt3.Rows.Count; A++)
                    {
                        //string str = $" 0521{dr["DNKI_PartNo"].ToString().PadRight(15)}        {dr["DNKI_ProcessID"].ToString().PadRight(5)}{dr["DNKI_Sequence"].ToString().PadRight(7)}         {dr["DNKI_PartQty"].ToString().PadLeft(7, '0')}{TruckNo}{Convert.ToDateTime(Dv1.ToTable().Rows[Dv1.ToTable().Rows.Count - 1]["CustScannedOn"]).ToString("yyyyMMdd")}1{dr["DNKI_PartQty"].ToString().PadLeft(7, '0')}{CustCode}{clsGlobal.mWarehouseNo}{Convert.ToDateTime(Dv1.ToTable().Rows[Dv1.ToTable().Rows.Count - 1]["CustScannedOn"]).ToString("yyyyMMddHHmmss")}{clsGlobal.mDeviceID}{ShipTo}{dr["CUST_PartNo"].ToString().PadRight(30)}00000000                         {clsGlobal.mUserId.PadRight(7)}";
                        string custScannedOn = Dv1.ToTable().Rows[Dv1.ToTable().Rows.Count - 1]["CustScannedOn"].ToString();
                        string formattedCustScannedOn = string.IsNullOrEmpty(custScannedOn) ? "" : Convert.ToDateTime(custScannedOn).ToString("yyyyMMdd");

                        string formattedCustScannedOnDateTime = string.IsNullOrEmpty(custScannedOn) ? "" : Convert.ToDateTime(custScannedOn).ToString("yyyyMMddHHmmss");

                        //string str = $" 0521{dr["DNKI_PartNo"].ToString().PadRight(15)}        {dr["DNKI_ProcessID"].ToString().PadRight(5)}{dr["DNKI_Sequence"].ToString().PadRight(7)}         {dr["DNKI_PartQty"].ToString().PadLeft(7, '0')}{TruckNo}{formattedCustScannedOn}1{dr["DNKI_PartQty"].ToString().PadLeft(7, '0')}{CustCode}{clsGlobal.mWarehouseNo}{formattedCustScannedOn}{clsGlobal.mDeviceID}{ShipTo}{dr["CUST_PartNo"].ToString().PadRight(30)}00000000                         {clsGlobal.mUserId.PadRight(7)}";
                        string str = " 0521" + dt3.Rows[A]["DNKI_PartNo"].ToString().PadRight(15, ' ') + "        " + dt3.Rows[A]["DNKI_ProcessID"].ToString().PadRight(5, ' ') + dt3.Rows[A]["DNKI_Sequence"].ToString().PadRight(7, ' ') + "         " + dt3.Rows[A]["DNKI_PartQty"].ToString().PadLeft(7, '0') + TruckNo + formattedCustScannedOn + "1" + dt3.Rows[A]["DNKI_PartQty"].ToString().PadLeft(7, '0') + CustCode + clsGlobal.mWarehouseNo + formattedCustScannedOnDateTime + clsGlobal.mDeviceID + ShipTo + dt3.Rows[A]["CUST_PartNo"].ToString().PadRight(30, ' ') + "00000000                         " + clsGlobal.mUserId.PadRight(7, ' ');
                        clsGlobal.WriteToFTPFile(datFilePath, str + "\r\n");
                    }
                }

                foreach (DataRow row in DtSIL.Rows)
                {
                    DataView Dv1 = new DataView(dt1);
                    Dv1.RowFilter = "DNKI_PartNo='" + row["PartNo"].ToString() + "'";
                    DataTable dt3 = Dv1.ToTable(true, "DNKI_Barcode", "DNKI_PartNo", "DNKI_ProcessID", "DNKI_Sequence", "DNKI_PartQty", "CUST_PartQty", "CUST_PartNo");

                    string PartNo1 = "";
                    int Qty = 0;
                    DataView dv2 = new DataView(dt3);

                    foreach (DataRow dr2 in dv2.ToTable(true, "DNKI_PartNo").Rows)
                    {
                        Sequence = (Convert.ToInt32(Sequence) + 1).ToString();
                        PartNo1 = dr2["DNKI_PartNo"].ToString();
                        Qty = dt3.AsEnumerable().Where(r => r["DNKI_PartNo"].ToString() == PartNo1).Sum(r => Convert.ToInt32(r["DNKI_PartQty"]));

                        //string str = $"L{Sequence.PadLeft(4, '0')}{clsGlobal.mWarehouseNo.PadLeft(2, '0')}{clsGlobal.mDeviceID.PadLeft(2, '0')}    {clsGlobal.mUserId.PadRight(7)}{Convert.ToDateTime(SILScannedon).ToString("yyyyMMdd")}1000101000{TruckNo}{CustCode}{ShipTo}{Possition}{dr2["DNKI_PartNo"].ToString().PadRight(15)}{Qty.ToString().PadLeft(7, '0')}                                                        {Convert.ToDateTime(SILScannedon).ToString("yyyyMMddHHmmss")}                             ";
                        string str = "L" + Sequence.PadLeft(4, '0') + clsGlobal.mWarehouseNo.PadLeft(2, '0') +
                        clsGlobal.mDeviceID.PadLeft(2, '0') + "    " + clsGlobal.mUserId.PadRight(7, ' ') + Convert.ToDateTime(SILScannedon).ToString("yyyyMMdd") + "1000101000" +
                        TruckNo + CustCode + ShipTo + Possition + dr2["DNKI_PartNo"].ToString().PadRight(15, ' ') +
                        Qty.ToString().PadLeft(7, '0') + "                                                        " +
                        Convert.ToDateTime(SILScannedon).ToString("yyyyMMddHHmmss") + "                             ";

                        clsGlobal.WriteToFTPFile(datFilePath, str + "\r\n");
                    }
                }

                int coUNT = 1;
                foreach (DataRow row in dt1.Rows)
                {
                    coUNT++;
                    Sequence = (Convert.ToInt32(Sequence) + 1).ToString();
                    // string str = $"L{Sequence.PadLeft(4, '0')}{clsGlobal.mWarehouseNo.PadLeft(2, '0')}{clsGlobal.mDeviceID.PadLeft(2, '0')}    {clsGlobal.mUserId.PadRight(7)}{Convert.ToDateTime(row["DNKIScannedOn"]).ToString("yyyyMMdd")}1000{coUNT.ToString().PadRight(2, '0')}2000{TruckNo}{CustCode}{ShipTo}{Possition}                      21{row["DNKI_PartNo"].ToString().PadRight(15)}{row["CUST_PartNo"].ToString().PadRight(25)}{row["DNKI_PartQty"].ToString().PadLeft(7)}{row["DNKI_Sequence"].ToString().PadLeft(7, '0')}{Convert.ToDateTime(row["DNKIScannedOn"]).ToString("yyyyMMddHHmmss")}                             ";
                    string str = "L" + Sequence.PadLeft(4, '0') + clsGlobal.mWarehouseNo.PadLeft(2, '0') +
                        clsGlobal.mDeviceID.PadLeft(2, '0') + "    " + clsGlobal.mUserId.PadRight(7, ' ') + Convert.ToDateTime(row["DNKIScannedOn"]).ToString("yyyyMMdd") + "1000" + coUNT.ToString().PadRight(2, '0') + "2000" +
                        TruckNo + CustCode + ShipTo + Possition + "                      21" + row["DNKI_PartNo"].ToString().PadRight(15, ' ') + row["CUST_PartNo"].ToString().PadRight(25, ' ') +
                        row["DNKI_PartQty"].ToString().PadLeft(7, ' ') + row["DNKI_Sequence"].ToString().PadLeft(7, '0') +
                        Convert.ToDateTime(row["DNKIScannedOn"]).ToString("yyyyMMddHHmmss") + "        " + row["DNKI_Sequence"].ToString().PadLeft(7, '0') + "              ";
                    clsGlobal.WriteToFTPFile(datFilePath, str + "\r\n");
                    coUNT++;

                    if (DensoPart != "")
                    {
                        Sequence = (Convert.ToInt32(Sequence) + 1).ToString();
                        // string str1 = $"L{Sequence.PadLeft(4, '0')}{clsGlobal.mWarehouseNo.PadLeft(2, '0')}{clsGlobal.mDeviceID.PadLeft(2, '0')}    {clsGlobal.mUserId.PadRight(7)}{Convert.ToDateTime(row["CustScannedOn"]).ToString("yyyyMMdd")}1000{coUNT.ToString().PadRight(2, '0')}3000{TruckNo}{CustCode}{ShipTo}{Possition}                      CS{row["DNKI_PartNo"].ToString().PadRight(15)}{row["CUST_PartNo"].ToString().PadRight(25)}{row["CUST_PartQty"].ToString().PadRight(7)}{row["CUST_Sequence"].ToString().PadLeft(7)}{Convert.ToDateTime(row["CustScannedOn"]).ToString("yyyyMMddHHmmss")}        {row["CUST_Sequence"].ToString().PadLeft(7)}              ";
                        string custScannedOn = row["CustScannedOn"].ToString();
                        string formattedCustScannedOnDateTime = string.IsNullOrEmpty(custScannedOn) ? "" : Convert.ToDateTime(custScannedOn).ToString("yyyyMMddHHmmss");
                        string formattedCustScannedOnDate = string.IsNullOrEmpty(custScannedOn) ? "" : Convert.ToDateTime(custScannedOn).ToString("yyyyMMdd");

                        //string str1 = $"L{Sequence.PadLeft(4, '0')}{clsGlobal.mWarehouseNo.PadLeft(2, '0')}{clsGlobal.mDeviceID.PadLeft(2, '0')}    {clsGlobal.mUserId.PadRight(7)}{formattedCustScannedOn}1000{coUNT.ToString().PadRight(2, '0')}3000{TruckNo}{CustCode}{ShipTo}{Possition}                      CS{row["DNKI_PartNo"].ToString().PadRight(15)}{row["CUST_PartNo"].ToString().PadRight(25)}{row["CUST_PartQty"].ToString().PadRight(7)}{row["CUST_Sequence"].ToString().PadLeft(7)}{formattedCustScannedOn}        {row["CUST_Sequence"].ToString().PadLeft(7)}              ";
                        string str1 = "L" + Sequence.PadLeft(4, '0') + clsGlobal.mWarehouseNo.PadLeft(2, '0') +
                           clsGlobal.mDeviceID.PadLeft(2, '0') + "    " + clsGlobal.mUserId.PadRight(7, ' ') + formattedCustScannedOnDate + "1000" + coUNT.ToString().PadRight(2, '0') + "3000" +
                           TruckNo + CustCode + ShipTo + Possition + "                      CS" + row["DNKI_PartNo"].ToString().PadRight(15, ' ') + row["CUST_PartNo"].ToString().PadRight(25, ' ') + row["CUST_PartQty"].ToString().PadRight(7, ' ') + row["CUST_Sequence"].ToString().PadLeft(7, ' ') +
                           //dt1.Rows[B]["DNKI_PartQty"].ToString() + dt1.Rows[B]["DNKI_PartQty"].ToString() + dt1.Rows[B]["DNKI_Sequence"].ToString().PadLeft(7, '0') +
                           formattedCustScannedOnDateTime + "                             ";
                        clsGlobal.WriteToFTPFile(datFilePath, str1 + "\r\n");
                    }
                    else
                    {
                        Sequence = (Convert.ToInt32(Sequence) + 1).ToString();
                        //string str1 = $"L{Sequence.PadLeft(4, '0')}{clsGlobal.mWarehouseNo.PadLeft(2, '0')}{clsGlobal.mDeviceID.PadLeft(2, '0')}    {clsGlobal.mUserId.PadRight(7)}{Convert.ToDateTime(row["CustScannedOn"]).ToString("yyyyMMdd")}1000{coUNT.ToString().PadRight(2, '0')}3000{TruckNo}{CustCode}{ShipTo}{Possition}                      CS{DensoPart.PadRight(15)}{row["CUST_PartNo"].ToString().PadRight(25)}{row["CUST_PartQty"].ToString().PadRight(7)}{row["CUST_Sequence"].ToString().PadLeft(7)}{Convert.ToDateTime(row["CustScannedOn"]).ToString("yyyyMMddHHmmss")}        {row["CUST_Sequence"].ToString().PadLeft(7)}              ";
                        string custScannedOn = row["CustScannedOn"].ToString();
                        string formattedCustScannedOnDateTime = string.IsNullOrEmpty(custScannedOn) ? "" : Convert.ToDateTime(custScannedOn).ToString("yyyyMMddHHmmss");
                        string formattedCustScannedOnDate = string.IsNullOrEmpty(custScannedOn) ? "" : Convert.ToDateTime(custScannedOn).ToString("yyyyMMdd");

                        //string str1 = $"L{Sequence.PadLeft(4, '0')}{clsGlobal.mWarehouseNo.PadLeft(2, '0')}{clsGlobal.mDeviceID.PadLeft(2, '0')}    {clsGlobal.mUserId.PadRight(7)}{formattedCustScannedOn}1000{coUNT.ToString().PadRight(2, '0')}3000{TruckNo}{CustCode}{ShipTo}{Possition}                      CS{DensoPart.PadRight(15)}{row["CUST_PartNo"].ToString().PadRight(25)}{row["CUST_PartQty"].ToString().PadRight(7)}{row["CUST_Sequence"].ToString().PadLeft(7)}{formattedCustScannedOn}        {row["CUST_Sequence"].ToString().PadLeft(7)}              ";
                        string str1 = "L" + Sequence.PadLeft(4, '0') + clsGlobal.mWarehouseNo.PadLeft(2, '0') +
                            clsGlobal.mDeviceID.PadLeft(2, '0') + "    " + clsGlobal.mUserId.PadRight(7, ' ') + formattedCustScannedOnDate + "1000" + coUNT.ToString().PadRight(2, '0') + "3000" +
                            TruckNo + CustCode + ShipTo + Possition + "                      CS" + DensoPart.PadRight(15, ' ') + row["CUST_PartNo"].ToString().PadRight(25, ' ') + row["CUST_PartQty"].ToString().PadRight(7, ' ') + row["CUST_Sequence"].ToString().PadLeft(7, ' ') +
                            //dt1.Rows[B]["DNKI_PartQty"].ToString() + dt1.Rows[B]["DNKI_PartQty"].ToString() + dt1.Rows[B]["DNKI_Sequence"].ToString().PadLeft(7, '0') +
                            formattedCustScannedOnDateTime + "                             ";
                        clsGlobal.WriteToFTPFile(datFilePath, str1 + "\r\n");
                    }
                }

                coUNT++;
                Thread.Sleep(2000);
                Sequence = (Convert.ToInt32(Sequence) + 1).ToString();
                string str2 = $"L{Sequence.PadLeft(4, '0')}{clsGlobal.mWarehouseNo.PadLeft(2, '0')}{clsGlobal.mDeviceID.PadLeft(2, '0')}    {clsGlobal.mUserId.PadRight(7)}{DateTime.Now:yyyyMMdd}3000{coUNT.ToString().PadRight(2, '0')}0000{TruckNo}{CustCode}{ShipTo}{Possition}                                                                              {DateTime.Now:yyyyMMdd}{DateTime.Now:HHmmss}                             ";
                clsGlobal.WriteToFTPFile(datFilePath, str2 + "\r\n");

                File.Delete(sequencePath);
                clsGlobal.WriteToFile(sequencePath, "0");

                WriteFTPFile("ftp://" + clsGlobal.mFTPIP + "/SS" + System.DateTime.Now.ToString("yyMMdd") + System.DateTime.Now.ToString("HHmmss") + clsGlobal.mDeviceID + ".DAT", clsGlobal.mFTPUserID, clsGlobal.mFTPPassword);
                clsGlobal.DeleteDirectory(Path_1);

                //});
                //clsGlobal.DeleteDirectory(strFinal);
                clsGLB.ShowMessage($"This SIL File Transferred {spinnerSIL.SelectedItem.ToString().Replace("*", "")} Successfully!!!", this, MessageTitle.INFORMATION);
                BindSpinnerCompltedSIL();
                _ListItem.Clear();
                receivingItemAdapter.NotifyDataSetChanged();




            }
            catch (Exception ex)
            {
                editProgressbar.Visibility = ViewStates.Gone;
                clsGLB.ShowMessage(ex.Message, this, MessageTitle.ERROR);
            }
            finally
            {
                editProgressbar.Visibility = ViewStates.Gone;
            }

        }
        private string WriteFTPFile(string path, string Username, string password)
        {
            string strTranscationPath = Path.Combine(clsGlobal.FilePath, clsGlobal.TranscationFolder);
            string Path_1 = Path.Combine(strTranscationPath, spinnerSIL.SelectedItem.ToString().Replace("*", ""));
            string filePath = Path_1 + "//" + SILHeader + ".DAT";
            Uri severUri = new Uri(path);
            if (severUri.Scheme != Uri.UriSchemeFtp)
                return "";


            using (var client = new WebClient())
            {
                client.Credentials = new NetworkCredential(Username, password);
                client.UploadFile(path, WebRequestMethods.Ftp.UploadFile, filePath);
                client.Dispose();
            }

            return filePath;
            //string strTransactionPath = Path.Combine(clsGlobal.FilePath, clsGlobal.TranscationFolder);
            //string path1 = Path.Combine(strTransactionPath, spinnerSIL.SelectedItem.ToString().Replace("*",""));
            //string filePath = path1 + "//" + SILHeader + ".DAT";
            //int port = 5151;
            //// Modify the URI to include the port
            //Uri baseUri = new Uri(path);
            //string ftpUri = $"{baseUri.Scheme}://{baseUri.Host}:{port}{baseUri.AbsolutePath}";
            //Uri serverUri = new Uri(ftpUri);

            //// Validate the URI scheme
            //if (serverUri.Scheme != Uri.UriSchemeFtp)
            //    return "";

            //using (var client = new WebClient())
            //{
            //    client.Credentials = new NetworkCredential(Username, password);
            //    client.UploadFile(serverUri.ToString(), WebRequestMethods.Ftp.UploadFile, filePath);
            //}

            //return filePath;
        }
        private void SaveDataIntoTable(ref DataTable dtHead, ref DataTable dtDetails)
        {
            PL_HHT_DOWNLOAD _plObj = null;

            BL_HHT_DOWNLOAD _blObj = new BL_HHT_DOWNLOAD();
            PL_DETAILS_DATA _plObjDetailsData = null;
            BL_DETAILS_DATA _blObjDetailsData = new BL_DETAILS_DATA();
            try
            {

                _plObj = new PL_HHT_DOWNLOAD();
                _plObj.DbType = "DELETE";
                _plObj.SIL_CODE = spinnerSIL.SelectedItem.ToString().Replace("*", "");
                _plObj.CreatedBy = clsGlobal.mUserId;
                _blObj.BL_ExecuteTask(_plObj);

                _plObjDetailsData = new PL_DETAILS_DATA();
                _plObjDetailsData.DbType = "DELETE";
                _plObjDetailsData.SILNo = spinnerSIL.SelectedItem.ToString().Replace("*", "");
                _blObjDetailsData.BL_ExecuteTask(_plObjDetailsData);

                for (int iHeader = 0; iHeader < dtHead.Rows.Count; iHeader++)
                {
                    _plObj = new PL_HHT_DOWNLOAD();
                    _plObj.DbType = "HEADER";
                    _plObj.SIL_CODE = spinnerSIL.SelectedItem.ToString().Replace("*", "");
                    _plObj.PART_NO = dtHead.Rows[iHeader][0].ToString();
                    _plObj.TOTAL_QTY = Convert.ToInt32(dtHead.Rows[iHeader][1]);
                    _plObj.SCAN_QTY = Convert.ToInt32(dtHead.Rows[iHeader][2]);
                    _plObj.BAL_QTY = Convert.ToInt32(dtHead.Rows[iHeader][3]);
                    _plObj.BinQty = Convert.ToInt32(dtHead.Rows[iHeader][4]);
                    _plObj.CP_PROCESS = dtDetails.Columns.Count == 3 ? "2POINTS" : "3POINTS";
                    _plObj.CreatedBy = clsGlobal.mUserId;

                    _blObj.BL_ExecuteTask(_plObj);
                }
                for (int iDetails = 0; iDetails < dtDetails.Rows.Count; iDetails++)
                {
                    _plObj = new PL_HHT_DOWNLOAD();
                    _plObj.DbType = "DETAILS";
                    _plObj.CP_PROCESS = dtDetails.Columns.Count == 3 ? "2POINTS" : "3POINTS";
                    _plObj.SIL_CODE = spinnerSIL.SelectedItem.ToString().Replace("*", "");
                    _plObj.SIL_BARCODE = clsGlobal.ReplaceCaretWithNewlines(dtDetails.Rows[iDetails][0]?.ToString());
                    _plObj.BARCODE1 = dtDetails.Rows[iDetails][1]?.ToString();
                    if (_plObj.CP_PROCESS == "2POINTS")
                    {
                        _plObj.BARCODE2 = "";
                    }
                    else
                    {
                        _plObj.BARCODE2 = clsGlobal.ReplaceCaretWithNewlines(dtDetails.Rows[iDetails][2]?.ToString());
                        if (_plObj.BARCODE2 == "SIL")
                        {
                            _plObj.BARCODE2 = "";
                        }

                    }
                    _plObj.PATTERN_CODE = dtDetails.Rows[iDetails][17]?.ToString();
                    _plObj.IsMatchBarcode1SeqNo = dtDetails.Rows[iDetails][18]?.ToString() == "" ? false : Convert.ToBoolean(dtDetails.Rows[iDetails][18]?.ToString());
                    _plObj.Barcode1SeqNo = dtDetails.Rows[iDetails][19]?.ToString() == "" ? "" : dtDetails.Rows[iDetails][19]?.ToString();
                    _plObj.IsMatchBarcode2SeqNo = dtDetails.Rows[iDetails][20]?.ToString() == "" ? false : Convert.ToBoolean(dtDetails.Rows[iDetails][20]?.ToString());
                    _plObj.Barcode2SeqNo = dtDetails.Rows[iDetails][21]?.ToString() == "" ? "" : dtDetails.Rows[iDetails][21]?.ToString();
                    _plObj.PART_NO = dtDetails.Rows[iDetails][3]?.ToString();
                    _plObj.CreatedBy = clsGlobal.mUserId;
                    _blObj.BL_ExecuteTask(_plObj);
                    _plObjDetailsData = new PL_DETAILS_DATA();
                    _plObjDetailsData.DbType = "SAVE";
                    _plObjDetailsData.SILNo = spinnerSIL.SelectedItem.ToString().Replace("*", "");
                    _plObjDetailsData.SILBarcode = dtDetails.Rows[iDetails][0]?.ToString();
                    _plObjDetailsData.DNHASupBarcode = dtDetails.Rows[iDetails][1]?.ToString();
                    _plObjDetailsData.CUSBarcode = dtDetails.Rows[iDetails][2]?.ToString();
                    _plObjDetailsData.PartNo = dtDetails.Rows[iDetails][3]?.ToString();
                    _plObjDetailsData.CustPart = dtDetails.Rows[iDetails][4]?.ToString();
                    _plObjDetailsData.Qty = dtDetails.Rows[iDetails][5]?.ToString();
                    _plObjDetailsData.ExtChar = dtDetails.Rows[iDetails][6]?.ToString();
                    _plObjDetailsData.ProcessCode = dtDetails.Rows[iDetails][7]?.ToString();
                    _plObjDetailsData.TruckNo = dtDetails.Rows[iDetails][8]?.ToString();
                    _plObjDetailsData.ShipTo = dtDetails.Rows[iDetails][9]?.ToString();
                    _plObjDetailsData.CustCode = dtDetails.Rows[iDetails][10]?.ToString();
                    _plObjDetailsData.SequenceNo = dtDetails.Rows[iDetails][11]?.ToString();
                    _plObjDetailsData.CustSeqNo = dtDetails.Rows[iDetails][12]?.ToString();
                    _plObjDetailsData.UserId = dtDetails.Rows[iDetails][13]?.ToString();
                    _plObjDetailsData.SILScannedOn = dtDetails.Rows[iDetails][14]?.ToString();
                    _plObjDetailsData.DNHAScannedOn = dtDetails.Rows[iDetails][15]?.ToString();
                    _plObjDetailsData.CustScannedOn = dtDetails.Rows[iDetails][16]?.ToString();
                    _plObjDetailsData.DNHAPattern = dtDetails.Rows[iDetails][17]?.ToString();
                    _plObjDetailsData.MatchBarcode1SeqNo = dtDetails.Rows[iDetails][18]?.ToString() == "" ? false : Convert.ToBoolean(dtDetails.Rows[iDetails][18]?.ToString());
                    _plObjDetailsData.Barcode1SeqNo = dtDetails.Rows[iDetails][19]?.ToString() == "" ? "" : dtDetails.Rows[iDetails][19]?.ToString();
                    _plObjDetailsData.MatchBarcode2SeqNo = dtDetails.Rows[iDetails][20]?.ToString() == "" ? false : Convert.ToBoolean(dtDetails.Rows[iDetails][20]?.ToString());
                    _plObjDetailsData.Barcode2SeqNo = dtDetails.Rows[iDetails][21]?.ToString() == "" ? "" : dtDetails.Rows[iDetails][21]?.ToString();
                    _blObjDetailsData = new BL_DETAILS_DATA();
                    _blObjDetailsData.BL_ExecuteTask(_plObjDetailsData);


                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        private void FileGenerateData(object sender, DialogClickEventArgs e)
        {
            try
            {
                string strTranscationPath = Path.Combine(clsGlobal.FilePath, clsGlobal.TranscationFolder);
                string strFinal = Path.Combine(strTranscationPath, spinnerSIL.SelectedItem.ToString().Replace("*", "").Replace("*", ""));
                DataTable dtHead = null;
                DataTable dtDetails = null;
                string strMainScanFile = Path.Combine(strFinal, clsGlobal.SILDetailsFile);
                string strHeaderPath = Path.Combine(strFinal, clsGlobal.SILMasterDataFile);
                string strDetailsPath = Path.Combine(strFinal, clsGlobal.SILDetailsFile);
                string strAllString = File.ReadAllText(strMainScanFile);
                clsGlobal.mBindDataTablesSep(strHeaderPath, strDetailsPath, "~", ref dtHead, ref dtDetails);
                DataTable dtMain = CreateDataTable(strAllString);
                if (dtMain.Rows.Count > 0)
                {
                    SaveDataIntoTable(ref dtHead, ref dtDetails);
                    DtSIL = ToDataTable(_ListItem);
                    FileGenerate(dtMain);

                }
            }
            catch (Exception ex)
            {

                clsGLB.ShowMessage(ex.Message, this, MessageTitle.ERROR);
            }
            finally
            { StopPlayingSound(); }
        }
        private void BindRecycleView()
        {
            try
            {

                _ListItem.Clear();
                string strSILCode = spinnerSIL.SelectedItem.ToString().Replace("*", "");
                string strTranscationPath = Path.Combine(clsGlobal.FilePath, clsGlobal.TranscationFolder);
                string strFinalSILWiseDirectory = Path.Combine(strTranscationPath, strSILCode);
                string strFinalFilePath = Path.Combine(strFinalSILWiseDirectory, clsGlobal.SILMasterDataFile);


                if (File.Exists(strFinalFilePath))
                {
                    _ListItem = clsGlobal.ReadSILFTPFileToList(strFinalFilePath);
                }

                receivingItemAdapter = new SILFTPScanningItemAdapter(this, _ListItem);
                recyclerViewItem.SetAdapter(receivingItemAdapter);
                receivingItemAdapter.NotifyDataSetChanged();

            }
            catch (Exception ex) { throw ex; }
        }
        public void BindALLSIL(string path)
        {
            try
            {
                _lstFlag.Clear();
                _lstFlag.Add("--Select--");
                string[] directoriesFinal = Directory.GetDirectories(path);
                for (int i = 0; i < directoriesFinal.Length; i++)
                {
                    string strCompltedSIL = Path.Combine(directoriesFinal[i].TrimEnd(Path.DirectorySeparatorChar), clsGlobal.SILCompletedFile);
                    if (File.Exists(strCompltedSIL))
                    {
                        string strSILCode = Path.GetFileName(directoriesFinal[i].TrimEnd(Path.DirectorySeparatorChar));
                        _lstFlag.Add("*" + strSILCode);
                    }
                }

                // Get all directories
            }
            catch (Exception ex)
            {
                // Handle exceptions (e.g., path not found)
                Console.WriteLine(ex.Message);
            }
        }
        private void BindSpinnerCompltedSIL()
        {

            string strTranscationPath = Path.Combine(clsGlobal.FilePath, clsGlobal.TranscationFolder);
            BindALLSIL(strTranscationPath);

            ArrayAdapter arrayAdapter = new ArrayAdapter(this, Resource.Layout.Spinner, _lstFlag);
            arrayAdapter.SetDropDownViewResource(Android.Resource.Layout.SimpleSpinnerDropDownItem);
            spinnerSIL.Adapter = arrayAdapter;
            spinnerSIL.SetSelection(0);
            spinnerSIL.RequestFocus();
        }

        private void DismissKeyboard()
        {
            var view = CurrentFocus;
            if (view != null)
            {
                var imm = (InputMethodManager)GetSystemService(InputMethodService);
                imm.HideSoftInputFromWindow(view.WindowToken, 0);
            }
        }

        private void DismissKeyboard2()
        {
            var currentFocus = this.CurrentFocus;
            if (currentFocus != null)
            {
                InputMethodManager inputMethodManager = (InputMethodManager)this.GetSystemService(Context.InputMethodService);
                inputMethodManager.HideSoftInputFromWindow(currentFocus.WindowToken, HideSoftInputFlags.None);
            }

        }
        public static DataTable CreateDataTable(string data)
        {
            // Define the column names
            string[] columns = new string[]
            {
            "SIL_Barcode", "DNKI_Barcode", "CUSTOMER_Barcode", "DNKI_PartNo", "CUST_PartNo",
            "DNKI_PartQty", "CUST_PartQty", "DNKI_ProcessID", "SIL_TruckNo", "SIL_ShipTo",
            "SIL_CustNo", "DNKI_Sequence", "CUST_Sequence", "ScannedBy", "SILScannedOn",
            "DNKIScannedOn", "CustScannedOn", "PATTERNCODE", "ISMatchBarcode1Data", "Barcode1Data", "ISMatchBarcode2Data", "Barcode2Data"
            };

            // Create a DataTable and define the columns
            DataTable dataTable = new DataTable();
            foreach (var column in columns)
            {
                dataTable.Columns.Add(column);
            }

            // Split the data by \r\n to separate each row of data
            string[] rows = data.Split(new[] { "\n" }, StringSplitOptions.RemoveEmptyEntries);

            foreach (var rowData in rows)
            {
                // Split each row by "~"
                string[] dataParts = rowData.Split('~');

                // Make sure the data has enough parts to fill the columns
                if (dataParts.Length == columns.Length)
                {
                    // Create a new row and populate it with the split data
                    DataRow row = dataTable.NewRow();
                    for (int i = 0; i < columns.Length; i++)
                    {
                        row[columns[i]] = dataParts[i].Trim();
                    }
                    dataTable.Rows.Add(row);
                }
            }

            return dataTable;
        }



        private void BtnClear_Click(object sender, EventArgs e)
        {
            try
            {
                clear();
            }
            catch (Exception ex)
            {
                clsGLB.ShowMessage(ex.Message, this, MessageTitle.ERROR);
            }
        }

        private void Btnback_Click(object sender, EventArgs e)
        {
            try
            {
                this.Finish();
                //OpenActivity(typeof(MainActivity));
            }
            catch (Exception ex)
            {
                clsGLB.ShowMessage(ex.Message, this, MessageTitle.ERROR);
            }
        }



        public override void OnBackPressed() { }

        private bool ValidateControls()
        {
            try
            {
                bool IsValidate = true;

                if (spinnerSIL.SelectedItemPosition <= 0)
                {
                    Toast.MakeText(this, "Select SIL.", ToastLength.Long).Show();
                    spinnerSIL.RequestFocus();
                    IsValidate = false;
                }



                return IsValidate;
            }
            catch (Exception ex) { throw ex; }
        }

        private void clear()
        {
            spinnerSIL.SetSelection(0);
        }
        public void OpenActivity(Type t)
        {
            try
            {
                Intent MenuIntent = new Intent(this, t);
                StartActivity(MenuIntent);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }




    }
}