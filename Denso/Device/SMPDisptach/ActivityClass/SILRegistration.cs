using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.Media;
using Android.OS;
using Android.Runtime;
using Android.Support.V7.Widget;
using Android.Util;
using Android.Views;
using Android.Views.InputMethods;
using Android.Widget;
using Java.Sql;
using Java.Util;
using static Android.Net.Wifi.WifiEnterpriseConfig;
using static Android.Support.V7.Widget.RecyclerView;

namespace SMPDisptach.ActivityClass
{
    /// <summary>
    /// Main
    /// </summary>
    [Activity(Label = "SILRegistration", WindowSoftInputMode = Android.Views.SoftInput.StateAlwaysHidden, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation, ScreenOrientation = ScreenOrientation.Portrait)]
    public class SILRegistration : Activity
    {
        #region Private Variables
        Vibrator vibrator;
        clsGlobal clsGLB;
        EditText txtSILBarcode;
        Dictionary<string, string> dicRegPlant = new Dictionary<string, string>();
        TextView txtTotalQty, txtTruckSILCodeNo, txtCheckPoint;
        TextView lblCount;
        int _TotalQty = 0, _ScanQty = 0, _SrNoCounter = 0;
        int dispatchcunt = 0;
        int _DnhaSupQty = 0;
        string _SILCode = string.Empty;
        StringBuilder _sb = new StringBuilder();
        List<ViewSILScanData> _ListItem = new List<ViewSILScanData>();

        Dictionary<string, string> _dicBarcode1 = new Dictionary<string, string>();
        Dictionary<string, string> _dicBarcode2 = new Dictionary<string, string>();
        bool scanningComplete = false;
        string selectedSKU = string.Empty;
        string strDNHAPartNo = string.Empty;
        RecyclerView recyclerViewItem;
        SILScanItemAdapter receivingItemAdapter;
        RecyclerView.LayoutManager mLayoutManager;
        RecyclerView.LayoutManager mLayoutManager2;
        Dictionary<string, string> _dicBatteryScanningData = new Dictionary<string, string>();
        MediaPlayer mediaPlayerSound;
        #region SILVariable
        #endregion
        #region DNHAVariable
        #endregion

        #region CUSTVariable
        #endregion

        #endregion

        #region Constructor
        public SILRegistration()
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

        #endregion

        #region MainEvent
        protected override void OnCreate(Bundle savedInstanceState)
        {
            try
            {
                base.OnCreate(savedInstanceState);
                SetContentView(Resource.Layout.activity_SILRegistration);

                //cmbSite = FindViewById<Spinner>(Resource.Id.cmbSite);

                vibrator = this.GetSystemService(VibratorService) as Vibrator;

                Button btn = FindViewById<Button>(Resource.Id.btnBack);
                btn.Click += Btnback_Click;
                Button btnClear = FindViewById<Button>(Resource.Id.btnClear);
                btnClear.Click += BtnClear_Click;


                txtSILBarcode = FindViewById<EditText>(Resource.Id.editSILCode);
                txtSILBarcode.KeyPress += txtSILBarcode_KeyPress;
                // txtSILBarcode.Text = "31302300000201400 11HA212400-06701H0000300HA212400-06701H0000100HA212400-06901H0000400HA212400-50201H0000550HA212400-50601H0001400HA212400-50711H0000300HA212400-50711H0000050HA212400-52101H0000200";
                txtSILBarcode.Text = "";


                txtTotalQty = FindViewById<TextView>(Resource.Id.txtTotalQty);
                txtTotalQty.Text = "Total Qty : " + _TotalQty.ToString();

                txtTruckSILCodeNo = FindViewById<TextView>(Resource.Id.lblTruckNo);
                txtTruckSILCodeNo.Text = "";
                txtCheckPoint = FindViewById<TextView>(Resource.Id.lblTransName);
                txtCheckPoint.Text = "";


                dispatchcunt = 0;


                // lblCount = FindViewById<TextView>(Resource.Id.lblCount);

                recyclerViewItem = FindViewById<RecyclerView>(Resource.Id.recycleViewReceiveItem);
                mLayoutManager = new LinearLayoutManager(this);
                recyclerViewItem.SetLayoutManager(mLayoutManager);

                string strTranscationPath = Path.Combine(clsGlobal.FilePath, clsGlobal.TranscationFolder);
                MediaScannerConnection.ScanFile(this, new String[] { strTranscationPath }, null, null);
                clsGlobal.DeleteDirectoryWithOutFile(strTranscationPath);

                //txtBattery.Enabled = txtTruckNo.Enabled = false;

                //clsGlobal.ReadCustomerMaster();
                //clsGlobal.ReadSupplierMaster();
                clsGlobal.ReadDNHAMaster();
                //clsGlobal.ReadAlertMessage();
                //clsGlobal.ReadSuspectedLotMaster();
                //if (clsGlobal.mAlertMeassage != "")
                //{
                //    ShowAlertPopUp();
                //    return;
                //}
                txtSILBarcode.RequestFocus();
            }
            catch (Exception ex)
            {
                clsGLB.ShowMessage(ex.Message, this, MessageTitle.ERROR);
            }
        }

