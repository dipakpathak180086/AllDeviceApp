using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.Media;
using Android.OS;
using Android.Support.V7.App;
using Android.Support.V7.Widget;
using Android.Util;
using Android.Views;
using Android.Widget;
using Com.Rscja.Deviceapi;
using IOCLAndroidApp;
using IOCLAndroidApp.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SatoScanningApp
{
    [Activity(Label = "Sato ScanningApp", WindowSoftInputMode = SoftInput.StateHidden, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation, ScreenOrientation = ScreenOrientation.Portrait)]
    public class ReceivingActivity : AppCompatActivity
    {
        SoundPool soundPool;
        int soundPoolId;
        public RFIDWithUHF uhfAPI;
        UIHand handler;
        Dictionary<string, string> _tagID = new Dictionary<string, string>();
        bool loopFlag = false;
        List<ItemView> _ListItem = new List<ItemView>();
        string mode = "";
        clsGlobal clsGLB;
        clsNetwork oNetwork;
        MediaPlayer mediaPlayerSound;
        Vibrator vibrator;
        Spinner cmbDocNo;
        EditText editAssetBarcode;

        TextView txtTotalQty, txtMsg, txtScanQty, txtToPlant;
        int _TotalQty = 0, _ScanQty = 0;
        RecyclerView recyclerViewItem;
        ItemAdapter itemAdapter;
        RecyclerView.LayoutManager mLayoutManager;
        Button btnComplete, btnReset, btnSave, btnStart;
        List<string> _lst = new List<string>();

        public ReceivingActivity()
        {
            try
            {
                clsGLB = new clsGlobal();
                oNetwork = new clsNetwork();
            }
            catch (Exception ex)
            {
                Toast.MakeText(this, ex.Message, ToastLength.Long).Show();
            }
        }

        #region Activity Events

        protected override void OnResume()
        {
            base.OnResume();
            //Log.Info("re2", uhfAPI.ToString());
            if (uhfAPI != null)
            {

                new InitTask(this).Execute();
            }
        }
        protected override void OnPause()
        {
            stopReading();
            base.OnPause();
        }

        protected override void OnDestroy()
        {
            stopReading();
            base.OnDestroy();
            uhfAPI.Free();
        }
        //public override bool OnKeyDown(Keycode keyCode, KeyEvent e)
        //{

        //    if (e.KeyCode.GetHashCode() == 139 || e.KeyCode.GetHashCode() == 280 || e.KeyCode.GetHashCode() == 293)
        //    {
        //        if (e.RepeatCount == 0)
        //        {

        //            //if (actionBar.SelectedTab.Tag.ToString() == "Scan") {
        //            this.scan();

        //            return true;
        //            //}

        //        }
        //    }
        //    return base.OnKeyDown(keyCode, e);


        //}
        public void scan()
        {


            string strUII = this.uhfAPI.InventorySingleTag();
            if (!string.IsNullOrEmpty(strUII))
            {
                String strEPC = this.uhfAPI.ConvertUiiToEPC(strUII);
                if (!_tagID.ContainsKey(strEPC))
                {
                    _tagID.Add(strEPC, strEPC);

                    Message msg = handler.ObtainMessage();


                    msg.Obj = strEPC;
                    handler.SendMessage(msg);
                }

                //AddEPCToList(strEPC, "N/A");
            }
            else
            {
                Toast.MakeText(this, "failuer", ToastLength.Short);
            }


        }
        private void ContinuousRead()
        {
            Thread th = new Thread(new ThreadStart(delegate
            {
                while (loopFlag)
                {
                    string strUII = this.uhfAPI.InventorySingleTag();
                    if (string.IsNullOrEmpty(strUII))
                    {
                        continue;
                    }
                    //if (!savingFlag)
                    //{
                    //    savingFlag = true;
                    this.RunOnUiThread(() =>
                    {

                        string epc = this.uhfAPI.ConvertUiiToEPC(strUII).ToString();
                        if (epc.Length > 12)
                        {
                            editAssetBarcode.Text = epc.Substring(0, 12);

                            //stopReading();
                        }
                        else
                        {
                            editAssetBarcode.Text = epc;

                            //stopReading();
                        }

                        if (!string.IsNullOrEmpty(strUII))
                        {

                            String strEPC = this.uhfAPI.ConvertUiiToEPC(strUII);
                            Message msg = handler.ObtainMessage();


                            if (strEPC.Length > 12)
                                msg.Obj = strEPC.Substring(0, 12);
                            else
                                msg.Obj = strEPC;
                            handler.SendMessage(msg);
                           // Thread.Sleep(500);
                        }

                    });
                }
            }));
            th.Start();
        }
        private void AddEPCToList(String epc, String rssi)
        {
            if (!string.IsNullOrEmpty(epc))
            {
                editAssetBarcode.Text = epc;
                Save();
                // if (!_tagID.ContainsKey(epc))
                // {
                //    // _tagID.Add(epc, epc);
                //     //foreach (var item in _tagID)
                //     //{

                //     //Sound();
                //     // editBinBarcode_KeyPress(null, null);
                //    // Save();
                //     //}
                //     //ItemView pickingItem = new ItemView();
                //     //pickingItem.Asset = epc;
                //     //pickingItem.Qty = 1;
                //     //pickingItem.ScanQty = 1;

                //     //_ListItem.Add(pickingItem);
                //     //itemAdapter.NotifyDataSetChanged();
                //     //_TotalQty = _tagID.Count;
                //     //txtTotalQty.Text = "Total Qty :" + _TotalQty;
                //}
            }
        }
        private void StopInventory()
        {
            if (loopFlag)
            {

                uhfAPI.StopInventory();
                loopFlag = false;
            }


        }
        private class UIHand : Handler
        {
            ReceivingActivity scanFragment;
            public UIHand(ReceivingActivity _scanFragment)
            {
                scanFragment = _scanFragment;
            }
            public override void HandleMessage(Message msg)
            {
                try
                {
                    string result = msg.Obj.ToString();

                    scanFragment.AddEPCToList(result, result);
                }
                catch (Exception)
                {

                }

            }
        }
        private void stopReading()
        {
            _tagID.Clear();
            btnStart.Text = "Start";
            loopFlag = false;
            StopInventory();
        }
        private class InitTask : AsyncTask<Java.Lang.Void, Java.Lang.Void, string[]>
        {

            ReceivingActivity mainActivity;
            ProgressDialog proDialg = null;

            public InitTask(ReceivingActivity _mainActivity)
            {
                mainActivity = _mainActivity;
            }
            protected override string[] RunInBackground(params Java.Lang.Void[] @params)
            {
                //throw new NotImplementedException ();
                return null;
            }

            //后台要执行的任务
            protected override Java.Lang.Object DoInBackground(params Java.Lang.Object[] @params)
            {
                string result = "No";
                if (mainActivity.uhfAPI != null)
                {
                    for (int i = 1; i <= 3; i++)
                    {
                        if (i != 3)
                        {
                            if (!mainActivity.uhfAPI.Init())
                                mainActivity.uhfAPI.Free();
                            else
                                return "OK";

                        }
                        else
                        {
                            if (mainActivity.uhfAPI.Init())
                            {
                                result = "OK";
                            }
                        }


                    }

                }
                return result;
            }
            public void SetPower()
            {
                int iPower = clsGlobal.mTagPower;

                if (mainActivity.uhfAPI.SetPower(iPower))
                {
                    Toast.MakeText(mainActivity, $"Tag power set {iPower} success!", ToastLength.Short).Show();
                }
                else
                {
                    Toast.MakeText(mainActivity, "failuer!", ToastLength.Short).Show();
                }

            }
            protected override void OnPostExecute(Java.Lang.Object result)
            {
                proDialg.Cancel();
                SetPower(); 
                Log.Debug("结果", result.ToString());
                if (result.ToString() != "OK")
                    Toast.MakeText(mainActivity, "Init failure!", ToastLength.Short);
            }

            //开始执行任务
            protected override void OnPreExecute()
            {
                proDialg = new ProgressDialog(mainActivity);
                proDialg.SetMessage("init.....");
                proDialg.Show();
            }
        }
        private void Sound()
        {

            soundPool.Play(soundPoolId, 1, 1, 0, 0, 1);


        }
        protected override void OnCreate(Bundle savedInstanceState)
        {

            try
            {
                base.OnCreate(savedInstanceState);
                // Set our view from the "main" layout resource
                SetContentView(Resource.Layout.activity_Receiving);
                if (uhfAPI == null)
                {
                    try
                    {
                        uhfAPI = RFIDWithUHF.Instance;

                        uhfAPI.StopInventory();

                    }
                    catch
                    {

                    }
                }

                cmbDocNo = FindViewById<Spinner>(Resource.Id.spinnerDocNo);
                cmbDocNo.ItemSelected += CmbDocNo_ItemSelected;


                
                TextView txtHeader = FindViewById<TextView>(Resource.Id.txtHeader);


                txtHeader.Text = "RECEIVING";

                txtMsg = FindViewById<TextView>(Resource.Id.txtMsg);
                txtMsg.Text = "";

                txtToPlant = FindViewById<TextView>(Resource.Id.txtPlant);

                txtTotalQty = FindViewById<TextView>(Resource.Id.txtTotalQty);
                txtTotalQty.Text = "Total Qty : " + _TotalQty.ToString();
                txtScanQty = FindViewById<TextView>(Resource.Id.txtScanQty);
                txtScanQty.Text = "Scan Qty : " + _ScanQty.ToString();
                

                editAssetBarcode = FindViewById<EditText>(Resource.Id.editBarcode);
                editAssetBarcode.KeyPress += editBinBarcode_KeyPress;

                btnStart = FindViewById<Button>(Resource.Id.btnStart);
                btnStart.Click += BtnStart_Click;

                btnSave = FindViewById<Button>(Resource.Id.btnSave);
                btnSave.Click += BtnSave_Click;

              


                btnReset = FindViewById<Button>(Resource.Id.btnReset);
                btnReset.Click += BtnReset_Click;



                vibrator = this.GetSystemService(VibratorService) as Vibrator;
                // txtMsg.Text = "Click start button to start scanning";
                cmbDocNo.RequestFocus();
                btnComplete = FindViewById<Button>(Resource.Id.btnComplete);
                btnComplete.Click += BtnComplete_Click;
                ImageView imgBack = FindViewById<ImageView>(Resource.Id.imgBack);
                imgBack.Click += (e, a) =>
                {
                    txtMsg.Text = "";
                    ShowConfirmBox("Are you sure ? you have saved the all data!!!", this, CloseScreen);
                };
                recyclerViewItem = FindViewById<RecyclerView>(Resource.Id.recycleViewPickingItem);
                mLayoutManager = new LinearLayoutManager(this);
                recyclerViewItem.SetLayoutManager(mLayoutManager);

                BindRecycleView();

                GetDocNumber();

                soundPool = new SoundPool(10, Stream.Music, 0);
                soundPoolId = soundPool.Load(this, Resource.Drawable.beep, 1);
                handler = new UIHand(this);

            }
            catch (Exception ex)
            {
                clsGLB.ShowMessage(ex.Message, this, MessageTitle.ERROR);
            }
        }

        private void BtnStart_Click(object sender, EventArgs e)
        {
            try
            {
                if (btnStart.Text == "Start")
                {
                    btnStart.Text = "Stop";
                    if (uhfAPI == null)
                    {
                        try
                        {
                            uhfAPI = RFIDWithUHF.Instance;
                            uhfAPI.StopInventory();
                        }
                        catch
                        {

                        }
                    }
                    loopFlag = true;
                    //scan();
                    ContinuousRead();
                }
                else
                {
                    btnStart.Text = "Start";
                    loopFlag = false;
                    StopInventory();
                }

            }
            catch (Exception ex)
            {
                clsGLB.ShowMessage(ex.Message, this, MessageTitle.ERROR);
            }
        }

        private void BtnClear_Click(object sender, EventArgs e)
        {
            Clear();
        }

        private void BtnBack_Click(object sender, EventArgs e)
        {
            stopReading();
            oNetwork.TcpClosed();
            this.Finish();
        }

        private void BtnComplete_Click(object sender, EventArgs e)
        {
            try
            {

                txtMsg.Text = "";
                ShowConfirmBox("Are you sure you want to Complete?", this, CompleteData);

            }
            catch (Exception ex)
            {
                clsGLB.ShowMessage(ex.Message, this, MessageTitle.ERROR);
            }
        }
        private void BtnSave_Click(object sender, EventArgs e)
        {
            try
            {
                txtMsg.Text = "";
                ShowConfirmBox("Are you sure you want to Save?", this, SaveData);

            }
            catch (Exception ex)
            {
                clsGLB.ShowMessage(ex.Message, this, MessageTitle.ERROR);
            }


        }

        #endregion

        #region Button Events



        private void BtnReset_Click(object sender, EventArgs e)
        {
            try
            {
                txtMsg.Text = "";
                txtToPlant.Text = "XXXX";
                if (cmbDocNo.SelectedItemPosition > 0)
                {
                    cmbDocNo.SetSelection(0);
                }
                // btnStart.Text = "Start";
                editAssetBarcode.Text = "";
                txtTotalQty.Text = "Total Qty : 0";
                txtScanQty.Text = "Scan Qty : 0";
                _TotalQty = 0;
                _ScanQty = 0;
                editAssetBarcode.Enabled = false;
                _ListItem.Clear();
                itemAdapter.NotifyDataSetChanged();
                cmbDocNo.RequestFocus();
                if (btnStart.Text == "Stop")
                {
                    StopInventory();
                    btnStart.Text = "Start";
                }
            }
            catch (Exception ex)
            {
                clsGLB.ShowMessage(ex.Message, this, MessageTitle.ERROR);
            }
        }

        #endregion

        #region EditText Events

        private void editBinBarcode_KeyPress(object sender, View.KeyEventArgs e)
        {
            try
            {
                if (e.Event.Action == KeyEventActions.Down)
                {
                    if (e.KeyCode == Keycode.Enter)
                    {

                        Save();

                    }
                    else
                        e.Handled = false;
                }
            }
            catch (Exception ex)
            {
                StartPlayingSound();
                ShowMessageBox("Error : " + ex.Message, this);
            }
        }
        public override void OnBackPressed()
        {
        }

        #endregion

        #region Methods
        public void GetDocNumber()
        {
            try
            {
                string _MESSAGE = "RECEIVING~BIND_DOC~" + clsGlobal.mPlant + "~" + "~" + "~" + "~" + "~" + "~" + "}";
                string[] _RESPONSE = oNetwork.GetSetTcpNewApp(_MESSAGE).Split('~');

                switch (_RESPONSE[0])
                {
                    case "VALID":
                        _lst.Clear();
                        _lst.Add("--Select--");
                        string[] sArr = _RESPONSE[1].Split('#');
                        for (int i = 0; i < sArr.Length; i++)
                        {
                            _lst.Add(sArr[i]);
                        }
                        ArrayAdapter<string> arrayAdapter = new ArrayAdapter<string>(this, Resource.Layout.Spiner, _lst);
                        cmbDocNo.Adapter = arrayAdapter;
                        cmbDocNo.SetSelection(0);

                        break;
                    case "INVALID":
                        editAssetBarcode.Text = "";
                        StartPlayingSound();
                        ShowMessageBox("No Doc found", this);
                        break;

                    case "ERROR":
                        StartPlayingSound();
                        ShowMessageBox(_RESPONSE[1], this);
                        break;

                    case "NO_CONNECTION":
                        StartPlayingSound();
                        ShowMessageBox("Communication server not connected", this);
                        break;

                    default:
                        StartPlayingSound();
                        ShowMessageBox("No option match from comm server", this);
                        break;
                }
            }
            catch (Exception ex)
            {
                StartPlayingSound();
                ShowMessageBox(ex.Message, this);
            }
        }
        public void GetToPlant()
        {
            try
            {
                string _MESSAGE = "RECEIVING~BIND_TO_PLANT~" + clsGlobal.mPlant + "~" + "~" + cmbDocNo.SelectedItem.ToString() + "~" + "~" + "~" + "~" + "}";
                string[] _RESPONSE = oNetwork.GetSetTcpNewApp(_MESSAGE).Split('~');

                switch (_RESPONSE[0])
                {
                    case "VALID":

                        string[] sArr = _RESPONSE[1].Split('#');
                        for (int i = 0; i < sArr.Length; i++)
                        {
                            txtToPlant.Text = sArr[i].ToString();
                        }


                        break;
                    case "INVALID":
                        editAssetBarcode.Text = "";
                        StartPlayingSound();
                        ShowMessageBox("No Doc found", this);
                        break;

                    case "ERROR":
                        StartPlayingSound();
                        ShowMessageBox(_RESPONSE[1], this);
                        break;

                    case "NO_CONNECTION":
                        StartPlayingSound();
                        ShowMessageBox("Communication server not connected", this);
                        break;

                    default:
                        StartPlayingSound();
                        ShowMessageBox("No option match from comm server", this);
                        break;
                }
            }
            catch (Exception ex)
            {
                StartPlayingSound();
                ShowMessageBox(ex.Message, this);
            }
        }

        private void BindRecycleView()
        {
            try
            {
                itemAdapter = new ItemAdapter(_ListItem, this);
                recyclerViewItem.SetAdapter(itemAdapter);

            }
            catch (Exception ex) { throw ex; }
        }

        private void CmbDocNo_ItemSelected(object sender, AdapterView.ItemSelectedEventArgs e)
        {
            try
            {
                if (cmbDocNo.SelectedItemPosition > 0)
                {
                    GetDocDetails(cmbDocNo.SelectedItem.ToString());
                    editAssetBarcode.Text = string.Empty;
                    editAssetBarcode.Enabled = true;
                    editAssetBarcode.RequestFocus();
                }
            }
            catch (Exception ex)
            {
                StartPlayingSound();
                ShowMessageBox(ex.Message, this);
            }
        }

        public void ShowConfirmBox(string msg, Activity activity, EventHandler<DialogClickEventArgs> handler)
        {
            Android.App.AlertDialog.Builder builder = new Android.App.AlertDialog.Builder(activity);
            builder.SetTitle("Message");
            builder.SetMessage(msg);
            builder.SetCancelable(false);
            builder.SetPositiveButton("Yes", handler);
            builder.SetNegativeButton("No", handllerCancelButton);
            builder.Show();
        }
        void handllerCancelButton(object sender, DialogClickEventArgs e)
        {
            try
            {

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
                vibrator.Cancel();
                StopPlayingSound();
            }
            catch (Exception ex)
            {
                clsGLB.ShowMessage(ex.Message, this, MessageTitle.ERROR);
            }
        }
        private void GetDocDetails(string sRequestNo)
        {
            try
            {
                string sRequest = string.Empty;
                sRequest = oNetwork.GetSetTcpNewApp("RECEIVING~BIND_VIEW~" + clsGlobal.mPlant + "~" + "~" + sRequestNo + "~" + "~" + "~" + "~" + "~" + "}");
                string[] sResponse = sRequest.Split('~');
                switch (sResponse[0])
                {
                    case "VALID":
                        if (sResponse[1] != "")
                        {
                            BindListviewDtl(sResponse[1].ToString());
                            GetToPlant();
                        }
                        itemAdapter.NotifyDataSetChanged();
                        txtTotalQty.Text = "Total Qty :" + _TotalQty;
                        txtScanQty.Text = "Scan Qty : " + _ScanQty;
                        editAssetBarcode.RequestFocus();
                        editAssetBarcode.Text = string.Empty;
                        editAssetBarcode.Enabled = true;
                        break;
                    case "INVALID":
                        StartPlayingSound();
                        ShowMessageBox("No Pending Picklist Items Found!", this);
                        cmbDocNo.RequestFocus();
                        break;
                    case "ERROR":
                        StartPlayingSound();
                        ShowMessageBox(sResponse[1], this);
                        cmbDocNo.RequestFocus();
                        break;
                    case "NO_CONNECTION":
                        StartPlayingSound();
                        ShowMessageBox("Server is unavailable", this);
                        cmbDocNo.RequestFocus();
                        break;
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {

            }
        }
        private void BindListviewDtl(string strReqNo)
        {
            _ScanQty = 0;
            _TotalQty = 0;
            _ListItem.Clear();
            string[] arrRow = strReqNo.Split('#');
            foreach (string strRow in arrRow)
            {
                string[] arrCell = strRow.Split('$');
                ItemView pickingItem = new ItemView();
                pickingItem.Asset = arrCell[0];
                pickingItem.RFIDTag = arrCell[1];
                pickingItem.Qty = Convert.ToInt32(Convert.ToDecimal(arrCell[2]));
                pickingItem.ScanQty = Convert.ToInt32(Convert.ToDecimal(arrCell[3]));
                if (arrCell[1].ToString() == arrCell[4].ToString())
                {
                    pickingItem.ScannedRFIDTag = arrCell[4].ToString();
                }
                else
                {
                    pickingItem.ScannedRFIDTag = "";
                }
                //pickingItem.Qty = Convert.ToInt32(Convert.ToDecimal(arrCell[1]));
                //pickingItem.ScanQty = Convert.ToInt32(Convert.ToDecimal(arrCell[2]));

                _ListItem.Add(pickingItem);
                _TotalQty += Convert.ToInt32(Convert.ToDecimal(arrCell[2]));
                _ScanQty += Convert.ToInt32(Convert.ToDecimal(arrCell[3]));
            }
        }
        async Task<string> ScanDispatchDataAsync()
        {
            var progressDialog = ProgressDialog.Show(this, "", "Please wait...", true);
            try
            {
                txtMsg.Text = "";
                string[] _RESPONSE = await Task.Run(() => ScanDispatchDataToServer());

                progressDialog.Hide();

                switch (_RESPONSE[0])
                {
                    case "VALID":
                        if (!_RESPONSE[1].Equals("Y"))
                        {
                            //StartPlayingSound();
                            txtMsg.Text = _RESPONSE[1];
                            // ShowMessageBox(_RESPONSE[1], this);
                            editAssetBarcode.Text = "";
                            editAssetBarcode.Enabled = true;
                            editAssetBarcode.RequestFocus();
                        }
                        else
                        {
                            Sound();
                            GetDocDetails(cmbDocNo.SelectedItem.ToString());
                            if (_TotalQty == _ScanQty)
                            {
                                editAssetBarcode.Enabled = true;
                                editAssetBarcode.Text = "";
                                editAssetBarcode.RequestFocus();
                                ShowMessageBox("Doc Successfully Completed", this); ;
                                BtnReset_Click(null, null);

                            }
                            else
                            {
                                txtMsg.Text = $"Tag {editAssetBarcode.Text.Trim()} Successfully Scanned";
                                editAssetBarcode.Enabled = true;
                                editAssetBarcode.Text = "";
                                editAssetBarcode.RequestFocus();

                            }
                        }
                        break;

                    case "INVALID":
                        StartPlayingSound();
                        ShowMessageBox(_RESPONSE[1], this);
                        stopReading();
                        break;

                    case "ERROR":
                        StartPlayingSound();
                        ShowMessageBox(_RESPONSE[1], this);
                        break;

                    case "NO_CONNECTION":
                        StartPlayingSound();
                        ShowMessageBox("Communication server not connected", this);
                        stopReading();
                        break;

                    default:
                        StartPlayingSound();
                        ShowMessageBox("No option match from comm server", this);
                        stopReading();
                        break;
                }
            }
            catch (Exception ex)
            {
                clsGLB.ShowMessage(ex.Message, this, MessageTitle.ERROR);
                progressDialog.Hide();
            }
            finally
            {
                progressDialog.Hide();
            }
            return "";
        }
        async Task<string> CompleteDispatchDataAsync()
        {
            var progressDialog = ProgressDialog.Show(this, "", "Please wait...", true);
            try
            {
                txtMsg.Text = "";
                string[] _RESPONSE = await Task.Run(() => CompleteDispatchDataToServer());

                progressDialog.Hide();

                switch (_RESPONSE[0])
                {
                    case "VALID":
                        if (!_RESPONSE[1].Equals("Y"))
                        {
                            StartPlayingSound();
                            ShowMessageBox(_RESPONSE[1], this);
                            editAssetBarcode.Text = "";
                            editAssetBarcode.Enabled = true;
                            editAssetBarcode.RequestFocus();
                        }
                        else
                        {

                            editAssetBarcode.Enabled = true;
                            editAssetBarcode.Text = "";
                            editAssetBarcode.RequestFocus();
                            ShowMessageBox("Doc Successfully Completed", this); ;
                            BtnReset_Click(null, null);
                        }
                        break;

                    case "INVALID":
                        StartPlayingSound();
                        ShowMessageBox(_RESPONSE[1], this);
                        break;

                    case "ERROR":
                        StartPlayingSound();
                        ShowMessageBox(_RESPONSE[1], this);
                        break;

                    case "NO_CONNECTION":
                        StartPlayingSound();
                        ShowMessageBox("Communication server not connected", this);
                        break;

                    default:
                        StartPlayingSound();
                        ShowMessageBox("No option match from comm server", this);
                        break;
                }
            }
            catch (Exception ex)
            {
                clsGLB.ShowMessage(ex.Message, this, MessageTitle.ERROR);
                progressDialog.Hide();
            }
            finally
            {
                progressDialog.Hide();
            }
            return "";
        }



        private string[] CompleteDispatchDataToServer()
        {
            try
            {
                string _MESSAGE = "RECEIVING~COMPLETE~" + clsGlobal.mPlant + "~" + txtToPlant.Text.Trim() + "~" + cmbDocNo.SelectedItem.ToString().Trim() + "~" + editAssetBarcode.Text.Trim() + "~" + clsGlobal.UserId + "}";
                string[] _RESPONSE = oNetwork.GetSetTcpNewApp(_MESSAGE).Split('~');
                return _RESPONSE;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        private string[] ScanDispatchDataToServer()
        {
            try
            {
                string[] _RESPONSE = null;
                for (int i = 0; i < _ListItem.Count; i++)
                {
                    if (_ListItem[i].ScannedRFIDTag.ToString().Trim() == "")
                    {
                        continue;
                    }
                    string _MESSAGE = "RECEIVING~SAVE~" + clsGlobal.mPlant + "~" + txtToPlant.Text + "~" + cmbDocNo.SelectedItem.ToString().Trim() + "~" + _ListItem[i].ScannedRFIDTag.ToString().Trim() + "~" + clsGlobal.UserId + "}";
                    _RESPONSE = oNetwork.GetSetTcpNewApp(_MESSAGE).Split('~');
                }
                return _RESPONSE;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        private string[] GetScanCountToServer()
        {
            try
            {
                string _MESSAGE = "GET_SCAN_COUNT~" + clsGlobal.ProcessType + "~" + cmbDocNo.SelectedItem.ToString().Trim() + "~" + "~" + "~" + "~" + "~" + "}";
                string[] _RESPONSE = oNetwork.GetSetTcpNewApp(_MESSAGE).Split('~');
                return _RESPONSE;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        private void Save()
        {
            mode = "";

            txtMsg.Text = "";
            if (cmbDocNo.SelectedItemPosition < 0)
            {
                txtMsg.Text = "Select Document No.";
                cmbDocNo.RequestFocus();
                return;
            }
            if (_TotalQty == _ScanQty)
            {
                txtMsg.Text = "Doc Scanning Completed Need to Save the Data!!!";
                editAssetBarcode.Text = "";
                return;
            }
            bool iMatched = false;
            for (int i = 0; i < _ListItem.Count; i++)
            {
                if (_ListItem[i].RFIDTag == editAssetBarcode.Text.Trim())
                {
                    iMatched = true;
                    var _nList = _ListItem.FindAll(x => x.ScannedRFIDTag == editAssetBarcode.Text.Trim());
                    if (_nList.Count == 0)
                    {
                        _ScanQty = _ScanQty + 1;
                        _ListItem[i].ScannedRFIDTag = editAssetBarcode.Text.Trim();
                    }
                    break;
                }
            }
            txtTotalQty.Text = "Total Qty :" + _TotalQty;
            txtScanQty.Text = "Scan Qty : " + _ScanQty;

            itemAdapter.NotifyDataSetChanged();
            if (!iMatched)
            {
                txtMsg.Text = "Invalid Asset Tag!!!";

                return;
            }
            //ScanDispatchDataAsync();
        }
        private void CompleteData(object sender, DialogClickEventArgs e)
        {
            CompleteDispatchDataAsync();
        }
        private void SaveData(object sender, DialogClickEventArgs e)
        {
            ScanDispatchDataAsync();
        }
        private void CloseScreen(object sender, DialogClickEventArgs e)
        {
            stopReading();
            oNetwork.TcpClosed();
            this.Finish();
        }
        //End


        public void ShowMessageBox(string msg, Activity activity)
        {
            Android.App.AlertDialog.Builder builder = new Android.App.AlertDialog.Builder(activity);
            builder.SetTitle("Message");
            builder.SetMessage(msg);
            builder.SetCancelable(false);
            builder.SetPositiveButton("Ok", handleOkMessage);
            builder.Show();
        }


        private void StartPlayingSound()
        {
            try
            {
                //Start Vibration
                long[] pattern = { 0, 200, 0 }; //0 to start now, 200 to vibrate 200 ms, 0 to sleep for 0 ms.
                vibrator.Vibrate(pattern, 0);//

                StopPlayingSound();
                mediaPlayerSound = MediaPlayer.Create(this, Resource.Raw.Beep);
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
                }
            }
            catch (Exception ex) { throw ex; }
        }

        private void Clear()
        {
            try
            {
                editAssetBarcode.Text = string.Empty;
                editAssetBarcode.Enabled = true;
                editAssetBarcode.RequestFocus();
            }
            catch (Exception ex)
            {
                clsGLB.ShowMessage(ex.Message, this, MessageTitle.ERROR);
            }
        }

    }
    #endregion

}
