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
    public class FTPSettingActivity : Activity
    {
        //clsNetwork oNetwork;
        clsGlobal clsGLB;
        EditText txtWarehouseNo;
        EditText txtDeviceID;
        EditText txtFTPIP;
        EditText txtFTPUserID;
        EditText txtFTPPassword;
        MediaPlayer mediaPlayerSound;
        Vibrator vibrator;
        bool scanningComplete = false;
        //Spinner cmbSite;
        //List<string> _ListSite = new List<string>();
        public FTPSettingActivity()
        {
            try
            {
                clsGLB = new clsGlobal();
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
                SetContentView(Resource.Layout.activity_FTPSetting);

                //cmbSite = FindViewById<Spinner>(Resource.Id.cmbSite);
                vibrator = this.GetSystemService(VibratorService) as Vibrator;
                Button btnSave = FindViewById<Button>(Resource.Id.btnSave);
                btnSave.Click += BtnSave_Click;

                txtWarehouseNo = FindViewById<EditText>(Resource.Id.editWarehouseNo);
                txtDeviceID = FindViewById<EditText>(Resource.Id.editDeviceId);
                txtFTPIP = FindViewById<EditText>(Resource.Id.editFTPIP);
                txtFTPUserID = FindViewById<EditText>(Resource.Id.editFTPUserID);
                txtFTPPassword = FindViewById<EditText>(Resource.Id.editFTPPassword);

                Button btnBack = FindViewById<Button>(Resource.Id.btnBack);
                btnBack.Click += (e, a) =>
                {
                    this.Finish();
                };
                Button btnClear = FindViewById<Button>(Resource.Id.btnClear);
                btnClear.Click += (e, a) =>
                {
                    txtWarehouseNo.Text = txtDeviceID.Text = txtFTPIP.Text = txtFTPUserID.Text = txtFTPPassword.Text = "";
                    txtWarehouseNo.RequestFocus();
                };


                ReadFTPSetting();

                txtWarehouseNo.RequestFocus();
            }
            catch (Exception ex)
            {
                clsGLB.ShowMessage(ex.Message, this, MessageTitle.ERROR);
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

                    string filename = Path.Combine(ModInit.GstrPath, "Server.SYS");

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
            { clsGLB.ShowMessage(ex.Message, this, MessageTitle.ERROR); }
        }
        void handllerCancelButton(object sender, DialogClickEventArgs e)
        {
            try
            {
                StopPlayingSound();
            }
            catch (Exception ex)
            {
                clsGLB.ShowMessage(ex.Message, this, MessageTitle.ERROR);
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
                clsGLB.ShowMessage(ex.Message, this, MessageTitle.ERROR);
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
                        txtWarehouseNo.Text = strCon[0].Trim();
                        txtDeviceID.Text = strCon[1].Trim();
                        txtFTPIP.Text= strCon[2].Trim();
                        txtFTPUserID.Text = strCon[3].Trim();
                        txtFTPPassword.Text = strCon[4].Trim();
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

        public void WriteServerIP()
        {
            try
            {
                string filename = Path.Combine(clsGlobal.FilePath, "FTPSetting.txt");
                StreamWriter WriteServer = new StreamWriter(filename, false);
                //WriteServer.WriteLine(ModInit.GstrServerIP + "~" + ModInit.GintServerPort);
                WriteServer.WriteLine(txtWarehouseNo.Text + "~" + txtDeviceID.Text + "~" + txtFTPIP.Text + "~" + txtFTPUserID.Text + "~" + txtFTPPassword.Text);
                WriteServer.Close();
                WriteServer = null;
                clsGlobal.mWarehouseNo = txtWarehouseNo.Text.Trim();
                clsGlobal.mDeviceID = txtDeviceID.Text.Trim() ;
                clsGlobal.mFTPIP = txtFTPIP.Text.Trim();
                clsGlobal.mFTPUserID = txtFTPUserID.Text.Trim();
                clsGlobal.mFTPPassword = txtFTPPassword.Text.Trim();
                Toast.MakeText(this, "FTP Setting Saved Successfully", ToastLength.Long).Show();
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

                if (string.IsNullOrEmpty(txtWarehouseNo.Text.Trim()))
                {
                    Toast.MakeText(this, "Enter Warehouse No", ToastLength.Long).Show();
                    txtWarehouseNo.RequestFocus();
                    SoundForNG();
                    IsValidate = false;
                }
                if (string.IsNullOrEmpty(txtDeviceID.Text.Trim()))
                {
                    Toast.MakeText(this, "Enter Device ID", ToastLength.Long).Show();
                    txtDeviceID.RequestFocus();
                    SoundForNG();
                    IsValidate = false;
                }
                if (string.IsNullOrEmpty(txtFTPIP.Text.Trim()))
                {
                    Toast.MakeText(this, "Enter FTP IP", ToastLength.Long).Show();
                    txtFTPIP.RequestFocus();
                    SoundForNG();
                    IsValidate = false;
                }
                if (string.IsNullOrEmpty(txtFTPUserID.Text.Trim()))
                {
                    Toast.MakeText(this, "Enter FTP User ID", ToastLength.Long).Show();
                    txtFTPUserID.RequestFocus();
                    SoundForNG();
                    IsValidate = false;
                }
                if (string.IsNullOrEmpty(txtFTPPassword.Text.Trim()))
                {
                    Toast.MakeText(this, "Enter FTP Password", ToastLength.Long).Show();
                    txtFTPPassword.RequestFocus();
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