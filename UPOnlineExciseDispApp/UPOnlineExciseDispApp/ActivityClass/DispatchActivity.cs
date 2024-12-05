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
    [Activity(Label = "UP Online Excise Dispatch App", WindowSoftInputMode = SoftInput.StateHidden, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation, ScreenOrientation = ScreenOrientation.Portrait)]
    public class DispatchActivity : AppCompatActivity
    {
        Vibrator vibrator;
        clsGlobal clsGLB;
        clsNetwork oNetwork;
        int _ScanCount = 0;
        MediaPlayer mediaPlayerSound;
        Vibrator vibrator;
        List<string> _ListGipNo = new List<string>();
        List<DispatchItem> _ListDispatchItem = new List<DispatchItem>();

        Spinner cmbIGPNo;
        TextView lblMessage, lblScanCount;
        EditText txtCaseBarcode, txtVehicleNo;
        Button btnClear;

        RecyclerView recyclerViewItem;
        DispatchItemAdapter dispatchItemAdapter;
        RecyclerView.LayoutManager mLayoutManager;

        public DispatchActivity()
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

        #region Activity Events
        protected override void OnCreate(Bundle savedInstanceState)
        {
            try
            {
                base.OnCreate(savedInstanceState);
                // Set our view from the "main" layout resource
                SetContentView(Resource.Layout.activity_dispatch);

                lblMessage = FindViewById<TextView>(Resource.Id.lblMessage);
                lblMessage.Text = "";

                lblScanCount = FindViewById<TextView>(Resource.Id.lblScanCount);

                cmbIGPNo = FindViewById<Spinner>(Resource.Id.cmbIGPNo);
                cmbIGPNo.ItemSelected += CmbIGPNo_ItemSelected;

                txtCaseBarcode = FindViewById<EditText>(Resource.Id.txtCaseBarcode);
                txtCaseBarcode.KeyPress += txtCaseBarcode_KeyPress;

                txtVehicleNo = FindViewById<EditText>(Resource.Id.txtVehicleNo);

                Button btnBack = FindViewById<Button>(Resource.Id.btnBack);
                btnBack.Click += (e, a) =>
                {
                    oNetwork.TcpClosed();
                    this.Finish();
                };

                btnClear = FindViewById<Button>(Resource.Id.btnClear);
                btnClear.Click += btnClear_Click;

                recyclerViewItem = FindViewById<RecyclerView>(Resource.Id.recycleViewDispatchItem);
                mLayoutManager = new LinearLayoutManager(this);
                recyclerViewItem.SetLayoutManager(mLayoutManager);

                BindRecycleView();

                vibrator = this.GetSystemService(VibratorService) as Vibrator;

                GetDeliveryNumber();
            }
            catch (Exception ex)
            {
                clsGLB.ShowMessage(ex.Message, this, MessageTitle.ERROR);
            }
        }

        public override void OnBackPressed()
        {
        }

        #endregion

        #region Button Events

        private void btnClear_Click(object sender, EventArgs e)
        {
            try
            {
                ClearAll();
                txtCaseBarcode.RequestFocus();
            }
            catch (Exception ex)
            {
                StartPlayingSound();
                ShowMessageBox(ex.Message, this);
            }
        }

        #endregion

        #region Methods

        private void BindRecycleView()
        {
            try
            {
                dispatchItemAdapter = new DispatchItemAdapter(_ListDispatchItem, this);
                recyclerViewItem.SetAdapter(dispatchItemAdapter);

            }
            catch (Exception ex) { throw ex; }
        }
        public void GetDeliveryNumber()
        {
            try
            {
                string _MESSAGE = "V_FILLDELIVERYCHALAN~" + "}";
                string[] _RESPONSE = oNetwork.fnSendReceiveData(_MESSAGE).Split('~');

                switch (_RESPONSE[0])
                {
                    case "VALID":
                        _ListGipNo.Clear();
                        _ListGipNo.Add("--Select--");
                        for (int i = 1; i < _RESPONSE.Length; i++)
                        {
                            _ListGipNo.Add(_RESPONSE[i]);
                        }
                        ArrayAdapter<string> arrayAdapter = new ArrayAdapter<string>(this, Resource.Layout.Spiner, _ListGipNo);
                        cmbIGPNo.Adapter = arrayAdapter;
                        cmbIGPNo.SetSelection(0);

                        break;
                    case "INVALID":
                        txtCaseBarcode.Text = "";
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
                StartPlayingSound();
                ShowMessageBox(ex.Message, this);
            }
        }

        public void fillVehicleNo_PrrmitNo(string DeliveryNo)
        {
            try
            {
                string _MESSAGE = "V_FILLVEHICLENO~" + DeliveryNo + "~" + "}";
                string[] _RESPONSE = oNetwork.fnSendReceiveData(_MESSAGE).Split('~');

                switch (_RESPONSE[0])
                {
                    case "VALID":
                        txtVehicleNo.Text = _RESPONSE[1];
                        GetDeliveryDetails(cmbIGPNo.SelectedItem.ToString());
                        break;

                    case "INVALID":
                        cmbIGPNo.SetSelection(0);
                        txtCaseBarcode.Text = "";
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
                StartPlayingSound();
                ShowMessageBox(ex.Message, this);
            }
        }

        private void GetDeliveryDetails(string deliveryNo)
        {
            try
            {
                string _MESSAGE = "V_DELIVERY_DETAILS~" + deliveryNo + "}";
                string msg = oNetwork.fnSendReceiveData(_MESSAGE);
                string[] _RESPONSE = msg.Split('~');

                switch (_RESPONSE[0])
                {
                    case "VALID":
                        _ListDispatchItem.Clear();
                        _ScanCount = 0;

                        foreach (string sRow in _RESPONSE[1].Split('$'))
                        {
                            string[] sArrCol = sRow.Split('#');
                            _ListDispatchItem.Add(new DispatchItem
                            {
                                GipNo = sArrCol[0],
                                CaseQty = Convert.ToInt32(sArrCol[1]),
                                DispatchQty = Convert.ToInt32(sArrCol[2]),
                                ETIN = sArrCol[3],
                                BrandShotName = sArrCol[4]
                            });
                            _ScanCount += Convert.ToInt32(sArrCol[2]);
                        }

                        dispatchItemAdapter.NotifyDataSetChanged();
                        lblScanCount.Text = "Scan Count : " + _ScanCount;
                        txtCaseBarcode.RequestFocus();
                        break;

                    case "INVALID":
                        cmbIGPNo.SetSelection(0);
                        txtCaseBarcode.Text = "";
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
                StartPlayingSound();
                ShowMessageBox(ex.Message, this);
            }
        }


        private async void SaveDispatchDataAsync(string DeliveryNo, string txtcasebarcode, string username, string datetime, string mode,string GetEtin)
        {
            var progressDialog = ProgressDialog.Show(this, "", "Please wait...", true);
            try
            {
                bool ETINFound = false;
                foreach (var Item in _ListDispatchItem)
                {
                    string CaseETIN = GetEtin;
                    string PETIN = Item.ETIN;
                    if (GetEtin == Item.ETIN)
                    {
                        ETINFound = true;
                        int iCaseQty = Item.CaseQty;
                        int iScanQty = Item.DispatchQty;
                        if (iScanQty < iCaseQty)
                        {
                            string[] _RESPONSE = await Task.Run(() => SendDataToServer(DeliveryNo, txtcasebarcode, username, datetime, mode));

                            // progressDialog.Hide();

                            switch (_RESPONSE[0])
                            {
                                case "VALID":
                                    txtCaseBarcode.Text = "";
                                    if (_RESPONSE[1] == "OK")
                                    {
                                        lblMessage.Text = "Dispatch Complete.";
                                        _ScanCount++;
                                        lblScanCount.Text = "Scan Count : " + _ScanCount;
                                        Item.DispatchQty++;
                                    }
                                    else
                                    {
                                        StartPlayingSound();
                                        ShowMessageBox(_RESPONSE[1].ToString(), this);
                                        txtCaseBarcode.Text = "";
                                        txtCaseBarcode.RequestFocus();
                                    }
                                    break;

                                case "INVALID":
                                    StartPlayingSound();
                                    ShowMessageBox(_RESPONSE[1].ToString(), this);
                                    lblMessage.Text = _RESPONSE[1].ToString();
                                    txtCaseBarcode.Text = "";
                                    txtCaseBarcode.RequestFocus();
                                    break;

                                case "ERROR":
                                    StartPlayingSound();
                                    ShowMessageBox(_RESPONSE[1].ToString(), this);
                                    lblMessage.Text = _RESPONSE[1].ToString();
                                    txtCaseBarcode.Text = "";
                                    txtCaseBarcode.RequestFocus();
                                    break;

                                case "NO_CONNECTION":
                                    StartPlayingSound();
                                    ShowMessageBox("Communication server not connected", this);
                                    txtCaseBarcode.Text = "";
                                    txtCaseBarcode.RequestFocus();
                                    break;

                                default:
                                    StartPlayingSound();
                                    ShowMessageBox("No option match from comm server", this);
                                    break;
                            }
                            break;
                        }
                        else
                        {
                            // progressDialog.Hide();
                            StartPlayingSound();
                            ShowMessageBox("Dispatch Qty Complete For ETIN", this);
                            lblMessage.Text = "Dispatch Qty Complete For ETIN";
                            txtCaseBarcode.Text = "";
                            txtCaseBarcode.RequestFocus();
                            break;
                        }
                    }
                }
                if (ETINFound == false)
                {
                    // progressDialog.Hide();
                    StartPlayingSound();
                    ShowMessageBox("ETIN not belong to GIP", this);
                    lblMessage.Text = "ETIN not belong to GIP";
                    txtCaseBarcode.Text = "";
                    txtCaseBarcode.RequestFocus();
                }
                dispatchItemAdapter.NotifyDataSetChanged();
            }
            catch (Exception ex)
            {
                progressDialog.Hide();
                StartPlayingSound();
                ShowMessageBox(ex.Message, this);
            }
            finally
            {
                progressDialog.Hide();
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

        private void ClearAll()
        {
            cmbIGPNo.SetSelection(0);
            //lv.Items.Clear();
            lblMessage.Text = "";
            txtCaseBarcode.Text = "";

            txtVehicleNo.Text = "";
            _ScanCount = 0;
            lblScanCount.Text = "Scan Count : " + _ScanCount;
        }

        private string[] SendDataToServer(string DeliveryNo, string txtcasebarcode, string username, string datetime, string mode)
        {
            try
            {
                string _MESSAGE = "V_CASE~" + DeliveryNo.Trim() + "~" + txtcasebarcode.Trim() + "~" + clsGlobal.UserId + "~" + datetime + "}";
                string[] _RESPONSE = oNetwork.fnSendReceiveData(_MESSAGE).Split('~');


                return _RESPONSE;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        private string[] SendDataToServerForEtin(string caseBarcode)
        {
            try
            {
                string _MESSAGE = "V_GET_ETIN~" + caseBarcode.Trim() + "}";
                string[] _RESPONSE = oNetwork.fnSendReceiveData(_MESSAGE).Split('~');


                return _RESPONSE;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        #endregion

        #region EditText Events
        private void txtCaseBarcode_KeyPress(object sender, View.KeyEventArgs e)
        {
            try
            {
                if (e.Event.Action == KeyEventActions.Down)
                {
                    if (e.KeyCode == Keycode.Enter)
                    {
                        lblMessage.Text = "";
                        if (cmbIGPNo.SelectedItemPosition <= 0)
                        {
                            StartPlayingSound();
                            ShowMessageBox("Select permit no.", this);
                            lblMessage.Text = "Please select pemit no.";
                        }
                        else if (txtCaseBarcode.Text != "" && txtCaseBarcode.Text.Trim().Length == 35)
                        {
                            txtCaseBarcode.RequestFocus();
                            if (txtCaseBarcode.Text.Trim().Length != 35)
                            {
                                StartPlayingSound();
                                ShowMessageBox("Invalid case barcode", this);
                                txtCaseBarcode.Text = "";
                                lblMessage.Text = "Invalid case barcode";
                                txtCaseBarcode.RequestFocus();
                                return;
                            }
                            else if (cmbIGPNo.SelectedItemPosition <= 0)
                            {
                                StartPlayingSound();
                                ShowMessageBox("Please select pemit no.", this);
                                txtCaseBarcode.Text = "";
                                lblMessage.Text = "Please select pemit no.";
                                return;
                            }
                            string[] _RESPONSE = SendDataToServerForEtin(txtCaseBarcode.Text.Trim());

                            // progressDialog.Hide();
                            string etin = "";
                            switch (_RESPONSE[0])
                            {
                                case "VALID":
                                    etin = _RESPONSE[1].Trim();
                                    SaveDispatchDataAsync(cmbIGPNo.SelectedItem.ToString(), txtCaseBarcode.Text, clsGlobal.UserId, "", "F", etin);
                                    break;
                                case "INVALID":
                                    StartPlayingSound();
                                    ShowMessageBox(_RESPONSE[1].ToString(), this);
                                    lblMessage.Text = _RESPONSE[1].ToString();
                                    txtCaseBarcode.Text = "";
                                    txtCaseBarcode.RequestFocus();
                                    break;
                            }
                         
                            txtCaseBarcode.Text = "";
                            txtCaseBarcode.RequestFocus();
                        }
                        else
                        {
                            StartPlayingSound();
                            ShowMessageBox("Invalid case serial no.", this);
                            txtCaseBarcode.Text = "";
                            lblMessage.Text = "Invalid case serial no.";
                            txtCaseBarcode.RequestFocus();
                        }
                    }
                    else
                        e.Handled = false;
                }
            }
            catch (Exception ex)
            {
                StartPlayingSound();
                ShowMessageBox(ex.Message, this);
            }
        }

        #endregion

        #region Spinner(CoboBox) Event

        private void CmbIGPNo_ItemSelected(object sender, AdapterView.ItemSelectedEventArgs e)
        {
            try
            {
                if (cmbIGPNo.SelectedItemPosition > 0)
                {
                    _ListDispatchItem.Clear();
                    dispatchItemAdapter.NotifyDataSetChanged();

                    _ScanCount = 0;
                    lblScanCount.Text = "Scan Count : " + _ScanCount;

                    lblMessage.Text = "";
                    fillVehicleNo_PrrmitNo(cmbIGPNo.SelectedItem.ToString());
                }
            }
            catch (Exception ex)
            {
                StartPlayingSound();
                ShowMessageBox(ex.Message, this);
            }
        }

        #endregion
    }
}