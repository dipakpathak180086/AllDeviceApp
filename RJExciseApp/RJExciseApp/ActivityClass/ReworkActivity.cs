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
using RJExciseApp.ActivityClass;
using System.Collections.Generic;
using Android.Media;
using IOCLAndroidApp.Models;
using System.Threading.Tasks;
using RJExciseApp.Adapter;
using Android.Support.V7.Widget;
using System.Threading;

namespace RJExciseApp
{
    [Activity(Label = "Rework App", WindowSoftInputMode = SoftInput.StateHidden, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation, ScreenOrientation = ScreenOrientation.Portrait)]
    public class ReworkActivity : AppCompatActivity
    {
        clsGlobal clsGLB;
        clsNetwork oNetwork;

        MediaPlayer mediaPlayerSound;
        Vibrator vibrator;
        List<string> _ListGipNo = new List<string>();
        List<CaseItem> _ListDispatchItem = new List<CaseItem>();


        TextView lblMsg, lblScanCount, lblPlant, lblLine, lblETIN, lblBatchNo, lblPackSize, lblStregth, lblVolume, lblRefNo, lblPlanId, lblCaseBarcode;
        EditText txtScanBarcode, txtScanBottelBarcode;
        Button btnReset;
        private string tempScanningBarcode = string.Empty;
        RecyclerView recyclerViewItem;
        CaseItemAdapter dispatchItemAdapter;
        RecyclerView.LayoutManager mLayoutManager;
        public ReworkActivity()
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
                SetContentView(Resource.Layout.activity_Rework);

                lblMsg = FindViewById<TextView>(Resource.Id.lblMsg);
                lblMsg.Text = "";

                lblScanCount = FindViewById<TextView>(Resource.Id.lblScanCount);
                lblScanCount.Text = "0/0";

                lblPlant = FindViewById<TextView>(Resource.Id.lblPlant);
                lblPlant.Text = "XXXX";

                lblLine = FindViewById<TextView>(Resource.Id.lblLine);
                lblLine.Text = "XXXX";

                lblETIN = FindViewById<TextView>(Resource.Id.lblETIN);
                lblETIN.Text = "XXXX";

                lblBatchNo = FindViewById<TextView>(Resource.Id.lblBatchNo);
                lblBatchNo.Text = "XXXX";

                lblPackSize = FindViewById<TextView>(Resource.Id.lblPackSize);
                lblPackSize.Text = "0";

                lblStregth = FindViewById<TextView>(Resource.Id.lblStregth);
                lblStregth.Text = "0";

                lblVolume = FindViewById<TextView>(Resource.Id.lblVolume);
                lblVolume.Text = "0";

                lblRefNo = FindViewById<TextView>(Resource.Id.lblRefNo);
                lblRefNo.Text = "XXXX";

                lblPlanId = FindViewById<TextView>(Resource.Id.lblPlanId);
                lblPlanId.Text = "XXXX";

                lblCaseBarcode = FindViewById<TextView>(Resource.Id.lblCaseBarcodeVal);
                lblCaseBarcode.Text = "Case Barcode";

                txtScanBarcode = FindViewById<EditText>(Resource.Id.txtScanBarcode);
                txtScanBarcode.KeyPress += txtScanBarcode_KeyPress;

                txtScanBottelBarcode = FindViewById<EditText>(Resource.Id.txtScanBottelBarcode);
                txtScanBottelBarcode.KeyPress += txtScanBottelBarcode_KeyPress;

                Button btnBack = FindViewById<Button>(Resource.Id.btnBack);
                btnBack.Click += (e, a) =>
                {
                    oNetwork.TcpClosed();
                    this.Finish();
                };

                btnReset = FindViewById<Button>(Resource.Id.btnReset);
                btnReset.Click += btnReset_Click;

                recyclerViewItem = FindViewById<RecyclerView>(Resource.Id.recycleViewDispatchItem);
                mLayoutManager = new LinearLayoutManager(this);
                recyclerViewItem.SetLayoutManager(mLayoutManager);

                BindRecycleView();

                ResetField();
                lblLine.Text = "1";

