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
    public class StockTakeActivity : AppCompatActivity
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
        Spinner cmbFloor, cmbSection, cboLocation;
        EditText editAssetBarcode;

        TextView txtMsg, txtScanQty, txtTotalQty, txtPlant;
        int _TotalQty = 0, _ScanQty = 0;
        RecyclerView recyclerViewItem;
        ItemStockTakeAdapter itemAdapter;
        RecyclerView.LayoutManager mLayoutManager;
        Button btnSave, btnReset, btnBack, btnStart, btnClear;
        List<string> _lst = new List<string>();

        public StockTakeActivity()
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
            Log.Info("re2", uhfAPI.ToString());
            if (uhfAPI != null)
            {

                new InitTask(this).Execute();
            }
        }
        protected override void OnPause()
        {
            base.OnPause();
        }

        protected override void OnDestroy()
        {

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
                            //  Thread.Sleep(500);
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

                if (!_tagID.ContainsKey(epc))
                {
                    _tagID.Add(epc, epc);
                    editAssetBarcode.Text = epc;
                    TempSave();

                    //ItemView pickingItem = new ItemView();
                    //pickingItem.Asset = epc;
                    //pickingItem.Qty = 1;
                    //pickingItem.ScanQty = 1;

                    //_ListItem.Add(pickingItem);
                    //itemAdapter.NotifyDataSetChanged();
                    //_TotalQty = _tagID.Count;
                    //txtTotalQty.Text = "Total Qty :" + _TotalQty;
                }
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
            StockTakeActivity scanFragment;
            public UIHand(StockTakeActivity _scanFragment)
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
            btnStart.Text = "Start";
            loopFlag = false;
            StopInventory();
        }
        private class InitTask : AsyncTask<Java.Lang.Void, Java.Lang.Void, string[]>
        {

            StockTakeActivity mainActivity;
            ProgressDialog proDialg = null;

            public InitTask(StockTakeActivity _mainActivity)
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
                SetContentView(Resource.Layout.activity_StockTake);
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
                cmbSection.ItemSelected += CmbSection_ItemSelected;
                cboLocation = FindViewById<Spinner>(Resource.Id.spinnerLocation);
                cboLocation.ItemSelected += cboLocation_ItemSelected;




                ImageView imgBack = FindViewById<ImageView>(Resource.Id.imgBack);
                imgBack.Click += (e, a) =>
                {
                    StopInventory();
                    oNetwork.TcpClosed();
                    this.Finish();
                };
                TextView txtHeader = FindViewById<TextView>(Resource.Id.txtHeader);


                txtHeader.Text = "STOCK TAKE";

                txtMsg = FindViewById<TextView>(Resource.Id.txtMsg);
                txtMsg.Text = "";

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
                    if (uhfAPI != null)
                    {
                        StopInventory();
                    }

                    this.Finish();
                };
                recyclerViewItem = FindViewById<RecyclerView>(Resource.Id.recycleViewPickingItem);
                mLayoutManager = new LinearLayoutManager(this);
                recyclerViewItem.SetLayoutManager(mLayoutManager);

                BindRecycleView();

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

        private void CmbFloor_ItemSelected(object sender, AdapterView.ItemSelectedEventArgs e)
        {
            try
            {
                if (cmbFloor.SelectedItemPosition > 0)
                {
                    GetSection();
                    cmbSection.RequestFocus();
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
                    cboLocation.RequestFocus();
                }
            }
            catch (Exception ex)
            {
                StartPlayingSound();
                ShowMessageBox(ex.Message, this);
            }

        }

        private void cboLocation_ItemSelected(object sender, AdapterView.ItemSelectedEventArgs e)
        {
            try
            {
                if (cboLocation.SelectedItemPosition > 0)
                {
                    BindView();
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

        private void BtnStart_Click(object sender, EventArgs e)
        {
            try
            {
                if (btnStart.Text == "Start")
                {
                    txtMsg.Text = "";
                    btnStart.Text = "Stop";
                    editAssetBarcode.Enabled = true;
                    editAssetBarcode.RequestFocus();
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
                    editAssetBarcode.Enabled = true;
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



        #endregion

        #region Button Events



        private void BtnReset_Click(object sender, EventArgs e)
        {
            try
            {
                txtMsg.Text = "";
                //txtPlant.Text = clsGlobal.mPlant ;
                if (cmbFloor.SelectedItemPosition > 0)
                {
                    cmbFloor.SetSelection(0);
                }
                if (cmbSection.SelectedItemPosition > 0)
                {
                    cmbSection.SetSelection(0);
                }
                if (cboLocation.SelectedItemPosition > 0)
                {
                    cboLocation.SetSelection(0);
                }
                // btnStart.Text = "Start";
                editAssetBarcode.Text = "";
                txtScanQty.Text = "Scan Count : 0";
                txtTotalQty.Text = "Total Qty : 0";
                _TotalQty = 0;
                _ScanQty = 0;
                editAssetBarcode.Enabled = false;
                _ListItem.Clear();
                _tagID.Clear();
                itemAdapter.NotifyDataSetChanged();
                cmbFloor.RequestFocus();
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

                        TempSave();

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
        private void SaveData(object sender, DialogClickEventArgs e)
        {
           
            Save();
        }
        private void TempSave()
        {
            mode = "";

            txtMsg.Text = "";

            if (_TotalQty == _ScanQty)
            {
                txtMsg.Text = "Scanning Completed Need to Save the Data!!!";
                editAssetBarcode.Text = "";
                return;
            }
            bool iMatched = false;
            for (int i = 0; i < _ListItem.Count; i++)
            {
                if (_ListItem[i].ScannedRFIDTag != "" && _ListItem[i].ScannedRFIDTag == editAssetBarcode.Text.Trim())
                {
                    txtMsg.Text = "Tag Already Scanned!!!";
                    editAssetBarcode.Text = "";
                    return;

                }
                if (_ListItem[i].RFIDTag == editAssetBarcode.Text.Trim())
                {
                    iMatched = true;
                    _ScanQty = _ScanQty + 1;
                    _ListItem[i].ScannedRFIDTag = editAssetBarcode.Text.Trim();
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
            //if (_tagID.ContainsKey(editAssetBarcode.Text.Trim()))
            //    _tagID.Remove(editAssetBarcode.Text.Trim());

        }



        public void GetLocation()
        {
            try
            {
                string _MESSAGE = "STOCKTAKE~BIND_LOCATION~" + clsGlobal.mPlant + "~" + cmbFloor.SelectedItem + "~" + cmbSection.SelectedItem + "~" + "~" + "~" + "~" + "~" + "}";
                string[] _RESPONSE = oNetwork.fnSendReceiveData(_MESSAGE).Split('~');

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
                        cboLocation.Adapter = arrayAdapter;
                        cboLocation.SetSelection(0);

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
        public void GetSection()
        {
            try
            {
                string _MESSAGE = "STOCKTAKE~BIND_SECTION~" + clsGlobal.mPlant + "~" + cmbFloor.SelectedItem + "~" + "~" + "~" + "~" + "~" + "~" + "}";
                string[] _RESPONSE = oNetwork.fnSendReceiveData(_MESSAGE).Split('~');

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
        public void GetFloor()
        {
            try
            {
                string _MESSAGE = "STOCKTAKE~BIND_FLOOR~" + clsGlobal.mPlant + "~" + "~" + "~" + "~" + "~" + "}";
                string[] _RESPONSE = oNetwork.fnSendReceiveData(_MESSAGE).Split('~');

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
                itemAdapter = new ItemStockTakeAdapter(_ListItem, this);
                recyclerViewItem.SetAdapter(itemAdapter);

            }
            catch (Exception ex) { throw ex; }
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
        private void BindView()
        {
            try
            {
                string sRequest = string.Empty;
                sRequest = oNetwork.fnSendReceiveData("STOCKTAKE~BIND_VIEW~" + clsGlobal.mPlant + "~" + cmbFloor.SelectedItem + "~" + cmbSection.SelectedItem + "~" + "~" + "~" + cboLocation.SelectedItem + "~" + "}");
                string[] sResponse = sRequest.Split('~');
                switch (sResponse[0])
                {
                    case "VALID":
                        if (sResponse[1] != "")
                        {
                            BindListviewDtl(sResponse[1].ToString());

                        }
                        itemAdapter.NotifyDataSetChanged();
                        _TotalQty = itemAdapter.ItemCount;
                        txtTotalQty.Text = "Scan Count : " + _TotalQty;
                        editAssetBarcode.RequestFocus();
                        editAssetBarcode.Text = string.Empty;
                        editAssetBarcode.Enabled = true;
                        break;
                    case "INVALID":
                        //StartPlayingSound();
                        //ShowMessageBox("No Pending Items Found!", this);

                        break;
                    case "ERROR":
                        StartPlayingSound();
                        ShowMessageBox(sResponse[1], this);

                        break;
                    case "NO_CONNECTION":
                        StartPlayingSound();
                        ShowMessageBox("Server is unavailable", this);

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
                _TotalQty = _TotalQty + 1;
                string[] arrCell = strRow.Split('$');
                ItemView pickingItem = new ItemView();

                pickingItem.Asset = arrCell[0];
                pickingItem.RFIDTag = arrCell[1];
                pickingItem.Status = arrCell[2];
                pickingItem.ScannedRFIDTag = arrCell[3];
                if (!string.IsNullOrEmpty(pickingItem.ScannedRFIDTag))
                {
                    _ScanQty = _ScanQty + 1;
                }
                //Convert.ToInt32(Convert.ToDecimal(arrCell[1]));
                // pickingItem.ScanQty = Convert.ToInt32(Convert.ToDecimal(arrCell[2]));

                _ListItem.Add(pickingItem);
                //_TotalQty += Convert.ToInt32(Convert.ToDecimal(arrCell[1]));
                //_ScanQty += Convert.ToInt32(Convert.ToDecimal(arrCell[2]));
            }
            //txtScanQty.Text = "Scan Count : " + _ScanQty;
            // txtTotalQty.Text = "Total Qty :" + _TotalQty;
        }
        async Task<string> ScanDataAsync()
        {
            var progressDialog = ProgressDialog.Show(this, "", "Please wait...", true);
            try
            {
                txtMsg.Text = "";
                string[] _RESPONSE = await Task.Run(() => ScanStockTakeDataToServer());

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
                            BindView();
                            txtMsg.Text = $"Stock Take Data Saved Successfully!!";
                            editAssetBarcode.Enabled = true;
                            editAssetBarcode.Text = "";
                            editAssetBarcode.RequestFocus();


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





        private string[] ScanStockTakeDataToServer()
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
                    string _MESSAGE = "STOCKTAKE~SAVE~" + clsGlobal.mPlant + "~" + cmbFloor.SelectedItem.ToString().Trim() + "~" + cmbSection.SelectedItem.ToString().Trim() + "~" + _ListItem[i].RFIDTag.ToString().Trim() + "~" + clsGlobal.UserId + "~" + cboLocation.SelectedItem.ToString().Trim() + "}";
                    _RESPONSE = oNetwork.fnSendReceiveData(_MESSAGE).Split('~');
                }
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
            if (cmbFloor.SelectedItemPosition < 0)
            {
                txtMsg.Text = "Select Floor";
                cmbFloor.RequestFocus();
                return;
            }
            if (cmbSection.SelectedItemPosition < 0)
            {
                txtMsg.Text = "Select Section";
                cmbSection.RequestFocus();
                return;
            }
            if (cboLocation.SelectedItemPosition < 0)
            {
                txtMsg.Text = "Select Location";
                cboLocation.RequestFocus();
                return;
            }

            ScanDataAsync();
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
