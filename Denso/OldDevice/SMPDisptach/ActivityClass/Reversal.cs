using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Data;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.Media;
using Android.OS;
using Android.Runtime;
using Android.Support.V7.Widget;
using Android.Util;
using Android.Views;
using Android.Views.InputMethods;
using Android.Widget;
using Java.Sql;
using Java.Util;
using Org.Apache.Http;
using static Android.Net.Wifi.WifiEnterpriseConfig;
using static Android.Support.V7.Widget.RecyclerView;

namespace SMPDisptach.ActivityClass
{
    /// <summary>
    /// Main
    /// </summary>
    [Activity(Label = "Reversal", WindowSoftInputMode = Android.Views.SoftInput.StateAlwaysHidden, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation, ScreenOrientation = ScreenOrientation.Portrait)]
    public class Reversal : Activity
    {
        #region Private Variables
        private BL_REVERSAL _blObj = null;
        private PL_REVERSAL _plObj = null;
        Vibrator vibrator;
        clsGlobal clsGLB;
        EditText txtSILBarcode, txtDNHASupBarcode;
        Dictionary<string, string> dicRegPlant = new Dictionary<string, string>();
        TextView txtTotalQty, txtScanQty;

        DataTable dtHead = null;
        DataTable dtDetails = null;
        TextView lblCount;
        int _TotalQty = 0, _ScanQty = 0, _SrNoCounter = 0;
        int dispatchcunt = 0;
        int _DnhaSupQty = 0;
        string _SILCode = string.Empty;
        StringBuilder _sb = new StringBuilder();
        List<ViewSILScanData> _ListItem = new List<ViewSILScanData>();

        Dictionary<string, string> _dicBarcode1 = new Dictionary<string, string>();
        Dictionary<string, string> _dicBarcode2 = new Dictionary<string, string>();
        bool scanningComplete = false;
        string selectedSKU = string.Empty;
        string strDNHAPartNo = string.Empty;
        RecyclerView recyclerViewItem;
        SILScanItemAdapter receivingItemAdapter;
        RecyclerView.LayoutManager mLayoutManager;
        RecyclerView.LayoutManager mLayoutManager2;
        Dictionary<string, string> _dicBatteryScanningData = new Dictionary<string, string>();
        MediaPlayer mediaPlayerSound;

        #endregion

        #region Constructor
        public Reversal()
        {
            try
            {
                clsGLB = new clsGlobal();
                _blObj = new BL_REVERSAL();

            }
            catch (Exception ex)
            {
                Toast.MakeText(this, ex.Message, ToastLength.Long).Show();
            }
        }

        #endregion

        #region MainEvent
        protected override void OnCreate(Bundle savedInstanceState)
        {
            try
            {
                base.OnCreate(savedInstanceState);
                SetContentView(Resource.Layout.activity_Reversal);

                //cmbSite = FindViewById<Spinner>(Resource.Id.cmbSite);

                vibrator = this.GetSystemService(VibratorService) as Vibrator;

                Button btn = FindViewById<Button>(Resource.Id.btnBack);
                btn.Click += Btnback_Click;
                Button btnClear = FindViewById<Button>(Resource.Id.btnClear);
                btnClear.Click += BtnClear_Click;


                txtSILBarcode = FindViewById<EditText>(Resource.Id.editSILBarcode);
                txtSILBarcode.KeyPress += txtSILBarcode_KeyPress;
                txtSILBarcode.Text = "";

                txtDNHASupBarcode = FindViewById<EditText>(Resource.Id.editDNHASupBarcode);
                txtDNHASupBarcode.KeyPress += txtDNHASupBarcode_KeyPress;
                txtDNHASupBarcode.Text = "";


                txtTotalQty = FindViewById<TextView>(Resource.Id.txtTotalQty);
                txtTotalQty.Text = "Total Qty : " + _TotalQty.ToString();

                txtScanQty = FindViewById<TextView>(Resource.Id.txtScanQty);
                txtScanQty.Text = "Scan Qty : " + _ScanQty.ToString();



                recyclerViewItem = FindViewById<RecyclerView>(Resource.Id.recycleViewReceiveItem);
                mLayoutManager = new LinearLayoutManager(this);
                recyclerViewItem.SetLayoutManager(mLayoutManager);


                txtSILBarcode.RequestFocus();
                clsGlobal.ReadAlertMessage();
                if (clsGlobal.mAlertMeassage != "")
                {
                    ShowAlertPopUp();
                    return;
                }
            }
            catch (Exception ex)
            {
                clsGLB.ShowMessage(ex.Message, this, MessageTitle.ERROR);
            }
        }



