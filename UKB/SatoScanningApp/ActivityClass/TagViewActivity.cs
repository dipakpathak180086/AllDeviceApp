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
using Com.Imagealgorithmlab.Barcode;
using Com.Rscja.Deviceapi;
using IOCLAndroidApp;
using IOCLAndroidApp.Models;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace SatoScanningApp.ActivityClass
{
    [Activity(Label = "Sato ScanningApp", WindowSoftInputMode = SoftInput.StateHidden, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation, ScreenOrientation = ScreenOrientation.Portrait)]
    public class TagViewActivity : AppCompatActivity
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

        TextView txtAssetCode, txtMsg, txtAssetDesc, txtPlant, txtFloor, txtSection, txtLocationCode;
        int _TotalQty = 0, _ScanQty = 0;

        RecyclerView.LayoutManager mLayoutManager;
        Button btnSave, btnReset, btnBack, btnStart, btnClear;
        List<string> _lst = new List<string>();
        bool savingFlag = false;
        public TagViewActivity()
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

                String strEPC = this.uhfAPI.ConvertUiiToEPC(strUII);
                Message msg = handler.ObtainMessage();


                msg.Obj = strEPC;
                handler.SendMessage(msg);

            }

            //AddEPCToList(strEPC, "N/A");

            else
            {
                Toast.MakeText(this, "failuer", ToastLength.Short);
            }

        }

        object _lock = new object();
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

                //if (!_tagID.ContainsKey(epc))
                //{
                //    _tagID.Add(epc, epc);
                //foreach (var item in _tagID)
                //{
                editAssetBarcode.Text = epc;
                //Sound();
                // editBinBarcode_KeyPress(null, null);
                if (editAssetBarcode.Text.Length > 0)
                    GetDataDetails();
                //}
                //ItemView pickingItem = new ItemView();
                //pickingItem.Asset = epc;
                //pickingItem.Qty = 1;
                //pickingItem.ScanQty = 1;

                //_ListItem.Add(pickingItem);
                //itemAdapter.NotifyDataSetChanged();
                //_TotalQty = _tagID.Count;
                //txtTotalQty.Text = "Total Qty :" + _TotalQty;
                // }
            }
        }

        private void StopInventory()
        {
            if (loopFlag)
            {
                editAssetBarcode.Enabled = false;

                uhfAPI.StopInventory();
                loopFlag = false;
            }


        }
        private class UIHand : Handler
        {
            TagViewActivity scanFragment;
            public UIHand(TagViewActivity _scanFragment)
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

            TagViewActivity mainActivity;
            ProgressDialog proDialg = null;

            public InitTask(TagViewActivity _mainActivity)
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
                SetContentView(Resource.Layout.layout_TagViewData);
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




                ImageView imgBack = FindViewById<ImageView>(Resource.Id.imgBack);
                imgBack.Click += (e, a) =>
                {
                    stopReading();
                    this.Finish();
                };
                TextView txtHeader = FindViewById<TextView>(Resource.Id.txtHeader);


                txtHeader.Text = "TAG UNMAPPING";

                txtMsg = FindViewById<TextView>(Resource.Id.txtMsg);
                txtMsg.Text = "";

                txtPlant = FindViewById<TextView>(Resource.Id.txtPlant);
                txtAssetCode = FindViewById<TextView>(Resource.Id.txtAssetCode);
                txtAssetDesc = FindViewById<TextView>(Resource.Id.txtAssetDesc);
                txtFloor = FindViewById<TextView>(Resource.Id.txtFloor);
                txtSection = FindViewById<TextView>(Resource.Id.txtSection);
                txtLocationCode = FindViewById<TextView>(Resource.Id.txtLocationCode);





                editAssetBarcode = FindViewById<EditText>(Resource.Id.editBarcode);
                editAssetBarcode.KeyPress += editBinBarcode_KeyPress;

                btnStart = FindViewById<Button>(Resource.Id.btnStart);
                btnStart.Click += BtnStart_Click;

                btnSave = FindViewById<Button>(Resource.Id.btnSave);
                //btnSave.Click += BtnSave_Click;

                btnBack = FindViewById<Button>(Resource.Id.btnBack);
                btnBack.Click += BtnBack_Click;


                btnReset = FindViewById<Button>(Resource.Id.btnReset);
                btnReset.Click += BtnReset_Click;



                vibrator = this.GetSystemService(VibratorService) as Vibrator;
                // txtMsg.Text = "Click start button to start scanning";

                btnBack = FindViewById<Button>(Resource.Id.btnBack);
                btnBack.Click += (e, a) =>
                {
                    stopReading();
                    oNetwork.TcpClosed();
                    this.Finish();
                };

                mLayoutManager = new LinearLayoutManager(this);




                editAssetBarcode.Enabled = false;
                soundPool = new SoundPool(10, Stream.Music, 0);
                soundPoolId = soundPool.Load(this, Resource.Drawable.beep, 1);
                handler = new UIHand(this);

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
                    editAssetBarcode.Enabled = false;

                    loopFlag = false;
                    StopInventory();
                }

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
                txtPlant.Text = txtAssetCode.Text = txtAssetDesc.Text = "XXXX";

                editAssetBarcode.Text = "";



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

                        GetDataDetails();

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

        public void GetDataDetails()
        {
            try
            {
                string _MESSAGE = "TAGUNMAPPING~VIEW_TAG_DATA~" + txtPlant.Text + "~" + txtAssetCode.Text.Trim() + "~" + txtAssetDesc.Text.Trim() + "~" + editAssetBarcode.Text.Trim() + "~" + clsGlobal.UserId + "}";
                string[] _RESPONSE = oNetwork.GetSetTcpNewApp(_MESSAGE).Split('~');

                switch (_RESPONSE[0])
                {
                    case "VALID":
                        if (!_RESPONSE[1].Equals("Y"))
                        {
                            txtMsg.Text = "";
                            string[] sArr = _RESPONSE[1].Split('#');
                            if (sArr.Length > 0)
                            {
                                string[] sArr2 = sArr[0].Split('$');
                                if (sArr2.Length > 1)
                                {
                                    Sound();


                                    txtPlant.Text = sArr2[0].ToString();
                                    txtFloor.Text = sArr2[1].ToString();
                                    txtSection.Text = sArr2[2].ToString();
                                    txtLocationCode.Text = sArr2[3].ToString(); 
                                    txtAssetCode.Text = sArr2[4].ToString();
                                    txtAssetDesc.Text = sArr2[5].ToString();


                                }
                                else
                                {

                                    txtMsg.Text = _RESPONSE[1];
                                    txtPlant.Text = txtAssetCode.Text = txtAssetDesc.Text = "XXXX";
                                    editAssetBarcode.Text = "";
                                    editAssetBarcode.Enabled = true;
                                    editAssetBarcode.RequestFocus();
                                }
                            }

                        }
                        else
                        {




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