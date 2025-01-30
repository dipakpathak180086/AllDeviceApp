using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.Media;
using Android.OS;
using Android.Support.V7.App;
using Android.Support.V7.Widget;
using Android.Views;
using Android.Widget;

using IOCLAndroidApp;
using IOCLAndroidApp.Models;
using AISScanningApp.Adapter;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Timers;
using System.Drawing;

namespace AISScanningApp
{
    [Activity(Label = "AIS ScanningApp", WindowSoftInputMode = SoftInput.StateHidden, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation, ScreenOrientation = ScreenOrientation.Portrait)]
    public class PLCVerifedPrintingActivity : AppCompatActivity
    {
        clsPLC_Update _plc0 = null, _plc1 = null, _plc2 = null, _plc3 = null, _plc4 = null, _plc5 = null, _plc6 = null, _plc7 = null, _plc8 = null, _plc9 = null, _plc10 = null, _plc11 = null;
        /* bool variable to check whether plc job is done or not-so that same job can not be started in another thread */
        bool _IsPlc0Complete = true, _IsPlc1Complete = true, _IsPlc2Complete = true, _IsPlc3Complete = true, _IsPlc4Complete = true, _IsPlc5Complete = true, _IsPlc6Complete = true, _IsPlc7Complete = true, _IsPlc8Complete = true, _IsPlc9Complete = true, _IsPlc10Complete = true, _IsPlc11Complete = true;
        private clsGlobal clsGLB;
        private clsNetwork oNetwork;
        private MediaPlayer mediaPlayerSound;
        private Vibrator vibrator;
        private List<Part> _ListPartNo = new List<Part>();
        private Spinner spinnerPartNo;
        private EditText txtBarcode;
        private TextView txtMsg, txtLastVerifiedPart;
        private Button btnReset, btnVerifiedPrinting, btnConnect;
        private RecyclerView recycleViewPicking;
        private PickingAdapter pickingAdapter;
        private RecyclerView.LayoutManager mLayoutManager;
        MyTcpClient _tcpClient = null;
        bool _IsTcpComplete = true;
        bool IsWaitingForPLC = false;
        string _status = string.Empty;
        Timer timer;
        public PLCVerifedPrintingActivity()
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
        protected override void OnCreate(Bundle savedInstanceState)
        {

            try
            {
                base.OnCreate(savedInstanceState);
                // Set our view from the "main" layout resource
                SetContentView(Resource.Layout.activity_PLCVerifiedPrinting);
                vibrator = this.GetSystemService(VibratorService) as Vibrator;
                ImageView imgBack = FindViewById<ImageView>(Resource.Id.imgBack);
                imgBack.Click += (e, a) =>
                {
                    this.Finish();
                };

                TextView txtHeader = FindViewById<TextView>(Resource.Id.txtHeader);
                txtHeader.Text = clsGlobal.Process_Header_Text;

                txtMsg = FindViewById<TextView>(Resource.Id.txtMsg);
                txtMsg.Text = "";

                txtLastVerifiedPart = FindViewById<TextView>(Resource.Id.txtLastVerifiedBarcode);
                txtLastVerifiedPart.Text = "********";

                spinnerPartNo = FindViewById<Spinner>(Resource.Id.spinnerPartNo);
                spinnerPartNo.ItemSelected += spinnerPartNo_ItemSelected;

                txtBarcode = FindViewById<EditText>(Resource.Id.txtBarcode);
                txtBarcode.KeyPress += editItemBarcode_KeyPress;

                //btnVerifiedPrinting = FindViewById<Button>(Resource.Id.btnVerified);
                //btnVerifiedPrinting.Click += btnVerifiedPrinting_Click;

                btnReset = FindViewById<Button>(Resource.Id.btnReset);
                btnReset.Click += BtnReset_Click;

                btnConnect = FindViewById<Button>(Resource.Id.btnPLCConnect);
                btnConnect.Click += BtnConnect_Click;

                spinnerPartNo.Enabled = true;
                txtBarcode.Enabled = false;

                GetPartNoAsync();

                spinnerPartNo.RequestFocus();
                timer = new Timer();
                timer.Interval = 1000; // 1 second
                timer.Elapsed += Timer_Elapsed;
                timer.Start();
                BtnConnect_Click(null, null);
            }
            catch (Exception ex)
            {
                clsGLB.ShowMessage(ex.Message, this, MessageTitle.ERROR);
            }
        }

