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
using SatoScanningApp.ActivityClass;
using System.Collections.Generic;
using Android.Media;
using IOCLAndroidApp.Models;
using System.Threading.Tasks;

namespace SatoScanningApp
{
    [Activity(Label = "Sato ScanningApp", WindowSoftInputMode = SoftInput.StateHidden, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation, ScreenOrientation = ScreenOrientation.Portrait)]
    public class FinalPackingActivity : AppCompatActivity
    {
        clsGlobal clsGLB;
        clsNetwork oNetwork;
        MediaPlayer mediaPlayerSound;
        Vibrator vibrator;

        List<FinalPacking> _ListFinalPackLotNo = new List<FinalPacking>();
        List<string> _ListTempLotNo = new List<string>();
        List<string> _ListColor = new List<string>();

        EditText editTrolleyCard, editTotalQty, editOkQty, editNgQty, editPackSize, editTrolleyQty, editTrolleyNo, editPendingQty;
        Spinner spinnerLotNo, spinnerColor;
        ImageButton imgbtnGo;
        Button btnSave, btnReset;
        CheckBox chkPartial;
        string _ScannedTrolleyCard = "", _ModelNo = "";

        public FinalPackingActivity()
        {
            try
            {
                clsGLB = new clsGlobal();
                oNetwork = new clsNetwork();
                clsGlobal.FinalPacking = new FinalPacking();
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
                SetContentView(Resource.Layout.activity_finalPacking);

                editTrolleyCard = FindViewById<EditText>(Resource.Id.editTrolleyCard);
                editTrolleyCard.KeyPress += EditTrolleyCard_KeyPress;

                spinnerColor = FindViewById<Spinner>(Resource.Id.spinnerColor);

                spinnerLotNo = FindViewById<Spinner>(Resource.Id.spinnerLotNo);
                spinnerLotNo.ItemSelected += SpinnerLotNo_ItemSelected;

                editTrolleyNo = FindViewById<EditText>(Resource.Id.editTrolleyNo);
                editTrolleyNo.KeyPress += EditTrolleyNo_KeyPress; ;

                editTrolleyQty = FindViewById<EditText>(Resource.Id.editTrolleyQty);
                editPackSize = FindViewById<EditText>(Resource.Id.editPackSize);
                editPendingQty = FindViewById<EditText>(Resource.Id.editPendingQty);
                editTotalQty = FindViewById<EditText>(Resource.Id.editTotalQty);

                editOkQty = FindViewById<EditText>(Resource.Id.editOkQty);
                editNgQty = FindViewById<EditText>(Resource.Id.editNgQty);

                Button btnBack = FindViewById<Button>(Resource.Id.btnBack);
                btnBack.Click += (e, a) =>
                {
                    this.Finish();
                };

                imgbtnGo = FindViewById<ImageButton>(Resource.Id.imgbtnGo);
                imgbtnGo.Click += ImgbtnGo_Click;

                btnReset = FindViewById<Button>(Resource.Id.btnReset);
                btnReset.Click += BtnReset_Click;

                btnSave = FindViewById<Button>(Resource.Id.btnSave);
                btnSave.Click += BtnSave_Click;

         
                

                vibrator = this.GetSystemService(VibratorService) as Vibrator;
                GetColor();
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

        #region Spinner Events
        private void SpinnerLotNo_ItemSelected(object sender, AdapterView.ItemSelectedEventArgs e)
        {
            try
            {
                if (spinnerLotNo.SelectedItem.ToString() != "--Select--")
                {
                    var SelectedLotNo = _ListFinalPackLotNo.Find(x => x.LotNo == spinnerLotNo.SelectedItem.ToString());
                    if (SelectedLotNo != null)
                    {
                        editTotalQty.Text = SelectedLotNo.TotalQty.ToString();
                        editOkQty.RequestFocus();
                    }
                    else
                    {
                        StartPlayingSound();
                        ShowMessageBox("Selected LotNO details not found", this);
                    }
                }
            }
            catch (Exception ex)
            {
                clsGLB.ShowMessage(ex.Message, this, MessageTitle.ERROR);
            }
        }

        #endregion

        #region Button Events
        private void BtnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (ValidateBeforeScan() == false)
                    return;
                if (ValidateField())
                {
                    
                    clsGlobal.FinalPacking.NgQty = Convert.ToInt32(editNgQty.Text);
                    if (clsGlobal.FinalPacking.DefectQty == clsGlobal.FinalPacking.NgQty)
                    {
                        SaveFinalPackingDataAsync();
                    }
                    else
                    {
                        StartPlayingSound();
                        ShowMessageBox("Qty mismatch, Defect Qty is " + clsGlobal.FinalPacking.DefectQty + " And Ng Qty is " + clsGlobal.FinalPacking.NgQty, this);
                    }
                }
            }
            catch (Exception ex)
            {
                clsGLB.ShowMessage(ex.Message, this, MessageTitle.ERROR);
            }
        }

