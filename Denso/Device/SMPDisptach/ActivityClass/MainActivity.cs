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
namespace SMPDisptach
{
    [Activity(Label = "SMPDisptach", WindowSoftInputMode = SoftInput.StateHidden, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation, ScreenOrientation = ScreenOrientation.Portrait)]
    public class MainActivity : AppCompatActivity
    {
        clsGlobal clsGLB;
        //ModNet modnet;
        //ModFunctions modfunction;
        MediaPlayer mediaPlayerSound;
        Vibrator vibrator;
        Timer timer;
        TextView txtDate;
        TextView txtTime;
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
        protected override void OnCreate(Bundle savedInstanceState)
        {
            try
            {
                base.OnCreate(savedInstanceState);
                // Set our view from the "main" layout resource
                SetContentView(Resource.Layout.activity_main);

                //SqlConnection con = new SqlConnection("Server=10.91.4.3;Database=SATO_DENSO_SMART_PASS;User Id=sa;Password=sato@123;Encrypt=False;");
                //con.Open();


                Button btnSILScanning = FindViewById<Button>(Resource.Id.btnSILScanning);
                btnSILScanning.Click += btnSILScanning_Click;

                Button btnSILDelete = FindViewById<Button>(Resource.Id.btnSILDelete);
                btnSILDelete.Click += btnSILDelete_Click;


                Button btnFTPTransfer = FindViewById<Button>(Resource.Id.btnFTPTransfer);
                btnFTPTransfer.Click += BtnFTPTransfer_Click;
                ReadFTPSetting();

                txtDate =FindViewById<TextView>(Resource.Id.txtDate);
                txtTime=FindViewById<TextView>(Resource.Id.txtTime);

                timer = new Timer();
                timer.Interval = 1000; // 1 second
                timer.Elapsed += Timer_Elapsed;
                timer.Start();

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
                txtDate.Text = "Date: "+DateTime.Now.ToString("dd/MM/yyyy");
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
                clsGLB.ShowMessage(ex.Message, this, MessageTitle.ERROR);
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
                clsGLB.ShowMessage(ex.Message, this, MessageTitle.ERROR);
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
            timer.Stop();
            timer.Dispose();
        }

    }
}