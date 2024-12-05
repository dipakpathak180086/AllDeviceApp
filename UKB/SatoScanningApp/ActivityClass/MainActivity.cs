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
        Button btnTagMapping,btnTagUnMapping,btnIN, btnOut,btnStockTake, btnTagViewData;
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

                ImageView imgBack = FindViewById<ImageView>(Resource.Id.imgBack);
                imgBack.Click += (e, a) =>
                {
                    this.Finish();
                };

                TextView txtHeader = FindViewById<TextView>(Resource.Id.txtHeader);
                txtHeader.Text = "MENU";

                btnTagMapping = FindViewById<Button>(Resource.Id.btnTagMapping);
                btnTagMapping.Click += BtnTagMapping_Click;


                btnTagUnMapping = FindViewById<Button>(Resource.Id.btnTagUnMapping);
                btnTagUnMapping.Click += BtnTagUnMapping_Click;

                btnIN = FindViewById<Button>(Resource.Id.btnInReceive);
                btnIN.Click += BtnIN_Click;

                btnOut = FindViewById<Button>(Resource.Id.btnOutDispatch);
                btnOut.Click += BtnOut_Click;

                btnStockTake = FindViewById<Button>(Resource.Id.btnStockTake);
                btnStockTake.Click += BtnStockTake_Click; ;

                btnTagViewData = FindViewById<Button>(Resource.Id.btnTagViewData);
                btnTagViewData.Click += btnTagViewData_Click; ;

                
                //if (clsGlobal.UserGroup.Trim().ToUpper() != "ADMIN")
                //{
                //    DisableMenus();
                //    GetUserRight();
                //}

                vibrator = this.GetSystemService(VibratorService) as Vibrator;
               
            }
            catch (Exception ex)
            {
                clsGLB.ShowMessage(ex.Message, this, MessageTitle.ERROR);
            }
        }

        private void BtnTagUnMapping_Click(object sender, EventArgs e)
        {
            try
            {
                clsGlobal.ProcessType = "TAG UNMAPPING";
                OpenActivity(typeof(TagUnMappingActivity));
            }
            catch (Exception ex)
            {
                clsGLB.ShowMessage(ex.Message, this, MessageTitle.ERROR);
            }
        }

        private void btnTagViewData_Click(object sender, EventArgs e)
        {
            try
            {
                clsGlobal.ProcessType = "TAG VIEW DATA";
                OpenActivity(typeof(TagViewActivity));
            }
            catch (Exception ex)
            {
                clsGLB.ShowMessage(ex.Message, this, MessageTitle.ERROR);
            }
        }

        private void BtnTagMapping_Click(object sender, EventArgs e)
        {
            try
            {
                clsGlobal.ProcessType = "TAG MAPPING";
                OpenActivity(typeof(TagMappingActivity));
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
        private void BtnOut_Click(object sender, EventArgs e)
        {
            try
            {
                clsGlobal.ProcessType = "OUT";
                OpenActivity(typeof(DirectDispatchActivity));
            }
            catch (Exception ex)
            {
                clsGLB.ShowMessage(ex.Message, this, MessageTitle.ERROR);
            }
        }

        private void BtnIN_Click(object sender, EventArgs e)
        {
            try
            {
                clsGlobal.ProcessType = "IN";
                OpenActivity(typeof(ReceivingActivity));
            }
            catch (Exception ex)
            {
                clsGLB.ShowMessage(ex.Message, this, MessageTitle.ERROR);
            }
        }
        private void BtnStockTake_Click(object sender, EventArgs e)
        {
            try
            {
              
                OpenActivity(typeof(StockTakeActivity));
            }
            catch (Exception ex)
            {
                clsGLB.ShowMessage(ex.Message, this, MessageTitle.ERROR);
            }
        }
        #endregion

        #region Methods

        private void DisableMenus()
        {
            try
            {
                btnIN.Enabled = btnOut.Enabled = false;
            }
            catch (Exception ex)
            {
                clsGLB.ShowMessage(ex.Message, this, MessageTitle.ERROR);
            }
        }
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
                                case "201":
                                    btnIN.Enabled = true;
                                    break;
                                case "202":
                                    btnOut.Enabled = true;
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