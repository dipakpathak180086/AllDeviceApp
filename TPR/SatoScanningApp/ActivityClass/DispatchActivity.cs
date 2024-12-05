using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.Media;
using Android.OS;
using Android.Support.V7.App;
using Android.Views;
using Android.Widget;

using IOCLAndroidApp;
using IOCLAndroidApp.Models;
using MiposAndroid.CodeFile;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SatoScanningApp
{
    [Activity(Label = "Sato ScanningApp", WindowSoftInputMode = SoftInput.StateHidden, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation, ScreenOrientation = ScreenOrientation.Portrait)]
    public class DispatchActivity : AppCompatActivity
    {
        clsGlobal clsGLB;
        clsNetwork oNetwork;
        MediaPlayer mediaPlayerSound;
        Vibrator vibrator;

        List<DispatchTrolley> _listDispatchTrolley = new List<DispatchTrolley>();

        EditText editTrolleyNo, editDispatchOrderNo, editTrollyeQty, editCustomer, editLocation, editModelNo;

        Button btnSave, btnReset, txtSqty, txtDisQty;

        string _DispatchOrderId = "";

        public DispatchActivity()
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
                SetContentView(Resource.Layout.activity_dispatch);

                editDispatchOrderNo = FindViewById<EditText>(Resource.Id.editDispatchOrderNo);
                editDispatchOrderNo.KeyPress += EditDispatchOrderNo_KeyPress;

                ImageButton imgbtnGo = FindViewById<ImageButton>(Resource.Id.imgbtnGo);
                imgbtnGo.Click += (s, e) =>
                {
                    GetDispatchOrderDataAsync();
                };

                editCustomer = FindViewById<EditText>(Resource.Id.editCustomer);
                editLocation = FindViewById<EditText>(Resource.Id.editLocation);
                editModelNo = FindViewById<EditText>(Resource.Id.editModelNo);

                editTrolleyNo = FindViewById<EditText>(Resource.Id.editTrolleyNo);
                editTrolleyNo.KeyPress += EditTrolleyNo_KeyPress;

                editTrollyeQty = FindViewById<EditText>(Resource.Id.editTrolleyQty);
                editTrollyeQty.Focusable = false;

                btnSave = FindViewById<Button>(Resource.Id.btnSave);
                btnSave.Click += BtnSave_Click;

                Button btnBack = FindViewById<Button>(Resource.Id.btnBack);
                btnBack.Click += (e, a) =>
                {
                    this.Finish();
                };
                txtDisQty = FindViewById<Button>(Resource.Id.txtDisQty);

                txtSqty = FindViewById<Button>(Resource.Id.txtSqty);


                btnReset = FindViewById<Button>(Resource.Id.btnReset);
                btnReset.Click += BtnReset_Click;

                vibrator = this.GetSystemService(VibratorService) as Vibrator;
            }
            catch (Exception ex)
            {
                clsGLB.ShowMessage(ex.Message, this, MessageTitle.ERROR);
            }
        }

        #endregion

        #region Button Events
        private void BtnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (ValidateField())
                {
                    if (string.IsNullOrEmpty(editTrollyeQty.Text) || editTrollyeQty.Text == "0")
                    {
                        StartPlayingSound();
                        ShowMessageBox("Trolley Qty Not Found !!", this);
                        editTrolleyNo.RequestFocus();
                        return;
                    }
                    if (txtDisQty.Text != "0" && editTrollyeQty.Text != "0")
                    {
                        long iTotalTrolleyQty = Convert.ToInt64(editTrollyeQty.Text.Trim()) + Convert.ToInt64(txtSqty.Text.Trim());
                        if (iTotalTrolleyQty > Convert.ToInt64(txtDisQty.Text.Trim()))
                        {
                            StartPlayingSound();
                            clsGLB.ShowMessage("Trolley Qty can not be greater than Dispatch Qty!!", this, MessageTitle.INFORMATION);
                            editTrolleyNo.RequestFocus();
                            return;
                        }
                        SaveDispatchDataAsync();
                    }
                    else
                    {
                        StartPlayingSound();
                        clsGLB.ShowMessage("Details Not Found!!", this, MessageTitle.ERROR);
                    }
                }
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
                editDispatchOrderNo.Text = "";
                Clear();
                editDispatchOrderNo.RequestFocus();
            }
            catch (Exception ex)
            {
                clsGLB.ShowMessage(ex.Message, this, MessageTitle.ERROR);
            }
        }

        #endregion

        #region Methods

        private bool ValidateField()
        {
            try
            {
                if (string.IsNullOrEmpty(editDispatchOrderNo.Text))
                {
                    StartPlayingSound();
                    ShowMessageBox("Input dispatch order no", this);
                    editDispatchOrderNo.RequestFocus();
                    return false;
                }
                if (string.IsNullOrEmpty(editCustomer.Text))
                {
                    StartPlayingSound();
                    ShowMessageBox("Customer details not found", this);
                    return false;
                }
                if (string.IsNullOrEmpty(editLocation.Text))
                {
                    StartPlayingSound();
                    ShowMessageBox("Location details not found", this);
                    return false;
                }
                if (string.IsNullOrEmpty(editCustomer.Text))
                {
                    StartPlayingSound();
                    ShowMessageBox("Model details not found", this);
                    return false;
                }
                if (string.IsNullOrEmpty(editTrolleyNo.Text))
                {
                    StartPlayingSound();
                    ShowMessageBox("Scan Trolley", this);
                    editTrolleyNo.RequestFocus();
                    return false;
                }
                if (_DispatchOrderId=="")
                {
                    StartPlayingSound();
                    ShowMessageBox("DispatchOrder Id details not found", this);
                    return false;
                }
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        async Task<string> GetDispatchOrderDataAsync()
        {
            var progressDialog = ProgressDialog.Show(this, "", "Please wait...", true);
            try
            {
                if (editDispatchOrderNo.Text.Trim() == "")
                {
                    StartPlayingSound();
                    ShowMessageBox("Please input dispatch order no", this);
                    return "";
                }
                Clear();
                string[] _RESPONSE = await Task.Run(() => GetDispatchOrderDataFromServer(editDispatchOrderNo.Text.Trim()));

                progressDialog.Hide();

                switch (_RESPONSE[0])
                {
                    case "VALID":
                        _DispatchOrderId = _RESPONSE[1];
                        editModelNo.Text = _RESPONSE[2];
                        txtDisQty.Text = _RESPONSE[3];
                        txtSqty.Text = _RESPONSE[4];
                        editCustomer.Text = _RESPONSE[5];
                        editLocation.Text = _RESPONSE[6];
                        editTrolleyNo.RequestFocus();
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

        private string[] GetDispatchOrderDataFromServer(string sDisOrderNo)
        {
            try
            {
                string _MESSAGE = "GET_DIS_DATA~" + sDisOrderNo + "}";
                string[] _RESPONSE = oNetwork.fnSendReceiveData(_MESSAGE).Split('~');
                return _RESPONSE;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        private bool ValidateTrolley()
        {
            bool breturn = false;
            try
            {
                string _MESSAGE = "DIS_VALID_TROLLEY~" + editModelNo.Text.Trim() + "~" + editTrolleyNo.Text.Trim() + "}";
                string[] _RESPONSE = oNetwork.fnSendReceiveData(_MESSAGE).Split('~');
                switch (_RESPONSE[0])
                {
                    case "VALID":
                        editTrollyeQty.Text = _RESPONSE[1].ToString();
                        btnSave.RequestFocus();
                        breturn = true;
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

            return breturn;
        }

        async void SaveDispatchDataAsync()
        {
            var progressDialog = ProgressDialog.Show(this, "", "Please wait...", true);
            try
            {
                string[] _RESPONSE = await Task.Run(() => SendDispatchDataToServer(_DispatchOrderId, editModelNo.Text.Trim(),
                    editTrolleyNo.Text.Trim(), editTrollyeQty.Text.Trim()));

                progressDialog.Hide();

                switch (_RESPONSE[0])
                {
                    case "VALID":
                        clsGLB.ShowMessage(_RESPONSE[1], this, MessageTitle.CONFIRM);
                        await GetDispatchOrderDataAsync();
                        editTrolleyNo.Text = editTrollyeQty.Text = "";
                        editTrolleyNo.RequestFocus();
                        if (txtDisQty.Text == txtSqty.Text)
                        {
                            clsGLB.ShowMessage("Dispatch Completed !!", this, MessageTitle.INFORMATION);
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
        }

        private string[] SendDispatchDataToServer(string sDisOrderId, string sModel, string sTrolleyNo, string sQty)
        {
            try
            {
                string _MESSAGE = "SAVE_TROLLEY_DIS~" + sDisOrderId + "~" + sModel + "~" + sTrolleyNo + "~" + sQty + "~" + clsGlobal.UserId + "}";
                string[] _RESPONSE = oNetwork.fnSendReceiveData(_MESSAGE).Split('~');

                return _RESPONSE;
            }
            catch (Exception ex)
            {
                throw ex;
            }
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
                editTrolleyNo.Text = "";
                editTrollyeQty.Text = "";
                editCustomer.Text = "";
                editLocation.Text = "";
                editModelNo.Text = ""; _DispatchOrderId = "";
                txtDisQty.Text = txtSqty.Text = "0";
            }
            catch (Exception ex)
            {
                clsGLB.ShowMessage(ex.Message, this, MessageTitle.ERROR);
            }
        }

        #endregion

        #region EditText Events

        private void EditDispatchOrderNo_KeyPress(object sender, View.KeyEventArgs e)
        {
            try
            {
                if (e.Event.Action == KeyEventActions.Down)
                {
                    if (e.KeyCode == Keycode.Enter)
                    {
                        GetDispatchOrderDataAsync();
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
        private void EditTrolleyNo_KeyPress(object sender, View.KeyEventArgs e)
        {
            try
            {
                if (e.Event.Action == KeyEventActions.Down)
                {
                    if (e.KeyCode == Keycode.Enter)
                    {
                        if (ValidateField())
                        {
                            if (!ValidateTrolley())
                            {
                                editTrolleyNo.Text = string.Empty;
                                editTrollyeQty.Text = string.Empty;
                            }
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

        public override void OnBackPressed()
        {
        }

        #endregion
    }
}