        #endregion

        #region Private methods
        public void ShowConfirmBox(string msg, Activity activity, EventHandler<DialogClickEventArgs> handler)
        {
            scanningComplete = true;
            SoundForFinalSave();
            Android.App.AlertDialog.Builder builder = new Android.App.AlertDialog.Builder(activity);
            builder.SetTitle("Message");
            builder.SetMessage(msg);
            builder.SetCancelable(false);
            builder.SetPositiveButton("Yes", handler);
            builder.SetNegativeButton("No", handllerCancelButton);
            builder.Show();
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
        void handllerCancelButton(object sender, DialogClickEventArgs e)
        {
            try
            {
                StopPlayingSound();
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
                StopPlayingSound();
            }
            catch (Exception ex)
            {
                clsGLB.ShowMessage(ex.Message, this, MessageTitle.ERROR);
            }
        }
        private void StartPlayingSound(bool isSaved = false)
        {
            try
            {



                if (isSaved)
                {
                    mediaPlayerSound = MediaPlayer.Create(this, Resource.Raw.OkSound);
                }
                else
                {
                    StopPlayingSound();
                    mediaPlayerSound = MediaPlayer.Create(this, Resource.Raw.Beep);
                }
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
                    scanningComplete = false;
                }
            }
            catch (Exception ex) { throw ex; }
        }
        private void SoundForOK()
        {
            try
            {
                Task.Run(() =>
                { //Start Vibration
                    long[] pattern = { 0, 2000, 500 }; //0 to start now, 200 to vibrate 200 ms, 0 to sleep for 0 ms.
                    vibrator.Vibrate(pattern, -1);//
                    StopPlayingSound();
                    StartPlayingSound(true);
                    Thread.Sleep(2000);
                    StopPlayingSound();
                    vibrator.Cancel();
                });

            }
            catch (Exception ex) { throw ex; }
        }
        private void SoundForNG()
        {
            try
            {
                Task.Run(() =>
                {
                    StopPlayingSound();
                    StartPlayingSound();
                    Thread.Sleep(3000);
                    StopPlayingSound();
                });

            }
            catch (Exception ex) { throw ex; }
        }
        private void SoundForFinalSave()
        {
            try
            {
                Task.Run(() =>
                {
                    while (scanningComplete)
                    {


                        StartPlayingSound(true);
                        Thread.Sleep(1050);
                    }
                    //Thread.Sleep(3000);
                    //StopPlayingSound();
                });

            }
            catch (Exception ex) { throw ex; }
        }

