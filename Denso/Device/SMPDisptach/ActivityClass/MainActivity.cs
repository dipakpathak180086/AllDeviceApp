using Android;
using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.Media;
using Android.OS;
using Android.Support.V7.App;
using Android.Views;
using Android.Widget;
using SMPDisptach.ActivityClass;
using System;
using System.IO;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Timers;
using Java.Sql;
using System.Data;
namespace SMPDisptach
{
    [Activity(Label = "SMPDisptach", WindowSoftInputMode = SoftInput.StateHidden, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation, ScreenOrientation = ScreenOrientation.Portrait)]
    public class MainActivity : AppCompatActivity
    {
        clsGlobal clsGlobal;
        //ModNet modnet;
        //ModFunctions modfunction;
        MediaPlayer mediaPlayerSound;
        Vibrator vibrator;
        Timer timer;
        TextView txtDate;
        TextView txtTime;
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

        public MainActivity()
        {
            try
            {
                //clsGlobal = new clsGlobal();
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
        public bool ReadFTPSetting()
        {
            try
            {
                string filename = Path.Combine(clsGlobal.FilePath, "FTPSetting.txt");
                FileInfo FTPServerFile = new FileInfo(filename);
                StreamReader ReadServer;
                string[] strCon;
                if (FTPServerFile.Exists == true)
                {
                    ReadServer = new StreamReader(filename);
                    strCon = ReadServer.ReadLine().Split("~");
                    if (strCon.Length >= 1)
                    {
                        clsGlobal.mWarehouseNo = strCon[0].Trim();
                        clsGlobal.mDeviceID = strCon[1].Trim();
                        clsGlobal.mFTPIP = strCon[2].Trim();
                        clsGlobal.mFTPUserID = strCon[3].Trim();
                        clsGlobal.mFTPPassword = strCon[4].Trim();
                    }
                    else
                    {
                        ReadServer.Close();
                        ReadServer = null;
                        FTPServerFile = null;
                        return false;
                    }
                    ReadServer.Close();
                    ReadServer = null;
                    FTPServerFile = null;
                    return true;
                }
                else
                {
                    FTPServerFile = null;
                    return false;
                }
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        protected void MasterSyncAll(object sender, DialogClickEventArgs e)
        {
            var progressDialog =  ProgressDialog.Show(this, "", "Please Wait....", true);
          

            try
            {
                DirectoryInfo _dir = null;
                _dir = new DirectoryInfo(clsGlobal.FilePath  +"//"+ clsGlobal.MasterFolder);
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
                    string strFinaPath = Path.Combine(clsGlobal.FilePath,  clsGlobal.MasterFolder + "//DNHA_PART_DATA.txt");
                    clsGlobal.ConvertDataTableToTxt(dtData, strFinaPath);

                }
                _plObj = new PL_HHT_UPLOAD();
                _plObj.DbType = "SUP_PART_LIST";
                dtData = _blObj.BL_ExecuteTask(_plObj);
                if (dtData.Rows.Count > 0)
                {
                    string strFinaPath = Path.Combine(clsGlobal.FilePath,   clsGlobal.MasterFolder + "//SUP_PART_DATA.txt");
                    clsGlobal.ConvertDataTableToTxt(dtData, strFinaPath);

                }
                _plObj = new PL_HHT_UPLOAD();
                _plObj.DbType = "CUST_PART_LIST";
                dtData = _blObj.BL_ExecuteTask(_plObj);
                if (dtData.Rows.Count > 0)
                {
                    string strFinaPath = Path.Combine(clsGlobal.FilePath,   clsGlobal.MasterFolder + "//CUST_PART_DATA.txt");
                    clsGlobal.ConvertDataTableToTxt(dtData, strFinaPath);

                }
                _plObj = new PL_HHT_UPLOAD();
                _plObj.DbType = "DNHA_PATTERN_LIST";
                dtData = _blObj.BL_ExecuteTask(_plObj);
                if (dtData.Rows.Count > 0)
                {
                    string strFinaPath = Path.Combine(clsGlobal.FilePath,   clsGlobal.MasterFolder + "//" + clsGlobal.mPatternPath + "//" +clsGlobal.mDNHADir + "//DNHA_PATTERN_DATA.txt");
                    clsGlobal.ConvertDataTableToTxt(dtData, strFinaPath);

                }
                _plObj.DbType = "SUPPLIER_PATTERN_LIST";
                dtData = _blObj.BL_ExecuteTask(_plObj);
                if (dtData.Rows.Count > 0)
                {
                    string strFinaPath = Path.Combine(clsGlobal.FilePath,  clsGlobal.MasterFolder + "//" + clsGlobal.mPatternPath + "//" + clsGlobal.mSupplierDir + "//SUPPLIER_PATTERN_DATA.txt");
                    clsGlobal.ConvertDataTableToTxt(dtData, strFinaPath);

                }
                _plObj.DbType = "CUSTOMER_PATTERN_LIST";
                dtData = _blObj.BL_ExecuteTask(_plObj);
                if (dtData.Rows.Count > 0)
                {
                    string strFinaPath = Path.Combine(clsGlobal.FilePath,  clsGlobal.MasterFolder + "//" + clsGlobal.mPatternPath + "//" + clsGlobal.mCustomerDir + "//CUSTOMER_PATTERN_DATA.txt");
                    clsGlobal.ConvertDataTableToTxt(dtData, strFinaPath);

                }
                _plObj.DbType = "ALERT_PASSWORD";
                dtData = _blObj.BL_ExecuteTask(_plObj);
                if (dtData.Rows.Count > 0)
                {
                    string strFinaPath = Path.Combine(clsGlobal.FilePath,  clsGlobal.MasterFolder + "//ALERT_PASS.txt");
                    clsGlobal.ConvertDataTableToTxt(dtData, strFinaPath);

                }
                _plObj.DbType = "NG_LOT_LIST";
                dtData = _blObj.BL_ExecuteTask(_plObj);
                if (dtData.Rows.Count > 0)
                {
                    string strFinaPath = Path.Combine(clsGlobal.FilePath,  clsGlobal.MasterFolder + "//NG_PART_DATA.txt");
                    clsGlobal.ConvertDataTableToTxt(dtData, strFinaPath);

                }

               
                clsGlobal.ShowMessage($"All Master Data Sync Successfully!!!", this, MessageTitle.INFORMATION);
                progressDialog.Hide();
            }
            catch (Exception ex)
            {
               
                clsGlobal.ShowMessage(ex.Message, this, MessageTitle.ERROR);
                progressDialog.Hide();
            }
        }
        protected override void OnCreate(Bundle savedInstanceState)
        {
            try
            {
                base.OnCreate(savedInstanceState);
                // Set our view from the "main" layout resource
                SetContentView(Resource.Layout.activity_main);

                //SqlConnection con = new SqlConnection("Server=10.91.4.3;Database=SATO_DENSO_SMART_PASS;User Id=sa;Password=sato@123;Encrypt=False;");
                //con.Open();

                Button btnSILRegistration = FindViewById<Button>(Resource.Id.btnSILRegister);
                btnSILRegistration.Click += BtnSILRegistration_Click;

                Button btnSILScanning = FindViewById<Button>(Resource.Id.btnSILScanning);
                btnSILScanning.Click += btnSILScanning_Click;

                Button btnSILDelete = FindViewById<Button>(Resource.Id.btnSILDelete);
                btnSILDelete.Click += btnSILDelete_Click;


                Button btnFTPTransfer = FindViewById<Button>(Resource.Id.btnFTPTransfer);
                btnFTPTransfer.Click += BtnFTPTransfer_Click;

                Button btnFraction = FindViewById<Button>(Resource.Id.btnFraction);
                btnFraction.Click += BtnFraction_Click;

                Button btnReversal = FindViewById<Button>(Resource.Id.btnReversal);
                btnReversal.Click += BtnReversal_Click;




                ReadFTPSetting();
                clsGlobal.ReadServerSetting();
                txtDate = FindViewById<TextView>(Resource.Id.txtDate);
                txtTime = FindViewById<TextView>(Resource.Id.txtTime);

                timer = new Timer();
                timer.Interval = 1000; // 1 second
                timer.Elapsed += Timer_Elapsed;
                timer.Start();

                vibrator = this.GetSystemService(VibratorService) as Vibrator;


            }
            catch (Exception ex)
            {
                clsGlobal.ShowMessage(ex.Message, this, MessageTitle.ERROR);
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

        private void btnSILDelete_Click(object sender, EventArgs e)
        {
            try
            {
                OpenActivity(typeof(SILDelete));
            }
            catch (Exception ex)
            {
                clsGlobal.ShowMessage(ex.Message, this, MessageTitle.ERROR);
            }
        }

        private void BtnFTPTransfer_Click(object sender, EventArgs e)
        {
            try
            {
                OpenActivity(typeof(FTPFileTransfer));
            }
            catch (Exception ex)
            {
                clsGlobal.ShowMessage(ex.Message, this, MessageTitle.ERROR);
            }
        }

        private void BtnSILRegistration_Click(object sender, EventArgs e)
        {
            try
            {
                OpenActivity(typeof(SILRegistration));
            }
            catch (Exception ex)
            {
                clsGlobal.ShowMessage(ex.Message, this, MessageTitle.ERROR);
            }
        }


        private void btnSILScanning_Click(object sender, EventArgs e)
        {
            try
            {
                OpenActivity(typeof(SILScanning));
            }
            catch (Exception ex)
            {
                clsGlobal.ShowMessage(ex.Message, this, MessageTitle.ERROR);
            }
        }
        private void BtnFraction_Click(object sender, EventArgs e)
        {
            try
            {
                OpenActivity(typeof(Fraction));
            }
            catch (Exception ex)
            {
                clsGlobal.ShowMessage(ex.Message, this, MessageTitle.ERROR);
            }
        }
        private void BtnReversal_Click(object sender, EventArgs e)
        {
            try
            {
                OpenActivity(typeof(Reversal));
            }
            catch (Exception ex)
            {
                clsGlobal.ShowMessage(ex.Message, this, MessageTitle.ERROR);
            }
        }
        private void BtnMasterSync_Click(object sender, EventArgs e)
        {
            try
            {
              
                ShowConfirmBox($"Are you sure want to sync all master data?", this, MasterSyncAll);

            }
            catch (Exception ex)
            {
                clsGlobal.ShowMessage(ex.Message, this, MessageTitle.ERROR);
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
                clsGlobal.ShowMessage(ex.Message, this, MessageTitle.ERROR);
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
            timer.Stop();
            timer.Dispose();
        }

    }
}