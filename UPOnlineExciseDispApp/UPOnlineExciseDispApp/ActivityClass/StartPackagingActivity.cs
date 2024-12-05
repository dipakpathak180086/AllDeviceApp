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

namespace UPOnlineExciseDispApp
{
    [Activity(Label = "Start Packaging", WindowSoftInputMode = SoftInput.StateHidden, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation, ScreenOrientation = ScreenOrientation.Portrait)]
    public class StartPackagingActivity : AppCompatActivity
    {
        clsGlobal clsGLB;
        clsNetwork oNetwork;
        MediaPlayer mediaPlayerSound;
        Vibrator vibrator;
        Button btnStart=null;
        TextView lblMsg, lblBatchSerialNo, lblETIN, lblStrength, lblBrandVolume, lblPackSize, lblBrandName;

        public StartPackagingActivity()
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
            vibrator = this.GetSystemService(VibratorService) as Vibrator;
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.activity_StartPackaging);
            lblMsg = FindViewById<TextView>(Resource.Id.lblMsg);
            lblBrandName = FindViewById<TextView>(Resource.Id.lblBrandName);
            lblPackSize = FindViewById<TextView>(Resource.Id.lblPackSize);
            lblBrandVolume = FindViewById<TextView>(Resource.Id.lblBrandVolume);
            lblStrength = FindViewById<TextView>(Resource.Id.lblStrength);
            lblETIN = FindViewById<TextView>(Resource.Id.lblETIN);
            lblBatchSerialNo = FindViewById<TextView>(Resource.Id.lblBatchSerialNo);
            Button btnBack = FindViewById<Button>(Resource.Id.btnBack);
            btnBack.Click += (e, a) =>
            {
                oNetwork.TcpClosed();
                this.Finish();
            };
            lblMsg.Visibility = ViewStates.Invisible;
            BindStartPackaging();
            btnStart = FindViewById<Button>(Resource.Id.btnStart);
            btnStart.Click += btnStart_Click;
           
           
        }

        private string[] SendDataToServer()
        {
            try
            {
                string _MESSAGE = "STARTPACKAGING~" + clsGlobal.Db_Type + "~" + clsGlobal.LineId + "~" + clsGlobal.UserId + "}";
                string[] _RESPONSE = oNetwork.fnSendReceiveData(_MESSAGE).Split('~');
                return _RESPONSE;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        private void BindStartPackaging()
        {
            try
            {
                clsGlobal.Db_Type = "BIND_START_PACKAGING_DATA";
                string[] _RESPONSE = SendDataToServer();
                switch (_RESPONSE[0])
                {
                    case "VALID":
                        string[] ArrRow = _RESPONSE[1].Split("#");
                        string[] ArrCol = ArrRow[0].Split("$");
                        
                        lblBrandName.Text = ArrCol[0].ToString();
                        clsGlobal.BrandName = ArrCol[0].ToString();

                        lblPackSize.Text = ArrCol[1].ToString();
                        clsGlobal.PackSize = ArrCol[1].ToString();

                        lblBrandVolume.Text = ArrCol[2].ToString();
                        clsGlobal.BrandVolume = ArrCol[2].ToString();

                        lblStrength.Text = ArrCol[3].ToString();
                        clsGlobal.Strength = ArrCol[3].ToString();

                        lblETIN.Text = ArrCol[4].ToString();
                        clsGlobal.ETIN = ArrCol[4].ToString();

                        lblBatchSerialNo.Text = ArrCol[5].ToString();
                        clsGlobal.BatchSerialNo = ArrCol[5].ToString();

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
                throw ex;
            }
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
        private void btnStart_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(lblBrandName.Text.Trim()) && lblBrandName.Text.Trim()== "XXXXXXXX")
                {
                    Toast.MakeText(this, "Brand Name can't be blank!!", ToastLength.Long).Show();
                    return;
                }
                if (string.IsNullOrEmpty(lblPackSize.Text.Trim()) && lblPackSize.Text.Trim()== "XXXXXXXX")
                {
                    Toast.MakeText(this, "Pack Size can't be blank!!", ToastLength.Long).Show();
                    return;
                }
                if (string.IsNullOrEmpty(lblBrandVolume.Text.Trim()) && lblBrandVolume.Text.Trim() == "XXXXXXXX")
                {
                    Toast.MakeText(this, "Brand Volume can't be blank!!", ToastLength.Long).Show();
                    return;
                }
                if (string.IsNullOrEmpty(lblStrength.Text.Trim()) && lblStrength.Text.Trim() == "XXXXXXXX")
                {
                    Toast.MakeText(this, "Strength can't be blank!!", ToastLength.Long).Show();
                    return;
                }
                if (string.IsNullOrEmpty(lblETIN.Text.Trim()) && lblETIN.Text.Trim() == "XXXXXXXX")
                {
                    Toast.MakeText(this, "ETIN can't be blank!!", ToastLength.Long).Show();
                    return;
                }
                if (string.IsNullOrEmpty(lblBatchSerialNo.Text.Trim()) && lblBatchSerialNo.Text.Trim() == "XXXXXXXX")
                {
                    Toast.MakeText(this, "Batch Serial No. can't be blank!!", ToastLength.Long).Show();
                    return;
                }

                OpenActivity(typeof(ManualPackagingActivity));
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
    }
}