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
using Android;
using System.Threading.Tasks;

namespace ScanAndSaveApp
{
    [Activity(Label = "Dispatch Scanner", WindowSoftInputMode = SoftInput.StateHidden, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation, ScreenOrientation = ScreenOrientation.Portrait)]
    public class MainActivity : AppCompatActivity
    {
        clsGlobal clsGLB;
        // clsNetwork oNetwork;
        int _iScanCount = 0;
        List<string> _listScanCase;

        EditText txtDeliveryNo;
        EditText txtTruckNo;
        EditText txtFrameNo;
        TextView lblScanCount;
        TextView lblLastScan;
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

                Button btnClear = FindViewById<Button>(Resource.Id.btnClear);
                btnClear.Click += BtnServerSetting_Click;

                Button btnExit = FindViewById<Button>(Resource.Id.btnExit);
                btnExit.Click += BtnExit_Click;

                txtTruckNo = FindViewById<EditText>(Resource.Id.editTruckNo);
                txtTruckNo.FocusChange += TxtTruckNo_FocusChange;
                txtTruckNo.KeyPress += TxtTruckNo_KeyPress;

                lblLastScan = FindViewById<TextView>(Resource.Id.lblLastScan1);

                txtDeliveryNo = FindViewById<EditText>(Resource.Id.editDeliveryNo);
                txtDeliveryNo.KeyPress += TxtDeliveryNo_KeyPress;
                txtDeliveryNo.FocusChange += TxtDeliveryNo_FocusChange;
                txtFrameNo = FindViewById<EditText>(Resource.Id.editFrameNo);
                txtFrameNo.KeyPress += txtFrameNo_KeyPress;

                lblScanCount = FindViewById<TextView>(Resource.Id.lblScanneCount);

                vibrator = this.GetSystemService(VibratorService) as Vibrator;

                _listScanCase = new List<string>();

                //if (ReadSettingFile() == false)
                //    OpenActivity(typeof(SettingActivity));

