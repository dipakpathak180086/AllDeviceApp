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
    public class AddPrintTrolleyActivity : AppCompatActivity
    {
        clsGlobal clsGLB;
        clsNetwork oNetwork;
        MediaPlayer mediaPlayerSound;
        Vibrator vibrator;

        Spinner spinnerModel;
        List<string> _ListModel = new List<string>();

        EditText editTrolleyNo, editPackSize;

        Button btnSave, btnReset, btnPrint;

        public AddPrintTrolleyActivity()
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
                SetContentView(Resource.Layout.activity_addprinttrolley);

                spinnerModel = FindViewById<Spinner>(Resource.Id.spinnerModel);

                editTrolleyNo = FindViewById<EditText>(Resource.Id.editTrolleyNo);
                editTrolleyNo.KeyPress += EditTrolleyNo_KeyPress;

                editPackSize = FindViewById<EditText>(Resource.Id.editPackSize);

                btnSave = FindViewById<Button>(Resource.Id.btnSave);
                btnSave.Click += BtnSave_ClickAsync;

                btnPrint = FindViewById<Button>(Resource.Id.btnPrint);
                btnPrint.Click += BtnPrint_ClickAsync;

                Button btnBack = FindViewById<Button>(Resource.Id.btnBack);
                btnBack.Click += (e, a) =>
                {
                    this.Finish();
                };


                btnReset = FindViewById<Button>(Resource.Id.btnReset);
                btnReset.Click += BtnReset_Click;

                GetModel();

                vibrator = this.GetSystemService(VibratorService) as Vibrator;
            }
            catch (Exception ex)
            {
                clsGLB.ShowMessage(ex.Message, this, MessageTitle.ERROR);
            }
        }

        #endregion

        #region Button Events

        private async void BtnSave_ClickAsync(object sender, EventArgs e)
        {
            var progressDialog = ProgressDialog.Show(this, "", "Please wait...", true);
            try
            {
                if (ValidateField())
                {
                    string[] _RESPONSE = await Task.Run(() => SendTrolleyDataToServer(editTrolleyNo.Text.Trim(), spinnerModel.SelectedItem.ToString(), editPackSize.Text.Trim()));

                    progressDialog.Hide();

                    switch (_RESPONSE[0])
                    {
                        case "VALID":
                            clsGLB.ShowMessage(_RESPONSE[1], this, MessageTitle.CONFIRM);
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
            }
            catch (Exception ex)
            {
                clsGLB.ShowMessage(ex.Message, this, MessageTitle.ERROR);
            }
            finally
            {
                progressDialog.Hide();
            }
        }

        private async void BtnPrint_ClickAsync(object sender, EventArgs e)
        {
            var progressDialog = ProgressDialog.Show(this, "", "Please wait...", true);
            try
            {
                if (ValidateField())
                {
                    string[] _RESPONSE = await Task.Run(() => SendPrintDataToServer(editTrolleyNo.Text.Trim()));

                    progressDialog.Hide();

                    switch (_RESPONSE[0])
                    {
                        case "VALID":
                            clsGLB.ShowMessage("Print Successfully!!", this, MessageTitle.CONFIRM);
                            Clear();
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
            }
            catch (Exception ex)
            {
                clsGLB.ShowMessage(ex.Message, this, MessageTitle.ERROR);
            }
            finally
            {
                progressDialog.Hide();
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
                if (string.IsNullOrEmpty(editTrolleyNo.Text))
                {
                    StartPlayingSound();
                    ShowMessageBox("Enter trolley no", this);
                    editTrolleyNo.RequestFocus();
                    return false;
                }
                if (spinnerModel.SelectedItemPosition <= 0)
                {
                    StartPlayingSound();
                    ShowMessageBox("Select Model", this);
                    return false;
                }
                if (string.IsNullOrEmpty(editPackSize.Text) || Convert.ToInt32(editPackSize.Text) == 0)
                {
                    StartPlayingSound();
                    ShowMessageBox("Enter Pack Size", this);
                    editPackSize.RequestFocus();
                    return false;
                }

                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void GetModel()
        {
            try
            {
                string _MESSAGE = "GET_MODEL_FOR_TROLLEY~}";
                string[] _RESPONSE = oNetwork.fnSendReceiveData(_MESSAGE).Split('~');
                switch (_RESPONSE[0])
                {
                    case "VALID":
                        _ListModel.Add("--Select--");
                        string[] sArr = _RESPONSE[1].Split('#');
                        for (int i = 0; i < sArr.Length; i++)
                        {
                            _ListModel.Add(sArr[i]);
                        }
                        ArrayAdapter<string> arrayAdapter = new ArrayAdapter<string>(this, Resource.Layout.Spiner, _ListModel);
                        spinnerModel.Adapter = arrayAdapter;
                        spinnerModel.SetSelection(0);
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

        private async void GetTrolleyDetailsAsync(string TrolleyNo)
        {
            var progressDialog = ProgressDialog.Show(this, "", "Please wait...", true);
            try
            {

                string[] _RESPONSE = await Task.Run(() => GetTrolleyDataFromServer(TrolleyNo));

                progressDialog.Hide();

                switch (_RESPONSE[0])
                {
                    case "VALID":
                        editPackSize.Text = _RESPONSE[1].Trim();
                        int Index = _ListModel.IndexOf(_RESPONSE[2].Trim());
                        spinnerModel.SetSelection(Index);
                        break;

                    case "INVALID":
                        //StartPlayingSound();
                        //ShowMessageBox(_RESPONSE[1], this);
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
                progressDialog.Hide();
            }
        }
        private string[] GetTrolleyDataFromServer(string TrolleyNo)
        {
            try
            {
                string _MESSAGE = "GET_TROLLEY_DATA_FOR_PRINT~" + TrolleyNo + "}";
                string[] _RESPONSE = oNetwork.fnSendReceiveData(_MESSAGE).Split('~');

                return _RESPONSE;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
      
        private string[] SendTrolleyDataToServer(string TrolleyNo, string Model, string PackSize)
        {
            try
            {
                string _MESSAGE = "SAVE_TROLLEY_FOR_PRINT~" + TrolleyNo + "~" + Model + "~" + PackSize + "~" + clsGlobal.UserId + "}";
                string[] _RESPONSE = oNetwork.fnSendReceiveData(_MESSAGE).Split('~');

                return _RESPONSE;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private string[] SendPrintDataToServer(string TrolleyNo)
        {
            try
            {
                string _MESSAGE = "PRINT_TROLLEY~" + TrolleyNo + "}";
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
                spinnerModel.SetSelection(0);
                editPackSize.Text = "";
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
                        //Trolley no already exist then return values in calse of reprint
                        if (editTrolleyNo.Text.Trim() != "")
                        { GetTrolleyDetailsAsync(editTrolleyNo.Text.Trim()); }
                        else
                        {
                            StartPlayingSound();
                            ShowMessageBox("Scan/Input Trolley No", this);
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
        public override void OnBackPressed()
        {
        }
    }
}