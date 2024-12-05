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
using ScanAndSaveApp.ActivityClass;
using System.Collections.Generic;
using Honda_Device_Android;
using Android.Media;
using IOCLAndroidApp.Models;

namespace ScanAndSaveApp
{
    [Activity(Label = "Sato Scanning App", MainLauncher = true, WindowSoftInputMode = SoftInput.StateHidden, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation, ScreenOrientation = ScreenOrientation.Portrait)]
    public class MainActivity : AppCompatActivity
    {
        clsGlobal clsGLB;
        clsNetwork oNetwork;
        int _iScanCount = 0;
        List<ScanCaseModel> _listScanCase;

        EditText txtScanCase;
        TextView txtScanCount;
        ListView listViewScanCase;
        MediaPlayer mediaPlayerSound;
        Vibrator vibrator;

        public MainActivity()
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
                // Set our view from the "main" layout resource
                SetContentView(Resource.Layout.activity_main);

                Button btnServerSetting = FindViewById<Button>(Resource.Id.btnServerSetting);
                btnServerSetting.Click += BtnServerSetting_Click;

                Button btnTestPrint = FindViewById<Button>(Resource.Id.btnTestPrint);
                btnTestPrint.Click += BtnTestPrint_Click;

                txtScanCase = FindViewById<EditText>(Resource.Id.txtScanCase);
                txtScanCase.KeyPress += TxtScanCase_KeyPress;

                txtScanCount = FindViewById<TextView>(Resource.Id.txtScanCount);

                listViewScanCase = FindViewById<ListView>(Resource.Id.listViewScanCase);
                _listScanCase = new List<ScanCaseModel>();

                vibrator = this.GetSystemService(VibratorService) as Vibrator;

                listViewScanCase.Adapter = new CaseItemAdapter(this, _listScanCase);

                //if (ReadSettingFile() == false)
                //    OpenActivity(typeof(SettingActivity));

