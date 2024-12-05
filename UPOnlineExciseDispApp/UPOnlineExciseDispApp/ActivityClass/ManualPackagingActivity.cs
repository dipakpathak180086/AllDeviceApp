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

namespace UPOnlineExciseDispApp
{
    [Activity(Label = "Manual Packaging", WindowSoftInputMode = SoftInput.StateHidden, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation, ScreenOrientation = ScreenOrientation.Portrait)]
    public class ManualPackagingActivity : AppCompatActivity
    {
        clsGlobal clsGLB;
        clsNetwork oNetwork;
        MediaPlayer mediaPlayerSound;
        List<CaseItem> _ListDispatchItem = new List<CaseItem>();
        Vibrator vibrator;
        TextView lblTotalScanCount, lblBottelScanCount, lblMsg;
        EditText txtCaseBarcode, txtScanBottelBarcode;
        RecyclerView recyclerViewItem;
        CaseItemAdapter dispatchItemAdapter;
        RecyclerView.LayoutManager mLayoutManager;
        private Int32 _TotalCaseScanQty = 0, _TotalBottelQty = 0;
        public ManualPackagingActivity()
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
            base.OnCreate(savedInstanceState);
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.activity_ManualPackaging);

            lblTotalScanCount = FindViewById<TextView>(Resource.Id.lblTotalScanCount);
            lblBottelScanCount = FindViewById<TextView>(Resource.Id.lblBottelScanCount);
            lblMsg = FindViewById<TextView>(Resource.Id.lblMsg);

            //lblTotalScanCount.Text = "Pack Size :" + clsGlobal.PackSize;

            Button btnBack = FindViewById<Button>(Resource.Id.btnBack);
            btnBack.Click += (e, a) =>
            {
                oNetwork.TcpClosed();
                this.Finish();
            };

            txtCaseBarcode = FindViewById<EditText>(Resource.Id.txtCaseBarcode);
            txtCaseBarcode.KeyPress += txtCaseBarcode_KeyPress;

            txtScanBottelBarcode = FindViewById<EditText>(Resource.Id.txtScanBottelBarcode);
            txtScanBottelBarcode.KeyPress += txtScanBottelBarcode_KeyPress;

            recyclerViewItem = FindViewById<RecyclerView>(Resource.Id.recycleViewDispatchItem);
            mLayoutManager = new LinearLayoutManager(this);
            recyclerViewItem.SetLayoutManager(mLayoutManager);

            BindRecycleView();

            vibrator = this.GetSystemService(VibratorService) as Vibrator;
            BindUserDataAsync();
            lblMsg.Text = "";

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
        private bool IsValidForCaseBarcode()
        {
            try
            {
                if (txtCaseBarcode.Text.Trim() == "")
                {
                    StartPlayingSound();
                    ShowMessageBox("Scan case barcode", this);
                    txtCaseBarcode.RequestFocus();
                    return false;
                }
                return true;
            }
            catch (Exception ex) { throw ex; }
        }
        private bool IsValidForBottelBarcode()
        {
            try
            {
                if (IsValidForCaseBarcode() == false)
                {
                    return false;
                }
                if (txtScanBottelBarcode.Text.Trim() == "")
                {
                    StartPlayingSound();
                    ShowMessageBox("Scan Bottel barcode", this);
                    txtScanBottelBarcode.RequestFocus();
                    return false;
                }
                if (Convert.ToInt32(clsGlobal.PackSize) == _TotalBottelQty)
                {
                    StartPlayingSound();
                    BtnReset_Click(null, null);
                    ShowMessageBox("Scan completed", this);
                    return false;
                }
                return true;
            }
            catch (Exception ex) { throw ex; }
        }

