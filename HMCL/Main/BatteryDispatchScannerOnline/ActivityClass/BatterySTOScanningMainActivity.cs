using Android.App;
using Android.OS;
using Android.Support.V7.App;
using Android.Runtime;
using Android.Widget;
using Android.Content.PM;
using Android.Views;
using BatteryDispatchScannerOnline;
using Android.Content;
using System;
using System.IO;
using BatteryDispatchScannerOnline;
using BatteryDispatchScannerOnline.ActivityClass;
using System.Collections.Generic;
using BatteryDispatchScannerOnline;
using Android.Media;
using System.Threading.Tasks;
using Android;
using System.Threading;

namespace BatteryDispatchScannerOnline
{
    [Activity(Label = "BatteryScanning", WindowSoftInputMode = SoftInput.StateHidden, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation, ScreenOrientation = ScreenOrientation.Portrait)]
    public class BatterySTOScanningMainActivity : AppCompatActivity
    {
        clsGlobal clsGLB;
        //ModNet modnet;
        //ModFunctions modfunction;
        EditText txtDeliveryNo;
        MediaPlayer mediaPlayerSound;
       // Vibrator vibrator;
        Button ServerSettings;

        const int RequestId = 1;

        readonly string[] PermissionsGroup =
            {
                            //TODO add more permissions
                            Manifest.Permission.ReadExternalStorage,
                            Manifest.Permission.WriteExternalStorage,
             };
        private void allowThePermission()
        {
            RequestPermissions(PermissionsGroup, RequestId);
        }
        async void GetPermissionDataAsync(object sender, DialogClickEventArgs e)
        {
            var progressDialog = ProgressDialog.Show(this, "", "Please wait...", true);
            try
            {
                await Task.Run(() => allowThePermission());
            }
            catch (Exception)
            {
                progressDialog.Hide();
                throw;
            }
            finally
            {
                progressDialog.Hide();
            }


        }

        public BatterySTOScanningMainActivity()
        {
            try
            {
                clsGLB = new clsGlobal();
                clsGlobal.mEnterDelivery = "";
                //modnet = new ModNet();
                //modfunction = new ModFunctions();
                //oNetwork = new clsNetwork();
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
                SetContentView(Resource.Layout.activity_MainBatterySTOScanning);

                txtDeliveryNo = FindViewById<EditText>(Resource.Id.editDelivery);
                txtDeliveryNo.Text = "";
                txtDeliveryNo.KeyPress += TxtDeliveryNo_KeyPress; ;
                Button btn = FindViewById<Button>(Resource.Id.btnBack);
                btn.Click += Btn_Click;
                Button btnView = FindViewById<Button>(Resource.Id.btnView);
                btnView.Click += BtnView_Click;
                txtDeliveryNo.RequestFocus();

            }
            catch (Exception ex)
            {
                clsGLB.ShowMessage(ex.Message, this, MessageTitle.ERROR);
            }
        }

        private void TxtDeliveryNo_KeyPress(object sender, View.KeyEventArgs e)
        {
            try
            {
                if (e.Event.Action == KeyEventActions.Down)
                {
                    if (e.KeyCode == Keycode.Enter)
                    {
                        if (txtDeliveryNo.Text.Length != 9)
                        {
                            clsGLB.showToastNGMessage("Invalid Delivery No.", this);
                            SoundForNG();
                            return;
                        }
                        if (txtDeliveryNo.Text.Length > 0)
                        {
                            clsGlobal.mEnterDelivery = txtDeliveryNo.Text.Trim();
                            if (!ModNet.FetchBatteryDeliverySTOData(txtDeliveryNo.Text.Trim()))
                            {
                                clsGLB.showToastNGMessage(ModInit.Gstrarr[0], this);
                                SoundForNG();
                                return;
                            }

                            this.Finish();
                            OpenActivity(typeof(BatterySTOScanning));
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

        private void BtnView_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtDeliveryNo.Text.Length > 0)
                {
                    
                    clsGlobal.mEnterDelivery = txtDeliveryNo.Text.Trim();
                    if (!ModNet.FetchBatteryDeliverySTOData(txtDeliveryNo.Text.Trim()))
                    {
                        clsGLB.showToastNGMessage(ModInit.Gstrarr[0], this);
                        SoundForNG();
                        return;
                    }
                   
                    this.Finish();
                    OpenActivity(typeof(BatterySTOScanning));
                }
            }
            catch (Exception ex)
            {
                clsGLB.ShowMessage(ex.Message, this, MessageTitle.ERROR);
            }
        }

        private void Btn_Click(object sender, EventArgs e)
        {
            try
            {
                this.Finish();
                //OpenActivity(typeof(MainActivity));
            }
            catch (Exception ex)
            {
                clsGLB.ShowMessage(ex.Message, this, MessageTitle.ERROR);
            }
        }

        #region Methods


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
            //this.FinishAffinity();

            //System.Diagnostics.Process.GetCurrentProcess().CloseMainWindow();
            Android.OS.Process.KillProcess(Android.OS.Process.MyPid());
        }
        void handllerCancelButton(object sender, DialogClickEventArgs e)
        {

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
        private void SoundForNG()
        {
            try
            {
                Task.Run(() =>
                {
                    StartPlayingSound();
                    Thread.Sleep(3000);
                    StopPlayingSound();
                });

            }
            catch (Exception ex) { throw ex; }
        }

        void handleOkMessage(object sender, DialogClickEventArgs e)
        {
            try
            {
                //vibrator.Cancel();
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
                ////Start Vibration
                //long[] pattern = { 0, 200, 0 }; //0 to start now, 200 to vibrate 200 ms, 0 to sleep for 0 ms.
                //vibrator.Vibrate(pattern, 0);//

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

        public override void OnBackPressed()
        {
            ShowConfirmBox("Do you want to exit", this);
        }


    }
}