                ReadCaseFile();
                txtScanCase.RequestFocus();
            }
            catch (Exception ex)
            {
                clsGLB.ShowMessage(ex.Message, this, MessageTitle.ERROR);
            }
        }

        private void BtnTestPrint_Click(object sender, EventArgs e)
        {
            string folderPath = Path.Combine(clsGlobal.FilePath, clsGlobal.FileFolder);
            if (!Directory.Exists(folderPath))
                Directory.CreateDirectory(folderPath);

            string filename = Path.Combine(folderPath, clsGlobal.TestPrnFile);
            AIPPrint print = new AIPPrint("^XA\r\n^FO50,50^A0N,50,50^FDHello!^FS\r\n^XZ", "192.168.42.1", 9100);
            print.PrintData();
        }

        private void BtnServerSetting_Click(object sender, EventArgs e)
        {
            try
            {
                OpenActivity(typeof(PassKeyActivity));
            }
            catch (Exception ex)
            {
                clsGLB.ShowMessage(ex.Message, this, MessageTitle.ERROR);
            }
        }

        private void TxtScanCase_KeyPress(object sender, View.KeyEventArgs e)
        {
            try
            {
                if (e.Event.Action == KeyEventActions.Down)
                {
                    if (e.KeyCode == Keycode.Enter)
                    {

                        if (!string.IsNullOrEmpty(txtScanCase.Text))
                        {
                            if (txtScanCase.Text.Length>32)
                            {
                                // SaveCase(txtScanCase.Text.Trim());
                                //Check barcode is already scanned or not
                                bool IsAlreadyScanned = _listScanCase.Exists(x => x._caseNo.Trim().ToUpper() == txtScanCase.Text.Trim().ToUpper());
                                //if not scanned then save
                                if (IsAlreadyScanned == false)
                                {
                                    WriteFile(txtScanCase.Text.Trim());
                                    txtScanCase.Text = "";
                                    txtScanCase.RequestFocus();
                                }
                                else
                                {
                                    Toast.MakeText(this, "Barcode already scanned", ToastLength.Long).Show();
                                    txtScanCase.Text = "";
                                    txtScanCase.RequestFocus();
                                }
                            }
                            else
                            {
                                Toast.MakeText(this, "Wrong Barcode scanned", ToastLength.Long).Show();
                                txtScanCase.Text = "";
                                txtScanCase.RequestFocus();
                            }
                        }
                        else
                        {
                            Toast.MakeText(this, "Scan case", ToastLength.Long).Show();
                            txtScanCase.RequestFocus();
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

        #region Methods

        private void SaveCase(string CaseBarcode)
        {
            try
            {
                string _MESSAGE = "VALIDATE_MAPPED_CASE~" + CaseBarcode + "~" + clsGlobal.LineId + "}";
                string[] _RESPONSE = oNetwork.fnSendReceiveData(_MESSAGE).Split('~');
                switch (_RESPONSE[0])
                {
                    case "VALID":
                        WriteFile(CaseBarcode);
                        break;

                    case "INVALID":
                        StartPlayingSound();
                        ShowMessageBox(_RESPONSE[1], this);
                        //Toast.MakeText(this, _RESPONSE[1], ToastLength.Long).Show();
                        break;

                    case "ERROR":
                        StartPlayingSound();
                        ShowMessageBox(_RESPONSE[1], this);
                        //Toast.MakeText(this, _RESPONSE[1], ToastLength.Long).Show();
                        break;

                    case "NO_CONNECTION":
                        StartPlayingSound();
                        ShowMessageBox("Communication server not connected", this);
                        // Toast.MakeText(this, "Communication server not connected", ToastLength.Long).Show();
                        break;

                    default:
                        StartPlayingSound();
                        ShowMessageBox("No option match from comm server", this);
                        // Toast.MakeText(this, "No option match from comm server", ToastLength.Long).Show();
                        break;

                }

            }
            catch (Exception ex)
            {
                clsGLB.ShowMessage(ex.Message, this, MessageTitle.ERROR);
            }
        }

        private void WriteFile(string CaseBarcode)
        {
            StreamWriter sw = null;
            try
            {
                string folderPath = Path.Combine(clsGlobal.FilePath, clsGlobal.FileFolder);
                if (!Directory.Exists(folderPath))
                    Directory.CreateDirectory(folderPath);

                string filename = Path.Combine(folderPath, clsGlobal.CaseFileName);
                sw = new StreamWriter(filename, true);

                sw.WriteLine(CaseBarcode + "'");

                _listScanCase.Add(new ScanCaseModel(CaseBarcode));
                listViewScanCase.Adapter = new CaseItemAdapter(this, _listScanCase);

                _iScanCount++;
                txtScanCount.Text = "Scan Count : " + _iScanCount;

                MediaScannerConnection.ScanFile(this, new String[] { filename }, null, null);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (sw != null)
                {
                    sw.Flush();
                    sw.Close();
                    sw = null;
                }
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

                    try
                    {
                        string Line = sr.ReadLine().Split('=')[1].Trim();
                        clsGlobal.LineId = Line.Split('-')[0].Trim();
                    }
                    catch (Exception exfil)
                    {

                    }

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

        private void ReadCaseFile()
        {
            StreamReader sr = null;
            try
            {
                string folderPath = Path.Combine(clsGlobal.FilePath, clsGlobal.FileFolder);
                string filename = Path.Combine(folderPath, clsGlobal.CaseFileName);

                if (File.Exists(filename))
                {
                    sr = new StreamReader(filename);
                    while (!sr.EndOfStream)
                    {
                        string str = sr.ReadLine().TrimEnd('\'');
                        _listScanCase.Add(new ScanCaseModel(str));
                        _iScanCount++;
                    }
                    listViewScanCase.Adapter = new CaseItemAdapter(this, _listScanCase);
                    txtScanCount.Text = "Scan Count : " + _iScanCount;

                    sr.Close();
                    sr.Dispose();
                    sr = null;
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