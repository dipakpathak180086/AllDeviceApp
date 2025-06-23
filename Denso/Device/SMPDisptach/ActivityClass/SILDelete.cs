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

namespace SMPDisptach.ActivityClass
{
    [Activity(Label = "SILDelete", WindowSoftInputMode = Android.Views.SoftInput.StateAlwaysHidden, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation, ScreenOrientation = ScreenOrientation.Portrait)]
    public class SILDelete : Activity
    {
        Vibrator vibrator;
        clsGlobal clsGlobal;
        Spinner spinnerSIL;
        Button btnSILDelete;
        //ModNet modnet;
        List<string> _lstFlag = new List<string>();
        MediaPlayer mediaPlayerSound;
        RecyclerView.LayoutManager mLayoutManager;
        public SILDelete()
        {
            try
            {
                //clsGlobal = new clsGlobal();

                //modnet = new ModNet();

            }
            catch (Exception ex)
            {
                Toast.MakeText(this, ex.Message, ToastLength.Long).Show();
            }
        }
        public void ShowConfirmBox(string msg, Activity activity, EventHandler<DialogClickEventArgs> handler)
        {
            //scanningComplete = true;
            //SoundForFinalSave();
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
        private void StopPlayingSound()
        {
            try
            {
                if (mediaPlayerSound != null)
                {
                    mediaPlayerSound.Stop();
                    mediaPlayerSound.Release();
                    mediaPlayerSound = null;
                    //scanningComplete = false;
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
                    StopPlayingSound();
                    StartPlayingSound();
                    Thread.Sleep(3000);
                    StopPlayingSound();
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
        protected override void OnCreate(Bundle savedInstanceState)
        {
            try
            {
                base.OnCreate(savedInstanceState);
                SetContentView(Resource.Layout.activity_SILDelete);
                vibrator = this.GetSystemService(VibratorService) as Vibrator;
                string strTranscationPath = Path.Combine(clsGlobal.FilePath, clsGlobal.TranscationFolder);
                MediaScannerConnection.ScanFile(this, new String[] { strTranscationPath }, null, null);
                clsGlobal.DeleteDirectoryWithOutFile(strTranscationPath);
                //cmbSite = FindViewById<Spinner>(Resource.Id.cmbSite);
                btnSILDelete = FindViewById<Button>(Resource.Id.btnDelete);
                btnSILDelete.Click += BtnSILDelete_Click;
               

                spinnerSIL = FindViewById<Spinner>(Resource.Id.spinnerSIL);
                BindSpinnerSIL();
                Button btnBack = FindViewById<Button>(Resource.Id.btnBack);
                btnBack.Click += (e, a) =>
                {
                    this.Finish();
                };
                clsGlobal.mAlertMeassage = "Enter Password For Delete the SIL";
                ShowAlertPopUp();
                //if (clsGlobal.mAlertMeassage != "")
                //{
                //    this.Finish();
                //}
                //else
                //{
                //    clsGlobal.mAlertMeassage = "";
                //}
                //txtBattery.Enabled = txtTruckNo.Enabled = false;
            }
            catch (Exception ex)
            {
                clsGlobal.ShowMessage(ex.Message, this, MessageTitle.ERROR);
            }
        }

        private void BtnSILDelete_Click(object sender, EventArgs e)
        {
            if (spinnerSIL.SelectedItemPosition > 0)
            {
                FinalDeleteData();
            }
        }

        private void FinalDeleteData()
        {
            try
            {

                ShowConfirmBox($"Are you sure want to Delete this SIL {spinnerSIL.SelectedItem.ToString()} Scanned Data?", this, DeleteData);

            }
            catch (Exception ex)
            {
                clsGlobal.ShowMessage(ex.Message, this, MessageTitle.ERROR);
            }


        }
        private void DeleteData(object sender, DialogClickEventArgs e)
        {
            try
            {
                string strTranscationPath = Path.Combine(clsGlobal.FilePath, clsGlobal.TranscationFolder);
                string strFinal = Path.Combine(strTranscationPath, spinnerSIL.SelectedItem.ToString());
                clsGlobal.DeleteDirectory(strFinal);
                SoundForOK();
                clsGlobal.ShowMessage($"This SIL {spinnerSIL.SelectedItem.ToString()} Deleted Successfully!!!", this, MessageTitle.INFORMATION);
                clsGlobal.WriteLog($"This SIL {spinnerSIL.SelectedItem.ToString()} Deleted Successfully!!!");
                
                BindSpinnerSIL();
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            { StopPlayingSound(); }
        }
        public void BindALLSIL(string path)
        {
            try
            {
                _lstFlag.Clear();
                _lstFlag.Add("--Select--");
                string[] directoriesFinal = Directory.GetDirectories(path).OrderBy(x => x).ToArray();
                for (int i = 0; i < directoriesFinal.Length; i++)
                {
                    string strSILCode = Path.GetFileName(directoriesFinal[i].TrimEnd(Path.DirectorySeparatorChar));
                    _lstFlag.Add(strSILCode);
                }

                // Get all directories
            }
            catch (Exception ex)
            {
                // Handle exceptions (e.g., path not found)
                Console.WriteLine(ex.Message);
            }
        }
        private void BindSpinnerSIL()
        {

            string strTranscationPath = Path.Combine(clsGlobal.FilePath, clsGlobal.TranscationFolder);
            BindALLSIL(strTranscationPath);

            ArrayAdapter arrayAdapter = new ArrayAdapter(this, Resource.Layout.Spinner, _lstFlag);
            arrayAdapter.SetDropDownViewResource(Android.Resource.Layout.SimpleSpinnerDropDownItem);
            spinnerSIL.Adapter = arrayAdapter;
            spinnerSIL.SetSelection(0);
            spinnerSIL.RequestFocus();
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
                //OpenActivity(typeof(MainActivity));
            }
            catch (Exception ex)
            {
                clsGlobal.ShowMessage(ex.Message, this, MessageTitle.ERROR);
            }
        }



        public override void OnBackPressed() { }

        private bool ValidateControls()
        {
            try
            {
                bool IsValidate = true;

                if (spinnerSIL.SelectedItemPosition <= 0)
                {
                    Toast.MakeText(this, "Select SIL.", ToastLength.Long).Show();
                    spinnerSIL.RequestFocus();
                    IsValidate = false;
                }



                return IsValidate;
            }
            catch (Exception ex) { throw ex; }
        }

        private void clear()
        {
            spinnerSIL.SetSelection(0);
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