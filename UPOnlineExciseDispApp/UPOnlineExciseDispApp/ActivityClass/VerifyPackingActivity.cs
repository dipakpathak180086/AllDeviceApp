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
using UPOnlineExciseDispApp.ActivityClass;
using System.Collections.Generic;
using Android.Media;
using IOCLAndroidApp.Models;
using System.Threading.Tasks;
using UPOnlineExciseDispApp.Adapter;
using Android.Support.V7.Widget;
using System.Threading;

namespace UPOnlineExciseDispApp
{
    [Activity(Label = "UP Online Excise Packing Verify", WindowSoftInputMode = SoftInput.StateHidden, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation, ScreenOrientation = ScreenOrientation.Portrait)]
    public class VerifyPackingActivity : AppCompatActivity
    {
        clsGlobal clsGLB;
        clsNetwork oNetwork;

        MediaPlayer mediaPlayerSound;
        Vibrator vibrator;
        List<string> _ListGipNo = new List<string>();
        List<CaseItem> _Listtem = new List<CaseItem>();


        TextView lblMsg, lblScanCount;
        EditText txtScanCaseBarcode, txtScanBottelBarcode;
        Button btnReset;
        private string tempScanningBarcode = string.Empty;
        RecyclerView recyclerViewItem;
        CaseItemAdapter dispatchItemAdapter;
        RecyclerView.LayoutManager mLayoutManager;
        public VerifyPackingActivity()
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
                SetContentView(Resource.Layout.activity_VerifyPacking);

                lblMsg = FindViewById<TextView>(Resource.Id.lblMsg);
                lblMsg.Text = "";

                lblScanCount = FindViewById<TextView>(Resource.Id.lblBottelScanCount);
                lblScanCount.Text = "Bottel Scan : 0";



                txtScanCaseBarcode = FindViewById<EditText>(Resource.Id.txtCaseBarcode);
                txtScanCaseBarcode.KeyPress += txtScanBarcode_KeyPress;

                txtScanBottelBarcode = FindViewById<EditText>(Resource.Id.txtScanBottelBarcode);
                txtScanBottelBarcode.KeyPress += txtScanBottelBarcode_KeyPress;

                Button btnBack = FindViewById<Button>(Resource.Id.btnBack);
                btnBack.Click += (e, a) =>
                {
                    oNetwork.TcpClosed();
                    this.Finish();
                };



                recyclerViewItem = FindViewById<RecyclerView>(Resource.Id.recycleViewDispatchItem);
                mLayoutManager = new LinearLayoutManager(this);
                recyclerViewItem.SetLayoutManager(mLayoutManager);

                BindRecycleView();


                vibrator = this.GetSystemService(VibratorService) as Vibrator;
                txtScanCaseBarcode.Text = "";
                txtScanCaseBarcode.Enabled = true;

