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
using static Android.Net.Wifi.WifiEnterpriseConfig;
using static Android.Support.V7.Widget.RecyclerView;

namespace SMPDisptach.ActivityClass
{
    /// <summary>
    /// Main
    /// </summary>
    [Activity(Label = "Fraction", WindowSoftInputMode = Android.Views.SoftInput.StateAlwaysHidden, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation, ScreenOrientation = ScreenOrientation.Portrait)]
    public class Fraction : Activity
    {
        #region Private Variables
        private BL_FRACTION _blObj = null;
        private PL_FRACTION _plObj = null;
        Vibrator vibrator;
        clsGlobal clsGLB;
        EditText txtMasterBarcode, txtChildBarcode;
        Dictionary<string, string> dicRegPlant = new Dictionary<string, string>();
        TextView txtTotalQty, txtScanQty;
        TextView lblCount;
        int _TotalQty = 0, _ScanQty = 0, _SrNoCounter = 0;
        int dispatchcunt = 0;
        int _DnhaSupQty = 0;
        string _SILCode = string.Empty;
        StringBuilder _sb = new StringBuilder();
        List<ViewFraction> _ListItem = new List<ViewFraction>();

        Dictionary<string, string> _dicBarcode1 = new Dictionary<string, string>();
        Dictionary<string, string> _dicBarcode2 = new Dictionary<string, string>();
        bool scanningComplete = false;
        string selectedSKU = string.Empty;
        string strDNHAPartNo = string.Empty;
        RecyclerView recyclerViewItem;
        FractionItemAdapter receivingItemAdapter;
        RecyclerView.LayoutManager mLayoutManager;
        RecyclerView.LayoutManager mLayoutManager2;
        Dictionary<string, string> _dicBatteryScanningData = new Dictionary<string, string>();
        MediaPlayer mediaPlayerSound;

        #endregion