        private void ShowAlertPopUp()
        {
            try
            {

                AlertActivity customDialog = new AlertActivity(this);
                customDialog.SetCanceledOnTouchOutside(false);
                customDialog.Show();
            }
            catch (Exception ex) { throw ex; }
        }
        private void GetSILScanData()
        {
            try
            {

                if (txtSILBarcode.Text.Length > 0)
                {
                    clsGlobal.mSILType = clsGlobal.mGetCheckPoints(txtSILBarcode.Text.Trim());
                    clsGlobal.mShipmentType = clsGlobal.mCheckSILTILType(txtSILBarcode.Text.Trim());
                    if (clsGlobal.mShipmentType != "SIL")
                    {

                        txtSILBarcode.Text = "";
                        clsGLB.showToastNGMessage("Invalid SIL Barcode.", this);
                        SoundForNG();
                       // ShowAlertPopUp();
                        return;

                    }
                    if (txtSILBarcode.Text.Trim() .StartsWith("DISC"))
                    {

                        txtSILBarcode.Text = "";
                        clsGLB.showToastNGMessage("Invalid SIL Barcode.", this);
                        SoundForNG();
                        //ShowAlertPopUp();
                        return;

                    }

                    var lstSIlData = clsGlobal.GetSILData(txtSILBarcode.Text.Trim());
                    if (lstSIlData.Count > 0)
                    {



                        BindRecycleView(lstSIlData);


                        SoundForOK();
                    }
                    else
                    {
                        txtSILBarcode.Text = "";
                        clsGLB.showToastNGMessage("Invalid SIL Barcode.", this);
                        SoundForNG();
                        //ShowAlertPopUp();

                    }

                }
            }
            catch (Exception ex)
            {
                clsGLB.ShowMessage(ex.Message, this, MessageTitle.ERROR);

            }


        }
        private void GetSetTotalAndScanQty()
        {
            _TotalQty = 0;
            _ScanQty = 0;
            for (int iCount = 0; iCount < _ListItem.Count; iCount++)
            {
                _TotalQty += Convert.ToInt32(Convert.ToInt32(_ListItem[iCount].Qty));
                _ScanQty += Convert.ToInt32(Convert.ToInt32(_ListItem[iCount].ScanQty));
            }
            txtTotalQty.Text = "Total Qty : " + _TotalQty.ToString();
        }
        private void BindRecycleView(List<KanbanData> lst)
        {
            try
            {

                _ListItem.Clear();
                _dicBarcode1.Clear();
                _dicBarcode2.Clear();
                ; _sb.Length = 0;
                string strSILCode = lst.GroupBy(x => x.TruckNo).Select(g => g.First().TruckNo).FirstOrDefault();
                string strTranscationPath = Path.Combine(clsGlobal.FilePath, clsGlobal.TranscationFolder);
                string strFinalSILWiseDirectory = Path.Combine(strTranscationPath, strSILCode);
                string strFinalFilePath = Path.Combine(strFinalSILWiseDirectory, clsGlobal.SILMasterDataFile);
                string strFinalDetailsFilePath = Path.Combine(strFinalSILWiseDirectory, clsGlobal.SILDetailsFile);
                string strSILBarcodeFilePath = Path.Combine(strFinalSILWiseDirectory, clsGlobal.SILBarcode);
                if (File.Exists(strFinalDetailsFilePath))
                {
                    List<SILKanbanBarcodeScannedData> _ListDetails = clsGlobal.ReadSILScannedFileToList(strFinalDetailsFilePath);
                    for (int i = 0; i < _ListDetails.Count; i++)
                    {
                        if (!_dicBarcode1.ContainsKey(_ListDetails[i].Barcode1))
                            _dicBarcode1.Add(_ListDetails[i].Barcode1, _ListDetails[i].Barcode1);

                        if (!_dicBarcode2.ContainsKey(_ListDetails[i].Barcode2))
                            _dicBarcode2.Add(_ListDetails[i].Barcode2, _ListDetails[i].Barcode2);
                    }
                }
                if (!Directory.Exists(strFinalSILWiseDirectory))
                {
                    Directory.CreateDirectory(strFinalSILWiseDirectory);
                }
                if (File.Exists(strFinalFilePath))
                {
                    _ListItem = clsGlobal.ReadSILFileToList(strFinalFilePath);
                    txtTruckSILCodeNo.Text = lst.GroupBy(x => x.TruckNo).Select(g => g.First().TruckNo).FirstOrDefault();
                    _SILCode = lst.GroupBy(x => x.TruckNo).Select(g => g.First().TruckNo).FirstOrDefault();
                    string strCheckPoints = lst.GroupBy(x => x.TruckNo).Select(g => g.First().PointCheck).FirstOrDefault();
                    if (char.IsLetter(strCheckPoints, 0))
                    {
                        txtCheckPoint.Text = "3-Points";
                    }
                    else
                    {
                        txtCheckPoint.Text = "2-Points";
                    }
                    //txtCheckPoint.Text = lst.GroupBy(x => x.TruckNo).Select(g => g.First().PointCheck).FirstOrDefault();
                    txtSILBarcode.Text = "";
                    clsGLB.showToastNGMessage($"This SIL Already Registered!!!", this);
                    txtSILBarcode.RequestFocus();
                    SoundForNG();
                    return;
                }
                else
                {
                    for (int i = 0; i < lst.Count; i++)
                    {
                        int BinQty = 0;
                        int BinNo = 0;
                        try
                        {
                            BinQty = Convert.ToInt32(clsGlobal.ReadDNHAMaster().Where(x => x.DNHAPartNo == lst[i].Part).Select(m => m.LotSize).FirstOrDefault());
                            BinNo = Convert.ToInt32(lst[i].Qty) / BinQty;
                        }
                        catch
                        {
                            BinQty = 0;
                        }
                        ViewSILScanData _listBindView = new ViewSILScanData();
                        _listBindView.PartNo = lst[i].Part;
                        _listBindView.Bin = BinNo.ToString();
                        _listBindView.Qty = lst[i].Qty.ToString();
                        _listBindView.ScanQty = "0";
                        _listBindView.Balance = Convert.ToString(lst[i].Qty - 0);
                        txtTruckSILCodeNo.Text = _SILCode = lst[i].TruckNo;

                        _ListItem.Add(_listBindView);


                    }
                    string strCheckPoints = lst.GroupBy(x => x.TruckNo).Select(g => g.First().PointCheck).FirstOrDefault();
                    if (char.IsLetter(strCheckPoints, 0))
                    {
                        txtCheckPoint.Text = "3-Points";
                    }
                    else
                    {
                        txtCheckPoint.Text = "2-Points";
                    }
                    clsGlobal.WriteSILFileFromList(strFinalFilePath, _ListItem);
                    string strSILBarcode = $"{txtSILBarcode.Text.Trim()}";
                    clsGlobal.WriteToFile(strSILBarcodeFilePath, strSILBarcode);
                    clsGLB.showToastNGMessage($"This SIL Registered successfully!!!", this);
                    txtSILBarcode.Text = "";
                    txtSILBarcode.RequestFocus();
                    SoundForOK();

                }

                GetSetTotalAndScanQty();

                receivingItemAdapter = new SILScanItemAdapter(this, _ListItem);
                recyclerViewItem.SetAdapter(receivingItemAdapter);
                receivingItemAdapter.NotifyDataSetChanged();

            }
            catch (Exception ex) { throw ex; }
        }



