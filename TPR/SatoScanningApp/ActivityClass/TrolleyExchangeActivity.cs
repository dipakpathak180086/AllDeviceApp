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
    public class TrolleyExchangeActivity : AppCompatActivity
    {
        clsGlobal clsGLB;
        clsNetwork oNetwork;
        MediaPlayer mediaPlayerSound;
        Vibrator vibrator;


        EditText editOldTrolleyNo, editNewTrolleyNo;
       
        Button btnSave, btnReset;


        public TrolleyExchangeActivity()
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
                SetContentView(Resource.Layout.activity_trolleyExchange);

                editOldTrolleyNo = FindViewById<EditText>(Resource.Id.editOldTrolleyNo);
                editOldTrolleyNo.KeyPress += EditOldTrolleyNo_KeyPress;

                editNewTrolleyNo = FindViewById<EditText>(Resource.Id.editNewTrolleyNo);
                editNewTrolleyNo.KeyPress += EditNewTrolleyNo_KeyPress;
            
                Button btnBack = FindViewById<Button>(Resource.Id.btnBack);
                btnBack.Click += (e, a) =>
                {
                    this.Finish();
                };
                Clear();


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
                    bool bvalidateOldTrolley = ValidateOldTrolley();
                    bool bvalidateNewTrolley= ValidateNewTrolley();
                    if (bvalidateNewTrolley==true && bvalidateOldTrolley==true)
                    {
                        if (string.IsNullOrEmpty(editOldTrolleyNo.Text))
                        {
                            StartPlayingSound();
                            ShowMessageBox("Scan Old Trolley", this);
                            editOldTrolleyNo.RequestFocus();
                            return;
                        }
                        if (string.IsNullOrEmpty(editNewTrolleyNo.Text))
                        {
                            ShowMessageBox("Scan New Trolley", this);
                            editNewTrolleyNo.RequestFocus();
                            return;
                        }
                        ShowConfirmBox("Do you want to exchange ?", this);
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
                if (string.IsNullOrEmpty(editOldTrolleyNo.Text))
                {
                    StartPlayingSound();
                    ShowMessageBox("Scan Old Trolley", this);
                    editOldTrolleyNo.RequestFocus();
                    return false;
                }
                if (string.IsNullOrEmpty(editNewTrolleyNo.Text))
                {
                    StartPlayingSound();
                    ShowMessageBox("Scan New Trolley", this);
                    editNewTrolleyNo.RequestFocus();
                    return false;
                }

                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

       

        private bool ValidateOldTrolley()
        {
            bool breturn = false;
            try
            {
                string _MESSAGE = "EXCHANGE_TROLLEY~VALIDATE_OLD_TROLLEY~" + editOldTrolleyNo.Text.Trim() +"~"+ editNewTrolleyNo.Text.Trim() + "~" + clsGlobal.UserId + "}";
                string[] _RESPONSE = oNetwork.fnSendReceiveData(_MESSAGE).Split('~');
                switch (_RESPONSE[0])
                {
                    case "VALID":
                        if (_RESPONSE[1] == "Y")
                        {
                            breturn = true;
                            editOldTrolleyNo.Enabled = false;
                            editNewTrolleyNo.Enabled = true;
                            editNewTrolleyNo.RequestFocus();
                        }
                        else
                        {
                            breturn = false;
                            StartPlayingSound();
                            ShowMessageBox(_RESPONSE[1], this);
                            editOldTrolleyNo.Text = string.Empty;
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
        private bool ValidateNewTrolley()
        {
            bool breturn = false;
            try
            {
                string _MESSAGE = "EXCHANGE_TROLLEY~VALIDATE_NEW_TROLLEY~" + editOldTrolleyNo.Text.Trim() + "~" + editNewTrolleyNo.Text.Trim() + "~" + clsGlobal.UserId + "}";
                string[] _RESPONSE = oNetwork.fnSendReceiveData(_MESSAGE).Split('~');
                switch (_RESPONSE[0])
                {
                    case "VALID":
                        if (_RESPONSE[1] == "Y")
                        {
                            breturn = true;
                            btnSave.RequestFocus();
                        }
                        else
                        {
                            breturn = false;
                            StartPlayingSound();
                            ShowMessageBox(_RESPONSE[1], this);
                            editOldTrolleyNo.Text = string.Empty;
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


        async void SaveDataAsync(object sender, DialogClickEventArgs e)
        {
            var progressDialog = ProgressDialog.Show(this, "", "Please wait...", true);
            try
            {
              

                string[] _RESPONSE = await Task.Run(() => SendDataToServer(editOldTrolleyNo.Text.Trim(),editNewTrolleyNo.Text.Trim()));

                progressDialog.Hide();

                switch (_RESPONSE[0])
                {
                    case "VALID":
                        if (_RESPONSE[1] == "Y")
                        {
                            clsGLB.ShowMessage("Trolley Exchange Successfully!!", this, MessageTitle.CONFIRM);
                            Clear();
                            BtnReset_Click(null, null);
                        }
                        else
                        {
                            StartPlayingSound();
                            ShowMessageBox(_RESPONSE[1], this);
                            Clear();
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

        private string[] SendDataToServer(string oldTrolleyNo,string newTrolleyNo)
        {
            try
            {
                string _MESSAGE = "EXCHANGE_TROLLEY~SAVE~" + oldTrolleyNo + "~" + newTrolleyNo + "~" + clsGlobal.UserId + "}";
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
                editNewTrolleyNo.Text = editOldTrolleyNo.Text = "";
                editOldTrolleyNo.Enabled = true;
                editNewTrolleyNo.Enabled = false;
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
            builder.SetPositiveButton("Yes", SaveDataAsync);
            builder.SetNegativeButton("No", handllerCancelButton);
            builder.Show();
        }

        void handllerCancelButton(object sender, DialogClickEventArgs e)
        {
            try
            {
                Clear();
            }
            catch (Exception ex)
            {
                clsGLB.ShowMessage(ex.Message, this, MessageTitle.ERROR);
            }
        }

        #endregion

        #region EditText Events
        private void EditOldTrolleyNo_KeyPress(object sender, View.KeyEventArgs e)
        {
            try
            {
                if (e.Event.Action == KeyEventActions.Down)
                {
                    if (e.KeyCode == Keycode.Enter)
                    {

                        if (string.IsNullOrEmpty(editOldTrolleyNo.Text))
                        {
                            StartPlayingSound();
                            ShowMessageBox("Scan Old Trolley", this);
                            editOldTrolleyNo.RequestFocus();

                        }

                        if (ValidateOldTrolley())
                        {
                            editOldTrolleyNo.Enabled = false;
                            editNewTrolleyNo.Enabled = true;
                            editNewTrolleyNo.RequestFocus();
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
        private void EditNewTrolleyNo_KeyPress(object sender, View.KeyEventArgs e)
        {
            try
            {
                if (e.Event.Action == KeyEventActions.Down)
                {
                    if (e.KeyCode == Keycode.Enter)
                    {

                        if (string.IsNullOrEmpty(editOldTrolleyNo.Text))
                        {
                            StartPlayingSound();
                            ShowMessageBox("Scan Old Trolley", this);
                            editOldTrolleyNo.RequestFocus();

                        }
                        if (string.IsNullOrEmpty(editNewTrolleyNo.Text))
                        {
                            StartPlayingSound();
                            ShowMessageBox("Scan New Trolley", this);
                            editNewTrolleyNo.RequestFocus();

                        }
                        if (ValidateNewTrolley())
                        {
                            btnSave.RequestFocus();
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