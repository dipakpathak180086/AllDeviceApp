using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
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
using static Android.Support.V7.Widget.RecyclerView;

namespace BatteryDispatchScannerOnline.ActivityClass
{
    [Activity(Label = "BatteryScanning", WindowSoftInputMode = Android.Views.SoftInput.StateAlwaysHidden, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation, ScreenOrientation = ScreenOrientation.Portrait)]
    public class BatteryScanning : Activity
    {

        clsGlobal clsGLB;
        EditText txtDelivery, txtBattery;
        Dictionary<string, string> dicRegPlant = new Dictionary<string, string>();
        TextView lblResult, txtTotalQty, txtScanQty, txtTruckNo, txtTransName;
        TextView lblCount;
        int _TotalQty = 0, _ScanQty = 0, _SrNoCounter = 0;
        int dispatchcunt = 0;
        List<ViewBatteryData> _ListItem = new List<ViewBatteryData>();
        List<ViewBatteryScanData> _ListScanItem = new List<ViewBatteryScanData>();
        List<ViewBatteryData> _ListItemFinalSave = new List<ViewBatteryData>();
        string selectedSKU = string.Empty;
        RecyclerView recyclerViewItem;
        BatteryItemAdapter receivingItemAdapter;
        RecyclerView recyclerViewScanItem;
        BatteryScanItemAdapter receivingScanItemAdapter;
        RecyclerView.LayoutManager mLayoutManager;
        RecyclerView.LayoutManager mLayoutManager2;
        Dictionary<string, string> _dicBatteryScanningData = new Dictionary<string, string>();
        MediaPlayer mediaPlayerSound;
        bool scanningComplete = false;
        public BatteryScanning()
        {
            try
            {
                clsGLB = new clsGlobal();
                dicRegPlant.Add("HHHU", "HHHU");
                dicRegPlant.Add("HHHD", "HHHD");
                dicRegPlant.Add("HHHG", "HHHG");
                dicRegPlant.Add("HM4N", "HM4N");
                dicRegPlant.Add("HM5V", "HM5V");
                dicRegPlant.Add("HM6C", "HM6C");
                dicRegPlant.Add("HE6S", "HE6S");
                dicRegPlant.Add("HE6C", "HE6C");
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
                SetContentView(Resource.Layout.activity_BatteryScanning);

                //cmbSite = FindViewById<Spinner>(Resource.Id.cmbSite);

                Button btnFinalSave = FindViewById<Button>(Resource.Id.btnFinalSave);
                btnFinalSave.Click += BtnFinalSave_Click;

                Button btn = FindViewById<Button>(Resource.Id.btnBack);
                btn.Click += Btnback_Click;
                Button btnClear = FindViewById<Button>(Resource.Id.btnClear);
                btnClear.Click += BtnClear_Click;


                txtDelivery = FindViewById<EditText>(Resource.Id.editDelivery);
                txtDelivery.KeyPress += TxtDelivery_KeyPress;
                txtDelivery.Text = clsGlobal.mEnterDelivery;


                //TxtDelivery_KeyPress(null, null);

                txtBattery = FindViewById<EditText>(Resource.Id.editBatteryBarcode);
                txtBattery.KeyPress += TxtBattery_KeyPress;
                txtBattery.Text = "";

                txtTotalQty = FindViewById<TextView>(Resource.Id.txtTotalQty);
                txtTotalQty.Text = "Total Qty : " + _TotalQty.ToString();
                txtScanQty = FindViewById<TextView>(Resource.Id.txtScanQty);
                txtScanQty.Text = "Scan Qty : " + _ScanQty.ToString();

                txtTruckNo = FindViewById<TextView>(Resource.Id.lblTruckNo);
                txtTruckNo.Text = "Truck No:        ";
                txtTransName = FindViewById<TextView>(Resource.Id.lblTransName);
                txtTransName.Text = "";


                dispatchcunt = 0;

                lblResult = FindViewById<TextView>(Resource.Id.lblDisResult);
                // lblCount = FindViewById<TextView>(Resource.Id.lblCount);

                recyclerViewItem = FindViewById<RecyclerView>(Resource.Id.recycleViewReceiveItem);
                mLayoutManager = new LinearLayoutManager(this);
                recyclerViewItem.SetLayoutManager(mLayoutManager);

                recyclerViewScanItem = FindViewById<RecyclerView>(Resource.Id.recycleViewScanReceiveItem);
                mLayoutManager2 = new LinearLayoutManager(this);
                recyclerViewScanItem.SetLayoutManager(mLayoutManager2);

                //modnet.InitializeTCPClient();
                //Button btnBack = FindViewById<Button>(Resource.Id.btnBack);
                //btnBack.Click += (e, a) =>
                //{
                //    this.Finish();
                //};    

                //txtBattery.Enabled = txtTruckNo.Enabled = false;
                txtDelivery.Enabled = false;
                txtBattery.Enabled = false;
                txtDelivery.RequestFocus();
                GetDeliveryData();
            }
            catch (Exception ex)
            {
                clsGLB.ShowMessage(ex.Message, this, MessageTitle.ERROR);
            }
        }



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
                    mediaPlayerSound = MediaPlayer.Create(this, Resource.Raw.SavedSound);
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
        private void SoundForNG()
        {
            try
            {
                Task.Run(() =>
                {
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
        private void GetDeliveryData()
        {
            try
            {
                if (txtDelivery.Text.Length > 0)
                {
                    if ((txtDelivery.Text.Trim().Length != 8))
                    {
                        clsGLB.showToastNGMessage("Invalid Delivery No.", this);
                        SoundForNG();
                    }
                    if (ModNet.FetchBatteryDeliveryData(txtDelivery.Text.Trim()))
                    {
                        BindRecycleView();
                        txtBattery.Enabled = true;
                        txtBattery.RequestFocus();
                    }
                    else
                    {
                        txtBattery.Enabled = false;
                        lblResult.Text = ModInit.Gstrarr[0];
                        txtDelivery.Text = "";
                        // txtDelivery.RequestFocus();
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
        private void BindRecycleView()
        {
            try
            {
                _ListItem.Clear();
                _ListItemFinalSave.Clear();
                selectedSKU = "";
                string[] sArr = ModInit.GstrResult.Split("@");

                for (int i = 0; i < sArr.Length; i++)
                {
                    ModInit.Gstrarr = sArr[i].Split('~');
                    if (ModInit.Gstrarr.Length > 1)
                    {
                        if (ModInit.Gstrarr[1] == "") { continue; }
                        if (ModInit.Gstrarr[3].ToString() != "" && !dicRegPlant.ContainsKey(ModInit.Gstrarr[3].ToString()))
                        {

                            clsGLB.ShowMessage($"This Plant {ModInit.Gstrarr[3].ToString()} is not registered!!!", this, MessageTitle.ERROR);
                            _ListItem.Clear();
                            _ListItemFinalSave.Clear();
                            break;
                        }
                        ViewBatteryData _listBindView = new ViewBatteryData();
                        if (_ListItem.Exists(x => x.BatteryType.Contains(ModInit.Gstrarr[1])))
                        {
                            int iIndex = _ListItem.FindIndex(x => x.BatteryType.Contains(ModInit.Gstrarr[1]));
                            //decimal dQty = Convert.ToDecimal(_ListItem.Find(x => x.BatteryType == ModInit.Gstrarr[2]).Qty);
                            //decimal dSQty = Convert.ToDecimal(_ListItem.Find(x => x.BatteryType == ModInit.Gstrarr[4]).Qty);
                            _ListItem[iIndex].Qty = Convert.ToString(Convert.ToInt32(_ListItem[iIndex].Qty) + Convert.ToInt32(ModInit.Gstrarr[2]));
                            _ListItem[iIndex].ScanQty = Convert.ToString(Convert.ToInt32(_ListItem[iIndex].ScanQty) + Convert.ToInt32(ModInit.Gstrarr[4]));
                            _ListItem[iIndex].Balance = Convert.ToString(Convert.ToInt32(_ListItem[iIndex].Qty) - Convert.ToInt32(_ListItem[iIndex].ScanQty));
                            //_ListItem[iIndex].Qty = Convert.ToString( Convert.ToDecimal(ModInit.Gstrarr[2]));
                            //_ListItem[iIndex].ScanQty = Convert.ToString( Convert.ToDecimal(ModInit.Gstrarr[4]));
                        }
                        else
                        {
                            _listBindView.Qty = ModInit.Gstrarr[2];
                            _listBindView.ScanQty = ModInit.Gstrarr[4];
                            _listBindView.BatteryType = ModInit.Gstrarr[1];
                            _listBindView.ShowBatteryType = ShowMFTypeBttery(ModInit.Gstrarr[1]);
                            _listBindView.Plant = ModInit.Gstrarr[3];
                            txtTruckNo.Text = ModInit.Gstrarr[6];
                            txtTransName.Text = ModInit.Gstrarr[7];
                            //_listBindView.Balance = Convert.ToString(Convert.ToDecimal(_ListItem.Sum(x => Convert.ToDecimal(x.Qty))) - Convert.ToDecimal(_ListItem.Sum(x => Convert.ToDecimal(x.ScanQty))));
                            _listBindView.Balance = Convert.ToString(Convert.ToInt32(ModInit.Gstrarr[2]) - Convert.ToInt32(ModInit.Gstrarr[4]));
                            _ListItem.Add(_listBindView);
                        }


                        _ListItemFinalSave.Add(new ViewBatteryData { BatteryType = ModInit.Gstrarr[1], Qty = ModInit.Gstrarr[2], Plant = ModInit.Gstrarr[3].ToString(), ScanQty = ModInit.Gstrarr[4].ToString(), Balance = Convert.ToString(Convert.ToInt32(ModInit.Gstrarr[2]) - Convert.ToInt32(ModInit.Gstrarr[4])), SKU = ModInit.Gstrarr[5] });
                        //var SelectedItem = _ListItem.Find(x => x.Delivery == ModInit.Gstrarr[0].ToString() && x.SKU == ModInit.Gstrarr[1].ToString());
                        //if (SelectedItem == null)
                        //{
                        //    _ListItem.Add(new ViewBatteryData { Delivery = ModInit.Gstrarr[0], SKU = ModInit.Gstrarr[1], Qty = ModInit.Gstrarr[2], Plant = ModInit.Gstrarr[3].ToString(), ScanQty = ModInit.Gstrarr[4].ToString(), MSG = ModInit.Gstrarr[5].ToString() });
                        //}


                    }
                }
                GetSetTotalAndScanQty();

                receivingItemAdapter = new BatteryItemAdapter(this, _ListItem);
                recyclerViewItem.SetAdapter(receivingItemAdapter);
                receivingItemAdapter.NotifyDataSetChanged();
                //RecyclerView recyclerView = (RecyclerView)view.findViewById(R.id.recyclerView);

            }
            catch (Exception ex) { throw ex; }
        }

        private void BindRecycleScannedView(string strBatteryNo, string strSKU)
        {
            try
            {

                if (!_ListScanItem.Exists(x => x.BatteryType == strBatteryNo))
                {

                    _SrNoCounter = _SrNoCounter + 1;
                    _ListScanItem.Add(new ViewBatteryScanData { SrNo = _SrNoCounter.ToString(), Delivery = txtDelivery.Text.Trim(), BatteryType = strBatteryNo, SKU = strSKU });
                    //_ListScanItem = _ListScanItem.OrderByDescending(x => x.SrNo).ToList();
                    receivingScanItemAdapter = new BatteryScanItemAdapter(this, _ListScanItem);
                    receivingScanItemAdapter.btnClick += RecyclerViewScanItem_Click;
                    recyclerViewScanItem.SetAdapter(receivingScanItemAdapter);
                    recyclerViewScanItem.SmoothScrollToPosition(receivingScanItemAdapter.ItemCount);
                    receivingScanItemAdapter.NotifyDataSetChanged();
                }
                //RecyclerView recyclerView = (RecyclerView)view.findViewById(R.id.recyclerView);

            }
            catch (Exception ex) { throw ex; }
        }
        private void UpdateMainRecycleViewScanQty(string strBatteryType)
        {
            try
            {

                if (_ListItem.Exists(x => x.BatteryType.Contains(strBatteryType)))
                {

                    int iIndex = _ListItem.FindIndex(x => x.BatteryType.Contains(strBatteryType));
                    for (int i = 0; i < _ListItem.Count; i++)
                    {
                        if (_ListItem[i].BatteryType.Contains(strBatteryType) && Convert.ToInt32(_ListItem[i].Balance) > 0)
                        {
                            _ListItem[i].ScanQty = Convert.ToString(Convert.ToInt32(_ListItem[i].ScanQty) + Convert.ToInt32(1));
                            _ListItem[i].Balance = Convert.ToString(Convert.ToInt32(_ListItem[i].Qty) - Convert.ToInt32(_ListItem[i].ScanQty));
                            // _ScanQty += 1;
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
        private void UpdateFinalListScanQty(string strBatteryType, string strSKU)
        {
            try
            {

                if (_ListItemFinalSave.Exists(x => x.BatteryType.Contains(strBatteryType) && x.SKU == strSKU))
                {
                    for (int i = 0; i < _ListItemFinalSave.Count; i++)
                    {
                        //if (_ListItemFinalSave[i].BatteryType.Contains(strBatteryType) && _ListItemFinalSave[i].SKU == strSKU && Convert.ToInt32(_ListItemFinalSave[i].Balance) > 0)
                        if (_ListItemFinalSave[i].BatteryType.Contains(strBatteryType) && Convert.ToInt32(_ListItemFinalSave[i].Balance) > 0)
                        {
                            _ListItemFinalSave[i].ScanQty = Convert.ToString(Convert.ToInt32(_ListItemFinalSave[i].ScanQty) + Convert.ToInt32(1));
                            _ListItemFinalSave[i].Balance = Convert.ToString(Convert.ToInt32(_ListItemFinalSave[i].Qty) - Convert.ToInt32(_ListItemFinalSave[i].ScanQty));
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
        private void RemoveMainRecycleViewScanQty(string strBatteryType)
        {
            try
            {

                if (_ListItem.Exists(x => x.BatteryType.Contains(strBatteryType)))
                {

                    int iIndex = _ListItem.FindIndex(x => x.BatteryType.Contains(strBatteryType));
                    for (int i = 0; i < _ListItem.Count; i++)
                    {
                        if (_ListItem[i].BatteryType.Contains(strBatteryType))
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

        private void RemoveFinalRecycleViewScanQty(string strBatteryType)
        {
            try
            {
                string sku = getBatteryRemoveSKU(strBatteryType);

                if (_ListItemFinalSave.Exists(x => x.BatteryType.Contains(strBatteryType)))
                {

                    int iIndex = _ListItemFinalSave.FindIndex(x => x.BatteryType.Contains(strBatteryType));
                    for (int i = 0; i < _ListItemFinalSave.Count; i++)
                    {
                        //if (_ListItemFinalSave[i].BatteryType.Contains(strBatteryType) && _ListItemFinalSave[i].SKU == sku)
                        if (_ListItemFinalSave[i].BatteryType.Contains(strBatteryType) && Convert.ToInt32(_ListItemFinalSave[i].ScanQty) != 0)
                        {
                            _ListItemFinalSave[i].ScanQty = Convert.ToString(Convert.ToInt32(_ListItemFinalSave[i].ScanQty) - Convert.ToInt32(1));
                            _ListItemFinalSave[i].Balance = Convert.ToString(Convert.ToInt32(_ListItemFinalSave[i].Qty) - Convert.ToInt32(_ListItemFinalSave[i].ScanQty));

                            break;
                        }
                    }
                    //  _ScanQty = _ListScanItem.Count;
                    receivingItemAdapter.NotifyDataSetChanged();
                    GetSetTotalAndScanQty();
                    txtScanQty.Text = "Scan Qty : " + _ScanQty.ToString();
                }
                //RecyclerView recyclerView = (RecyclerView)view.findViewById(R.id.recyclerView);

            }
            catch (Exception ex) { throw ex; }

        }

        private void RecyclerViewScanItem_Click(object sender, int e)
        {
            try
            {
                var objData = receivingScanItemAdapter.data[e];
                _ListScanItem.Remove(objData);
                _SrNoCounter = 0;
                if (_ListScanItem.Count > 0)
                {
                    int iMax = _ListScanItem.Count + 1;
                    _SrNoCounter = iMax;
                    for (int i = 0; i < _ListScanItem.Count; i++)
                    {
                        _SrNoCounter = _SrNoCounter - 1;
                        _ListScanItem[i].SrNo = Convert.ToString(_SrNoCounter);
                    }
                }
                recyclerViewScanItem.SmoothScrollToPosition(receivingScanItemAdapter.ItemCount);
                receivingScanItemAdapter.NotifyDataSetChanged();
                _SrNoCounter = Convert.ToInt32(_ListScanItem.Max(x => x.SrNo));
                //_ScanQty = _ListScanItem.Count;
                //txtScanQty.Text = "Scan Qty : " + _ScanQty.ToString();
                var batteryType = _dicBatteryScanningData[objData.BatteryType];
                RemoveMainRecycleViewScanQty(batteryType);
                RemoveFinalRecycleViewScanQty(batteryType);
                _dicBatteryScanningData.Remove(objData.BatteryType);
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

                bool bReturn = false;
                for (int i = 0; i < _ListScanItem.Count; i++)
                {
                    bReturn = ModNet.BatteryScanningDataSave(txtDelivery.Text.Trim(), _ListScanItem[i].SKU, _ListScanItem[i].BatteryType);
                }
                if (bReturn)
                {

                    lblResult.Text = $"This Delivery ({txtDelivery.Text.Trim()}) Data Saved Successfully!!!";
                    clsGLB.ShowMessage($"This Delivery ({txtDelivery.Text.Trim()}) Data Saved Successfully!!!", this, MessageTitle.INFORMATION);
                    txtBattery.Text = "";
                    txtBattery.RequestFocus();

                    clear();
                    this.Finish();
                    OpenActivity(typeof(BatteryScanningMainActivity));
                }
                else
                {
                    lblResult.Text = ModInit.Gstrarr[0];
                    txtBattery.Text = "";
                    txtBattery.RequestFocus();
                    SoundForNG();
                }
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

        //private string GetBtteryBarcode(string scannedBarcode)
        //{
        //    string finalBatterybarcode = string.Empty;
        //    try
        //    {
        //        //Single Barcode only Exide
        //        if (scannedBarcode.Length == 15)
        //        {
        //            finalBatterybarcode += scannedBarcode.Substring(0,11) + "$";
        //        }
        //        else
        //        {
        //            //MasterBarcode For Both and Amron For single
        //            string[] sArr = scannedBarcode.Split('&');
        //            for (int i = 0; i < sArr.Length - 1; i++)
        //            {
        //                if (sArr[i].Length == 11)
        //                {
        //                    finalBatterybarcode += sArr[i].ToString() + "$";
        //                }

        //            }
        //        }
        //        finalBatterybarcode = finalBatterybarcode.TrimEnd('$');

        //    }
        //    catch (Exception ex)
        //    {

        //        throw ex;
        //    }
        //    return finalBatterybarcode;
        //}
        private string GetBtteryBarcode(string scannedBarcode)
        {
            string finalBatterybarcode = string.Empty;
            try
            {
                //Single Barcode only Exide  61 and 77
                if (scannedBarcode.Split(' ').Length > 3)
                {
                    string[] sArr = scannedBarcode.Split(' ');
                    for (int i = 0; i < sArr.Length - 1; i++)
                    {
                        if (sArr[i].Length == 11)
                        {
                            finalBatterybarcode += sArr[i].ToString() + "$";
                        }

                    }
                }
                else if (scannedBarcode.Length == 11 || scannedBarcode.Length == 10)
                {
                    finalBatterybarcode = scannedBarcode.TrimEnd('$');
                }
                else
                {
                    //MasterBarcode For Both and Amron For single 141
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
        private string GetShortNameBatteryType(string strType)
        {
            //FEX0-ETZ4
            //ATZ4L
            //FEX0-ETZ3
            //ATZ3L
            string str = "";
            if (strType.Length == 9)
                str = strType.Substring(strType.Length - 2, 2);
            else if (strType.Length == 5)
                str = strType.Substring(2, 2);
            else
                str = strType;
            return str;
        }
        private string GetBtteryType(string scannedBarcode)
        {
            string finalBatteryType = string.Empty;
            try
            {
                //Single Barcode only Exide  61 and 77
                if (scannedBarcode.Split(' ').Length > 3)
                {
                    string[] sArr = scannedBarcode.Split(' ');
                    for (int i = 0; i < sArr.Length - 1; i++)
                    {
                        if (sArr[i].Contains("-"))
                        {
                            finalBatteryType = sArr[i].ToString() + "$";
                            break;
                        }
                        else if (sArr[i].StartsWith("AT"))
                        {
                            finalBatteryType = sArr[i].ToString() + "$";
                            break;
                        }

                    }
                }
                else
                {
                    //MasterBarcode For Both and Amron For single 141
                    string[] sArr = scannedBarcode.Split('&');
                    for (int i = 0; i < sArr.Length - 1; i++)
                    {
                        if (sArr[i].Contains("-"))
                        {
                            finalBatteryType = sArr[i].ToString() + "$";
                            break;
                        }
                        else if (sArr[i].StartsWith("AT"))
                        {
                            finalBatteryType = sArr[i].ToString() + "$";
                            break;
                        }

                    }

                }

                finalBatteryType = finalBatteryType.TrimEnd('$');
                finalBatteryType = GetShortNameBatteryType(finalBatteryType);

            }
            catch (Exception ex)
            {

                throw ex;
            }
            return finalBatteryType;
        }
        private string GetBtteryTypeFromSAP(string scannedBarcode)
        {
            string finalBatteryType = string.Empty;
            try
            {
                string[] sArr = scannedBarcode.Split('$');
                for (int i = 0; i < sArr.Length; i++)
                {
                    string sBarcode = sArr[i];
                    if (ModNet.GetBatteryTypeData(sBarcode, ref finalBatteryType))
                    {
                        finalBatteryType = finalBatteryType.TrimEnd('$');
                        finalBatteryType = GetShortNameBatteryType(finalBatteryType);
                    }
                    else
                    {
                        finalBatteryType = "";
                    }


                    break;

                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
            return finalBatteryType;
        }
        private string ShowMFTypeBttery(string strBatteryType)
        {
            string finalBatteryType = string.Empty;
            try
            {

                finalBatteryType = GetShortNameBatteryType(strBatteryType);
                if (finalBatteryType.StartsWith("Z"))
                {
                    finalBatteryType = "MF-" + finalBatteryType.Substring(finalBatteryType.Length - 1);
                }

            }
            catch (Exception ex)
            {

                throw ex;
            }
            return finalBatteryType;
        }
        private string getBatteryRemoveSKU(string strBatteryType)
        {
            string strSKU = string.Empty;
            if (_ListItemFinalSave.Count > 0)
            {
                for (int i = 0; i < _ListItemFinalSave.Count; i++)
                {
                    if (_ListItemFinalSave[i].BatteryType.Contains(strBatteryType))
                    {
                        strSKU = strSKU + _ListItemFinalSave[i].SKU + "~";
                        break;
                    }
                }
            }
            return strSKU.TrimEnd('~');
        }
        private string getBatterySKU(string strBatteryType)
        {
            string strSKU = string.Empty;
            if (_ListItemFinalSave.Count > 0)
            {
                for (int i = 0; i < _ListItemFinalSave.Count; i++)
                {
                    if (_ListItemFinalSave[i].BatteryType.Contains(strBatteryType) && _ListItemFinalSave[i].Qty != _ListItemFinalSave[i].ScanQty)
                    {
                        strSKU = strSKU + _ListItemFinalSave[i].SKU + "~";
                        break;
                    }
                }
            }
            return strSKU.TrimEnd('~');
        }


        //private void TxtBattery_KeyPress(object sender, View.KeyEventArgs e)
        //{
        //    try
        //    {
        //        if (e.Event.Action == KeyEventActions.Down)
        //        {
        //            if (e.KeyCode == Keycode.Enter)
        //            {
        //                //DismissKeyboard();

        //                if (ValidateControls())
        //                {
        //                    lblResult.Text = "";
        //                    string strBatteryType = GetBtteryType(txtBattery.Text.Trim());
        //                    if (string.IsNullOrEmpty(strBatteryType))
        //                    {
        //                        Toast.MakeText(this, "This type is not available in this Delivery.", ToastLength.Long).Show();
        //                        txtBattery.Text = "";
        //                        txtBattery.RequestFocus();
        //                        return;
        //                    }

        //                    string strBatteryBarcode = GetBtteryBarcode(txtBattery.Text.Trim());
        //                    if (string.IsNullOrEmpty(strBatteryBarcode))
        //                    {
        //                        Toast.MakeText(this, "Invalid Battery Barcode.", ToastLength.Long).Show();
        //                        txtBattery.Text = "";
        //                        txtBattery.RequestFocus();
        //                        return;
        //                    }
        //                    if (ModNet.BatteryScanningDataSave(selectedSKU, txtDelivery.Text.Trim(), "HR26AG1234", strBatteryBarcode))
        //                    {
        //                        for (int i = 0; i < _ListItem.Count; i++)
        //                        {
        //                            if (_ListItem[i].chkCheck)
        //                            {
        //                                string[] strScannedQty = strBatteryBarcode.Split('$'); //Length
        //                                _ListItem[i].ScanQty = Convert.ToString(Convert.ToDecimal(_ListItem[i].ScanQty) + strScannedQty.Length);
        //                                _ListItem[i].MSG = "OK";
        //                                receivingItemAdapter.NotifyDataSetChanged();
        //                                break;
        //                            }
        //                        }
        //                        lblResult.Text = "Last Battery : " + strBatteryBarcode.Trim();
        //                        txtBattery.Text = "";
        //                        txtBattery.RequestFocus();
        //                        //dispatchcunt++;
        //                        //lblCount.Text = dispatchcunt.ToString();
        //                    }
        //                    else
        //                    {
        //                        lblResult.Text = ModInit.Gstrarr[0];
        //                        txtBattery.Text = "";
        //                        txtBattery.RequestFocus();
        //                    }
        //                }
        //            }
        //            else
        //                e.Handled = false;
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        clsGLB.ShowMessage(ex.Message, this, MessageTitle.ERROR);

        //    }
        //}


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
                            string strBatteryBarcode = GetBtteryBarcode(txtBattery.Text.Trim());
                            if (string.IsNullOrEmpty(strBatteryBarcode))
                            {
                                clsGLB.showToastNGMessage("Invalid Battery Barcode.", this);
                                txtBattery.Text = "";
                                txtBattery.RequestFocus();
                                SoundForNG();
                                return;
                            }
                            //string strBatteryType = GetBtteryType(txtBattery.Text.Trim());
                             string strBatteryType= GetBtteryTypeFromSAP(strBatteryBarcode);
                            if (string.IsNullOrEmpty(strBatteryType))
                            {
                                clsGLB.showToastNGMessage($"Invalid Battery Type", this);
                                txtBattery.Text = "";
                                txtBattery.RequestFocus();
                                SoundForNG();
                                return;
                            }


                            if (!_ListItem.Exists(x => x.BatteryType == strBatteryType))
                            {
                                clsGLB.showToastNGMessage("This battery is not belongs to listed battery type!!!", this);
                                txtBattery.Text = "";
                                txtBattery.RequestFocus();
                                SoundForNG();
                                return;
                            }
                            #region Old Complete Battery Scanning Code
                            //if (_ListItemFinalSave.Count > 0)
                            //{
                            //    bool bCheck = false;
                            //    for (int i = 0; i < _ListItemFinalSave.Count; i++)
                            //    {
                            //        if (_ListItemFinalSave[i].BatteryType.Contains(strBatteryType.TrimEnd()) && Convert.ToInt32(Convert.ToInt32(_ListItemFinalSave[i].Balance)) == 0)
                            //        {
                            //            bCheck = true;
                            //            continue;
                            //        }
                            //        else if (_ListItemFinalSave[i].BatteryType.Contains(strBatteryType.TrimEnd()) && Convert.ToInt32(Convert.ToInt32(_ListItemFinalSave[i].Balance)) > 0)
                            //        {
                            //            bCheck = false;
                            //        }
                            //    }
                            //    if (bCheck)
                            //    {
                            //        clsGLB.showToastNGMessage("This Battery type scanning alreayd completed!!", this);
                            //        txtBattery.Text = "";
                            //        txtBattery.RequestFocus();
                            //        SoundForNG();
                            //        return;
                            //    }

                            //}
                            //else
                            //{
                            //    clsGLB.showToastNGMessage("No data available for battery scanning!!", this);
                            //    txtBattery.Text = "";
                            //    txtBattery.RequestFocus();
                            //    SoundForNG();
                            //    return;
                            //}
                            #endregion

                            #region Old Greater Than Validataion
                            //if (_ListItemFinalSave.Count > 0)
                            //{
                            //    bool bCheck = false;
                            //    List<ViewBatteryData> _ListFinalCheck = _ListItemFinalSave.FindAll(x => x.BatteryType.Contains(strBatteryType.TrimEnd()));
                            //    for (int i = 0; i < _ListFinalCheck.Count; i++)
                            //    {
                            //        if (_ListItemFinalSave[i].BatteryType.Contains(strBatteryType.TrimEnd()) &&
                            //            Convert.ToInt32(Convert.ToDecimal(_ListItemFinalSave[i].Balance)) > 0 &&
                            //            strBatteryBarcode.Split('$').Length >= Convert.ToInt32(Convert.ToDecimal(_ListItemFinalSave[i].Balance)))
                            //        {
                            //            bCheck = true;
                            //            if (strBatteryBarcode.Split('$').Length == Convert.ToInt32(Convert.ToDecimal(_ListFinalCheck[i].Balance)))
                            //            {
                            //                bCheck = false;
                            //                break;
                            //            }
                            //            else if (Convert.ToInt32(Convert.ToDecimal(_ListFinalCheck[i].Balance)) >= strBatteryBarcode.Split('$').Length)
                            //            {
                            //                bCheck = false;
                            //                break;
                            //            }
                            //            else
                            //            {
                            //                continue;
                            //            }
                            //        }

                            //        else
                            //        {
                            //            bCheck = false;
                            //        }
                            //    }
                            //    if (bCheck)
                            //    {
                            //        clsGLB.showToastNGMessage($"This battery type {strBatteryType} balance qty is greater than scanned battery !!", this);
                            //        txtBattery.Text = "";
                            //        txtBattery.RequestFocus();
                            //        SoundForNG();
                            //        return;
                            //    }


                            //}
                            #endregion

                            if (_ListItem.Count > 0)
                            {
                                List<ViewBatteryData> _ListScanCheck = _ListItem.FindAll(x => x.BatteryType.Contains(strBatteryType.TrimEnd()));
                                if (_ListScanCheck.Exists(x => Convert.ToInt32(x.Balance) == 0))
                                {
                                    clsGLB.showToastNGMessage("This Battery type scanning alreayd completed!!", this);
                                    txtBattery.Text = "";
                                    txtBattery.RequestFocus();
                                    SoundForNG();
                                    return;
                                }
                                if (_ListScanCheck.Exists(x => Convert.ToInt32(x.Balance) < strBatteryBarcode.Split('$').Length))
                                {
                                    clsGLB.showToastNGMessage($"This battery type {strBatteryType} balance qty is greater than scanned battery !!", this);
                                    txtBattery.Text = "";
                                    txtBattery.RequestFocus();
                                    SoundForNG();
                                    return;
                                }

                            }
                            else
                            {
                                clsGLB.showToastNGMessage("No data available for battery scanning!!", this);
                                txtBattery.Text = "";
                                txtBattery.RequestFocus();
                                SoundForNG();
                                return;
                            }
                            if (_ListScanItem.Count > 0)
                            {
                                string[] sBarrcode = strBatteryBarcode.Split('$');
                                for (int i = 0; i < sBarrcode.Length; i++)
                                {
                                    if (_ListScanItem.Exists(x => x.BatteryType.Contains(sBarrcode[i])))
                                    {
                                        clsGLB.showToastNGMessage($"This battery barcode already {sBarrcode[i]} scanned !!", this);
                                        txtBattery.Text = "";
                                        txtBattery.RequestFocus();
                                        SoundForNG();
                                        return;
                                    }
                                }

                            }
                            string[] strSKU = getBatterySKU(strBatteryType).Split('~');
                            for (int iSKU = 0; iSKU < strSKU.Length; iSKU++)
                            {
                                string[] sArr = strBatteryBarcode.Split('$');
                                for (int i = 0; i < sArr.Length; i++)
                                {
                                    string sBarcode = sArr[i];
                                    string strFinalSKU = getBatterySKU(strBatteryType).Split('~')[0];
                                    //if (ModNet.ValidateBatteryDataTemp(txtDelivery.Text.Trim(), strSKU[iSKU], sBarcode)) 
                                    ///Now i have changed *strSKU[iSKU]-  strFinalSKU
                                    if (ModNet.ValidateBatteryData(txtDelivery.Text.Trim(), strFinalSKU, sBarcode))
                                    {
                                        if (!_dicBatteryScanningData.ContainsKey(sBarcode))
                                        {
                                            _dicBatteryScanningData.Add(sBarcode, strBatteryType);
                                        }
                                        BindRecycleScannedView(sBarcode, strFinalSKU);
                                        UpdateMainRecycleViewScanQty(strBatteryType);
                                        UpdateFinalListScanQty(strBatteryType, strFinalSKU);
                                        if (_ListScanItem.Count > 0)
                                        {
                                            if (_TotalQty == _ScanQty)
                                            {
                                                FinalSaveData();
                                            }
                                        }
                                        txtBattery.Text = "";
                                        txtBattery.RequestFocus();

                                    }
                                    else
                                    {
                                        txtBattery.Text = "";
                                        lblResult.Text = ModInit.Gstrarr[0];
                                        txtBattery.RequestFocus();
                                        SoundForNG();
                                    }
                                    //if (_ListScanItem.Count > 0)
                                    //{
                                    //    if (_ListScanItem.Exists(x => x.BatteryType == sBarcode.TrimEnd()))
                                    //    {
                                    //        Toast.MakeText(this, "Already Scanned Battery Barcode.", ToastLength.Long).Show();
                                    //        txtBattery.Text = "";
                                    //        txtBattery.RequestFocus();
                                    //        continue;

                                    //    }

                                    //}


                                }


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
        private void BtnFinalSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (_TotalQty == _ScanQty && _TotalQty > 0 && _ScanQty > 0)
                {
                    FinalSaveData();
                }

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
                OpenActivity(typeof(BatteryScanningMainActivity));
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
                        GetDeliveryData();
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
                    clsGLB.showToastNGMessage($"Input Delivery No.", this);
                    txtDelivery.RequestFocus();
                    IsValidate = false;
                    SoundForNG();
                }

                else if (string.IsNullOrEmpty(txtBattery.Text.Trim()))
                {
                    clsGLB.showToastNGMessage($"Scan Battery Barcode.", this);
                    txtBattery.Text = "";
                    txtBattery.RequestFocus();
                    IsValidate = false;
                    SoundForNG();
                }
                //else if (txtBattery.Text.Trim().Length != 65
                //    && txtBattery.Text.Trim().Length != 76
                //     && txtBattery.Text.Trim().Length != 77
                //    && txtBattery.Text.Trim().Length != 144
                //    && txtBattery.Text.Trim().Length != 140
                //     && txtBattery.Text.Trim().Length != 133
                //    && txtBattery.Text.Trim().Length != 59
                //     && txtBattery.Text.Trim().Length != 34
                //    && txtBattery.Text.Trim().Length != 11
                //    && txtBattery.Text.Trim().Length != 10)
                //{
                //    clsGLB.showToastNGMessage($"Invalid Battery Barcode.", this);
                //    txtBattery.Text = "";
                //    txtBattery.RequestFocus();
                //    IsValidate = false;
                //    SoundForNG();
                //}
                else if (_ListItem.Count == 0)
                {
                    clsGLB.showToastNGMessage($"Delivery Data is not Available", this);
                    txtBattery.Text = "";
                    txtBattery.RequestFocus();
                    IsValidate = false;
                    SoundForNG();
                }

                return IsValidate;
            }
            catch (Exception ex) { throw ex; }
        }

        private void clear()
        {
            //txtTruckNo.Text = "Truck No:        ";
            //txtTransName.Text = "";
            //txtBattery.Enabled = false;
            if (_dicBatteryScanningData.Count > 0)
                _dicBatteryScanningData.Clear();
            //txtDelivery.Text = "";
            // _TotalQty = 0;
            _ScanQty = 0;
            txtBattery.Text = "";
            lblResult.Text = "";
            // txtDelivery.Enabled = true;
            selectedSKU = "";
            if (_ListScanItem.Count > 0)
                _ListScanItem.Clear();
            //if (_ListItem.Count > 0)
            //    _ListItem.Clear();
            for (int i = 0; i < _ListItem.Count; i++)
            {
                _ListItem[i].ScanQty = "0";
                _ListItem[i].Balance = _ListItem[i].Qty;
            }
            receivingItemAdapter.NotifyDataSetChanged();
            if (receivingScanItemAdapter != null)
                receivingScanItemAdapter.NotifyDataSetChanged();
            txtTotalQty.Text = "Total Qty : " + _TotalQty.ToString();
            txtScanQty.Text = "Scan Qty : " + _ScanQty.ToString();
            txtBattery.RequestFocus();
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