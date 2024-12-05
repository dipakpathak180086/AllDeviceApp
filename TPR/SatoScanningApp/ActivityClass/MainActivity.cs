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
using SatoScanningApp.ActivityClass;
using System.Collections.Generic;
using Android.Media;
using IOCLAndroidApp.Models;

namespace SatoScanningApp
{
    [Activity(Label = "Sato ScanningApp", WindowSoftInputMode = SoftInput.StateHidden, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation, ScreenOrientation = ScreenOrientation.Portrait)]
    public class MainActivity : AppCompatActivity
    {
        clsGlobal clsGLB;
        clsNetwork oNetwork;
        MediaPlayer mediaPlayerSound;
        Vibrator vibrator;
        Button btnDispatch, btnFinalPacking, btnMachining, btnMachiningSplit, btnTrolleyReceiving, btnReOiling, btnAddPrintTrolley,btnTrolleyExchange;
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
                btnDispatch.Enabled = false;

                btnFinalPacking = FindViewById<Button>(Resource.Id.btnFinalPacking);
                btnFinalPacking.Click += btnFinalPacking_Click;
                btnFinalPacking.Enabled = false;

                btnMachining = FindViewById<Button>(Resource.Id.btnMachining);
                btnMachining.Click += btnMachining_Click;
                btnMachining.Enabled = false;

                btnMachiningSplit = FindViewById<Button>(Resource.Id.btnMachiningSplit);
                btnMachiningSplit.Click += btnMachiningSplit_Click;
                btnMachiningSplit.Enabled = false;

                btnReOiling = FindViewById<Button>(Resource.Id.btnReOiling);
                btnReOiling.Click += btnReOiling_Click;
                btnReOiling.Enabled = false;

                btnTrolleyReceiving = FindViewById<Button>(Resource.Id.btnTrolleyReceiving);
                btnTrolleyReceiving.Click += btnTrolleyReceiving_Click;
                btnTrolleyReceiving.Enabled = false;

                btnAddPrintTrolley = FindViewById<Button>(Resource.Id.btnAddPrintTrolley);
                btnAddPrintTrolley.Click += btnAddPrintTrolley_Click;
                //btnAddPrintTrolley.Enabled = false;

                btnTrolleyExchange = FindViewById<Button>(Resource.Id.btnTrolleyExchange);
                btnTrolleyExchange.Click += btnTrolleyExchange_Click;

                Button btnBack = FindViewById<Button>(Resource.Id.btnBack);
                btnBack.Click += (e, a) =>
                {
                    this.Finish();
                };

                vibrator = this.GetSystemService(VibratorService) as Vibrator;

                GetUserRight();
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

        private void btnAddPrintTrolley_Click(object sender, EventArgs e)
        {
            try
            {
                OpenActivity(typeof(AddPrintTrolleyActivity));
            }
            catch (Exception ex)
            {
                clsGLB.ShowMessage(ex.Message, this, MessageTitle.ERROR);
            }
        }

        private void btnFinalPacking_Click(object sender, EventArgs e)
        {
            try
            {
                OpenActivity(typeof(FinalPackingActivity));
            }
            catch (Exception ex)
            {
                clsGLB.ShowMessage(ex.Message, this, MessageTitle.ERROR);
            }
        }

        private void btnMachining_Click(object sender, EventArgs e)
        {
            try
            {
                OpenActivity(typeof(MachiningActivity));
            }
            catch (Exception ex)
            {
                clsGLB.ShowMessage(ex.Message, this, MessageTitle.ERROR);
            }
        }
        private void btnMachiningSplit_Click(object sender, EventArgs e)
        {
            try
            {
                OpenActivity(typeof(MachiningSplitActivity));
            }
            catch (Exception ex)
            {
                clsGLB.ShowMessage(ex.Message, this, MessageTitle.ERROR);
            }
        }
        private void btnReOiling_Click(object sender, EventArgs e)
        {
            try
            {
                OpenActivity(typeof(ReOilingActivity));
            }
            catch (Exception ex)
            {
                clsGLB.ShowMessage(ex.Message, this, MessageTitle.ERROR);
            }
        }

        private void btnTrolleyReceiving_Click(object sender, EventArgs e)
        {
            try
            {
                OpenActivity(typeof(TrolleyReceivingActivity));
            }
            catch (Exception ex)
            {
                clsGLB.ShowMessage(ex.Message, this, MessageTitle.ERROR);
            }
        }
        private void btnTrolleyExchange_Click(object sender, EventArgs e)
        {
            try
            {
                OpenActivity(typeof(TrolleyExchangeActivity));
            }
            catch (Exception ex)
            {
                clsGLB.ShowMessage(ex.Message, this, MessageTitle.ERROR);
            }
        }
        #endregion

        #region Methods

        private void GetUserRight()
        {
            try
            {
                string _MESSAGE = "GET_USER_RIGHT~" + clsGlobal.UserGroup + "}";
                string[] _RESPONSE = oNetwork.fnSendReceiveData(_MESSAGE).Split('~');
                switch (_RESPONSE[0])
                {
                    case "VALID":
                        string[] sArr = _RESPONSE[1].Split('#');
                        for (int i = 0; i < sArr.Length; i++)
                        {
                            switch (sArr[i])
                            {
                                case "206":
                                    btnMachining.Enabled = true;
                                    btnMachiningSplit.Enabled = true;
                                    break;
                                case "207":
                                    btnFinalPacking.Enabled = true;
                                    break;
                                case "208":
                                    btnDispatch.Enabled = true;
                                    break;
                                case "209":
                                    btnTrolleyReceiving.Enabled = true;
                                    break;
                                case "213":
                                    btnReOiling.Enabled = true;
                                    break;
                                default:
                                    break;
                            }
                        }
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