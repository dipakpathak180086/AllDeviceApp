using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.Media;
using Android.OS;
using Android.Support.V7.App;
using Android.Views;
using Android.Widget;
using IOCLAndroidApp;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SatoScanningApp
{
    [Activity(Label = "Sato ScanningApp", WindowSoftInputMode = SoftInput.StateHidden, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation, ScreenOrientation = ScreenOrientation.Portrait)]
    public class TrolleyReceivingActivity : AppCompatActivity
    {
        clsGlobal clsGLB;
        clsNetwork oNetwork;
        MediaPlayer mediaPlayerSound;
        Vibrator vibrator;

        Spinner spinnerColor;
        List<string> _ListColor = new List<string>();
        int _CurrentColorIndex = 0;

        EditText editTrolleyNo, editTrayQty;
       
        Button btnSave, btnReset;

        string _ScannedTrolleyCard = "", _ModelNo = "";

        public TrolleyReceivingActivity()
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
                SetContentView(Resource.Layout.activity_trolleyReceiving);

                spinnerColor = FindViewById<Spinner>(Resource.Id.spinnerColor);

                editTrolleyNo = FindViewById<EditText>(Resource.Id.editTrolleyNo);
                editTrolleyNo.KeyPress += EditTrolleyNo_KeyPress;

                editTrayQty = FindViewById<EditText>(Resource.Id.editTrayQty);
            
                Button btnBack = FindViewById<Button>(Resource.Id.btnBack);
                btnBack.Click += (e, a) =>
                {
                    this.Finish();
                };



                btnReset = FindViewById<Button>(Resource.Id.btnReset);
                btnReset.Click += BtnReset_Click;

                btnSave = FindViewById<Button>(Resource.Id.btnSave);
                btnSave.Click += BtnSave_Click;

                vibrator = this.GetSystemService(VibratorService) as Vibrator;


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

        #region Button Events
        private void BtnSave_Click(object sender, EventArgs e)
        {
            try
            {

                if (ValidateField())
                {
                    if (ValidateTrolley())
                    {
                        if (spinnerColor.SelectedItemPosition <= 0)
                        {
                            StartPlayingSound();
                            ShowMessageBox("Select Color", this);
                            return;
                        }
                        ShowConfirmBox("Do you want to save ?", this);
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
                Clear();
                editTrolleyNo.Text = "";
                spinnerColor.SetSelection(0);
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
                if (string.IsNullOrEmpty(editTrolleyNo.Text))
                {
                    StartPlayingSound();
                    ShowMessageBox("Scan Trolley", this);
                    editTrolleyNo.RequestFocus();
                    return false;
                }
                if (string.IsNullOrEmpty(editTrayQty.Text) || Convert.ToInt32(editTrayQty.Text) < 0)
                {
                    StartPlayingSound();
                    ShowMessageBox("Invalid Tray Qty", this);
                    editTrayQty.RequestFocus();
                    return false;
                }

                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void GetColor()
        {
            try
            {
                string _MESSAGE = "GET_COLOR~" + "}";
                string[] _RESPONSE = oNetwork.fnSendReceiveData(_MESSAGE).Split('~');
                switch (_RESPONSE[0])
                {
                    case "VALID":
                        _ListColor.Clear();
                        _ListColor.Add("--Select--");
                        string[] sArr = _RESPONSE[1].Split('#');
                        for (int i = 0; i < sArr.Length; i++)
                        {
                            _ListColor.Add(sArr[i]);
                        }
                        ArrayAdapter<string> arrayAdapter = new ArrayAdapter<string>(this, Resource.Layout.Spiner, _ListColor);
                        spinnerColor.Adapter = arrayAdapter;
                        spinnerColor.SetSelection(0);
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

        private bool ValidateTrolley()
        {
            bool breturn = false;
            try
            {
                string _MESSAGE = "VALID_TROLLEY~" + editTrolleyNo.Text.Trim() + "}";
                string[] _RESPONSE = oNetwork.fnSendReceiveData(_MESSAGE).Split('~');
                switch (_RESPONSE[0])
                {
                    case "VALID":
                        if (_RESPONSE[1] == "OK")
                        {
                            breturn = true;
                            editTrayQty.RequestFocus();
                        }
                        else
                        {
                            breturn = false;
                            StartPlayingSound();
                            ShowMessageBox(_RESPONSE[1], this);
                            editTrolleyNo.Text = string.Empty;
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
            }

            return breturn;

        }



        async void SaveReceivingDataAsync(object sender, DialogClickEventArgs e)
        {
            var progressDialog = ProgressDialog.Show(this, "", "Please wait...", true);
            try
            {
              

                string[] _RESPONSE = await Task.Run(() => SendReceivingDataToServer(editTrolleyNo.Text.Trim(), Convert.ToInt32(editTrayQty.Text.Trim()), spinnerColor.SelectedItem.ToString().Trim()));

                progressDialog.Hide();

                switch (_RESPONSE[0])
                {
                    case "VALID":
                        clsGLB.ShowMessage(_RESPONSE[1], this, MessageTitle.CONFIRM);
                        Clear();
                        BtnReset_Click(null, null);
                        editTrolleyNo.Text = "";
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
        }

        private string[] SendReceivingDataToServer(string TrolleyCard, int TrayQty, string ColorName)
        {
            try
            {
                string _MESSAGE = "SAVE_TROLLEY_REC~" + TrolleyCard + "~" + TrayQty + "~" + ColorName + "~" + clsGlobal.UserId + "}";
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

        private void Clear()
        {
            try
            {
                editTrolleyNo.Text = "";
                editTrayQty.Text = "";
                
                _ScannedTrolleyCard = "";
                _ModelNo = "";
            }
            catch (Exception ex)
            {
                clsGLB.ShowMessage(ex.Message, this, MessageTitle.ERROR);
            }
        }

        public void ShowConfirmBox(string msg, Activity activity)
        {
            Android.App.AlertDialog.Builder builder = new Android.App.AlertDialog.Builder(activity);
            builder.SetTitle("Message");
            builder.SetMessage(msg);
            builder.SetCancelable(false);
            builder.SetPositiveButton("Yes", SaveReceivingDataAsync);
            builder.SetNegativeButton("No", handllerCancelButton);
            builder.Show();
        }

        void handllerCancelButton(object sender, DialogClickEventArgs e)
        {
            try
            {
                editTrolleyNo.Text = "";
                editTrayQty.Text = "";
                _ScannedTrolleyCard = "";
                _CurrentColorIndex = 0;
                editTrolleyNo.RequestFocus();
            }
            catch (Exception ex)
            {
                clsGLB.ShowMessage(ex.Message, this, MessageTitle.ERROR);
            }
        }

        #endregion

        #region EditText Events
        private void EditTrolleyNo_KeyPress(object sender, View.KeyEventArgs e)
        {
            try
            {
                if (e.Event.Action == KeyEventActions.Down)
                {
                    if (e.KeyCode == Keycode.Enter)
                    {

                        if (string.IsNullOrEmpty(editTrolleyNo.Text))
                        {
                            StartPlayingSound();
                            ShowMessageBox("Scan Trolley", this);
                            editTrolleyNo.RequestFocus();

                        }

                        if (ValidateTrolley())
                        {
                            GetColor();
                            editTrayQty.RequestFocus();
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

        #endregion
    }
}