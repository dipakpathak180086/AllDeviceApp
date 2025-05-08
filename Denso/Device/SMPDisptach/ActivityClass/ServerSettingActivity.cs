using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.Media;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using SMPDisptach;

namespace SMPDisptach
{
    [Activity(Label = "Setting", WindowSoftInputMode = SoftInput.StateHidden, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation, ScreenOrientation = ScreenOrientation.Portrait)]
    public class ServerSettingActivity : Activity
    {
        //clsNetwork oNetwork;
        clsGlobal clsGlobal;
        EditText txtServerIp;
        EditText txtDatabase;
        EditText txtUserID;
        EditText txtPassword;
        MediaPlayer mediaPlayerSound;
        Vibrator vibrator;
        bool scanningComplete = false;
        //Spinner cmbSite;
        //List<string> _ListSite = new List<string>();
        public ServerSettingActivity()
        {
            try
            {
                //clsGlobal = new clsGlobal();
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
                SetContentView(Resource.Layout.activity_ServerSetting);

                //cmbSite = FindViewById<Spinner>(Resource.Id.cmbSite);
                vibrator = this.GetSystemService(VibratorService) as Vibrator;
                Button btnSave = FindViewById<Button>(Resource.Id.btnSave);
                btnSave.Click += BtnSave_Click;

                txtServerIp = FindViewById<EditText>(Resource.Id.editServer);
                txtDatabase = FindViewById<EditText>(Resource.Id.editDatabase);
                txtUserID = FindViewById<EditText>(Resource.Id.editUserID);
                txtPassword = FindViewById<EditText>(Resource.Id.editPassword);

                Button btnBack = FindViewById<Button>(Resource.Id.btnBack);
                btnBack.Click += (e, a) =>
                {
                    this.Finish();
                };
                Button btnClear = FindViewById<Button>(Resource.Id.btnClear);
                btnClear.Click += (e, a) =>
                {
                    txtServerIp.Text = txtDatabase.Text = txtUserID.Text = txtPassword.Text ="";
                    txtServerIp.RequestFocus();
                };


                ReadServerSetting();

                txtServerIp.RequestFocus();
            }
            catch (Exception ex)
            {
                clsGlobal.ShowMessage(ex.Message, this, MessageTitle.ERROR);
            }
        }