        #endregion

        #region Private methods
        public void ShowConfirmBox(string msg, Activity activity, EventHandler<DialogClickEventArgs> handler)
        {
            scanningComplete = true;

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
                    mediaPlayerSound = MediaPlayer.Create(this, Resource.Raw.OkSound);
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
                    scanningComplete = false;
                }
            }
            catch (Exception ex) { throw ex; }
        }
        private void SoundForOK()
        {
            try
            {
                Task.Run(() =>
                { //Start Vibration
                    long[] pattern = { 0, 2000, 500 }; //0 to start now, 200 to vibrate 200 ms, 0 to sleep for 0 ms.
                    vibrator.Vibrate(pattern, -1);//
                    StopPlayingSound();
                    StartPlayingSound(true);
                    Thread.Sleep(2000);
                    StopPlayingSound();
                    vibrator.Cancel();
                });

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


        private void ShowAlertPopUp()
        {
            try
            {

                AlertActivity customDialog = new AlertActivity(this);
                customDialog.SetCanceledOnTouchOutside(false);
                customDialog.Show();
            }
            catch (Exception ex) { throw ex; }
        }

        private void GetSetTotalAndScanQty()
        {
            _TotalQty = 0;
            _ScanQty = 0;
            for (int iCount = 0; iCount < _ListItem.Count; iCount++)
            {
                _TotalQty += Convert.ToInt32(Convert.ToInt32(_ListItem[iCount].Qty));
                _ScanQty += Convert.ToInt32(Convert.ToInt32(_ListItem[iCount].ScanQty));
            }
            txtTotalQty.Text = "Total Qty : " + _TotalQty.ToString();
            txtScanQty.Text = "Scan Qty : " + _ScanQty.ToString();
        }
        private void WriteDeatilsFile(string writeContent)
        {
            try
            {
                if (_ListItem.Count > 0)
                {
                    string strSILCode = _SILCode;
                    string strTranscationPath = Path.Combine(clsGlobal.FilePath, clsGlobal.TranscationFolder);
                    string strFinalSILWiseDirectory = Path.Combine(strTranscationPath, strSILCode);
                    string strFinalFilePath = Path.Combine(strFinalSILWiseDirectory, clsGlobal.SILDetailsFile);
                    clsGlobal.WriteToFile(strFinalFilePath, writeContent);
                }

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        private void WriteHeaderFile(string writeContent)
        {
            try
            {
                if (_ListItem.Count > 0)
                {
                    string strSILCode = _SILCode;
                    string strTranscationPath = Path.Combine(clsGlobal.FilePath, clsGlobal.TranscationFolder);
                    string strFinalSILWiseDirectory = Path.Combine(strTranscationPath, strSILCode);
                    string strFinalFilePath = Path.Combine(strFinalSILWiseDirectory, clsGlobal.SILBarcode);
                    clsGlobal.WriteToFile(strFinalFilePath, writeContent);
                }

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        private void WriteSILCompltedFile(string writeContent)
        {
            try
            {
                if (_ListItem.Count > 0)
                {
                    string strSILCode = _SILCode;
                    string strTranscationPath = Path.Combine(clsGlobal.FilePath, clsGlobal.TranscationFolder);
                    string strFinalSILWiseDirectory = Path.Combine(strTranscationPath, strSILCode);
                    string strFinalFilePath = Path.Combine(strFinalSILWiseDirectory, clsGlobal.SILCompletedFile);
                    clsGlobal.WriteToFile(strFinalFilePath, writeContent);
                }

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        private void SaveReversal()
        {
            try
            {
                bool isCheckBarcode = dtDetails.AsEnumerable().Any(row => row.ItemArray[1].ToString() == txtDNHASupBarcode.Text.Trim());

                if (!isCheckBarcode)
                {
                    clsGLB.showToastNGMessage($"Invalid DNHA/SUP Barcode or Not available in the list.", this);
                    txtDNHASupBarcode.Text = "";
                    SoundForNG();
                    ShowAlertPopUp();
                    return;
                }
                //if (dtDetails.Rows.Count == 1)
                //{
                //    clsGLB.showToastNGMessage($"Last data can't remove you need to go SIL Delete option", this);
                //    txtDNHASupBarcode.Text = "";
                //    SoundForNG();
                //    ShowAlertPopUp();
                //    return;

                //}
                string strTranscationPath = Path.Combine(clsGlobal.FilePath, clsGlobal.TranscationFolder);
                string strFinalSILWiseDirectory = Path.Combine(strTranscationPath, _SILCode);
                string strFinalFilePath = Path.Combine(strFinalSILWiseDirectory, clsGlobal.SILMasterDataFile);
                string strSILBarcodeFilePath = Path.Combine(strFinalSILWiseDirectory, clsGlobal.SILBarcode);
                string strCompltedSIL = Path.Combine(strFinalSILWiseDirectory, clsGlobal.SILCompletedFile);
                _plObj = new PL_REVERSAL();
                _plObj.DbType = "SAVE";
                _plObj.SIL_BARCODE = txtSILBarcode.Text.Trim();
                _plObj.SIL_NO = _SILCode;
                _plObj.DNHA_BARCODE = txtDNHASupBarcode.Text.Trim();
                _plObj.CreatedBy = clsGlobal.mUserId;
                DataTable dtData = _blObj.BL_ExecuteTask(_plObj).Tables[0];
                if (dtData.Rows.Count > 0)
                {
                    if (dtData.Rows[0]["Result"].ToString() == "Y")
                    {
                        var part = dtDetails.AsEnumerable()
                           .Where(row => row.ItemArray[1].ToString() == txtDNHASupBarcode.Text.Trim())
                           .Select(row => row.ItemArray[3].ToString()) // Getting Part as string
                           .FirstOrDefault();
                        var qty = dtDetails.AsEnumerable()
                           .Where(row => row.ItemArray[1].ToString() == txtDNHASupBarcode.Text.Trim())
                           .Select(row => row.ItemArray[5].ToString()) // Getting qty as string
                           .FirstOrDefault();

                        for (int i = 0; i < dtHead.Rows.Count; i++)
                        {
                            if (dtHead.Rows[i][0].Equals(part))
                            {
                                dtHead.Rows[i][2] = Convert.ToInt32(dtHead.Rows[i][2]) - Convert.ToInt32(qty);
                                dtHead.Rows[i][3] = Convert.ToInt32(dtHead.Rows[i][1]) - Convert.ToInt32(dtHead.Rows[i][2]);
                                dtHead.AcceptChanges();
                            }
                        }

                        var rowToDelete = dtDetails.AsEnumerable()
                               .FirstOrDefault(row => row.ItemArray[1].ToString() == txtDNHASupBarcode.Text.Trim());
                        if (rowToDelete != null)
                        {
                            rowToDelete.Delete();
                            dtDetails.AcceptChanges();

                        }
                        try
                        {
                            Directory.Delete(strFinalSILWiseDirectory, true);
                            Directory.CreateDirectory(strFinalSILWiseDirectory);
                            MediaScannerConnection.ScanFile(this, new String[] { strTranscationPath }, null, null);
                        }
                        catch (Exception ex)
                        {

                            clsGLB.showToastNGMessage($"{ex.Message}", this);
                            txtDNHASupBarcode.Text = "";
                            SoundForNG();
                            ShowAlertPopUp();
                        }
                        _ListItem.Clear();
                        for (int i = 0; i < dtHead.Rows.Count; i++)
                        {
                            ViewSILScanData viewSILScanData = new ViewSILScanData();
                            viewSILScanData.PartNo = dtHead.Rows[i][0].ToString();
                            viewSILScanData.Qty = dtHead.Rows[i][1].ToString();
                            viewSILScanData.ScanQty = dtHead.Rows[i][2].ToString();
                            viewSILScanData.Balance = dtHead.Rows[i][3].ToString();
                            viewSILScanData.Bin = dtHead.Rows[i][4].ToString();
                            _ListItem.Add(viewSILScanData);
                            clsGlobal.WriteSILFileFromList(strFinalFilePath, _ListItem);
                        }
                        for (int i = 0; i < dtDetails.Rows.Count; i++)
                        {
                            WriteDeatilsFile($"{dtDetails.Rows[i][0].ToString()}~{clsGlobal.ReplaceNewlinesWithCaret(dtDetails.Rows[i][1].ToString())}~{clsGlobal.ReplaceNewlinesWithCaret(dtDetails.Rows[i][2].ToString())}" +
                       $"~{dtDetails.Rows[i][3].ToString()}~{dtDetails.Rows[i][4].ToString()}~{dtDetails.Rows[i][5].ToString()}~{dtDetails.Rows[i][6].ToString()}~{dtDetails.Rows[i][7].ToString()}~{dtDetails.Rows[i][8].ToString()}~{dtDetails.Rows[i][9].ToString()}~{dtDetails.Rows[i][10].ToString()}~{dtDetails.Rows[i][11].ToString()}~{dtDetails.Rows[i][12].ToString()}~{dtDetails.Rows[i][13].ToString()}" +
                       $"~{dtDetails.Rows[i][14].ToString()}~{dtDetails.Rows[i][15].ToString()}~{dtDetails.Rows[i][16].ToString()}~{dtDetails.Rows[i][17].ToString()}~{dtDetails.Rows[i][18].ToString()}~{dtDetails.Rows[i][19].ToString()}~{dtDetails.Rows[i][20].ToString()}~{dtDetails.Rows[i][21].ToString()}");
                        }
                        GetSetTotalAndScanQty();
                        string strSILBarcode = $"{txtSILBarcode.Text.Trim()}";
                        clsGlobal.WriteToFile(strSILBarcodeFilePath, strSILBarcode);
                        receivingItemAdapter = new SILScanItemAdapter(this, _ListItem);
                        recyclerViewItem.SetAdapter(receivingItemAdapter);

                        receivingItemAdapter.NotifyDataSetChanged();
                        txtDNHASupBarcode.Text = "";
                        txtDNHASupBarcode.RequestFocus();
                        //if (_TotalQty == _ScanQty)
                        //{
                        //    clsGLB.showToastNGMessage($"Master Kanban Fraction Completed!!", this);
                        //    clear();
                        //    return;
                        //}
                    }
                    else
                    {
                        clsGLB.showToastNGMessage($"{dtData.Rows[0]["Result"].ToString()}", this);
                        txtDNHASupBarcode.Text = "";
                        SoundForNG();
                        ShowAlertPopUp();
                        return;
                    }
                }


            }
            catch (Exception ex) { throw ex; }
        }




        private void SaveData(object sender, DialogClickEventArgs e)
        {
            try
            {

                //bool bReturn = false;
                //for (int i = 0; i < _ListScanItem.Count; i++)
                //{
                //    bReturn = ModNet.BatteryScanningDataSave(txtSILBarcode.Text.Trim(), _ListScanItem[i].SKU, _ListScanItem[i].PartNo);
                //}
                //if (bReturn)
                //{

                //    lblResult.Text = $"This Delivery ({txtSILBarcode.Text.Trim()}) Data Saved Successfully!!!";
                //    clsGLB.ShowMessage($"This Delivery ({txtSILBarcode.Text.Trim()}) Data Saved Successfully!!!", this, MessageTitle.INFORMATION);
                //    txtDNHAKanbanBarcode.Text = "";
                //    txtDNHAKanbanBarcode.RequestFocus();

                //    clear();
                //    this.Finish();
                //    OpenActivity(typeof(BatteryScanningMainActivity));
                //}
                //else
                //{
                //    lblResult.Text = ModInit.Gstrarr[0];
                //    txtDNHAKanbanBarcode.Text = "";
                //    txtDNHAKanbanBarcode.RequestFocus();
                //    SoundForNG();
                //}
            }
            catch (Exception)
            {

                throw;
            }
            finally
            { StopPlayingSound(); }
        }
        private void FinalSaveData()
        {
            try
            {

                ShowConfirmBox("Submit Scanned Data?", this, SaveData);

            }
            catch (Exception ex)
            {
                clsGLB.ShowMessage(ex.Message, this, MessageTitle.ERROR);
            }


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




        #endregion




        #region GenricFuncation for commna to get Part And Qty
        #endregion

        #region Activiy Events



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

            }
            catch (Exception ex)
            {
                clsGLB.ShowMessage(ex.Message, this, MessageTitle.ERROR);
            }
        }

        private void txtSILBarcode_KeyPress(object sender, View.KeyEventArgs e)
        {
            try
            {
                if (e.Event.Action == KeyEventActions.Down)
                {
                    if (e.KeyCode == Keycode.Enter)
                    {
                        if (txtSILBarcode.Text.Trim() == "")
                        {
                            return;
                        }
                        if (string.IsNullOrEmpty(txtSILBarcode.Text.Trim()))
                        {
                            clsGLB.showToastNGMessage($"Scan SIL Barcode.", this);
                            txtSILBarcode.Text = "";
                            txtSILBarcode.RequestFocus();
                            SoundForNG();
                            ShowAlertPopUp();
                            return;
                        }

                        _SILCode = txtSILBarcode.Text.Trim().Substring(0, 7);
                        string strTranscationPath = Path.Combine(clsGlobal.FilePath, clsGlobal.TranscationFolder);
                        string strFinalSILWiseDirectory = Path.Combine(strTranscationPath, _SILCode);
                        string strFinalFilePath = Path.Combine(strFinalSILWiseDirectory, clsGlobal.SILMasterDataFile);
                        string strSILBarcodeFilePath = Path.Combine(strFinalSILWiseDirectory, clsGlobal.SILBarcode);
                        string strCompltedSIL = Path.Combine(strFinalSILWiseDirectory, clsGlobal.SILCompletedFile);
                        dtHead = null;
                        dtDetails = null;
                        _plObj = new PL_REVERSAL();
                        _plObj.DbType = "GET_SIL_DATA";
                        _plObj.SIL_NO = _SILCode;
                        DataSet ds1 = _blObj.BL_ExecuteTask(_plObj);
                        if (ds1.Tables.Count == 0)
                        {
                            if (!File.Exists(strCompltedSIL))
                            {
                                clsGLB.showToastNGMessage($"Invalid SIL Barcode or SIL is incompleted.", this);
                                txtSILBarcode.Text = "";
                                txtSILBarcode.RequestFocus();
                                SoundForNG();
                                ShowAlertPopUp();
                                return;
                            }
                        }
                        if (File.Exists(strCompltedSIL))
                        {
                            dtHead = null;
                            dtDetails = null;
                            string strFinal = Path.Combine(strTranscationPath, _SILCode.Replace("*", "").Replace("*", ""));
                            string strMainScanFile = Path.Combine(strFinal, clsGlobal.SILDetailsFile);
                            string strHeaderPath = Path.Combine(strFinal, clsGlobal.SILMasterDataFile);
                            string strDetailsPath = Path.Combine(strFinal, clsGlobal.SILDetailsFile);
                            clsGlobal.mBindDataTablesSep(strHeaderPath, strDetailsPath, "~", ref dtHead, ref dtDetails);
                            for (int i = 0; i < dtHead.Rows.Count; i++)
                            {
                                ViewSILScanData viewSILScanData = new ViewSILScanData();
                                viewSILScanData.PartNo = dtHead.Rows[i][0].ToString();
                                viewSILScanData.Qty = dtHead.Rows[i][1].ToString();
                                viewSILScanData.ScanQty = dtHead.Rows[i][2].ToString();
                                viewSILScanData.Balance = dtHead.Rows[i][3].ToString();
                                viewSILScanData.Bin = dtHead.Rows[i][4].ToString();
                                _ListItem.Add(viewSILScanData);
                            }
                            GetSetTotalAndScanQty();

                            receivingItemAdapter = new SILScanItemAdapter(this, _ListItem);
                            recyclerViewItem.SetAdapter(receivingItemAdapter);

                            receivingItemAdapter.NotifyDataSetChanged();
                            txtDNHASupBarcode.RequestFocus();

                        }
                        else
                        {


                            if (!Directory.Exists(strFinalSILWiseDirectory))
                            {
                                Directory.CreateDirectory(strFinalSILWiseDirectory);
                            }
                            _ListItem.Clear();
                            dtHead = null;
                            dtDetails = null;
                            _plObj = new PL_REVERSAL();
                            _plObj.DbType = "GET_SIL_DATA";
                            _plObj.SIL_NO = _SILCode;
                            DataSet ds = _blObj.BL_ExecuteTask(_plObj);
                            if (ds.Tables.Count == 0)
                            {
                                clsGLB.showToastNGMessage($"Invalid SIL Barcode or SIL is incompleted.", this);
                                txtSILBarcode.Text = "";
                                txtSILBarcode.RequestFocus();
                                SoundForNG();
                                ShowAlertPopUp();
                                return;
                            }
                            dtHead = ds.Tables[0];
                            dtDetails = ds.Tables[1];
                            for (int i = 0; i < dtHead.Rows.Count; i++)
                            {
                                ViewSILScanData viewSILScanData = new ViewSILScanData();
                                viewSILScanData.PartNo = dtHead.Rows[i][0].ToString();
                                viewSILScanData.Qty = dtHead.Rows[i][1].ToString();
                                viewSILScanData.ScanQty = dtHead.Rows[i][2].ToString();
                                viewSILScanData.Balance = dtHead.Rows[i][3].ToString();
                                viewSILScanData.Bin = dtHead.Rows[i][4].ToString();
                                _ListItem.Add(viewSILScanData);
                                clsGlobal.WriteSILFileFromList(strFinalFilePath, _ListItem);
                            }
                            for (int i = 0; i < dtDetails.Rows.Count; i++)
                            {
                                WriteDeatilsFile($"{dtDetails.Rows[i][0].ToString()}~{clsGlobal.ReplaceNewlinesWithCaret(dtDetails.Rows[i][1].ToString())}~{clsGlobal.ReplaceNewlinesWithCaret(dtDetails.Rows[i][2].ToString())}" +
                           $"~{dtDetails.Rows[i][3].ToString()}~{dtDetails.Rows[i][4].ToString()}~{dtDetails.Rows[i][5].ToString()}~{dtDetails.Rows[i][6].ToString()}~{dtDetails.Rows[i][7].ToString()}~{dtDetails.Rows[i][8].ToString()}~{dtDetails.Rows[i][9].ToString()}~{dtDetails.Rows[i][10].ToString()}~{dtDetails.Rows[i][11].ToString()}~{dtDetails.Rows[i][12].ToString()}~{dtDetails.Rows[i][13].ToString()}" +
                           $"~{dtDetails.Rows[i][14].ToString()}~{dtDetails.Rows[i][15].ToString()}~{dtDetails.Rows[i][16].ToString()}~{dtDetails.Rows[i][17].ToString()}~{dtDetails.Rows[i][18].ToString()}~{dtDetails.Rows[i][19].ToString()}~{dtDetails.Rows[i][20].ToString()}~{dtDetails.Rows[i][21].ToString()}");
                            }
                            GetSetTotalAndScanQty();

                            receivingItemAdapter = new SILScanItemAdapter(this, _ListItem);
                            recyclerViewItem.SetAdapter(receivingItemAdapter);

                            receivingItemAdapter.NotifyDataSetChanged();
                            WriteSILCompltedFile(_SILCode);
                            string strSILBarcode = $"{txtSILBarcode.Text.Trim()}";
                            clsGlobal.WriteToFile(strSILBarcodeFilePath, strSILBarcode);
                            txtDNHASupBarcode.RequestFocus();

                        }


                    }
                    else
                        e.Handled = false;
                }
            }
            catch (Exception ex)
            {
                clsGLB.ShowMessage(ex.Message, this, MessageTitle.ERROR);
            }
        }
        private void txtDNHASupBarcode_KeyPress(object sender, View.KeyEventArgs e)
        {
            try
            {
                if (e.Event.Action == KeyEventActions.Down)
                {
                    if (e.KeyCode == Keycode.Enter)
                    {
                        if (txtDNHASupBarcode.Text.Trim() == "")
                        {
                            return;
                        }
                        if (string.IsNullOrEmpty(txtSILBarcode.Text.Trim()))
                        {
                            clsGLB.showToastNGMessage($"Scan SIL Barcode.", this);
                            txtSILBarcode.Text = "";
                            txtSILBarcode.RequestFocus();
                            SoundForNG();
                            ShowAlertPopUp();
                            return;
                        }
                        else if (txtSILBarcode.Text.Length < 25)
                        {
                            clsGLB.showToastNGMessage($"Invalid SIL Barcode.", this);
                            txtSILBarcode.Text = "";
                            txtSILBarcode.RequestFocus();
                            SoundForNG();
                            ShowAlertPopUp();
                            return;
                        }
                        else if (string.IsNullOrEmpty(txtDNHASupBarcode.Text.Trim()))
                        {
                            clsGLB.showToastNGMessage($"Scan DNHA/SUP Kanban Barcode.", this);
                            txtDNHASupBarcode.Text = "";
                            txtDNHASupBarcode.RequestFocus();
                            SoundForNG();
                            ShowAlertPopUp();
                            return;
                        }
                        else if (txtDNHASupBarcode.Text.Length < 25)
                        {
                            clsGLB.showToastNGMessage($"Invalid DNHA/SUP Kanban Barcode.", this);
                            txtDNHASupBarcode.Text = "";
                            txtDNHASupBarcode.RequestFocus();
                            SoundForNG();
                            ShowAlertPopUp();
                            return;
                        }
                        else if (_ListItem.Count == 0)
                        {
                            clsGLB.showToastNGMessage($"Scan First DNHA Master Kanban Barcode.", this);

                            SoundForNG();
                            ShowAlertPopUp();
                            return;

                        }
                        SaveReversal();

                    }
                    else
                        e.Handled = false;
                }
            }
            catch (Exception ex)
            {
                clsGLB.ShowMessage(ex.Message, this, MessageTitle.ERROR);
            }
        }

        public override void OnBackPressed() { }


        private void clear()
        {

            if (_dicBatteryScanningData.Count > 0)
                _dicBatteryScanningData.Clear();
            _SILCode = "";
            _dicBarcode1.Clear();
            _dicBarcode2.Clear();
            _ScanQty = 0;
            _TotalQty = 0;

            txtSILBarcode.Text = txtDNHASupBarcode.Text = "";


            if (_ListItem.Count > 0)
                _ListItem.Clear();

            for (int i = 0; i < _ListItem.Count; i++)
            {
                _ListItem[i].ScanQty = "0";
                _ListItem[i].Balance = _ListItem[i].Qty;
            }
            if (receivingItemAdapter != null)
            {
                receivingItemAdapter.NotifyDataSetChanged();
            }

            txtTotalQty.Text = "Total Qty : " + _TotalQty.ToString();
            txtScanQty.Text = "Total SQty : " + _ScanQty.ToString();
            txtSILBarcode.RequestFocus();


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

        #endregion

    }
}