                txtScanBottelBarcode.Enabled = false;
                txtScanBottelBarcode.Text = "";
                txtScanCaseBarcode.RequestFocus();
                Button btnReset = FindViewById<Button>(Resource.Id.btnReset);
                btnReset.Click += (e, a) =>
                {
                    lblMsg.Text = "";
                    txtScanCaseBarcode.Text = "";
                    txtScanCaseBarcode.Enabled = true;
                    txtScanBottelBarcode.Enabled = false;
                    txtScanBottelBarcode.Text = "";
                    txtScanCaseBarcode.RequestFocus();
                    if (_Listtem.Count > 0)
                    {
                        _Listtem.Clear();
                        dispatchItemAdapter.NotifyDataSetChanged();
                    }
                };

            }
            catch (Exception ex)
            {
                clsGLB.ShowMessage(ex.Message, this, MessageTitle.ERROR);
            }
        }
        public override void OnBackPressed()
        {
        }
        private void ResetField()
        {
            txtScanBottelBarcode.Text = txtScanCaseBarcode.Text ="";
            txtScanCaseBarcode.Enabled = true;
            txtScanBottelBarcode.Enabled = false;
            lblScanCount.Text = "0/0";
            txtScanCaseBarcode.RequestFocus();
            tempScanningBarcode = "";
           // lblMsg.Text = "";
            if (_Listtem.Count > 0)
            {
                _Listtem.Clear();
                dispatchItemAdapter.NotifyDataSetChanged();
            }
        }
        private void BindView()
        {
            var progressDialog = ProgressDialog.Show(this, "", "Please wait...", true);
            try
            {
                string[] _RESPONSE = SendDataToServer("BIND_VIEW~", txtScanCaseBarcode.Text.Trim(), "");

                progressDialog.Hide();

                switch (_RESPONSE[0])
                {
                    case "VALID":
                        _Listtem.Clear();
                        string[] ArrRow = _RESPONSE[1].Split("#");
                        for (int i = 0; i < ArrRow.Length; i++)
                        {
                            string[] ArrCol = ArrRow[i].Split("$");
                            _Listtem.Add(new CaseItem
                            {
                                BottelBarcode = ArrCol[0],
                            });
                        }
                        lblScanCount.Text = "Bottel Scan : " + _Listtem.Count;
                        dispatchItemAdapter.NotifyDataSetChanged();
                        break;
                    case "ERROR":
                        lblMsg.Text = _RESPONSE[1];
                        lblMsg.SetTextColor(Android.Graphics.Color.Red);
                        SoundAndVibratorNG();
                        break;
                    case "INVALID":
                        lblMsg.Text = _RESPONSE[1];
                        lblMsg.SetTextColor(Android.Graphics.Color.Red);
                        SoundAndVibratorNG();
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
        }

        private bool ScanBottelBarcode()
        {
            bool bReturn = false;
            try
            {

                for (int j = 0; j < _Listtem.Count; j++)
                {
                    if (_Listtem[j].BottelBarcode.Trim() == txtScanBottelBarcode.Text.Trim())
                    {
                        lblMsg.Text = $"This Case {txtScanCaseBarcode.Text.Trim()} Verified Successfully!!!";
                        lblMsg.SetTextColor(Android.Graphics.Color.Green);
                        VibratorOK();
                        ResetField();
                        bReturn = true;
                        break;
                    }
                }
                if (!bReturn)
                {
                    lblMsg.Text = $"This Case {txtScanCaseBarcode.Text.Trim()} is not Verified!!!";
                    lblMsg.SetTextColor(Android.Graphics.Color.Red);
                    txtScanBottelBarcode.Text = "";
                    txtScanBottelBarcode.RequestFocus();
                    SoundAndVibratorNG();

                }
            }
            catch (Exception ex)
            {
                clsGLB.ShowMessage(ex.Message, this, MessageTitle.ERROR);

            }
            finally
            {
                txtScanBottelBarcode.Text = "";
            }

            return bReturn;
        }

        private bool ScanCaseBarcode()
        {
            lblMsg.Text = "";
            bool bReturn = false;
            var progressDialog = ProgressDialog.Show(this, "", "Please wait...", true);
            try
            {
                string[] _RESPONSE = SendDataToServer("VERIFY_CASE_SCAN~CASE_SCAN~", txtScanCaseBarcode.Text.Trim(), "");

                progressDialog.Hide();

                switch (_RESPONSE[0])
                {
                    case "VALID":
                        _Listtem.Clear();
                        string[] ArrRow = _RESPONSE[1].Split("#");
                        for (int i = 0; i < ArrRow.Length; i++)
                        {
                            string[] ArrCol = ArrRow[i].Split("$");
                            _Listtem.Add(new CaseItem
                            {
                                BottelBarcode = ArrCol[0],
                            });
                        }
                        lblScanCount.Text = "Bottel Scan : " + _Listtem.Count;
                        dispatchItemAdapter.NotifyDataSetChanged();
                        txtScanCaseBarcode.Enabled = false;
                        txtScanBottelBarcode.Enabled = true;
                        txtScanBottelBarcode.RequestFocus();
                        break;
                    case "ERROR":
                        lblMsg.Text = _RESPONSE[1];
                        lblMsg.SetTextColor(Android.Graphics.Color.Red);
                        SoundAndVibratorNG();
                        break;
                    case "INVALID":
                        lblMsg.Text = _RESPONSE[1];
                        lblMsg.SetTextColor(Android.Graphics.Color.Red);
                        SoundAndVibratorNG();
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
            return bReturn;
        }






        private void txtScanBottelBarcode_KeyPress(object sender, View.KeyEventArgs e)
        {
            try
            {
                if (e.Event.Action == KeyEventActions.Down)
                {
                    if (e.KeyCode == Keycode.Enter)
                    {
                        lblMsg.Text = "";
                        if (txtScanBottelBarcode.Text.Length != 44)
                        {
                            lblMsg.Text = "Invalid Barcode!!!";
                            lblMsg.SetTextColor(Android.Graphics.Color.Red);
                            txtScanBottelBarcode.Text = "";
                            txtScanBottelBarcode.RequestFocus();
                            SoundAndVibratorNG();
                            return;
                        }
                        ScanBottelBarcode();
                        txtScanBottelBarcode.SelectAll();
                    }
                    else
                        e.Handled = false;
                }
            }
            catch (Exception ex)
            {
                lblMsg.Text = ex.Message;
                lblMsg.SetTextColor(Android.Graphics.Color.Red);
            }
            finally
            {

            }
        }
        private void txtScanBarcode_KeyPress(object sender, View.KeyEventArgs e)
        {
            try
            {
                if (e.Event.Action == KeyEventActions.Down)
                {
                    if (e.KeyCode == Keycode.Enter)
                    {
                        lblMsg.Text = "";
                        if (txtScanCaseBarcode.Text.Length != 34)
                        {
                            lblMsg.Text = "Invalid Barcode!!!";
                            lblMsg.SetTextColor(Android.Graphics.Color.Red);
                            txtScanCaseBarcode.Text = "";
                            txtScanCaseBarcode.RequestFocus();
                            SoundAndVibratorNG();
                            return;
                        }

                        ScanCaseBarcode(); //Scan Case Or Bottel Barcode (First Field )
                        txtScanCaseBarcode.SelectAll();
                    }
                    else
                        e.Handled = false;
                }
            }
            catch (Exception ex)
            {
                lblMsg.Text = ex.Message;
                lblMsg.SetTextColor(Android.Graphics.Color.Red);
                txtScanCaseBarcode.Text = "";
                txtScanCaseBarcode.RequestFocus();
            }
            finally
            {


            }
        }

        private void BindRecycleView()
        {
            try
            {
                dispatchItemAdapter = new CaseItemAdapter(_Listtem, this);
                recyclerViewItem.SetAdapter(dispatchItemAdapter);

            }
            catch (Exception ex) { throw ex; }
        }
        private string[] SendDataToServer(string Type, string CaseBarcode, string BottleBarcode)
        {
            try
            {
                string _MESSAGE = Type  + CaseBarcode.Trim() + "~" + BottleBarcode.Trim() + "}";
                string[] _RESPONSE = oNetwork.fnSendReceiveData(_MESSAGE).Split('~');
                return _RESPONSE;
            }
            catch (Exception ex)
            {
                throw ex;
            }
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
        public void ShowMessageBoxVibrator(string msg, Activity activity)
        {
            Android.App.AlertDialog.Builder builder = new Android.App.AlertDialog.Builder(activity);
            builder.SetTitle("Message");
            builder.SetMessage(msg);
            builder.SetCancelable(false);
            builder.SetPositiveButton("Ok", handleOkMessageVibrator);
            // builder.SetNegativeButton("No", handllerCancelButton);
            builder.Show();
        }
        void handleOkMessageVibrator(object sender, DialogClickEventArgs e)
        {
            try
            {
                vibrator.Cancel();
            }
            catch (Exception ex)
            {
                clsGLB.ShowMessage(ex.Message, this, MessageTitle.ERROR);
            }
        }
        private void VibratorOK()
        {
            try
            {
                Task.Run(() =>
                {
                    StartPlayingVibrator();
                    Thread.Sleep(2000);
                    vibrator.Cancel();

                });
            }
            catch (Exception ex) { throw ex; }
        }
        private void SoundAndVibratorNG()
        {
            try
            {
                Task.Run(() =>
                {
                    StartPlayingSound();
                    StartPlayingVibrator();
                    Thread.Sleep(1000);
                    vibrator.Cancel();
                    StopPlayingSound();
                });

            }
            catch (Exception ex) { throw ex; }
        }

        private void StartPlayingVibrator()
        {
            try
            {
                //Start Vibration
                long[] pattern = { 0, 200, 0 }; //0 to start now, 200 to vibrate 200 ms, 0 to sleep for 0 ms.
                vibrator.Vibrate(pattern, 0);//


            }
            catch (Exception ex) { throw ex; }
        }

    }
}