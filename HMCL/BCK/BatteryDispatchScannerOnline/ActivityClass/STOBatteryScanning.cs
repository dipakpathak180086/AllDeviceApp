using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.Media;
using Android.OS;
using Android.Runtime;
using Android.Support.V7.Widget;
using Android.Views;
using Android.Views.InputMethods;
using Android.Widget;

namespace BatteryDispatchScannerOnline.ActivityClass
{
    [Activity(Label = "STOBatteryScanning", WindowSoftInputMode = Android.Views.SoftInput.StateAlwaysHidden, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation, ScreenOrientation = ScreenOrientation.Portrait)]
    public class STOBatteryScanning : Activity
    {
        Dictionary<string, string> dicRegPlant = new Dictionary<string, string>();
        clsGlobal clsGLB;
        EditText txtDelivery, txtTruckNo, txtBattery,txtFrame;
        CheckBox chkFram;
        TextView lblResult;
        TextView lblCount;
        //ModNet modnet;
        int dispatchcunt = 0;
        List<ViewBatteryData> _ListItem = new List<ViewBatteryData>();
        string selectedSKU = string.Empty;
        RecyclerView recyclerViewItem;
        BatteryItemAdapter receivingItemAdapter;
        RecyclerView.LayoutManager mLayoutManager;
        public STOBatteryScanning()
        {
            try
            {
                clsGLB = new clsGlobal();
                dicRegPlant.Add("HHHU", "HHHU");
                //modnet = new ModNet();

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
                SetContentView(Resource.Layout.activity_STOBatteryScanning);

                //cmbSite = FindViewById<Spinner>(Resource.Id.cmbSite);

                Button btn = FindViewById<Button>(Resource.Id.btnBack);
                btn.Click += Btnback_Click;
                Button btnClear = FindViewById<Button>(Resource.Id.btnClear);
                btnClear.Click += BtnClear_Click;

                chkFram = FindViewById<CheckBox>(Resource.Id.chkFrame);
                chkFram.CheckedChange += ChkFram_CheckedChange;

                txtDelivery = FindViewById<EditText>(Resource.Id.editDelivery);
                txtDelivery.KeyPress += TxtDelivery_KeyPress;
                txtDelivery.FocusChange += TxtDelivery_FocusChange;
                txtTruckNo = FindViewById<EditText>(Resource.Id.editTruckNo);
                txtTruckNo.KeyPress += txtTruckNo_KeyPress;
                txtTruckNo.FocusChange += txtTruckNo_FocusChange;


                txtFrame = FindViewById<EditText>(Resource.Id.editFrame);
                txtFrame.KeyPress += TxtFrame_KeyPress;

                txtBattery = FindViewById<EditText>(Resource.Id.editBatteryBarcode);
                txtBattery.KeyPress += TxtBattery_KeyPress;

                dispatchcunt = 0;

                lblResult = FindViewById<TextView>(Resource.Id.lblDisResult);
              

                recyclerViewItem = FindViewById<RecyclerView>(Resource.Id.recycleViewReceiveItem);
                mLayoutManager = new LinearLayoutManager(this);
                recyclerViewItem.SetLayoutManager(mLayoutManager);
                //modnet.InitializeTCPClient();
                //Button btnBack = FindViewById<Button>(Resource.Id.btnBack);
                //btnBack.Click += (e, a) =>
                //{
                //    this.Finish();
                //};

                //txtBattery.Enabled = txtTruckNo.Enabled = false;
                txtDelivery.Enabled = true;
                txtDelivery.RequestFocus();
            }
            catch (Exception ex)
            {
                clsGLB.ShowMessage(ex.Message, this, MessageTitle.ERROR);
            }
        }

        private void ChkFram_CheckedChange(object sender, CompoundButton.CheckedChangeEventArgs e)
        {
            if (chkFram.Checked)
            {
                txtFrame.Enabled = true;
            }
            else
            {
                txtFrame.Enabled = false;
            }
        }

        private void TxtFrame_KeyPress(object sender, View.KeyEventArgs e)
        {
            try
            {
                if (e.Event.Action == KeyEventActions.Down)
                {
                    if (e.KeyCode == Keycode.Enter)
                    {
                        //DismissKeyboard();
                        txtBattery.RequestFocus();
                    }
                    else
                        e.Handled = false;
                }
            }
            catch (Exception ex)
            {
                clsGLB.ShowMessage(ex.Message, this, MessageTitle.ERROR);
                txtTruckNo.Text = "";
                txtTruckNo.RequestFocus();
            }
        }

