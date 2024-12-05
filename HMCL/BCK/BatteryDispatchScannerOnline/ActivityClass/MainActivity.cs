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

namespace BatteryDispatchScannerOnline
{
    [Activity(Label = "BatteryScanning", MainLauncher = true, WindowSoftInputMode = SoftInput.StateHidden, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation, ScreenOrientation = ScreenOrientation.Portrait)]
    public class MainActivity : AppCompatActivity
    {
        clsGlobal clsGLB;
        //ModNet modnet;
        //ModFunctions modfunction;
        MediaPlayer mediaPlayerSound;
        Vibrator vibrator;
        Button btnReceipt;
        Button btnMarking;
        Button btnDispatch;
        Button btnBatteryScanning,btnReverseDelivery,btnBatterySTOScanning;
        Button ServerSettings;
        TextView lblVersion;
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

        public MainActivity()
        {
            try
            {
                clsGLB = new clsGlobal();
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
                SetContentView(Resource.Layout.activity_main);

                if ((int)Build.VERSION.SdkInt >= 23)
                {
                    allowThePermission();
                }

             

                btnBatteryScanning = FindViewById<Button>(Resource.Id.btnBattteryScanning);
                btnBatteryScanning.Click += BtnBatteryScanning_Click;

                btnBatterySTOScanning= FindViewById<Button>(Resource.Id.btnBatterySTOScanning);
                btnBatterySTOScanning.Click += BtnBatterySTOScanning_Click;


                btnReverseDelivery = FindViewById<Button>(Resource.Id.btnReverseDelivery);
                btnReverseDelivery.Click += BtnReverseDelivery_Click;

                ServerSettings = FindViewById<Button>(Resource.Id.btnServerSettings);
                ServerSettings.Click += ServerSettings_Click;
                ServerSettings.Visibility = ViewStates.Invisible;


                Context context = this.ApplicationContext;
                string _AppVersion = context.PackageManager.GetPackageInfo(context.PackageName, 0).VersionName;

                lblVersion = FindViewById<TextView>(Resource.Id.lblVersion);
                lblVersion.Text = "App. Version: " + _AppVersion;

                vibrator = this.GetSystemService(VibratorService) as Vibrator;

                if (!File.Exists(Path.Combine(ModInit.GstrPath, "Server.SYS")))
                    OpenActivity(typeof(SettingActivity));
                else
                    ReadServerIP();
                if (ModNet.InitializeTCPClient() != 0)
                {
                    clsGLB.ShowMessage("Comm Server Not Connected, Please Resatrt the Application", this, MessageTitle.ERROR);
                }
            }
            catch (Exception ex)
            {
                clsGLB.ShowMessage(ex.Message, this, MessageTitle.ERROR);
            }
        }

        private void BtnBatterySTOScanning_Click(object sender, EventArgs e)
        {
            try
            {
                OpenActivity(typeof(STOBatteryScanning));
            }
            catch (Exception ex)
            {
                clsGLB.ShowMessage(ex.Message, this, MessageTitle.ERROR);
            }
        }

        private void BtnReverseDelivery_Click(object sender, EventArgs e)
        {
            try
            {
                OpenActivity(typeof(ReverseDelivery));
            }
            catch (Exception ex)
            {
                clsGLB.ShowMessage(ex.Message, this, MessageTitle.ERROR);
            }
        }

        private void ServerSettings_Click(object sender, EventArgs e)
        {
            try
            {
                OpenActivity(typeof(SettingActivity));
            }
            catch (Exception ex)
            {
                clsGLB.ShowMessage(ex.Message, this, MessageTitle.ERROR);
            }
        }

        private void BtnMarking_Click(object sender, EventArgs e)
        {
            try
            {
                //OpenActivity(typeof(Marking));
            }
            catch (Exception ex)
            {
                clsGLB.ShowMessage(ex.Message, this, MessageTitle.ERROR);
            }
        }

        private void BtnReceipt_Click(object sender, EventArgs e)
        {
            try
            {
               // OpenActivity(typeof(Receipt));
            }
            catch (Exception ex)
            {
                clsGLB.ShowMessage(ex.Message, this, MessageTitle.ERROR);
            }
        }

        private void BtnDispatch_Click(object sender, EventArgs e)
        {
            try
            {
                //OpenActivity(typeof(Dispatch));
            }
            catch (Exception ex)
            {
                clsGLB.ShowMessage(ex.Message, this, MessageTitle.ERROR);
            }
        }
        private void BtnBatteryScanning_Click(object sender, EventArgs e)
        {
            try
            {
                OpenActivity(typeof(BatteryScanningMainActivity));
            }
            catch (Exception ex)
            {
                clsGLB.ShowMessage(ex.Message, this, MessageTitle.ERROR);
            }
        }
        public bool ReadServerIP()
        {
            try
            {
                string filename = Path.Combine(ModInit.GstrPath, "Server.SYS");
                FileInfo ServerFile = new FileInfo(filename);
                StreamReader ReadServer;
                string[] strCon;
                if (ServerFile.Exists == true)
                {
                    ReadServer = new StreamReader(filename);
                    strCon = ReadServer.ReadLine().Split("~");
                    if (strCon.Length >= 1)
                    {
                        ModInit.GstrServerIP = strCon[0];
                        ModInit.GintServerPort = Convert.ToInt32(strCon[1].Trim());
                        ModInit.GstrMarkingLocation = strCon[2];
                    }
                    else
                    {
                        ReadServer.Close();
                        ReadServer = null;
                        ServerFile = null;
                        return false;
                    }
                    ReadServer.Close();
                    ReadServer = null;
                    ServerFile = null;
                    return true;
                }
                else
                {
                    ServerFile = null;
                    return false;
                }
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public void WriteServerIP()
        {
            try
            {
                string filename = Path.Combine(ModInit.GstrPath, "Server.SYS");
                StreamWriter WriteServer = new StreamWriter(filename, false);
                //WriteServer.WriteLine(ModInit.GstrServerIP + "~" + ModInit.GintServerPort);
                WriteServer.WriteLine("10.30.51.117" + "~" + "5100");
                WriteServer.Close();
                WriteServer = null;
            }
            catch (Exception ex)
            {
                throw ex;
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

        public override void OnBackPressed()
        {
            ShowConfirmBox("Do you want to exit", this);
        }


    }
}