                //ReadCaseFile();
                txtDeliveryNo.RequestFocus();
            }
            catch (Exception ex)
            {
                clsGLB.ShowMessage(ex.Message, this, MessageTitle.ERROR);
            }
        }

        private void TxtDeliveryNo_FocusChange(object sender, View.FocusChangeEventArgs e)
        {
            try
            {
                if (txtDeliveryNo.Text.Length > 0)
                {
                    if ((txtDeliveryNo.Text.Trim().Length != 8))
                    {
                        Toast.MakeText(this, "Invalid Delivery No.", ToastLength.Long).Show();//View.SetBackgroundColor(Android.Graphics.Color.Red);
                    }
                }
            }
            catch (Exception ex)
            {
                clsGLB.ShowMessage(ex.Message, this, MessageTitle.ERROR);
            }
        }

        private void TxtDeliveryNo_KeyPress(object sender, View.KeyEventArgs e)
        {
            try
            {
                if (e.Event.Action == KeyEventActions.Down)
                {
                    if (e.KeyCode == Keycode.Enter)
                    {
                        txtTruckNo.RequestFocus();
                        txtTruckNo.SelectAll();

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

        private void TxtTruckNo_KeyPress(object sender, View.KeyEventArgs e)
        {
            try
            {
                if (e.Event.Action == KeyEventActions.Down)
                {
                    if (e.KeyCode == Keycode.Enter)
                    {
                        txtFrameNo.RequestFocus();
                        txtFrameNo.SelectAll();

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

        private void TxtTruckNo_FocusChange(object sender, View.FocusChangeEventArgs e)
        {
            try
            {
                if (txtTruckNo.Text.Length == 4)
                {
                    if (!string.IsNullOrEmpty(txtTruckNo.Text))
                    {
                        clsGlobal.CaseFileName = txtTruckNo.Text + ".txt";
                        ReadCaseFile();
                    }
                }
                else
                    Toast.MakeText(this, "Invalid Truck No.", ToastLength.Long).Show();
            }
            catch (Exception ex)
            {
                clsGLB.ShowMessage(ex.Message, this, MessageTitle.ERROR);
            }
        }

        private void TxtTruckNo_Click(object sender, EventArgs e)
        {

        }

        private void BtnExit_Click(object sender, EventArgs e)
        {
            try
            {
                this.Finish();
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
                Clear();
            }
            catch (Exception ex)
            {
                clsGLB.ShowMessage(ex.Message, this, MessageTitle.ERROR);
            }
        }

        private void txtFrameNo_KeyPress(object sender, View.KeyEventArgs e)
        {
            try
            {
                if (e.Event.Action == KeyEventActions.Down)
                {
                    if (e.KeyCode == Keycode.Enter)
                    {
                        if (!string.IsNullOrEmpty(txtDeliveryNo.Text))
                        {
                            if (!string.IsNullOrEmpty(txtTruckNo.Text))
                            {
                                if (!string.IsNullOrEmpty(txtFrameNo.Text))
                                {
                                    if ((txtDeliveryNo.Text.Trim().Length == 8))
                                    {
                                        if ((txtTruckNo.Text.Trim().Length == 4))
                                        {
                                            if ((txtFrameNo.Text.Trim().Length == 17) || (txtFrameNo.Text.Trim().Length == 14))
                                            {
                                                //17 length is Frame and 14 digit length is ENGIN.
                                                //Check barcode is already scanned or not
                                                bool IsAlreadyScanned = _listScanCase.Contains(txtFrameNo.Text.Trim().ToUpper());
                                                //if not scanned then save
                                                if (IsAlreadyScanned == false)
                                                {
                                                    lblLastScan.Text = "Last Scan: " + txtFrameNo.Text.Trim();
                                                    if (txtFrameNo.Text.Trim().Length == 17)
                                                    {
                                                        WriteFile(txtDeliveryNo.Text.Trim() + '\t' + txtTruckNo.Text.Trim() + '\t' + txtFrameNo.Text.Trim() +'\t' +""+ '\r');
                                                        _listScanCase.Add(txtFrameNo.Text.Trim());
                                                    }
                                                    else
                                                    {
                                                        WriteFile(txtDeliveryNo.Text.Trim() + '\t' + txtTruckNo.Text.Trim() + '\t' + ""+ '\t' + txtFrameNo.Text.Trim() + '\r');
                                                        _listScanCase.Add(txtFrameNo.Text.Trim());
                                                    }
                                                    txtFrameNo.Text = "";
                                                    txtFrameNo.RequestFocus();
                                                }
                                                else
                                                {
                                                    if (txtFrameNo.Text.Trim().Length == 17)
                                                    {
                                                        Toast.MakeText(this, "Frame No. already scanned", ToastLength.Long).Show();
                                                    }
                                                    else
                                                    {
                                                        Toast.MakeText(this, "Engine No. already scanned", ToastLength.Long).Show();
                                                    }
                                                    txtFrameNo.Text = "";
                                                    txtFrameNo.RequestFocus();
                                                }
                                            }
                                            else
                                            {
                                                //Toast.MakeText(this, "Invalid frame No.", ToastLength.Long).Show();
                                                clsGLB.ShowMessage("Invalid frame No.", this, MessageTitle.ERROR);
                                                //txtFrameNo.RequestFocus();
                                                //txtFrameNo.SelectAll();
                                            }
                                        }
                                        else
                                        {
                                            //Toast.MakeText(this, "Invalid Delivery No.", ToastLength.Long).Show();
                                            clsGLB.ShowMessage("Invalid Truck No.", this, MessageTitle.ERROR);
                                            //txtDeliveryNo.RequestFocus();
                                            //txtDeliveryNo.SelectAll();

                                        }
                                    }
                                    else
                                    {
                                        //Toast.MakeText(this, "Invalid Delivery No.", ToastLength.Long).Show();
                                        clsGLB.ShowMessage("Invalid Delivery No.", this, MessageTitle.ERROR);
                                        //txtDeliveryNo.RequestFocus();
                                        //txtDeliveryNo.SelectAll();

                                    }
                                }
                                else
                                {
                                    Toast.MakeText(this, "Scan Frame No.", ToastLength.Long).Show();
                                    txtFrameNo.RequestFocus();
                                }
                            }
                            else
                            {
                                txtTruckNo.RequestFocus();
                                Toast.MakeText(this, "Enter Truck No.", ToastLength.Long).Show();

                            }
                        }
                        else
                        {
                            txtDeliveryNo.RequestFocus();
                            Toast.MakeText(this, "Enter Delivery No.", ToastLength.Long).Show();
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

                sw.WriteLine(CaseBarcode);

                _listScanCase.Add(txtFrameNo.Text.Trim().ToUpper());


                _iScanCount++;
                lblScanCount.Text = _iScanCount.ToString();

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
            _iScanCount = 0;
            try
            {
                string folderPath = Path.Combine(clsGlobal.FilePath, clsGlobal.FileFolder);
                if (!Directory.Exists(folderPath))
                {
                    Directory.CreateDirectory(folderPath);
                }
                string filename = Path.Combine(folderPath, clsGlobal.CaseFileName);

                if (File.Exists(filename))
                {
                    sr = new StreamReader(filename);
                    while (!sr.EndOfStream)
                    {
                        string[] str = sr.ReadLine().ToString().Split('\t');
                        if (str[2].Trim().ToUpper() == "")
                        {
                            _listScanCase.Add(str[3].Trim().ToUpper());
                        }
                        else
                        {
                            _listScanCase.Add(str[2].Trim().ToUpper());
                        }
                        _iScanCount++;
                    }

                    lblScanCount.Text = _iScanCount.ToString();

                    sr.Close();
                    sr.Dispose();
                    sr = null;
                }
                else
                {
                    _iScanCount = 0;
                    _listScanCase.Clear();
                    lblScanCount.Text = _iScanCount.ToString();
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
            //ShowConfirmBox("Do you want to exit", this);
        }

        private void Clear()
        {
            txtDeliveryNo.Text = "";
            txtFrameNo.Text = "";
            txtTruckNo.Text = "";
            txtDeliveryNo.RequestFocus();
        }
    }
}