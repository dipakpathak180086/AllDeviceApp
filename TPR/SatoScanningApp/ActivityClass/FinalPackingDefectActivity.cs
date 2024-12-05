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

namespace SatoScanningApp
{
    [Activity(Label = "Sato ScanningApp", WindowSoftInputMode = SoftInput.StateHidden, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation, ScreenOrientation = ScreenOrientation.Portrait)]
    public class FinalPackingDefectActivity : AppCompatActivity
    {
        clsGlobal clsGLB;
       
        MediaPlayer mediaPlayerSound;
        Vibrator vibrator;

        EditText editIC, editOC, editSlag, editDent, editSpine, editPackNg, editOthers, editRust, editExtraParam2, editExtraParam3, editExtraParam4, editExtraParam5;
        Button btnSave, btnReset;

        string _ScannedTrolleyCard;

        public FinalPackingDefectActivity()
        {
            try
            {
                clsGLB = new clsGlobal();
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
                SetContentView(Resource.Layout.activity_finalPacking_defect);

                editIC = FindViewById<EditText>(Resource.Id.editIC);
                editOC = FindViewById<EditText>(Resource.Id.editOC);
                editSlag = FindViewById<EditText>(Resource.Id.editSlag);
                editDent = FindViewById<EditText>(Resource.Id.editDent);

                editSpine = FindViewById<EditText>(Resource.Id.editSpine);
                editPackNg = FindViewById<EditText>(Resource.Id.editPackingNg);
                editOthers = FindViewById<EditText>(Resource.Id.editOthers);
                editRust = FindViewById<EditText>(Resource.Id.editRust);
                editExtraParam2 = FindViewById<EditText>(Resource.Id.editExtraParam2);
                editExtraParam3 = FindViewById<EditText>(Resource.Id.editExtraParam3);
                editExtraParam4 = FindViewById<EditText>(Resource.Id.editExtraParam4);
                editExtraParam5 = FindViewById<EditText>(Resource.Id.editExtraParam5);

                Button btnBack = FindViewById<Button>(Resource.Id.btnBack);
                btnBack.Click += (e, a) =>
                {
                    this.Finish();
                };


                btnReset = FindViewById<Button>(Resource.Id.btnReset);
                btnReset.Click += BtnReset_Click;

                btnSave = FindViewById<Button>(Resource.Id.btnSave);
                btnSave.Click += BtnSave_Click;

                vibrator = this.GetSystemService(VibratorService) as Vibrator;
                Clear();
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
                int DefectQty = 0;
                DefectQty += clsGlobal.FinalPacking.InnerCavity = editIC.Text.Length > 0 ? Convert.ToInt32(editIC.Text) : 0;
                DefectQty += clsGlobal.FinalPacking.OuterCavity = editOC.Text.Length > 0 ? Convert.ToInt32(editOC.Text) : 0;
                DefectQty += clsGlobal.FinalPacking.Slag = editSlag.Text.Length > 0 ? Convert.ToInt32(editSlag.Text) : 0;
                DefectQty += clsGlobal.FinalPacking.Dent = editDent.Text.Length > 0 ? Convert.ToInt32(editDent.Text) : 0;
                DefectQty += clsGlobal.FinalPacking.Spine = editSpine.Text.Length > 0 ? Convert.ToInt32(editSpine.Text) : 0;
                DefectQty += clsGlobal.FinalPacking.PackNg = editPackNg.Text.Length > 0 ? Convert.ToInt32(editPackNg.Text) : 0;
                DefectQty += clsGlobal.FinalPacking.Other = editOthers.Text.Length > 0 ? Convert.ToInt32(editOthers.Text) : 0;
                DefectQty += clsGlobal.FinalPacking.Rust = editRust.Text.Length > 0 ? Convert.ToInt32(editRust.Text) : 0;
                DefectQty += clsGlobal.FinalPacking.ExtraParam2 = editExtraParam2.Text.Length > 0 ? Convert.ToInt32(editExtraParam2.Text) : 0;
                DefectQty += clsGlobal.FinalPacking.ExtraParam3 = editExtraParam3.Text.Length > 0 ? Convert.ToInt32(editExtraParam3.Text) : 0;
                DefectQty += clsGlobal.FinalPacking.ExtraParam4 = editExtraParam4.Text.Length > 0 ? Convert.ToInt32(editExtraParam4.Text) : 0;
                DefectQty += clsGlobal.FinalPacking.ExtraParam5 = editExtraParam5.Text.Length > 0 ? Convert.ToInt32(editExtraParam5.Text) : 0;
                clsGlobal.FinalPacking.DefectQty = DefectQty;
                if (DefectQty == clsGlobal.FinalPacking.NgQty)
                {
                    this.Finish();
                }
                else
                {
                    StartPlayingSound();
                    ShowMessageBox("Qty mismatch, Defect Qty is " + DefectQty + " And Ng Qty is " + clsGlobal.FinalPacking.NgQty, this);
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
            }
            catch (Exception ex)
            {
                clsGLB.ShowMessage(ex.Message, this, MessageTitle.ERROR);
            }
        }

        #endregion

        #region Methods

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

        private void Clear()
        {
            try
            {
                editIC.Text = "0";
                editOC.Text = "0";
                editSlag.Text = "0";
                editDent.Text = "0";
                editSpine.Text = "0";
                editPackNg.Text = "0";
                editOthers.Text = "0";
                editRust.Text = "0";
                editExtraParam2.Text = "0";
                editExtraParam3.Text = "0";
                editExtraParam4.Text = "0";
                editExtraParam5.Text = "0";
            }
            catch (Exception ex)
            {
                clsGLB.ShowMessage(ex.Message, this, MessageTitle.ERROR);
            }
        }

        #endregion

    }
}