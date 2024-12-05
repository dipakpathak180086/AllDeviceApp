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

namespace UPOnlineExciseDispApp
{
    [Activity(Label = "UP Online Excise App", WindowSoftInputMode = SoftInput.StateHidden, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation, ScreenOrientation = ScreenOrientation.Portrait)]
    public class MainActivity : AppCompatActivity
    {
        clsGlobal clsGLB;
        clsNetwork oNetwork;
        MediaPlayer mediaPlayerSound;
        Vibrator vibrator;
        Button btnDispatch, btnVerifiyPackaging,btnRework, btnManualPackaging, btnUnmappedPackaging;
        public MainActivity()
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
                SetContentView(Resource.Layout.activity_main);

                btnDispatch = FindViewById<Button>(Resource.Id.btnDispatch);
                btnDispatch.Click += BtnDispatch_Click;

                btnRework = FindViewById<Button>(Resource.Id.btnRework);
                btnRework.Click += btnRework_Click;

                btnVerifiyPackaging = FindViewById<Button>(Resource.Id.btnVerifiyPackaging);
                btnVerifiyPackaging.Click += btnVerifiyPackaging_Click;

                btnManualPackaging = FindViewById<Button>(Resource.Id.btnManualPacking);
                btnManualPackaging.Click += BtnManualPackaging_Click;

                btnUnmappedPackaging = FindViewById<Button>(Resource.Id.btnUnmappedPackaging);
                btnUnmappedPackaging.Click += btnUnmappedPackaging_Click;

                Button btnBack = FindViewById<Button>(Resource.Id.btnBack);
                btnBack.Click += (e, a) =>
                {
                    oNetwork.TcpClosed();
                    this.Finish();
                };

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
        private void BtnDispatch_Click(object sender, EventArgs e)
        {
            try
            {
               OpenActivity(typeof(DispatchActivity));
            }
            catch (Exception ex)
            {
                clsGLB.ShowMessage(ex.Message, this, MessageTitle.ERROR);
            }
        }
        private void btnVerifiyPackaging_Click(object sender, EventArgs e)
        {
            try
            {
                OpenActivity(typeof(VerifyPackingActivity));
            }
            catch (Exception ex)
            {
                clsGLB.ShowMessage(ex.Message, this, MessageTitle.ERROR);
            }
        }
        private void btnRework_Click(object sender, EventArgs e)
        {
            try
            {
                OpenActivity(typeof(ReworkActivity));
            }
            catch (Exception ex)
            {
                clsGLB.ShowMessage(ex.Message, this, MessageTitle.ERROR);
            }
        }
        private void BtnManualPackaging_Click(object sender, EventArgs e)
        {
            try
            {
                OpenActivity(typeof(StartPackagingActivity));
            }
            catch (Exception ex)
            {
                clsGLB.ShowMessage(ex.Message, this, MessageTitle.ERROR);
            }
        }

        private void btnUnmappedPackaging_Click(object sender, EventArgs e)
        {
            try
            {
                OpenActivity(typeof(StartUnmappingActivity));
            }
            catch (Exception ex)
            {
                clsGLB.ShowMessage(ex.Message, this, MessageTitle.ERROR);
            }
        }


        #endregion

        #region Methods


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

        #endregion
    }
}