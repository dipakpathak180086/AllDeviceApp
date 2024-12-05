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
namespace UPOnlineExciseDispApp.ActivityClass
{
    [Activity(Label = "Start Unmapping Activity", MainLauncher = true, WindowSoftInputMode = SoftInput.StateHidden, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation, ScreenOrientation = ScreenOrientation.Portrait)]
    public class StartUnmappingActivity : AppCompatActivity
    {
        clsGlobal clsGLB;
        clsNetwork oNetwork;


        EditText editPassword;

        MediaPlayer mediaPlayerSound;
        Vibrator vibrator;

        public StartUnmappingActivity()
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
            try
            {
                base.OnCreate(savedInstanceState);
                // Set our view from the "main" layout resource
                SetContentView(Resource.Layout.activity_SartUnmapping);

                Button btnLogin = FindViewById<Button>(Resource.Id.btnLogin);
                btnLogin.Click += BtnLogin_Click; ;

                Button btnBack = FindViewById<Button>(Resource.Id.btnBack);
                btnBack.Click += (e, a) =>
                {
                    oNetwork.TcpClosed();
                    this.Finish();
                };

                //editUserId = FindViewById<EditText>(Resource.Id.editUserId);
                editPassword = FindViewById<EditText>(Resource.Id.editPassword);

                vibrator = this.GetSystemService(VibratorService) as Vibrator;
                editPassword.RequestFocus();
            }
            catch (Exception ex)
            {
                clsGLB.ShowMessage(ex.Message, this, MessageTitle.ERROR);
            }
        }
        public override void OnBackPressed()
        {
        }

        private void BtnLogin_Click(object sender, EventArgs e)
        {
            try
            {
               
                if (string.IsNullOrEmpty(editPassword.Text.Trim()))
                {
                    Toast.MakeText(this, "Input password", ToastLength.Long).Show();
                    editPassword.RequestFocus();
                    return;
                }
                ValidateUser();
            }
            catch (Exception ex)
            {
                clsGLB.ShowMessage(ex.Message, this, MessageTitle.ERROR);
            }
        }
        private void ValidateUser()
        {
            try
            {
                string _MESSAGE = "V_UNMAPPEDUSER~" + editPassword.Text.Trim() + "}";
                string[] _RESPONSE = oNetwork.fnSendReceiveData(_MESSAGE).Split('~');
                switch (_RESPONSE[0])
                {
                    case "VALID":
                        if (_RESPONSE[1] == "OK")
                        {
                            editPassword.Text = "";
                            OpenActivity(typeof(UnmappedPackingActivity));
                        }
                        else
                        {
                            StartPlayingSound();
                            ShowMessageBox(_RESPONSE[1], this);
                        }

                        break;

                    case "INVALID":
                        editPassword.Text = "";
                        editPassword.RequestFocus();
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

        public void ShowConfirmBox(string msg, Activity activity)
        {
            Android.App.AlertDialog.Builder builder = new Android.App.AlertDialog.Builder(activity);
            builder.SetTitle("Message");
            builder.SetMessage(msg);
            builder.SetCancelable(false);
            builder.SetPositiveButton("Yes", handllerOkButton);
            builder.SetNegativeButton("No", handllerCancelButton);
            builder.Show();
        }
        void handllerOkButton(object sender, DialogClickEventArgs e)
        {
            this.FinishAffinity();
        }
        void handllerCancelButton(object sender, DialogClickEventArgs e)
        {

        }
        //This MessageBox Will Be Used As User Click Ok To Stop The Sound
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
    }
}