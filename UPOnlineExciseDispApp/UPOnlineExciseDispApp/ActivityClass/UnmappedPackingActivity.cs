using Android.App;
using Android.OS;
using Android.Support.V7.App;
using Android.Runtime;
using Android.Widget;
using Android.Content.PM;
using Android.Views;
using IOCLAndroidApp;
using Android.Content;
using System;
using System.IO;
using UPOnlineExciseDispApp.ActivityClass;
using System.Collections.Generic;
using Android.Media;
using IOCLAndroidApp.Models;
using System.Threading.Tasks;
using UPOnlineExciseDispApp.Adapter;
using Android.Support.V7.Widget;

namespace UPOnlineExciseDispApp.ActivityClass
{
    [Activity(Label = "Unmapped Packing", WindowSoftInputMode = SoftInput.StateHidden, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation, ScreenOrientation = ScreenOrientation.Portrait)]

    public class UnmappedPackingActivity : AppCompatActivity
    {
        clsGlobal clsGLB;
        clsNetwork oNetwork;
        MediaPlayer mediaPlayerSound;
        Vibrator vibrator;
        TextView lblMsg;
        EditText txtScanCaseBarcode, txtScanOldBottelBarcode, txtScanNewBottelBarcode;
        RadioButton rbtnUnmappedCase = null;
        RadioButton rbtnBottleReplace = null;

        public UnmappedPackingActivity()
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
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.activity_UnmappedPacking);
            lblMsg = FindViewById<TextView>(Resource.Id.lblMsg);
            Button btnBack = FindViewById<Button>(Resource.Id.btnBack);
            btnBack.Click += (e, a) =>
            {
                oNetwork.TcpClosed();
                this.Finish();
            };
            txtScanCaseBarcode = FindViewById<EditText>(Resource.Id.txtScanCaseBarcode);
            txtScanCaseBarcode.KeyPress += txtScanCaseBarcode_KeyPress;

            txtScanOldBottelBarcode = FindViewById<EditText>(Resource.Id.txtScanOldBottelBarcode);
            txtScanOldBottelBarcode.KeyPress += txtScanOldBottelBarcode_KeyPress;

            txtScanNewBottelBarcode = FindViewById<EditText>(Resource.Id.txtScanNewBottelBarcode);
            txtScanNewBottelBarcode.KeyPress += txtScanNewBottelBarcode_KeyPress;

            rbtnUnmappedCase = (RadioButton)FindViewById(Resource.Id.rbtnUnmappedCase);
            rbtnUnmappedCase.CheckedChange += rbtnUnmappedCase_CheckedChange;

            rbtnBottleReplace = (RadioButton)FindViewById(Resource.Id.rbtnBottleReplace);
            rbtnBottleReplace.CheckedChange += rbtnBottleReplace_CheckedChange;
            Clear();
            vibrator = this.GetSystemService(VibratorService) as Vibrator;
            // Create your application here
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
        private void rbtnUnmappedCase_CheckedChange(object sender, CompoundButton.CheckedChangeEventArgs e)
        {
            if (rbtnUnmappedCase.Checked == true)
            {
                txtScanOldBottelBarcode.Enabled = false;
                txtScanNewBottelBarcode.Enabled = false;
                rbtnBottleReplace.Checked = false;
                txtScanCaseBarcode.Text = "";
                txtScanOldBottelBarcode.Text = "";
                txtScanNewBottelBarcode.Text = "";
                txtScanCaseBarcode.RequestFocus();
            }
            else
            {
                txtScanOldBottelBarcode.Enabled = true;
                txtScanNewBottelBarcode.Enabled = true;
                rbtnBottleReplace.Checked = true;
                rbtnUnmappedCase.Checked = false;
                txtScanCaseBarcode.Text = "";
                txtScanOldBottelBarcode.Text = "";
                txtScanNewBottelBarcode.Text = "";
                txtScanCaseBarcode.RequestFocus();
            }

        }

