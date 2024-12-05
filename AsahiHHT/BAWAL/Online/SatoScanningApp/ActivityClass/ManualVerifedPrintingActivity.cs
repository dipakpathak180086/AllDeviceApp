using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.Media;
using Android.OS;
using Android.Support.V7.App;
using Android.Support.V7.Widget;
using Android.Views;
using Android.Widget;

using IOCLAndroidApp;
using IOCLAndroidApp.Models;
using AISScanningApp.Adapter;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AISScanningApp
{
    [Activity(Label = "AIS ScanningApp", WindowSoftInputMode = SoftInput.StateHidden, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation, ScreenOrientation = ScreenOrientation.Portrait)]
    public class ManualVerifedPrintingActivity : AppCompatActivity
    {
        private clsGlobal clsGLB;
        private clsNetwork oNetwork;
        private MediaPlayer mediaPlayerSound;
        private Vibrator vibrator;
        private List<Part> _ListPartNo = new List<Part>();
        private Spinner spinnerPartNo,spinnerRemarks;
        
        private TextView txtMsg;
        private Button btnReset, btnSave;
        private RecyclerView recycleViewPicking;
        private PickingAdapter pickingAdapter;
        private RecyclerView.LayoutManager mLayoutManager;

        public ManualVerifedPrintingActivity()
        {
            try
            {
                clsGLB = new clsGlobal();
                oNetwork = new clsNetwork();
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
                SetContentView(Resource.Layout.activity_ManualVerifiedPrinting);
                vibrator = this.GetSystemService(VibratorService) as Vibrator;
                ImageView imgBack = FindViewById<ImageView>(Resource.Id.imgBack);
                imgBack.Click += (e, a) =>
                {
                    this.Finish();
                };

                TextView txtHeader = FindViewById<TextView>(Resource.Id.txtHeader);
                txtHeader.Text = clsGlobal.Process_Header_Text;

                txtMsg = FindViewById<TextView>(Resource.Id.txtMsg);
                txtMsg.Text = "";

                spinnerPartNo = FindViewById<Spinner>(Resource.Id.spinnerPartNo);
                spinnerPartNo.ItemSelected += spinnerPartNo_ItemSelected;

                spinnerRemarks = FindViewById<Spinner>(Resource.Id.spinnerRemark);


                btnSave = FindViewById<Button>(Resource.Id.btnSave);
                btnSave.Click += btnSave_Click;

                btnReset = FindViewById<Button>(Resource.Id.btnReset);
                btnReset.Click += BtnReset_Click;

                spinnerPartNo.Enabled = true;
                spinnerRemarks.Enabled = false;
                GetRemarkList();
                GetPartNoAsync();
               
                spinnerPartNo.RequestFocus();
            }
            catch (Exception ex)
            {
                clsGLB.ShowMessage(ex.Message, this, MessageTitle.ERROR);
            }
        }



        #endregion

        #region Spinner Events
        private void spinnerPartNo_ItemSelected(object sender, AdapterView.ItemSelectedEventArgs e)
        {
            try
            {
                if (spinnerPartNo.SelectedItemPosition > 0)
                {
                    spinnerPartNo.Enabled = false;
                    spinnerRemarks.Enabled = true;
                    spinnerRemarks.RequestFocus();
                }
            }
            catch (Exception ex)
            {
                clsGLB.ShowMessage(ex.Message, this, MessageTitle.ERROR);
            }
        }
        #endregion

        #region Button Events
        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (IsValidPart())
                {

                    SaveDataAsync();
                }
               
            }
            catch (Exception ex)
            {
                StartPlayingSound();
                ShowMessageBox("Error : " + ex.Message, this);
            }
        }

        private void BtnReset_Click(object sender, EventArgs e)
        {
            try
            {
                Clear();
                GetPartNoAsync();
            }
            catch (Exception ex)
            {
                clsGLB.ShowMessage(ex.Message, this, MessageTitle.ERROR);
            }
        }

        #endregion

        #region EditText Events

        private void editItemBarcode_KeyPress(object sender, View.KeyEventArgs e)
        {
           
        }

      
        public override void OnBackPressed()
        {
        }

        #endregion

        #region RecycleView

        private void BindRecycleView()
        {
            try
            {
                pickingAdapter = new PickingAdapter(_ListPartNo, this);
                pickingAdapter.ItemClick += PickingAdapter_ItemClick;
                recycleViewPicking.SetAdapter(pickingAdapter);
            }
            catch (Exception ex)
            {
                clsGLB.ShowMessage(ex.Message, this, MessageTitle.ERROR);
            }
        }

        private void PickingAdapter_ItemClick(object sender, int e)
        {
            try
            {
            }
            catch (Exception ex)
            {
                clsGLB.ShowMessage(ex.Message, this, MessageTitle.ERROR);
            }
        }

        #endregion

        #region Methods

        private void GetRemarkList()
        {
            try
            {

                List<string> _List = new List<string>();

                _List.Add("--Select--");
                _List.Add("Print-Cut");
                _List.Add("Scanning Miss");
                _List.Add("Setup Rejection");
                ArrayAdapter<string> arrayAdapter = new ArrayAdapter<string>(this, Resource.Layout.Spiner, _List);
                spinnerRemarks.Adapter = arrayAdapter;
                spinnerRemarks.SetSelection(0);
                spinnerRemarks.RequestFocus();
            }

            catch (Exception ex)
            {
                clsGLB.ShowMessage(ex.Message, this, MessageTitle.ERROR);

            }
            finally
            {

            }
            
        }

        private async Task<string> GetPartNoAsync()
        {
            var progressDialog = ProgressDialog.Show(this, "", "Please wait...", true);
            try
            {
                clsGlobal.Db_Type = "BIND_PART";
                string[] _RESPONSE = await Task.Run(() => SendDataToServer());

                progressDialog.Hide();
                List<string> _ListPickListNo = new List<string>();
                switch (_RESPONSE[0])
                {
                    case "VALID":
                        _ListPickListNo.Add("--Select--");
                        string[] ArrRow = _RESPONSE[1].Split("#");
                        for (int i = 0; i < ArrRow.Length; i++)
                        {
                            string[] ArrCol = ArrRow[i].Split("$");

                            for (int J = 0; J < ArrCol.Length; J++)
                            {

                                _ListPickListNo.Add(ArrCol[J]);
                            }
                        }
                        ArrayAdapter<string> arrayAdapter = new ArrayAdapter<string>(this, Resource.Layout.Spiner, _ListPickListNo);
                        spinnerPartNo.Adapter = arrayAdapter;
                        spinnerPartNo.SetSelection(0);
                        spinnerPartNo.RequestFocus();
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
                progressDialog.Hide();
            }
            finally
            {
                progressDialog.Hide();
            }
            return "";
        }

        private void GetPartNoAfterComplete()
        {
            try
            {
                clsGlobal.Db_Type = "BIND_PARTNO";
                string[] _RESPONSE =SendDataToServer();
                List<string> _ListPickListNo = new List<string>();
                switch (_RESPONSE[0])
                {
                    case "VALID":
                        _ListPickListNo.Add("--Select--");
                        string[] ArrRow = _RESPONSE[1].Split("#");
                        for (int i = 0; i < ArrRow.Length; i++)
                        {
                            string[] ArrCol = ArrRow[i].Split("$");

                            for (int J = 0; J < ArrCol.Length; J++)
                            {

                                _ListPickListNo.Add(ArrCol[J]);
                            }
                        }
                        ArrayAdapter<string> arrayAdapter = new ArrayAdapter<string>(this, Resource.Layout.Spiner, _ListPickListNo);
                        spinnerPartNo.Adapter = arrayAdapter;
                        spinnerPartNo.SetSelection(0);
                        spinnerPartNo.RequestFocus();
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

        private string[] SendDataToServer()
        {
            try
            {
                string _MESSAGE = "MANUALLY_VERIFIED~" + clsGlobal.Db_Type + "~" + spinnerPartNo.SelectedItem + "~"  + spinnerRemarks.SelectedItem.ToString().Trim()+ "~" + clsGlobal.UserId+"}";
                string[] _RESPONSE = oNetwork.fnSendReceiveData(_MESSAGE).Split('~');
                return _RESPONSE;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
       
        private async Task<string> GetPartDataAsync()
        {
            var progressDialog = ProgressDialog.Show(this, "", "Please wait...", true);
            try
            {
                _ListPartNo.Clear();
                clsGlobal.Db_Type = "BIND_PART";
                string[] _RESPONSE = await Task.Run(() => SendDataToServer());

                progressDialog.Hide();

                switch (_RESPONSE[0])
                {
                    case "VALID":
                        string[] ArrRow = _RESPONSE[1].Split("#");
                        for (int i = 0; i < ArrRow.Length; i++)
                        {
                            string[] ArrCol = ArrRow[i].Split("$");
                            _ListPartNo.Add(new Part
                            {
                                PartNo = ArrCol[0]
                            });
                        }
                        
                        break;

                    case "INVALID":
                      
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
                //Refresh the list
                pickingAdapter.NotifyDataSetChanged();
            }
            catch (Exception ex)
            {
                clsGLB.ShowMessage(ex.Message, this, MessageTitle.ERROR);
                progressDialog.Hide();
            }
            finally
            {
                progressDialog.Hide();
            }
            return "";
        }

        

    
        private async void SaveDataAsync()
        {
            var progressDialog = ProgressDialog.Show(this, "", "Please wait...", true);
            try
            {
                clsGlobal.Db_Type = "MANUALLY_SAVE";
                txtMsg.Text = "";
                string[] _RESPONSE = await Task.Run(() => SendDataToServer());

                progressDialog.Hide();

                switch (_RESPONSE[0])
                {
                    case "VALID":
                        txtMsg.Text = _RESPONSE[1].Trim();
                        spinnerRemarks.SetSelection(0);
                        break;
                   
                    case "INVALID":

                        spinnerRemarks.SetSelection(0);
                        StartPlayingSound();
                        ShowMessageBox(_RESPONSE[1], this);
                        break;

                    case "ERROR":

                        spinnerRemarks.SetSelection(0);
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
                progressDialog.Hide();
            }
            finally
            {
                progressDialog.Hide();
            }
        }

      

        public void ShowConfirmBox(string msg, Activity activity, EventHandler<DialogClickEventArgs> handler)
        {
            Android.App.AlertDialog.Builder builder = new Android.App.AlertDialog.Builder(activity);
            builder.SetTitle("Message");
            builder.SetMessage(msg);
            builder.SetCancelable(false);
            builder.SetPositiveButton("Yes", handler);
            builder.SetNegativeButton("No", handllerCancelButton);
            builder.Show();
        }
        private void handllerCancelButton(object sender, DialogClickEventArgs e)
        {
            try
            {

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
            builder.Show();
        }

        private void handleOkMessage(object sender, DialogClickEventArgs e)
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

        private void Clear()
        {
            try
            {

                spinnerRemarks.SetSelection(0);
                txtMsg.Text = "";
                spinnerRemarks.Enabled = false;
                spinnerPartNo.Enabled = true;
                spinnerRemarks.RequestFocus();
               
                _ListPartNo.Clear();
               
            }
            catch (Exception ex)
            {
                clsGLB.ShowMessage(ex.Message, this, MessageTitle.ERROR);
            }
        }

       


        private bool IsValidPart()
        {
            try
            {
                if (spinnerPartNo.SelectedItemPosition <= 0)
                {
                    StartPlayingSound();
                    ShowMessageBox("Select Part No", this);
                    spinnerPartNo.RequestFocus();
                    return false;
                }
                if (spinnerRemarks.SelectedItemPosition <= 0)
                {
                    StartPlayingSound();
                    ShowMessageBox("Select Remark", this);
                    spinnerPartNo.RequestFocus();
                    return false;
                }

                return true;
            }
            catch (Exception ex) { throw ex; }
        }

        #endregion
    }
}