        private void BindRecycleView()
        {
            try
            {
                _ListItem.Clear();
                selectedSKU = "";
                string[] sArr = ModInit.GstrResult.Split("@");

                for (int i = 0; i < sArr.Length; i++)
                {
                    ModInit.Gstrarr = sArr[i].Split('~');
                    if (ModInit.Gstrarr.Length > 0)
                    {
                        if (ModInit.Gstrarr[1] == "") { continue; }
                        if (ModInit.Gstrarr[3].ToString() != "" && !dicRegPlant.ContainsKey(ModInit.Gstrarr[3].ToString()))
                        {

                            clsGLB.ShowMessage($"This Plant {ModInit.Gstrarr[3].ToString()} is not registered!!!", this, MessageTitle.ERROR);
                            _ListItem.Clear();
                            break;
                        }
                        _ListItem.Add(new ViewBatteryData { Delivery = ModInit.Gstrarr[0], SKU = ModInit.Gstrarr[1], Qty = ModInit.Gstrarr[2], Plant = ModInit.Gstrarr[3].ToString(), ScanQty = ModInit.Gstrarr[4].ToString(), MSG = ModInit.Gstrarr[5].ToString() });
                        //var SelectedItem = _ListItem.Find(x => x.Delivery == ModInit.Gstrarr[0].ToString() && x.SKU == ModInit.Gstrarr[1].ToString());
                        //if (SelectedItem == null)
                        //{
                        //    _ListItem.Add(new ViewBatteryData { Delivery = ModInit.Gstrarr[0], SKU = ModInit.Gstrarr[1], Qty = ModInit.Gstrarr[2], Plant = ModInit.Gstrarr[3].ToString(), ScanQty = ModInit.Gstrarr[4].ToString(), MSG = ModInit.Gstrarr[5].ToString() });
                        //}
                    }
                }
                receivingItemAdapter = new BatteryItemAdapter(this, _ListItem);
                receivingItemAdapter.btnCheck += ReceivingItemAdapter_btnCheck;
                recyclerViewItem.SetAdapter(receivingItemAdapter);

            }
            catch (Exception ex) { throw ex; }
        }