        private void rbtnBottleReplace_CheckedChange(object sender, CompoundButton.CheckedChangeEventArgs e)
        {
            if (rbtnBottleReplace.Checked == true)
            {
                txtScanOldBottelBarcode.Enabled = true;
                txtScanNewBottelBarcode.Enabled = true;
                rbtnBottleReplace.Checked = true;
                rbtnUnmappedCase.Checked = false;
                txtScanCaseBarcode.Text = "";
                txtScanOldBottelBarcode.Text = "";
                txtScanNewBottelBarcode.Text = "";
                txtScanCaseBarcode.RequestFocus();

            }
            else
            {
                txtScanOldBottelBarcode.Enabled = false;
                txtScanNewBottelBarcode.Enabled = false;
                rbtnBottleReplace.Checked = false;
                rbtnUnmappedCase.Checked = true;
                txtScanCaseBarcode.Text = "";
                txtScanOldBottelBarcode.Text = "";
                txtScanNewBottelBarcode.Text = "";
                txtScanCaseBarcode.RequestFocus();
            }
        }

        private bool IsValidForCaseBarcode()
        {
            try
            {
                if (txtScanCaseBarcode.Text.Trim() == "")
                {
                    StartPlayingSound();
                    ShowMessageBox("Scan case barcode", this);
                    txtScanCaseBarcode.RequestFocus();
                    return false;
                }
                return true;
            }
            catch (Exception ex) { throw ex; }
        }

        private bool IsValidForOldBottelBarcode()
        {
            try
            {
                if (txtScanOldBottelBarcode.Text.Trim() == "")
                {
                    StartPlayingSound();
                    ShowMessageBox("Scan old Bottel barcode", this);
                    txtScanOldBottelBarcode.RequestFocus();
                    return false;
                }
                return true;
            }
            catch (Exception ex) { throw ex; }
        }
        private bool IsValidForBottelBarcode()
        {
            try
            {
                if (IsValidForCaseBarcode() == false)
                {
                    return false;
                }
                if (IsValidForOldBottelBarcode() == false)
                {
                    return false;
                }
                if (txtScanNewBottelBarcode.Text.Trim() == "")
                {
                    StartPlayingSound();
                    ShowMessageBox("Scan New Bottel barcode", this);
                    txtScanNewBottelBarcode.RequestFocus();
                    return false;
                }
                return true;
            }
            catch (Exception ex) { throw ex; }
        }

        private void Clear()
        {
            try
            {
                txtScanCaseBarcode.Text = "";
                txtScanOldBottelBarcode.Text = "";
                txtScanNewBottelBarcode.Text = "";
                lblMsg.Text = "";
                txtScanCaseBarcode.RequestFocus();
                txtScanOldBottelBarcode.Enabled = false;
                txtScanNewBottelBarcode.Enabled = false;
                rbtnUnmappedCase.Checked = true;
                rbtnBottleReplace.Checked = false;

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
                txtScanCaseBarcode.RequestFocus();
            }
            catch (Exception ex)
            {
                clsGLB.ShowMessage(ex.Message, this, MessageTitle.ERROR);
            }
        }