        private void UpdateFinalListScanQty(string strPartNo, string iQty)
        {
            try
            {
                string searchText = string.Empty;
                string replaceText = string.Empty;
                if (_ListItem.Exists(x => x.PartNo.Contains(strPartNo)))
                {
                    for (int i = 0; i < _ListItem.Count; i++)
                    {
                        //if (_ListItemFinalSave[i].PartNo.Contains(strPartNo) && _ListItemFinalSave[i].SKU == strSKU && Convert.ToInt32(_ListItemFinalSave[i].Balance) > 0)
                        if (_ListItem[i].PartNo.Contains(strPartNo) && Convert.ToInt32(_ListItem[i].Balance) > 0)
                        {
                            searchText = $"{_ListItem[i].PartNo}~{_ListItem[i].Qty}~{_ListItem[i].ScanQty}~{_ListItem[i].Balance}";
                            _ListItem[i].ScanQty = Convert.ToString(Convert.ToInt32(_ListItem[i].ScanQty) + Convert.ToInt32(iQty));
                            _ListItem[i].Balance = Convert.ToString(Convert.ToInt32(_ListItem[i].Qty) - Convert.ToInt32(_ListItem[i].ScanQty));
                            replaceText = $"{_ListItem[i].PartNo}~{_ListItem[i].Qty}~{_ListItem[i].ScanQty}~{_ListItem[i].Balance}";

                            UpdateHeaderFile(searchText, replaceText);
                            // _ScanQty += 1;
                            break;
                        }

                    }
                    // _ScanQty = _ListScanItem.Sum(x=>Convert.ToInt32( Convert.ToDecimal( x.ScanQty)));
                    receivingItemAdapter.NotifyDataSetChanged();
                    GetSetTotalAndScanQty();
                }
                //RecyclerView recyclerView = (RecyclerView)view.findViewById(R.id.recyclerView);

            }
            catch (Exception ex) { throw ex; }

        }
        private void UpdateHeaderFile(string searchText, string replaceText)
        {
            try
            {
                if (_ListItem.Count > 0)
                {
                    string strSILCode = _SILCode;
                    string strTranscationPath = Path.Combine(clsGlobal.FilePath, clsGlobal.TranscationFolder);
                    string strFinalSILWiseDirectory = Path.Combine(strTranscationPath, strSILCode);
                    string strFinalFilePath = Path.Combine(strFinalSILWiseDirectory, clsGlobal.SILMasterDataFile);
                    clsGlobal.ReplaceInFile(strFinalFilePath, searchText, replaceText);
                }

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        private void WriteSILBarcodeFile(string writeContent)
        {
            try
            {
                if (_ListItem.Count > 0)
                {
                    string strSILCode = _SILCode;
                    string strTranscationPath = Path.Combine(clsGlobal.FilePath, clsGlobal.TranscationFolder);
                    string strFinalSILWiseDirectory = Path.Combine(strTranscationPath, strSILCode);
                    string strFinalFilePath = Path.Combine(strFinalSILWiseDirectory, clsGlobal.SILBarcode);
                    clsGlobal.WriteToFile(strFinalFilePath, writeContent);
                }

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }



        private void SaveData(object sender, DialogClickEventArgs e)
        {
            try
            {

                //bool bReturn = false;
                //for (int i = 0; i < _ListScanItem.Count; i++)
                //{
                //    bReturn = ModNet.BatteryScanningDataSave(txtSILBarcode.Text.Trim(), _ListScanItem[i].SKU, _ListScanItem[i].PartNo);
                //}
                //if (bReturn)
                //{

                //    lblResult.Text = $"This Delivery ({txtSILBarcode.Text.Trim()}) Data Saved Successfully!!!";
                //    clsGLB.ShowMessage($"This Delivery ({txtSILBarcode.Text.Trim()}) Data Saved Successfully!!!", this, MessageTitle.INFORMATION);
                //    txtDNHAKanbanBarcode.Text = "";
                //    txtDNHAKanbanBarcode.RequestFocus();

                //    clear();
                //    this.Finish();
                //    OpenActivity(typeof(BatteryScanningMainActivity));
                //}
                //else
                //{
                //    lblResult.Text = ModInit.Gstrarr[0];
                //    txtDNHAKanbanBarcode.Text = "";
                //    txtDNHAKanbanBarcode.RequestFocus();
                //    SoundForNG();
                //}
            }
            catch (Exception)
            {

                throw;
            }
            finally
            { StopPlayingSound(); }
        }
        private void FinalSaveData()
        {
            try
            {

                ShowConfirmBox("Submit Scanned Data?", this, SaveData);

            }
            catch (Exception ex)
            {
                clsGLB.ShowMessage(ex.Message, this, MessageTitle.ERROR);
            }


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


        private bool MatchDNHAAndParseBarcode(string kanbanBarcode)
        {
            string partNo = string.Empty;
            string qty = "0";
            int counter = 0;
            bool isMatchPart = false;

            // Loop through the list of patterns
            foreach (var entry in clsGlobal.mlistCustomerPattern)
            {
                counter = 0;

                // Step 4: Iterate through the hashtable inside the dictionary
                for (int i = 0; i < entry.keyValueData.Count; i++)
                {
                    // Get the start and end indexes from the keyValueData entry
                    int startIndex = Convert.ToInt32(entry.keyValueData[i].Item2.ToString().Split('-')[0]);
                    int endIndex = Convert.ToInt32(entry.keyValueData[i].Item2.ToString().Split('-')[1]);

                    // Extract the part number or quantity based on the current counter
                    int length = endIndex - startIndex;
                    if (counter == 0)
                    {
                        partNo = kanbanBarcode.Trim().Substring(startIndex, length);
                    }
                    else if (counter == 1)
                    {
                        qty = kanbanBarcode.Trim().Substring(startIndex, length);
                    }

                    counter++;
                }

                // Check if the part number exists in the DNHA list
                if (clsGlobal.mlistDNHA.Exists(x => x.DNHAPartNo == partNo))
                {
                    isMatchPart = true;
                    break;
                }
            }

            // If no match is found, return false and show an error message

            return isMatchPart;
        }

        #endregion




        #region GenricFuncation for commna to get Part And Qty
        #endregion

        #region Activiy Events



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

            }
            catch (Exception ex)
            {
                clsGLB.ShowMessage(ex.Message, this, MessageTitle.ERROR);
            }
        }

        private void txtSILBarcode_KeyPress(object sender, View.KeyEventArgs e)
        {
            try
            {
                if (e.Event.Action == KeyEventActions.Down)
                {
                    if (e.KeyCode == Keycode.Enter)
                    {
                        txtSILBarcode.SelectAll();
                        GetSILScanData();

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

        private bool ValidateDNHAControls()
        {
            try
            {
                bool IsValidate = true;


                if (string.IsNullOrEmpty(txtSILBarcode.Text.Trim()))
                {
                    clsGLB.showToastNGMessage($"Scan SIL Barcode.", this);
                    txtSILBarcode.RequestFocus();
                    IsValidate = false;
                    SoundForNG();
                    //ShowAlertPopUp();
                }


                return IsValidate;
            }
            catch (Exception ex) { throw ex; }
        }

        private bool ValidateCustomerControls()
        {
            try
            {
                bool IsValidate = true;


                if (string.IsNullOrEmpty(txtSILBarcode.Text.Trim()))
                {
                    clsGLB.showToastNGMessage($"Scan SIL Barcode", this);
                    txtSILBarcode.RequestFocus();
                    IsValidate = false;
                    SoundForNG();
                    //ShowAlertPopUp();
                }


                return IsValidate;
            }
            catch (Exception ex) { throw ex; }
        }
        private bool ValidateSupplierControls()
        {
            try
            {
                bool IsValidate = true;


                if (string.IsNullOrEmpty(txtSILBarcode.Text.Trim()))
                {
                    clsGLB.showToastNGMessage($"Scan SIL Barcode", this);
                    txtSILBarcode.RequestFocus();
                    IsValidate = false;
                    SoundForNG();
                    // ShowAlertPopUp();
                }



                return IsValidate;
            }
            catch (Exception ex) { throw ex; }
        }

        private void clear()
        {

            if (_dicBatteryScanningData.Count > 0)
                _dicBatteryScanningData.Clear();
            _SILCode = "";
            _dicBarcode1.Clear();
            _dicBarcode2.Clear();
            _ScanQty = 0;
            _TotalQty = 0;

            txtSILBarcode.Text = "";

            txtSILBarcode.Enabled = true;


            selectedSKU = "";
            if (_ListItem.Count > 0)
                _ListItem.Clear();

            for (int i = 0; i < _ListItem.Count; i++)
            {
                _ListItem[i].ScanQty = "0";
                _ListItem[i].Balance = _ListItem[i].Qty;
            }
            if (receivingItemAdapter != null)
            {
                receivingItemAdapter.NotifyDataSetChanged();
            }

            txtTotalQty.Text = "Total Qty : " + _TotalQty.ToString();
            txtSILBarcode.RequestFocus();

            txtTruckSILCodeNo.Text = "";
            txtCheckPoint.Text = "";

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

        #endregion

    }
}