        private void ReceivingItemAdapter_btnCheck(object sender, int e)
        {
            try
            {
                selectedSKU = "";
                _ListItem[e].chkCheck = true;

                for (int i = 0; i < _ListItem.Count; i++)
                {
                    if (_ListItem[i].chkCheck && i != e)
                    {
                        _ListItem[i].chkCheck = false;
                    }
                    if (_ListItem[i].chkCheck)
                    {
                        selectedSKU = _ListItem[i].SKU;
                    }
                }
                try
                {
                    receivingItemAdapter.NotifyDataSetChanged();
                }
                catch (Exception)
                {


                }

            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        private void txtTruckNo_FocusChange(object sender, View.FocusChangeEventArgs e)
        {

        }

        private void DismissKeyboard()
        {
            var view = CurrentFocus;
            if (view != null)
            {
                var imm = (InputMethodManager)GetSystemService(InputMethodService);
                imm.HideSoftInputFromWindow(view.WindowToken, 0);
            }
        }

        private void DismissKeyboard2()
        {
            var currentFocus = this.CurrentFocus;
            if (currentFocus != null)
            {
                InputMethodManager inputMethodManager = (InputMethodManager)this.GetSystemService(Context.InputMethodService);
                inputMethodManager.HideSoftInputFromWindow(currentFocus.WindowToken, HideSoftInputFlags.None);
            }

        }

        private string GetBtteryBarcode(string scannedBarcode)
        {
            string finalBatterybarcode = string.Empty;
            try
            {
                //Single Barcode only Exide
                if (scannedBarcode.Length == 15)
                {
                    finalBatterybarcode += scannedBarcode.Substring(0,11) + "$";
                }
                else
                {
                    //MasterBarcode For Both and Amron For single
                    string[] sArr = scannedBarcode.Split('&');
                    for (int i = 0; i < sArr.Length - 1; i++)
                    {
                        if (sArr[i].Length == 11)
                        {
                            finalBatterybarcode += sArr[i].ToString() + "$";
                        }

                    }
                }
                finalBatterybarcode = finalBatterybarcode.TrimEnd('$');

            }
            catch (Exception ex)
            {

                throw ex;
            }
            return finalBatterybarcode;
        }


        private void TxtDelivery_FocusChange(object sender, View.FocusChangeEventArgs e)
        {
            try
            {
                
            }
            catch (Exception ex)
            {
                clsGLB.ShowMessage(ex.Message, this, MessageTitle.ERROR);
            }
        }


        private void txtTruckNo_KeyPress(object sender, View.KeyEventArgs e)
        {
            try
            {
                if (e.Event.Action == KeyEventActions.Down)
                {
                    if (e.KeyCode == Keycode.Enter)
                    {
                        //DismissKeyboard();
                        if (txtTruckNo.Text.Length > 0)
                        {
                            //txtDelivery.Enabled = false;
                            txtBattery.Enabled = true;
                            txtBattery.RequestFocus();
                        }
                    }
                    else
                        e.Handled = false;
                }
            }
            catch (Exception ex)
            {
                clsGLB.ShowMessage(ex.Message, this, MessageTitle.ERROR);
                txtTruckNo.Text = "";
                txtTruckNo.RequestFocus();
            }
        }
        private void TxtBattery_KeyPress(object sender, View.KeyEventArgs e)
        {
            try
            {
                if (e.Event.Action == KeyEventActions.Down)
                {
                    if (e.KeyCode == Keycode.Enter)
                    {
                        //DismissKeyboard();

                        if (ValidateControls())
                        {
                            lblResult.Text = "";
                            //txtBattery.SetRawInputType(Android.Text.InputTypes.Null);
                            //txtBattery.InputType = Android.Text.InputTypes.Null;
                            //DismissKeyboard2();
                            string strBatteryBarcode = GetBtteryBarcode(txtBattery.Text.Trim());
                            if (string.IsNullOrEmpty(strBatteryBarcode))
                            {
                                Toast.MakeText(this, "Invalid Battery Barcode.", ToastLength.Long).Show();
                                txtBattery.RequestFocus();
                                return;
                            }
                            if (ModNet.STOBatteryScanningDataSave(selectedSKU, txtDelivery.Text.Trim(), txtTruckNo.Text.Trim(), strBatteryBarcode,txtFrame.Text.Trim()))
                            {
                                for (int i = 0; i < _ListItem.Count; i++)
                                {
                                    if (_ListItem[i].chkCheck)
                                    {
                                        string[] strScannedQty = strBatteryBarcode.Split('$'); //Length
                                        _ListItem[i].ScanQty = Convert.ToString(Convert.ToDecimal(_ListItem[i].ScanQty) + strScannedQty.Length);
                                        _ListItem[i].MSG = "OK";
                                        receivingItemAdapter.NotifyDataSetChanged();
                                        break;
                                    }
                                }
                                lblResult.Text = "Last Battery : " + txtBattery.Text.ToUpper().Trim();
                                txtFrame.Text = "";
                                txtFrame.RequestFocus();
                                txtBattery.Text = "";
                                txtBattery.RequestFocus();
                                //dispatchcunt++;
                                //lblCount.Text = dispatchcunt.ToString();
                            }
                            else
                            {
                                lblResult.Text = ModInit.Gstrarr[0];
                                txtFrame.Text = "";
                                txtFrame.RequestFocus();
                           
                                txtBattery.Text = "";
                                txtBattery.RequestFocus();
                            }
                        }
                    }
                    else
                        e.Handled = false;
                }
            }
            catch (Exception ex)
            {
                clsGLB.ShowMessage(ex.Message, this, MessageTitle.ERROR);
                txtTruckNo.Text = "";
                txtTruckNo.RequestFocus();
            }
        }
        private void BtnClear_Click(object sender, EventArgs e)
        {
            try
            {
                clear();
            }
            catch (Exception ex)
            {
                clsGLB.ShowMessage(ex.Message, this, MessageTitle.ERROR);
            }
        }

        private void Btnback_Click(object sender, EventArgs e)
        {
            try
            {
                this.Finish();
                //OpenActivity(typeof(MainActivity));
            }
            catch (Exception ex)
            {
                clsGLB.ShowMessage(ex.Message, this, MessageTitle.ERROR);
            }
        }

        private void TxtDelivery_KeyPress(object sender, View.KeyEventArgs e)
        {
            try
            {
                if (e.Event.Action == KeyEventActions.Down)
                {
                    if (e.KeyCode == Keycode.Enter)
                    {
                        if (txtDelivery.Text.Length > 0)
                        {
                            if ((txtDelivery.Text.Trim().Length != 8))
                            {
                                clsGLB.showToastNGMessage("Invalid Delivery No.", this);
                            }
                            if (ModNet.FetchBatteryDeliveryData(txtDelivery.Text.Trim()))
                            {
                                //lblResult.Text = "Last Frame : " + txtFarmeNo.Text.ToUpper().Trim();
                                //txtFarmeNo.Text = "";
                                //txtFarmeNo.RequestFocus();
                                //dispatchcunt++;
                                //lblCount.Text = dispatchcunt.ToString();
                                //txtDelivery.Enabled = false;
                                //txtTruckNo.Enabled = true;
                                BindRecycleView();
                                txtTruckNo.RequestFocus();
                            }
                            else
                            {
                                lblResult.Text = ModInit.Gstrarr[0];
                                txtDelivery.Text = "";
                                // txtDelivery.RequestFocus();
                            }

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


        public override void OnBackPressed() { }

        private bool ValidateControls()
        {
            try
            {
                bool IsValidate = true;


                if (string.IsNullOrEmpty(txtDelivery.Text.Trim()))
                {
                    Toast.MakeText(this, "Input Delivery No.", ToastLength.Long).Show();
                    txtDelivery.RequestFocus();
                    IsValidate = false;
                }
                else if (string.IsNullOrEmpty(txtTruckNo.Text.Trim()))
                {
                    Toast.MakeText(this, "Input Truck No.", ToastLength.Long).Show();
                    txtTruckNo.RequestFocus();
                    IsValidate = false;
                }
                else if (chkFram.Checked==true)
                {
                    if (string.IsNullOrEmpty(txtFrame.Text.Trim()))
                    {
                        Toast.MakeText(this, "Input Frame No.", ToastLength.Long).Show();
                        txtFrame.SelectAll();
                        txtFrame.RequestFocus();
                        IsValidate = false;
                    }
                }
                else if (string.IsNullOrEmpty(txtBattery.Text.Trim()))
                {
                    Toast.MakeText(this, "Scan Battery Barcode.", ToastLength.Long).Show();
                    txtBattery.SelectAll();
                    txtBattery.RequestFocus();
                    IsValidate = false;
                }
                 if (_ListItem.Count > 0)
                {
                    bool chk = false;
                    for (int i = 0; i < _ListItem.Count; i++)
                    {
                        if (_ListItem[i].chkCheck == true)
                        {
                            chk = true;
                            break;
                        }
                    }
                    if (!chk)
                    {
                        Toast.MakeText(this, "Check Atleast one SKU.", ToastLength.Long).Show();
                        txtBattery.SelectAll();
                        txtBattery.RequestFocus();
                        IsValidate = false;
                    }
                    else
                    {
                        for (int i = 0; i < _ListItem.Count; i++)
                        {
                            if (_ListItem[i].chkCheck == true)
                            {
                                if (_ListItem[i].Qty.ToString() == _ListItem[i].ScanQty)
                                {
                                    Toast.MakeText(this, "This SKU scanning completed choose another one!!!", ToastLength.Long).Show();
                                    txtBattery.SelectAll();
                                    txtBattery.RequestFocus();
                                    IsValidate = false;
                                    break;
                                }
                            }

                        }
                    }
                }

                return IsValidate;
            }
            catch (Exception ex) { throw ex; }
        }

        private void clear()
        {
            chkFram.Checked = false;
            txtFrame.Enabled = false;
            txtFrame.Text = "";
            txtTruckNo.Text = "";
            txtDelivery.Text = "";
            txtBattery.Text = "";
            lblResult.Text = "";
            // txtBattery.Enabled = txtTruckNo.Enabled = false;
            _ListItem.Clear();
            selectedSKU = "";
            receivingItemAdapter.NotifyDataSetChanged();
            txtDelivery.RequestFocus();
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