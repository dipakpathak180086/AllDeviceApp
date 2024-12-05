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
    [Activity(Label = "ReverseDelivery", WindowSoftInputMode = Android.Views.SoftInput.StateAlwaysHidden, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation, ScreenOrientation = ScreenOrientation.Portrait)]
    public class ReverseDelivery : Activity
    {

        clsGlobal clsGLB;
        EditText txtDelivery;
        Spinner spinnerFlag;
        TextView lblResult;
        //ModNet modnet;
        List<string> _lstFlag = new List<string>();
        RecyclerView.LayoutManager mLayoutManager;
        public ReverseDelivery()
        {
            try
            {
                clsGLB = new clsGlobal();

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
                SetContentView(Resource.Layout.activity_ReverseDelivery);

                //cmbSite = FindViewById<Spinner>(Resource.Id.cmbSite);

                Button btn = FindViewById<Button>(Resource.Id.btnBack);
                btn.Click += Btnback_Click;
                Button btnClear = FindViewById<Button>(Resource.Id.btnClear);
                btnClear.Click += BtnClear_Click;

                spinnerFlag = FindViewById<Spinner>(Resource.Id.spinnerFlag);

                txtDelivery = FindViewById<EditText>(Resource.Id.editDelivery);
                txtDelivery.KeyPress += TxtDelivery_KeyPress;
                txtDelivery.FocusChange += TxtDelivery_FocusChange;

                lblResult = FindViewById<TextView>(Resource.Id.lblDisResult);

                BindSpinnerFlag();
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


        private void BindSpinnerFlag()
        {
            _lstFlag.Clear();
            _lstFlag.Add("--Select--");
            _lstFlag.Add("I");
            _lstFlag.Add("N");
            ArrayAdapter arrayAdapter = new ArrayAdapter(this, Resource.Layout.Spinner, _lstFlag);
            spinnerFlag.Adapter = arrayAdapter;
            spinnerFlag.SetSelection(0);
            spinnerFlag.RequestFocus();
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
                    finalBatterybarcode += scannedBarcode.Substring(11) + "$";
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
                            if (!ValidateControls()) { return; }
                            if ((txtDelivery.Text.Trim().Length != 8))
                            {
                                clsGLB.showToastNGMessage("Invalid Delivery No.", this);
                            }
                            if (ModNet.SaveRverseDelivery(spinnerFlag.SelectedItem.ToString(), txtDelivery.Text.Trim()))
                            {
                                lblResult.Text = "Last Reversed Delivery : " + txtDelivery.Text.ToUpper().Trim();
                                //txtFarmeNo.Text = "";
                                //txtFarmeNo.RequestFocus();
                                //dispatchcunt++;
                                //lblCount.Text = dispatchcunt.ToString();
                                //txtDelivery.Enabled = false;
                                //txtTruckNo.Enabled = true;
                                txtDelivery.Text = "";
                                txtDelivery.RequestFocus();
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

                if (spinnerFlag.SelectedItemPosition <= 0)
                {
                    Toast.MakeText(this, "Select Flag.", ToastLength.Long).Show();
                    spinnerFlag.RequestFocus();
                    IsValidate = false;
                }
                else if (string.IsNullOrEmpty(txtDelivery.Text.Trim()))
                {
                    Toast.MakeText(this, "Input Delivery No.", ToastLength.Long).Show();
                    txtDelivery.RequestFocus();
                    IsValidate = false;
                }


                return IsValidate;
            }
            catch (Exception ex) { throw ex; }
        }

        private void clear()
        {
            spinnerFlag.SetSelection(0);
            txtDelivery.Text = "";
            lblResult.Text = "";
            txtDelivery.Enabled = true;
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