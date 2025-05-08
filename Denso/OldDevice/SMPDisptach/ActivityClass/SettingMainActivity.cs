using Android.App;
using Android.OS;
using Android.Support.V7.App;
using Android.Runtime;
using Android.Widget;
using Android.Content.PM;
using Android.Views;
using SMPDisptach;
using Android.Content;
using System;
using System.IO;
using SMPDisptach;
using SMPDisptach.ActivityClass;
using System.Collections.Generic;
using Android.Media;
using System.Threading.Tasks;
using Android;
using System.Timers;
using Java.Sql;
using System.Data;
namespace SMPDisptach
{
    [Activity(Label = "SMPDisptach", WindowSoftInputMode = SoftInput.StateHidden, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation, ScreenOrientation = ScreenOrientation.Portrait)]
    public class SettingMainActivity : AppCompatActivity
    {
        clsGlobal clsGLB;
        //ModNet modnet;
        //ModFunctions modfunction;
        MediaPlayer mediaPlayerSound;
        Vibrator vibrator;
        Timer timer;
        TextView txtDate;
        TextView txtTime;
        ProgressBar editProgressBar;
        const int RequestId = 1;
        private BL_HHT_UPLOAD _blObj = null;
        private PL_HHT_UPLOAD _plObj = null;
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

        public SettingMainActivity()
        {
            try
            {
                clsGLB = new clsGlobal();
                _blObj = new BL_HHT_UPLOAD();
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
                SetContentView(Resource.Layout.activity_Settingmain);




                Button btnFTPSetting = FindViewById<Button>(Resource.Id.btnFTPSetting);
                btnFTPSetting.Click += btnFTPSetting_Click;

                Button btnServerSetting = FindViewById<Button>(Resource.Id.btnServerSetting);
                btnServerSetting.Click += btnServerSetting_Click;

                Button btnMasterSync = FindViewById<Button>(Resource.Id.btnMasterDataSync);
                btnMasterSync.Click += BtnMasterSync_Click;

                editProgressBar = FindViewById<ProgressBar>(Resource.Id.progressBar);
                //Button btnReverseDelivery = FindViewById<Button>(Resource.Id.btnReverseDelivery);
                //btnReverseDelivery.Click += BtnReverseDelivery_Click;
                //ReadFTPSetting();
                clsGlobal.ReadServerSetting();




                vibrator = this.GetSystemService(VibratorService) as Vibrator;


            }
            catch (Exception ex)
            {
                clsGLB.ShowMessage(ex.Message, this, MessageTitle.ERROR);
            }
        }
        private void Timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            // Update the TextView with the current date and time on the UI thread
            RunOnUiThread(() =>
            {
                txtDate.Text = "Date: " + DateTime.Now.ToString("dd/MM/yyyy");
                txtTime.Text = "Time: " + DateTime.Now.ToString("HH:mm:ss");
            });
        }

        private void btnServerSetting_Click(object sender, EventArgs e)
        {
            try
            {
                OpenActivity(typeof(ServerSettingActivity));
            }
            catch (Exception ex)
            {
                clsGLB.ShowMessage(ex.Message, this, MessageTitle.ERROR);
            }
        }


        private void btnFTPSetting_Click(object sender, EventArgs e)
        {
            try
            {
                OpenActivity(typeof(FTPSettingActivity));
            }
            catch (Exception ex)
            {
                clsGLB.ShowMessage(ex.Message, this, MessageTitle.ERROR);
            }
        }
        private  void BtnMasterSync_Click(object sender, EventArgs e)
        {
            try
            {

                ShowConfirmBox($"Are you sure want to sync all master data?", this, MasterSyncAll);

            }
            catch (Exception ex)
            {
                clsGLB.ShowMessage(ex.Message, this, MessageTitle.ERROR);
            }
            finally
            {
            }

        }