        private void BtnConnect_Click(object sender, EventArgs e)
        {
            try
            {
                if (btnConnect.Text.Trim().ToUpper() == "PLC CONNECT")
                {
                    btnConnect.Text = "PLC DIS-CONNECT";
                    if (_plc0 != null)
                    {
                        _plc0.Dispose();
                        _plc0 = null;
                    }
                    _plc0 = new clsPLC_Update(clsGlobal.mPLCIp, clsGlobal.mPLCPort);
                    if (_plc0.GetPLCStatus() == "Connected")
                    {
                        btnConnect.Text = "PLC CONNECTED";
                        btnConnect.SetBackgroundColor(Android.Graphics.Color.Green);
                    }
                    else
                    {
                        btnConnect.Text = "PLC DIS-CONNECTED";
                        btnConnect.SetBackgroundColor(Android.Graphics.Color.Red);
                    }
                }

            }
            catch (Exception)
            {

                throw;
            }
        }

        private void Timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            // Update the TextView with the current date and time on the UI thread
            RunOnUiThread(() =>
            {
                try
                {
                    //if (!IsWaitingForPLC)
                    //{
                    IsWaitingForPLC = true;
                    btnConnect.Enabled = false;
                    if (_plc0 != null)
                    {
                        _plc0.Dispose();
                        _plc0 = null;
                    }
                    _plc0 = new clsPLC_Update(clsGlobal.mPLCIp, clsGlobal.mPLCPort);
                    if (_plc0.GetPLCStatus() == "Connected")
                    {
                        btnConnect.Text = "PLC CONNECTED";
                        btnConnect.SetBackgroundColor(Android.Graphics.Color.Green);
                    }
                    else
                    {
                        btnConnect.Text = "PLC DIS-CONNECTED";
                        btnConnect.SetBackgroundColor(Android.Graphics.Color.Red);
                    }
                    //}

                }
                catch
                {
                    //IsWaitingForPLC=false;

                    btnConnect.Text = "PLC DIS-CONNECTED";
                }

            });
        }
        private void WritePLCInput0()
        {

            try
            {
                _status = _plc0.GetPLCStatus();
                if (_IsPlc0Complete && _status == "Connected")
                {
                    _IsPlc0Complete = false;
                    _plc0.WriteToPLC("1");
                    _IsPlc0Complete = true;
                }
                else
                {
                    StartPlayingSound();
                    ShowMessageBox("PLC Dis-Connected,Please check!!!!", this);
                }
            }
            catch (Exception ex)
            {
                _status = "Error";
                //GlobalVar.Logger.LogMessage(EventNotice.EventTypes.evtError, $"GetPLCInput0:{plc.IPAdress}:{plc.PortNo}", $"Error:" + ex.ToString());
                _IsPlc0Complete = true;
            }
        }

        #endregion

        #region Spinner Events
        private void spinnerPartNo_ItemSelected(object sender, AdapterView.ItemSelectedEventArgs e)
        {
            try
            {
                if (spinnerPartNo.SelectedItemPosition > 0)
                {
                    spinnerPartNo.Enabled = false;
                    txtBarcode.Enabled = true;
                    txtBarcode.RequestFocus();
                }
            }
            catch (Exception ex)
            {
                clsGLB.ShowMessage(ex.Message, this, MessageTitle.ERROR);
            }
        }
        #endregion

        #region Button Events
        private void btnVerifiedPrinting_Click(object sender, EventArgs e)
        {
            try
            {
            }
            catch (Exception ex)
            {
                clsGLB.ShowMessage(ex.Message, this, MessageTitle.ERROR);
            }
        }

        private void BtnReset_Click(object sender, EventArgs e)
        {
            try
            {
                Clear();
                GetPartNoAsync();
            }
            catch (Exception ex)
            {
                clsGLB.ShowMessage(ex.Message, this, MessageTitle.ERROR);
            }
        }

        #endregion

        #region EditText Events