        public override void OnBackPressed() { }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (ValidateControls())
                {

                    //string folderPath = Path.Combine(clsGlobal.FilePath, clsGlobal.FileFolder);
                    //if (!Directory.Exists(folderPath))
                    //    Directory.CreateDirectory(folderPath);

                    string filename = Path.Combine(clsGlobal.FilePath, "ServerSetting.txt");
                    FileInfo ServerFile = new FileInfo(filename);

                    //using (var streamWriter = new StreamWriter(filename, false))
                    //{
                    WriteServerIP();

                    MediaScannerConnection.ScanFile(this, new string[] { filename }, null, null);

                    Toast.MakeText(this, "Setting saved", ToastLength.Long).Show();

                    Finish();
                    //}
                }
            }
            catch (Exception ex)
            { clsGlobal.ShowMessage(ex.Message, this, MessageTitle.ERROR); }
        }
        void handllerCancelButton(object sender, DialogClickEventArgs e)
        {
            try
            {
                StopPlayingSound();
            }
            catch (Exception ex)
            {
                clsGlobal.ShowMessage(ex.Message, this, MessageTitle.ERROR);
            }
        }

        void handleOkMessage(object sender, DialogClickEventArgs e)
        {
            try
            {
                StopPlayingSound();
            }
            catch (Exception ex)
            {
                clsGlobal.ShowMessage(ex.Message, this, MessageTitle.ERROR);
            }
        }
        private void StartPlayingSound(bool isSaved = false)
        {
            try
            {



                if (isSaved)
                {
                    mediaPlayerSound = MediaPlayer.Create(this, Resource.Raw.OkSound);
                }
                else
                {
                    StopPlayingSound();
                    mediaPlayerSound = MediaPlayer.Create(this, Resource.Raw.Beep);
                }
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
                    scanningComplete = false;
                }
            }
            catch (Exception ex) { throw ex; }
        }
        private void SoundForOK()
        {
            try
            {
                Task.Run(() =>
                { //Start Vibration
                    long[] pattern = { 0, 2000, 500 }; //0 to start now, 200 to vibrate 200 ms, 0 to sleep for 0 ms.
                    vibrator.Vibrate(pattern, -1);//
                    StopPlayingSound();
                    StartPlayingSound(true);
                    Thread.Sleep(2000);
                    StopPlayingSound();
                    vibrator.Cancel();
                });

            }
            catch (Exception ex) { throw ex; }
        }
        private void SoundForNG()
        {
            try
            {
                Task.Run(() =>
                {
                    StopPlayingSound();
                    StartPlayingSound();
                    Thread.Sleep(3000);
                    StopPlayingSound();
                });

            }
            catch (Exception ex) { throw ex; }
        }
        public bool ReadServerSetting()
        {
            try
            {
                string filename = Path.Combine(clsGlobal.FilePath, "ServerSetting.txt");
                FileInfo ServerFile = new FileInfo(filename);
                StreamReader ReadServer;
                string[] strCon;
                if (ServerFile.Exists == true)
                {
                    ReadServer = new StreamReader(filename);
                    strCon = ReadServer.ReadLine().Split("~");
                    if (strCon.Length >= 1)
                    {
                        txtServerIp.Text = strCon[0].Trim();
                        txtDatabase.Text = strCon[1].Trim();
                        txtUserID.Text= strCon[2].Trim();
                        txtPassword.Text = strCon[3].Trim();

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
                string filename = Path.Combine(clsGlobal.FilePath, "ServerSetting.txt");
                StreamWriter WriteServer = new StreamWriter(filename, false);
                //WriteServer.WriteLine(ModInit.GstrServerIP + "~" + ModInit.GintServerPort);
                WriteServer.WriteLine(txtServerIp.Text + "~" + txtDatabase.Text + "~" + txtUserID.Text + "~" + txtPassword.Text);
                WriteServer.Close();
                WriteServer = null;
                clsGlobal.mDatabaseServer = txtServerIp.Text.Trim();
                clsGlobal.mDatabaseName = txtDatabase.Text.Trim() ;
                clsGlobal.mDatabaseUserId = txtUserID.Text.Trim();
                clsGlobal.mDatabasePassword = txtPassword.Text.Trim();
                Toast.MakeText(this, "Server Setting Saved Successfully", ToastLength.Long).Show();
                SoundForOK();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private bool ValidateControls()
        {
            try
            {
                bool IsValidate = true;

                if (string.IsNullOrEmpty(txtServerIp.Text.Trim()))
                {
                    Toast.MakeText(this, "Enter Server Name/IP", ToastLength.Long).Show();
                    txtServerIp.RequestFocus();
                    SoundForNG();
                    IsValidate = false;
                }
                if (string.IsNullOrEmpty(txtDatabase.Text.Trim()))
                {
                    Toast.MakeText(this, "Enter Database Name", ToastLength.Long).Show();
                    txtDatabase.RequestFocus();
                    SoundForNG();
                    IsValidate = false;
                }
                if (string.IsNullOrEmpty(txtUserID.Text.Trim()))
                {
                    Toast.MakeText(this, "Enter User Id", ToastLength.Long).Show();
                    txtUserID.RequestFocus();
                    SoundForNG();
                    IsValidate = false;
                }
               
                if (string.IsNullOrEmpty(txtPassword.Text.Trim()))
                {
                    Toast.MakeText(this, "Enter Password", ToastLength.Long).Show();
                    txtPassword.RequestFocus();
                    SoundForNG();
                    IsValidate = false;
                }
                return IsValidate;
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
    }
}