        protected async void MasterSyncAll(object sender, DialogClickEventArgs e)
        {
            editProgressBar.Visibility = ViewStates.Visible;


            //var progressDialog = ProgressDialog.Show(this, "", "Please Wait....", true);
            try
            {
                await Task.Run(() =>
                {
                    DirectoryInfo _dir = null;
                    _dir = new DirectoryInfo(clsGlobal.FilePath + "//" + clsGlobal.MasterFolder);
                    if (_dir.Exists == false)
                    {
                        _dir.Create();
                    }
                    _dir = new DirectoryInfo(clsGlobal.FilePath + "//" + clsGlobal.MasterFolder + "//" + clsGlobal.mPatternPath + "//" + clsGlobal.mDNHADir);
                    if (_dir.Exists == false)
                    {
                        _dir.Create();
                    }
                    _dir = new DirectoryInfo(clsGlobal.FilePath + "//" + clsGlobal.MasterFolder + "//" + clsGlobal.mPatternPath + "//" + clsGlobal.mCustomerDir);
                    if (_dir.Exists == false)
                    {
                        _dir.Create();
                    }
                    _dir = new DirectoryInfo(clsGlobal.FilePath + "//" + clsGlobal.MasterFolder + "//" + clsGlobal.mPatternPath + "//" + clsGlobal.mSupplierDir);
                    if (_dir.Exists == false)
                    {
                        _dir.Create();
                    }
                    DataTable dtData = null;
                    _plObj = new PL_HHT_UPLOAD();
                    _plObj.DbType = "USER_LIST";
                    dtData = _blObj.BL_ExecuteTask(_plObj);
                    if (dtData.Rows.Count > 0)
                    {
                        string strFinaPath = Path.Combine(clsGlobal.FilePath, clsGlobal.MasterFolder + "//LOGIN.txt");
                        clsGlobal.ConvertDataTableToTxt(dtData, strFinaPath);

                    }
                    _plObj = new PL_HHT_UPLOAD();
                    _plObj.DbType = "DNHA_PART_LIST";
                    dtData = _blObj.BL_ExecuteTask(_plObj);
                    if (dtData.Rows.Count > 0)
                    {
                        string strFinaPath = Path.Combine(clsGlobal.FilePath, clsGlobal.MasterFolder + "//DNHA_PART_DATA.txt");
                        clsGlobal.ConvertDataTableToTxt(dtData, strFinaPath);

                    }
                    _plObj = new PL_HHT_UPLOAD();
                    _plObj.DbType = "SUP_PART_LIST";
                    dtData = _blObj.BL_ExecuteTask(_plObj);
                    if (dtData.Rows.Count > 0)
                    {
                        string strFinaPath = Path.Combine(clsGlobal.FilePath, clsGlobal.MasterFolder + "//SUP_PART_DATA.txt");
                        clsGlobal.ConvertDataTableToTxt(dtData, strFinaPath);

                    }
                    _plObj = new PL_HHT_UPLOAD();
                    _plObj.DbType = "CUST_PART_LIST";
                    dtData = _blObj.BL_ExecuteTask(_plObj);
                    if (dtData.Rows.Count > 0)
                    {
                        string strFinaPath = Path.Combine(clsGlobal.FilePath, clsGlobal.MasterFolder + "//CUST_PART_DATA.txt");
                        clsGlobal.ConvertDataTableToTxt(dtData, strFinaPath);

                    }
                    _plObj = new PL_HHT_UPLOAD();
                    _plObj.DbType = "DNHA_PATTERN_LIST";
                    dtData = _blObj.BL_ExecuteTask(_plObj);
                    if (dtData.Rows.Count > 0)
                    {
                        string strFinaPath = Path.Combine(clsGlobal.FilePath, clsGlobal.MasterFolder + "//" + clsGlobal.mPatternPath + "//" + clsGlobal.mDNHADir + "//DNHA_PATTERN_DATA.txt");
                        clsGlobal.ConvertDataTableToTxt(dtData, strFinaPath);

                    }
                    _plObj.DbType = "SUPPLIER_PATTERN_LIST";
                    dtData = _blObj.BL_ExecuteTask(_plObj);
                    if (dtData.Rows.Count > 0)
                    {
                        string strFinaPath = Path.Combine(clsGlobal.FilePath, clsGlobal.MasterFolder + "//" + clsGlobal.mPatternPath + "//" + clsGlobal.mSupplierDir + "//SUPPLIER_PATTERN_DATA.txt");
                        clsGlobal.ConvertDataTableToTxt(dtData, strFinaPath);

                    }
                    _plObj.DbType = "CUSTOMER_PATTERN_LIST";
                    dtData = _blObj.BL_ExecuteTask(_plObj);
                    if (dtData.Rows.Count > 0)
                    {
                        string strFinaPath = Path.Combine(clsGlobal.FilePath, clsGlobal.MasterFolder + "//" + clsGlobal.mPatternPath + "//" + clsGlobal.mCustomerDir + "//CUSTOMER_PATTERN_DATA.txt");
                        clsGlobal.ConvertDataTableToTxt(dtData, strFinaPath);

                    }
                    _plObj.DbType = "ALERT_PASSWORD";
                    dtData = _blObj.BL_ExecuteTask(_plObj);
                    if (dtData.Rows.Count > 0)
                    {
                        string strFinaPath = Path.Combine(clsGlobal.FilePath, clsGlobal.MasterFolder + "//ALERT_PASS.txt");
                        clsGlobal.ConvertDataTableToTxt(dtData, strFinaPath);

                    }
                    _plObj.DbType = "NG_LOT_LIST";
                    dtData = _blObj.BL_ExecuteTask(_plObj);
                    if (dtData.Rows.Count > 0)
                    {
                        string strFinaPath = Path.Combine(clsGlobal.FilePath, clsGlobal.MasterFolder + "//NG_PART_DATA.txt");
                        clsGlobal.ConvertDataTableToTxt(dtData, strFinaPath);

                    }

                    //progressDialog.Hide();
                    
                });
                clsGLB.ShowMessage($"All Master Data Sync Successfully!!!", this, MessageTitle.INFORMATION);
            }
            catch (Exception ex)
            {
                //progressDialog.Hide();
                clsGLB.ShowMessage(ex.Message, this, MessageTitle.ERROR);
            }
            finally
            {
                editProgressBar.Visibility = ViewStates.Gone;
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


        public void ShowConfirmBox(string msg, Activity activity, EventHandler<DialogClickEventArgs> handler)
        {
            //scanningComplete = true;
            //SoundForFinalSave();
            Android.App.AlertDialog.Builder builder = new Android.App.AlertDialog.Builder(activity);
            builder.SetTitle("Message");
            builder.SetMessage(msg);
            builder.SetCancelable(false);
            builder.SetPositiveButton("Yes", handler);
            builder.SetNegativeButton("No", handllerCancelButton);
            builder.Show();
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
            this.Finish();

            //System.Diagnostics.Process.GetCurrentProcess().CloseMainWindow();
            //Android.OS.Process.KillProcess(Android.OS.Process.MyPid());
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
        protected override void OnDestroy()
        {
            // Stop and dispose of the timer when the activity is destroyed
            base.OnDestroy();

        }

    }
}