                vibrator = this.GetSystemService(VibratorService) as Vibrator;

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
            txtScanBottelBarcode.Text = txtScanBarcode.Text = lblMsg.Text = "";
            lblRefNo.Text = lblPlant.Text = lblLine.Text = lblBatchNo.Text = lblETIN.Text = lblPackSize.Text = lblStregth.Text = lblPlanId.Text = lblVolume.Text = "XXXX";
            txtScanBarcode.Enabled = true;
            //lblCaseBarcode.Text = "";
            //lblScanBottelCase.Text = "Scan Bottel Barcode:";
            txtScanBottelBarcode.Enabled = false;
            lblScanCount.Text = "0/0";
            txtScanBarcode.RequestFocus();
            tempScanningBarcode = "";
            lblMsg.Text = "";
            lblCaseBarcode.Text = "";
            if (_ListDispatchItem.Count > 0)
            {
                _ListDispatchItem.Clear();
                dispatchItemAdapter.NotifyDataSetChanged();
            }
        }
        private void BindView()
        {
            var progressDialog = ProgressDialog.Show(this, "", "Please wait...", true);
            try
            {
                string[] _RESPONSE = SendDataToServer("BIND_VIEW~", lblPlant.Text, lblLine.Text, lblETIN.Text, lblBatchNo.Text, "0", "0", "0", lblRefNo.Text, lblPlanId.Text);

                progressDialog.Hide();

                switch (_RESPONSE[0])
                {
                    case "VALID":
                        _ListDispatchItem.Clear();
                        string[] ArrRow = _RESPONSE[1].Split("#");
                        for (int i = 0; i < ArrRow.Length; i++)
                        {
                            string[] ArrCol = ArrRow[i].Split("$");
                            if (ArrCol[0].Trim() != "")
                                lblCaseBarcode.Text = ArrCol[0];
                            _ListDispatchItem.Add(new CaseItem
                            {
                                BottelBarcode = ArrCol[1],
                            });
                        }
                        lblScanCount.Text = _ListDispatchItem.Count + "/" + lblPackSize.Text.Trim();
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

        private void ScanAndSave()
        {
            if (lblScanCount.Text.Trim().Split('/')[0].Equals(lblPackSize.Text.Trim()))
            {
                //Case Scanning
                if (ScanCaseBarcode())
                {
                    ScanBarcode();
                }

            }
            else
            {
                //Bottel Scanning
                if (ScanBottelBarcode())
                {
                    ScanBarcode();
                }
            }
            if (lblScanCount.Text.Trim().Split('/')[0].Equals(lblPackSize.Text.Trim()) && lblCaseBarcode.Text.ToString() != "")
            {
                //Final Save
                SaveFinal();
            }
            else if (lblScanCount.Text.Trim().Split('/')[0].Equals(lblPackSize.Text.Trim()))
            {
                txtScanBottelBarcode.Text = "";
                txtScanBottelBarcode.Hint = "Scan Case Barcode";

            }

        }
        private bool ScanBottelBarcode()
        {
            bool bReturn = false;
            var progressDialog = ProgressDialog.Show(this, "", "Please wait...", true);
            try
            {
                string[] _RESPONSE = SendDataToServer("BOTTEL_SCAN~", lblPlant.Text, lblLine.Text, lblETIN.Text, lblBatchNo.Text, lblPackSize.Text, lblStregth.Text, lblVolume.Text, lblRefNo.Text, lblPlanId.Text);

                progressDialog.Hide();

                switch (_RESPONSE[0])
                {
                    case "VALID":
                        string ArrRow = _RESPONSE[1];
                        if (ArrRow == "Y")
                        {
                            lblMsg.Text = "Scanned Successfully!!!";
                            lblMsg.SetTextColor(Android.Graphics.Color.Green);
                            VibratorOK();
                            txtScanBottelBarcode.RequestFocus();
                            bReturn = true;
                        }
                        else
                        {
                            if (ArrRow == "ALREADY SCANNED!!!")
                            {
                                lblMsg.Text = _RESPONSE[1];
                                lblMsg.SetTextColor(Android.Graphics.Color.Red);
                                txtScanBottelBarcode.Text = "";
                                txtScanBottelBarcode.RequestFocus();
                                SoundAndVibratorNG();
                            }
                            else
                            {
                                lblMsg.Text = _RESPONSE[1];
                                lblMsg.SetTextColor(Android.Graphics.Color.Red);
                                txtScanBottelBarcode.Text = "";
                                txtScanBottelBarcode.RequestFocus();
                                SoundAndVibratorNG();
                            }
                        }
                        break;
                    case "ERROR":
                        lblMsg.Text = _RESPONSE[1];
                        lblMsg.SetTextColor(Android.Graphics.Color.Red);
                        txtScanBottelBarcode.Text = "";
                        txtScanBottelBarcode.RequestFocus();
                        SoundAndVibratorNG();
                        break;
                    case "INVALID":
                        lblMsg.Text = _RESPONSE[1];
                        lblMsg.SetTextColor(Android.Graphics.Color.Red);
                        txtScanBottelBarcode.Text = "";
                        txtScanBottelBarcode.RequestFocus();
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

        private bool ScanCaseBarcode()
        {
            bool bReturn = false;
            var progressDialog = ProgressDialog.Show(this, "", "Please wait...", true);
            try
            {
                string[] _RESPONSE = SendDataToServer("CASE_SCAN~", lblPlant.Text, lblLine.Text, lblETIN.Text, lblBatchNo.Text, lblPackSize.Text, lblStregth.Text, lblVolume.Text, lblRefNo.Text, lblPlanId.Text);

                progressDialog.Hide();

                switch (_RESPONSE[0])
                {
                    case "VALID":
                        string ArrRow = _RESPONSE[1];
                        if (ArrRow == "Y")
                        {
                            lblMsg.Text = "Case Scanned Successfully!!!";
                            StartPlayingVibrator();
                            lblMsg.SetTextColor(Android.Graphics.Color.Green);
                            txtScanBottelBarcode.RequestFocus();
                            lblCaseBarcode.Text = txtScanBottelBarcode.Text.Trim();
                            VibratorOK();
                            bReturn = true;
                        }
                        else
                        {
                            if (ArrRow == "ALREADY SCANNED!!!")
                            {
                                lblMsg.Text = _RESPONSE[1];
                                lblMsg.SetTextColor(Android.Graphics.Color.Red);
                                SoundAndVibratorNG();
                            }
                            else
                            {
                                lblMsg.Text = _RESPONSE[1];
                                lblMsg.SetTextColor(Android.Graphics.Color.Red);
                                SoundAndVibratorNG();
                            }
                        }
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

        private void SaveFinal()
        {

            var progressDialog = ProgressDialog.Show(this, "", "Please wait...", true);
            try
            {

                string[] _RESPONSE = SendDataToServer("SAVE_MASTER~", lblPlant.Text, lblLine.Text, lblETIN.Text, lblBatchNo.Text, lblPackSize.Text, lblStregth.Text, lblVolume.Text, lblRefNo.Text, lblPlanId.Text);

                progressDialog.Hide();

                switch (_RESPONSE[0])
                {
                    case "VALID":
                        string ArrRow = _RESPONSE[1];
                        if (ArrRow == "Y")
                        {
                            ResetField();
                            lblMsg.Text = "REWORK DONE!!!";
                            lblMsg.SetTextColor(Android.Graphics.Color.Green);
                            VibratorOK();

                        }
                        else
                        {
                            lblMsg.Text = "Data Not Saved!!!";
                            lblMsg.SetTextColor(Android.Graphics.Color.Red);
                            SoundAndVibratorNG();
                        }
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

        private void ScanBarcode()
        {
            //var progressDialog = ProgressDialog.Show(this, "", "Please wait...", true);
            try
            {
                string[] _RESPONSE = SendDataToServer("CHECK_SCAN_CASE_OR_BOTTEL~", lblPlant.Text, lblLine.Text, lblETIN.Text, lblBatchNo.Text, "0", "0", "0", lblRefNo.Text, lblPlanId.Text);

                //progressDialog.Hide();

                switch (_RESPONSE[0])
                {
                    case "VALID":
                        string[] ArrRow = _RESPONSE[1].Split("#");
                        string[] ArrCol = ArrRow[0].Split("$");
                        lblRefNo.Text = ArrCol[0].ToString();
                        lblPlant.Text = ArrCol[1].ToString();
                        lblLine.Text = ArrCol[2].ToString();
                        lblETIN.Text = ArrCol[3].ToString();
                        lblBatchNo.Text = ArrCol[4].ToString();
                        lblPackSize.Text = ArrCol[5].ToString();
                        lblStregth.Text = ArrCol[6].ToString();
                        lblVolume.Text = ArrCol[7].ToString();
                        lblPlanId.Text = ArrCol[8].ToString();
                        BindView();

                        txtScanBarcode.Enabled = false;
                        txtScanBarcode.Text = "";
                        txtScanBottelBarcode.Enabled = true;
                        txtScanBottelBarcode.RequestFocus();
                        //  lblCaseBarcode.Text = txtScanBottelBarcode.Text.Trim();
                        break;

                    case "ERROR":
                        lblMsg.Text = _RESPONSE[1];
                        lblMsg.SetTextColor(Android.Graphics.Color.Red);
                        SoundAndVibratorNG();
                        break;
                    case "INVALID":
                        lblMsg.Text = _RESPONSE[1];
                        lblMsg.SetTextColor(Android.Graphics.Color.Red);
                        txtScanBarcode.Text = "";
                        txtScanBarcode.RequestFocus();
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
                // progressDialog.Hide();
            }
            finally
            {
                // progressDialog.Hide();
            }
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            try
            {
                if (!lblRefNo.Text.Equals("XXXX"))
                {
                    Android.App.AlertDialog.Builder dialog = new Android.App.AlertDialog.Builder(this);
                    Android.App.AlertDialog alert = dialog.Create();
                    alert.SetTitle("Warning");
                    alert.SetMessage("Are you sure want Reset the data");
                    alert.SetButton("Yes", (c, ev) =>
                    {
                        ResetField();

                    });

                    alert.SetButton2("NO", (c, ev) => { });
                    alert.Show();
                    return;
                }
                else
                {
                    ResetField();
                }
            }
            catch (Exception ex)
            {
                lblMsg.Text = ex.Message;
                lblMsg.SetTextColor(Android.Graphics.Color.Red);
            }
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
                        if (txtScanBottelBarcode.Text.Length != 12 && txtScanBottelBarcode.Text.Length != 30)
                        {
                            lblMsg.Text = "Invalid Barcode!!!";
                            lblMsg.SetTextColor(Android.Graphics.Color.Red);
                            txtScanBottelBarcode.Text = "";
                            txtScanBottelBarcode.RequestFocus();
                            SoundAndVibratorNG();
                            return;
                        }
                        if (!lblScanCount.Text.Equals("0/0"))
                        {
                            if (lblScanCount.Text.Trim().Split('/')[0].Equals(lblPackSize.Text.Trim()))
                            {
                                if (txtScanBottelBarcode.Text.Length != 30)
                                {
                                    lblMsg.Text = "Invalid Case Barcode!!!";
                                    lblMsg.SetTextColor(Android.Graphics.Color.Red);
                                    txtScanBottelBarcode.Text = "";
                                    txtScanBottelBarcode.RequestFocus();
                                    SoundAndVibratorNG();
                                    return;
                                }
                            }

                        }
                        if (txtScanBottelBarcode.Text.Trim().Length == 30)
                        {
                            tempScanningBarcode = txtScanBottelBarcode.Text.Trim().Trim();
                        }
                        else
                        {
                            tempScanningBarcode = txtScanBottelBarcode.Text.Trim();
                        }
                        ScanAndSave(); //Scan Case Or Bottel Barcode (Second Field )
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
                        if (txtScanBarcode.Text.Length != 30 && txtScanBarcode.Text.Length != 12)
                        {
                            lblMsg.Text = "Invalid Barcode!!!";
                            lblMsg.SetTextColor(Android.Graphics.Color.Red);
                            txtScanBarcode.Text = "";
                            txtScanBarcode.RequestFocus();
                            return;
                        }
                        if (txtScanBarcode.Text.Trim().Length == 30)
                        {
                            tempScanningBarcode = txtScanBarcode.Text.Trim();
                        }
                        else
                        {
                            tempScanningBarcode = txtScanBarcode.Text.Trim();
                        }
                        ScanBarcode(); //Scan Case Or Bottel Barcode (First Field )
                        txtScanBarcode.SelectAll();
                    }
                    else
                        e.Handled = false;
                }
            }
            catch (Exception ex)
            {
                lblMsg.Text = ex.Message;
                lblMsg.SetTextColor(Android.Graphics.Color.Red);
                txtScanBarcode.Text = "";
                txtScanBarcode.RequestFocus();
            }
            finally
            {


            }
        }

        private void BindRecycleView()
        {
            try
            {
                dispatchItemAdapter = new CaseItemAdapter(_ListDispatchItem, this);
                recyclerViewItem.SetAdapter(dispatchItemAdapter);

            }
            catch (Exception ex) { throw ex; }
        }
        private string[] SendDataToServer(string Type, string lblPlant, string lblLine, string lblETIN, string lblBatchNo, string lblPackSize, string lblStregth, string lblVolume, string lblRefNo, string lblPlanId)
        {
            try
            {
                string _MESSAGE = Type + tempScanningBarcode.Trim() + "~" + lblPlant.Trim() + "~" + lblLine.Trim() + "~" + lblETIN.Trim() + "~" + lblBatchNo.Trim() + "~" + lblPackSize + "~" + lblStregth + "~" + lblVolume + "~" + lblRefNo.Trim() + "~" + lblPlanId.Trim() + "~" + clsGlobal.UserId + "}";
                string[] _RESPONSE = oNetwork.GetSetTcpNewApp(_MESSAGE).Split('~');
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
                    Thread.Sleep(3000);
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