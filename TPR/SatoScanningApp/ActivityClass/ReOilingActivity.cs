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
    public class ReOilingActivity : AppCompatActivity
    {
        clsGlobal clsGLB;
        clsNetwork oNetwork;
        MediaPlayer mediaPlayerSound;
        Vibrator vibrator;

        EditText editTrolleyCard, editTotalQty, editOkQty, editNgQty, editLotNo;
        ImageButton imgbtnGo;
        Button btnSave, btnReset;

        string _ScannedTrolleyCard = "", _ModelNo = "";
        List<ReOiling> _ListMachiningLotNo = new List<ReOiling>();
        List<ReOiling> _ListReOilingData = new List<ReOiling>();
        int _CurrentLotNoIndex = 0;

        public ReOilingActivity()
        {
            try
            {
                clsGLB = new clsGlobal();
                oNetwork = new clsNetwork();
                clsGlobal.ReOiling = new ReOiling();
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
                SetContentView(Resource.Layout.activity_reoiling);

                editTrolleyCard = FindViewById<EditText>(Resource.Id.editTrolleyCard);
                editTrolleyCard.KeyPress += EditTrolleyCard_KeyPress;

                editTotalQty = FindViewById<EditText>(Resource.Id.editTotalQty);
                editLotNo = FindViewById<EditText>(Resource.Id.editLotNo);

                editOkQty = FindViewById<EditText>(Resource.Id.editOkQty);
                editOkQty.TextChanged += EditOkQty_TextChanged;

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

                editTrolleyCard.RequestFocus();
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
        private void BtnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (ValidateField())
                {
                    clsGlobal.ReOiling.NgQty = Convert.ToInt32(editNgQty.Text);
                    if (clsGlobal.ReOiling.DefectQty == clsGlobal.ReOiling.NgQty)
                    {
                        _ListReOilingData.Add(new ReOiling
                        {
                            MachiningTrolleyCard = _ScannedTrolleyCard,
                            TotalQty = int.Parse(editTotalQty.Text.Trim()),
                            OkQty = int.Parse(editOkQty.Text.Trim()),
                            NgQty = int.Parse(editNgQty.Text.Trim()),
                            CreatedBy = clsGlobal.UserId,
                            ModelNo = _ModelNo,
                            LotNo = editLotNo.Text.Trim(),
                            LotNoDate = _ListMachiningLotNo[_CurrentLotNoIndex].LotNoDate,

                            InnerCavity = clsGlobal.ReOiling.InnerCavity,
                            OuterCavity = clsGlobal.ReOiling.OuterCavity,
                            Slag = clsGlobal.ReOiling.Slag,
                            Dent = clsGlobal.ReOiling.Dent,
                            Spine = clsGlobal.ReOiling.Spine,
                            RONg = clsGlobal.ReOiling.RONg,
                            Other = clsGlobal.ReOiling.Other,
                            ExtraParam1 = clsGlobal.ReOiling.ExtraParam1,
                            ExtraParam2 = clsGlobal.ReOiling.ExtraParam2,
                            ExtraParam3 = clsGlobal.ReOiling.ExtraParam3,
                            ExtraParam4 = clsGlobal.ReOiling.ExtraParam4,
                            ExtraParam5 = clsGlobal.ReOiling.ExtraParam5
                        });

                        //If all lot no has been added then save
                        if (_ListMachiningLotNo.Count == (_CurrentLotNoIndex + 1))
                            SaveReOilingDataAsync();
                        else
                        {
                            _CurrentLotNoIndex++;

                            editTotalQty.Text = _ListMachiningLotNo[_CurrentLotNoIndex].TotalQty.ToString();
                            editLotNo.Text = _ListMachiningLotNo[_CurrentLotNoIndex].LotNo;
                            editOkQty.Text = "";
                            editNgQty.Text = "";
                            editOkQty.RequestFocus();

                            clsGLB.ShowMessage("Lot No details added,now input next lot no details", this, MessageTitle.INFORMATION);
                        }
                       
                    }
                    else
                    {
                        StartPlayingSound();
                        ShowMessageBox("Qty mismatch, Defect Qty is " + clsGlobal.ReOiling.DefectQty + " And Ng Qty is " + clsGlobal.ReOiling.NgQty, this);
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
                    clsGlobal.ReOiling.NgQty = Convert.ToInt32(editNgQty.Text);
                    if (clsGlobal.ReOiling.NgQty > 0)
                        OpenActivity(typeof(ReOilingDefectActivity));
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
                _ListReOilingData.Clear();
                _ListMachiningLotNo.Clear();
                _CurrentLotNoIndex = 0;
                ClearDefectValue();
                editTrolleyCard.RequestFocus();
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
                if (string.IsNullOrEmpty(editLotNo.Text))
                {
                    StartPlayingSound();
                    ShowMessageBox("LotNo not found", this);
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
                if (string.IsNullOrEmpty(editNgQty.Text))
                {
                    StartPlayingSound();
                    ShowMessageBox("Please input ng qty", this);
                    editTrolleyCard.RequestFocus();
                    editNgQty.Text = "";
                    editNgQty.RequestFocus();
                    return false;
                }

                if ((Convert.ToInt32(editNgQty.Text) + Convert.ToInt32(editOkQty.Text)) != Convert.ToInt32(editTotalQty.Text))
                {
                    StartPlayingSound();
                    ShowMessageBox("OK+NG qty should be equal to total qty", this);
                    return false;
                }
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private async void GetReOilingDataAync(string TrolleyCard)
        {
            var progressDialog = ProgressDialog.Show(this, "", "Please wait...", true);
            try
            {
                Clear();

                string[] _RESPONSE = await Task.Run(() => GetReOilingDataFromServer(TrolleyCard));
                progressDialog.Hide();

                switch (_RESPONSE[0])
                {
                    case "VALID":
                        string[] sArrRow = _RESPONSE[1].Split('#');
                        for (int i = 0; i < sArrRow.Length; i++)
                        {
                            string[] sArrCol = sArrRow[i].Split('$');
                            _ListMachiningLotNo.Add(new ReOiling
                            {
                                ModelNo = sArrCol[0],
                                LotNo = sArrCol[1],
                                LotNoDate = sArrCol[2],
                                TotalQty = int.Parse(sArrCol[3])
                            });
                        }
                        _CurrentLotNoIndex = 0;
                        editTotalQty.Text = _ListMachiningLotNo[_CurrentLotNoIndex].TotalQty.ToString();
                        _ModelNo = _ListMachiningLotNo[_CurrentLotNoIndex].ModelNo;
                        editLotNo.Text = _ListMachiningLotNo[_CurrentLotNoIndex].LotNo;
                        _ScannedTrolleyCard = TrolleyCard;
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

        private string[] GetReOilingDataFromServer(string TrolleyCard)
        {
            try
            {
                string _MESSAGE = "GET_REOILING_DATA~" + TrolleyCard + "}";
                string[] _RESPONSE = oNetwork.fnSendReceiveData(_MESSAGE).Split('~');

                return _RESPONSE;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private async void SaveReOilingDataAsync()
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
                progressDialog.Hide();
                clsGLB.ShowMessage(ex.Message, this, MessageTitle.ERROR);
            }
        }

        private string[] SendDataToServer()
        {
            try
            {
                //Make data string
                string StrData = "";
                foreach (var Item in _ListReOilingData)
                {
                    StrData += Item.MachiningTrolleyCard + "$" + Item.TotalQty + "$" + Item.OkQty + "$"
                        + Item.NgQty + "$" + Item.CreatedBy + "$" + Item.ModelNo + "$" + Item.InnerCavity
                        + "$" + Item.OuterCavity + "$" + Item.Slag + "$" + Item.Dent + "$" + Item.Spine + "$"
                        + Item.RONg + "$" + Item.Other + "$" + Item.ExtraParam1 + "$" + Item.ExtraParam2
                        + "$" + Item.ExtraParam3 + "$" + Item.ExtraParam4 + "$" + Item.ExtraParam5 + "$" + Item.LotNo + "$" + Item.LotNoDate;

                    StrData += "#";
                }

                StrData = StrData.TrimEnd('#');

                string _MESSAGE = "SAVE_REOILING_DATA~" + StrData + "}";
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

        private void ClearDefectValue()
        {
            try
            {
                clsGlobal.ReOiling.InnerCavity = 0;
                clsGlobal.ReOiling.OuterCavity = 0;
                clsGlobal.ReOiling.Slag = 0;
                clsGlobal.ReOiling.Dent = 0;
                clsGlobal.ReOiling.Spine = 0;
                clsGlobal.ReOiling.RONg = 0;
                clsGlobal.ReOiling.Other = 0;
                clsGlobal.ReOiling.ExtraParam1 = 0;
                clsGlobal.ReOiling.ExtraParam2 = 0;
                clsGlobal.ReOiling.ExtraParam3 = 0;
                clsGlobal.ReOiling.ExtraParam4 = 0;
                clsGlobal.ReOiling.ExtraParam5 = 0;
                clsGlobal.ReOiling.DefectQty = 0;
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
                        GetReOilingDataAync(editTrolleyCard.Text.Trim());
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
                SetNgQty();
            }
            catch (Exception ex)
            {
                clsGLB.ShowMessage(ex.Message, this, MessageTitle.ERROR);
            }
        }

        #endregion
    }
}