        private string[] SendUnmappedPackingDataToServer()
        {
            try
            {
                string CaseBarcode = txtScanCaseBarcode.Text.Trim() == "" ? txtScanCaseBarcode.Text.Trim() : txtScanCaseBarcode.Text.Trim();

                string _MESSAGE = "UNMAPPED_PACKING~" + clsGlobal.Db_Type + "~" + CaseBarcode + "~" + txtScanOldBottelBarcode.Text.Trim() + "~" + txtScanNewBottelBarcode.Text.Trim() + "~" + clsGlobal.UserId + "}";
                string[] _RESPONSE = oNetwork.fnSendReceiveData(_MESSAGE).Split('~');
                return _RESPONSE;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        private async void ValidateCaseDataAsync()
        {
            try
            {
                clsGlobal.Db_Type = "VALIDATE_CASE_BARCODE";
                lblMsg.Text = "";
                string[] _RESPONSE = await Task.Run(() => SendUnmappedPackingDataToServer());
                switch (_RESPONSE[0])
                {
                    case "VALID":
                        lblMsg.Text = _RESPONSE[1].Trim().ToString();
                        lblMsg.SetTextColor(Android.Graphics.Color.Green);
                        txtScanCaseBarcode.Text = "";
                        txtScanCaseBarcode.RequestFocus();
                        break;

                    case "INVALID":
                        txtScanCaseBarcode.Text = "";
                        txtScanCaseBarcode.RequestFocus();
                        lblMsg.Text = _RESPONSE[1].Trim().ToString();
                        lblMsg.SetTextColor(Android.Graphics.Color.Red);
                        StartPlayingSound();
                        ShowMessageBox(_RESPONSE[1].Trim().ToString(), this);
                        break;

                    case "NO_CONNECTION":
                        txtScanCaseBarcode.Text = "";
                        txtScanCaseBarcode.RequestFocus();
                        StartPlayingSound();
                        ShowMessageBox("Communication server not connected", this);
                        break;

                    default:
                        txtScanCaseBarcode.Text = "";
                        txtScanCaseBarcode.RequestFocus();
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

        private async void ValidateCaseForBottelDataAsync()
        {
            try
            {
                clsGlobal.Db_Type = "VALIDATE_CASE_FOR_BOTTEL";
                lblMsg.Text = "";
                string[] _RESPONSE = await Task.Run(() => SendUnmappedPackingDataToServer());
                switch (_RESPONSE[0])
                {
                    case "VALID":
                        lblMsg.Text = _RESPONSE[1].Trim().ToString();
                        lblMsg.SetTextColor(Android.Graphics.Color.Green);
                        txtScanOldBottelBarcode.Enabled = true;
                        txtScanOldBottelBarcode.RequestFocus();
                        break;

                    case "INVALID":
                        txtScanCaseBarcode.Text = "";
                        txtScanCaseBarcode.RequestFocus();
                        lblMsg.Text = _RESPONSE[1].Trim().ToString();
                        lblMsg.SetTextColor(Android.Graphics.Color.Red);
                        StartPlayingSound();
                        ShowMessageBox(_RESPONSE[1].Trim().ToString(), this);
                        break;

                    case "NO_CONNECTION":
                        txtScanCaseBarcode.Text = "";
                        txtScanCaseBarcode.RequestFocus();
                        StartPlayingSound();
                        ShowMessageBox("Communication server not connected", this);
                        break;

                    default:
                        txtScanCaseBarcode.Text = "";
                        txtScanCaseBarcode.RequestFocus();
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
        private async void ValidateOldBottelDataAsync()
        {
            try
            {
                clsGlobal.Db_Type = "VALIDATE_OLD_BOTTEL";
                lblMsg.Text = "";
                string[] _RESPONSE = await Task.Run(() => SendUnmappedPackingDataToServer());
                switch (_RESPONSE[0])
                {
                    case "VALID":
                        lblMsg.Text = _RESPONSE[1].Trim().ToString();
                        lblMsg.SetTextColor(Android.Graphics.Color.Green);
                        txtScanNewBottelBarcode.Enabled = true;
                        txtScanNewBottelBarcode.RequestFocus();
                        break;

                    case "INVALID":
                        txtScanOldBottelBarcode.Text = "";
                        txtScanOldBottelBarcode.RequestFocus();
                        lblMsg.Text = _RESPONSE[1].Trim().ToString();
                        lblMsg.SetTextColor(Android.Graphics.Color.Red);
                        StartPlayingSound();
                        ShowMessageBox(_RESPONSE[1].Trim().ToString(), this);
                        break;

                    case "NO_CONNECTION":
                        txtScanOldBottelBarcode.Text = "";
                        txtScanOldBottelBarcode.RequestFocus();
                        StartPlayingSound();
                        ShowMessageBox("Communication server not connected", this);
                        break;

                    default:
                        txtScanOldBottelBarcode.Text = "";
                        txtScanOldBottelBarcode.RequestFocus();
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
        private async void ValidateNewBottelDataAsync()
        {
            try
            {
                clsGlobal.Db_Type = "VALIDATE_NEW_BOTTEL";
                lblMsg.Text = "";
                string[] _RESPONSE = await Task.Run(() => SendUnmappedPackingDataToServer());
                switch (_RESPONSE[0])
                {
                    case "VALID":
                        lblMsg.Text = _RESPONSE[1].Trim().ToString();
                        lblMsg.SetTextColor(Android.Graphics.Color.Green);
                        txtScanCaseBarcode.Text = "";
                        txtScanOldBottelBarcode.Text = "";
                        txtScanNewBottelBarcode.Text = "";
                        txtScanCaseBarcode.RequestFocus();
                        txtScanOldBottelBarcode.Enabled = false;
                        txtScanNewBottelBarcode.Enabled = false;
                        break;

                    case "INVALID":
                        txtScanNewBottelBarcode.Text = "";
                        txtScanNewBottelBarcode.RequestFocus();
                        lblMsg.Text = _RESPONSE[1].Trim().ToString();
                        lblMsg.SetTextColor(Android.Graphics.Color.Red);
                        StartPlayingSound();
                        ShowMessageBox(_RESPONSE[1].Trim().ToString(), this);
                        break;

                    case "NO_CONNECTION":
                        txtScanNewBottelBarcode.Text = "";
                        txtScanNewBottelBarcode.RequestFocus();
                        StartPlayingSound();
                        ShowMessageBox("Communication server not connected", this);
                        break;

                    default:
                        txtScanNewBottelBarcode.Text = "";
                        txtScanNewBottelBarcode.RequestFocus();
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
        private void txtScanCaseBarcode_KeyPress(object sender, View.KeyEventArgs e)
        {
            try
            {
                if (e.Event.Action == KeyEventActions.Down)
                {
                    if (e.KeyCode == Keycode.Enter)
                    {
                        if (IsValidForCaseBarcode() && rbtnUnmappedCase.Checked)
                        {
                            Android.App.AlertDialog.Builder dialog = new Android.App.AlertDialog.Builder(this);
                            Android.App.AlertDialog alert = dialog.Create();
                            alert.SetTitle("Remove Case");
                            alert.SetMessage("Do you really want to remove case ");
                            alert.SetButton("Yes", (c, ev) =>
                            {

                                ValidateCaseDataAsync();
                            });

                            alert.SetButton2("NO", (c, ev) => { });
                            alert.Show();
                            return;
                        }
                        if (IsValidForCaseBarcode() && rbtnBottleReplace.Checked)
                        {
                            ValidateCaseForBottelDataAsync();
                        }
                        else
                        {
                            txtScanCaseBarcode.Text = "";
                            txtScanCaseBarcode.RequestFocus();
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
        private void txtScanOldBottelBarcode_KeyPress(object sender, View.KeyEventArgs e)
        {
            try
            {
                if (e.Event.Action == KeyEventActions.Down)
                {
                    if (e.KeyCode == Keycode.Enter)
                    {
                        if (IsValidForOldBottelBarcode() && rbtnBottleReplace.Checked)
                        {
                            ValidateOldBottelDataAsync();
                        }
                        else
                        {
                            txtScanOldBottelBarcode.Text = "";
                            txtScanOldBottelBarcode.RequestFocus();
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
        private void txtScanNewBottelBarcode_KeyPress(object sender, View.KeyEventArgs e)
        {
            try
            {
                if (e.Event.Action == KeyEventActions.Down)
                {
                    if (e.KeyCode == Keycode.Enter)
                    {
                        if (IsValidForBottelBarcode() && rbtnBottleReplace.Checked)
                        {
                            Android.App.AlertDialog.Builder dialog = new Android.App.AlertDialog.Builder(this);
                            Android.App.AlertDialog alert = dialog.Create();
                            alert.SetTitle("Replace Bottel");
                            alert.SetMessage("Do you really want to replace old bottel with new bottel ");
                            alert.SetButton("Yes", (c, ev) =>
                            {
                                ValidateNewBottelDataAsync();
                            });

                            alert.SetButton2("NO", (c, ev) => { });
                            alert.Show();
                            return;
                        }
                        else
                        {
                            txtScanNewBottelBarcode.Text = "";
                            txtScanNewBottelBarcode.RequestFocus();
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

    }
}