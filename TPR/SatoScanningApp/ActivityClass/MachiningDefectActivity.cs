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
    public class MachiningDefectActivity : AppCompatActivity
    {
        clsGlobal clsGLB;
       
        MediaPlayer mediaPlayerSound;
        Vibrator vibrator;

        EditText editIC, editOC, editSlag, editDent, editSpine, editForgMat,editRust,editPinHole,editMachineOutsideCavity
            , editOthers, editIdPlus, editIdMinus, editPowerCut, editExtraParam4, editExtraParam5,editTotalLengthMinus,editTotalLengthPlus
            ,editRCenterMinus,editRCenterPlus,editNoCleanUp,editCarck;
        Button btnSave, btnReset;

        string _ScannedTrolleyCard;

        public MachiningDefectActivity()
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
                SetContentView(Resource.Layout.activity_machining_defect);

                editIC = FindViewById<EditText>(Resource.Id.editIC);
                editOC = FindViewById<EditText>(Resource.Id.editOC);
                editSlag = FindViewById<EditText>(Resource.Id.editSlag);
                editDent = FindViewById<EditText>(Resource.Id.editDent);

                editSpine = FindViewById<EditText>(Resource.Id.editSpine);
                editForgMat = FindViewById<EditText>(Resource.Id.editForgMat);
                editRust = FindViewById<EditText>(Resource.Id.editRust);
                editPinHole = FindViewById<EditText>(Resource.Id.editPinHole);
                editMachineOutsideCavity = FindViewById<EditText>(Resource.Id.editMacineOutsideCavity);
                editOthers = FindViewById<EditText>(Resource.Id.editOthers);
                editIdPlus = FindViewById<EditText>(Resource.Id.editIdPlus);
                editIdMinus = FindViewById<EditText>(Resource.Id.editIdMinus);
                editPowerCut = FindViewById<EditText>(Resource.Id.editPowerCut);
                editExtraParam4 = FindViewById<EditText>(Resource.Id.editExtraParam4);
                editExtraParam5 = FindViewById<EditText>(Resource.Id.editExtraParam5);

                editTotalLengthMinus = FindViewById<EditText>(Resource.Id.editTotalLengthMinus);
                editTotalLengthPlus = FindViewById<EditText>(Resource.Id.editTotalLengthPlus);
                editRCenterMinus = FindViewById<EditText>(Resource.Id.editRCenterMinus);
                editRCenterPlus = FindViewById<EditText>(Resource.Id.editRCenterPlus);
                editNoCleanUp = FindViewById<EditText>(Resource.Id.editNoCleanUp);
                editCarck = FindViewById<EditText>(Resource.Id.editCarck);

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
                DefectQty += clsGlobal.Machining.InnerCavity = editIC.Text.Length > 0 ? Convert.ToInt32(editIC.Text) : 0;
                DefectQty += clsGlobal.Machining.OuterCavity = editOC.Text.Length > 0 ? Convert.ToInt32(editOC.Text) : 0;
                DefectQty += clsGlobal.Machining.Slag = editSlag.Text.Length > 0 ? Convert.ToInt32(editSlag.Text) : 0;
                DefectQty += clsGlobal.Machining.Dent = editDent.Text.Length > 0 ? Convert.ToInt32(editDent.Text) : 0;
                DefectQty += clsGlobal.Machining.Spine = editSpine.Text.Length > 0 ? Convert.ToInt32(editSpine.Text) : 0;
                DefectQty += clsGlobal.Machining.ForgMat = editForgMat.Text.Length > 0 ? Convert.ToInt32(editForgMat.Text) : 0;
                DefectQty += clsGlobal.Machining.Rust = editRust.Text.Length > 0 ? Convert.ToInt32(editRust.Text) : 0;
                DefectQty += clsGlobal.Machining.PinHole = editPinHole.Text.Length > 0 ? Convert.ToInt32(editPinHole.Text) : 0;
                DefectQty += clsGlobal.Machining.MachineOutsideCavity = editMachineOutsideCavity.Text.Length > 0 ? Convert.ToInt32(editMachineOutsideCavity.Text) : 0;
                DefectQty += clsGlobal.Machining.Other = editOthers.Text.Length > 0 ? Convert.ToInt32(editOthers.Text) : 0;
                DefectQty += clsGlobal.Machining.IDPlus = editIdPlus.Text.Length > 0 ? Convert.ToInt32(editIdPlus.Text) : 0;
                DefectQty += clsGlobal.Machining.IDMinus = editIdMinus.Text.Length > 0 ? Convert.ToInt32(editIdMinus.Text) : 0;
                DefectQty += clsGlobal.Machining.PowerCut = editPowerCut.Text.Length > 0 ? Convert.ToInt32(editPowerCut.Text) : 0;
                DefectQty += clsGlobal.Machining.ExtraParam4 = editExtraParam4.Text.Length > 0 ? Convert.ToInt32(editExtraParam4.Text) : 0;
                DefectQty += clsGlobal.Machining.ExtraParam5 = editExtraParam5.Text.Length > 0 ? Convert.ToInt32(editExtraParam5.Text) : 0;

                DefectQty += clsGlobal.Machining.TotalLengthMinus = editTotalLengthMinus.Text.Length > 0 ? Convert.ToInt32(editTotalLengthMinus.Text) : 0;
                DefectQty += clsGlobal.Machining.TotalLengthPlus = editTotalLengthPlus.Text.Length > 0 ? Convert.ToInt32(editTotalLengthPlus.Text) : 0;
                DefectQty += clsGlobal.Machining.RCenterMinus = editRCenterMinus.Text.Length > 0 ? Convert.ToInt32(editRCenterMinus.Text) : 0;
                DefectQty += clsGlobal.Machining.RCenterPlus = editRCenterPlus.Text.Length > 0 ? Convert.ToInt32(editRCenterPlus.Text) : 0;
                DefectQty += clsGlobal.Machining.NoCleanUp = editNoCleanUp.Text.Length > 0 ? Convert.ToInt32(editNoCleanUp.Text) : 0;
                DefectQty += clsGlobal.Machining.Crack = editCarck.Text.Length > 0 ? Convert.ToInt32(editCarck.Text) : 0;

                clsGlobal.Machining.DefectQty = DefectQty;
                if (DefectQty == clsGlobal.Machining.NgQty)
                {
                    this.Finish();
                }
                else
                {
                    StartPlayingSound();
                    ShowMessageBox("Qty mismatch, Defect Qty is " + DefectQty + " And Ng Qty is " + clsGlobal.Machining.NgQty, this);
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
                editForgMat.Text = "0";
                editRust.Text = "0";
                editPinHole.Text = "0";
                editMachineOutsideCavity.Text = "0";
                editOthers.Text = "0";
                editIdPlus.Text = "0";
                editIdMinus.Text = "0";
                editPowerCut.Text = "0";
                editExtraParam4.Text = "0";
                editExtraParam5.Text = "0";

                editTotalLengthMinus.Text = "0";
                editTotalLengthPlus.Text = "0";
                editRCenterMinus.Text = "0";
                editRCenterPlus.Text = "0";
                editNoCleanUp.Text = "0";
                editCarck.Text = "0";

            }
            catch (Exception ex)
            {
                clsGLB.ShowMessage(ex.Message, this, MessageTitle.ERROR);
            }
        }

        #endregion

    }
}