        private async void Clear()
        {
            try
            {
                txtCaseBarcode.Text = "";
                txtScanBottelBarcode.Text = "";
                lblMsg.Text = "";
                _TotalCaseScanQty = 0;
                _TotalBottelQty = 0;
                lblTotalScanCount.Text = "Pack Size :" + _TotalCaseScanQty.ToString();
                lblBottelScanCount.Text = " Bottel Scan : " + _TotalBottelQty.ToString();
                txtCaseBarcode.Enabled = true;
                txtScanBottelBarcode.Enabled = false;
                txtCaseBarcode.RequestFocus();
                _ListDispatchItem.Clear();
                dispatchItemAdapter.NotifyDataSetChanged();


            }
            catch (Exception ex)
            {
                clsGLB.ShowMessage(ex.Message, this, MessageTitle.ERROR);
            }
        }
        private async void BtnReset_Click(object sender, EventArgs e)
        {
            try
            {

                Clear();
                txtCaseBarcode.RequestFocus();
            }
            catch (Exception ex)
            {
                clsGLB.ShowMessage(ex.Message, this, MessageTitle.ERROR);
            }
        }
        private string[] SendPickingDataToServer()
        {
            try
            {
                string CaseBarcode = txtCaseBarcode.Text.Trim() == "" ? txtCaseBarcode.Text.Trim() : txtCaseBarcode.Text.Trim();

                string _MESSAGE = "MANUALPACKAGING~" + clsGlobal.Db_Type + "~" + clsGlobal.BrandName.Trim() + "~" + clsGlobal.PackSize.Trim() + "~" + clsGlobal.BrandVolume.Trim() + "~" + clsGlobal.Strength.Trim() + "~" + clsGlobal.ETIN.Trim() + "~" + clsGlobal.BatchSerialNo.Trim() + "~" + CaseBarcode + "~" + txtScanBottelBarcode.Text.Trim() + "~" + clsGlobal.UserId + "~" + clsGlobal.LineId + "}";
                string[] _RESPONSE = oNetwork.fnSendReceiveData(_MESSAGE).Split('~');
                return _RESPONSE;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        private async void ValidateCaseDataAsync()
        {
            var progressDialog = ProgressDialog.Show(this, "", "Please wait...", true);
            try
            {
                clsGlobal.Db_Type = "VALIDATE_CASE_BARCODE";
                lblMsg.Text = "";
                string[] _RESPONSE = await Task.Run(() => SendPickingDataToServer());

                progressDialog.Hide();

                switch (_RESPONSE[0])
                {
                    case "VALID":
                        lblMsg.Text = _RESPONSE[1].Trim().ToString();
                        lblMsg.SetTextColor(Android.Graphics.Color.Green);
                        lblTotalScanCount.Text = "Pack Size :" + clsGlobal.PackSize;
                        BindBottelDataAsync();
                        //txtCaseBarcode.Text = caseBarcode;
                        txtCaseBarcode.Enabled = false;
                        txtScanBottelBarcode.RequestFocus();
                        break;

                    case "INVALID":
                        txtCaseBarcode.Text = "";
                        txtCaseBarcode.RequestFocus();
                        StartPlayingSound();
                        ShowMessageBox(_RESPONSE[1], this);
                        break;

                    case "ERROR":
                        txtCaseBarcode.Text = "";
                        txtCaseBarcode.RequestFocus();
                        StartPlayingSound();
                        ShowMessageBox(_RESPONSE[1], this);
                        break;

                    case "NO_CONNECTION":
                        txtCaseBarcode.Text = "";
                        txtCaseBarcode.RequestFocus();
                        StartPlayingSound();
                        ShowMessageBox("Communication server not connected", this);
                        break;

                    default:
                        txtCaseBarcode.Text = "";
                        txtCaseBarcode.RequestFocus();
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

        }
        //string caseBarcode = "";
        private void txtCaseBarcode_KeyPress(object sender, View.KeyEventArgs e)
        {
            try
            {
                if (e.Event.Action == KeyEventActions.Down)
                {
                    if (e.KeyCode == Keycode.Enter)
                    {

                        //await Task.Run(() =>
                        //{
                        if (IsValidForCaseBarcode())
                        {
                            txtCaseBarcode.SelectAll();
                            ValidateCaseDataAsync();
                        }
                        else
                        {
                            txtCaseBarcode.Text = "";
                        }
                        //});
                    }
                    else
                    {
                        e.Handled = false;
                    }
                }
            }
            catch (Exception ex)
            {
                StartPlayingSound();
                ShowMessageBox("Error : " + ex.Message, this);
            }
        }
        private async void BindUserDataAsync()
        {
            //var progressDialog = ProgressDialog.Show(this, "", "Please wait...", true);
            try
            {
                clsGlobal.Db_Type = "BIND_USER_DATA";
                lblMsg.Text = "";
                string[] _RESPONSE = await Task.Run(() => SendPickingDataToServer());

                // progressDialog.Hide();

                switch (_RESPONSE[0])
                {
                    case "VALID":
                        _ListDispatchItem.Clear();
                        string[] ArrRow = _RESPONSE[1].Split("#");
                        for (int i = 0; i < ArrRow.Length; i++)
                        {
                            string[] ArrCol = ArrRow[i].Split("$");
                            if (ArrCol[0].ToString() == "NO DATA FOUND")
                            { continue; }
                            //txtCaseBarcode.Text = "90" + ArrCol[0].ToString();
                            txtCaseBarcode.Text =  ArrCol[0].ToString();
                            txtCaseBarcode.Enabled = false;
                            txtScanBottelBarcode.Enabled = true;
                            txtScanBottelBarcode.RequestFocus();
                            //lblMsg.Text = ArrCol[0];
                            //lblMsg.SetTextColor(Android.Graphics.Color.Green);
                            _ListDispatchItem.Add(new CaseItem
                            {

                                BottelBarcode = ArrCol[1],
                            });
                        }
                        dispatchItemAdapter.NotifyDataSetChanged();
                        lblBottelScanCount.Text = "Bottel Scan :" + _ListDispatchItem.Count;
                        break;

                    case "INVALID":
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
                // progressDialog.Hide();
            }

        }
        private async void BindBottelDataAsync()
        {
            //var progressDialog = ProgressDialog.Show(this, "", "Please wait...", true);
            try
            {
                clsGlobal.Db_Type = "BIND_BOTTEL_DATA";
                lblMsg.Text = "";
                string[] _RESPONSE = await Task.Run(() => SendPickingDataToServer());

                //progressDialog.Hide();

                switch (_RESPONSE[0])
                {
                    case "VALID":
                        _ListDispatchItem.Clear();
                        string[] ArrRow = _RESPONSE[1].Split("#");
                        for (int i = 0; i < ArrRow.Length; i++)
                        {
                            string[] ArrCol = ArrRow[i].Split("$");
                            //lblMsg.Text = ArrCol[0];
                            //lblMsg.SetTextColor(Android.Graphics.Color.Green);
                            _ListDispatchItem.Add(new CaseItem
                            {
                                BottelBarcode = ArrCol[1],
                            });
                        }
                        dispatchItemAdapter.NotifyDataSetChanged();
                        break;

                    case "INVALID":
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
                //progressDialog.Hide();
            }

        }
        private async void ValidateBottelDataAsync()
        {
            var progressDialog = ProgressDialog.Show(this, "", "Please wait...", true);
            try
            {
                clsGlobal.Db_Type = "VALIDATE_BOTTEL_BARCODE";
                lblMsg.Text = "";
                string[] _RESPONSE = await Task.Run(() => SendPickingDataToServer());

                progressDialog.Hide();

                switch (_RESPONSE[0])
                {
                    case "VALID":
                        lblMsg.Text = _RESPONSE[1].Split('|')[0].ToString();
                        lblMsg.SetTextColor(Android.Graphics.Color.Green);
                        // _TotalCaseScanQty = Convert.ToInt32(_RESPONSE[1].Split('|')[1].ToString());
                        _TotalBottelQty = Convert.ToInt32(_RESPONSE[1].Split('|')[2].ToString());
                        lblBottelScanCount.Text = " Bottel Scan : " + _TotalBottelQty.ToString();



                        if (Convert.ToInt32(clsGlobal.PackSize) == _TotalBottelQty)
                        {
                            BtnReset_Click(null, null);
                            _ListDispatchItem.Clear();
                            dispatchItemAdapter.NotifyDataSetChanged();
                            ShowMessageBox("Scan completed", this);
                            return;
                        }
                        else
                        {
                            //BindBottelDataAsync();
                            _ListDispatchItem.Add(new CaseItem
                            {
                                BottelBarcode = txtScanBottelBarcode.Text.Trim(),
                            });

                            dispatchItemAdapter.NotifyDataSetChanged();
                            txtScanBottelBarcode.Text = "";
                            txtScanBottelBarcode.RequestFocus();
                        }
                        break;

                    case "INVALID":
                        txtScanBottelBarcode.Text = "";
                        txtScanBottelBarcode.RequestFocus();
                        StartPlayingSound();
                        ShowMessageBox(_RESPONSE[1], this);
                        if (_RESPONSE[1].ToString().Equals("CASE SCAN COMPLETED"))
                        {
                            _TotalBottelQty = _TotalBottelQty + 1;
                            lblBottelScanCount.Text = " Bottel Scan : " + _TotalBottelQty.ToString();

                            BtnReset_Click(null, null);
                            _ListDispatchItem.Clear();
                            dispatchItemAdapter.NotifyDataSetChanged();
                            return;

                        }
                        //StartPlayingSound();
                        //ShowMessageBox(_RESPONSE[1], this);

                        break;

                    case "ERROR":
                        txtScanBottelBarcode.Text = "";
                        txtScanBottelBarcode.RequestFocus();
                        StartPlayingSound();
                        ShowMessageBox(_RESPONSE[1], this);
                        break;

                    case "NO_CONNECTION":
                        txtScanBottelBarcode.Text = "";
                        txtScanBottelBarcode.RequestFocus();
                        StartPlayingSound();
                        ShowMessageBox("Communication server not connected", this);
                        break;

                    default:
                        txtScanBottelBarcode.Text = "";
                        txtScanBottelBarcode.RequestFocus();
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
        private void txtScanBottelBarcode_KeyPress(object sender, View.KeyEventArgs e)
        {
            try
            {
                if (e.Event.Action == KeyEventActions.Down)
                {
                    if (e.KeyCode == Keycode.Enter)
                    {
                        //await  Task.Run(() =>
                        //  {

                        if (IsValidForCaseBarcode())
                        {
                            txtScanBottelBarcode.SelectAll();
                            ValidateBottelDataAsync();
                        }
                        else
                        {
                            txtScanBottelBarcode.Text = "";
                            txtScanBottelBarcode.RequestFocus();
                        }
                        //});
                    }
                    else
                    {
                        e.Handled = false;
                    }
                }
            }
            catch (Exception ex)
            {
                StartPlayingSound();
                ShowMessageBox("Error : " + ex.Message, this);
            }
        }
    }
}