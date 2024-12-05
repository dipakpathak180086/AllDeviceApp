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
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace SatoScanningApp
{
    [Activity(Label = "Sato ScanningApp", WindowSoftInputMode = SoftInput.StateHidden, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation, ScreenOrientation = ScreenOrientation.Portrait)]
    public class TagMappingActivity : AppCompatActivity
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
        Spinner cmbFloor, cmbSection, cmbLocation, cmbAssetCode;
        EditText editAssetBarcode;

        TextView txtMsg;

        Button btnSave, btnReset, btnBack, btnStart, btnClear;
        List<string> _lst = new List<string>();
        bool savingFlag = false;
        public TagMappingActivity()
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
        #region UFH READING


        protected override void OnResume()
        {
            base.OnResume();

            // Log.Info("re2", uhfAPI.ToString());
            if (uhfAPI != null)
            {

                new InitTask(this).Execute();
            }
        }
        protected override void OnPause()
        {
            //stopReading();
            base.OnPause();
        }

        protected override void OnDestroy()
        {
            //stopReading();
            base.OnDestroy();
            uhfAPI.Free();
        }
        //public override bool OnKeyDown(Keycode keyCode, KeyEvent e)
        //{

        //    if (e.KeyCode.GetHashCode() == 139 || e.KeyCode.GetHashCode() == 280 || e.KeyCode.GetHashCode() == 293)
        //    {
        //        if (e.RepeatCount == 0)
        //        {
        //            lock (_lock)
        //            {
        //                //if (actionBar.SelectedTab.Tag.ToString() == "Scan") {
        //                this.SingleScan();
        //            }

        //            return true;
        //            //}

        //        }
        //    }
        //    return base.OnKeyDown(keyCode, e);


        //}
        public void SingleScan()
        {


            //string strUII = this.uhfAPI.InventorySingleTag();
            string strUII = this.uhfAPI.InventorySingleTag();
            if (!string.IsNullOrEmpty(strUII))
            {
                this.RunOnUiThread(() =>
                {


                    String strEPC = this.uhfAPI.ConvertUiiToEPC(strUII);
                    Message msg = handler.ObtainMessage();

                    if (strEPC.Length > 12)
                        msg.Obj = editAssetBarcode.Text = strEPC.Substring(0, 12);
                    else
                        msg.Obj = editAssetBarcode.Text = strEPC;
                    handler.SendMessage(msg);
                });
            }

            //AddEPCToList(strEPC, "N/A");

            else
            {
                //Toast.MakeText(this, "failuer", ToastLength.Short);
            }

        }

        object _lock = new object();
        private void ContinuousReadOld()
        {
            Thread th = new Thread(new ThreadStart(delegate
            {

                while (loopFlag)
                {

                    //if (!savingFlag)
                    //{
                    //    savingFlag = true;
                    string strUII = this.uhfAPI.InventorySingleTag();
                    if (string.IsNullOrEmpty(strUII))
                    {
                        continue;
                    }
                    string epc = this.uhfAPI.ConvertUiiToEPC(strUII).ToString();
                    if (epc.Length > 12)
                    {
                        editAssetBarcode.Text = epc.Substring(0, 12);
                        loopFlag = false;
                    }
                    else
                    {
                        editAssetBarcode.Text = epc;
                    }

                    if (!string.IsNullOrEmpty(strUII))
                    {

                        String strEPC = this.uhfAPI.ConvertUiiToEPC(strUII);
                        Message msg = handler.ObtainMessage();


                        if (strEPC.Length > 12)
                            msg.Obj = strEPC.Substring(0, 11);
                        else
                            msg.Obj = strEPC;
                        handler.SendMessage(msg);
                        //Thread.Sleep(500);
                    }

                    // }
                }
            }));
            th.Start();
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

                //if (!_tagID.ContainsKey(epc))
                //{
                //    _tagID.Add(epc, epc);
                //foreach (var item in _tagID)
                //{
                editAssetBarcode.Text = "";
                editAssetBarcode.Text = epc;
                //Sound();
                // editBinBarcode_KeyPress(null, null);
                //Save();
                //}
                //ItemView pickingItem = new ItemView();
                //pickingItem.Asset = epc;
                //pickingItem.Qty = 1;
                //pickingItem.ScanQty = 1;

                //_ListItem.Add(pickingItem);
                //itemAdapter.NotifyDataSetChanged();
                //_TotalQty = _tagID.Count;
                //txtTotalQty.Text = "Total Qty :" + _TotalQty;
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
            TagMappingActivity scanFragment;
            public UIHand(TagMappingActivity _scanFragment)
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

            loopFlag = false;
            StopInventory();
        }
        private class InitTask : AsyncTask<Java.Lang.Void, Java.Lang.Void, string[]>
        {

            TagMappingActivity mainActivity;
            ProgressDialog proDialg = null;

            public InitTask(TagMappingActivity _mainActivity)
            {
                mainActivity = _mainActivity;
            }
            protected override string[] RunInBackground(params Java.Lang.Void[] @params)
            {
                //throw new NotImplementedException ();
                return null;
            }
            public void SetPower()
            {
                int iPower = 1;

                if (mainActivity.uhfAPI.SetPower(iPower))
                {
                    Toast.MakeText(mainActivity, $"Tag power set {iPower} success!", ToastLength.Short).Show();
                }
                else
                {
                    Toast.MakeText(mainActivity, "failuer!", ToastLength.Short).Show();
                }

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
        #endregion

        #region Activity Events
        protected override void OnCreate(Bundle savedInstanceState)
        {

            try
            {
                base.OnCreate(savedInstanceState);
                // Set our view from the "main" layout resource
                SetContentView(Resource.Layout.layout_TagMapping);
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

                cmbFloor = FindViewById<Spinner>(Resource.Id.spinnerFloor);
                cmbFloor.ItemSelected += CmbFloor_ItemSelected;

                cmbSection = FindViewById<Spinner>(Resource.Id.spinnerSection);
                cmbSection.ItemSelected += CmbSection_ItemSelected; ;

                cmbLocation = FindViewById<Spinner>(Resource.Id.spinnerLocation);
                cmbLocation.ItemSelected += CmbLocation_ItemSelected; ;

                cmbAssetCode = FindViewById<Spinner>(Resource.Id.spinnerAsset);
                cmbAssetCode.ItemSelected += CmbAssetCode_ItemSelected; ;


                ImageView imgBack = FindViewById<ImageView>(Resource.Id.imgBack);
                imgBack.Click += (e, a) =>
                {
                    this.Finish();
                };
                TextView txtHeader = FindViewById<TextView>(Resource.Id.txtHeader);


                txtHeader.Text = "TAG MAPPING";

                txtMsg = FindViewById<TextView>(Resource.Id.txtMsg);
                txtMsg.Text = "";






                editAssetBarcode = FindViewById<EditText>(Resource.Id.editBarcode);
                editAssetBarcode.KeyPress += editBinBarcode_KeyPress;

                btnSave = FindViewById<Button>(Resource.Id.btnSave);
                btnSave.Click += BtnSave_Click;

                btnBack = FindViewById<Button>(Resource.Id.btnBack);
                btnBack.Click += BtnBack_Click;


                btnReset = FindViewById<Button>(Resource.Id.btnReset);
                btnReset.Click += BtnReset_Click;



                vibrator = this.GetSystemService(VibratorService) as Vibrator;
                // txtMsg.Text = "Click start button to start scanning";
                cmbFloor.RequestFocus();
                btnBack = FindViewById<Button>(Resource.Id.btnBack);
                btnBack.Click += (e, a) =>
                {
                    stopReading();
                    oNetwork.TcpClosed();
                    this.Finish();
                };


                GetFloor();
                soundPool = new SoundPool(10, Stream.Music, 0);
                soundPoolId = soundPool.Load(this, Resource.Drawable.beep, 1);
                handler = new UIHand(this);

            }
            catch (Exception ex)
            {
                clsGLB.ShowMessage(ex.Message, this, MessageTitle.ERROR);
            }
        }
        async Task<string> ReadTag()
        {
            var progressDialog = ProgressDialog.Show(this, "", "Please wait...", true);
            try
            {
                await Task.Run(() =>
                {
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
                    if (!uhfAPI.StopInventory())
                    {
                        loopFlag = true;
                        //SingleScan();
                        ContinuousRead();
                    }
                    txtMsg.Text = "";
                    cmbFloor.Enabled = false;
                    cmbSection.Enabled = false;
                    cmbLocation.Enabled = false;
                    cmbAssetCode.Enabled = false;
                    editAssetBarcode.Enabled = true;
                    editAssetBarcode.RequestFocus();

                });
            }
            catch (Exception ex)
            {

                clsGLB.ShowMessage(ex.Message, this, MessageTitle.ERROR);

            }
            finally
            {
                progressDialog.Hide();
            }
            return "";
        }
        private void CmbAssetCode_ItemSelected(object sender, AdapterView.ItemSelectedEventArgs e)
        {
            try
            {
                if (cmbAssetCode.SelectedItemPosition > 0)
                {


                    ReadTag();
                }
            }
            catch (Exception ex)
            {
                StartPlayingSound();
                ShowMessageBox(ex.Message, this);
            }
        }

        private void CmbLocation_ItemSelected(object sender, AdapterView.ItemSelectedEventArgs e)
        {
            try
            {
                if (cmbLocation.SelectedItemPosition > 0)
                {
                    GetAssetCode();

                }
            }
            catch (Exception ex)
            {
                StartPlayingSound();
                ShowMessageBox(ex.Message, this);
            }
        }

        private void CmbSection_ItemSelected(object sender, AdapterView.ItemSelectedEventArgs e)
        {
            try
            {
                if (cmbSection.SelectedItemPosition > 0)
                {
                    GetLocation();

                }
            }
            catch (Exception ex)
            {
                StartPlayingSound();
                ShowMessageBox(ex.Message, this);
            }
        }

        private void CmbFloor_ItemSelected(object sender, AdapterView.ItemSelectedEventArgs e)
        {
            try
            {
                if (cmbFloor.SelectedItemPosition > 0)
                {
                    GetSection();

                }
            }
            catch (Exception ex)
            {
                StartPlayingSound();
                ShowMessageBox(ex.Message, this);
            }
        }

        private void BtnClear_Click(object sender, EventArgs e)
        {
            stopReading();
            Clear();
        }

        private void BtnBack_Click(object sender, EventArgs e)
        {
            stopReading();
            oNetwork.TcpClosed();
            this.Finish();
        }


        #endregion

        #region Button Events



        private void BtnReset_Click(object sender, EventArgs e)
        {
            try
            {
                txtMsg.Text = "";
                if (cmbFloor.SelectedItemPosition > 0)
                {
                    cmbFloor.SetSelection(0);
                }
                if (cmbSection.SelectedItemPosition > 0)
                {
                    cmbSection.SetSelection(0);
                }
                if (cmbLocation.SelectedItemPosition > 0)
                {
                    cmbLocation.SetSelection(0);
                }
                if (cmbAssetCode.SelectedItemPosition > 0)
                {
                    cmbAssetCode.SetSelection(0);
                }
                editAssetBarcode.Text = "";
                cmbFloor.Enabled = true;
                cmbSection.Enabled = true;
                cmbLocation.Enabled = true;
                cmbAssetCode.Enabled = true;
                editAssetBarcode.Enabled = false;
                _ListItem.Clear();
                cmbFloor.RequestFocus();

            }
            catch (Exception ex)
            {
                clsGLB.ShowMessage(ex.Message, this, MessageTitle.ERROR);
            }
        }

        #endregion

        #region EditText Events
        private void BtnSave_Click(object sender, EventArgs e)
        {
            try
            {
                txtMsg.Text = "";
                ShowConfirmBox("Are you sure you want to Map?", this, SaveData);

            }
            catch (Exception ex)
            {
                clsGLB.ShowMessage(ex.Message, this, MessageTitle.ERROR);
            }


        }
        private void editBinBarcode_KeyPress(object sender, View.KeyEventArgs e)
        {
            try
            {
                if (e.Event.Action == KeyEventActions.Down)
                {
                    if (e.KeyCode == Keycode.Enter)
                    {

                        try
                        {
                            txtMsg.Text = "";
                            ShowConfirmBox("Are you sure you want to Map?", this, SaveData);

                        }
                        catch (Exception ex)
                        {
                            clsGLB.ShowMessage(ex.Message, this, MessageTitle.ERROR);
                        }

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
        public void GetFloor()
        {
            try
            {
                string _MESSAGE = "TAGMAPPING~BIND_FLOOR~" + clsGlobal.mPlant + "~" + "~" + "~" + "~" + "~" + "~" + "}";
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
                        cmbFloor.Adapter = arrayAdapter;
                        cmbFloor.SetSelection(0);

                        break;
                    case "INVALID":
                        editAssetBarcode.Text = "";
                        StartPlayingSound();
                        ShowMessageBox("No Data found", this);
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

        public void GetSection()
        {
            try
            {
                string _MESSAGE = "TAGMAPPING~BIND_SECTION~" + clsGlobal.mPlant + "~" + cmbFloor.SelectedItem.ToString() + "~" + "~" + "~" + "~" + "~" + "}";
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
                        cmbSection.Adapter = arrayAdapter;
                        cmbSection.SetSelection(0);

                        break;
                    case "INVALID":
                        editAssetBarcode.Text = "";
                        StartPlayingSound();
                        ShowMessageBox("No Data found", this);
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

        public void GetLocation()
        {
            try
            {
                string _MESSAGE = "TAGMAPPING~BIND_LOCATION~" + clsGlobal.mPlant + "~" + cmbFloor.SelectedItem.ToString() + "~" + cmbSection.SelectedItem.ToString() + "~" + "~" + "~" + "~" + "}";
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
                        cmbLocation.Adapter = arrayAdapter;
                        cmbLocation.SetSelection(0);

                        break;
                    case "INVALID":
                        editAssetBarcode.Text = "";
                        StartPlayingSound();
                        ShowMessageBox("No Data found", this);
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

        public void GetAssetCode()
        {
            try
            {
                string _MESSAGE = "TAGMAPPING~BIND_ASSET~" + clsGlobal.mPlant + "~" + cmbFloor.SelectedItem.ToString() + "~" + cmbSection.SelectedItem.ToString() + "~" + cmbLocation.SelectedItem.ToString() + "~" + "~" + "~" + "}";
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
                        cmbAssetCode.Enabled = true;
                        cmbAssetCode.Adapter = arrayAdapter;
                        cmbAssetCode.SetSelection(0);

                        break;
                    case "INVALID":
                        editAssetBarcode.Text = "";
                        cmbAssetCode.Enabled = true;
                        StartPlayingSound();
                        ShowMessageBox("No Data found", this);
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



        private void CmbDocNo_ItemSelected(object sender, AdapterView.ItemSelectedEventArgs e)
        {

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

        async Task<string> ScanDispatchDataAsync()
        {

            var progressDialog = ProgressDialog.Show(this, "", "Please wait...", true);
            try
            {
                txtMsg.Text = "";
                string[] _RESPONSE = await Task.Run(() => ScanDispatchDataToServer());

                progressDialog.Hide();
                savingFlag = false;
                switch (_RESPONSE[0])
                {
                    case "VALID":
                        if (!_RESPONSE[1].Equals("Y"))
                        {
                            // StartPlayingSound();
                            //ShowMessageBox(_RESPONSE[1], this);
                            txtMsg.Text = _RESPONSE[1];
                            editAssetBarcode.Text = "";
                            editAssetBarcode.Enabled = true;
                            editAssetBarcode.RequestFocus();
                        }
                        else
                        {
                            Sound();
                            txtMsg.Text = $"Tag {editAssetBarcode.Text.Trim()} Mapped Successfully ";
                            editAssetBarcode.Enabled = false;
                            editAssetBarcode.Text = "";
                            GetAssetCode();
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
                        stopReading();
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




        private string[] ScanDispatchDataToServer()
        {
            try
            {
                string _MESSAGE = "TAGMAPPING~TAGMAPPING~" + clsGlobal.mPlant + "~" + cmbFloor.SelectedItem.ToString() + "~" + cmbSection.SelectedItem.ToString() + "~" + cmbLocation.SelectedItem.ToString() + "~" + cmbAssetCode.SelectedItem.ToString() + "~" + editAssetBarcode.Text.Trim() + "~" + clsGlobal.UserId + "}";
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
            if (cmbFloor.SelectedItemPosition <= 0)
            {
                txtMsg.Text = "Select Floor.";
                cmbFloor.RequestFocus();
                return;
            }
            if (cmbSection.SelectedItemPosition <= 0)
            {
                txtMsg.Text = "Select Section.";
                cmbSection.RequestFocus();
                return;
            }
            if (cmbLocation.SelectedItemPosition <= 0)
            {
                txtMsg.Text = "Select Location";
                cmbLocation.RequestFocus();
                return;
            }
            if (cmbAssetCode.SelectedItemPosition <= 0)
            {
                txtMsg.Text = "Select Asset Code";
                cmbAssetCode.RequestFocus();
                return;
            }

            if (string.IsNullOrEmpty(editAssetBarcode.Text.Trim()))
            {
                txtMsg.Text = "Read Asset TAG";
                editAssetBarcode.RequestFocus();
                return;
            }

            ScanDispatchDataAsync();


        }
        private void SaveData(object sender, DialogClickEventArgs e)
        {
            Save();
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
