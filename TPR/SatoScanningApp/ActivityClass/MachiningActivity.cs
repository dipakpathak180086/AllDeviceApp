﻿using Android.App;
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
    public class MachiningActivity : AppCompatActivity
    {
        clsGlobal clsGLB;
        clsNetwork oNetwork;
        MediaPlayer mediaPlayerSound;
        Vibrator vibrator;

        Spinner spinnerLine;
        List<string> _ListLine = new List<string>();
        List<Machining> _ListMachining = new List<Machining>();
        List<Machining> _ListAfterPickingLotNo = new List<Machining>();
        int _CurrentLotNoIndex = 0;

        EditText editTrolleyCard, editTotalQty, editOkQty, editNgQty, editLotNo, editReprintTrolleyCard, editOperator, editInspector;
        ImageButton imgbtnGo;
        Button btnSave, btnReset, btnReprint;
        CheckBox chkMixedTrolley;
        RadioButton radio_picking, radio_machining;
        LinearLayout layout_mixtrolley, layout_line, layout_LotNo, layout_okqty, layout_ngqty, linearLayout_User;
        CheckBox chkPartial;
        string _ScannedTrolleyCard = "", _ModelNo = "";

        public MachiningActivity()
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
                SetContentView(Resource.Layout.activity_machining);

                layout_mixtrolley = FindViewById<LinearLayout>(Resource.Id.layout_mixtrolley);
                layout_line = FindViewById<LinearLayout>(Resource.Id.layout_line);
                layout_LotNo = FindViewById<LinearLayout>(Resource.Id.layout_LotNo);
                layout_okqty = FindViewById<LinearLayout>(Resource.Id.layout_okqty);
                layout_ngqty = FindViewById<LinearLayout>(Resource.Id.layout_ngqty);
                linearLayout_User = FindViewById<LinearLayout>(Resource.Id.linearLayout_User);

                ShowLayOut(false);

                radio_picking = FindViewById<RadioButton>(Resource.Id.radio_picking);
                radio_picking.CheckedChange += Radio_picking_CheckedChange;
                radio_machining = FindViewById<RadioButton>(Resource.Id.radio_machining);
                radio_machining.CheckedChange += Radio_picking_CheckedChange;

                chkMixedTrolley = FindViewById<CheckBox>(Resource.Id.chkMixedTrolley);
                spinnerLine = FindViewById<Spinner>(Resource.Id.spinnerLine);

                editTrolleyCard = FindViewById<EditText>(Resource.Id.editTrolleyCard);
                editTrolleyCard.KeyPress += EditTrolleyCard_KeyPress;

                editTotalQty = FindViewById<EditText>(Resource.Id.editTotalQty);
                editLotNo = FindViewById<EditText>(Resource.Id.editLotNo);

                editOkQty = FindViewById<EditText>(Resource.Id.editOkQty);
                editOkQty.TextChanged += EditOkQty_TextChanged;

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

                chkPartial = FindViewById<CheckBox>(Resource.Id.chkPartial);

                vibrator = this.GetSystemService(VibratorService) as Vibrator;


                GetLine();
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

        #region RadioButton Event

        private void Radio_picking_CheckedChange(object sender, CompoundButton.CheckedChangeEventArgs e)
        {
            try
            {
                BtnReset_Click(sender, e);
                editTrolleyCard.Text = "";
                if (radio_picking.Checked == true)
                    ShowLayOut(false);
                else if (radio_machining.Checked)
                    ShowLayOut(true);
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
                //If saving after for machining process
                if (radio_machining.Checked)
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
                            if (chkMixedTrolley.Checked == false) //If not mixed trolley then save
                            {
                                if (!chkPartial.Checked)
                                {
                                    int iNGQty = editNgQty.Text.Trim() == "" ? 0 : Convert.ToInt32(editNgQty.Text.Trim());
                                    int iRemaineQty = Convert.ToInt32(editTotalQty.Text.Trim()) - (Convert.ToInt32(editOkQty.Text.Trim()) + iNGQty);
                                    if (iRemaineQty > 0)
                                    {
                                        ShowMessageBox("This Trolley Card Lot Peding Qty is " + iRemaineQty+" and not allowed to save", this);
                                        return;
                                    }
                                }
                                if (!_ListMachining.Exists(x => x.CuttingTrolleyCard == _ScannedTrolleyCard && x.LotNo == editLotNo.Text.Trim()))
                                {
                                    _ListMachining.Add(new Machining
                                    {
                                        LineNo = spinnerLine.SelectedItem.ToString().Split('-')[0].Trim(),
                                        CuttingTrolleyCard = _ScannedTrolleyCard,
                                        TotalQty = int.Parse(editTotalQty.Text.Trim()),
                                        OkQty = int.Parse(editOkQty.Text.Trim()),
                                        NgQty = int.Parse(editNgQty.Text.Trim()),
                                        CreatedBy = clsGlobal.UserId,
                                        ModelNo = _ModelNo,
                                        LotNo = editLotNo.Text.Trim(),
                                        LotNoDate = _ListAfterPickingLotNo[_CurrentLotNoIndex].LotNoDate,

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
                                        TotalLengthPlus=clsGlobal.Machining.TotalLengthPlus,
                                        RCenterMinus=clsGlobal.Machining.RCenterMinus,
                                        RCenterPlus=clsGlobal.Machining.RCenterPlus,
                                        NoCleanUp=clsGlobal.Machining.NoCleanUp,
                                        Crack=clsGlobal.Machining.Crack
                                    });
                                }

                                //If all lot no has been added then save
                                if (_ListAfterPickingLotNo.Count == (_CurrentLotNoIndex + 1))
                                    SaveMachiningDataAsync();
                                else
                                {
                                    _CurrentLotNoIndex++;

                                    editTotalQty.Text = _ListAfterPickingLotNo[_CurrentLotNoIndex].TotalQty.ToString();
                                    editLotNo.Text = _ListAfterPickingLotNo[_CurrentLotNoIndex].LotNo;
                                    editOkQty.Text = "";
                                    editNgQty.Text = "";
                                    editOkQty.RequestFocus();

                                    clsGLB.ShowMessage("Lot No details added,now input next lot no details", this, MessageTitle.INFORMATION);
                                }
                            }
                            else
                                AddMachiningDataMixed();
                        }
                        else
                        {
                            StartPlayingSound();
                            ShowMessageBox("Qty mismatch, Defect Qty is " + clsGlobal.Machining.DefectQty + " And Ng Qty is " + clsGlobal.Machining.NgQty, this);
                        }
                    }
                }
                else // saving for picking
                {
                    if (ValidateField())
                    {
                        SavePickingDataAsync(editTrolleyCard.Text.Trim());
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
                chkMixedTrolley.Checked = false;
                editTrolleyCard.Text = "";
                spinnerLine.SetSelection(0);
                _ListMachining.Clear();
                _ListAfterPickingLotNo.Clear();
                _CurrentLotNoIndex = 0;
                ClearDefectValue();
                chkPartial.Enabled = true;
                chkPartial.Checked = false;
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

        private void ShowLayOut(bool Show)
        {
            layout_mixtrolley.Visibility = Show == true ? ViewStates.Visible : ViewStates.Gone;
            layout_line.Visibility = Show == true ? ViewStates.Visible : ViewStates.Gone;
            layout_LotNo.Visibility = Show == true ? ViewStates.Visible : ViewStates.Gone;
            layout_okqty.Visibility = Show == true ? ViewStates.Visible : ViewStates.Gone;
            layout_ngqty.Visibility = Show == true ? ViewStates.Visible : ViewStates.Gone;
            linearLayout_User.Visibility = Show == true ? ViewStates.Visible : ViewStates.Gone;
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
                if (string.IsNullOrEmpty(editTotalQty.Text) || Convert.ToInt32(editTotalQty.Text) == 0)
                {
                    StartPlayingSound();
                    ShowMessageBox("Total Qty not found", this);
                    editTrolleyCard.RequestFocus();
                    return false;
                }
                //these conditioned will be checked only in the case of machining
                if (radio_machining.Checked)
                {
                    if (string.IsNullOrEmpty(editLotNo.Text))
                    {
                        StartPlayingSound();
                        ShowMessageBox("LotNo not found", this);
                        return false;
                    }
                    if (string.IsNullOrEmpty(editOkQty.Text))
                    {
                        StartPlayingSound();
                        ShowMessageBox("Please input ok qty", this);
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
                        ShowMessageBox("OK+NG qty should be equal to total qty", this);
                        return false;
                    }
                    //if ((Convert.ToInt32(editNgQty.Text) + Convert.ToInt32(editOkQty.Text)) != Convert.ToInt32(editTotalQty.Text))
                    //{
                    //    StartPlayingSound();
                    //    ShowMessageBox("OK+NG qty should be equal to total qty", this);
                    //    return false;
                    //}
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

        private async void GetPickingDataAsync(string TrolleyCard)
        {
            var progressDialog = ProgressDialog.Show(this, "", "Please wait...", true);
            try
            {
                Clear();

                string[] _RESPONSE = await Task.Run(() => GetPickingDataFromServer(TrolleyCard));

                progressDialog.Hide();

                switch (_RESPONSE[0])
                {
                    case "VALID":
                        editTotalQty.Text = _RESPONSE[1];
                        _ModelNo = _RESPONSE[2];
                        _ScannedTrolleyCard = TrolleyCard;
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

        private string[] GetPickingDataFromServer(string TrolleyCard)
        {
            try
            {
                string _MESSAGE = "GET_PICKING_FOR_MACHINING_DATA~" + TrolleyCard + "}";
                string[] _RESPONSE = oNetwork.fnSendReceiveData(_MESSAGE).Split('~');

                return _RESPONSE;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        private async void SavePickingDataAsync(string TrolleyCard)
        {
            var progressDialog = ProgressDialog.Show(this, "", "Please wait...", true);
            try
            {
                Clear();

                string[] _RESPONSE = await Task.Run(() => SendPickingDataToServer(TrolleyCard));

                progressDialog.Hide();

                switch (_RESPONSE[0])
                {
                    case "VALID":
                        clsGLB.ShowMessage(_RESPONSE[1], this, MessageTitle.CONFIRM);
                        Clear();
                        editTrolleyCard.Text = "";
                        editTrolleyCard.RequestFocus();
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

        private string[] SendPickingDataToServer(string TrolleyCard)
        {
            try
            {
                string _MESSAGE = "SAVE_PICKING_FOR_MACHINING_DATA~" + TrolleyCard + "~" + clsGlobal.UserId + "}";
                string[] _RESPONSE = oNetwork.fnSendReceiveData(_MESSAGE).Split('~');

                return _RESPONSE;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        private string[] SendReprintTrolleyCardDataToServer(string TrolleyCard)
        {
            try
            {
                string _MESSAGE = "REPRINT_MACHINING~" + TrolleyCard + "~" + clsGlobal.mMachingPrinterIp +"~" + clsGlobal.UserId + "}";
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

                string[] _RESPONSE = await Task.Run(() => GetMachineDataFromServer(TrolleyCard));

                progressDialog.Hide();

                switch (_RESPONSE[0])
                {
                    case "VALID":
                        string[] sArrRow = _RESPONSE[1].Split('#');
                        for (int i = 0; i < sArrRow.Length; i++)
                        {
                            string[] sArrCol = sArrRow[i].Split('$');
                            _ListAfterPickingLotNo.Add(new Machining
                            {
                                ModelNo = sArrCol[0],
                                LotNo = sArrCol[1],
                                LotNoDate = sArrCol[2],
                                TotalQty = int.Parse(sArrCol[3])
                            });
                        }
                        _CurrentLotNoIndex = 0;
                        editTotalQty.Text = _ListAfterPickingLotNo[_CurrentLotNoIndex].TotalQty.ToString();
                        _ModelNo = _ListAfterPickingLotNo[_CurrentLotNoIndex].ModelNo;
                        editLotNo.Text = _ListAfterPickingLotNo[_CurrentLotNoIndex].LotNo;
                        _ScannedTrolleyCard = TrolleyCard;
                        chkPartial.Enabled = false;
                        editOkQty.RequestFocus();
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
                string _MESSAGE = "GET_MACHINING_DATA~" + TrolleyCard + "}";
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

                string _MESSAGE = "SAVE_MACHINING_DATA~" + StrData + "~" + Operator + "~" + Inspector + "~" + clsGlobal.mMachingPrinterIp + "}";
                string[] _RESPONSE = oNetwork.fnSendReceiveData(_MESSAGE).Split('~');

                return _RESPONSE;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void AddMachiningDataMixed()
        {
            try
            {
                if (!_ListMachining.Exists(x => x.CuttingTrolleyCard == _ScannedTrolleyCard && x.LotNo == editLotNo.Text.Trim()))
                {
                    _ListMachining.Add(new Machining
                    {
                        LineNo = spinnerLine.SelectedItem.ToString().Split('-')[0].Trim(),
                        CuttingTrolleyCard = _ScannedTrolleyCard,
                        TotalQty = int.Parse(editTotalQty.Text.Trim()),
                        OkQty = int.Parse(editOkQty.Text.Trim()),
                        NgQty = int.Parse(editNgQty.Text.Trim()),
                        CreatedBy = clsGlobal.UserId,
                        ModelNo = _ModelNo,
                        LotNo = editLotNo.Text.Trim(),
                        LotNoDate = _ListAfterPickingLotNo[_CurrentLotNoIndex].LotNoDate,

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
                        ExtraParam5 = clsGlobal.Machining.ExtraParam5
                    });
                }
                else
                {
                    clsGLB.ShowMessage("Trolley card with same lot no already added to list", this, MessageTitle.INFORMATION);
                    return;
                }
                //If all lot no has been added then save
                if (_ListAfterPickingLotNo.Count == (_CurrentLotNoIndex + 1))
                {
                    //Show confirmation if user click on yes then save data and print the trolley card other wise, user will continue with
                    ShowConfirmBox("Do you want to print trolley card ?", this);
                }
                else
                {
                    _CurrentLotNoIndex++;

                    editTotalQty.Text = _ListAfterPickingLotNo[_CurrentLotNoIndex].TotalQty.ToString();
                    editLotNo.Text = _ListAfterPickingLotNo[_CurrentLotNoIndex].LotNo;
                    editOkQty.Text = "";
                    editNgQty.Text = "";
                    editOkQty.RequestFocus();

                    clsGLB.ShowMessage("Lot No details added,now input next lot no details", this, MessageTitle.INFORMATION);
                }
            }
            catch (Exception ex)
            {
                clsGLB.ShowMessage(ex.Message, this, MessageTitle.ERROR);
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
                editLotNo.Text = "";
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
                clsGlobal.Machining.TotalLengthPlus = 0;
                clsGlobal.Machining.TotalLengthMinus = 0;
                clsGlobal.Machining.RCenterPlus = 0;
                clsGlobal.Machining.RCenterMinus = 0;
                clsGlobal.Machining.NoCleanUp = 0;
                clsGlobal.Machining.Crack = 0;
            }
            catch (Exception ex)
            {
                clsGLB.ShowMessage(ex.Message, this, MessageTitle.ERROR);
            }
        }

        private void SetNgQty()
        {
            try
            {
                int TotalQty = 0;
                if (editOkQty.Text.Trim() == "")
                {
                    TotalQty = string.IsNullOrEmpty(editTotalQty.Text) ? 0 : Convert.ToInt32(editTotalQty.Text);
                    editNgQty.Text = (TotalQty - 0).ToString();
                }
                if (editOkQty.Text.Length > 0)
                {
                    TotalQty = string.IsNullOrEmpty(editTotalQty.Text) ? 0 : Convert.ToInt32(editTotalQty.Text);
                    if (Convert.ToInt32(editOkQty.Text) <= TotalQty)
                    {
                        editNgQty.Text = (Convert.ToInt32(editTotalQty.Text) - Convert.ToInt32(editOkQty.Text)).ToString();
                    }
                    else
                        Toast.MakeText(this, "OK Qty can not be greater than total qty", ToastLength.Long).Show();
                }
            }
            catch (Exception ex) { throw ex; }
        }

        public void ShowConfirmBox(string msg, Activity activity)
        {
            Android.App.AlertDialog.Builder builder = new Android.App.AlertDialog.Builder(activity);
            builder.SetTitle("Message");
            builder.SetMessage(msg);
            builder.SetCancelable(false);
            builder.SetPositiveButton("Yes", handlerYesButton_SaveMixDataAsync);
            builder.SetNegativeButton("No", handllerCancelButton);
            builder.Show();
        }
        async void handlerYesButton_SaveMixDataAsync(object sender, DialogClickEventArgs e)
        {
            var progressDialog = ProgressDialog.Show(this, "", "Please wait...", true);
            try
            {
                if (_ListMachining.Count == 0)
                {
                    StartPlayingSound();
                    ShowMessageBox("Data not added in the list,please check", this);
                    return;
                }
                string[] _RESPONSE = await Task.Run(() => SendMixDataToServer(editOperator.Text.Trim(), editInspector.Text.Trim()));

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
                progressDialog.Hide();
                clsGLB.ShowMessage(ex.Message, this, MessageTitle.ERROR);
            }
        }
        private string[] SendMixDataToServer(string Operator,string Inspector)
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

                string _MESSAGE = "SAVE_MACHINING_DATA_MIXED~" + StrData + "~" + Operator + "~" + Inspector + "~" + clsGlobal.mMachingPrinterIp + "}";
                string[] _RESPONSE = oNetwork.fnSendReceiveData(_MESSAGE).Split('~');

                return _RESPONSE;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        void handllerCancelButton(object sender, DialogClickEventArgs e)
        {
            try
            {
                editTotalQty.Text = "";
                editOkQty.Text = "";
                editNgQty.Text = "";
                editOperator.Text = "";
                editInspector.Text = "";
                _ScannedTrolleyCard = "";
                _ModelNo = "";
                editTrolleyCard.Text = "";
                _ListAfterPickingLotNo.Clear();
                _CurrentLotNoIndex = 0;
                editLotNo.Text = "";
                ClearDefectValue();
                editTrolleyCard.RequestFocus();
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
                        //For machining check machining validation
                        if (radio_machining.Checked)
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
                        else //Get Picking Data
                            GetPickingDataAsync(editTrolleyCard.Text.Trim());
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

        private void EditOkQty_TextChanged(object sender, Android.Text.TextChangedEventArgs e)
        {
            try
            {
               //SetNgQty();
            }
            catch (Exception ex)
            {
                clsGLB.ShowMessage(ex.Message, this, MessageTitle.ERROR);
            }
        }

        #endregion
    }
}