        private void ImgbtnGo_Click(object sender, EventArgs e)
        {
            try
            {
                if (ValidateField())
                {
                    ClearDefectValue();
                    clsGlobal.FinalPacking.NgQty = Convert.ToInt32(editNgQty.Text);
                    if (clsGlobal.FinalPacking.NgQty > 0)
                        OpenActivity(typeof(FinalPackingDefectActivity));
                }
            }
            catch (Exception ex)
            {
                clsGLB.ShowMessage(ex.Message, this, MessageTitle.ERROR);
            }
        }

        private void BtnReset_Click(object sender, EventArgs e)
        {
            try
            {
                Clear();
                editTrolleyNo.Text = "";
                ClearAll();
            }
            catch (Exception ex)
            {
                clsGLB.ShowMessage(ex.Message, this, MessageTitle.ERROR);
            }
        }

        #endregion

        #region Methods

        private bool ValidateBeforeScan()
        {
            try
            {
                if (editTrolleyNo.Text.Trim() == "")
                {
                    StartPlayingSound();
                    ShowMessageBox("Please enter/scan trolley no", this);
                    editTrolleyNo.RequestFocus();
                    return false;
                }
                if (editPackSize.Text.Trim() == "" || Convert.ToInt32(editPackSize.Text) == 0)
                {
                    StartPlayingSound();
                    ShowMessageBox("Trolley pack size not found", this);
                    editPackSize.RequestFocus();
                    return false;
                }
                if (string.IsNullOrEmpty(editTrolleyCard.Text))
                {
                    StartPlayingSound();
                    ShowMessageBox("Scan Trolley Card", this);
                    editTrolleyCard.RequestFocus();
                    return false;
                }

                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        private bool ValidateField()
        {
            try
            {
                if (string.IsNullOrEmpty(editTrolleyCard.Text))
                {
                    StartPlayingSound();
                    ShowMessageBox("Scan Trolley Card", this);
                    editTrolleyCard.RequestFocus();
                    return false;
                }
                if (spinnerColor.SelectedItem.ToString() == "--Select--" || spinnerColor.SelectedItemPosition < 0)
                {
                    StartPlayingSound();
                    ShowMessageBox("Select Color", this);
                    spinnerColor.RequestFocus();
                    return false;
                }
                if (spinnerLotNo.SelectedItem.ToString() == "--Select--" || spinnerLotNo.SelectedItemPosition < 0)
                {
                    StartPlayingSound();
                    ShowMessageBox("Select Lot No", this);
                    spinnerLotNo.RequestFocus();
                    return false;
                }
                if (string.IsNullOrEmpty(editTotalQty.Text) || Convert.ToInt32(editTotalQty.Text) == 0)
                {
                    StartPlayingSound();
                    ShowMessageBox("Total Qty not found", this);
                    editTrolleyCard.RequestFocus();
                    return false;
                }
                if (string.IsNullOrEmpty(editOkQty.Text))
                {
                    StartPlayingSound();
                    ShowMessageBox("Please input ok qty", this);
                    editOkQty.RequestFocus();
                    return false;
                }
                if (Convert.ToInt32(editTotalQty.Text) == 0)
                {
                    StartPlayingSound();
                    ShowMessageBox("Input ok qty can't be zero", this);
                    editOkQty.RequestFocus();
                    return false;
                }
                if (string.IsNullOrEmpty(editNgQty.Text))
                {
                    StartPlayingSound();
                    ShowMessageBox("Please input ng qty", this);
                    editTrolleyCard.RequestFocus();
                    editNgQty.Text = "";
                    editNgQty.RequestFocus();
                    return false;
                }

                if ((Convert.ToInt32(editNgQty.Text) + Convert.ToInt32(editOkQty.Text)) > Convert.ToInt32(editTotalQty.Text))
                {
                    StartPlayingSound();
                    ShowMessageBox("OK+NG qty should not be greater than total qty", this);
                    return false;
                }
                int TrolleyQty = editTrolleyQty.Text.Trim() == "" ? 0 : Convert.ToInt32(editTrolleyQty.Text.Trim());
                if ((Convert.ToInt32(editOkQty.Text) + TrolleyQty) > Convert.ToInt32(editPackSize.Text.Trim()))
                {
                    StartPlayingSound();
                    ShowMessageBox("Trolley can not hold more than " + (Convert.ToInt32(editPackSize.Text.Trim()) - TrolleyQty).ToString(), this);
                    return false;
                }
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        private void GetColor()
        {
            try
            {
                string _MESSAGE = "GET_COLOR~" + "}";
                string[] _RESPONSE = oNetwork.fnSendReceiveData(_MESSAGE).Split('~');
                switch (_RESPONSE[0])
                {
                    case "VALID":
                        _ListColor.Clear();
                        _ListColor.Add("--Select--");
                        string[] sArr = _RESPONSE[1].Split('#');
                        for (int i = 0; i < sArr.Length; i++)
                        {
                            _ListColor.Add(sArr[i]);
                        }
                        ArrayAdapter<string> arrayAdapter = new ArrayAdapter<string>(this, Resource.Layout.Spiner, _ListColor);
                        spinnerColor.Adapter = arrayAdapter;
                        spinnerColor.SetSelection(0);
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
            }
        }

        private async void GetTrolleyNoDataAsync(string TrolleyNo)
        {
            var progressDialog = ProgressDialog.Show(this, "", "Please wait...", true);
            try
            {
                Clear();
                ClearAll();

                string[] _RESPONSE = await Task.Run(() => GetTrolleyNoDataFromServer(TrolleyNo));

                progressDialog.Hide();

                switch (_RESPONSE[0])
                {
                    case "VALID":
                        editTrolleyQty.Text = _RESPONSE[1];
                        editPackSize.Text = _RESPONSE[2];

                        int PendingQty = 0;
                        PendingQty = Convert.ToInt32(_RESPONSE[2]) - Convert.ToInt32(_RESPONSE[1]);
                        editPendingQty.Text = PendingQty.ToString();

                        editTrolleyCard.RequestFocus();
                        break;

                    case "INVALID":
                        StartPlayingSound();
                        ShowMessageBox(_RESPONSE[1], this);
                        editTrolleyNo.Text = "";
                        editTrolleyNo.RequestFocus();
                        break;

                    case "ERROR":
                        StartPlayingSound();
                        ShowMessageBox(_RESPONSE[1], this);
                        editTrolleyNo.Text = "";
                        editTrolleyNo.RequestFocus();
                        break;

                    case "NO_CONNECTION":
                        StartPlayingSound();
                        ShowMessageBox("Communication server not connected", this);
                        editTrolleyNo.Text = "";
                        editTrolleyNo.RequestFocus();
                        break;

                    default:
                        StartPlayingSound();
                        ShowMessageBox("No option match from comm server", this);
                        editTrolleyNo.Text = "";
                        editTrolleyNo.RequestFocus();
                        break;

                }

            }
            catch (Exception ex)
            {
                clsGLB.ShowMessage(ex.Message, this, MessageTitle.ERROR);
            }
            finally
            {
                progressDialog.Hide();
            }
        }

        private string[] GetTrolleyNoDataFromServer(string TrolleyNo)
        {
            try
            {
                string _MESSAGE = "GET_FINALPACKING_TROLLEY~" + TrolleyNo + "}";
                string[] _RESPONSE = oNetwork.fnSendReceiveData(_MESSAGE).Split('~');

                return _RESPONSE;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private async void GetFinalPackingDataAsync(string TrolleyCard)
        {
            var progressDialog = ProgressDialog.Show(this, "", "Please wait...", true);
            try
            {
                Clear();
                _ListFinalPackLotNo.Clear();
                _ListTempLotNo.Clear();
                string[] _RESPONSE = await Task.Run(() => GetFinalPackingDataFromServer(TrolleyCard));

                progressDialog.Hide();

                switch (_RESPONSE[0])
                {
                    case "VALID":
                        string[] sArr = _RESPONSE[1].Split('#');
                        //if more than one lot no then option for selection otherwise default first value selected
                        if (sArr.Length > 1)
                            _ListTempLotNo.Add("--Select--");
                        for (int i = 0; i < sArr.Length; i++)
                        {
                            string[] sArrCol = sArr[i].Split('$');
                            _ListTempLotNo.Add(sArrCol[1]);
                            _ListFinalPackLotNo.Add(new FinalPacking
                            {
                                ModelNo = sArrCol[0],
                                LotNo = sArrCol[1],
                                LotNoDate = sArrCol[2],
                                TotalQty = Convert.ToInt32(sArrCol[3]),
                            });
                        }
                        ArrayAdapter<string> arrayAdapter = new ArrayAdapter<string>(this, Resource.Layout.Spiner, _ListTempLotNo);
                        spinnerLotNo.Adapter = arrayAdapter;
                        spinnerLotNo.SetSelection(0);
                        _ScannedTrolleyCard = TrolleyCard;
                        spinnerLotNo.RequestFocus();
                        break;

                    case "INVALID":
                        StartPlayingSound();
                        ShowMessageBox(_RESPONSE[1], this);
                        editTrolleyCard.Text = "";
                        editTrolleyCard.RequestFocus();
                        break;

                    case "ERROR":
                        StartPlayingSound();
                        ShowMessageBox(_RESPONSE[1], this);
                        editTrolleyCard.Text = "";
                        editTrolleyCard.RequestFocus();
                        break;

                    case "NO_CONNECTION":
                        StartPlayingSound();
                        ShowMessageBox("Communication server not connected", this);
                        editTrolleyCard.Text = "";
                        editTrolleyCard.RequestFocus();
                        break;

                    default:
                        StartPlayingSound();
                        ShowMessageBox("No option match from comm server", this);
                        editTrolleyCard.Text = "";
                        editTrolleyCard.RequestFocus();
                        break;

                }

            }
            catch (Exception ex)
            {
                clsGLB.ShowMessage(ex.Message, this, MessageTitle.ERROR);
            }
            finally
            {
                progressDialog.Hide();
            }
        }

        private string[] GetFinalPackingDataFromServer(string TrolleyCard)
        {
            try
            {
                string _MESSAGE = "GET_FINALPACKING_DATA~" + TrolleyCard + "~" + editTrolleyNo.Text.Trim() + "}";
                string[] _RESPONSE = oNetwork.fnSendReceiveData(_MESSAGE).Split('~');

                return _RESPONSE;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private async void SaveFinalPackingDataAsync()
        {
            var progressDialog = ProgressDialog.Show(this, "", "Please wait...", true);
            try
            {
                string[] _RESPONSE = await Task.Run(() => SendDataToServer());

                progressDialog.Hide();
                switch (_RESPONSE[0])
                {
                    case "VALID":
                        clsGLB.ShowMessage(_RESPONSE[1], this, MessageTitle.CONFIRM);
                        BtnReset_Click(null, null);
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
            }
            finally
            {
                progressDialog.Hide();
            }
        }

        private string[] SendDataToServer()
        {
            try
            {
                //Set Property
                var SelectedLotNo = _ListFinalPackLotNo.Find(x => x.LotNo == spinnerLotNo.SelectedItem.ToString());
                clsGlobal.FinalPacking.TrolleyNo = editTrolleyNo.Text.Trim();
                clsGlobal.FinalPacking.MachiningTrolleyCard = _ScannedTrolleyCard;
                clsGlobal.FinalPacking.LotNo = SelectedLotNo.LotNo;
                clsGlobal.FinalPacking.LotNoDate = SelectedLotNo.LotNoDate;
                clsGlobal.FinalPacking.ModelNo = SelectedLotNo.ModelNo;
                clsGlobal.FinalPacking.TotalQty = int.Parse(editTotalQty.Text.Trim());
                clsGlobal.FinalPacking.OkQty = int.Parse(editOkQty.Text.Trim());
                clsGlobal.FinalPacking.NgQty = int.Parse(editNgQty.Text.Trim());
                clsGlobal.FinalPacking.CreatedBy = clsGlobal.UserId;


                string _MESSAGE = "SAVE_FINALPACKING_DATA~" + clsGlobal.FinalPacking.MachiningTrolleyCard + "~" + clsGlobal.FinalPacking.TotalQty + "~" + clsGlobal.FinalPacking.OkQty + "~" + clsGlobal.FinalPacking.NgQty + "~" + clsGlobal.FinalPacking.TrolleyNo + "~" + clsGlobal.FinalPacking.InnerCavity + "~" + clsGlobal.FinalPacking.OuterCavity + "~" + clsGlobal.FinalPacking.Slag + "~" + clsGlobal.FinalPacking.Dent + "~" + clsGlobal.FinalPacking.Spine + "~" + clsGlobal.FinalPacking.PackNg + "~" + clsGlobal.FinalPacking.Other + "~" + clsGlobal.FinalPacking.Rust + "~" + clsGlobal.FinalPacking.ExtraParam2 + "~" + clsGlobal.FinalPacking.ExtraParam3 + "~" + clsGlobal.FinalPacking.ExtraParam4 + "~" + clsGlobal.FinalPacking.ExtraParam5 + "~" + clsGlobal.FinalPacking.CreatedBy + "~" + clsGlobal.FinalPacking.ModelNo + "~" + clsGlobal.FinalPacking.LotNo + "~" + clsGlobal.FinalPacking.LotNoDate + "~" + editPackSize.Text.Trim() + "~" + spinnerColor.SelectedItem + "}";
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

        private void Clear()
        {
            try
            {
                editTotalQty.Text = "";
                editOkQty.Text = "";
                editNgQty.Text = "";
                _ScannedTrolleyCard = "";
                _ModelNo = "";
            }
            catch (Exception ex)
            {
                clsGLB.ShowMessage(ex.Message, this, MessageTitle.ERROR);
            }
        }

        private void ClearAll()
        {
            try
            {
                editTrolleyQty.Text = "";
                editPackSize.Text = "";
                editPendingQty.Text = "";
                editTrolleyCard.Text = "";
                _ListTempLotNo.Clear();
                _ListFinalPackLotNo.Clear();
                ArrayAdapter<string> arrayAdapter = new ArrayAdapter<string>(this, Resource.Layout.Spiner, _ListTempLotNo);
                spinnerLotNo.Adapter = arrayAdapter;
                ClearDefectValue();
                editTrolleyNo.RequestFocus();
            }
            catch (Exception ex)
            {
                clsGLB.ShowMessage(ex.Message, this, MessageTitle.ERROR);
            }
        }

        private void ClearDefectValue()
        {
            try
            {
                clsGlobal.FinalPacking.InnerCavity = 0;
                clsGlobal.FinalPacking.OuterCavity = 0;
                clsGlobal.FinalPacking.Slag = 0;
                clsGlobal.FinalPacking.Dent = 0;
                clsGlobal.FinalPacking.Spine = 0;
                clsGlobal.FinalPacking.PackNg = 0;
                clsGlobal.FinalPacking.Other = 0;
                clsGlobal.FinalPacking.Rust = 0;
                clsGlobal.FinalPacking.ExtraParam2 = 0;
                clsGlobal.FinalPacking.ExtraParam3 = 0;
                clsGlobal.FinalPacking.ExtraParam4 = 0;
                clsGlobal.FinalPacking.ExtraParam5 = 0;
                clsGlobal.FinalPacking.DefectQty = 0;
            }
            catch (Exception ex)
            {
                clsGLB.ShowMessage(ex.Message, this, MessageTitle.ERROR);
            }
        }


        #endregion

        #region EditText Events
        private void EditTrolleyNo_KeyPress(object sender, View.KeyEventArgs e)
        {
            try
            {
                if (e.Event.Action == KeyEventActions.Down)
                {
                    if (e.KeyCode == Keycode.Enter)
                    {
                        editPackSize.Text = "";
                        editTrolleyQty.Text = "";
                        if (editTrolleyNo.Text.Trim() == "")
                        {
                            StartPlayingSound();
                            ShowMessageBox("Scan/Enter Trolley No", this);
                            editTrolleyNo.RequestFocus();
                            return;
                        }
                        GetTrolleyNoDataAsync(editTrolleyNo.Text.Trim());
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
        private void EditTrolleyCard_KeyPress(object sender, View.KeyEventArgs e)
        {
            try
            {
                if (e.Event.Action == KeyEventActions.Down)
                {
                    if (e.KeyCode == Keycode.Enter)
                    {

                        if (ValidateBeforeScan())
                        {
                            GetFinalPackingDataAsync(editTrolleyCard.Text.Trim());
                        }
                        else
                        {
                            editTrolleyCard.Text = "";
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

        #endregion
    }
}