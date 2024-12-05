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
using System.Threading.Tasks;
using static Android.Provider.Settings;
using System.Security.Cryptography;
using Android;

namespace SatoScanningApp
{
    [Activity(Label = "Sato ScanningApp", MainLauncher = true, WindowSoftInputMode = SoftInput.StateHidden, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation, ScreenOrientation = ScreenOrientation.Portrait)]
    public class LoginActivity : AppCompatActivity
    {
        clsGlobal clsGLB;
        clsNetwork oNetwork;
        string _AppVersion;

        EditText editUserId, editPassword;

        MediaPlayer mediaPlayerSound;
        Vibrator vibrator;

        public LoginActivity()
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
        #region Activity Events
        protected override void OnCreate(Bundle savedInstanceState)
        {
            try
            {
                base.OnCreate(savedInstanceState);

                //if (!Android.OS.Build.Serial.ToString().ToUpper().Equals("XIAOMI") && !Android.OS.Build.Manufacturer.ToString().ToUpper().Equals("CHAINWAY"))
                //{
                //    clsGLB.ShowMessage("Only CHAINWAY Device Will Support!!", this, MessageTitle.ERROR);
                //    return;
                //}

                // Set our view from the "main" layout resource
                if ((int)Build.VERSION.SdkInt >= 23)
                {
                    allowThePermission();
                }
                SetContentView(Resource.Layout.activity_login);

                ImageView imgBack = FindViewById<ImageView>(Resource.Id.imgBack);
                imgBack.Visibility = ViewStates.Invisible;

                TextView txtHeader = FindViewById<TextView>(Resource.Id.txtHeader);
               

                Button btnLogin = FindViewById<Button>(Resource.Id.btnLogin);
                btnLogin.Click += BtnLogin_Click;



                Button btnServerSetting = FindViewById<Button>(Resource.Id.btnServerSetting);
                btnServerSetting.Click += BtnServerSetting_Click;

                Context context = this.ApplicationContext;
                _AppVersion = context.PackageManager.GetPackageInfo(context.PackageName, 0).VersionName;
                TextView txtVersion = FindViewById<TextView>(Resource.Id.txtVersion);
                txtVersion.Text = "App Version : " + _AppVersion;

                string id = Secure.GetString(context.ContentResolver, Secure.AndroidId);

                editUserId = FindViewById<EditText>(Resource.Id.editUserId);
                editPassword = FindViewById<EditText>(Resource.Id.editPassword);

                vibrator = this.GetSystemService(VibratorService) as Vibrator;

                if (ReadSettingFile() == false)
                    OpenActivity(typeof(SettingActivity));

                txtHeader.Text = $"LOGIN & PLANT {clsGlobal.mPlant}";

                editUserId.RequestFocus();
                

            }
            catch (Exception ex)
            {
                clsGLB.ShowMessage(ex.Message, this, MessageTitle.ERROR);
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
                if (string.IsNullOrEmpty(editUserId.Text.Trim()))
                {
                    Toast.MakeText(this, "Input user id", ToastLength.Long).Show();
                    editUserId.RequestFocus();
                    return;
                }
                if (string.IsNullOrEmpty(editPassword.Text.Trim()))
                {
                    Toast.MakeText(this, "Input password", ToastLength.Long).Show();
                    editPassword.RequestFocus();
                    return;
                }
               
                if (string.IsNullOrEmpty(clsGlobal.mPlant))
                {
                    Toast.MakeText(this, "Plant code should not be blank!!", ToastLength.Long).Show();
                    editPassword.RequestFocus();
                    return;
                }
                ValidateUserAsync();
            }
            catch (Exception ex)
            {
                clsGLB.ShowMessage(ex.Message, this, MessageTitle.ERROR);
            }
        }

        private void BtnServerSetting_Click(object sender, EventArgs e)
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

        #endregion

        #region Methods
       
        private async void ValidateUserAsync()
        {
            var progressDialog = ProgressDialog.Show(this, "", "Please wait...", true);
            try
            {

                string[] _RESPONSE = await Task.Run(() => SendDataToServer());

                progressDialog.Hide();

                switch (_RESPONSE[0])
                {
                    case "VALID":
                        clsGlobal.UserId = _RESPONSE[1];
                        clsGlobal.UserName = _RESPONSE[2];
                        clsGlobal.UserGroup = _RESPONSE[3];
                        editUserId.Text = "";
                        editPassword.Text = "";
                        OpenActivity(typeof(MainActivity));
                        break;

                    case "INVALID":
                        editUserId.Text = "";
                        editPassword.Text = "";
                        editUserId.RequestFocus();
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
            finally
            {
                progressDialog.Hide();
            }
        }

        private string[] SendDataToServer()
        {
            try
            {
                string _MESSAGE = "V_USER~" + editUserId.Text.Trim() + "~" + editPassword.Text.Trim() + "~" + clsGlobal.mPlant + "}";
                string[] _RESPONSE = oNetwork.fnSendReceiveData(_MESSAGE).Split('~');

                return _RESPONSE;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private bool ReadSettingFile()
        {
            StreamReader sr = null;
            try
            {
                string folderPath = Path.Combine(clsGlobal.FilePath, clsGlobal.FileFolder);
                string filename = Path.Combine(folderPath, clsGlobal.ServerIpFileName);

                if (File.Exists(filename))
                {
                    sr = new StreamReader(filename);
                    clsGlobal.mSockIp = sr.ReadLine();
                    clsGlobal.mSockPort = Convert.ToInt32(sr.ReadLine());
                    clsGlobal.mPlant= sr.ReadLine();
                    clsGlobal.mTagPower = Convert.ToInt32(sr.ReadLine());
                    sr.Close();
                    sr.Dispose();
                    sr = null;

                    return true;
                }
                return false;
            }
            catch (Exception ex)
            { throw ex; }
            finally
            {
                if (sr != null)
                {
                    sr.Close();
                    sr.Dispose();
                    sr = null;
                }
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

        #endregion

        #region App New Version Update




        #endregion

    }
}