        private void editItemBarcode_KeyPress(object sender, View.KeyEventArgs e)
        {
            try
            {
                if (e.Event.Action == KeyEventActions.Down)
                {
                    if (e.KeyCode == Keycode.Enter)
                    {
                        if (IsValidForItemBarcode())
                        {
                            if (CheckVerifyData())
                            {
                                WritePLCInput0();
                            }
                            SaveDataAsync();
                        }
                        else
                        {
                            txtBarcode.Text = "";
                        }
                    }
                    else
                    {
                        e.Handled = false;
                    }
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
            try
            {
                timer.Stop();
                if (_plc0 != null)
                    _plc0.Dispose();
                if (_plc1 != null)
                    _plc1.Dispose();
                if (_plc2 != null)
                    _plc2.Dispose();
                if (_plc3 != null)
                    _plc3.Dispose();
                if (_plc4 != null)
                    _plc4.Dispose();
                if (_plc5 != null)
                    _plc5.Dispose();
                if (_plc6 != null)
                    _plc6.Dispose();
                if (_plc7 != null)
                    _plc7.Dispose();
                if (_plc8 != null)
                    _plc8.Dispose();
                if (_plc9 != null)
                    _plc9.Dispose();
                if (_plc10 != null)
                    _plc10.Dispose();
                if (_plc11 != null)
                    _plc11.Dispose();

                GC.Collect();
            }
            catch (Exception ex) { }
        }

        #endregion

        #region RecycleView

        private void BindRecycleView()
        {
            try
            {
                pickingAdapter = new PickingAdapter(_ListPartNo, this);
                pickingAdapter.ItemClick += PickingAdapter_ItemClick;
                recycleViewPicking.SetAdapter(pickingAdapter);
            }
            catch (Exception ex)
            {
                clsGLB.ShowMessage(ex.Message, this, MessageTitle.ERROR);
            }
        }

        private void PickingAdapter_ItemClick(object sender, int e)
        {
            try
            {
            }
            catch (Exception ex)
            {
                clsGLB.ShowMessage(ex.Message, this, MessageTitle.ERROR);
            }
        }

        #endregion

        #region Methods



        private async Task<string> GetPartNoAsync()
        {
            var progressDialog = ProgressDialog.Show(this, "", "Please wait...", true);
            try
            {
                clsGlobal.Db_Type = "BIND_PART";
                string[] _RESPONSE = await Task.Run(() => SendDataToServer());

                progressDialog.Hide();
                List<string> _ListPickListNo = new List<string>();
                switch (_RESPONSE[0])
                {
                    case "VALID":
                        _ListPickListNo.Add("--Select--");
                        string[] ArrRow = _RESPONSE[1].Split("#");
                        for (int i = 0; i < ArrRow.Length; i++)
                        {
                            string[] ArrCol = ArrRow[i].Split("$");

                            for (int J = 0; J < ArrCol.Length; J++)
                            {

                                _ListPickListNo.Add(ArrCol[J]);
                            }
                        }
                        ArrayAdapter<string> arrayAdapter = new ArrayAdapter<string>(this, Resource.Layout.Spiner, _ListPickListNo);
                        spinnerPartNo.Adapter = arrayAdapter;
                        spinnerPartNo.SetSelection(0);
                        spinnerPartNo.RequestFocus();
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

        private void GetPartNoAfterComplete()
        {
            try
            {
                clsGlobal.Db_Type = "BIND_PARTNO";
                string[] _RESPONSE = SendDataToServer();
                List<string> _ListPickListNo = new List<string>();
                switch (_RESPONSE[0])
                {
                    case "VALID":
                        _ListPickListNo.Add("--Select--");
                        string[] ArrRow = _RESPONSE[1].Split("#");
                        for (int i = 0; i < ArrRow.Length; i++)
                        {
                            string[] ArrCol = ArrRow[i].Split("$");

                            for (int J = 0; J < ArrCol.Length; J++)
                            {

                                _ListPickListNo.Add(ArrCol[J]);
                            }
                        }
                        ArrayAdapter<string> arrayAdapter = new ArrayAdapter<string>(this, Resource.Layout.Spiner, _ListPickListNo);
                        spinnerPartNo.Adapter = arrayAdapter;
                        spinnerPartNo.SetSelection(0);
                        spinnerPartNo.RequestFocus();
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

            }

        }

        private string[] SendDataToServer()
        {
            try
            {
                string _MESSAGE = "PRINTING_VERIFIED~" + clsGlobal.Db_Type + "~" + spinnerPartNo.SelectedItem + "~" + txtBarcode.Text.Trim() + "~" + clsGlobal.UserId + "}";
                string[] _RESPONSE = oNetwork.fnSendReceiveData(_MESSAGE).Split('~');
                return _RESPONSE;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private async Task<string> GetPartDataAsync()
        {
            var progressDialog = ProgressDialog.Show(this, "", "Please wait...", true);
            try
            {
                _ListPartNo.Clear();
                clsGlobal.Db_Type = "BIND_PART";
                string[] _RESPONSE = await Task.Run(() => SendDataToServer());

                progressDialog.Hide();

                switch (_RESPONSE[0])
                {
                    case "VALID":
                        string[] ArrRow = _RESPONSE[1].Split("#");
                        for (int i = 0; i < ArrRow.Length; i++)
                        {
                            string[] ArrCol = ArrRow[i].Split("$");
                            _ListPartNo.Add(new Part
                            {
                                PartNo = ArrCol[0]
                            });
                        }
                        //BindTotalAndScanQty();
                        txtBarcode.Text = "";
                        txtBarcode.RequestFocus();
                        break;

                    case "INVALID":
                        txtBarcode.Text = "";
                        txtBarcode.RequestFocus();
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
               
            }
            finally
            {
            }
            return "";
        }




        private async void SaveDataAsync()
        {
            var progressDialog = ProgressDialog.Show(this, "", "Please wait...", true);
            try
            {
                clsGlobal.Db_Type = "SAVE";
                txtMsg.Text = "";
                string[] _RESPONSE = await Task.Run(() => SendDataToServer());

                progressDialog.Hide();

                switch (_RESPONSE[0])
                {
                    case "VALID":
                        txtMsg.Text = _RESPONSE[1].Trim();
                        txtLastVerifiedPart.Text = txtBarcode.Text.Trim();
                        txtBarcode.Text = "";
                        txtBarcode.RequestFocus();
                        break;

                    case "INVALID":

                        txtBarcode.Text = "";
                        txtBarcode.RequestFocus();
                        StartPlayingSound();
                        ShowMessageBox(_RESPONSE[1], this);
                        break;

                    case "ERROR":

                        txtBarcode.Text = "";
                        txtBarcode.RequestFocus();
                        StartPlayingSound();
                        ShowMessageBox(_RESPONSE[1], this);
                        break;

                    case "NO_CONNECTION":

                        txtBarcode.Text = "";
                        txtBarcode.RequestFocus();
                        StartPlayingSound();
                        ShowMessageBox("Communication server not connected", this);
                        break;

                    default:

                        txtBarcode.Text = "";
                        txtBarcode.RequestFocus();
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
        }

        private  bool CheckVerifyData()
        {
            bool bFlag = false;
            try
            {
                clsGlobal.Db_Type = "CHK_VERIFY";
                txtMsg.Text = "";
                string[] _RESPONSE = SendDataToServer();


                switch (_RESPONSE[0])
                {
                    case "VALID":
                        bFlag= true;
                        break;

                    case "INVALID":
                        bFlag = false;
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

                        txtBarcode.Text = "";
                        txtBarcode.RequestFocus();
                        StartPlayingSound();
                        ShowMessageBox("No option match from comm server", this);
                        break;

                }
            }
            catch (Exception ex)
            {
                clsGLB.ShowMessage(ex.Message, this, MessageTitle.ERROR);
               
            }
            finally
            {
               
            }
            return bFlag;
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
        private void handllerCancelButton(object sender, DialogClickEventArgs e)
        {
            try
            {

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

        private void handleOkMessage(object sender, DialogClickEventArgs e)
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
                txtLastVerifiedPart.Text = "********";
                txtBarcode.Text = "";
                txtMsg.Text = "";
                txtBarcode.Enabled = false;
                spinnerPartNo.Enabled = true;
                txtBarcode.RequestFocus();

                _ListPartNo.Clear();
            }
            catch (Exception ex)
            {
                clsGLB.ShowMessage(ex.Message, this, MessageTitle.ERROR);
            }
        }

        private bool IsValidField()
        {
            try
            {

                if (spinnerPartNo.SelectedItemPosition <= 0)
                {
                    StartPlayingSound();
                    ShowMessageBox("Select Part No", this);
                    spinnerPartNo.RequestFocus();
                    return false;
                }
                if (txtBarcode.Text.Length == 0)
                {
                    StartPlayingSound();
                    ShowMessageBox("Scan Barcode", this);
                    txtBarcode.RequestFocus();
                    return false;
                }
                return true;
            }
            catch (Exception ex) { throw ex; }
        }




        private bool IsValidForItemBarcode()
        {
            try
            {
                if (spinnerPartNo.SelectedItemPosition <= 0)
                {
                    StartPlayingSound();
                    ShowMessageBox("Select Part No", this);
                    spinnerPartNo.RequestFocus();
                    return false;
                }
                if (txtBarcode.Text.Trim() == "")
                {
                    StartPlayingSound();
                    ShowMessageBox("Scan Bin barcode", this);
                    txtBarcode.RequestFocus();
                    return false;
                }
                if (btnConnect.Text.Trim().Equals("PLC DIS-CONNECTED"))
                {
                    StartPlayingSound();
                    ShowMessageBox("PLC Disconnected, Check PLC Connection!!", this);
                    txtBarcode.RequestFocus();
                    return false;
                }

                return true;
            }
            catch (Exception ex) { throw ex; }
        }

        #endregion
    }
}