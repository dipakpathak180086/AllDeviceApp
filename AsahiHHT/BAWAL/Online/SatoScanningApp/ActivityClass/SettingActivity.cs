using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.Media;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using IOCLAndroidApp;

namespace AISScanningApp.ActivityClass
{
    [Activity(Label = "Setting", WindowSoftInputMode = SoftInput.StateHidden, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation, ScreenOrientation = ScreenOrientation.Portrait)]
    public class SettingActivity : Activity
    {
        clsNetwork oNetwork;
        clsGlobal clsGLB;
        EditText editServerIP, editFTPIp,editFTPUser,editFTPPass,editMachineNo,editFTPFolder;
        EditText editPort;
        MediaPlayer mediaPlayerSound;
        Vibrator vibrator;
        List<string> _List=null;
        public SettingActivity()
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
        protected override void OnCreate(Bundle savedInstanceState)
        {
            try
            {
                base.OnCreate(savedInstanceState);
                SetContentView(Resource.Layout.activity_setting);

                Button btnSave = FindViewById<Button>(Resource.Id.btnSave);
                btnSave.Click += BtnSave_Click;

                editServerIP = FindViewById<EditText>(Resource.Id.txtServerIP);
                editPort = FindViewById<EditText>(Resource.Id.txtPort);
                editFTPIp = FindViewById<EditText>(Resource.Id.txtFTPIP);
                editFTPUser = FindViewById<EditText>(Resource.Id.txtFTPUser);
                editFTPPass = FindViewById<EditText>(Resource.Id.txtFTPPass);
                editFTPFolder = FindViewById<EditText>(Resource.Id.txtFTPFolder);
                editMachineNo = FindViewById<EditText>(Resource.Id.txtMachineNo);
                vibrator = this.GetSystemService(VibratorService) as Vibrator;

                ImageView imgBack = FindViewById<ImageView>(Resource.Id.imgBack);
                imgBack.Click += (e, a) =>
                {
                    this.Finish();
                };
               
                ReadSettingFile();

                editServerIP.RequestFocus();
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

                    string folderPath = Path.Combine(clsGlobal.FilePath, clsGlobal.FileFolder);
                    if (!Directory.Exists(folderPath))
                        Directory.CreateDirectory(folderPath);

                    string filename = Path.Combine(folderPath, clsGlobal.ServerIpFileName);

                    using (var streamWriter = new StreamWriter(filename, false))
                    {
                        streamWriter.WriteLine(editServerIP.Text.Trim());
                        streamWriter.WriteLine(editPort.Text.Trim());
                        streamWriter.WriteLine(editMachineNo.Text.Trim());
                        streamWriter.WriteLine(editFTPIp.Text.Trim());
                        streamWriter.WriteLine(editFTPUser.Text.Trim());
                        streamWriter.WriteLine(editFTPPass.Text.Trim());
                        streamWriter.WriteLine(editFTPFolder.Text.Trim());

                        MediaScannerConnection.ScanFile(this, new string[] { filename }, null, null);

                        Toast.MakeText(this, "Setting saved", ToastLength.Long).Show();

                        clsGlobal.mSockIp = editServerIP.Text.Trim();
                        clsGlobal.mSockPort = Convert.ToInt32(editPort.Text.Trim());
                        clsGlobal.mMachineNo = editMachineNo.Text.Trim();

                        
                        clsGlobal.mFtpAddress = editFTPIp.Text.Trim();
                        clsGlobal.mFtpUserName = editFTPUser.Text.Trim();
                        clsGlobal.mFtpPassword = editFTPPass.Text.Trim();
                        clsGlobal.mFtpFolder = editFTPFolder.Text.Trim();

                        Finish();
                    }
                }
            }
            catch (Exception ex)
            { clsGLB.ShowMessage(ex.Message, this, MessageTitle.ERROR); }
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
        private string[] SendDataToServer(string strCommString)
        {
            try
            {
                string _MESSAGE = strCommString +"}";
                string[] _RESPONSE = oNetwork.fnSendReceiveData(_MESSAGE).Split('~');
                return _RESPONSE;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        private async Task<string> GetLineAsync()
        {
            var progressDialog = ProgressDialog.Show(this, "", "Please wait...", true);
            try
            {
                clsGlobal.Db_Type = "BIND_LINE_DATA";
                string[] _RESPONSE = await Task.Run(() => SendDataToServer("BIND_LINE_DATA"));

                progressDialog.Hide();
                _List = new List<string>();
                switch (_RESPONSE[0])
                {
                    case "VALID":
                        _List.Add("--Select--");
                        string[] ArrRow = _RESPONSE[1].Split("#");
                        for (int i = 0; i < ArrRow.Length; i++)
                        {
                            string[] ArrCol = ArrRow[i].Split("$");

                            for (int J = 0; J < ArrCol.Length; J++)
                            {

                                _List.Add(ArrCol[J]);
                            }
                        }
                        ArrayAdapter<string> arrayAdapter = new ArrayAdapter<string>(this, Resource.Layout.Spiner, _List);
                        //sppinerLine.Adapter = arrayAdapter;
                        //sppinerLine.SetSelection(0);
                        //sppinerLine.RequestFocus();
                        break;

                    case "INVALID":
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
                progressDialog.Hide();
            }
            finally
            {
                progressDialog.Hide();
            }
            return "";
        }
        private void ReadSettingFile()
        {
            StreamReader sr = null;
            try
            {
                string folderPath = Path.Combine(clsGlobal.FilePath, clsGlobal.FileFolder);
                string filename = Path.Combine(folderPath, clsGlobal.ServerIpFileName);

                if (File.Exists(filename))
                {
                    sr = new StreamReader(filename);
                    editServerIP.Text = sr.ReadLine();
                    editPort.Text = sr.ReadLine();

                    editMachineNo.Text = sr.ReadLine();
                    
                   
                    editFTPIp.Text = sr.ReadLine();
                    editFTPUser.Text = sr.ReadLine();
                    editFTPPass.Text = sr.ReadLine();
                    editFTPFolder.Text = sr.ReadLine();

                    sr.Close();
                    sr.Dispose();
                    sr = null;

                    clsGlobal.mSockIp = editServerIP.Text.Trim();
                    clsGlobal.mSockPort = Convert.ToInt32(editPort.Text.Trim());
                    clsGlobal.mMachineNo = editMachineNo.Text.Trim();
                    clsGlobal.mFtpAddress = editFTPIp.Text.Trim();
                    clsGlobal.mFtpUserName = editFTPUser.Text.Trim();
                    clsGlobal.mFtpPassword = editFTPPass.Text.Trim();
                    clsGlobal.mFtpFolder = editFTPFolder.Text.Trim();
                }
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

        private bool ValidateControls()
        {
            try
            {
                bool IsValidate = true;

                if (string.IsNullOrEmpty(editServerIP.Text.Trim()))
                {
                    Toast.MakeText(this, "Input server ip", ToastLength.Long).Show();
                    editServerIP.RequestFocus();
                    IsValidate = false;
                }
                if (string.IsNullOrEmpty(editPort.Text.Trim()))
                {
                    Toast.MakeText(this, "Input server port", ToastLength.Long).Show();
                    editPort.RequestFocus();
                    IsValidate = false;
                }
                //if (sppinerLine.SelectedItemPosition<=0)
                //{
                //    Toast.MakeText(this, "Select line", ToastLength.Long).Show();
                //    sppinerLine.RequestFocus();
                //    IsValidate = false;
                //}
                //if (string.IsNullOrEmpty(editPLCIP.Text.Trim()))
                //{
                //    Toast.MakeText(this, "Input PLC IP", ToastLength.Long).Show();
                //    editPLCIP.RequestFocus();
                //    IsValidate = false;
                //}
                //if (string.IsNullOrEmpty(editPLCPort.Text.Trim()))
                //{
                //    Toast.MakeText(this, "Input PLC Port", ToastLength.Long).Show();
                //    editPLCPort.RequestFocus();
                //    IsValidate = false;
                //}
                //if (string.IsNullOrEmpty(editFTPIp.Text.Trim()))
                //{
                //    Toast.MakeText(this, "Input FTP IP", ToastLength.Long).Show();
                //    editFTPIp.RequestFocus();
                //    IsValidate = false;
                //}
                //if (string.IsNullOrEmpty(editFTPUser.Text.Trim()))
                //{
                //    Toast.MakeText(this, "Input FTP User", ToastLength.Long).Show();
                //    editFTPUser.RequestFocus();
                //    IsValidate = false;
                //}
                //if (string.IsNullOrEmpty(editFTPPass.Text.Trim()))
                //{
                //    Toast.MakeText(this, "Input FTP Password", ToastLength.Long).Show();
                //    editFTPPass.RequestFocus();
                //    IsValidate = false;
                //}
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