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
    [Activity(Label = "SILScanning", WindowSoftInputMode = Android.Views.SoftInput.StateAlwaysHidden, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation, ScreenOrientation = ScreenOrientation.Portrait)]
    public class SILScanning : Activity
    {
        #region Private Variables
        Vibrator vibrator;
        clsGlobal clsGLB;
        EditText txtSILBarcode, txtDNHASUPKanbanBarcode, txtCustKanbanBarcode;
        Dictionary<string, string> dicRegPlant = new Dictionary<string, string>();
        TextView txtTotalQty, txtScanQty, txtTruckSILCodeNo, txtCheckPoint;
        TextView lblDNHAKanban, lblCustKanban;
        TextView lblCount;
        int _TotalQty = 0, _ScanQty = 0, _SrNoCounter = 0;
        int dispatchcunt = 0;
        int _DnhaSupQty = 0;
        string _SILCode = string.Empty;
        StringBuilder _sb = new StringBuilder();
        List<ViewSILScanData> _ListItem = new List<ViewSILScanData>();

        Dictionary<string, string> _dicBarcode1 = new Dictionary<string, string>();
        Dictionary<string, string> _dicBarcode2 = new Dictionary<string, string>();

        string selectedSKU = string.Empty;
        string strDNHAPartNo = string.Empty;
        RecyclerView recyclerViewItem;
        SILScanItemAdapter receivingItemAdapter;
        RecyclerView.LayoutManager mLayoutManager;
        RecyclerView.LayoutManager mLayoutManager2;
        Dictionary<string, string> _dicBatteryScanningData = new Dictionary<string, string>();
        MediaPlayer mediaPlayerSound;
        bool scanningComplete = false;
        int iQrCode1Qty = 0;
        int iQrCode2Qty = 0;
        string strDNHAPattern = string.Empty;
        string strCustomerPattern = string.Empty;
        string strSupplierPattern = string.Empty;
        #region SILVariable
        string SILHeader = string.Empty;
        string TruckNo = string.Empty;
        string CustCode = string.Empty;
        string ShipTo = string.Empty;
        string Possition = string.Empty;
        string SILScannedON = string.Empty;
        #endregion
        #region DNHAVariable
        string CustPart = string.Empty;
        string PartNo = string.Empty;
        string Qty = string.Empty;
        string ProcessCode = string.Empty;
        string SequenceNo = string.Empty;
        string DensoBarcode = string.Empty;
        string DNHAScannedOn = string.Empty;
        #endregion

        #region CUSTVariable
        string CustScannedOn = string.Empty;
        #endregion

        #endregion

        #region Constructor
        public SILScanning()
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
                SetContentView(Resource.Layout.activity_SILScanning);

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

                lblDNHAKanban = FindViewById<TextView>(Resource.Id.lblDNHAKanban);
                txtDNHASUPKanbanBarcode = FindViewById<EditText>(Resource.Id.editDNHAKanban);
                txtDNHASUPKanbanBarcode.KeyPress += TxtDNHAKanbanBarcode_KeyPress;
                txtDNHASUPKanbanBarcode.Text = "";

                lblCustKanban = FindViewById<TextView>(Resource.Id.lblCustKanban);
                txtCustKanbanBarcode = FindViewById<EditText>(Resource.Id.editCustKanban);
                txtCustKanbanBarcode.KeyPress += TxtCustKanbanBarcode_KeyPress;
                txtCustKanbanBarcode.Text = "";

                //lblSupKanban = FindViewById<TextView>(Resource.Id.lblSuppKanban);
                //txtSUPKanbanBarcode = FindViewById<EditText>(Resource.Id.editSupKanban);
                //txtSUPKanbanBarcode.KeyPress += TxtSUPKanbanBarcode_KeyPress;
                //txtSUPKanbanBarcode.Text = "";

                txtTotalQty = FindViewById<TextView>(Resource.Id.txtTotalQty);
                txtTotalQty.Text = "Total Qty : " + _TotalQty.ToString();
                txtScanQty = FindViewById<TextView>(Resource.Id.txtScanQty);
                txtScanQty.Text = "Scan Qty : " + _ScanQty.ToString();

                txtTruckSILCodeNo = FindViewById<TextView>(Resource.Id.lblTruckNo);
                txtTruckSILCodeNo.Text = "Truck No:        ";
                txtCheckPoint = FindViewById<TextView>(Resource.Id.lblTransName);
                txtCheckPoint.Text = "";


                dispatchcunt = 0;


                // lblCount = FindViewById<TextView>(Resource.Id.lblCount);

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

                clsGlobal.ReadCustomerMaster();
                clsGlobal.ReadSupplierMaster();
                clsGlobal.ReadDNHAMaster();
                clsGlobal.ReadAlertMessage();
                clsGlobal.ReadSuspectedLotMaster();
                if (clsGlobal.mAlertMeassage != "")
                {
                    ShowAlertPopUp();
                    return;
                }
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
                        txtDNHASUPKanbanBarcode.Enabled = false;
                        txtSILBarcode.Text = "";
                        clsGLB.showToastNGMessage("Invalid SIL Barcode.", this);
                        SoundForNG();
                        ShowAlertPopUp();
                        return;

                    }

                    var lstSIlData = clsGlobal.GetSILData(txtSILBarcode.Text.Trim());
                    if (lstSIlData.Count > 0)
                    {



                        BindRecycleView(lstSIlData);
                        if (clsGlobal.mSILType == "2POINTS")
                        {
                            lblDNHAKanban.Visibility = ViewStates.Visible;
                            txtDNHASUPKanbanBarcode.Visibility = ViewStates.Visible;
                            clsGlobal.ReadDNHAPatternFile();
                            clsGlobal.ReadSupplierPatternFile();
                            txtDNHASUPKanbanBarcode.Enabled = true;
                            txtDNHASUPKanbanBarcode.RequestFocus();
                            txtSILBarcode.Enabled = false;
                        }
                        else
                        {
                            lblDNHAKanban.Visibility = ViewStates.Visible;
                            txtDNHASUPKanbanBarcode.Visibility = ViewStates.Visible;
                            clsGlobal.ReadDNHAPatternFile();
                            clsGlobal.ReadSupplierPatternFile();
                            lblCustKanban.Visibility = ViewStates.Visible;
                            txtCustKanbanBarcode.Visibility = ViewStates.Visible;
                            clsGlobal.ReadCutomerPatternFile();
                            txtSILBarcode.Enabled = false;
                            txtDNHASUPKanbanBarcode.Enabled = true;
                            txtDNHASUPKanbanBarcode.RequestFocus();

                        }
                        try
                        {
                            SILHeader = txtSILBarcode.Text.Trim().Substring(0, 20);
                            TruckNo = SILHeader.Substring(0, 7);
                            CustCode = SILHeader.Substring(7, 8);
                            ShipTo = SILHeader.Substring(15, 2);
                            Possition = SILHeader.Substring(17, 1);
                            SILScannedON = DateTime.Now.ToString();

                        }
                        catch (Exception ex)
                        {

                            throw ex;
                        }
                        SoundForOK();
                    }
                    else
                    {
                        txtDNHASUPKanbanBarcode.Enabled = false;

                        txtSILBarcode.Text = "";
                        clsGLB.showToastNGMessage("Invalid SIL Barcode.", this);
                        SoundForNG();
                        ShowAlertPopUp();

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
            txtScanQty.Text = "Scan Qty : " + _ScanQty.ToString();
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
                    txtCheckPoint.Text = lst.GroupBy(x => x.TruckNo).Select(g => g.First().PointCheck).FirstOrDefault();
                }
                else
                {
                    for (int i = 0; i < lst.Count; i++)
                    {
                        ViewSILScanData _listBindView = new ViewSILScanData();
                        _listBindView.PartNo = lst[i].Part;
                        _listBindView.Qty = lst[i].Qty.ToString();
                        _listBindView.ScanQty = "0";
                        _listBindView.Balance = Convert.ToString(lst[i].Qty - 0);
                        txtTruckSILCodeNo.Text = _SILCode = lst[i].TruckNo;
                        txtCheckPoint.Text = lst[i].PointCheck;
                        _ListItem.Add(_listBindView);


                    }
                    clsGlobal.WriteSILFileFromList(strFinalFilePath, _ListItem);
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
                    txtScanQty.Text = "Scan Qty : " + _ScanQty.ToString();
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
        private void WriteDeatilsFile(string writeContent)
        {
            try
            {
                if (_ListItem.Count > 0)
                {
                    string strSILCode = _SILCode;
                    string strTranscationPath = Path.Combine(clsGlobal.FilePath, clsGlobal.TranscationFolder);
                    string strFinalSILWiseDirectory = Path.Combine(strTranscationPath, strSILCode);
                    string strFinalFilePath = Path.Combine(strFinalSILWiseDirectory, clsGlobal.SILDetailsFile);
                    clsGlobal.WriteToFile(strFinalFilePath, writeContent);
                }

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        private void WriteSILCompltedFile(string writeContent)
        {
            try
            {
                if (_ListItem.Count > 0)
                {
                    string strSILCode = _SILCode;
                    string strTranscationPath = Path.Combine(clsGlobal.FilePath, clsGlobal.TranscationFolder);
                    string strFinalSILWiseDirectory = Path.Combine(strTranscationPath, strSILCode);
                    string strFinalFilePath = Path.Combine(strFinalSILWiseDirectory, clsGlobal.SILCompletedFile);
                    clsGlobal.WriteToFile(strFinalFilePath, writeContent);
                }

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        private void RemoveMainRecycleViewScanQty(string strPartNo)
        {
            try
            {

                if (_ListItem.Exists(x => x.PartNo.Contains(strPartNo)))
                {

                    int iIndex = _ListItem.FindIndex(x => x.PartNo.Contains(strPartNo));
                    for (int i = 0; i < _ListItem.Count; i++)
                    {
                        if (_ListItem[i].PartNo.Contains(strPartNo))
                        {
                            _ListItem[i].ScanQty = Convert.ToString(Convert.ToInt32(_ListItem[i].ScanQty) - Convert.ToInt32(1));
                            _ListItem[i].Balance = Convert.ToString(Convert.ToInt32(_ListItem[i].Qty) - Convert.ToInt32(_ListItem[i].ScanQty));
                            break;
                        }
                    }

                    // _ScanQty = _ListScanItem.Count;
                    receivingItemAdapter.NotifyDataSetChanged();
                    GetSetTotalAndScanQty();
                    txtScanQty.Text = "Scan Qty : " + _ScanQty.ToString();
                }
                //RecyclerView recyclerView = (RecyclerView)view.findViewById(R.id.recyclerView);

            }
            catch (Exception ex) { throw ex; }

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



        #region ScannningKanbanMethod
        private void EnableDisableField()
        {
            lblDNHAKanban.Visibility = ViewStates.Gone;
            txtDNHASUPKanbanBarcode.Visibility = ViewStates.Gone;
            lblCustKanban.Visibility = ViewStates.Gone;
            txtCustKanbanBarcode.Visibility = ViewStates.Gone;
            //lblSupKanban.Visibility = ViewStates.Gone;
            //txtSUPKanbanBarcode.Visibility = ViewStates.Gone;
            if (clsGlobal.mDNHAKanbanString == "DNHA")
            {
                lblDNHAKanban.Visibility = ViewStates.Visible;
                txtDNHASUPKanbanBarcode.Visibility = ViewStates.Visible;
                clsGlobal.ReadDNHAPatternFile();

                txtDNHASUPKanbanBarcode.RequestFocus();

            }
            if (clsGlobal.mCustomerKanbanString == "CUSTOMER")
            {
                lblCustKanban.Visibility = ViewStates.Visible;
                txtCustKanbanBarcode.Visibility = ViewStates.Visible;
                clsGlobal.ReadCutomerPatternFile();
                txtCustKanbanBarcode.RequestFocus();

            }
            if (clsGlobal.mSupplierKanbanString == "SUPPLIER")
            {
                //lblSupKanban.Visibility = ViewStates.Visible;
                //txtSUPKanbanBarcode.Visibility = ViewStates.Visible;
                clsGlobal.ReadSupplierPatternFile();
                //txtSUPKanbanBarcode.RequestFocus();

            }
            if (clsGlobal.mSILType == "3POINTS")
            {
                //if (lblSupKanban.Visibility == ViewStates.Visible)
                //{
                //    txtSUPKanbanBarcode.RequestFocus();

                //}
                if (lblDNHAKanban.Visibility == ViewStates.Visible)
                {
                    txtDNHASUPKanbanBarcode.RequestFocus();
                }
            }
        }
        private void ScanningDNHAKanbanBarcode()
        {
            try
            {
                if (ValidateDNHAControls())
                {
                    if (_dicBarcode1.ContainsKey(txtDNHASUPKanbanBarcode.Text.Trim()))
                    {
                        clsGLB.showToastNGMessage($"DNHA Barcode {txtDNHASUPKanbanBarcode.Text.Trim()} Already Exist!!", this);
                        txtDNHASUPKanbanBarcode.Text = "";
                        txtDNHASUPKanbanBarcode.RequestFocus();
                        SoundForNG();
                        ShowAlertPopUp();
                        return;
                    }
                    strDNHAPartNo = "";
                    string partNo = string.Empty;
                    string qty = "0";
                    string mfg = "";
                    string exp = "";
                    string lot = "";
                    int counter = 0;
                    bool isMatchPart = false;
                    bool isMatchMFGDate = false;
                    bool isMatchExpiryDate = false;
                    bool isMatchQty = false;
                    bool isMatchSuspectedLot = false;
                    bool isProductExpired = false;
                    bool isProductShippedDateCross = false;
                    bool isNGSuspectedLot = false;
                    var maxEntry = clsGlobal.mlistDNHAPattern
                       .OrderByDescending(entry => entry.keyValueData.Count);
                    // Loop through the list of patterns
                    foreach (var entry in maxEntry)
                    {
                        counter = 0;
                        // Permutations of the flags
                        if ((isMatchPart && isMatchQty) && isMatchMFGDate && isMatchExpiryDate && isMatchSuspectedLot)
                        {
                            // All remaining flags are true
                            break;
                        }
                        else if ((isMatchPart && isMatchQty) && isMatchMFGDate && isMatchExpiryDate && !isMatchSuspectedLot)
                        {
                            // MFG Date and Expiry Date are true, Suspected Lot is false
                            break;
                        }
                        else if ((isMatchPart && isMatchQty) && isMatchMFGDate && !isMatchExpiryDate && !isMatchSuspectedLot)
                        {
                            // Only MFG Date is true
                            break;
                        }
                        else if ((isMatchPart && isMatchQty) && !isMatchMFGDate && isMatchExpiryDate && isMatchSuspectedLot)
                        {
                            // Expiry Date and Suspected Lot are true, MFG Date is false
                            break;
                        }
                        else if ((isMatchPart && isMatchQty) && !isMatchMFGDate && isMatchExpiryDate && !isMatchSuspectedLot)
                        {
                            // Only Expiry Date is true
                            break;
                        }
                        else if ((isMatchPart && isMatchQty) && !isMatchMFGDate && !isMatchExpiryDate && isMatchSuspectedLot)
                        {
                            // Only Suspected Lot is true
                            break;
                        }
                        else if ((isMatchPart && isMatchQty) && isMatchMFGDate && !isMatchExpiryDate && isMatchSuspectedLot)
                        {
                            // MFG Date and Suspected Lot are true, Expiry Date is false
                            break;
                        }

                        //if (isMatchPart)
                        //{
                        //    break;
                        //}
                        // Step 4: Iterate through the hashtable inside the dictionary
                        for (int i = 0; i < entry.keyValueData.Count; i++)
                        {

                            // Get the start and end indexes from the keyValueData entry
                            int startIndex = Convert.ToInt32(entry.keyValueData[i].Item2.ToString().Split('-')[0]);
                            int endIndex = Convert.ToInt32(entry.keyValueData[i].Item2.ToString().Split('-')[1]);

                            // Extract the part number or quantity based on the current counter
                            int length = endIndex - startIndex;
                            if (entry.keyValueData[i].Item1.Trim().ToUpper() == "DNHAPARTNO")
                            {
                                try
                                {
                                    partNo = txtDNHASUPKanbanBarcode.Text.Trim().Substring(startIndex, length).Trim();

                                }
                                catch
                                {
                                    partNo = "";
                                }

                            }
                            else if (entry.keyValueData[i].Item1.Trim().ToUpper() == "QTY")
                            {
                                try
                                {
                                    int number;
                                    int.TryParse(txtDNHASUPKanbanBarcode.Text.Trim().Substring(startIndex, length), out number);
                                    qty = number.ToString().Trim();
                                    iQrCode1Qty = _DnhaSupQty = number;
                                }
                                catch
                                {
                                    qty = "";
                                }

                            }
                            else if (entry.keyValueData[i].Item1.Trim().ToUpper() == "MFG")
                            {
                                try
                                {

                                    string[] formats = { "dd-MM-yyyy", "MM-dd-yyyy", "yyyy-MM-dd" };  // Add all possible formats
                                    DateTime date;
                                    DateTime.TryParseExact(txtDNHASUPKanbanBarcode.Text.Trim().Substring(startIndex, length), formats, System.Globalization.CultureInfo.InvariantCulture, System.Globalization.DateTimeStyles.None, out date);
                                    if (date == DateTime.MinValue)
                                    {
                                        mfg = "";
                                    }
                                    else
                                    {
                                        mfg = date.ToString("yyyy-MM-dd", CultureInfo.InvariantCulture).Trim();
                                    }

                                }
                                catch
                                {
                                    mfg = "";
                                }

                            }
                            else if (entry.keyValueData[i].Item1.Trim().ToUpper() == "EXP")
                            {
                                try
                                {
                                    DateTime date;
                                    DateTime.TryParse(txtDNHASUPKanbanBarcode.Text.Trim().Substring(startIndex, length), out date);

                                    if (date == DateTime.MinValue)
                                    {
                                        exp = "";
                                    }
                                    else
                                    {
                                        exp = date.ToString("yyyy-MM-dd", CultureInfo.InvariantCulture).Trim();
                                    }
                                }
                                catch
                                {
                                    exp = "";
                                }

                            }
                            else if (entry.keyValueData[i].Item1.Trim().ToUpper() == "LOT")
                            {
                                try
                                {

                                    lot = txtDNHASUPKanbanBarcode.Text.Trim().Substring(startIndex, length).Trim();


                                }
                                catch
                                {
                                    lot = "";
                                }

                            }
                            //CheckNGSuspectedLot

                            if (clsGlobal.mlistSuspectedLot.Exists(x => x.DNHAPartNo == partNo && x.LotNo == lot))
                            {
                                isMatchSuspectedLot = true;
                                isNGSuspectedLot = true;
                            }
                            // Check if the part number exists in the DNHA list
                            if (clsGlobal.mlistDNHA.Exists(x => x.DNHAPartNo == partNo && x.IsMfgDate == true))
                            {
                                isMatchPart = true;
                                isMatchQty = true;
                                if (clsGlobal.mlistDNHA.Exists(x => x.DNHAPartNo == partNo && x.IsMfgDate == true && mfg != ""))
                                {
                                    isMatchMFGDate = true;
                                    string strExpDays = clsGlobal.mlistDNHA.Where(x => x.DNHAPartNo == partNo).Select(p => p.ExpDays).FirstOrDefault();
                                    string strShipDays = clsGlobal.mlistDNHA.Where(x => x.DNHAPartNo == partNo).Select(p => p.MFGShipDays).FirstOrDefault();
                                    if (strExpDays != null && strShipDays == null)
                                    {
                                        //DateTime dateTime = Convert.ToDateTime(mfg).AddDays(Convert.ToInt32(strExpDays));
                                        string[] formats = { "dd-MM-yyyy", "MM-dd-yyyy", "yyyy-MM-dd" };   // Add all possible formats
                                        DateTime dateTime;
                                        DateTime.TryParseExact(mfg, formats, System.Globalization.CultureInfo.InvariantCulture, System.Globalization.DateTimeStyles.None, out dateTime);

                                        dateTime = dateTime.AddDays(Convert.ToInt32(strExpDays));
                                        DateTime todayDateTime;
                                        DateTime.TryParseExact(DateTime.Today.ToString("yyyy-MM-dd"), formats, System.Globalization.CultureInfo.InvariantCulture, System.Globalization.DateTimeStyles.None, out todayDateTime);


                                        if (todayDateTime.Date > dateTime.Date)
                                        {
                                            isProductExpired = true;
                                            break;
                                        }
                                    }
                                    else if (strShipDays != null && strExpDays != null)
                                    {
                                        string[] formats = { "dd-MM-yyyy", "MM-dd-yyyy", "yyyy-MM-dd" };   // Add all possible formats
                                        DateTime todayDateTime;
                                        DateTime.TryParseExact(DateTime.Now.ToString("yyyy-MM-dd"), formats, System.Globalization.CultureInfo.InvariantCulture, System.Globalization.DateTimeStyles.None, out todayDateTime);



                                        DateTime dateExp;
                                        DateTime.TryParseExact(mfg, formats, System.Globalization.CultureInfo.InvariantCulture, System.Globalization.DateTimeStyles.None, out dateExp);
                                        dateExp = dateExp.AddDays(Convert.ToInt32(strExpDays));

                                        DateTime dateShip;
                                        DateTime.TryParseExact(mfg, formats, System.Globalization.CultureInfo.InvariantCulture, System.Globalization.DateTimeStyles.None, out dateShip);
                                        dateShip = Convert.ToDateTime(mfg).AddDays(Convert.ToInt32(strShipDays));
                                        if (todayDateTime.Date > dateExp.Date)
                                        {
                                            isProductExpired = true;
                                            break;
                                        }


                                        else if (todayDateTime.Date >= dateShip.Date && todayDateTime.Date <= dateExp.Date)
                                        {
                                            isProductShippedDateCross = true;
                                            break;
                                        }
                                    }
                                    //if (clsGlobal.mlistDNHA.Exists(x => x.DNHAPartNo == partNo
                                    //    && x.IsMfgExp == true
                                    //    && Convert.ToDateTime(mfg) >= x.MFGDate
                                    //    && Convert.ToDateTime(mfg) <= x.EXPDate))
                                    //{
                                    //    isMatchKanbanMFGAndExp = true;
                                    //    isMatchPart = true;
                                    //    break;
                                    //}

                                }
                            }

                            else if (clsGlobal.mlistDNHA.Exists(x => x.DNHAPartNo == partNo && x.IsExpDate == true))
                            {
                                isMatchExpiryDate = true;
                                bool atucalExp = clsGlobal.mlistDNHA.Where(x => x.DNHAPartNo == partNo).Select(p => p.IsExpDate).FirstOrDefault();
                                string strExpShipDays = clsGlobal.mlistDNHA.Where(x => x.DNHAPartNo == partNo).Select(p => p.EXPShipDays).FirstOrDefault();
                                int iExpShipDays = strExpShipDays == "" ? 0 : Convert.ToInt32( strExpShipDays);
                                if (DateTime.Today > DateTime.ParseExact(exp, "yyyy-MM-dd", CultureInfo.DefaultThreadCurrentCulture).AddDays(-iExpShipDays))
                                {
                                    isProductExpired = true;
                                    break;
                                }
                            }
                            else
                            {
                                if (clsGlobal.mlistDNHA.Exists(x => x.DNHAPartNo == partNo))
                                {
                                    strDNHAPattern = entry.Patterns;
                                }
                                isMatchPart = true;
                                isMatchQty = true;
                            }
                            counter++;
                        }


                    }
                    if (!isMatchPart)
                    {
                        clsGLB.showToastNGMessage("Invalid DNHA Kanban Barcode.", this);
                        txtDNHASUPKanbanBarcode.Text = "";
                        txtDNHASUPKanbanBarcode.RequestFocus();
                        SoundForNG();
                        ShowAlertPopUp();
                        return;
                    }
                    if (!_ListItem.Exists(p => p.PartNo == partNo))
                    {
                        clsGLB.showToastNGMessage($"Part No. {partNo} isn't available in SIL List! ", this);
                        txtDNHASUPKanbanBarcode.Text = "";
                        txtDNHASUPKanbanBarcode.RequestFocus();
                        SoundForNG();
                        ShowAlertPopUp();
                        return;

                    }
                    if (isNGSuspectedLot)
                    {
                        clsGLB.showToastNGMessage($"This product Lot {lot} is suspected {partNo},Scanned valid product", this);
                        txtDNHASUPKanbanBarcode.Text = "";
                        txtDNHASUPKanbanBarcode.RequestFocus();
                        SoundForNG();
                        ShowAlertPopUp();
                        return;
                    }
                    if (clsGlobal.mlistDNHA.Exists(x => x.DNHAPartNo == partNo && (x.IsExpDate == true) && isMatchExpiryDate == false))
                    {
                        clsGLB.showToastNGMessage($"This product is registered with expiary check {partNo},Scanned valid product or check pattern", this);
                        txtDNHASUPKanbanBarcode.Text = "";
                        txtDNHASUPKanbanBarcode.RequestFocus();
                        SoundForNG();
                        ShowAlertPopUp();
                        return;
                    }
                    if (clsGlobal.mlistDNHA.Exists(x => x.DNHAPartNo == partNo && (x.IsMfgDate == true) && isMatchMFGDate == false))
                    {
                        clsGLB.showToastNGMessage($"This product is registered with manufacturing check {partNo},Scanned valid product or check pattern", this);
                        txtDNHASUPKanbanBarcode.Text = "";
                        txtDNHASUPKanbanBarcode.RequestFocus();
                        SoundForNG();
                        ShowAlertPopUp();
                        return;
                    }
                    if (isProductShippedDateCross)
                    {
                        clsGLB.showToastNGMessage($"This product is Shipping date over {partNo},Scanned valid product", this);
                        txtDNHASUPKanbanBarcode.Text = "";
                        txtDNHASUPKanbanBarcode.RequestFocus();
                        SoundForNG();
                        ShowAlertPopUp();
                        return;
                    }
                    if (isProductExpired)
                    {
                        clsGLB.showToastNGMessage($"This product is Expired {partNo},Scanned valid product", this);
                        txtDNHASUPKanbanBarcode.Text = "";
                        txtDNHASUPKanbanBarcode.RequestFocus();
                        SoundForNG();
                        ShowAlertPopUp();
                        return;
                    }


                    if (!clsGlobal.mlistDNHA.Exists(p => p.DNHAPartNo == partNo))
                    {
                        clsGLB.showToastNGMessage($"Scanned Part {partNo} isn't available in main master list! ", this);
                        txtDNHASUPKanbanBarcode.Text = "";
                        txtDNHASUPKanbanBarcode.RequestFocus();
                        SoundForNG();
                        ShowAlertPopUp();
                        return;

                    }
                    if (string.IsNullOrEmpty(qty))
                    {
                        clsGLB.showToastNGMessage($"Qty is not available! ", this);
                        txtDNHASUPKanbanBarcode.Text = "";
                        txtDNHASUPKanbanBarcode.RequestFocus();
                        SoundForNG();
                        ShowAlertPopUp();
                        return;

                    }
                    if (_ListItem.Exists(p => Convert.ToInt32(p.Balance) == 0 && p.PartNo == partNo))
                    {
                        clsGLB.showToastNGMessage($"This Part No {partNo} Scanning Completed! ", this);
                        txtDNHASUPKanbanBarcode.Text = "";
                        txtDNHASUPKanbanBarcode.RequestFocus();
                        SoundForNG();
                        ShowAlertPopUp();
                        return;

                    }
                    if (_ListItem.Exists(p => Convert.ToInt32(qty) > Convert.ToInt32(p.Balance) && p.PartNo == partNo))
                    {
                        clsGLB.showToastNGMessage($"Scanned Barcode Qty {qty} should be not be greater then SIL Part Qty! ", this);
                        txtDNHASUPKanbanBarcode.Text = "";
                        txtDNHASUPKanbanBarcode.RequestFocus();
                        SoundForNG();
                        ShowAlertPopUp();
                        return;

                    }

                    try
                    {
                        CustPart = txtDNHASUPKanbanBarcode.Text.Substring(66, 25).Trim();
                        PartNo = txtDNHASUPKanbanBarcode.Text.Substring(91, 15).Trim();
                        Qty = txtDNHASUPKanbanBarcode.Text.Substring(106, 7).Trim();
                        ProcessCode = txtDNHASUPKanbanBarcode.Text.Substring(113, 5).Trim();
                        SequenceNo = txtDNHASUPKanbanBarcode.Text.Substring(118, 7).Trim();
                        DensoBarcode = txtDNHASUPKanbanBarcode.Text.Substring(0, 150).Trim();
                        DNHAScannedOn = DateTime.Now.ToString();
                    }
                    catch (Exception ex)
                    {

                        throw ex;
                    }

                    if (clsGlobal.mSILType == "2POINTS")
                    {
                        strDNHAPartNo = partNo;
                        //We will validate the Lot and Qty of kaban barcode, if any ng lot or qty should not be greater then balance qty
                        UpdateFinalListScanQty(partNo, qty);
                        WriteDeatilsFile($"{txtSILBarcode.Text.Trim()}~{clsGlobal.ReplaceNewlinesWithCaret(txtDNHASUPKanbanBarcode.Text.Trim())}~{clsGlobal.ReplaceNewlinesWithCaret(txtCustKanbanBarcode.Text.Trim())}" +
                            $"~{PartNo}~{CustPart}~{Qty}~{"0"}~{ProcessCode}~{TruckNo}~{ShipTo}~{CustCode}~{SequenceNo}~{clsGlobal.mCustSeqNo}~{clsGlobal.mUserId}" +
                            $"~{SILScannedON}~{DNHAScannedOn}~{CustScannedOn}~{strDNHAPattern}");
                        _dicBarcode1.Add(txtDNHASUPKanbanBarcode.Text.Trim(), txtDNHASUPKanbanBarcode.Text.Trim());
                        if (_TotalQty == _ScanQty)
                        {
                            WriteSILCompltedFile(TruckNo);
                            clsGLB.showToastOKMessage($"SIL No. {TruckNo} Completed! ", this);
                            txtDNHASUPKanbanBarcode.Text = "";
                            txtDNHASUPKanbanBarcode.RequestFocus();
                        }
                    }
                    else
                    {
                        strDNHAPartNo = partNo;
                        _dicBarcode1.Add(txtDNHASUPKanbanBarcode.Text.Trim(), txtDNHASUPKanbanBarcode.Text.Trim());
                        txtDNHASUPKanbanBarcode.Enabled = false;
                        txtCustKanbanBarcode.RequestFocus();
                    }
                    SoundForOK();

                }
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
        private bool CheckPartAndQty(List<ViewSILScanData> lst, string strPartNo, string qty)
        {
            bool bCheck = false;
            try
            {

                for (int i = 0; i < lst.Count; i++)
                {
                    if (_ListItem[i].PartNo == strPartNo && Convert.ToInt32(qty) > Convert.ToInt32(_ListItem[i].Balance))
                    {
                        return bCheck = true;
                    }
                }

            }
            catch (Exception ex)
            {

                throw ex;
            }
            return bCheck;

        }

        private void ScanningSUPKanbanBarcode()
        {
            try
            {
                if (ValidateSupplierControls())
                {
                    if (_dicBarcode1.ContainsKey(txtDNHASUPKanbanBarcode.Text.Trim()))
                    {

                        clsGLB.showToastNGMessage($"Supplier Barcode {txtDNHASUPKanbanBarcode.Text.Trim()} Already Exist!!", this);
                        txtDNHASUPKanbanBarcode.Text = "";
                        txtDNHASUPKanbanBarcode.RequestFocus();
                        SoundForNG();
                        ShowAlertPopUp();
                        return;
                    }

                    string partNo = string.Empty;
                    string qty = "0";
                    int counter = 0;
                    string dnhaPartNo = "";
                    bool isMatchPart = false;
                    string dnhaPartQty = string.Empty;
                    string mfg = "";
                    string exp = "";
                    string lot = "";
                    bool isMatchMFGDate = false;
                    bool isMatchExpiryDate = false;
                    bool isMatchQty = false;
                    bool isMatchSuspectedLot = false;
                    bool isProductExpired = false;
                    bool isProductShippedDateCross = false;
                    bool isNGSuspectedLot = false;
                    var maxEntry = clsGlobal.mlistSupplierPattern
                                         .OrderByDescending(entry => entry.keyValueData.Count);
                    // Loop through the list of patterns
                    foreach (var entry in maxEntry)
                    {
                        counter = 0;
                        // Permutations of the flags
                        if (isMatchPart && isMatchQty && isMatchMFGDate && isMatchExpiryDate && isMatchSuspectedLot)
                        {
                            // All flags are true
                            break;
                        }
                        else if (isMatchPart && isMatchQty && !isMatchMFGDate && !isMatchExpiryDate && !isMatchSuspectedLot)
                        {
                            // Only Part and Qty are true
                            break;
                        }
                        else if (isMatchPart && isMatchQty && isMatchMFGDate && !isMatchExpiryDate && !isMatchSuspectedLot)
                        {
                            // Part, Qty, and MFGDate are true
                            break;
                        }
                        else if (isMatchPart && !isMatchQty && !isMatchMFGDate && !isMatchExpiryDate && !isMatchSuspectedLot)
                        {
                            // Only Part is true
                            break;
                        }
                        else if (!isMatchPart && isMatchQty && isMatchMFGDate && isMatchExpiryDate && isMatchSuspectedLot)
                        {
                            // All except Part are true
                            break;
                        }
                        else if (!isMatchPart && isMatchQty && !isMatchMFGDate && !isMatchExpiryDate && !isMatchSuspectedLot)
                        {
                            // Only Qty is true
                            break;
                        }
                        else if (isMatchPart && isMatchQty && !isMatchMFGDate && isMatchExpiryDate && !isMatchSuspectedLot)
                        {
                            // Part, Qty, and ExpiryDate are true
                            break;
                        }
                        // Step 4: Iterate through the hashtable inside the dictionary
                        for (int i = 0; i < entry.keyValueData.Count; i++)
                        {
                            // Get the start and end indexes from the keyValueData entry
                            int startIndex = Convert.ToInt32(entry.keyValueData[i].Item2.ToString().Split('-')[0]);
                            int endIndex = Convert.ToInt32(entry.keyValueData[i].Item2.ToString().Split('-')[1]);

                            // Extract the part number or quantity based on the current counter
                            int length = endIndex - startIndex;
                            if (entry.keyValueData[i].Item1.Trim().ToUpper() == "SUPPLIERPARTNO")
                            {
                                try
                                {
                                    partNo = txtDNHASUPKanbanBarcode.Text.Trim().Substring(startIndex, length);
                                }
                                catch
                                {
                                    partNo = "";
                                }

                            }
                            else if (entry.keyValueData[i].Item1.Trim().ToUpper() == "QTY")
                            {
                                try
                                {
                                    int number;
                                    int.TryParse(txtDNHASUPKanbanBarcode.Text.Trim().Substring(startIndex, length), out number);
                                    qty = number.ToString();
                                    iQrCode1Qty = _DnhaSupQty = number;
                                }
                                catch
                                {

                                    qty = "";
                                }

                            }
                            else if (entry.keyValueData[i].Item1.Trim().ToUpper() == "MFG")
                            {
                                try
                                {
                                    string[] formats = { "dd-MM-yyyy", "MM-dd-yyyy", "yyyy-MM-dd" };  // Add all possible formats
                                    DateTime date;
                                    DateTime.TryParseExact(txtDNHASUPKanbanBarcode.Text.Trim().Substring(startIndex, length), formats, System.Globalization.CultureInfo.InvariantCulture, System.Globalization.DateTimeStyles.None, out date);
                                    if (date == DateTime.MinValue)
                                    {
                                        mfg = "";
                                    }
                                    else
                                    {
                                        mfg = date.ToString("yyyy-MM-dd", CultureInfo.InvariantCulture).Trim();
                                    }

                                }
                                catch
                                {
                                    mfg = "";
                                }

                            }
                            else if (entry.keyValueData[i].Item1.Trim().ToUpper() == "EXP")
                            {
                                try
                                {
                                    string[] formats = { "dd-MM-yyyy", "MM-dd-yyyy", "yyyy-MM-dd" };  // Add all possible formats
                                    DateTime date;
                                    DateTime.TryParseExact(txtDNHASUPKanbanBarcode.Text.Trim().Substring(startIndex, length), formats, System.Globalization.CultureInfo.InvariantCulture, System.Globalization.DateTimeStyles.None, out date);
                                    if (date == DateTime.MinValue)
                                    {
                                        exp = "";
                                    }
                                    else
                                    {
                                        exp = date.ToString("yyyy-MM-dd", CultureInfo.InvariantCulture).Trim();
                                    }
                                }
                                catch
                                {
                                    exp = "";
                                }

                            }
                            else if (entry.keyValueData[i].Item1.Trim().ToUpper() == "LOT")
                            {
                                try
                                {

                                    lot = txtDNHASUPKanbanBarcode.Text.Trim().Substring(startIndex, length).Trim();


                                }
                                catch
                                {
                                    lot = "";
                                }

                            }

                            if (clsGlobal.mlistSuspectedLot.Exists(x => x.DNHAPartNo == partNo && x.LotNo == lot))
                            {
                                isMatchSuspectedLot = true;
                                isNGSuspectedLot = true;
                            }
                            // Check if the part number exists in the DNHA list
                            if (clsGlobal.mlistSupplier.Exists(x => (x.DNHAPartNo == partNo || x.SupplierPartNo == partNo) && x.IsMfgDate == true))
                            {
                                isMatchPart = true;
                                isMatchQty = true;
                                isMatchMFGDate = true;
                                if (clsGlobal.mlistSupplier.Exists(x => (x.DNHAPartNo == partNo || x.SupplierPartNo == partNo) && x.IsMfgDate == true && mfg != ""))
                                {
                                    string strExpDays = clsGlobal.mlistSupplier.Where(x => (x.DNHAPartNo == partNo || x.SupplierPartNo == partNo)).Select(p => p.ExpDays).FirstOrDefault();
                                    string strShipDays = clsGlobal.mlistSupplier.Where(x => (x.DNHAPartNo == partNo || x.SupplierPartNo == partNo)).Select(p => p.ShipDays).FirstOrDefault();
                                    if (strExpDays != null && strExpDays == null)
                                    {
                                        DateTime dateTime = Convert.ToDateTime(mfg).AddDays(Convert.ToInt32(strExpDays));
                                        if (DateTime.Today.Date > dateTime.Date)
                                        {
                                            isProductExpired = true;
                                            break;
                                        }
                                    }
                                    else if (strShipDays != null && strExpDays != null)
                                    {
                                        DateTime dateTime = Convert.ToDateTime(mfg).AddDays(Convert.ToInt32(strExpDays));
                                        DateTime dateExp = Convert.ToDateTime(mfg).AddDays(Convert.ToInt32(strExpDays));
                                        DateTime dateShip = Convert.ToDateTime(mfg).AddDays(Convert.ToInt32(strShipDays));
                                        if (DateTime.Today.Date > dateTime.Date)
                                        {
                                            isProductExpired = true;
                                            break;
                                        }


                                        else if (DateTime.Today.Date >= dateShip.Date && DateTime.Today.Date <= dateShip.Date)
                                        {
                                            isProductShippedDateCross = true;
                                            break;
                                        }
                                    }
                                    //if (clsGlobal.mlistDNHA.Exists(x => x.DNHAPartNo == partNo
                                    //    && x.IsMfgExp == true
                                    //    && Convert.ToDateTime(mfg) >= x.MFGDate
                                    //    && Convert.ToDateTime(mfg) <= x.EXPDate))
                                    //{
                                    //    isMatchKanbanMFGAndExp = true;
                                    //    isMatchPart = true;
                                    //    break;
                                    //}

                                }
                            }

                            else if (clsGlobal.mlistSupplier.Exists(x => (x.DNHAPartNo == partNo || x.SupplierPartNo == partNo) && x.IsExpDate == true))
                            {
                                isMatchExpiryDate = true;
                                bool atucalExp = clsGlobal.mlistSupplier.Where(x => (x.DNHAPartNo == partNo || x.SupplierPartNo == partNo)).Select(p => p.IsExpDate).FirstOrDefault();
                                if (DateTime.Today.Date > DateTime.ParseExact(exp, "yyyy-MM-dd", CultureInfo.DefaultThreadCurrentCulture).Date)
                                {
                                    isProductExpired = true;
                                    break;
                                }
                            }
                            // Check if the part number exists in the DNHA list
                            if (clsGlobal.mlistSupplier.Exists(x => (x.DNHAPartNo == partNo || x.SupplierPartNo == partNo)))
                            {
                                //Now part is matched then need to check this partno into Main Master table any Expiry or specific validation is there then match the data
                                //If not matched it will go for next pattern if any
                                //
                                dnhaPartNo = clsGlobal.mlistSupplier.Where(x => (x.DNHAPartNo == partNo || x.SupplierPartNo == partNo)).Select(x => x.DNHAPartNo).First();
                                dnhaPartQty = qty;
                                isMatchPart = true;
                                isMatchQty = true;

                            }
                            counter++;
                        }


                    }
                    if (!isMatchPart)
                    {
                        clsGLB.showToastNGMessage("Invalid Supplier/DNHA Kanban Barcode.", this);
                        txtDNHASUPKanbanBarcode.Text = "";
                        txtDNHASUPKanbanBarcode.RequestFocus();
                        SoundForNG();
                        ShowAlertPopUp();
                        return;
                    }
                    if (!_ListItem.Exists(p => p.PartNo == dnhaPartNo))
                    {
                        clsGLB.showToastNGMessage($"Part No. {partNo} isn't available in SIL List! ", this);
                        txtDNHASUPKanbanBarcode.Text = "";
                        txtDNHASUPKanbanBarcode.RequestFocus();
                        SoundForNG();
                        ShowAlertPopUp();
                        return;

                    }
                    if (isNGSuspectedLot)
                    {
                        clsGLB.showToastNGMessage($"This product Lot {lot} is suspected {partNo},Scanned valid product", this);
                        txtDNHASUPKanbanBarcode.Text = "";
                        txtDNHASUPKanbanBarcode.RequestFocus();
                        SoundForNG();
                        ShowAlertPopUp();
                        return;
                    }
                    if (clsGlobal.mlistDNHA.Exists(x => x.DNHAPartNo == partNo && (x.IsExpDate == true) && isMatchExpiryDate == false))
                    {
                        clsGLB.showToastNGMessage($"This product is registered with expiary check {partNo},Scanned valid product or check pattern", this);
                        txtDNHASUPKanbanBarcode.Text = "";
                        txtDNHASUPKanbanBarcode.RequestFocus();
                        SoundForNG();
                        ShowAlertPopUp();
                        return;
                    }
                    if (clsGlobal.mlistDNHA.Exists(x => x.DNHAPartNo == partNo && (x.IsMfgDate == true) && isMatchMFGDate == false))
                    {
                        clsGLB.showToastNGMessage($"This product is registered with manufacturing check {partNo},Scanned valid product or check pattern", this);
                        txtDNHASUPKanbanBarcode.Text = "";
                        txtDNHASUPKanbanBarcode.RequestFocus();
                        SoundForNG();
                        ShowAlertPopUp();
                        return;
                    }
                    if (isProductExpired)
                    {
                        clsGLB.showToastNGMessage($"This product is Expired {partNo},Scanned valid product", this);
                        txtDNHASUPKanbanBarcode.Text = "";
                        txtDNHASUPKanbanBarcode.RequestFocus();
                        SoundForNG();
                        ShowAlertPopUp();
                        return;
                    }

                    if (!clsGlobal.mlistSupplier.Exists(p => p.DNHAPartNo == partNo || p.SupplierPartNo == partNo))
                    {
                        clsGLB.showToastNGMessage($"Scanned Part {partNo} isn't available in main master list! ", this);
                        txtDNHASUPKanbanBarcode.Text = "";
                        txtDNHASUPKanbanBarcode.RequestFocus();
                        SoundForNG();
                        ShowAlertPopUp();
                        return;

                    }
                    if (string.IsNullOrEmpty(qty))
                    {
                        clsGLB.showToastNGMessage($"Qty is not available! ", this);
                        txtDNHASUPKanbanBarcode.Text = "";
                        txtDNHASUPKanbanBarcode.RequestFocus();
                        SoundForNG();
                        ShowAlertPopUp();
                        return;

                    }
                    if (_ListItem.Exists(p => Convert.ToInt32(p.Balance) == 0 && p.PartNo == dnhaPartNo))
                    {
                        clsGLB.showToastNGMessage($"This Part No {dnhaPartNo} Scanning Completed! ", this);
                        txtDNHASUPKanbanBarcode.Text = "";
                        txtDNHASUPKanbanBarcode.RequestFocus();
                        SoundForNG();
                        ShowAlertPopUp();
                        return;

                    }
                    if (_ListItem.Exists(p => Convert.ToInt32(qty) > Convert.ToInt32(p.Balance) && p.PartNo == dnhaPartNo))
                    {
                        clsGLB.showToastNGMessage($"Scanned Barcode Qty {qty} should be not be greater then SIL Part Qty! ", this);
                        txtDNHASUPKanbanBarcode.Text = "";
                        txtDNHASUPKanbanBarcode.RequestFocus();
                        SoundForNG();
                        ShowAlertPopUp();
                        return;

                    }

                    if (clsGlobal.mSILType == "2POINTS")
                    {

                        //We will validate the Lot and Qty of kaban barcode, if any ng lot or qty should not be greater then balance qty
                        UpdateFinalListScanQty(dnhaPartNo, qty);
                        WriteDeatilsFile($"{txtSILBarcode.Text.Trim()}~{clsGlobal.ReplaceNewlinesWithCaret(txtDNHASUPKanbanBarcode.Text.Trim())}~{clsGlobal.mShipmentType}");
                        _dicBarcode1.Add(txtDNHASUPKanbanBarcode.Text.Trim(), txtDNHASUPKanbanBarcode.Text.Trim());
                    }
                    else
                    {
                        _dicBarcode1.Add(txtDNHASUPKanbanBarcode.Text.Trim(), txtDNHASUPKanbanBarcode.Text.Trim());
                        txtCustKanbanBarcode.RequestFocus();
                    }
                    SoundForOK();

                }
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
        #endregion

        #region GenricFuncation for commna to get Part And Qty
        #endregion

        #region Activiy Events
        private void TxtDNHAKanbanBarcode_KeyPress(object sender, View.KeyEventArgs e)
        {
            try
            {
                if (e.Event.Action == KeyEventActions.Down)
                {
                    if (e.KeyCode == Keycode.Enter)
                    {
                        //DismissKeyboard();
                        txtDNHASUPKanbanBarcode.SelectAll();
                        if (txtDNHASUPKanbanBarcode.Text.Trim().StartsWith("DISC"))
                        {

                            ScanningDNHAKanbanBarcode();

                        }
                        else
                        {

                            ScanningSUPKanbanBarcode();

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
        private void TxtCustKanbanBarcode_KeyPress(object sender, View.KeyEventArgs e)
        {
            try
            {
                if (e.Event.Action == KeyEventActions.Down)
                {
                    if (e.KeyCode == Keycode.Enter)
                    {
                        //DismissKeyboard();
                        txtCustKanbanBarcode.SelectAll();
                        if (ValidateCustomerControls())
                        {
                            //[] mfg = "12 D2009AAA4279 49400-76TM0-00 00001/00004,D2009,9,,2024100301,L211,5,AA,01,,LOC  -   3,D200,49400M76T00".Split(','); //06 index qty for tata


                            string partNo = string.Empty;
                            string qty = "0";
                            string seqNo = "0";
                            int counter = 0;
                            bool isMatchPart = false;
                            bool isMatchQty = false;
                            bool isMatchSeqNo = false;
                            string dnhaPartNo = string.Empty;
                            string dnhaPartQty = string.Empty;

                            var mlistCustomerPatternFinal = clsGlobal.mlistCustomerPattern.Where(x => x.ThreePointCheckDigit == clsGlobal.m3CheckPointsDigit).Select(x => x).ToList();
                            if (mlistCustomerPatternFinal.Count == 0)
                            {
                                clsGLB.showToastNGMessage($"Customer Barcode {txtCustKanbanBarcode.Text.Trim()} 3CheckDigitNot Matched!!", this);
                                txtCustKanbanBarcode.Text = "";
                                txtCustKanbanBarcode.RequestFocus();
                                SoundForNG();
                                ShowAlertPopUp();
                                return;
                            }
                            // Loop through the list of patterns
                            //foreach (var entry in clsGlobal.mlistCustomerPattern)
                            foreach (var entry in mlistCustomerPatternFinal)
                            {
                                counter = 0;
                                if (isMatchPart && isMatchQty)
                                {
                                    break;
                                }
                                // Step 4: Iterate through the hashtable inside the dictionary
                                for (int i = 0; i < entry.keyValueData.Count; i++)
                                {
                                    // Get the start and end indexes from the keyValueData entry
                                    int startIndex = Convert.ToInt32(entry.keyValueData[i].Item2.ToString().Split('-')[0]);
                                    int endIndex = Convert.ToInt32(entry.keyValueData[i].Item2.ToString().Split('-')[1]);

                                    // Extract the part number or quantity based on the current counter
                                    int length = endIndex - startIndex;
                                    if (entry.keyValueData[i].Item1.Trim().ToUpper() == "CUSTOMERPARTNO")
                                    {
                                        try
                                        {
                                            if (txtCustKanbanBarcode.Text.TrimEnd().Contains(",") && clsGlobal.m3CheckPointsDigit == "Y")
                                            {
                                                try
                                                {
                                                    string[] sArr = txtCustKanbanBarcode.Text.TrimEnd().Split(",");
                                                    partNo = sArr[12];
                                                }
                                                catch
                                                {
                                                    partNo = txtCustKanbanBarcode.Text.Trim().Substring(startIndex, length).Trim();
                                                }


                                            }
                                            else
                                            {
                                                partNo = txtCustKanbanBarcode.Text.Trim().Substring(startIndex, length).Trim();

                                            }
                                            qty = _DnhaSupQty.ToString();
                                        }
                                        catch
                                        {

                                            partNo = "";
                                        }

                                    }
                                    else if (entry.keyValueData[i].Item1.Trim().ToUpper() == "QTY")
                                    {
                                        try
                                        {
                                            int number = 0;
                                            if (txtCustKanbanBarcode.Text.TrimEnd().Contains(","))
                                            {
                                                string[] sArr = txtCustKanbanBarcode.Text.TrimEnd().Split(",");
                                                string strPartNoExtract = "";
                                                int iQtyExtract = 0;
                                                if (sArr.Length > 5)
                                                {
                                                    int.TryParse(txtCustKanbanBarcode.Text.TrimEnd().Split(",")[6].TrimEnd(), out number);
                                                    if (number == 0)
                                                    {
                                                        if (!clsGlobal.mlistCustomer.Exists(x => (x.DNHAPartNo == partNo.Trim() || x.CustomerPartNo.Trim().Replace("-", "").Replace(",", "") == partNo.Trim().Replace("-", "").Replace(",", "")) && x.DNHAPartNo == strDNHAPartNo))
                                                        {
                                                            clsGlobal.ParseBarcode(txtCustKanbanBarcode.Text.Trim(), out strPartNoExtract, out iQtyExtract);
                                                            partNo = strPartNoExtract;
                                                            number = iQtyExtract;
                                                        }
                                                    }
                                                    //else
                                                    //{
                                                    //    int.TryParse(txtCustKanbanBarcode.Text.TrimEnd().Split(",")[6].TrimEnd(), out number);
                                                    //}
                                                }
                                                else
                                                {
                                                    int.TryParse(txtCustKanbanBarcode.Text.Trim().Substring(startIndex, length), out number);
                                                }

                                            }
                                            else
                                            {
                                                int.TryParse(txtCustKanbanBarcode.Text.Trim().Substring(startIndex, length), out number);
                                            }


                                            qty = number.ToString().Trim();
                                        }
                                        catch
                                        {
                                            qty = "0";


                                        }


                                    }
                                    else if (entry.keyValueData[i].Item1.Trim().ToUpper() == "SEQNO")
                                    {
                                        try
                                        {
                                            string strSEQNo = "";

                                            strSEQNo = txtCustKanbanBarcode.Text.Trim().Substring(startIndex, length);

                                            seqNo = clsGlobal.mCustSeqNo = strSEQNo.ToString().Trim();
                                            isMatchSeqNo = true;
                                        }
                                        catch
                                        {
                                            seqNo = "0";


                                        }


                                    }
                                    // Check if the part number exists in the DNHA list
                                    if (clsGlobal.mlistCustomer.Exists(x => (x.DNHAPartNo == partNo.Trim() || x.CustomerPartNo.Trim().Replace("-", "").Replace(",", "") == partNo.Trim().Replace("-", "").Replace(",", "")) && x.DNHAPartNo == strDNHAPartNo))
                                    {
                                        //Now part is matched then need to check this partno into Main Master table any Expiry or specific validation is there then match the data
                                        //If not matched it will go for next pattern if any
                                        //
                                        dnhaPartNo = clsGlobal.mlistCustomer.Where(x => (x.DNHAPartNo == partNo.Trim() || x.CustomerPartNo.Trim().Replace("-", "").Replace(",", "") == partNo.Trim().Replace("-", "").Replace(",", "")) && x.DNHAPartNo == strDNHAPartNo).Select(x => x.DNHAPartNo).First();
                                        dnhaPartQty = qty;
                                        strCustomerPattern = entry.Patterns;
                                        iQrCode2Qty = Convert.ToInt32(qty);
                                        isMatchPart = true;
                                        if (iQrCode2Qty > 0)
                                        {
                                            isMatchQty = true;
                                        }



                                    }
                                    counter++;
                                }


                            }

                            if (!isMatchPart)
                            {
                                clsGLB.showToastNGMessage("Invalid Customer Kanban Barcode.", this);
                                txtCustKanbanBarcode.Text = "";
                                txtCustKanbanBarcode.RequestFocus();
                                SoundForNG();
                                ShowAlertPopUp();
                                return;
                            }
                            if (!_ListItem.Exists(p => p.PartNo == dnhaPartNo))
                            {
                                clsGLB.showToastNGMessage($"Part No. {dnhaPartNo} isn't available in SIL List! ", this);
                                txtCustKanbanBarcode.Text = "";
                                txtCustKanbanBarcode.RequestFocus();
                                SoundForNG();
                                ShowAlertPopUp();
                                return;

                            }
                            if (!clsGlobal.mlistCustomer.Exists(x => (x.DNHAPartNo == partNo.Trim() || x.CustomerPartNo.Trim().Replace("-", "").Replace(",", "") == partNo.Trim().Replace("-", "").Replace(",", "")) && x.DNHAPartNo == strDNHAPartNo))
                            {
                                clsGLB.showToastNGMessage($"Scanned Part. {partNo} isn't available in main master list! ", this);
                                txtDNHASUPKanbanBarcode.Text = "";
                                txtDNHASUPKanbanBarcode.RequestFocus();
                                SoundForNG();
                                ShowAlertPopUp();
                                return;

                            }
                            if (string.IsNullOrEmpty(qty))
                            {
                                clsGLB.showToastNGMessage($"Qty is not available! ", this);
                                txtCustKanbanBarcode.Text = "";
                                txtCustKanbanBarcode.RequestFocus();
                                SoundForNG();
                                ShowAlertPopUp();
                                return;

                            }
                            if (_ListItem.Exists(p => Convert.ToInt32(p.Balance) == 0 && p.PartNo == dnhaPartNo))
                            {
                                clsGLB.showToastNGMessage($"This Part No {dnhaPartNo} Scanning Completed! ", this);
                                txtDNHASUPKanbanBarcode.Text = "";
                                txtDNHASUPKanbanBarcode.RequestFocus();
                                SoundForNG();
                                ShowAlertPopUp();
                                return;

                            }
                            if (_ListItem.Exists(p => Convert.ToInt32(qty) > Convert.ToInt32(p.Balance) && p.PartNo == dnhaPartNo))
                            {
                                clsGLB.showToastNGMessage($"Scanned Barcode Qty {qty} should be not be greater then SIL Part Qty! ", this);
                                txtCustKanbanBarcode.Text = "";
                                txtCustKanbanBarcode.RequestFocus();
                                SoundForNG();
                                ShowAlertPopUp();
                                return;

                            }
                            if (isMatchSeqNo)
                            {
                                if (clsGlobal.mSILType == "2POINTS")
                                {
                                    if (_dicBarcode1.ContainsKey(seqNo.Trim()))
                                    {

                                        clsGLB.showToastNGMessage($"Customer Barcode {txtCustKanbanBarcode.Text.Trim()} Already Exist!!", this);
                                        txtCustKanbanBarcode.Text = "";
                                        txtCustKanbanBarcode.RequestFocus();
                                        SoundForNG();
                                        ShowAlertPopUp();
                                        return;
                                    }
                                }
                                else
                                {
                                    if (_dicBarcode2.ContainsKey(seqNo.Trim()))
                                    {

                                        clsGLB.showToastNGMessage($"Customer Barcode {txtCustKanbanBarcode.Text.Trim()} Already Exist!!", this);
                                        txtCustKanbanBarcode.Text = "";
                                        txtCustKanbanBarcode.RequestFocus();
                                        SoundForNG();
                                        ShowAlertPopUp();
                                        return;
                                    }
                                }
                            }

                            if (clsGlobal.mSILType == "2POINTS")
                            {
                                WriteDeatilsFile($"{txtSILBarcode.Text.Trim()}~{clsGlobal.ReplaceNewlinesWithCaret(txtCustKanbanBarcode.Text.Trim())}~{clsGlobal.mShipmentType}");
                                if (isMatchSeqNo)
                                {
                                    //_dicBarcode1.Add(txtCustKanbanBarcode.Text.Trim(), txtCustKanbanBarcode.Text.Trim());
                                    _dicBarcode1.Add(seqNo, seqNo);
                                }
                                txtCustKanbanBarcode.SelectAll();
                                txtCustKanbanBarcode.RequestFocus();
                            }
                            else
                            {
                                if (iQrCode1Qty != iQrCode2Qty)
                                {
                                    clsGLB.showToastNGMessage($"QR Code1 Qty {iQrCode1Qty} should be equal to QR Code2 Qty {iQrCode2Qty} ! ", this);
                                    txtCustKanbanBarcode.Text = "";
                                    txtCustKanbanBarcode.RequestFocus();
                                    SoundForNG();
                                    ShowAlertPopUp();
                                    return;

                                }
                                string strBarcode1 = string.Empty;
                                if (txtDNHASUPKanbanBarcode.Text.Length > 0)
                                {
                                    strBarcode1 = txtDNHASUPKanbanBarcode.Text.Trim();
                                }
                                else
                                {
                                    strBarcode1 = txtDNHASUPKanbanBarcode.Text.Trim();
                                }
                                CustScannedOn = DateTime.Now.ToString();
                                //WriteDeatilsFile($"{txtSILBarcode.Text.Trim()}~{strBarcode1}~{clsGlobal.ReplaceNewlinesWithCaret(txtCustKanbanBarcode.Text.Trim())}~{clsGlobal.mShipmentType}")
                                WriteDeatilsFile($"{txtSILBarcode.Text.Trim()}~{clsGlobal.ReplaceNewlinesWithCaret(txtDNHASUPKanbanBarcode.Text.Trim())}" +
                                $"~{clsGlobal.ReplaceNewlinesWithCaret(txtCustKanbanBarcode.Text.Trim())}" +
                                $"~{PartNo}~{CustPart}~{Qty}~{"0"}~{ProcessCode}~{TruckNo}~{ShipTo}~{CustCode}~{SequenceNo}~{clsGlobal.mCustSeqNo}~{clsGlobal.mUserId}" +
                                $"~{SILScannedON}~{DNHAScannedOn}~{CustScannedOn}~{strCustomerPattern}");
                                if (isMatchSeqNo)
                                {
                                    //_dicBarcode2.Add(txtCustKanbanBarcode.Text.Trim(), txtCustKanbanBarcode.Text.Trim());
                                    _dicBarcode2.Add(seqNo, seqNo);
                                }
                            }
                            //We will validate the Lot and Qty of kaban barcode, if any ng lot or qty should not be greater then balance qty

                            //We will validate the Lot and Qty of kaban barcode, if any ng lot or qty should not be greater then balance qty
                            //UpdateFinalListScanQty(partNo, qty);
                            UpdateFinalListScanQty(dnhaPartNo, dnhaPartQty);
                            txtDNHASUPKanbanBarcode.Text = txtCustKanbanBarcode.Text = txtDNHASUPKanbanBarcode.Text = "";
                            txtDNHASUPKanbanBarcode.Enabled = true;
                            txtDNHASUPKanbanBarcode.RequestFocus();
                            if (_TotalQty == _ScanQty)
                            {
                                WriteSILCompltedFile(TruckNo);
                                clsGLB.showToastOKMessage($"SIL No. {TruckNo} Completed! ", this);
                                txtDNHASUPKanbanBarcode.Text = "";
                                txtDNHASUPKanbanBarcode.RequestFocus();
                            }
                            SoundForOK();
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
            finally
            { }
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
                        lblDNHAKanban.Visibility = ViewStates.Gone;
                        txtDNHASUPKanbanBarcode.Visibility = ViewStates.Gone;
                        lblCustKanban.Visibility = ViewStates.Gone;
                        txtCustKanbanBarcode.Visibility = ViewStates.Gone;
                        //lblSupKanban.Visibility = ViewStates.Gone;
                        //txtSUPKanbanBarcode.Visibility = ViewStates.Gone;
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
                    ShowAlertPopUp();
                }

                else if (string.IsNullOrEmpty(txtDNHASUPKanbanBarcode.Text.Trim()))
                {
                    clsGLB.showToastNGMessage($"Scan DNHA Kanban Barcode.", this);
                    txtDNHASUPKanbanBarcode.Text = "";
                    txtDNHASUPKanbanBarcode.RequestFocus();
                    IsValidate = false;
                    SoundForNG();
                    ShowAlertPopUp();
                }
                else if (txtDNHASUPKanbanBarcode.Text.Length < 25)
                {
                    clsGLB.showToastNGMessage($"Invalid DNHA Kanban Barcode.", this);
                    txtDNHASUPKanbanBarcode.Text = "";
                    txtDNHASUPKanbanBarcode.RequestFocus();
                    IsValidate = false;
                    SoundForNG();
                    ShowAlertPopUp();
                }
                else if (_TotalQty == _ScanQty)
                {
                    clsGLB.showToastNGMessage($"Scan Completed of this SIL.", this);
                    txtDNHASUPKanbanBarcode.Text = "";
                    txtDNHASUPKanbanBarcode.RequestFocus();
                    IsValidate = false;
                    SoundForNG();
                    ShowAlertPopUp();
                }

                else if (_ListItem.Count == 0)
                {
                    clsGLB.showToastNGMessage($"SIL Data is not Available", this);
                    txtDNHASUPKanbanBarcode.Text = "";
                    txtDNHASUPKanbanBarcode.RequestFocus();
                    IsValidate = false;
                    SoundForNG();
                    ShowAlertPopUp();
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
                    ShowAlertPopUp();
                }

                else if (string.IsNullOrEmpty(txtCustKanbanBarcode.Text.Trim()))
                {
                    clsGLB.showToastNGMessage($"Scan Customer Kanban Barcode.", this);
                    txtCustKanbanBarcode.Text = "";
                    txtCustKanbanBarcode.RequestFocus();
                    IsValidate = false;
                    SoundForNG();
                    ShowAlertPopUp();
                }
                //else if (txtCustKanbanBarcode.Text.Trim().Length < 25)
                //{
                //    clsGLB.showToastNGMessage($"Invalid Customer Kanban Barcode.", this);
                //    txtCustKanbanBarcode.Text = "";
                //    txtCustKanbanBarcode.RequestFocus();
                //    IsValidate = false;
                //    SoundForNG();
                //    ShowAlertPopUp();
                //}
                else if (_TotalQty == _ScanQty)
                {
                    clsGLB.showToastNGMessage($"Scan Completed of this SIL.", this);
                    txtCustKanbanBarcode.Text = "";
                    txtCustKanbanBarcode.RequestFocus();
                    IsValidate = false;
                    SoundForNG();
                    ShowAlertPopUp();
                }
                else if (_ListItem.Count == 0)
                {
                    clsGLB.showToastNGMessage($"SIL Data is not Available", this);
                    txtCustKanbanBarcode.Text = "";
                    txtCustKanbanBarcode.RequestFocus();
                    IsValidate = false;
                    SoundForNG();
                    ShowAlertPopUp();
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
                    ShowAlertPopUp();
                }

                else if (string.IsNullOrEmpty(txtDNHASUPKanbanBarcode.Text.Trim()))
                {
                    clsGLB.showToastNGMessage($"Scan Supplier Kanban Barcode.", this);
                    txtDNHASUPKanbanBarcode.Text = "";
                    txtDNHASUPKanbanBarcode.RequestFocus();
                    IsValidate = false;
                    SoundForNG();
                    ShowAlertPopUp();
                }
                else if (txtDNHASUPKanbanBarcode.Text.Length < 25)
                {
                    clsGLB.showToastNGMessage($"Invalid Supplier Kanban Barcode.", this);
                    txtDNHASUPKanbanBarcode.Text = "";
                    txtDNHASUPKanbanBarcode.RequestFocus();
                    IsValidate = false;
                    SoundForNG();
                    ShowAlertPopUp();
                }
                else if (_TotalQty == _ScanQty)
                {
                    clsGLB.showToastNGMessage($"Scan Completed of this SIL.", this);
                    txtDNHASUPKanbanBarcode.Text = "";
                    txtDNHASUPKanbanBarcode.RequestFocus();
                    IsValidate = false;
                    SoundForNG();
                    ShowAlertPopUp();
                }
                else if (_ListItem.Count == 0)
                {
                    clsGLB.showToastNGMessage($"SIL Data is not Available", this);
                    txtDNHASUPKanbanBarcode.Text = "";
                    txtDNHASUPKanbanBarcode.RequestFocus();
                    IsValidate = false;
                    SoundForNG();
                    ShowAlertPopUp();
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
            iQrCode1Qty = 0;
            iQrCode2Qty = 0;
            txtDNHASUPKanbanBarcode.Text = "";
            txtCustKanbanBarcode.Text = "";
            txtSILBarcode.Text = "";
            lblDNHAKanban.Visibility = ViewStates.Gone;
            txtDNHASUPKanbanBarcode.Visibility = ViewStates.Gone;
            lblCustKanban.Visibility = ViewStates.Gone;
            txtCustKanbanBarcode.Visibility = ViewStates.Gone;
            txtSILBarcode.Enabled = true;
            txtDNHASUPKanbanBarcode.Enabled = true;
            txtCustKanbanBarcode.Enabled = true;

            //lblSupKanban.Visibility = ViewStates.Gone;
            //txtSUPKanbanBarcode.Visibility = ViewStates.Gone;

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
            txtScanQty.Text = "Scan Qty : " + _ScanQty.ToString();
            txtSILBarcode.RequestFocus();

            txtTruckSILCodeNo.Text = "Truck No:        ";
            txtCheckPoint.Text = "";
            SILHeader = "";
            TruckNo = "";
            CustCode = "";
            ShipTo = "";
            Possition = "";
            CustPart = string.Empty;
            PartNo = string.Empty;
            Qty = string.Empty;
            ProcessCode = string.Empty;
            SequenceNo = string.Empty;
            DensoBarcode = string.Empty;
            DNHAScannedOn = string.Empty;
            strDNHAPattern = string.Empty;
            strCustomerPattern = string.Empty;
            strSupplierPattern = string.Empty;
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