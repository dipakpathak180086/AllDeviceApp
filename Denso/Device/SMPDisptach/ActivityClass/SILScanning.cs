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
using System.Xml;
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
using Java.Util.Functions;
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
        clsGlobal clsGlobal;
        Spinner spinnerSIL;
        List<string> _lstSIL = new List<string>();
        EditText txtDNHASUPKanbanBarcode, txtCustKanbanBarcode;
        Dictionary<string, string> dicRegPlant = new Dictionary<string, string>();
        TextView txtTotalQty, txtScanQty, txtTruckSILCodeNo, txtCheckPoint;
        TextView lblDNHAKanban, lblCustKanban;
        TextView lblCount;
        TextView lblPartCount;
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
        string _strSILBarCode = string.Empty;
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
        string valueombinedBarcode1Key = "";
        bool isvalueMatchBarcode1SeqNo = false;
        string valueombinedBarcode2Key = "";
        bool isvalueMatchBarcode2SeqNo = false;

        string[] formats = {
            "MM/dd/yyyy hh:mm:ss tt",  // Format with AM/PM
            "dd/MM/yyyy hh:mm:ss tt",  // Another possible format
            "MM/dd/yyyy HH:mm:ss",     // 24-hour format
            "dd/MM/yyyy HH:mm:ss",     // 24-hour format with day first
            "MM/dd/yyyy",              // Without time
            "dd/MM/yyyy"               // Day first without time
        };
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
                // clsGlobal = new clsGlobal();

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

                spinnerSIL = FindViewById<Spinner>(Resource.Id.spinnerSIL);
                spinnerSIL.ItemSelected += SpinnerSIL_ItemSelected;



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


                lblPartCount = FindViewById<TextView>(Resource.Id.lblPartCount);

                recyclerViewItem = FindViewById<RecyclerView>(Resource.Id.recycleViewReceiveItem);
                mLayoutManager = new LinearLayoutManager(this);
                recyclerViewItem.SetLayoutManager(mLayoutManager);

                string strTranscationPath = Path.Combine(clsGlobal.FilePath, clsGlobal.TranscationFolder);
                MediaScannerConnection.ScanFile(this, new String[] { strTranscationPath }, null, null);
                clsGlobal.DeleteDirectoryWithOutFile(strTranscationPath);

                clsGlobal.ReadCustomerMaster();
                clsGlobal.ReadSupplierMaster();
                clsGlobal.ReadDNHAMaster();
                clsGlobal.ReadAlertMessage();
                clsGlobal.ReadSuspectedLotMaster();
                clsGlobal.ReadCUSTExpMaster();
                clsGlobal.ReadExpiryControlMaster();
                if (clsGlobal.mAlertMeassage != "")
                {
                    ShowAlertPopUp();
                    return;
                }
                BindSpinnerRegisteredSIL();
            }
            catch (Exception ex)
            {
                clsGlobal.ShowMessage(ex.Message, this, MessageTitle.ERROR);
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
                clsGlobal.ShowMessage(ex.Message, this, MessageTitle.ERROR);
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
                clsGlobal.ShowMessage(ex.Message, this, MessageTitle.ERROR);
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
        //private void SoundForOK()
        //{
        //    try
        //    {
        //        Task.Run(() =>
        //        { //Start Vibration
        //            long[] pattern = { 0, 2000, 500 }; //0 to start now, 200 to vibrate 200 ms, 0 to sleep for 0 ms.
        //            vibrator.Vibrate(pattern, -1);//
        //            StopPlayingSound();
        //            StartPlayingSound(true);
        //            Thread.Sleep(2000);
        //            StopPlayingSound();
        //            vibrator.Cancel();
        //        });

        //    }
        //    catch (Exception ex) { throw ex; }
        //}
        private CancellationTokenSource _cts = new CancellationTokenSource();
        private void SoundForOK()
        {
            _cts.Cancel(); // Stop previous task
            _cts = new CancellationTokenSource();
            var token = _cts.Token;

            Task.Run(() =>
            {

                StopPlayingSound();
                StartPlayingSound(true);

                Thread.Sleep(500); // Wait for 2 seconds

                if (!token.IsCancellationRequested)
                {
                    StopPlayingSound();

                }
            }, token);
        }
        private void SoundForOKVibrate()
        {
            _cts.Cancel(); // Stop previous task
            _cts = new CancellationTokenSource();
            var token = _cts.Token;

            Task.Run(() =>
            {
                vibrator.Vibrate(new long[] { 0, 2000, 500 }, -1);
                StopPlayingSound();
                StartPlayingSound(true);

                Thread.Sleep(500); // Wait for 2 seconds

                if (!token.IsCancellationRequested)
                {
                    StopPlayingSound();
                    vibrator.Cancel();
                }
            }, token);
        }

        //private void SoundForNG()
        //{
        //    try
        //    {
        //        Task.Run(() =>
        //        {
        //            StopPlayingSound();
        //            StartPlayingSound();
        //            Thread.Sleep(3000);
        //            StopPlayingSound();
        //        });

        //    }
        //    catch (Exception ex) { throw ex; }
        //}
        private CancellationTokenSource _ctsNG = new CancellationTokenSource();

        private void SoundForNG()
        {
            _ctsNG.Cancel();
            _ctsNG = new CancellationTokenSource();

            Task.Run(async () =>
            {
                StopPlayingSound();
                StartPlayingSound();
                await Task.Delay(3000);
                StopPlayingSound();
            }, _ctsNG.Token);
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

        public void BindALLSIL(string path)
        {
            try
            {
                _lstSIL.Clear();
                _lstSIL.Add("--Select--");
                string[] directoriesFinal = Directory.GetDirectories(path).OrderBy(x => x).ToArray();
                for (int i = 0; i < directoriesFinal.Length; i++)
                {
                    string strCompltedSIL = Path.Combine(directoriesFinal[i].TrimEnd(Path.DirectorySeparatorChar), clsGlobal.SILCompletedFile);
                    if (File.Exists(strCompltedSIL))
                    {
                        string strSILCode = Path.GetFileName(directoriesFinal[i].TrimEnd(Path.DirectorySeparatorChar));
                        _lstSIL.Add("*" + strSILCode);

                    }
                    else
                    {
                        string strSILCode = Path.GetFileName(directoriesFinal[i].TrimEnd(Path.DirectorySeparatorChar));
                        _lstSIL.Add(strSILCode);
                    }

                }

                // Get all directories
            }
            catch (Exception ex)
            {
                // Handle exceptions (e.g., path not found)
                Console.WriteLine(ex.Message);
            }
        }
        private void BindSpinnerRegisteredSIL()
        {

            string strTranscationPath = Path.Combine(clsGlobal.FilePath, clsGlobal.TranscationFolder);
            BindALLSIL(strTranscationPath);



            ArrayAdapter arrayAdapter = new ArrayAdapter(this, Resource.Layout.Spinner, _lstSIL);
            arrayAdapter.SetDropDownViewResource(Android.Resource.Layout.SimpleSpinnerDropDownItem);
            spinnerSIL.Adapter = arrayAdapter;
            spinnerSIL.SetSelection(0);
            spinnerSIL.RequestFocus();
        }
        private void GetSILScanData(string strSILBarcode)
        {
            try
            {

                if (strSILBarcode.Length > 0)
                {
                    clsGlobal.mSILType = clsGlobal.mGetCheckPoints(strSILBarcode.Trim());
                    clsGlobal.mCustomerCode = Convert.ToString(Convert.ToInt32(clsGlobal.mGetCustomerCode(strSILBarcode.Trim())));
                    clsGlobal.mShipmentType = clsGlobal.mCheckSILTILType(strSILBarcode.Trim());
                    if (clsGlobal.mShipmentType != "SIL" && clsGlobal.mShipmentType != "TIL")
                    {
                        txtDNHASUPKanbanBarcode.Enabled = false;
                        clsGlobal.showToastNGMessage("Invalid SIL/TIL Barcode.", this);
                        SoundForNG();
                        ShowAlertPopUp();
                        return;

                    }

                    var lstSIlData = clsGlobal.GetSILData(strSILBarcode);
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
                            spinnerSIL.Enabled = false;
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
                            spinnerSIL.Enabled = false;
                            txtDNHASUPKanbanBarcode.Enabled = true;
                            txtDNHASUPKanbanBarcode.RequestFocus();

                        }
                        try
                        {
                            SILHeader = strSILBarcode.Trim().Substring(0, 20);
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
                        SoundForOKVibrate();
                    }
                    else
                    {
                        txtDNHASUPKanbanBarcode.Enabled = false;

                        spinnerSIL.SetSelection(0);
                        clsGlobal.showToastNGMessage("Invalid SIL Barcode.", this);
                        SoundForNG();
                        ShowAlertPopUp();

                    }

                }
            }
            catch (Exception ex)
            {
                clsGlobal.ShowMessage(ex.Message, this, MessageTitle.ERROR);

            }


        }
        private void GetUpdateScannedBinCount()
        {
            int iRemainedBin = 0;
            for (int i = 0; i < _ListItem.Count; i++)
            {
                int iBinSize = Convert.ToInt32(clsGlobal.mlistDNHA.Where(x => x.DNHAPartNo == _ListItem[i].PartNo).Select(m => m.LotSize).FirstOrDefault());

                if (iBinSize > 0)
                {
                    int iSumScanQty = Convert.ToInt32(_ListItem.Where(x => x.PartNo == _ListItem[i].PartNo).Select(m => m.ScanQty).FirstOrDefault());
                    int iBin = Convert.ToInt32(_ListItem.Where(x => x.PartNo == _ListItem[i].PartNo).Select(m => m.Bin).FirstOrDefault());
                    int ibinsUsed = iSumScanQty / iBinSize;
                    iRemainedBin += Math.Max(iBin - ibinsUsed, 0);
                }
            }
            txtCheckPoint.Text = iRemainedBin.ToString();
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
        public void BindDataWithZeroBalanceAtBottom(List<ViewSILScanData> data)
        {
            // Reorder the dataset: Move items with Balance == 0 to the bottom
            var reorderedData = data
                .Where(d => Convert.ToInt32(d.Balance) > 0) // Items with non-zero balance
                .Concat(data.Where(d => Convert.ToInt32(d.Balance) == 0)) // Items with zero balance
                .ToList();

            // Update the dataset in the adapter
            _ListItem = reorderedData;

            // Notify the adapter that the data has changed
            receivingItemAdapter.NotifyDataSetChanged();
        }
        private void BindRecycleView(List<KanbanData> lst)
        {
            try
            {

                _ListItem.Clear();
                _dicBarcode1.Clear();
                _dicBarcode2.Clear();
                clsGlobal.mlistCustomer.Clear();
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
                        if (_ListDetails[i].isMatchBarcode1SeqNo)
                        {
                            if (!_dicBarcode1.ContainsKey(_ListDetails[i].Barcode1SEQNo))
                                _dicBarcode1.Add(_ListDetails[i].Barcode1SEQNo, _ListDetails[i].Barcode1SEQNo);
                        }
                        if (_ListDetails[i].isMatchBarcode2SeqNo)
                        {
                            if (!_dicBarcode2.ContainsKey(_ListDetails[i].Barcode2SEQNo))
                                _dicBarcode2.Add(_ListDetails[i].Barcode2SEQNo, _ListDetails[i].Barcode2SEQNo);
                        }
                    }
                }
                if (!Directory.Exists(strFinalSILWiseDirectory))
                {
                    Directory.CreateDirectory(strFinalSILWiseDirectory);
                }
                string strCheckPoints = "";
                if (File.Exists(strFinalFilePath))
                {
                    _ListItem = clsGlobal.ReadSILFileToList(strFinalFilePath);
                    txtTruckSILCodeNo.Text = lst.GroupBy(x => x.TruckNo).Select(g => g.First().TruckNo).FirstOrDefault();
                    _SILCode = lst.GroupBy(x => x.TruckNo).Select(g => g.First().TruckNo).FirstOrDefault();
                    strCheckPoints = lst.GroupBy(x => x.TruckNo).Select(g => g.First().PointCheck).FirstOrDefault();
                    if (char.IsLetter(strCheckPoints, 0))
                    {
                        txtCheckPoint.Text = "3-Points";
                    }
                    else
                    {
                        txtCheckPoint.Text = "2-Points";
                    }



                    var partNoSet = new HashSet<string>(_ListItem.Select(x => x.PartNo));
                    var mlistCustomer = clsGlobal.mlistAllCustomer.Where(c => partNoSet.Contains(c.DNHAPartNo)).ToList();

                    //var filteredList = clsGlobal.mlistCustomer.Where(part => _ListItem.Contains(part.DNHAPartNo)).ToList();
                    clsGlobal.mlistCustomer = mlistCustomer.ToList();
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


                        var partNoSet = new HashSet<string>(_ListItem.Select(x => x.PartNo));
                        var mlistCustomer = clsGlobal.mlistAllCustomer.Where(c => partNoSet.Contains(c.DNHAPartNo)).ToList();

                        //var filteredList = clsGlobal.mlistCustomer.Where(part => _ListItem.Contains(part.DNHAPartNo)).ToList();
                        clsGlobal.mlistCustomer = mlistCustomer.ToList();
                    }
                    clsGlobal.WriteSILFileFromList(strFinalFilePath, _ListItem);
                }
                strCheckPoints = lst.GroupBy(x => x.TruckNo).Select(g => g.First().PointCheck).FirstOrDefault();
                if (char.IsLetter(strCheckPoints, 0))
                {
                    txtCheckPoint.Text = "3-Points";
                }
                else
                {
                    txtCheckPoint.Text = "2-Points";
                }

                GetSetTotalAndScanQty();

                receivingItemAdapter = new SILScanItemAdapter(this, _ListItem);
                recyclerViewItem.SetAdapter(receivingItemAdapter);
                lblPartCount.Text = Convert.ToString(_ListItem.Count(x => x.Balance != "0"));
                receivingItemAdapter.NotifyDataSetChanged();
                GetUpdateScannedBinCount();
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
                    lblPartCount.Text = Convert.ToString(_ListItem.Count(x => x.Balance != "0"));
                    txtScanQty.Text = "Scan Qty : " + _ScanQty.ToString();
                    GetUpdateScannedBinCount();
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
                    lblPartCount.Text = Convert.ToString(_ListItem.Count(x => x.Balance != "0"));
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
                //    clsGlobal.ShowMessage($"This Delivery ({txtSILBarcode.Text.Trim()}) Data Saved Successfully!!!", this, MessageTitle.INFORMATION);
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
                clsGlobal.ShowMessage(ex.Message, this, MessageTitle.ERROR);
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
        private void ScanningDNHAKanbanBarcode()
        {
            try
            {
                if (ValidateDNHAControls())
                {
                    //if (_dicBarcode1.ContainsKey(txtDNHASUPKanbanBarcode.Text.Trim()))
                    //{
                    //    clsGlobal.showToastNGMessage($"DNHA Barcode {txtDNHASUPKanbanBarcode.Text.Trim()} Already Exist!!", this);
                    //    txtDNHASUPKanbanBarcode.Text = "";
                    //    txtDNHASUPKanbanBarcode.RequestFocus();
                    //    SoundForNG();
                    //    ShowAlertPopUp();
                    //    return;
                    //}
                    strDNHAPartNo = "";
                    _DnhaSupQty = 0;

                    string partNo = string.Empty;
                    string qty = "0";
                    string mfg = "";
                    string exp = "";
                    string lot = "";
                    int counter = 0;
                    string seqNo = "";
                    string barcodeLength = "";
                    string combinedKey = "";
                    bool isMatchSeqNo = false;
                    bool isMatchPart = false;
                    bool isMatchMFGDate = false;
                    bool isMatchExpiryDate = false;
                    bool isMatchQty = false;
                    bool isMatchSuspectedLot = false;
                    bool isMatchBarcodeLength = false;
                    bool isProductExpired = false;
                    bool isProductMFGShippedDateCross = false;
                    bool isProductEXPShippedDateCross = false;
                    bool isNGSuspectedLot = false;
                    bool isBarcodeLength = false;
                    DateTime? mfgdate = null;
                    DateTime? expdate = null;
                    string strCode = Convert.ToInt32(clsGlobal.mCustomerCode).ToString();
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
                        else if ((isMatchPart && isMatchQty) && !isMatchMFGDate && !isMatchExpiryDate && !isMatchSuspectedLot)
                        {
                            break;
                        }
                        else
                        {
                            //Added by dipak 27-02-25 
                            isMatchPart = false; isMatchQty = false; isMatchMFGDate = false; isMatchExpiryDate = false; isMatchSeqNo = false; isMatchSuspectedLot = false;
                            isBarcodeLength = false; isMatchBarcodeLength = false;
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
                            string sepraterIndex = Convert.ToString(entry.keyValueData[i].Item2.ToString().Split('-')[2]);
                            string strTheSeprator = Convert.ToString(entry.Seperater);

                            // Extract the part number or quantity based on the current counter
                            int length = endIndex - startIndex;
                            if (entry.keyValueData[i].Item1.Trim().ToUpper() == "DNHAPARTNO")
                            {
                                if (strTheSeprator != "")
                                {
                                    try
                                    {
                                        string[] sArrBarcode = txtDNHASUPKanbanBarcode.Text.Split(Convert.ToChar(strTheSeprator));
                                        //string[] sArrBarcode = txtDNHASUPKanbanBarcode.Text.Split(new char[] { Convert.ToChar(strTheSeprator) }, StringSplitOptions.RemoveEmptyEntries);
                                        if (startIndex == endIndex)
                                        {
                                            partNo = sArrBarcode[Convert.ToInt32(sepraterIndex)];
                                        }
                                        else
                                        {
                                            partNo = sArrBarcode[Convert.ToInt32(sepraterIndex)].Substring(startIndex, length);
                                        }
                                    }
                                    catch
                                    {
                                        partNo = "";

                                    }

                                }
                                else
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
                            }
                            else if (entry.keyValueData[i].Item1.Trim().ToUpper() == "QTY")
                            {
                                int number = 0;
                                if (strTheSeprator != "")
                                {
                                    try
                                    {
                                        string[] sArrBarcode = txtDNHASUPKanbanBarcode.Text.Split(Convert.ToChar(strTheSeprator));
                                        //string[] sArrBarcode = txtDNHASUPKanbanBarcode.Text.Split(new char[] { Convert.ToChar(strTheSeprator) }, StringSplitOptions.RemoveEmptyEntries);
                                        if (startIndex == endIndex)
                                        {
                                            int.TryParse(sArrBarcode[Convert.ToInt32(sepraterIndex)], out number);
                                        }
                                        else
                                        {
                                            int.TryParse(sArrBarcode[Convert.ToInt32(sepraterIndex)].Substring(startIndex, length), out number);

                                        }
                                        qty = number.ToString().Trim();
                                        iQrCode1Qty = _DnhaSupQty = number;
                                    }
                                    catch
                                    {
                                        qty = "";

                                    }

                                }
                                else
                                {
                                    try
                                    {

                                        int.TryParse(txtDNHASUPKanbanBarcode.Text.Trim().Substring(startIndex, length), out number);
                                        qty = number.ToString().Trim();
                                        iQrCode1Qty = _DnhaSupQty = number;
                                        isMatchQty = true;//Added by dipak 10-03-25
                                    }
                                    catch
                                    {
                                        qty = "";
                                    }
                                }

                            }
                            else if (entry.keyValueData[i].Item1.Trim().ToUpper() == "MFG")
                            {
                                DateTime? date;
                                if (strTheSeprator != "")
                                {
                                    try
                                    {
                                        string[] sArrBarcode = txtDNHASUPKanbanBarcode.Text.Split(Convert.ToChar(strTheSeprator));
                                        //string[] sArrBarcode = txtDNHASUPKanbanBarcode.Text.Split(new char[] { Convert.ToChar(strTheSeprator) }, StringSplitOptions.RemoveEmptyEntries);
                                        if (startIndex == endIndex)
                                        {
                                            mfg = sArrBarcode[Convert.ToInt32(sepraterIndex)];
                                        }
                                        else
                                        {
                                            mfg = sArrBarcode[Convert.ToInt32(sepraterIndex)].Substring(startIndex, length);
                                        }
                                        //if (date == null || date == DateTime.MinValue)
                                        //{
                                        //    mfg = "";
                                        //}
                                        //else
                                        //{
                                        //    mfg = date?.ToString("yyyy-MM-dd", CultureInfo.InvariantCulture).Trim();
                                        //}
                                    }
                                    catch
                                    {
                                        mfg = "";

                                    }

                                }
                                else
                                {
                                    try
                                    {

                                        //string[] formats = { "dd-MM-yyyy", "MM-dd-yyyy", "yyyy-MM-dd" };  // Add all possible formats

                                        //DateTime.TryParseExact(txtDNHASUPKanbanBarcode.Text.Trim().Substring(startIndex, length), formats, System.Globalization.CultureInfo.InvariantCulture, System.Globalization.DateTimeStyles.None, out date);
                                        //date = clsGlobal.ParseDate(txtDNHASUPKanbanBarcode.Text.Trim().Substring(startIndex, length));
                                        mfg = txtDNHASUPKanbanBarcode.Text.Trim().Substring(startIndex, length);
                                        //if (date == null || date == DateTime.MinValue)
                                        //{
                                        //    mfg = "";
                                        //}
                                        //else
                                        //{
                                        //    mfg = date?.ToString("yyyy-MM-dd", CultureInfo.InvariantCulture).Trim();
                                        //}

                                    }
                                    catch
                                    {
                                        mfg = "";
                                    }
                                }

                            }
                            else if (entry.keyValueData[i].Item1.Trim().ToUpper() == "EXP")
                            {
                                DateTime? date;
                                if (strTheSeprator != "")
                                {
                                    try
                                    {
                                        string[] sArrBarcode = txtDNHASUPKanbanBarcode.Text.Split(Convert.ToChar(strTheSeprator));
                                        //string[] sArrBarcode = txtDNHASUPKanbanBarcode.Text.Split(new char[] { Convert.ToChar(strTheSeprator) }, StringSplitOptions.RemoveEmptyEntries); 
                                        if (startIndex == endIndex)
                                        {
                                            //date = clsGlobal.ParseDate(sArrBarcode[Convert.ToInt32(sepraterIndex)]);
                                            exp = sArrBarcode[Convert.ToInt32(sepraterIndex)];
                                        }
                                        else
                                        {
                                            // date = clsGlobal.ParseDate(sArrBarcode[Convert.ToInt32(sepraterIndex)].Substring(startIndex, length));
                                            exp = sArrBarcode[Convert.ToInt32(sepraterIndex)].Substring(startIndex, length);
                                        }
                                        //Commented by dipak 27-06-25 for expiry control
                                        //if (date == null || date == DateTime.MinValue)
                                        //{
                                        //    exp = "";
                                        //}
                                        //else
                                        //{
                                        //    exp = date?.ToString("yyyy-MM-dd", CultureInfo.InvariantCulture).Trim();
                                        //}
                                    }
                                    catch
                                    {
                                        exp = "";

                                    }

                                }
                                else
                                {
                                    try
                                    {

                                        //DateTime.TryParse(txtDNHASUPKanbanBarcode.Text.Trim().Substring(startIndex, length), out date);
                                        //date = DateTime.ParseExact(txtDNHASUPKanbanBarcode.Text.Trim().Substring(startIndex, length), "MM/dd/yyyy hh:mm:ss tt", CultureInfo.InvariantCulture);
                                        //date = clsGlobal.ParseDate(txtDNHASUPKanbanBarcode.Text.Trim().Substring(startIndex, length));
                                        mfg = txtDNHASUPKanbanBarcode.Text.Trim().Substring(startIndex, length);
                                        //if (date == null || date == DateTime.MinValue)
                                        //{
                                        //    exp = "";
                                        //}
                                        //else
                                        //{

                                        //    exp = date?.ToString("yyyy-MM-dd", CultureInfo.InvariantCulture).Trim();
                                        //}
                                    }
                                    catch
                                    {
                                        exp = "";
                                    }
                                }

                            }
                            else if (entry.keyValueData[i].Item1.Trim().ToUpper() == "LOT")
                            {
                                if (strTheSeprator != "")
                                {
                                    try
                                    {
                                        string[] sArrBarcode = txtDNHASUPKanbanBarcode.Text.Split(Convert.ToChar(strTheSeprator));
                                        //string[] sArrBarcode = txtDNHASUPKanbanBarcode.Text.Split(new char[] { Convert.ToChar(strTheSeprator) }, StringSplitOptions.RemoveEmptyEntries);
                                        if (startIndex == endIndex)
                                        {
                                            lot = sArrBarcode[Convert.ToInt32(sepraterIndex)];
                                        }
                                        else
                                        {
                                            lot = sArrBarcode[Convert.ToInt32(sepraterIndex)].Substring(startIndex, length);
                                        }
                                    }
                                    catch
                                    {
                                        lot = "";

                                    }

                                }
                                else
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

                            }
                            else if (entry.keyValueData[i].Item1.Trim().ToUpper() == "LENGTH")
                            {
                                if (strTheSeprator != "")
                                {
                                    try
                                    {
                                        string[] sArrBarcode = txtDNHASUPKanbanBarcode.Text.Split(Convert.ToChar(strTheSeprator));
                                        //string[] sArrBarcode = txtDNHASUPKanbanBarcode.Text.Split(new char[] { Convert.ToChar(strTheSeprator) }, StringSplitOptions.RemoveEmptyEntries);
                                        if (startIndex == endIndex)
                                        {
                                            barcodeLength = sArrBarcode[Convert.ToInt32(sepraterIndex)];
                                        }
                                        else
                                        {
                                            barcodeLength = sArrBarcode[Convert.ToInt32(sepraterIndex)].Substring(startIndex, length);
                                        }
                                    }
                                    catch
                                    {
                                        barcodeLength = "";

                                    }

                                }
                                else
                                {
                                    try
                                    {


                                        barcodeLength = txtDNHASUPKanbanBarcode.Text.Trim().Substring(startIndex, length).Trim();


                                    }
                                    catch
                                    {
                                        barcodeLength = "";
                                    }
                                }

                            }
                            else if (entry.keyValueData[i].Item1.Trim().ToUpper() == "SEQNO")
                            {
                                string strSEQNo = "";
                                if (strTheSeprator != "")
                                {
                                    try
                                    {
                                        string[] sArrBarcode = txtDNHASUPKanbanBarcode.Text.Split(Convert.ToChar(strTheSeprator));
                                        //string[] sArrBarcode = txtDNHASUPKanbanBarcode.Text.Split(new char[] { Convert.ToChar(strTheSeprator) }, StringSplitOptions.RemoveEmptyEntries);
                                        if (startIndex == endIndex)
                                        {
                                            strSEQNo = sArrBarcode[Convert.ToInt32(sepraterIndex)];
                                        }
                                        else
                                        {
                                            strSEQNo = sArrBarcode[Convert.ToInt32(sepraterIndex)].Substring(startIndex, length);
                                        }
                                    }
                                    catch
                                    {
                                        strSEQNo = "";

                                    }

                                }
                                else
                                {
                                    try
                                    {


                                        strSEQNo = txtDNHASUPKanbanBarcode.Text.Trim().Substring(startIndex, length);

                                    }
                                    catch
                                    {
                                        strSEQNo = "";


                                    }
                                }
                                seqNo = clsGlobal.mDNHASupSeqNo = strSEQNo.ToString().Trim();
                                combinedKey = $"{partNo}^{seqNo}";
                                valueombinedBarcode1Key = combinedKey;
                                isMatchSeqNo = true;
                                isvalueMatchBarcode1SeqNo = true;

                            }

                            //CheckNGSuspectedLot

                            if (clsGlobal.mlistSuspectedLot.Exists(x => x.DNHAPartNo == partNo && x.LotNo == lot))
                            {
                                isMatchSuspectedLot = true;
                                isNGSuspectedLot = true;
                            }

                            //Check Barcode Length
                            if (clsGlobal.mlistSuspectedLot.Exists(x => x.DNHAPartNo == partNo) && barcodeLength != "")
                            {
                                isMatchBarcodeLength = true;
                                isBarcodeLength = true;
                                int iBarcodeLength = 0;
                                int.TryParse(barcodeLength, out iBarcodeLength);
                                if (txtDNHASUPKanbanBarcode.Text.Length != iBarcodeLength)
                                {
                                    if (i == 0)
                                    {
                                        goto NextForeachIteration;
                                    }
                                }
                            }
                            if (mfg != "")
                            {
                                mfgdate = null;
                                try
                                {
                                    List<PL_EXPIRY_CONTROL> listExpControlAlpha = clsGlobal.mlistExpiryControl.Where(x => x.PartNo == partNo && x.CigmaCode.TrimStart('0') == strCode && x.ProcessType == "ALPH-BASED-EXPIRY").ToList();
                                    if (listExpControlAlpha.Count > 0)
                                    {
                                        string? iRefDay = listExpControlAlpha[0].RefDay;
                                        string? iRefMonth = listExpControlAlpha[0].RefMonth;
                                        string? iRefYear = listExpControlAlpha[0].RefYear;
                                        string? sRefSeparator = listExpControlAlpha[0].RefSeparator;

                                        string? iActualDay = listExpControlAlpha[0].ActualDay;
                                        string? iActualMonth = listExpControlAlpha[0].ActualMonth;
                                        string? iActualYear = listExpControlAlpha[0].ActualYear;
                                        string? sActualSeparator = listExpControlAlpha[0].ActualSeparator;

                                        string sReffinalDate = $"{iRefYear}{sRefSeparator}{iRefMonth}{sRefSeparator}{iRefDay}";
                                        string sActualfinalDate = $"{iActualYear}{sActualSeparator}{iActualMonth}{sActualSeparator}{iActualDay}";

                                        if (sReffinalDate == mfg)
                                        {
                                            mfg = sActualfinalDate;
                                        }
                                    }
                                    List<PL_EXPIRY_CONTROL> listExpControlDate = clsGlobal.mlistExpiryControl.Where(x => x.PartNo == partNo && x.CigmaCode.TrimStart('0') == strCode && x.ProcessType == "DATE-BASED-EXPIRY").ToList();
                                    if (listExpControlDate.Count > 0)
                                    {
                                        string? iRefDay = listExpControlDate[0].RefDay;
                                        string? iRefMonth = listExpControlDate[0].RefMonth;
                                        string? iRefYear = listExpControlDate[0].RefYear;
                                        string? sRefSeparator = listExpControlDate[0].RefSeparator;

                                        string sReffinalFormat = $"{iRefYear}{sRefSeparator}{iRefMonth}{sRefSeparator}{iRefYear}";
                                        if (sReffinalFormat != null)
                                        {
                                            DateTime tempDate;
                                            if (DateTime.TryParseExact(mfg, sReffinalFormat, CultureInfo.InvariantCulture, DateTimeStyles.None, out tempDate))
                                            {
                                                mfgdate = tempDate; // mfgdate is DateTime?
                                            }
                                            else
                                            {
                                                mfgdate = null;
                                            }
                                        }
                                    }
                                }
                                catch
                                {


                                }

                                mfgdate = clsGlobal.ParseDate(mfg);
                                if (mfgdate == null || mfgdate == DateTime.MinValue)
                                {
                                    mfg = "";
                                }
                                else
                                {
                                    mfg = mfgdate?.ToString("yyyy-MM-dd", CultureInfo.InvariantCulture).Trim();
                                }
                            }
                            if (exp != "")
                            {
                                expdate = null;
                                try
                                {
                                    List<PL_EXPIRY_CONTROL> listExpControlAlpha = clsGlobal.mlistExpiryControl.Where(x => x.PartNo == partNo && x.CigmaCode.TrimStart('0') == strCode && x.ProcessType == "ALPH-BASED-EXPIRY").ToList();
                                    if (listExpControlAlpha.Count > 0)
                                    {
                                        string? iRefDay = listExpControlAlpha[0].RefDay;
                                        string? iRefMonth = listExpControlAlpha[0].RefMonth;
                                        string? iRefYear = listExpControlAlpha[0].RefYear;
                                        string? sRefSeparator = listExpControlAlpha[0].RefSeparator;

                                        string? iActualDay = listExpControlAlpha[0].ActualDay;
                                        string? iActualMonth = listExpControlAlpha[0].ActualMonth;
                                        string? iActualYear = listExpControlAlpha[0].ActualYear;
                                        string? sActualSeparator = listExpControlAlpha[0].ActualSeparator;

                                        string sReffinalDate = $"{iRefYear}{sRefSeparator}{iRefMonth}{sRefSeparator}{iRefDay}";
                                        string sActualfinalDate = $"{iActualYear}{sActualSeparator}{iActualMonth}{sActualSeparator}{iActualDay}";

                                        if (sReffinalDate == mfg)
                                        {
                                            exp = sActualfinalDate;
                                        }
                                    }
                                    List<PL_EXPIRY_CONTROL> listExpControlDate = clsGlobal.mlistExpiryControl.Where(x => x.PartNo == partNo && x.CigmaCode.TrimStart('0') == strCode && x.ProcessType == "DATE-BASED-EXPIRY").ToList();
                                    if (listExpControlDate.Count > 0)
                                    {
                                        string? iRefDay = listExpControlDate[0].RefDay;
                                        string? iRefMonth = listExpControlDate[0].RefMonth;
                                        string? iRefYear = listExpControlDate[0].RefYear;
                                        string? sRefSeparator = listExpControlDate[0].RefSeparator;

                                        string sReffinalFormat = $"{iRefYear}{sRefSeparator}{iRefMonth}{sRefSeparator}{iRefYear}";
                                        if (sReffinalFormat != null)
                                        {
                                            DateTime tempDate;
                                            if (DateTime.TryParseExact(exp, sReffinalFormat, CultureInfo.InvariantCulture, DateTimeStyles.None, out tempDate))
                                            {
                                                expdate = tempDate; // mfgdate is DateTime?
                                            }
                                            else
                                            {
                                                expdate = null;
                                            }
                                        }
                                    }
                                }
                                catch
                                {


                                }
                                expdate = clsGlobal.ParseDate(exp);
                                if (expdate == null || expdate == DateTime.MinValue)
                                {
                                    exp = "";
                                }
                                else
                                {
                                    exp = expdate?.ToString("yyyy-MM-dd", CultureInfo.InvariantCulture).Trim();
                                }
                            }

                            if (clsGlobal.mlistCustWiseExpiry.Exists(x => x.DNHAPartNo == partNo && x.CustomerCode.TrimStart('0') == strCode && x.IsMfgDate == true))
                            {
                                isMatchPart = true;
                                isMatchQty = true; //Commented by dipak 10-03-25
                                if (clsGlobal.mlistCustWiseExpiry.Exists(x => x.DNHAPartNo == partNo && x.CustomerCode.TrimStart('0') == strCode && x.IsMfgDate == true && mfg != ""))
                                {
                                    isMatchMFGDate = true;
                                    string strExpDays = clsGlobal.mlistCustWiseExpiry.Where(x => x.DNHAPartNo == partNo && x.CustomerCode.TrimStart('0') == strCode).Select(p => p.ExpDays).FirstOrDefault();
                                    string strShipDays = clsGlobal.mlistCustWiseExpiry.Where(x => x.DNHAPartNo == partNo && x.CustomerCode.TrimStart('0') == strCode).Select(p => p.MFGShipDays).FirstOrDefault();
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
                                            isProductMFGShippedDateCross = true;
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
                            else if (clsGlobal.mlistDNHA.Exists(x => x.DNHAPartNo == partNo && x.IsMfgDate == true))
                            {
                                isMatchPart = true;
                                isMatchQty = true; //Commented by dipak 10-03-25
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
                                            isProductMFGShippedDateCross = true;
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
                            else if (clsGlobal.mlistCustWiseExpiry.Exists(x => x.DNHAPartNo == partNo && x.CustomerCode.TrimStart('0') == strCode && x.IsExpDate == true && exp != ""))
                            {
                                isMatchPart = true;
                                isMatchQty = true; //Commented by dipak 10-03-25
                                isMatchExpiryDate = true;
                                bool atucalExp = clsGlobal.mlistCustWiseExpiry.Where(x => x.DNHAPartNo == partNo && x.CustomerCode.TrimStart('0') == strCode).Select(p => p.IsExpDate).FirstOrDefault();
                                string strExpShipDays = clsGlobal.mlistCustWiseExpiry.Where(x => x.DNHAPartNo == partNo && x.CustomerCode.TrimStart('0') == strCode).Select(p => p.EXPShipDays).FirstOrDefault();
                                int iExpShipDays = strExpShipDays == "" ? 0 : Convert.ToInt32(strExpShipDays);
                                if (atucalExp == true && (iExpShipDays == 0 || iExpShipDays == null))
                                {
                                    if (DateTime.TryParseExact(exp, "yyyy-MM-dd", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime expDate))
                                    {
                                        if (DateTime.Today > expDate)
                                        {
                                            isProductExpired = true;
                                            break;
                                        }
                                    }
                                }
                                else if (atucalExp == true && (iExpShipDays != 0 || iExpShipDays != null))
                                {

                                    if (DateTime.TryParseExact(exp, "yyyy-MM-dd", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime expDate))
                                    {
                                        if (DateTime.Today > expDate)
                                        {
                                            isProductExpired = true;
                                            break;
                                        }
                                        else if (DateTime.Today > expDate.AddDays(-iExpShipDays))
                                        {
                                            isProductEXPShippedDateCross = true;
                                            break;
                                        }

                                    }
                                }

                                //if (DateTime.Today > DateTime.ParseExact(exp, "yyyy-MM-dd", CultureInfo.DefaultThreadCurrentCulture).AddDays(-iExpShipDays))
                                //{
                                //    isProductExpired = true;
                                //    break;
                                //}
                            }
                            else if (clsGlobal.mlistDNHA.Exists(x => x.DNHAPartNo == partNo && x.IsExpDate == true && exp != ""))
                            {
                                isMatchPart = true;
                                isMatchQty = true; //Commented by dipak 10-03-25
                                isMatchExpiryDate = true;
                                bool atucalExp = clsGlobal.mlistDNHA.Where(x => x.DNHAPartNo == partNo).Select(p => p.IsExpDate).FirstOrDefault();
                                string strExpShipDays = clsGlobal.mlistDNHA.Where(x => x.DNHAPartNo == partNo).Select(p => p.EXPShipDays).FirstOrDefault();
                                int iExpShipDays = strExpShipDays == "" ? 0 : Convert.ToInt32(strExpShipDays);
                                if (atucalExp == true && (iExpShipDays == 0 || iExpShipDays == null))
                                {
                                    if (DateTime.TryParseExact(exp, "yyyy-MM-dd", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime expDate))
                                    {
                                        if (DateTime.Today > expDate)
                                        {
                                            isProductExpired = true;
                                            break;
                                        }
                                    }
                                }
                                else if (atucalExp == true && (iExpShipDays != 0 || iExpShipDays != null))
                                {

                                    if (DateTime.TryParseExact(exp, "yyyy-MM-dd", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime expDate))
                                    {
                                        if (DateTime.Today > expDate)
                                        {
                                            isProductExpired = true;
                                            break;
                                        }
                                        else if (DateTime.Today > expDate.AddDays(-iExpShipDays))
                                        {
                                            isProductEXPShippedDateCross = true;
                                            break;
                                        }

                                    }
                                }

                                //if (DateTime.Today > DateTime.ParseExact(exp, "yyyy-MM-dd", CultureInfo.DefaultThreadCurrentCulture).AddDays(-iExpShipDays))
                                //{
                                //    isProductExpired = true;
                                //    break;
                                //}
                            }
                            else
                            {
                                if (clsGlobal.mlistDNHA.Exists(x => x.DNHAPartNo == partNo) && _ListItem.Exists(p => p.PartNo == partNo)) //(Part should be exists in master file and also in listitem.)
                                {
                                    strDNHAPattern = entry.Patterns;
                                    isMatchPart = true;
                                    isMatchQty = true; //Commented by dipak 10-03-25
                                }
                                else //Added by dipak 27-02-2025
                                {
                                    if (i == 0)
                                    {
                                        goto NextForeachIteration;
                                    }
                                }

                            }
                            counter++;
                        }
                    NextForeachIteration:
                        continue;


                    }
                    if (!isMatchPart)
                    {
                        clsGlobal.showToastNGMessage("Invalid DNHA Kanban Barcode.", this);
                        txtDNHASUPKanbanBarcode.Text = "";
                        txtDNHASUPKanbanBarcode.RequestFocus();
                        clsGlobal.WriteLog("Invalid DNHA Kanban Barcode.");
                        SoundForNG();
                        ShowAlertPopUp();
                        return;
                    }
                    if (!isMatchQty) //Added by dipak 10-03-2025
                    {
                        clsGlobal.showToastNGMessage("Qty is required for DNHA Kanban Barcode.", this);
                        clsGlobal.WriteLog($"Qty is required for DNHA Kanban Barcode.");
                        txtDNHASUPKanbanBarcode.Text = "";
                        txtDNHASUPKanbanBarcode.RequestFocus();
                        SoundForNG();
                        ShowAlertPopUp();
                        return;
                    }
                    if (!_ListItem.Exists(p => p.PartNo == partNo))
                    {
                        clsGlobal.showToastNGMessage($"Part No. {partNo} isn't available in SIL List! ", this);
                        clsGlobal.WriteLog($"Part No. {partNo} isn't available in SIL List! ");
                        txtDNHASUPKanbanBarcode.Text = "";
                        txtDNHASUPKanbanBarcode.RequestFocus();
                        SoundForNG();
                        ShowAlertPopUp();
                        return;

                    }
                    if (isNGSuspectedLot)
                    {
                        clsGlobal.showToastNGMessage($"This product Lot {lot} is suspected {partNo},Scanned valid product", this);
                        clsGlobal.WriteLog($"This product Lot {lot} is suspected {partNo},Scanned valid product");
                        txtDNHASUPKanbanBarcode.Text = "";
                        txtDNHASUPKanbanBarcode.RequestFocus();
                        SoundForNG();
                        ShowAlertPopUp();
                        return;
                    }
                    if (clsGlobal.mlistDNHA.Exists(x => x.DNHAPartNo == partNo && (x.IsExpDate == true) && isMatchExpiryDate == false))
                    {
                        clsGlobal.showToastNGMessage($"This product is registered with expiary check {partNo},Scanned valid product or check pattern", this);
                        clsGlobal.WriteLog($"This product is registered with expiary check {partNo},Scanned valid product or check pattern");
                        txtDNHASUPKanbanBarcode.Text = "";
                        txtDNHASUPKanbanBarcode.RequestFocus();
                        SoundForNG();
                        ShowAlertPopUp();
                        return;
                    }
                    if (clsGlobal.mlistDNHA.Exists(x => x.DNHAPartNo == partNo && (x.IsMfgDate == true) && isMatchMFGDate == false))
                    {
                        clsGlobal.showToastNGMessage($"This product is registered with manufacturing check {partNo},Scanned valid product or check pattern", this);
                        clsGlobal.WriteLog($"This product is registered with manufacturing check {partNo},Scanned valid product or check pattern");
                        txtDNHASUPKanbanBarcode.Text = "";
                        txtDNHASUPKanbanBarcode.RequestFocus();
                        SoundForNG();
                        ShowAlertPopUp();
                        return;
                    }
                    if (isProductMFGShippedDateCross)
                    {
                        clsGlobal.showToastNGMessage($"This product is MFG Shipping date over {partNo},Scanned valid product", this);
                        clsGlobal.WriteLog($"This product is MFG Shipping date over {partNo},Scanned valid product");
                        txtDNHASUPKanbanBarcode.Text = "";
                        txtDNHASUPKanbanBarcode.RequestFocus();
                        SoundForNG();
                        ShowAlertPopUp();
                        return;
                    }
                    if (isProductEXPShippedDateCross)
                    {
                        clsGlobal.showToastNGMessage($"This product is EXP Shipping date over {partNo},Scanned valid product", this);
                        clsGlobal.WriteLog($"This product is EXP Shipping date over {partNo},Scanned valid product");
                        txtDNHASUPKanbanBarcode.Text = "";
                        txtDNHASUPKanbanBarcode.RequestFocus();
                        SoundForNG();
                        ShowAlertPopUp();
                        return;
                    }
                    if (isProductExpired)
                    {
                        clsGlobal.showToastNGMessage($"This product is Expired {partNo},Scanned valid product", this);
                        clsGlobal.WriteLog($"This product is Expired {partNo},Scanned valid product");
                        txtDNHASUPKanbanBarcode.Text = "";
                        txtDNHASUPKanbanBarcode.RequestFocus();
                        SoundForNG();
                        ShowAlertPopUp();
                        return;
                    }


                    if (!clsGlobal.mlistDNHA.Exists(p => p.DNHAPartNo == partNo))
                    {
                        clsGlobal.showToastNGMessage($"Scanned Part {partNo} isn't available in main master list! ", this);
                        clsGlobal.WriteLog($"Scanned Part {partNo} isn't available in main master list!");
                        txtDNHASUPKanbanBarcode.Text = "";
                        txtDNHASUPKanbanBarcode.RequestFocus();
                        SoundForNG();
                        ShowAlertPopUp();
                        return;

                    }
                    if (string.IsNullOrEmpty(qty))
                    {
                        clsGlobal.showToastNGMessage($"Qty is not available! ", this);
                        clsGlobal.WriteLog($"Qty is not available! ");
                        txtDNHASUPKanbanBarcode.Text = "";
                        txtDNHASUPKanbanBarcode.RequestFocus();
                        SoundForNG();
                        ShowAlertPopUp();
                        return;

                    }
                    if (_ListItem.Exists(p => Convert.ToInt32(p.Balance) == 0 && p.PartNo == partNo))
                    {
                        clsGlobal.showToastNGMessage($"This Part No {partNo} Scanning Completed! ", this);
                        clsGlobal.WriteLog($"This Part No {partNo} Scanning Completed! ");
                        txtDNHASUPKanbanBarcode.Text = "";
                        txtDNHASUPKanbanBarcode.RequestFocus();
                        SoundForNG();
                        ShowAlertPopUp();
                        return;

                    }
                    if (_ListItem.Exists(p => Convert.ToInt32(qty) > Convert.ToInt32(p.Balance) && p.PartNo == partNo))
                    {
                        clsGlobal.showToastNGMessage($"Scanned Barcode Qty {qty} should be not be greater then SIL Part Qty! ", this);
                        clsGlobal.WriteLog($"Scanned Barcode Qty {qty} should be not be greater then SIL Part Qty! ");
                        txtDNHASUPKanbanBarcode.Text = "";
                        txtDNHASUPKanbanBarcode.RequestFocus();
                        SoundForNG();
                        ShowAlertPopUp();
                        return;

                    }
                    if (isMatchBarcodeLength)
                    {
                        if (txtDNHASUPKanbanBarcode.Text.Length != int.Parse(barcodeLength))
                        {
                            clsGlobal.showToastNGMessage($"Scanned Barcode Length is {txtDNHASUPKanbanBarcode.Text.Length}  and pattern barcode length is {barcodeLength} ! ", this);
                            clsGlobal.WriteLog($"Scanned Barcode Length is {txtDNHASUPKanbanBarcode.Text.Length}  and pattern barcode length is {barcodeLength} ! ");
                            txtDNHASUPKanbanBarcode.Text = "";
                            txtDNHASUPKanbanBarcode.RequestFocus();
                            SoundForNG();
                            ShowAlertPopUp();
                            return;
                        }
                    }
                    if (isMatchSeqNo)
                    {
                        if (_dicBarcode1.ContainsKey(combinedKey.Trim()))
                        {
                            clsGlobal.showToastNGMessage($"DNHA Barcode {txtDNHASUPKanbanBarcode.Text.Trim()} Already Exist!!", this);
                            clsGlobal.WriteLog($"DNHA Barcode {txtDNHASUPKanbanBarcode.Text.Trim()} Already Exist!!");
                            txtDNHASUPKanbanBarcode.Text = "";
                            txtDNHASUPKanbanBarcode.RequestFocus();
                            SoundForNG();
                            ShowAlertPopUp();
                            return;
                        }
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
                        if (partNo != PartNo)
                        {
                            PartNo = partNo;
                        }
                        if (Qty != qty)
                        {
                            Qty = qty;
                        }
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
                        WriteDeatilsFile($"{_strSILBarCode.Trim()}~{clsGlobal.ReplaceNewlinesWithCaret(txtDNHASUPKanbanBarcode.Text.Trim())}~{clsGlobal.ReplaceNewlinesWithCaret(txtCustKanbanBarcode.Text.Trim())}" +
                            $"~{PartNo}~{CustPart}~{Qty}~{"0"}~{ProcessCode}~{TruckNo}~{ShipTo}~{CustCode}~{SequenceNo}~{clsGlobal.mCustSeqNo}~{clsGlobal.mUserId}" +
                            $"~{SILScannedON}~{DNHAScannedOn}~{CustScannedOn}~{strDNHAPattern}~{isvalueMatchBarcode1SeqNo}~{valueombinedBarcode1Key}~{isvalueMatchBarcode2SeqNo}~{valueombinedBarcode2Key}");
                        valueombinedBarcode1Key = "";
                        valueombinedBarcode2Key = "";
                        isvalueMatchBarcode1SeqNo = false;
                        isvalueMatchBarcode2SeqNo = false;
                        if (isMatchSeqNo)
                        {
                            _dicBarcode1.Add(combinedKey, combinedKey);
                        }
                        if (_TotalQty == _ScanQty)
                        {
                            WriteSILCompltedFile(TruckNo);
                            clsGlobal.showToastOKMessage($"SIL No. {TruckNo} Completed! ", this);
                            txtDNHASUPKanbanBarcode.Text = "";
                            txtDNHASUPKanbanBarcode.RequestFocus();
                            clear();
                            BindSpinnerRegisteredSIL();
                        }
                        txtDNHASUPKanbanBarcode.Text = "";
                        SoundForOKVibrate();
                    }
                    else
                    {
                        strDNHAPartNo = partNo;
                        if (isMatchSeqNo)
                        {
                            _dicBarcode1.Add(combinedKey.Trim(), combinedKey.Trim());
                        }
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
        private void ScanningSUPKanbanBarcode()
        {
            try
            {
                if (ValidateSupplierControls())
                {
                    //if (_dicBarcode1.ContainsKey(txtDNHASUPKanbanBarcode.Text.Trim()))
                    //{

                    //    clsGlobal.showToastNGMessage($"Supplier Barcode {txtDNHASUPKanbanBarcode.Text.Trim()} Already Exist!!", this);
                    //    txtDNHASUPKanbanBarcode.Text = "";
                    //    txtDNHASUPKanbanBarcode.RequestFocus();
                    //    SoundForNG();
                    //    ShowAlertPopUp();
                    //    return;
                    //}
                    strDNHAPartNo = "";
                    _DnhaSupQty = 0;
                    string partNo = string.Empty;
                    string qty = "0";
                    int counter = 0;
                    string dnhaPartNo = "";
                    bool isMatchPart = false;
                    string dnhaPartQty = string.Empty;
                    string mfg = "";
                    string exp = "";
                    string lot = "";
                    string seqNo = "";
                    string barcodeLength = "";
                    string combinedKey = "";
                    bool isMatchSeqNo = false;
                    bool isMatchMFGDate = false;
                    bool isMatchExpiryDate = false;
                    bool isMatchQty = false;
                    bool isMatchSuspectedLot = false;
                    bool isMatchBarcodeLength = false;
                    bool isProductExpired = false;
                    bool isProductMFGShippedDateCross = false;
                    bool isProductEXPShippedDateCross = false;
                    bool isNGSuspectedLot = false;
                    bool isBarcodeLength = false;
                    DateTime? mfgdate = null;
                    DateTime? expdate = null;
                    //var maxEntry = clsGlobal.mlistSupplierPattern
                    //                     .OrderByDescending(entry => entry.keyValueData.Count);
                    string strCode = Convert.ToInt32(clsGlobal.mCustomerCode).ToString();
                    var maxEntry = clsGlobal.mlistSupplierPattern.Where(x => x.Code.TrimStart('0') == strCode).Select(x => x).ToList();
                    if (maxEntry.Count == 0)
                    {
                        clsGlobal.showToastNGMessage($"Supplier Barcode {txtCustKanbanBarcode.Text.Trim()} Pattern Code Not Matched!!", this);
                        txtCustKanbanBarcode.Text = "";
                        txtCustKanbanBarcode.RequestFocus();
                        SoundForNG();
                        ShowAlertPopUp();
                        return;
                    }
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
                        else if ((isMatchPart && isMatchQty) && !isMatchMFGDate && !isMatchExpiryDate && !isMatchSuspectedLot)
                        {
                            break;
                        }
                        else
                        {
                            //Added by dipak 27-02-25 
                            isMatchPart = false; isMatchQty = false; isMatchMFGDate = false; isMatchExpiryDate = false; isMatchSeqNo = false; isMatchSuspectedLot = false;
                            isBarcodeLength = false; isMatchBarcodeLength = false;
                        }

                        // Step 4: Iterate through the hashtable inside the dictionary
                        for (int i = 0; i < entry.keyValueData.Count; i++)
                        {
                            // Get the start and end indexes from the keyValueData entry
                            int startIndex = Convert.ToInt32(entry.keyValueData[i].Item2.ToString().Split('-')[0]);
                            int endIndex = Convert.ToInt32(entry.keyValueData[i].Item2.ToString().Split('-')[1]);
                            string sepraterIndex = Convert.ToString(entry.keyValueData[i].Item2.ToString().Split('-')[2]);
                            string strTheSeprator = Convert.ToString(entry.Seperater);

                            // Extract the part number or quantity based on the current counter
                            int length = endIndex - startIndex;
                            if (entry.keyValueData[i].Item1.Trim().ToUpper() == "SUPPLIERPARTNO")
                            {
                                if (strTheSeprator != "")
                                {
                                    try
                                    {
                                        string[] sArrBarcode = txtDNHASUPKanbanBarcode.Text.Split(Convert.ToChar(strTheSeprator));
                                        //string[] sArrBarcode = txtDNHASUPKanbanBarcode.Text.Split(new char[] { Convert.ToChar(strTheSeprator) }, StringSplitOptions.RemoveEmptyEntries);
                                        if (startIndex == endIndex)
                                        {
                                            partNo = sArrBarcode[Convert.ToInt32(sepraterIndex)];
                                        }
                                        else
                                        {
                                            partNo = sArrBarcode[Convert.ToInt32(sepraterIndex)].Substring(startIndex, length);
                                        }
                                    }
                                    catch
                                    {
                                        partNo = "";

                                    }

                                }
                                else
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
                                if (clsGlobal.mlistSupplier.Exists(x => (x.DNHAPartNo == partNo || x.SupplierPartNo == partNo)))
                                {
                                    dnhaPartNo = clsGlobal.mlistSupplier.Where(x => (x.DNHAPartNo == partNo || x.SupplierPartNo == partNo)).Select(x => x.DNHAPartNo).First();
                                    if (clsGlobal.mlistSupplier.Any(x => (x.DNHAPartNo == partNo || x.SupplierPartNo == partNo) && !string.IsNullOrWhiteSpace(x.LotQty)))
                                    {
                                        int number = 0;
                                        int.TryParse(clsGlobal.mlistSupplier.Where(x => (x.DNHAPartNo == partNo || x.SupplierPartNo == partNo)).Select(x => x.LotQty).First(), out number);
                                        qty = number.ToString();
                                        iQrCode1Qty = _DnhaSupQty = number;
                                        if (iQrCode1Qty > 0)
                                            isMatchQty = true;
                                    }
                                }
                                else //Added by dipak 27-02-2025
                                {
                                    if (i == 0)
                                    {
                                        goto NextForeachIteration;
                                    }
                                }

                                //Commentd By Dipak 27-02-2025
                                //try
                                //{
                                //dnhaPartNo = clsGlobal.mlistSupplier.Where(x => (x.DNHAPartNo == partNo || x.SupplierPartNo == partNo)).Select(x => x.DNHAPartNo).First();
                                //}
                                //catch
                                //{
                                //    clsGlobal.showToastNGMessage($"Invalid Scanned Barcode! ", this);
                                //    txtDNHASUPKanbanBarcode.Text = "";
                                //    txtDNHASUPKanbanBarcode.RequestFocus();
                                //    SoundForNG();
                                //    ShowAlertPopUp();
                                //    return;

                                //}


                            }
                            else if (entry.keyValueData[i].Item1.Trim().ToUpper() == "QTY")
                            {
                                int number = 0;
                                if (strTheSeprator != "")
                                {
                                    try
                                    {
                                        string[] sArrBarcode = txtDNHASUPKanbanBarcode.Text.Split(Convert.ToChar(strTheSeprator));
                                        //string[] sArrBarcode = txtDNHASUPKanbanBarcode.Text.Split(new char[] { Convert.ToChar(strTheSeprator) }, StringSplitOptions.RemoveEmptyEntries);
                                        if (startIndex == endIndex)
                                        {
                                            int.TryParse(sArrBarcode[Convert.ToInt32(sepraterIndex)], out number);
                                        }
                                        else
                                        {
                                            int.TryParse(sArrBarcode[Convert.ToInt32(sepraterIndex)].Substring(startIndex, length), out number);

                                        }
                                        qty = number.ToString();
                                        iQrCode1Qty = _DnhaSupQty = number;
                                        if (iQrCode1Qty > 0)
                                            isMatchQty = true;
                                    }
                                    catch
                                    {
                                        qty = "";

                                    }

                                }
                                else
                                {
                                    try
                                    {

                                        int.TryParse(txtDNHASUPKanbanBarcode.Text.Trim().Substring(startIndex, length).Trim(), out number);
                                        qty = number.ToString();
                                        iQrCode1Qty = _DnhaSupQty = number;
                                        if (iQrCode1Qty > 0)
                                            isMatchQty = true;
                                    }
                                    catch
                                    {

                                        qty = "";
                                    }
                                }

                            }
                            else if (entry.keyValueData[i].Item1.Trim().ToUpper() == "MFG")
                            {
                                DateTime? date;
                                if (strTheSeprator != "")
                                {
                                    try
                                    {
                                        string[] sArrBarcode = txtDNHASUPKanbanBarcode.Text.Split(Convert.ToChar(strTheSeprator));
                                        //string[] sArrBarcode = txtDNHASUPKanbanBarcode.Text.Split(new char[] { Convert.ToChar(strTheSeprator) }, StringSplitOptions.RemoveEmptyEntries);
                                        if (startIndex == endIndex)
                                        {
                                            //date = clsGlobal.ParseDate(sArrBarcode[Convert.ToInt32(sepraterIndex)]);
                                            mfg = sArrBarcode[Convert.ToInt32(sepraterIndex)];
                                        }
                                        else
                                        {
                                            // date = clsGlobal.ParseDate(sArrBarcode[Convert.ToInt32(sepraterIndex)].Substring(startIndex, length));
                                            mfg = sArrBarcode[Convert.ToInt32(sepraterIndex)].Substring(startIndex, length);
                                        }
                                        //if (date == null || date == DateTime.MinValue)
                                        //{
                                        //    mfg = "";
                                        //}
                                        //else
                                        //{
                                        //    mfg = date?.ToString("yyyy-MM-dd", CultureInfo.InvariantCulture).Trim();
                                        //}
                                    }
                                    catch
                                    {
                                        mfg = "";

                                    }

                                }
                                else
                                {
                                    try
                                    {


                                        // date = clsGlobal.ParseDate(txtDNHASUPKanbanBarcode.Text.Trim().Substring(startIndex, length).Trim());
                                        mfg = txtDNHASUPKanbanBarcode.Text.Trim().Substring(startIndex, length).Trim();
                                        //if (date == null || date == DateTime.MinValue)
                                        //{
                                        //    mfg = "";
                                        //}
                                        //else
                                        //{
                                        //    mfg = date?.ToString("yyyy-MM-dd", CultureInfo.InvariantCulture).Trim();
                                        //}

                                    }
                                    catch
                                    {
                                        mfg = "";
                                    }
                                }

                            }
                            else if (entry.keyValueData[i].Item1.Trim().ToUpper() == "EXP")
                            {
                                DateTime? date;
                                if (strTheSeprator != "")
                                {
                                    try
                                    {
                                        string[] sArrBarcode = txtDNHASUPKanbanBarcode.Text.Split(Convert.ToChar(strTheSeprator));
                                        if (startIndex == endIndex)
                                        {
                                            // date = clsGlobal.ParseDate(sArrBarcode[Convert.ToInt32(sepraterIndex)]);
                                            exp = sArrBarcode[Convert.ToInt32(sepraterIndex)];
                                        }
                                        else
                                        {
                                            // date = clsGlobal.ParseDate(sArrBarcode[Convert.ToInt32(sepraterIndex)].Substring(startIndex, length));
                                            exp = sArrBarcode[Convert.ToInt32(sepraterIndex)].Substring(startIndex, length);
                                        }
                                        //if (date == null || date == DateTime.MinValue)
                                        //{
                                        //    exp = "";
                                        //}
                                        //else
                                        //{
                                        //    exp = date?.ToString("yyyy-MM-dd", CultureInfo.InvariantCulture).Trim();
                                        //}
                                    }
                                    catch
                                    {
                                        exp = "";

                                    }

                                }
                                else
                                {
                                    try
                                    {


                                        //date = clsGlobal.ParseDate(txtDNHASUPKanbanBarcode.Text.Trim().Substring(startIndex, length).Trim());

                                        exp = txtDNHASUPKanbanBarcode.Text.Trim().Substring(startIndex, length).Trim();

                                        //if (date == null || date == DateTime.MinValue)
                                        //{
                                        //    exp = "";
                                        //}
                                        //else
                                        //{

                                        //    exp = date?.ToString("yyyy-MM-dd", CultureInfo.InvariantCulture).Trim();
                                        //}
                                    }
                                    catch
                                    {
                                        exp = "";
                                    }
                                }

                            }
                            else if (entry.keyValueData[i].Item1.Trim().ToUpper() == "LOT")
                            {
                                if (strTheSeprator != "")
                                {
                                    try
                                    {
                                        string[] sArrBarcode = txtDNHASUPKanbanBarcode.Text.Split(Convert.ToChar(strTheSeprator));
                                        //string[] sArrBarcode = txtDNHASUPKanbanBarcode.Text.Split(new char[] { Convert.ToChar(strTheSeprator) }, StringSplitOptions.RemoveEmptyEntries);
                                        if (startIndex == endIndex)
                                        {
                                            lot = sArrBarcode[Convert.ToInt32(sepraterIndex)];
                                        }
                                        else
                                        {
                                            lot = sArrBarcode[Convert.ToInt32(sepraterIndex)].Substring(startIndex, length);
                                        }
                                    }
                                    catch
                                    {
                                        lot = "";

                                    }

                                }
                                else
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
                            }
                            else if (entry.keyValueData[i].Item1.Trim().ToUpper() == "LENGTH")
                            {
                                if (strTheSeprator != "")
                                {
                                    try
                                    {
                                        string[] sArrBarcode = txtDNHASUPKanbanBarcode.Text.Split(Convert.ToChar(strTheSeprator));
                                        //string[] sArrBarcode = txtDNHASUPKanbanBarcode.Text.Split(new char[] { Convert.ToChar(strTheSeprator) }, StringSplitOptions.RemoveEmptyEntries);
                                        if (startIndex == endIndex)
                                        {
                                            barcodeLength = sArrBarcode[Convert.ToInt32(sepraterIndex)];
                                        }
                                        else
                                        {
                                            barcodeLength = sArrBarcode[Convert.ToInt32(sepraterIndex)].Substring(startIndex, length);
                                        }
                                    }
                                    catch
                                    {
                                        barcodeLength = "";

                                    }

                                }
                                else
                                {
                                    try
                                    {


                                        barcodeLength = txtDNHASUPKanbanBarcode.Text.Trim().Substring(startIndex, length).Trim();


                                    }
                                    catch
                                    {
                                        barcodeLength = "";
                                    }
                                }

                            }
                            else if (entry.keyValueData[i].Item1.Trim().ToUpper() == "SEQNO")
                            {
                                string strSEQNo = "";
                                if (strTheSeprator != "")
                                {
                                    try
                                    {
                                        string[] sArrBarcode = txtDNHASUPKanbanBarcode.Text.Split(Convert.ToChar(strTheSeprator));
                                        //string[] sArrBarcode = txtDNHASUPKanbanBarcode.Text.Split(new char[] { Convert.ToChar(strTheSeprator) }, StringSplitOptions.RemoveEmptyEntries);
                                        if (startIndex == endIndex)
                                        {
                                            strSEQNo = sArrBarcode[Convert.ToInt32(sepraterIndex)];
                                        }
                                        else
                                        {
                                            strSEQNo = sArrBarcode[Convert.ToInt32(sepraterIndex)].Substring(startIndex, length);
                                        }

                                    }
                                    catch
                                    {
                                        strSEQNo = "";

                                    }

                                }
                                else
                                {
                                    try
                                    {

                                        strSEQNo = txtDNHASUPKanbanBarcode.Text.Trim().Substring(startIndex, length);

                                    }
                                    catch
                                    {
                                        strSEQNo = "0";


                                    }
                                }

                                seqNo = clsGlobal.mDNHASupSeqNo = strSEQNo.ToString().Trim().Replace("\n", "").Replace("\r", "").Trim();
                                combinedKey = $"{partNo}^{seqNo}";
                                isvalueMatchBarcode1SeqNo = true;
                                valueombinedBarcode1Key = combinedKey;
                                isMatchSeqNo = true;
                            }

                            //Check Suspected Lot
                            if (clsGlobal.mlistSuspectedLot.Exists(x => x.DNHAPartNo == dnhaPartNo && x.LotNo == lot))
                            {
                                isMatchSuspectedLot = true;
                                isNGSuspectedLot = true;
                            }
                            ///Check Barcode length 
                            if (clsGlobal.mlistSupplier.Exists(x => (x.DNHAPartNo == dnhaPartNo || x.SupplierPartNo == partNo) && barcodeLength != ""))
                            {
                                isBarcodeLength = true;
                                isMatchBarcodeLength = true;
                                int iBarcodeLength = 0;
                                int.TryParse(barcodeLength, out iBarcodeLength);
                                if (txtDNHASUPKanbanBarcode.Text.Length != iBarcodeLength)
                                {
                                    if (i == 0)
                                    {
                                        goto NextForeachIteration;
                                    }
                                }
                            }
                            if (mfg != "")
                            {
                                mfgdate = null;
                                try
                                {
                                    List<PL_EXPIRY_CONTROL> listExpControlAlpha = clsGlobal.mlistExpiryControl.Where(x => x.PartNo == partNo && x.CigmaCode.TrimStart('0') == strCode && x.ProcessType == "ALPH-BASED-EXPIRY").ToList();
                                    if (listExpControlAlpha.Count > 0)
                                    {
                                        string? iRefDay = listExpControlAlpha[0].RefDay;
                                        string? iRefMonth = listExpControlAlpha[0].RefMonth;
                                        string? iRefYear = listExpControlAlpha[0].RefYear;
                                        string? sRefSeparator = listExpControlAlpha[0].RefSeparator;

                                        string? iActualDay = listExpControlAlpha[0].ActualDay;
                                        string? iActualMonth = listExpControlAlpha[0].ActualMonth;
                                        string? iActualYear = listExpControlAlpha[0].ActualYear;
                                        string? sActualSeparator = listExpControlAlpha[0].ActualSeparator;

                                        string sReffinalDate = $"{iRefYear}{sRefSeparator}{iRefMonth}{sRefSeparator}{iRefDay}";
                                        string sActualfinalDate = $"{iActualYear}{sActualSeparator}{iActualMonth}{sActualSeparator}{iActualDay}";

                                        if (sReffinalDate == mfg)
                                        {
                                            mfg = sActualfinalDate;
                                        }
                                    }
                                    List<PL_EXPIRY_CONTROL> listExpControlDate = clsGlobal.mlistExpiryControl.Where(x => x.PartNo == partNo && x.CigmaCode.TrimStart('0') == strCode && x.ProcessType == "DATE-BASED-EXPIRY").ToList();
                                    if (listExpControlDate.Count > 0)
                                    {
                                        string? iRefDay = listExpControlDate[0].RefDay;
                                        string? iRefMonth = listExpControlDate[0].RefMonth;
                                        string? iRefYear = listExpControlDate[0].RefYear;
                                        string? sRefSeparator = listExpControlDate[0].RefSeparator;

                                        string sReffinalFormat = $"{iRefYear}{sRefSeparator}{iRefMonth}{sRefSeparator}{iRefYear}";
                                        if (sReffinalFormat != null)
                                        {
                                            DateTime tempDate;
                                            if (DateTime.TryParseExact(mfg, sReffinalFormat, CultureInfo.InvariantCulture, DateTimeStyles.None, out tempDate))
                                            {
                                                mfgdate = tempDate; // mfgdate is DateTime?
                                            }
                                            else
                                            {
                                                mfgdate = null;
                                            }
                                        }
                                    }
                                }
                                catch
                                {


                                }

                                mfgdate = clsGlobal.ParseDate(mfg);
                                if (mfgdate == null || mfgdate == DateTime.MinValue)
                                {
                                    mfg = "";
                                }
                                else
                                {
                                    mfg = mfgdate?.ToString("yyyy-MM-dd", CultureInfo.InvariantCulture).Trim();
                                }
                            }
                            if (exp != "")
                            {
                                expdate = null;
                                try
                                {
                                    List<PL_EXPIRY_CONTROL> listExpControlAlpha = clsGlobal.mlistExpiryControl.Where(x => x.PartNo == partNo && x.CigmaCode.TrimStart('0') == strCode && x.ProcessType == "ALPH-BASED-EXPIRY").ToList();
                                    if (listExpControlAlpha.Count > 0)
                                    {
                                        string? iRefDay = listExpControlAlpha[0].RefDay;
                                        string? iRefMonth = listExpControlAlpha[0].RefMonth;
                                        string? iRefYear = listExpControlAlpha[0].RefYear;
                                        string? sRefSeparator = listExpControlAlpha[0].RefSeparator;

                                        string? iActualDay = listExpControlAlpha[0].ActualDay;
                                        string? iActualMonth = listExpControlAlpha[0].ActualMonth;
                                        string? iActualYear = listExpControlAlpha[0].ActualYear;
                                        string? sActualSeparator = listExpControlAlpha[0].ActualSeparator;

                                        string sReffinalDate = $"{iRefYear}{sRefSeparator}{iRefMonth}{sRefSeparator}{iRefDay}";
                                        string sActualfinalDate = $"{iActualYear}{sActualSeparator}{iActualMonth}{sActualSeparator}{iActualDay}";

                                        if (sReffinalDate == mfg)
                                        {
                                            exp = sActualfinalDate;
                                        }
                                    }
                                    List<PL_EXPIRY_CONTROL> listExpControlDate = clsGlobal.mlistExpiryControl.Where(x => x.PartNo == partNo && x.CigmaCode.TrimStart('0') == strCode && x.ProcessType == "DATE-BASED-EXPIRY").ToList();
                                    if (listExpControlDate.Count > 0)
                                    {
                                        string? iRefDay = listExpControlDate[0].RefDay;
                                        string? iRefMonth = listExpControlDate[0].RefMonth;
                                        string? iRefYear = listExpControlDate[0].RefYear;
                                        string? sRefSeparator = listExpControlDate[0].RefSeparator;

                                        string sReffinalFormat = $"{iRefYear}{sRefSeparator}{iRefMonth}{sRefSeparator}{iRefYear}";
                                        if (sReffinalFormat != null)
                                        {
                                            DateTime tempDate;
                                            if (DateTime.TryParseExact(exp, sReffinalFormat, CultureInfo.InvariantCulture, DateTimeStyles.None, out tempDate))
                                            {
                                                expdate = tempDate; // mfgdate is DateTime?
                                            }
                                            else
                                            {
                                                expdate = null;
                                            }
                                        }
                                    }
                                }
                                catch
                                {


                                }
                                expdate = clsGlobal.ParseDate(exp);
                                if (expdate == null || expdate == DateTime.MinValue)
                                {
                                    exp = "";
                                }
                                else
                                {
                                    exp = expdate?.ToString("yyyy-MM-dd", CultureInfo.InvariantCulture).Trim();
                                }
                            }
                            if (clsGlobal.mlistCustWiseExpiry.Exists(x => (x.DNHAPartNo == dnhaPartNo && x.CustomerCode.TrimStart('0') == strCode) && x.IsMfgDate == true))
                            {
                                isMatchPart = true;
                                //isMatchQty = true; //Commented by dipak 10-03-25
                                isMatchMFGDate = true;
                                strDNHAPartNo = clsGlobal.mlistCustWiseExpiry.Where(x => (x.DNHAPartNo == dnhaPartNo && x.CustomerCode.TrimStart('0') == strCode)).Select(p => p.DNHAPartNo).FirstOrDefault();
                                if (clsGlobal.mlistCustWiseExpiry.Exists(x => (x.DNHAPartNo == dnhaPartNo && x.CustomerCode.TrimStart('0') == strCode) && x.IsMfgDate == true && mfg != ""))
                                {
                                    string strExpDays = clsGlobal.mlistCustWiseExpiry.Where(x => (x.DNHAPartNo == dnhaPartNo && x.CustomerCode.TrimStart('0') == strCode)).Select(p => p.ExpDays).FirstOrDefault();
                                    string strShipDays = clsGlobal.mlistCustWiseExpiry.Where(x => (x.DNHAPartNo == dnhaPartNo && x.CustomerCode.TrimStart('0') == strCode)).Select(p => p.MFGShipDays).FirstOrDefault();
                                    if (strExpDays != null && strExpDays == null)
                                    {
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
                                            isProductMFGShippedDateCross = true;
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
                            else if (clsGlobal.mlistSupplier.Exists(x => (x.DNHAPartNo == dnhaPartNo || x.SupplierPartNo == partNo) && x.IsMfgDate == true))
                            {
                                isMatchPart = true;
                                //isMatchQty = true; //Commented by dipak 10-03-25
                                isMatchMFGDate = true;
                                strDNHAPartNo = clsGlobal.mlistSupplier.Where(x => (x.DNHAPartNo == dnhaPartNo || x.SupplierPartNo == partNo)).Select(p => p.DNHAPartNo).FirstOrDefault();
                                if (clsGlobal.mlistSupplier.Exists(x => (x.DNHAPartNo == dnhaPartNo || x.SupplierPartNo == partNo) && x.IsMfgDate == true && mfg != ""))
                                {
                                    string strExpDays = clsGlobal.mlistSupplier.Where(x => (x.DNHAPartNo == dnhaPartNo || x.SupplierPartNo == partNo)).Select(p => p.ExpDays).FirstOrDefault();
                                    string strShipDays = clsGlobal.mlistSupplier.Where(x => (x.DNHAPartNo == dnhaPartNo || x.SupplierPartNo == partNo)).Select(p => p.MFGShipDays).FirstOrDefault();
                                    if (strExpDays != null && strExpDays == null)
                                    {
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
                                            isProductMFGShippedDateCross = true;
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
                            else if (clsGlobal.mlistCustWiseExpiry.Exists(x => x.DNHAPartNo == dnhaPartNo && x.CustomerCode.TrimStart('0') == strCode && x.IsExpDate == true && exp != ""))
                            {
                                isMatchPart = true;
                                //isMatchQty = true; //Commented by dipak 10-03-25
                                isMatchExpiryDate = true;
                                strDNHAPartNo = clsGlobal.mlistCustWiseExpiry.Where(x => (x.DNHAPartNo == dnhaPartNo && x.CustomerCode.TrimStart('0') == strCode)).Select(p => p.DNHAPartNo).FirstOrDefault();
                                bool atucalExp = clsGlobal.mlistCustWiseExpiry.Where(x => x.DNHAPartNo == dnhaPartNo && x.CustomerCode.TrimStart('0') == strCode).Select(p => p.IsExpDate).FirstOrDefault();
                                string strExpShipDays = clsGlobal.mlistCustWiseExpiry.Where(x => x.DNHAPartNo == dnhaPartNo && x.CustomerCode.TrimStart('0') == strCode).Select(p => p.EXPShipDays).FirstOrDefault();
                                int iExpShipDays = strExpShipDays == "" ? 0 : Convert.ToInt32(strExpShipDays);
                                if (atucalExp == true && (iExpShipDays == 0 || iExpShipDays == null))
                                {
                                    if (DateTime.TryParseExact(exp, "yyyy-MM-dd", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime expDate))
                                    {
                                        if (DateTime.Today > expDate)
                                        {
                                            isProductExpired = true;
                                            break;
                                        }
                                    }
                                }
                                else if (atucalExp == true && (iExpShipDays != 0 || iExpShipDays != null))
                                {

                                    if (DateTime.TryParseExact(exp, "yyyy-MM-dd", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime expDate))
                                    {
                                        if (DateTime.Today > expDate)
                                        {
                                            isProductExpired = true;
                                            break;
                                        }
                                        else if (DateTime.Today > expDate.AddDays(-iExpShipDays))
                                        {
                                            isProductEXPShippedDateCross = true;
                                            break;
                                        }

                                    }
                                }

                                //if (DateTime.Today > DateTime.ParseExact(exp, "yyyy-MM-dd", CultureInfo.DefaultThreadCurrentCulture).AddDays(-iExpShipDays))
                                //{
                                //    isProductExpired = true;
                                //    break;
                                //}
                            }
                            else if (clsGlobal.mlistSupplier.Exists(x => x.DNHAPartNo == dnhaPartNo && x.IsExpDate == true && exp != ""))
                            {
                                isMatchPart = true;
                                //isMatchQty = true; //Commented by dipak 10-03-25
                                isMatchExpiryDate = true;
                                strDNHAPartNo = clsGlobal.mlistSupplier.Where(x => (x.DNHAPartNo == dnhaPartNo || x.SupplierPartNo == partNo)).Select(p => p.DNHAPartNo).FirstOrDefault();
                                bool atucalExp = clsGlobal.mlistSupplier.Where(x => x.DNHAPartNo == dnhaPartNo || x.SupplierPartNo == partNo).Select(p => p.IsExpDate).FirstOrDefault();
                                string strExpShipDays = clsGlobal.mlistSupplier.Where(x => x.DNHAPartNo == dnhaPartNo || x.SupplierPartNo == partNo).Select(p => p.EXPShipDays).FirstOrDefault();
                                int iExpShipDays = strExpShipDays == "" ? 0 : Convert.ToInt32(strExpShipDays);
                                if (atucalExp == true && (iExpShipDays == 0 || iExpShipDays == null))
                                {
                                    if (DateTime.TryParseExact(exp, "yyyy-MM-dd", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime expDate))
                                    {
                                        if (DateTime.Today > expDate)
                                        {
                                            isProductExpired = true;
                                            break;
                                        }
                                    }
                                }
                                else if (atucalExp == true && (iExpShipDays != 0 || iExpShipDays != null))
                                {

                                    if (DateTime.TryParseExact(exp, "yyyy-MM-dd", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime expDate))
                                    {
                                        if (DateTime.Today > expDate)
                                        {
                                            isProductExpired = true;
                                            break;
                                        }
                                        else if (DateTime.Today > expDate.AddDays(-iExpShipDays))
                                        {
                                            isProductEXPShippedDateCross = true;
                                            break;
                                        }

                                    }
                                }

                                //if (DateTime.Today > DateTime.ParseExact(exp, "yyyy-MM-dd", CultureInfo.DefaultThreadCurrentCulture).AddDays(-iExpShipDays))
                                //{
                                //    isProductExpired = true;
                                //    break;
                                //}
                            }
                            else
                            {
                                if (clsGlobal.mlistSupplier.Exists(x => (x.DNHAPartNo == dnhaPartNo || x.SupplierPartNo == partNo)))
                                {
                                    strSupplierPattern = entry.Patterns;
                                }
                                else //Added by dipak 27-02-2025
                                {
                                    if (i == 0)
                                    {
                                        goto NextForeachIteration;
                                    }
                                }
                                isMatchPart = true;
                                //isMatchQty = true; //Commented by dipak 10-03-25
                            }
                            // Check if the part number exists in the DNHA list
                            if (clsGlobal.mlistSupplier.Exists(x => (x.DNHAPartNo == dnhaPartNo || x.SupplierPartNo == partNo)))
                            {
                                if (clsGlobal.mlistSupplier.Exists(x => (x.DNHAPartNo == dnhaPartNo || x.SupplierPartNo == partNo)))
                                {
                                    strSupplierPattern = entry.Patterns;
                                }
                                else //Added by dipak 27-02-2025
                                {
                                    if (i == 0)
                                    {
                                        goto NextForeachIteration;
                                    }
                                }
                                //Now part is matched then need to check this partno into Main Master table any Expiry or specific validation is there then match the data
                                //If not matched it will go for next pattern if any
                                //
                                strDNHAPartNo = clsGlobal.mlistSupplier.Where(x => (x.DNHAPartNo == partNo || x.SupplierPartNo == partNo)).Select(p => p.DNHAPartNo).FirstOrDefault();
                                dnhaPartNo = clsGlobal.mlistSupplier.Where(x => (x.DNHAPartNo == partNo || x.SupplierPartNo == partNo)).Select(x => x.DNHAPartNo).First();
                                dnhaPartQty = qty;
                                isMatchPart = true;
                                //isMatchQty = true; //Commented by dipak 10-03-25

                            }
                            counter++;
                        }
                    NextForeachIteration:
                        continue;


                    }

                    if (!isMatchPart)
                    {
                        clsGlobal.showToastNGMessage("Invalid Supplier Kanban Barcode.", this);
                        clsGlobal.WriteLog($"Invalid Supplier Kanban Barcode.");
                        txtDNHASUPKanbanBarcode.Text = "";
                        txtDNHASUPKanbanBarcode.RequestFocus();
                        SoundForNG();
                        ShowAlertPopUp();
                        return;
                    }
                    if (!isMatchQty) //Added by dipak 10-03-2025
                    {
                        clsGlobal.showToastNGMessage("Qty is required for Supplier Kanban Barcode.", this);
                        clsGlobal.WriteLog($"Qty is required for Supplier Kanban Barcode.");
                        txtDNHASUPKanbanBarcode.Text = "";
                        txtDNHASUPKanbanBarcode.RequestFocus();
                        SoundForNG();
                        ShowAlertPopUp();
                        return;
                    }
                    if (dnhaPartQty == "0") //Added by dipak 10-03-2025
                    {
                        clsGlobal.showToastNGMessage("Qty is required for Supplier Kanban Barcode.", this);
                        clsGlobal.WriteLog($"Qty is required for Supplier Kanban Barcode.");
                        txtDNHASUPKanbanBarcode.Text = "";
                        txtDNHASUPKanbanBarcode.RequestFocus();
                        SoundForNG();
                        ShowAlertPopUp();
                        return;
                    }
                    if (!_ListItem.Exists(p => p.PartNo == dnhaPartNo))
                    {
                        clsGlobal.showToastNGMessage($"Part No. {dnhaPartNo} isn't available in SIL List! ", this);
                        clsGlobal.WriteLog($"Part No. {dnhaPartNo} isn't available in SIL List! ");
                        txtDNHASUPKanbanBarcode.Text = "";
                        txtDNHASUPKanbanBarcode.RequestFocus();
                        SoundForNG();
                        ShowAlertPopUp();
                        return;

                    }
                    if (isNGSuspectedLot)
                    {
                        clsGlobal.showToastNGMessage($"This product Lot {lot} is suspected {dnhaPartNo},Scanned valid product", this);
                        clsGlobal.WriteLog($"This product Lot {lot} is suspected {dnhaPartNo},Scanned valid product");
                        txtDNHASUPKanbanBarcode.Text = "";
                        txtDNHASUPKanbanBarcode.RequestFocus();
                        SoundForNG();
                        ShowAlertPopUp();
                        return;
                    }
                    if (clsGlobal.mlistDNHA.Exists(x => x.DNHAPartNo == dnhaPartNo && (x.IsExpDate == true) && isMatchExpiryDate == false))
                    {
                        clsGlobal.showToastNGMessage($"This product is registered with expiary check {dnhaPartNo},Scanned valid product or check pattern", this);
                        clsGlobal.WriteLog($"This product is registered with expiary check {dnhaPartNo},Scanned valid product or check pattern");
                        txtDNHASUPKanbanBarcode.Text = "";
                        txtDNHASUPKanbanBarcode.RequestFocus();
                        SoundForNG();
                        ShowAlertPopUp();
                        return;
                    }
                    if (clsGlobal.mlistDNHA.Exists(x => x.DNHAPartNo == dnhaPartNo && (x.IsMfgDate == true) && isMatchMFGDate == false))
                    {
                        clsGlobal.showToastNGMessage($"This product is registered with manufacturing check {dnhaPartNo},Scanned valid product or check pattern", this);
                        clsGlobal.WriteLog($"This product is registered with manufacturing check {dnhaPartNo},Scanned valid product or check pattern");
                        txtDNHASUPKanbanBarcode.Text = "";
                        txtDNHASUPKanbanBarcode.RequestFocus();
                        SoundForNG();
                        ShowAlertPopUp();
                        return;
                    }
                    if (isProductMFGShippedDateCross)
                    {
                        clsGlobal.showToastNGMessage($"This product is MFG Shipping date over {dnhaPartNo},Scanned valid product", this);
                        clsGlobal.WriteLog($"This product is MFG Shipping date over {dnhaPartNo},Scanned valid product");
                        txtDNHASUPKanbanBarcode.Text = "";
                        txtDNHASUPKanbanBarcode.RequestFocus();
                        SoundForNG();
                        ShowAlertPopUp();
                        return;
                    }
                    if (isProductEXPShippedDateCross)
                    {
                        clsGlobal.showToastNGMessage($"This product is EXP Shipping date over {dnhaPartNo},Scanned valid product", this);
                        clsGlobal.WriteLog($"This product is EXP Shipping date over {dnhaPartNo},Scanned valid product");
                        txtDNHASUPKanbanBarcode.Text = "";
                        txtDNHASUPKanbanBarcode.RequestFocus();
                        SoundForNG();
                        ShowAlertPopUp();
                        return;
                    }
                    if (isProductExpired)
                    {
                        clsGlobal.showToastNGMessage($"This product is Expired {dnhaPartNo},Scanned valid product", this);
                        clsGlobal.WriteLog($"This product is Expired {dnhaPartNo},Scanned valid product");
                        txtDNHASUPKanbanBarcode.Text = "";
                        txtDNHASUPKanbanBarcode.RequestFocus();
                        SoundForNG();
                        ShowAlertPopUp();
                        return;
                    }

                    if (!clsGlobal.mlistSupplier.Exists(p => p.DNHAPartNo == dnhaPartNo || p.SupplierPartNo == partNo))
                    {
                        clsGlobal.showToastNGMessage($"Scanned Part {dnhaPartNo} isn't available in main master list! ", this);
                        clsGlobal.WriteLog($"Scanned Part {dnhaPartNo} isn't available in main master list! ");
                        txtDNHASUPKanbanBarcode.Text = "";
                        txtDNHASUPKanbanBarcode.RequestFocus();
                        SoundForNG();
                        ShowAlertPopUp();
                        return;

                    }
                    if (string.IsNullOrEmpty(qty))
                    {
                        clsGlobal.showToastNGMessage($"Qty is not available! ", this);
                        clsGlobal.WriteLog($"Qty is not available! ");
                        txtDNHASUPKanbanBarcode.Text = "";
                        txtDNHASUPKanbanBarcode.RequestFocus();
                        SoundForNG();
                        ShowAlertPopUp();
                        return;

                    }
                    if (_ListItem.Exists(p => Convert.ToInt32(p.Balance) == 0 && p.PartNo == dnhaPartNo))
                    {
                        clsGlobal.showToastNGMessage($"This Part No {dnhaPartNo} Scanning Completed! ", this);
                        clsGlobal.WriteLog($"This Part No {dnhaPartNo} Scanning Completed! ");
                        txtDNHASUPKanbanBarcode.Text = "";
                        txtDNHASUPKanbanBarcode.RequestFocus();
                        SoundForNG();
                        ShowAlertPopUp();
                        return;

                    }
                    if (_ListItem.Exists(p => Convert.ToInt32(qty) > Convert.ToInt32(p.Balance) && p.PartNo == dnhaPartNo))
                    {
                        clsGlobal.showToastNGMessage($"Scanned Barcode Qty {qty} should be not be greater then SIL Part Qty! ", this);
                        clsGlobal.WriteLog($"Scanned Barcode Qty {qty} should be not be greater then SIL Part Qty! ");
                        txtDNHASUPKanbanBarcode.Text = "";
                        txtDNHASUPKanbanBarcode.RequestFocus();
                        SoundForNG();
                        ShowAlertPopUp();
                        return;

                    }
                    if (isMatchBarcodeLength)
                    {
                        if (txtDNHASUPKanbanBarcode.Text.Length != int.Parse(barcodeLength))
                        {
                            clsGlobal.showToastNGMessage($"Length is not matched,Scanned Barcode Length is {txtDNHASUPKanbanBarcode.Text.Length}  and pattern barcode length is {barcodeLength} ! ", this);
                            clsGlobal.WriteLog($"Length is not matched,Scanned Barcode Length is {txtDNHASUPKanbanBarcode.Text.Length}  and pattern barcode length is {barcodeLength} ! ");
                            txtDNHASUPKanbanBarcode.Text = "";
                            txtDNHASUPKanbanBarcode.RequestFocus();
                            SoundForNG();
                            ShowAlertPopUp();
                            return;
                        }
                    }
                    if (isMatchSeqNo)
                    {
                        if (_dicBarcode1.ContainsKey(combinedKey.Trim()))
                        {
                            clsGlobal.showToastNGMessage($"Supplier Barcode {txtDNHASUPKanbanBarcode.Text.Trim()} Already Exist!!", this);
                            clsGlobal.WriteLog($"Supplier Barcode {txtDNHASUPKanbanBarcode.Text.Trim()} Already Exist!!");
                            txtDNHASUPKanbanBarcode.Text = "";
                            txtDNHASUPKanbanBarcode.RequestFocus();
                            SoundForNG();
                            ShowAlertPopUp();
                            return;
                        }
                    }
                    try
                    {
                        //CustPart = txtDNHASUPKanbanBarcode.Text.Substring(66, 25).Trim();
                        //PartNo = txtDNHASUPKanbanBarcode.Text.Substring(91, 15).Trim();
                        //Qty = txtDNHASUPKanbanBarcode.Text.Substring(106, 7).Trim();
                        //ProcessCode = txtDNHASUPKanbanBarcode.Text.Substring(113, 5).Trim();
                        //SequenceNo = txtDNHASUPKanbanBarcode.Text.Substring(118, 7).Trim();
                        //DensoBarcode = txtDNHASUPKanbanBarcode.Text.Substring(0, 150).Trim();
                        //DNHAScannedOn = DateTime.Now.ToString();
                        string deviceId = clsGlobal.GetDeviceId(this);
                        string serial = clsGlobal.GetUPICODE(7, deviceId);
                        CustPart = partNo.Trim();
                        PartNo = dnhaPartNo.Trim();
                        Qty = qty.Trim();
                        ProcessCode = "";
                        SequenceNo = serial;
                        DensoBarcode = txtDNHASUPKanbanBarcode.Text.Trim();
                        DNHAScannedOn = DateTime.Now.ToString();
                    }
                    catch (Exception ex)
                    {

                        throw ex;
                    }
                    if (clsGlobal.mSILType == "2POINTS")
                    {
                        strDNHAPartNo = dnhaPartNo;

                        //We will validate the Lot and Qty of kaban barcode, if any ng lot or qty should not be greater then balance qty
                        UpdateFinalListScanQty(dnhaPartNo, qty);
                        WriteDeatilsFile($"{_strSILBarCode.Trim()}~{clsGlobal.ReplaceNewlinesWithCaret(txtDNHASUPKanbanBarcode.Text.Trim())}~{clsGlobal.ReplaceNewlinesWithCaret(txtCustKanbanBarcode.Text.Trim())}" +
                            $"~{PartNo}~{CustPart}~{Qty}~{"0"}~{ProcessCode}~{TruckNo}~{ShipTo}~{CustCode}~{SequenceNo}~{clsGlobal.mCustSeqNo}~{clsGlobal.mUserId}" +
                            $"~{SILScannedON}~{DNHAScannedOn}~{CustScannedOn}~{strSupplierPattern}~{isvalueMatchBarcode1SeqNo}~{valueombinedBarcode1Key}~{isvalueMatchBarcode2SeqNo}~{valueombinedBarcode2Key}");
                        valueombinedBarcode1Key = "";
                        valueombinedBarcode2Key = "";
                        isvalueMatchBarcode1SeqNo = false;
                        isvalueMatchBarcode2SeqNo = false;
                        if (isMatchSeqNo)
                        {
                            _dicBarcode1.Add(combinedKey, combinedKey);
                        }
                        if (_TotalQty == _ScanQty)
                        {
                            WriteSILCompltedFile(TruckNo);
                            clsGlobal.showToastOKMessage($"SIL No. {TruckNo} Completed! ", this);
                            txtDNHASUPKanbanBarcode.Text = "";
                            txtDNHASUPKanbanBarcode.RequestFocus();
                            clear();
                            BindSpinnerRegisteredSIL();
                        }
                        txtDNHASUPKanbanBarcode.Text = "";
                        SoundForOKVibrate();
                    }
                    else
                    {
                        strDNHAPartNo = dnhaPartNo;
                        if (isMatchSeqNo)
                        {
                            _dicBarcode1.Add(combinedKey, combinedKey);
                        }
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

        private string CheckSupplierOrDNHA()
        {
            string strSupplierOrDNHA = "";
            try
            {
                if (!CheckScanningSupplierAKanbanBarcode())
                {
                    if (CheckScanningDNHAKanbanBarcode())
                    {
                        strSupplierOrDNHA = "DNHA";
                    }
                    else
                    {
                        strSupplierOrDNHA = "INVALID";
                    }
                }
                else
                {
                    strSupplierOrDNHA = "SUPPLIER";
                }
            }
            catch (Exception ex)
            {

                clsGlobal.ShowMessage(ex.Message, this, MessageTitle.ERROR);
            }
            return strSupplierOrDNHA;


        }
        private bool CheckScanningDNHAKanbanBarcode()
        {
            bool _isDNHA = false;
            try
            {
                if (ValidateDNHAControls())
                {

                    string partNo = string.Empty;
                    int counter = 0;
                    bool isMatchPart = false;
                    bool isMatchMFGDate = false;
                    bool isMatchExpiryDate = false;
                    bool isMatchQty = false;
                    bool isMatchSuspectedLot = false;
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
                        else if ((isMatchPart && isMatchQty) && !isMatchMFGDate && !isMatchExpiryDate && !isMatchSuspectedLot)
                        {
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
                            string sepraterIndex = Convert.ToString(entry.keyValueData[i].Item2.ToString().Split('-')[2]);
                            string strTheSeprator = Convert.ToString(entry.Seperater);

                            // Extract the part number or quantity based on the current counter
                            int length = endIndex - startIndex;
                            if (entry.keyValueData[i].Item1.Trim().ToUpper() == "DNHAPARTNO")
                            {
                                if (strTheSeprator != "")
                                {
                                    try
                                    {
                                        string[] sArrBarcode = txtDNHASUPKanbanBarcode.Text.Split(Convert.ToChar(strTheSeprator));
                                        //string[] sArrBarcode = txtDNHASUPKanbanBarcode.Text.Split(new char[] { Convert.ToChar(strTheSeprator) }, StringSplitOptions.RemoveEmptyEntries);
                                        if (startIndex == endIndex)
                                        {
                                            partNo = sArrBarcode[Convert.ToInt32(sepraterIndex)];
                                        }
                                        else
                                        {
                                            partNo = sArrBarcode[Convert.ToInt32(sepraterIndex)].Substring(startIndex, length);
                                        }
                                    }
                                    catch
                                    {
                                        partNo = "";

                                    }

                                }
                                else
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
                            }

                            if (clsGlobal.mlistDNHA.Exists(x => x.DNHAPartNo == partNo) && _ListItem.Exists(p => p.PartNo == partNo)) //(Part should be exists in master file and also in listitem.)
                            {
                                isMatchPart = true;
                            }
                            else //Added by dipak 27-02-2025
                            {
                                if (i == 0)
                                {
                                    goto NextForeachIteration;
                                }
                            }


                            counter++;
                        }
                    NextForeachIteration:
                        continue;

                    }
                    if (!isMatchPart)
                    {
                        _isDNHA = false;
                    }
                    else
                    {
                        _isDNHA = true;
                    }


                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
            return _isDNHA;
        }
        private bool CheckScanningSupplierAKanbanBarcode()
        {
            bool _isDSUP = false;
            try
            {
                if (ValidateSupplierControls())
                {

                    string partNo = string.Empty;
                    int counter = 0;
                    bool isMatchPart = false;
                    bool isMatchMFGDate = false;
                    bool isMatchExpiryDate = false;
                    bool isMatchQty = false;
                    bool isMatchSuspectedLot = false;
                    //var maxEntry = clsGlobal.mlistSupplierPattern
                    //   .OrderByDescending(entry => entry.keyValueData.Count);
                    string strCode = Convert.ToInt32(clsGlobal.mCustomerCode).ToString();
                    var maxEntry = clsGlobal.mlistSupplierPattern.Where(x => x.Code.TrimStart('0') == strCode).Select(x => x).ToList();
                    if (maxEntry.Count == 0)
                    {
                        _isDSUP = false;
                        return _isDSUP;
                    }
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
                        else if ((isMatchPart && isMatchQty) && !isMatchMFGDate && !isMatchExpiryDate && !isMatchSuspectedLot)
                        {
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
                            string sepraterIndex = Convert.ToString(entry.keyValueData[i].Item2.ToString().Split('-')[2]);
                            string strTheSeprator = Convert.ToString(entry.Seperater);

                            // Extract the part number or quantity based on the current counter
                            int length = endIndex - startIndex;
                            if (entry.keyValueData[i].Item1.Trim().ToUpper() == "SUPPLIERPARTNO")
                            {
                                if (strTheSeprator != "")
                                {
                                    try
                                    {
                                        string[] sArrBarcode = txtDNHASUPKanbanBarcode.Text.Split(Convert.ToChar(strTheSeprator));
                                        // string[] sArrBarcode = txtDNHASUPKanbanBarcode.Text.Split(new char[] { Convert.ToChar(strTheSeprator) }, StringSplitOptions.RemoveEmptyEntries);
                                        if (startIndex == endIndex)
                                        {
                                            partNo = sArrBarcode[Convert.ToInt32(sepraterIndex)];
                                        }
                                        else
                                        {
                                            partNo = sArrBarcode[Convert.ToInt32(sepraterIndex)].Substring(startIndex, length);
                                        }
                                    }
                                    catch
                                    {
                                        partNo = "";

                                    }

                                }
                                else
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
                            }

                            if (clsGlobal.mlistSupplier.Exists(x => (x.DNHAPartNo == partNo || x.SupplierPartNo == partNo))) //(Part should be exists in master file and also in listitem.)
                            {

                                isMatchPart = true;
                            }
                            else //Added by dipak 27-02-2025
                            {
                                if (i == 0)
                                {
                                    goto NextForeachIteration;
                                }
                            }


                            counter++;
                        }
                    NextForeachIteration:
                        continue;

                    }
                    if (!isMatchPart)
                    {
                        _isDSUP = false;
                    }
                    else
                    {
                        _isDSUP = true;
                    }


                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
            return _isDSUP;
        }
        bool ContainsJunkCharacters(string text)
        {
            if (text.Contains("~"))
            {
                return true;
            }
            else
            {
                // Allow standard printable ASCII, Unicode, and spaces but reject `~`
                //return Regex.IsMatch(text, @"[\x00-\x1F\x7F-\x9F\u07DE-\u07FF\u2000-\u206F]");
                return Regex.IsMatch(text, @"[\x7F-\x9F\u07DE-\u07FF\u2000-\u206F]");
            }
        }
        #endregion

        #region GenricFuncation for commna to get Part And Qty
        #endregion

        #region Activiy Events
        private void SpinnerSIL_ItemSelected(object sender, AdapterView.ItemSelectedEventArgs e)
        {
            try
            {
                if (spinnerSIL.SelectedItemPosition > 0)
                {

                    lblDNHAKanban.Visibility = ViewStates.Gone;
                    txtDNHASUPKanbanBarcode.Visibility = ViewStates.Gone;
                    lblCustKanban.Visibility = ViewStates.Gone;
                    txtCustKanbanBarcode.Visibility = ViewStates.Gone;
                    //lblSupKanban.Visibility = ViewStates.Gone;
                    //txtSUPKanbanBarcode.Visibility = ViewStates.Gone;

                    if (spinnerSIL.SelectedItem.ToString().Contains("*"))
                    {
                        clsGlobal.showToastNGMessage($"This SIL Already Completed!!", this);
                        txtCustKanbanBarcode.Text = "";
                        txtCustKanbanBarcode.RequestFocus();
                        SoundForNG();
                        return;
                    }
                    string strTranscationPath = Path.Combine(clsGlobal.FilePath, clsGlobal.TranscationFolder);
                    string strFinalSILWiseDirectory = Path.Combine(strTranscationPath, spinnerSIL.SelectedItem.ToString());
                    string strFinalFilePath = Path.Combine(strFinalSILWiseDirectory, clsGlobal.SILMasterDataFile);
                    string strSILBarcodeFilePath = Path.Combine(strFinalSILWiseDirectory, clsGlobal.SILBarcode);
                    _strSILBarCode = clsGlobal.ReadSILBarcodeFromFile(strSILBarcodeFilePath);

                    GetSILScanData(_strSILBarCode);
                }
            }
            catch (Exception ex)
            {
                clsGlobal.ShowMessage(ex.Message, this, MessageTitle.ERROR);
            }
        }
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
                        //if (txtDNHASUPKanbanBarcode.Text.Trim().StartsWith("DISC"))
                        //{

                        //    ScanningDNHAKanbanBarcode();

                        //}
                        //else
                        //{

                        //    ScanningSUPKanbanBarcode();

                        //}
                        txtDNHASUPKanbanBarcode.Text = txtDNHASUPKanbanBarcode.Text.Replace("\r", "").Replace("\r", "");
                        if (CheckSupplierOrDNHA() == "DNHA")
                        {

                            ScanningDNHAKanbanBarcode();

                        }
                        else if (CheckSupplierOrDNHA() == "SUPPLIER")
                        {

                            ScanningSUPKanbanBarcode();

                        }
                        else
                        {
                            if (!string.IsNullOrEmpty(txtDNHASUPKanbanBarcode.Text.Trim()))
                            {
                                clsGlobal.showToastNGMessage($"Invalid DNHA/Supplier Barcode", this);
                                clsGlobal.WriteLog($"Invalid DNHA/Supplier Barcode");
                                txtDNHASUPKanbanBarcode.Text = "";
                                txtDNHASUPKanbanBarcode.RequestFocus();
                                SoundForNG();
                                ShowAlertPopUp();
                            }
                        }
                    }
                    else
                        e.Handled = false;
                }
            }
            catch (Exception ex)
            {
                clsGlobal.ShowMessage(ex.Message, this, MessageTitle.ERROR);

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
                            string combinedKey = "";
                            int counter = 0;
                            bool isMatchPart = false;
                            bool isMatchQty = false;
                            bool isMatchSeqNo = false;
                            string dnhaPartNo = string.Empty;
                            string dnhaPartQty = string.Empty;

                            var mlistCustomerPatternFinal = clsGlobal.mlistCustomerPattern.Where(x => x.ThreePointCheckDigit == clsGlobal.m3CheckPointsDigit && Convert.ToInt32(x.Code) == Convert.ToInt32(clsGlobal.mCustomerCode)).Select(x => x).ToList();
                            if (mlistCustomerPatternFinal.Count == 0)
                            {
                                clsGlobal.showToastNGMessage($"Customer Barcode {txtCustKanbanBarcode.Text.Trim()} 3CheckDigitNot Matched!!", this);
                                txtCustKanbanBarcode.Text = "";
                                txtCustKanbanBarcode.RequestFocus();
                                SoundForNG();
                                ShowAlertPopUp();
                                return;
                            }

                            txtCustKanbanBarcode.Text = txtCustKanbanBarcode.Text.Trim().Replace("\n", "").Replace("\r", "").Replace("\r\n", "").Trim();
                            // Loop through the list of patterns
                            //foreach (var entry in clsGlobal.mlistCustomerPattern)
                            foreach (var entry in mlistCustomerPatternFinal)
                            {

                                counter = 0;
                                if (isMatchPart && isMatchQty)
                                {
                                    break;
                                }
                                else
                                {
                                    //Added by dipak 27-02-2025
                                    isMatchPart = false;
                                    isMatchQty = false;
                                }

                                // Step 4: Iterate through the hashtable inside the dictionary
                                for (int i = 0; i < entry.keyValueData.Count; i++)
                                {
                                    // Get the start and end indexes from the keyValueData entry
                                    int startIndex = Convert.ToInt32(entry.keyValueData[i].Item2.ToString().Split('-')[0]);
                                    int endIndex = Convert.ToInt32(entry.keyValueData[i].Item2.ToString().Split('-')[1]);
                                    string sepraterIndex = Convert.ToString(entry.keyValueData[i].Item2.ToString().Split('-')[2]);
                                    string strTheSeprator = Convert.ToString(entry.Seperater);

                                    // Extract the part number or quantity based on the current counter
                                    int length = endIndex - startIndex;
                                    if (entry.keyValueData[i].Item1.Trim().ToUpper() == "CUSTOMERPARTNO")
                                    {
                                        try
                                        {
                                            if (strTheSeprator != "")
                                            {
                                                try
                                                {
                                                    string[] sArrBarcode = txtCustKanbanBarcode.Text.Split(Convert.ToChar(strTheSeprator));
                                                    //string[] sArrBarcode = txtCustKanbanBarcode.Text.Split(new char[] { Convert.ToChar(strTheSeprator) }, StringSplitOptions.RemoveEmptyEntries);
                                                    if (startIndex == endIndex)
                                                    {
                                                        partNo = sArrBarcode[Convert.ToInt32(sepraterIndex)];
                                                    }
                                                    else
                                                    {
                                                        partNo = sArrBarcode[Convert.ToInt32(sepraterIndex)].Substring(startIndex, length);
                                                    }
                                                }
                                                catch
                                                {


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
                                            isMatchQty = false;
                                            qty = "";
                                            int number = 0;
                                            if (strTheSeprator != "")
                                            {
                                                try
                                                {
                                                    string[] sArrBarcode = txtCustKanbanBarcode.Text.Split(Convert.ToChar(strTheSeprator));
                                                    //string[] sArrBarcode = txtCustKanbanBarcode.Text.Split(new char[] { Convert.ToChar(strTheSeprator) }, StringSplitOptions.RemoveEmptyEntries);
                                                    if (startIndex == endIndex)
                                                    {
                                                        int.TryParse(sArrBarcode[Convert.ToInt32(sepraterIndex)], out number);
                                                    }
                                                    else
                                                    {
                                                        int.TryParse(sArrBarcode[Convert.ToInt32(sepraterIndex)].Substring(startIndex, length), out number);

                                                    }
                                                }
                                                catch
                                                {


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
                                            if (strTheSeprator != "")
                                            {
                                                try
                                                {
                                                    string[] sArrBarcode = txtCustKanbanBarcode.Text.Split(Convert.ToChar(strTheSeprator));
                                                    // string[] sArrBarcode = txtCustKanbanBarcode.Text.Split(new char[] { Convert.ToChar(strTheSeprator) }, StringSplitOptions.RemoveEmptyEntries);
                                                    if (startIndex == endIndex)
                                                    {
                                                        strSEQNo = sArrBarcode[Convert.ToInt32(sepraterIndex)];
                                                    }
                                                    else
                                                    {
                                                        strSEQNo = sArrBarcode[Convert.ToInt32(sepraterIndex)].Substring(startIndex, length);
                                                    }
                                                }
                                                catch
                                                {


                                                }

                                            }
                                            else
                                            {
                                                strSEQNo = txtCustKanbanBarcode.Text.Trim().Substring(startIndex, length);
                                            }

                                            seqNo = clsGlobal.mCustSeqNo = strSEQNo.ToString().Trim();
                                            combinedKey = $"{partNo}^{seqNo}";
                                            isvalueMatchBarcode2SeqNo = true;
                                            valueombinedBarcode2Key = combinedKey;
                                            isMatchSeqNo = true;
                                        }
                                        catch
                                        {
                                            seqNo = "0";


                                        }


                                    }
                                    // Check if the part number exists in the DNHA list
                                    if (clsGlobal.mlistCustomer.Exists(x => (x.DNHAPartNo == partNo.Trim() || x.CustomerPartNo.Trim().Replace("-", "").Replace(",", "").Replace(" ", "") == partNo.Trim().Replace("-", "").Replace(",", "").Replace(" ", "")) && x.DNHAPartNo == strDNHAPartNo))
                                    {
                                        //Now part is matched then need to check this partno into Main Master table any Expiry or specific validation is there then match the data
                                        //If not matched it will go for next pattern if any
                                        //

                                        dnhaPartNo = clsGlobal.mlistCustomer.Where(x => (x.DNHAPartNo == partNo.Trim() || x.CustomerPartNo.Trim().Replace("-", "").Replace(",", "").Replace(" ", "") == partNo.Trim().Replace("-", "").Replace(",", "").Replace(" ", "")) && x.DNHAPartNo == strDNHAPartNo).Select(x => x.DNHAPartNo).First();
                                        dnhaPartQty = qty;
                                        strCustomerPattern = entry.Patterns;
                                        iQrCode2Qty = Convert.ToInt32(qty);
                                        isMatchPart = true;
                                        //if (iQrCode2Qty > 0 && _DnhaSupQty == iQrCode2Qty)
                                        //{
                                        //    isMatchQty = true;
                                        //}
                                        if (iQrCode2Qty > 0 && int.Parse(dnhaPartQty) > 0)
                                        {
                                            isMatchQty = true;
                                        }



                                    }
                                    else //Added by dipak 27-02-2025
                                    {
                                        if (i == 0)
                                        {
                                            goto NextForeachIteration;
                                        }
                                    }

                                    counter++;
                                }

                            NextForeachIteration:
                                continue;
                            }
                            if (string.IsNullOrEmpty(partNo)) { isMatchPart = false; }
                            if (!isMatchPart)
                            {
                                clsGlobal.showToastNGMessage($"Invalid Customer Kanban Barcode. {partNo.Trim().Replace("-", "").Replace(",", "").Replace(" ", "")} ", this);
                                clsGlobal.WriteLog($"Invalid Customer Kanban Barcode. {partNo.Trim().Replace("-", "").Replace(",", "").Replace(" ", "")} ");
                                txtCustKanbanBarcode.Text = "";
                                txtCustKanbanBarcode.RequestFocus();
                                SoundForNG();
                                ShowAlertPopUp();
                                return;
                            }
                            if (!_ListItem.Exists(p => p.PartNo == dnhaPartNo))
                            {
                                clsGlobal.showToastNGMessage($"Part No. {dnhaPartNo} isn't available in SIL List! ", this);
                                clsGlobal.WriteLog($"Part No. {dnhaPartNo} isn't available in SIL List! ");
                                txtCustKanbanBarcode.Text = "";
                                txtCustKanbanBarcode.RequestFocus();
                                SoundForNG();
                                ShowAlertPopUp();
                                return;

                            }
                            if (!clsGlobal.mlistCustomer.Exists(x => (x.DNHAPartNo == partNo.Trim() || x.CustomerPartNo.Trim().Replace("-", "").Replace(",", "").Replace(" ", "") == partNo.Trim().Replace("-", "").Replace(",", "").Replace(" ", "")) && x.DNHAPartNo == strDNHAPartNo))
                            {
                                clsGlobal.showToastNGMessage($"Scanned Part. {partNo} isn't available in main master list! ", this);
                                clsGlobal.WriteLog($"Scanned Part. {partNo} isn't available in main master list! ");
                                txtCustKanbanBarcode.Text = "";
                                txtCustKanbanBarcode.RequestFocus();
                                SoundForNG();
                                ShowAlertPopUp();
                                return;

                            }
                            if (string.IsNullOrEmpty(qty))
                            {
                                clsGlobal.showToastNGMessage($"Qty is not available! ", this);
                                clsGlobal.WriteLog($"Qty is not available!");
                                txtCustKanbanBarcode.Text = "";
                                txtCustKanbanBarcode.RequestFocus();
                                SoundForNG();
                                ShowAlertPopUp();
                                return;

                            }
                            if (_ListItem.Exists(p => Convert.ToInt32(p.Balance) == 0 && p.PartNo == dnhaPartNo))
                            {
                                clsGlobal.showToastNGMessage($"This Part No {dnhaPartNo} Scanning Completed! ", this);
                                clsGlobal.WriteLog($"This Part No {dnhaPartNo} Scanning Completed!");
                                txtCustKanbanBarcode.Text = "";
                                txtCustKanbanBarcode.RequestFocus();
                                SoundForNG();
                                ShowAlertPopUp();
                                return;

                            }
                            if (_ListItem.Exists(p => Convert.ToInt32(qty) > Convert.ToInt32(p.Balance) && p.PartNo == dnhaPartNo))
                            {
                                clsGlobal.showToastNGMessage($"Scanned Barcode Qty {qty} should be not be greater then SIL Part Qty! ", this);
                                clsGlobal.WriteLog($"Scanned Barcode Qty {qty} should be not be greater then SIL Part Qty!");
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
                                    if (_dicBarcode1.ContainsKey(combinedKey.Trim()))
                                    {

                                        clsGlobal.showToastNGMessage($"Customer Barcode {txtCustKanbanBarcode.Text.Trim()} Already Exist!!", this);
                                        clsGlobal.WriteLog($"Customer Barcode {txtCustKanbanBarcode.Text.Trim()} Already Exist!!");
                                        txtCustKanbanBarcode.Text = "";
                                        txtCustKanbanBarcode.RequestFocus();
                                        SoundForNG();
                                        ShowAlertPopUp();
                                        return;
                                    }
                                }
                                else
                                {
                                    if (_dicBarcode2.ContainsKey(combinedKey.Trim()))
                                    {

                                        clsGlobal.showToastNGMessage($"Customer Barcode {txtCustKanbanBarcode.Text.Trim()} Already Exist!!", this);
                                        clsGlobal.WriteLog($"Customer Barcode {txtCustKanbanBarcode.Text.Trim()} Already Exist!!");
                                        txtCustKanbanBarcode.Text = "";
                                        txtCustKanbanBarcode.RequestFocus();
                                        SoundForNG();
                                        ShowAlertPopUp();
                                        return;
                                    }
                                }
                            }
                            //This below code will never run
                            if (clsGlobal.mSILType == "2POINTS")
                            {
                                WriteDeatilsFile($"{_strSILBarCode.Trim()}~{clsGlobal.ReplaceNewlinesWithCaret(txtCustKanbanBarcode.Text.Trim())}~{clsGlobal.mShipmentType}");
                                if (isMatchSeqNo)
                                {
                                    //_dicBarcode1.Add(txtCustKanbanBarcode.Text.Trim(), txtCustKanbanBarcode.Text.Trim());
                                    _dicBarcode2.Add(combinedKey, combinedKey);
                                }
                                txtCustKanbanBarcode.SelectAll();
                                txtCustKanbanBarcode.RequestFocus();
                            }
                            else
                            {
                                if (iQrCode1Qty != iQrCode2Qty)
                                {
                                    clsGlobal.showToastNGMessage($"QR Code1 Qty {iQrCode1Qty} should be equal to QR Code2 Qty {iQrCode2Qty} ! ", this);
                                    clsGlobal.WriteLog($"QR Code1 Qty {iQrCode1Qty} should be equal to QR Code2 Qty {iQrCode2Qty} !");
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
                                WriteDeatilsFile($"{_strSILBarCode.Trim()}~{clsGlobal.ReplaceNewlinesWithCaret(txtDNHASUPKanbanBarcode.Text.Trim())}" +
                                $"~{clsGlobal.ReplaceNewlinesWithCaret(txtCustKanbanBarcode.Text.Trim())}" +
                                $"~{PartNo}~{CustPart}~{Qty}~{"0"}~{ProcessCode}~{TruckNo}~{ShipTo}~{CustCode}~{SequenceNo}~{clsGlobal.mCustSeqNo}~{clsGlobal.mUserId}" +
                                $"~{SILScannedON}~{DNHAScannedOn}~{CustScannedOn}~{strCustomerPattern}~{isvalueMatchBarcode1SeqNo}~{valueombinedBarcode1Key}~{isvalueMatchBarcode2SeqNo}~{valueombinedBarcode2Key}");
                                valueombinedBarcode1Key = "";
                                valueombinedBarcode2Key = "";
                                isvalueMatchBarcode1SeqNo = false;
                                isvalueMatchBarcode2SeqNo = false;
                                if (isMatchSeqNo)
                                {
                                    //_dicBarcode2.Add(txtCustKanbanBarcode.Text.Trim(), txtCustKanbanBarcode.Text.Trim());
                                    _dicBarcode2.Add(combinedKey, combinedKey);
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
                                clsGlobal.showToastOKMessage($"SIL No. {TruckNo} Completed! ", this);
                                txtDNHASUPKanbanBarcode.Text = "";
                                txtDNHASUPKanbanBarcode.RequestFocus();
                                clear();
                                BindSpinnerRegisteredSIL();
                            }
                            SoundForOKVibrate();
                        }

                    }
                    else
                        e.Handled = false;
                }
            }
            catch (Exception ex)
            {
                clsGlobal.ShowMessage(ex.Message, this, MessageTitle.ERROR);

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
                clsGlobal.ShowMessage(ex.Message, this, MessageTitle.ERROR);
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
                clsGlobal.ShowMessage(ex.Message, this, MessageTitle.ERROR);
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
                        //txtSILBarcode.SelectAll();
                        //lblDNHAKanban.Visibility = ViewStates.Gone;
                        //txtDNHASUPKanbanBarcode.Visibility = ViewStates.Gone;
                        //lblCustKanban.Visibility = ViewStates.Gone;
                        //txtCustKanbanBarcode.Visibility = ViewStates.Gone;
                        ////lblSupKanban.Visibility = ViewStates.Gone;
                        ////txtSUPKanbanBarcode.Visibility = ViewStates.Gone;
                        //GetSILScanData();

                    }
                    else
                        e.Handled = false;
                }
            }
            catch (Exception ex)
            {
                clsGlobal.ShowMessage(ex.Message, this, MessageTitle.ERROR);
            }
        }


        public override void OnBackPressed() { }

        private bool ValidateDNHAControls()
        {
            try
            {
                bool IsValidate = true;


                if (spinnerSIL.SelectedItemPosition <= 0)
                {
                    clsGlobal.showToastNGMessage($"Scan SIL Barcode.", this);
                    spinnerSIL.RequestFocus();
                    IsValidate = false;
                    SoundForNG();
                    ShowAlertPopUp();
                }

                else if (string.IsNullOrEmpty(txtDNHASUPKanbanBarcode.Text.Trim()))
                {
                    return false;
                    //clsGlobal.showToastNGMessage($"Scan DNHA Kanban Barcode.", this);
                    //txtDNHASUPKanbanBarcode.Text = "";
                    //txtDNHASUPKanbanBarcode.RequestFocus();
                    //IsValidate = false;
                    //SoundForNG();
                    //ShowAlertPopUp();
                }
                else if (txtDNHASUPKanbanBarcode.Text.Length < 25)
                {
                    clsGlobal.showToastNGMessage($"Invalid DNHA Kanban Barcode.", this);
                    clsGlobal.WriteLog($"Invalid DNHA Kanban Barcode.");
                    txtDNHASUPKanbanBarcode.Text = "";
                    txtDNHASUPKanbanBarcode.RequestFocus();
                    IsValidate = false;
                    SoundForNG();
                    ShowAlertPopUp();
                }
                else if (ContainsJunkCharacters(txtDNHASUPKanbanBarcode.Text))
                {
                    clsGlobal.showToastNGMessage($"Re-Scan Supplier/DNHA Kanban Barcode,Junk Character is not allowd.", this);
                    clsGlobal.WriteLog($"Re-Scan Supplier/DNHA Kanban Barcode,Junk Character is not allowd.");
                    txtDNHASUPKanbanBarcode.Text = "";
                    txtDNHASUPKanbanBarcode.RequestFocus();
                    IsValidate = false;
                    SoundForNG();
                    ShowAlertPopUp();
                }
                else if (_TotalQty == _ScanQty)
                {
                    clsGlobal.showToastNGMessage($"Scan Completed of this SIL.", this);
                    txtDNHASUPKanbanBarcode.Text = "";
                    txtDNHASUPKanbanBarcode.RequestFocus();
                    IsValidate = false;
                    SoundForNG();
                    ShowAlertPopUp();
                }

                else if (_ListItem.Count == 0)
                {
                    clsGlobal.showToastNGMessage($"SIL Data is not Available", this);
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


                if (spinnerSIL.SelectedItemPosition <= 0)
                {
                    clsGlobal.showToastNGMessage($"Scan SIL Barcode.", this);
                    spinnerSIL.RequestFocus();
                    IsValidate = false;
                    SoundForNG();
                    ShowAlertPopUp();
                }

                else if (string.IsNullOrEmpty(txtCustKanbanBarcode.Text.Trim()))
                {
                    clsGlobal.showToastNGMessage($"Scan Customer Kanban Barcode.", this);
                    txtCustKanbanBarcode.Text = "";
                    txtCustKanbanBarcode.RequestFocus();
                    IsValidate = false;
                    SoundForNG();
                    ShowAlertPopUp();
                }
                //else if (txtCustKanbanBarcode.Text.Trim().Length < 25)
                //{
                //    clsGlobal.showToastNGMessage($"Invalid Customer Kanban Barcode.", this);
                //    txtCustKanbanBarcode.Text = "";
                //    txtCustKanbanBarcode.RequestFocus();
                //    IsValidate = false;
                //    SoundForNG();
                //    ShowAlertPopUp();
                //}
                else if (ContainsJunkCharacters(txtCustKanbanBarcode.Text))
                {
                    clsGlobal.showToastNGMessage($"Re-Scan Customer Kanban Barcode,Junk Character is not allowd.", this);
                    clsGlobal.WriteLog($"Re-Scan Supplier Kanban Barcode,Junk Character is not allowd.");
                    txtCustKanbanBarcode.Text = "";
                    txtCustKanbanBarcode.RequestFocus();
                    IsValidate = false;
                    SoundForNG();
                    ShowAlertPopUp();
                }
                else if (_TotalQty == _ScanQty)
                {
                    clsGlobal.showToastNGMessage($"Scan Completed of this SIL.", this);
                    txtCustKanbanBarcode.Text = "";
                    txtCustKanbanBarcode.RequestFocus();
                    IsValidate = false;
                    SoundForNG();
                    ShowAlertPopUp();
                }
                else if (_ListItem.Count == 0)
                {
                    clsGlobal.showToastNGMessage($"SIL Data is not Available", this);
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


                if (spinnerSIL.SelectedItemPosition <= 0)
                {
                    clsGlobal.showToastNGMessage($"Scan SIL Barcode.", this);

                    spinnerSIL.RequestFocus();
                    IsValidate = false;
                    SoundForNG();
                    ShowAlertPopUp();
                }

                else if (string.IsNullOrEmpty(txtDNHASUPKanbanBarcode.Text.Trim()))
                {
                    return false;
                    //clsGlobal.showToastNGMessage($"Scan Supplier Kanban Barcode.", this);
                    //txtDNHASUPKanbanBarcode.Text = "";
                    //txtDNHASUPKanbanBarcode.RequestFocus();
                    //IsValidate = false;
                    //SoundForNG();
                    //ShowAlertPopUp();
                }

                else if (txtDNHASUPKanbanBarcode.Text.Length < 25)
                {
                    clsGlobal.showToastNGMessage($"Invalid Supplier Kanban Barcode.", this);
                    clsGlobal.WriteLog($"Invalid Supplier Kanban Barcode.");
                    txtDNHASUPKanbanBarcode.Text = "";
                    txtDNHASUPKanbanBarcode.RequestFocus();
                    IsValidate = false;
                    SoundForNG();
                    ShowAlertPopUp();
                }
                else if (ContainsJunkCharacters(txtDNHASUPKanbanBarcode.Text))
                {
                    clsGlobal.showToastNGMessage($"Re-Scan Supplier/DNHA Kanban Barcode,Junk Character is not allowd.", this);
                    clsGlobal.WriteLog($"Re-Scan Supplier/DNHA Kanban Barcode,Junk Character is not allowd.");
                    txtDNHASUPKanbanBarcode.Text = "";
                    txtDNHASUPKanbanBarcode.RequestFocus();
                    IsValidate = false;
                    SoundForNG();
                    ShowAlertPopUp();
                }
                else if (_TotalQty == _ScanQty)
                {
                    clsGlobal.showToastNGMessage($"Scan Completed of this SIL.", this);
                    txtDNHASUPKanbanBarcode.Text = "";
                    txtDNHASUPKanbanBarcode.RequestFocus();
                    IsValidate = false;
                    SoundForNG();
                    ShowAlertPopUp();
                }
                else if (_ListItem.Count == 0)
                {
                    clsGlobal.showToastNGMessage($"SIL Data is not Available", this);
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
            lblPartCount.Text = "0";
            txtDNHASUPKanbanBarcode.Text = "";
            txtCustKanbanBarcode.Text = "";
            spinnerSIL.SetSelection(0);
            lblDNHAKanban.Visibility = ViewStates.Gone;
            txtDNHASUPKanbanBarcode.Visibility = ViewStates.Gone;
            lblCustKanban.Visibility = ViewStates.Gone;
            txtCustKanbanBarcode.Visibility = ViewStates.Gone;
            spinnerSIL.Enabled = true;
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
                lblPartCount.Text = Convert.ToString(_ListItem.Count(x => x.Balance != "0"));
                GetUpdateScannedBinCount();
            }

            txtTotalQty.Text = "Total Qty : " + _TotalQty.ToString();
            txtScanQty.Text = "Scan Qty : " + _ScanQty.ToString();
            spinnerSIL.RequestFocus();

            txtTruckSILCodeNo.Text = "";
            txtCheckPoint.Text = "";
            lblPartCount.Text = "";
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