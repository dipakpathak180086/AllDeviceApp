using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.Media;
using Android.OS;
using Android.Support.V7.App;
using Android.Views;
using Android.Widget;
using IOCLAndroidApp;
using IOCLAndroidApp.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SatoScanningApp
{
    [Activity(Label = "Sato ScanningApp", WindowSoftInputMode = SoftInput.StateHidden, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation, ScreenOrientation = ScreenOrientation.Portrait)]
    public class MachiningSplitActivity : AppCompatActivity
    {
        clsGlobal clsGLB;
        clsNetwork oNetwork;
        MediaPlayer mediaPlayerSound;
        Vibrator vibrator;

        Spinner spinnerLine, spinnerModel, spinnerLotNo;
        List<string> _ListLine = new List<string>();
        List<Machining> _ListMachining = new List<Machining>();
        List<Machining> _ListAfterPickingLotNo = new List<Machining>();
        List<string> _ListTempLotNo = new List<string>();
        int _CurrentLotNoIndex = 0;

        EditText editTrolleyCard, editTotalQty, editOkQty, editNgQty, editReprintTrolleyCard, editOperator, editInspector;
        ImageButton imgbtnGo;
        Button btnSave, btnReset, btnReprint;

        string _ScannedTrolleyCard = "", _ModelNo = "";

        public MachiningSplitActivity()
        {
            try
            {
                clsGLB = new clsGlobal();
                oNetwork = new clsNetwork();
                clsGlobal.Machining = new Machining();
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
                SetContentView(Resource.Layout.activity_machiningSplit);

                spinnerLine = FindViewById<Spinner>(Resource.Id.spinnerLine);
                spinnerModel = FindViewById<Spinner>(Resource.Id.spinnerModel);

                spinnerLotNo = FindViewById<Spinner>(Resource.Id.spinnerLotNo);
                spinnerLotNo.ItemSelected += SpinnerLotNo_ItemSelected;

                editTrolleyCard = FindViewById<EditText>(Resource.Id.editTrolleyCard);
                editTrolleyCard.KeyPress += EditTrolleyCard_KeyPress;

                editTotalQty = FindViewById<EditText>(Resource.Id.editTotalQty);

                editOkQty = FindViewById<EditText>(Resource.Id.editOkQty);

                editNgQty = FindViewById<EditText>(Resource.Id.editNgQty);

                editReprintTrolleyCard = FindViewById<EditText>(Resource.Id.editReprintTrolleyCard);
                editOperator = FindViewById<EditText>(Resource.Id.editOperator);
                editInspector = FindViewById<EditText>(Resource.Id.editInspector);

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

                btnReprint = FindViewById<Button>(Resource.Id.btnReprint);
                btnReprint.Click += BtnReprint_Click;

                vibrator = this.GetSystemService(VibratorService) as Vibrator;

                GetLine();
                GetModel();
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
                    var SelectedLotNo = _ListAfterPickingLotNo.Find(x => x.LotNo == spinnerLotNo.SelectedItem.ToString());
                    if (SelectedLotNo != null)
                    {
                        editTotalQty.Text = SelectedLotNo.TotalQty.ToString();
                        editOkQty.RequestFocus();
                    }
                    else
                    {
                        StartPlayingSound();
                        ShowMessageBox("Selected LotNo details not found", this);
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
                if (spinnerLine.SelectedItemPosition <= 0)
                {
                    StartPlayingSound();
                    ShowMessageBox("Select Line No", this);
                    return;
                }
                if (ValidateField())
                {
                    if (editOperator.Text.Trim() == "")
                    {
                        StartPlayingSound();
                        ShowMessageBox("Input Operator name", this);
                        editOperator.RequestFocus();
                        return;
                    }

                    if (editInspector.Text.Trim() == "")
                    {
                        StartPlayingSound();
                        ShowMessageBox("Input Inspector name", this);
                        editInspector.RequestFocus();
                        return;
                    }

                    clsGlobal.Machining.NgQty = Convert.ToInt32(editNgQty.Text);
                    if (clsGlobal.Machining.DefectQty == clsGlobal.Machining.NgQty)
                    {

                        var SelectedLotNo = _ListAfterPickingLotNo.Find(x => x.LotNo == spinnerLotNo.SelectedItem.ToString());
                        if (!_ListMachining.Exists(x => x.CuttingTrolleyCard == _ScannedTrolleyCard && x.LotNo == SelectedLotNo.LotNo))
                        {
                            _ListMachining.Add(new Machining
                            {
                                LineNo = spinnerLine.SelectedItem.ToString().Split('-')[0].Trim(),
                                CuttingTrolleyCard = _ScannedTrolleyCard,
                                TotalQty = int.Parse(editTotalQty.Text.Trim()),
                                OkQty = int.Parse(editOkQty.Text.Trim()),
                                NgQty = int.Parse(editNgQty.Text.Trim()),
                                CreatedBy = clsGlobal.UserId,
                                ModelNo = spinnerModel.SelectedItem.ToString(),

                                LotNo = SelectedLotNo.LotNo,
                                LotNoDate = SelectedLotNo.LotNoDate,

                                InnerCavity = clsGlobal.Machining.InnerCavity,
                                OuterCavity = clsGlobal.Machining.OuterCavity,
                                Slag = clsGlobal.Machining.Slag,
                                Dent = clsGlobal.Machining.Dent,
                                Spine = clsGlobal.Machining.Spine,
                                ForgMat = clsGlobal.Machining.ForgMat,
                                Rust = clsGlobal.Machining.Rust,
                                PinHole = clsGlobal.Machining.PinHole,
                                MachineOutsideCavity = clsGlobal.Machining.MachineOutsideCavity,
                                Other = clsGlobal.Machining.Other,
                                IDPlus = clsGlobal.Machining.IDPlus,
                                IDMinus = clsGlobal.Machining.IDMinus,
                                PowerCut = clsGlobal.Machining.PowerCut,
                                ExtraParam4 = clsGlobal.Machining.ExtraParam4,
                                ExtraParam5 = clsGlobal.Machining.ExtraParam5,

                                TotalLengthMinus = clsGlobal.Machining.TotalLengthMinus,
                                TotalLengthPlus = clsGlobal.Machining.TotalLengthPlus,
                                RCenterMinus = clsGlobal.Machining.RCenterMinus,
                                RCenterPlus = clsGlobal.Machining.RCenterPlus,
                                NoCleanUp = clsGlobal.Machining.NoCleanUp,
                                Crack = clsGlobal.Machining.Crack
                            });
                        }

                        //If there is only one lot no then save
                        if (_ListAfterPickingLotNo.Count == 1)
                        {
                            if (_ListMachining.Count > 0)
                                SaveMachiningDataAsync();
                            else
                            {
                                StartPlayingSound();
                                ShowMessageBox("No data found in the list to save", this);
                            }
                        }
                        else //Show confirm message whether user want to add other lot not also
                        {
                            ShowConfirmBox("Do you want to print trolley card ?", this);
                        }
                    }
                    else
                    {
                        StartPlayingSound();
                        ShowMessageBox("Qty mismatch, Defect Qty is " + clsGlobal.Machining.DefectQty + " And Ng Qty is " + clsGlobal.Machining.NgQty, this);
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
                    clsGlobal.Machining.NgQty = Convert.ToInt32(editNgQty.Text);
                    if (clsGlobal.Machining.NgQty > 0)
                        OpenActivity(typeof(MachiningDefectActivity));
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
                editTrolleyCard.Text = "";
                spinnerLine.SetSelection(0);
                spinnerModel.SetSelection(0);
                _ListMachining.Clear();
                _ListAfterPickingLotNo.Clear();

                _ListTempLotNo.Clear();
                ArrayAdapter<string> arrayAdapter = new ArrayAdapter<string>(this, Resource.Layout.Spiner, _ListTempLotNo);
                spinnerLotNo.Adapter = arrayAdapter;

                _CurrentLotNoIndex = 0;
                ClearDefectValue();
            }
            catch (Exception ex)
            {
                clsGLB.ShowMessage(ex.Message, this, MessageTitle.ERROR);
            }
        }
        private void BtnReprint_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(editReprintTrolleyCard.Text))
                {
                    StartPlayingSound();
                    ShowMessageBox("Enter Trolley Card No.", this);
                    return;
                }
                ReprintTrolleyCardAsync(editReprintTrolleyCard.Text.Trim());

            }
            catch (Exception ex)
            {
                clsGLB.ShowMessage(ex.Message, this, MessageTitle.ERROR);
            }

        }

        #endregion

        #region Methods

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

                if (spinnerModel.SelectedItemPosition <= 0)
                {
                    StartPlayingSound();
                    ShowMessageBox("Select Model", this);
                    return false;
                }
                if (spinnerModel.SelectedItem.ToString() == _ModelNo)
                {
                    StartPlayingSound();
                    ShowMessageBox("You can not split trolleycard in same model", this);
                    return false;
                }
                if (string.IsNullOrEmpty(editOkQty.Text))
                {
                    StartPlayingSound();
                    ShowMessageBox("Please input ok qty", this);
                    editOkQty.RequestFocus();
                    return false;
                }
                if (string.IsNullOrEmpty(editNgQty.Text) || editNgQty.Text.Trim() == "")
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
                    ShowMessageBox("OK+NG qty can not be greater than total qty", this);
                    return false;
                }

                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void GetLine()
        {
            try
            {
                string _MESSAGE = "GET_LINE~" + "}";
                string[] _RESPONSE = oNetwork.fnSendReceiveData(_MESSAGE).Split('~');
                switch (_RESPONSE[0])
                {
                    case "VALID":
                        _ListLine.Add("--Select--");
                        string[] sArr = _RESPONSE[1].Split('#');
                        for (int i = 0; i < sArr.Length; i++)
                        {
                            _ListLine.Add(sArr[i]);
                        }
                        ArrayAdapter<string> arrayAdapter = new ArrayAdapter<string>(this, Resource.Layout.Spiner, _ListLine);
                        spinnerLine.Adapter = arrayAdapter;
                        spinnerLine.SetSelection(0);
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

        private void GetModel()
        {
            try
            {
                string _MESSAGE = "GET_MODEL_FOR_MACHINING_SPLIT~}";
                string[] _RESPONSE = oNetwork.fnSendReceiveData(_MESSAGE).Split('~');
                switch (_RESPONSE[0])
                {
                    case "VALID":
                        List<string> _ListModel = new List<string>();
                        _ListModel.Add("--Select--");
                        string[] sArr = _RESPONSE[1].Split('#');
                        for (int i = 0; i < sArr.Length; i++)
                        {
                            _ListModel.Add(sArr[i]);
                        }
                        ArrayAdapter<string> arrayAdapter = new ArrayAdapter<string>(this, Resource.Layout.Spiner, _ListModel);
                        spinnerModel.Adapter = arrayAdapter;
                        spinnerModel.SetSelection(0);
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

        private string[] SendReprintTrolleyCardDataToServer(string TrolleyCard)
        {
            try
            {
                string _MESSAGE = "REPRINT_MACHINING~" + TrolleyCard + "~" + clsGlobal.mMachingPrinterIp + "}";
                string[] _RESPONSE = oNetwork.fnSendReceiveData(_MESSAGE).Split('~');

                return _RESPONSE;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private async void GetMachiningDataAsync(string TrolleyCard)
        {
            var progressDialog = ProgressDialog.Show(this, "", "Please wait...", true);
            try
            {
                Clear();
                _ListAfterPickingLotNo.Clear();
                _ListTempLotNo.Clear();

                string[] _RESPONSE = await Task.Run(() => GetMachineDataFromServer(TrolleyCard));

                progressDialog.Hide();

                switch (_RESPONSE[0])
                {
                    case "VALID":
                        string[] sArrRow = _RESPONSE[1].Split('#');
                        //if more than one lot no then option for selection otherwise default first value selected
                        if (sArrRow.Length > 1)
                            _ListTempLotNo.Add("--Select--");
                        for (int i = 0; i < sArrRow.Length; i++)
                        {
                            string[] sArrCol = sArrRow[i].Split('$');
                            _ListTempLotNo.Add(sArrCol[1]);
                            _ListAfterPickingLotNo.Add(new Machining
                            {
                                ModelNo = sArrCol[0],
                                LotNo = sArrCol[1],
                                LotNoDate = sArrCol[2],
                                TotalQty = int.Parse(sArrCol[3])
                            });
                        }

                        ArrayAdapter<string> arrayAdapter = new ArrayAdapter<string>(this, Resource.Layout.Spiner, _ListTempLotNo);
                        spinnerLotNo.Adapter = arrayAdapter;
                        spinnerLotNo.SetSelection(0);
                        _ScannedTrolleyCard = TrolleyCard;
                        spinnerLotNo.RequestFocus();

                        //_CurrentLotNoIndex = 0;
                        //editTotalQty.Text = _ListAfterPickingLotNo[_CurrentLotNoIndex].TotalQty.ToString();
                        //_ModelNo = _ListAfterPickingLotNo[_CurrentLotNoIndex].ModelNo;
                        //editLotNo.Text = _ListAfterPickingLotNo[_CurrentLotNoIndex].LotNo;
                        //_ScannedTrolleyCard = TrolleyCard;
                        //editOkQty.RequestFocus();
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

        private string[] GetMachineDataFromServer(string TrolleyCard)
        {
            try
            {
                string _MESSAGE = "GET_MACHINING_SPLIT_DATA~" + TrolleyCard + "}";
                string[] _RESPONSE = oNetwork.fnSendReceiveData(_MESSAGE).Split('~');

                return _RESPONSE;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private string GetReprintTrolleyCard(string[] sTrolleyCard)
        {
            string str = string.Empty;
            if (sTrolleyCard.Length > 1)
            {
                str = sTrolleyCard[2];
            }

            return str;
        }
        private async void SaveMachiningDataAsync()
        {
            var progressDialog = ProgressDialog.Show(this, "", "Please wait...", true);
            try
            {
                string[] _RESPONSE = await Task.Run(() => SendDataToServer(editOperator.Text.Trim(), editInspector.Text.Trim()));

                progressDialog.Hide();
                switch (_RESPONSE[0])
                {
                    case "VALID":
                        clsGLB.ShowMessage(_RESPONSE[1], this, MessageTitle.CONFIRM);
                        BtnReset_Click(null, null);
                        editReprintTrolleyCard.Text = GetReprintTrolleyCard(_RESPONSE);
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

        private string[] SendDataToServer(string Operator, string Inspector)
        {
            try
            {
                //Make data string
                string StrData = "";
                foreach (var Item in _ListMachining)
                {
                    StrData += Item.LineNo + "$" + Item.CuttingTrolleyCard + "$" + Item.TotalQty + "$" + Item.OkQty + "$"
                        + Item.NgQty + "$" + Item.CreatedBy + "$" + Item.ModelNo + "$" + Item.InnerCavity
                        + "$" + Item.OuterCavity + "$" + Item.Slag + "$" + Item.Dent + "$" + Item.Spine + "$"
                        + Item.ForgMat + "$" + Item.Rust + "$" + Item.PinHole + "$" + Item.MachineOutsideCavity + "$"
                        + Item.Other + "$" + Item.IDPlus + "$" + Item.IDMinus
                        + "$" + Item.PowerCut + "$" + Item.ExtraParam4 + "$" + Item.ExtraParam5
                        + "$" + Item.TotalLengthMinus + "$" + Item.TotalLengthPlus + "$" + Item.RCenterMinus
                        + "$" + Item.RCenterPlus + "$" + Item.NoCleanUp + "$" + Item.Crack
                        + "$" + Item.LotNo + "$" + Item.LotNoDate;

                    StrData += "#";
                }

                StrData = StrData.TrimEnd('#');

                string _MESSAGE = "SAVE_MACHINING_SPLIT_DATA~" + StrData + "~" + Operator + "~" + Inspector + "}";
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
        public void ShowConfirmBox(string msg, Activity activity)
        {
            Android.App.AlertDialog.Builder builder = new Android.App.AlertDialog.Builder(activity);
            builder.SetTitle("Message");
            builder.SetMessage(msg);
            builder.SetCancelable(false);
            builder.SetPositiveButton("Yes", handlerYesButton);
            builder.SetNegativeButton("No", handllerCancelButton);
            builder.Show();
        }
        void handlerYesButton(object sender, DialogClickEventArgs e)
        {
            try
            {
                if (_ListMachining.Count > 0)
                    SaveMachiningDataAsync();
                else
                {
                    StartPlayingSound();
                    ShowMessageBox("No data found in the list to save", this);
                }
            }
            catch (Exception ex)
            {
                clsGLB.ShowMessage(ex.Message, this, MessageTitle.ERROR);
            }
        }
        void handllerCancelButton(object sender, DialogClickEventArgs e)
        {
            try
            {
                editTotalQty.Text = "";
                editOkQty.Text = "";
                editNgQty.Text = "";
                spinnerModel.SetSelection(0);
                _ModelNo = "";
                _CurrentLotNoIndex = 0;
                spinnerLotNo.SetSelection(0);
                ClearDefectValue();
                editTrolleyCard.RequestFocus();
            }
            catch (Exception ex)
            {
                clsGLB.ShowMessage(ex.Message, this, MessageTitle.ERROR);
            }
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
                editReprintTrolleyCard.Text = "";
                editOkQty.Text = "";
                editNgQty.Text = "";
                editOperator.Text = "";
                editInspector.Text = "";
                _ScannedTrolleyCard = "";
                _ModelNo = "";
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
                clsGlobal.Machining.InnerCavity = 0;
                clsGlobal.Machining.OuterCavity = 0;
                clsGlobal.Machining.Slag = 0;
                clsGlobal.Machining.Dent = 0;
                clsGlobal.Machining.Spine = 0;
                clsGlobal.Machining.ForgMat = 0;
                clsGlobal.Machining.Other = 0;
                clsGlobal.Machining.IDPlus = 0;
                clsGlobal.Machining.IDMinus = 0;
                clsGlobal.Machining.PowerCut = 0;
                clsGlobal.Machining.ExtraParam4 = 0;
                clsGlobal.Machining.ExtraParam5 = 0;
                clsGlobal.Machining.DefectQty = 0;
            }
            catch (Exception ex)
            {
                clsGLB.ShowMessage(ex.Message, this, MessageTitle.ERROR);
            }
        }

        private async void ReprintTrolleyCardAsync(string TrolleyCard)
        {
            var progressDialog = ProgressDialog.Show(this, "", "Please wait...", true);
            try
            {
                Clear();

                string[] _RESPONSE = await Task.Run(() => SendReprintTrolleyCardDataToServer(TrolleyCard));

                progressDialog.Hide();

                switch (_RESPONSE[0])
                {
                    case "VALID":
                        clsGLB.ShowMessage(_RESPONSE[1], this, MessageTitle.CONFIRM);
                        Clear();
                        editReprintTrolleyCard.RequestFocus();
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
        #endregion

        #region EditText Events
        private void EditTrolleyCard_KeyPress(object sender, View.KeyEventArgs e)
        {
            try
            {
                if (e.Event.Action == KeyEventActions.Down)
                {
                    if (e.KeyCode == Keycode.Enter)
                    {
                        if (spinnerLine.SelectedItemPosition <= 0)
                        {
                            StartPlayingSound();
                            editTrolleyCard.Text = "";
                            ShowMessageBox("Please select line", this);
                            return;
                        }
                        if (_ListMachining.Exists(x => x.CuttingTrolleyCard == editTrolleyCard.Text.Trim()))
                        {
                            StartPlayingSound();
                            editTrolleyCard.Text = "";
                            ShowMessageBox("Trolley card already scanned", this);
                            editTrolleyCard.RequestFocus();
                        }
                        else
                        {
                            GetMachiningDataAsync(editTrolleyCard.Text.Trim());
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