        #region Constructor
        public Fraction()
        {
            try
            {
                clsGLB = new clsGlobal();
                _blObj = new BL_FRACTION();

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
                SetContentView(Resource.Layout.activity_Fraction);

                //cmbSite = FindViewById<Spinner>(Resource.Id.cmbSite);

                vibrator = this.GetSystemService(VibratorService) as Vibrator;

                Button btn = FindViewById<Button>(Resource.Id.btnBack);
                btn.Click += Btnback_Click;
                Button btnClear = FindViewById<Button>(Resource.Id.btnClear);
                btnClear.Click += BtnClear_Click;


                txtMasterBarcode = FindViewById<EditText>(Resource.Id.editMasterKanban);
                txtMasterBarcode.KeyPress += txtMasterBarcode_KeyPress;
                txtMasterBarcode.Text = "";

                txtChildBarcode = FindViewById<EditText>(Resource.Id.editChildKanban);
                txtChildBarcode.KeyPress += TxtChildBarcode_KeyPress;
                txtChildBarcode.Text = "";


                txtTotalQty = FindViewById<TextView>(Resource.Id.txtTotalQty);
                txtTotalQty.Text = "Total Qty : " + _TotalQty.ToString();

                txtScanQty = FindViewById<TextView>(Resource.Id.txtScanQty);
                txtScanQty.Text = "Scan Qty : " + _ScanQty.ToString();

                //_plObj = new PL_FRACTION();
                //_plObj.DbType = "SELECT";
                //_plObj.MasterKanban = txtMasterBarcode.Text.Trim();
                //DataTable dtData = _blObj.BL_ExecuteTask(_plObj);


                // lblCount = FindViewById<TextView>(Resource.Id.lblCount);

                recyclerViewItem = FindViewById<RecyclerView>(Resource.Id.recycleViewReceiveItem);
                mLayoutManager = new LinearLayoutManager(this);
                recyclerViewItem.SetLayoutManager(mLayoutManager);


                txtMasterBarcode.RequestFocus();
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
        private void SaveFraction()
        {
            try
            {

              
                
                string strMasterPartNo = string.Empty;
                string strChildPartNo = string.Empty;
                int iMasterQty = 0;
                int iChildQty = 0;
                try
                {
                    ExtractPartNoAndQty(txtMasterBarcode.Text.Trim(), ref strMasterPartNo, ref iMasterQty);
                    ExtractPartNoAndQty(txtChildBarcode.Text.Trim(), ref strChildPartNo, ref iChildQty);
                }
                catch
                {
                    clsGLB.showToastNGMessage($"Invalid DNHA Child Kanban Barcode.", this);

                    SoundForNG();
                    ShowAlertPopUp();
                    return;
                }
                if (!strMasterPartNo.Equals(strChildPartNo))
                {
                    clsGLB.showToastNGMessage($"Master And Child Kanban Part No should be same.", this);
                    txtChildBarcode.Text = "";
                    SoundForNG();
                    ShowAlertPopUp();
                    return;


                }
                if (txtMasterBarcode.Text.Trim().Equals(txtChildBarcode.Text.Trim()))
                {
                    clsGLB.showToastNGMessage($"Master And Child Kanban should not be same.", this);
                    txtChildBarcode.Text = "";
                    SoundForNG();
                    ShowAlertPopUp();
                    return;


                }
                if (iChildQty>iMasterQty)
                {
                    clsGLB.showToastNGMessage($"Child Kanban Qty should be less then Master Kanban Qty..", this);
                    txtChildBarcode.Text = "";
                    SoundForNG();
                    ShowAlertPopUp();
                    return;


                }
                if (_TotalQty == _ScanQty)
                {
                    clsGLB.showToastNGMessage($"Master Kanban Fraction Completed!!", this);
                    clear();
                    return;
                }


                _plObj = new PL_FRACTION();
                _plObj.DbType = "SAVE";
                _plObj.MasterKanban = txtMasterBarcode.Text.Trim();
                _plObj.PartNo = strMasterPartNo;
                _plObj.MasterQty = iMasterQty;
                _plObj.ChildKanban = txtChildBarcode.Text.Trim();
                _plObj.ChildQty = iChildQty;
                _plObj.CreatedBy = clsGlobal.mUserId;
                DataTable dtData = _blObj.BL_ExecuteTask(_plObj);
                if (dtData.Rows.Count > 0)
                {
                    if (dtData.Rows[0]["Result"].ToString() == "Y")
                    {
                        BindRecycleView();
                        txtChildBarcode.Text = "";
                        if (_TotalQty == _ScanQty)
                        {
                            clsGLB.showToastNGMessage($"Master Kanban Fraction Completed!!", this);
                            clear();
                            return;
                        }
                    }
                    else
                    {
                        clsGLB.showToastNGMessage($"{dtData.Rows[0]["Result"].ToString()}", this);
                        txtChildBarcode.Text = "";
                        SoundForNG();
                        ShowAlertPopUp();
                        return;
                    }
                }


            }
            catch (Exception ex) { throw ex; }
        }
        private void BindRecycleView()
        {
            try
            {

                _ListItem.Clear();
                _dicBarcode1.Clear();
                _dicBarcode2.Clear();
                
                _plObj = new PL_FRACTION();
                _plObj.DbType = "SELECT";
                _plObj.MasterKanban = txtMasterBarcode.Text.Trim();
                DataTable dtData = _blObj.BL_ExecuteTask(_plObj);
                if (dtData.Rows.Count > 0)
                {
                    if (Convert.ToInt32(dtData.Rows[0]["Qty"].ToString()) == Convert.ToInt32(dtData.Rows[0]["ScanQty"].ToString()))
                    {
                        clsGLB.showToastNGMessage($"Master Kanban Fraction Completed!!", this);
                        clear();
                        return;
                    }
                    _ListItem = new List<ViewFraction>();
                    ViewFraction pl = new ViewFraction();
                    pl.PartNo = dtData.Rows[0]["PartNo"].ToString();
                    pl.Qty = Convert.ToInt32(dtData.Rows[0]["Qty"].ToString());
                    pl.ScanQty = Convert.ToInt32(dtData.Rows[0]["ScanQty"].ToString());
                    pl.Balance = Convert.ToInt32(dtData.Rows[0]["Qty"].ToString()) - Convert.ToInt32(dtData.Rows[0]["ScanQty"].ToString());
                    _ListItem.Add(pl);
                }
                else
                {
                    try
                    {
                        string strPartNo = "";
                        int iQty = 0;
                        ExtractPartNoAndQty(txtMasterBarcode.Text.Trim(), ref strPartNo, ref iQty);
                        if (strPartNo != "" && iQty > 0)
                        {
                            _ListItem = new List<ViewFraction>();
                            ViewFraction pl = new ViewFraction();
                            pl.PartNo = strPartNo;
                            pl.Qty = iQty;
                            pl.ScanQty = 0;
                            pl.Balance = iQty;
                            _ListItem.Add(pl);
                        }
                    }
                    catch
                    {
                        clsGLB.showToastNGMessage($"Invalid DNHA Master Kanban Barcode.", this);

                        SoundForNG();
                        ShowAlertPopUp();
                        return;
                    }


                }


                GetSetTotalAndScanQty();


                receivingItemAdapter = new FractionItemAdapter(this, _ListItem);
                recyclerViewItem.SetAdapter(receivingItemAdapter);
                receivingItemAdapter.NotifyDataSetChanged();
                txtChildBarcode.RequestFocus();

            }
            catch (Exception ex) { throw ex; }
        }
        public void ExtractPartNoAndQty(string barcode, ref string partNo, ref int qty)
        {


            // Regular expression to match PartNo and Qty
            //PartNo = txtDNHASUPKanbanBarcode.Text.Substring(91, 15).Trim();
            //Qty = txtDNHASUPKanbanBarcode.Text.Substring(106, 7).Trim();
            partNo = barcode.Substring(91, 15).Trim(); // Extract PartNo at position 89 with length 16
            qty = int.Parse(barcode.Substring(106, 7).Trim());    // Extract Qty at position 105 with length 7

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

        private void txtMasterBarcode_KeyPress(object sender, View.KeyEventArgs e)
        {
            try
            {
                if (e.Event.Action == KeyEventActions.Down)
                {
                    if (e.KeyCode == Keycode.Enter)
                    {
                        if (txtMasterBarcode.Text.Trim() == "")
                        {
                            return;
                        }
                        if (string.IsNullOrEmpty(txtMasterBarcode.Text.Trim()))
                        {
                            clsGLB.showToastNGMessage($"Scan DNHA Kanban Barcode.", this);
                            txtMasterBarcode.Text = "";
                            txtMasterBarcode.RequestFocus();
                            SoundForNG();
                            ShowAlertPopUp();
                            return;
                        }
                        else if (txtMasterBarcode.Text.Length < 25)
                        {
                            clsGLB.showToastNGMessage($"Invalid DNHA Kanban Barcode.", this);
                            txtMasterBarcode.Text = "";
                            txtMasterBarcode.RequestFocus();
                            SoundForNG();
                            ShowAlertPopUp();
                            return;
                        }
                        BindRecycleView();
                        

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
        private void TxtChildBarcode_KeyPress(object sender, View.KeyEventArgs e)
        {
            try
            {
                if (e.Event.Action == KeyEventActions.Down)
                {
                    if (e.KeyCode == Keycode.Enter)
                    {
                        if (txtChildBarcode.Text.Trim() == "")
                        {
                            return;
                        }
                        if (string.IsNullOrEmpty(txtMasterBarcode.Text.Trim()))
                        {
                            clsGLB.showToastNGMessage($"Scan DNHA Master Kanban Barcode.", this);
                            txtMasterBarcode.Text = "";
                            txtMasterBarcode.RequestFocus();
                            SoundForNG();
                            ShowAlertPopUp();
                            return;
                        }
                        else if (txtMasterBarcode.Text.Length < 25)
                        {
                            clsGLB.showToastNGMessage($"Invalid DNHA Master Kanban Barcode.", this);
                            txtMasterBarcode.Text = "";
                            txtMasterBarcode.RequestFocus();
                            SoundForNG();
                            ShowAlertPopUp();
                            return;
                        }
                        else if (string.IsNullOrEmpty(txtChildBarcode.Text.Trim()))
                        {
                            clsGLB.showToastNGMessage($"Scan DNHA Child Kanban Barcode.", this);
                            txtChildBarcode.Text = "";
                            txtChildBarcode.RequestFocus();
                            SoundForNG();
                            ShowAlertPopUp();
                            return;
                        }
                        else if (txtChildBarcode.Text.Length < 25)
                        {
                            clsGLB.showToastNGMessage($"Invalid DNHA Child Kanban Barcode.", this);
                            txtChildBarcode.Text = "";
                            txtChildBarcode.RequestFocus();
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
                        SaveFraction();

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

            txtMasterBarcode.Text = txtChildBarcode.Text = "";


            if (_ListItem.Count > 0)
                _ListItem.Clear();

            for (int i = 0; i < _ListItem.Count; i++)
            {
                _ListItem[i].ScanQty = 0;
                _ListItem[i].Balance = _ListItem[i].Qty;
            }
            if (receivingItemAdapter != null)
            {
                receivingItemAdapter.NotifyDataSetChanged();
            }

            txtTotalQty.Text = "Total Qty : " + _TotalQty.ToString();
            txtScanQty.Text = "Total SQty : " + _ScanQty.ToString();
            txtMasterBarcode.RequestFocus();


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