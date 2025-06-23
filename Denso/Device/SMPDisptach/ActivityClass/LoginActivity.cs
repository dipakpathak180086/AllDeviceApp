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
using System.Collections.Generic;
using Android.Media;
using System.Threading.Tasks;
using System.Data;
using System.Linq;
using Android;
namespace SMPDisptach
{
    [Activity(Label = "SMPDisptach", MainLauncher = true, WindowSoftInputMode = SoftInput.StateHidden, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation, ScreenOrientation = ScreenOrientation.Portrait)]
    public class LoginActivity : AppCompatActivity
    {
        clsGlobal clsGlobal;
        clsNetwork oNetwork;
        string _AppVersion;
        private DataTable dt = null;
        EditText editUserId, editPassword;
        private BL_HHT_APK_FILE _blObj = null;
        private PL_HHT_APK_FILE _plObj = null;
        MediaPlayer mediaPlayerSound;
        Vibrator vibrator;
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
            //clsGlobal.ReadUserLogin();
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
        public LoginActivity()
        {
            try
            {
                //clsGlobal = new clsGlobal();
                oNetwork = new clsNetwork();
                _blObj = new BL_HHT_APK_FILE();
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
                SetContentView(Resource.Layout.activity_login);

                if ((int)Build.VERSION.SdkInt >= 23)
                {
                    allowThePermission();

                }

                Button btnLogin = FindViewById<Button>(Resource.Id.btnLogin);
                btnLogin.Click += BtnLogin_Click;

                Button btnSettting = FindViewById<Button>(Resource.Id.btnSetting);
                btnSettting.Click += (e, a) =>
                {
                    OpenActivity(typeof(SettingMainActivity));
                };

                Button btnExit = FindViewById<Button>(Resource.Id.btnExit);
                btnExit.Click += (e, a) =>
                {
                    this.Finish();
                };

                Context context = this.ApplicationContext;
                _AppVersion = context.PackageManager.GetPackageInfo(context.PackageName, 0).VersionName;
                TextView txtVersion = FindViewById<TextView>(Resource.Id.lblVersion);
                txtVersion.Text = "App Version : " + _AppVersion;

                editUserId = FindViewById<EditText>(Resource.Id.editUserId);
                editUserId.TextChanged += (sender, e) =>
                {
                    string inputText = e.Text.ToString();

                    // Check if the last character is '^'
                    if (!string.IsNullOrEmpty(inputText) && inputText[inputText.Length - 1] == '^')
                    {
                        if (editUserId.Text.Trim().Contains(":") || editPassword.Text.Trim().Contains(":"))
                        {
                            var (userId, password) = GetCredentials(editUserId.Text.TrimEnd('^'), editPassword.Text.TrimEnd('^'));
                            editUserId.Text = userId;
                            editPassword.Text = password;
                            BtnLogin_Click(null, null);
                        }
                    }
                };
                editPassword = FindViewById<EditText>(Resource.Id.editPassword);
                editPassword.TextChanged += (sender, e) =>
                {
                    string inputText = e.Text.ToString();

                    // Check if the last character is '^'
                    if (!string.IsNullOrEmpty(inputText) && inputText[inputText.Length - 1] == '^')
                    {
                        if (editUserId.Text.Trim().Contains(":") || editPassword.Text.Trim().Contains(":"))
                        {
                            var (userId, password) = GetCredentials(editUserId.Text.TrimEnd('^'), editPassword.Text.TrimEnd('^'));
                            editUserId.Text = userId;
                            editPassword.Text = password;
                            BtnLogin_Click(null, null);
                        }
                    }
                };

                vibrator = this.GetSystemService(VibratorService) as Vibrator;
                clsGlobal.ReadAlertPasswordMaster();



                //GetLoginUser();
                editUserId.RequestFocus();
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
                clsGlobal.ReadServerSetting();
                // GetVersionAsync();
            }
            catch (Exception ex)
            {
                clsGlobal.ShowMessage(ex.Message, this, MessageTitle.ERROR);
            }
        }



        public override void OnBackPressed()
        {
            ShowConfirmBox("Do you want to exit", this);
        }

        #endregion

        #region Button Events

        private void BtnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                string strVersionFilePath = Path.Combine(clsGlobal.FilePath, clsGlobal.MasterFolder + "//HHT_VERSION.txt");


                if (string.IsNullOrEmpty(editUserId.Text.Trim()))
                {
                    clsGlobal.showToastNGMessage($"Input user id", this);
                    editUserId.RequestFocus();
                    return;
                }
                if (string.IsNullOrEmpty(editPassword.Text.Trim()))
                {
                    clsGlobal.showToastNGMessage($"Input password", this);
                    editPassword.RequestFocus();
                    return;
                }
                if (!IsNewVersionAvailable(strVersionFilePath, this))
                {
                    clsGlobal.showToastNGMessage($"Old version application is running,Please update!!", this);
                    ShowConfirmBox($"Are you sure want to download lates apk file?", this, DownloadApk);
                    editPassword.RequestFocus();
                    return;
                }

                else
                {

                    if (CheckUserCredentials(editUserId.Text.Trim(), editPassword.Text.Trim()))
                    {
                        OpenActivity(typeof(MainActivity));
                        clsGlobal.mUserId = editUserId.Text;
                        editUserId.Text = editPassword.Text = string.Empty;
                        return;
                    }
                    else
                    {

                        editUserId.RequestFocus();
                        StartPlayingSound();
                        ShowMessageBox("Invalid User Id and Password", this);
                        clsGlobal.WriteLog("Invalid User Id and Password");
                        return;
                    }
                }
            }
            catch (Exception ex)
            {
                clsGlobal.ShowMessage(ex.Message, this, MessageTitle.ERROR);
            }
        }


        #endregion

        #region Methods
        protected async void DownloadApk(object sender, DialogClickEventArgs e)
        {
            // In your activity
            ProgressBar progressBar = FindViewById<ProgressBar>(Resource.Id.progressBar);
            progressBar.Visibility = ViewStates.Visible;


            try
            {
                string downloadsPath = global::Android.OS.Environment.ExternalStorageDirectory.AbsolutePath;
                DirectoryInfo _dir = null;
                _dir = new DirectoryInfo(downloadsPath + "//DENSO_SMPS_APK");
                if (_dir.Exists == false)
                {
                    _dir.Create();
                }

                DataTable dtData = null;
                _plObj = new PL_HHT_APK_FILE();
                _plObj.DbType = "GET_APK";
                dtData = _blObj.BL_ExecuteTask(_plObj);
                if (dtData.Rows.Count > 0)
                {
                    if (File.Exists(downloadsPath + "//" + dtData.Rows[0]["FileName"].ToString()))
                    {
                        File.Delete(downloadsPath + "//" + dtData.Rows[0]["FileName"].ToString());
                    }
                    File.WriteAllBytes(_dir.FullName + "//" + dtData.Rows[0]["FileName"].ToString(), (byte[])dtData.Rows[0]["FileContent"]);
                    long originalFileSize = new FileInfo(_dir.FullName + "//" + dtData.Rows[0]["FileName"].ToString()).Length;
                    clsGlobal.ShowMessage($"APK file successfully downloaded to the path: {_dir.FullName}. Please navigate there manually to install it!", this, MessageTitle.INFORMATION);
                }
                else
                {
                    clsGlobal.ShowMessage($"No APK File Found!!", this, MessageTitle.INFORMATION);
                }

            }
            catch (Exception ex)
            {

                clsGlobal.ShowMessage(ex.Message, this, MessageTitle.ERROR);
            }
            finally
            {
                // ... do work ...
                progressBar.Visibility = ViewStates.Gone;
            }
        }
        private (string userId, string password) GetCredentials(string input1, string input2)
        {
            string userId = string.Empty;
            string password = string.Empty;

            // Check if input1 contains both userId and password
            if (input1.Contains(":"))
            {
                var parts = input1.Split(':');
                if (parts.Length == 2)
                {
                    userId = parts[0].Trim();
                    password = parts[1].Trim();
                }
            }
            // Else check input2
            else if (input2.Contains(":"))
            {
                var parts = input2.Split(':');
                if (parts.Length == 2)
                {
                    userId = parts[0].Trim();
                    password = parts[1].Trim();
                }
            }
            else
            {
                userId = input1.Trim();
                password = input2.Trim();
            }

            return (userId, password);
        }
        public bool IsNewVersionAvailable(string filePath, Context context)
        {
            try
            {
                // 1. Read the version from the file
                string fileVersion = File.ReadAllText(filePath)?.Trim();

                // 2. Get the current app version
                PackageManager pm = context.PackageManager;
                var packageInfo = pm.GetPackageInfo(context.PackageName, 0);
                string currentVersion = packageInfo.VersionName;

                // 3. Optional: use Version object for better comparison
                Version fileVer = new Version(fileVersion);
                Version currentVer = new Version(currentVersion);

                // 4. Compare versions
                return fileVer == currentVer; // true if update is available
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error comparing versions: " + ex.Message);
                return false;
            }
        }

        public bool CheckUserCredentials(string userId, string password)
        {
            // Get the list of logins
            List<Login> logins = clsGlobal.ReadUserLogin();

            // Use a lambda expression to check if the UserId and Password match
            return logins.Any(login => login.UserId == userId && login.Password == password);
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

        public void ShowConfirmBox(string msg, Activity activity, EventHandler<DialogClickEventArgs> handler)
        {
            Android.App.AlertDialog.Builder builder = new Android.App.AlertDialog.Builder(activity);
            builder.SetTitle("Message");
            builder.SetMessage(msg);
            builder.SetCancelable(false);
            builder.SetPositiveButton("Yes", handler);
            builder.SetNegativeButton("No", handllerCancelButton);
            builder.Show();
        }
        private void handllerCancelButton(object sender, DialogClickEventArgs e)
        {
            try
            {

            }
            catch (Exception ex)
            {
                clsGlobal.ShowMessage(ex.Message, this, MessageTitle.ERROR);
            }
        }
        public void ShowMessageBox(string msg, Activity activity)
        {
            Android.App.AlertDialog.Builder builder = new Android.App.AlertDialog.Builder(activity);
            builder.SetTitle("Message");
            builder.SetMessage(msg);
            builder.SetCancelable(false);
            builder.SetPositiveButton("Ok", handleOkMessage);
            builder.Show();
        }

        private void handleOkMessage(object sender, DialogClickEventArgs e)
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


    }
}