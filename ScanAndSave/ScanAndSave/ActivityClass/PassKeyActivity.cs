using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.Media;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using IOCLAndroidApp;

namespace ScanAndSaveApp.ActivityClass
{
    [Activity(Label = "Validate User", WindowSoftInputMode = SoftInput.StateHidden, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation, ScreenOrientation = ScreenOrientation.Portrait)]
    public class PassKeyActivity : Activity
    {
        clsGlobal clsGLB;
        EditText editPassKey;
        public PassKeyActivity()
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
        protected override void OnCreate(Bundle savedInstanceState)
        {
            try
            {
                base.OnCreate(savedInstanceState);
                SetContentView(Resource.Layout.activity_passkey);

                Button btnLogin = FindViewById<Button>(Resource.Id.btnLogin);
                btnLogin.Click += btnLogin_Click;

                editPassKey = FindViewById<EditText>(Resource.Id.editPassKey);

                Button btnBack = FindViewById<Button>(Resource.Id.btnBack);
                btnBack.Click += (e, a) =>
                {
                    this.Finish();
                };

                editPassKey.RequestFocus();
            }
            catch (Exception ex)
            {
                clsGLB.ShowMessage(ex.Message, this, MessageTitle.ERROR);
            }
        }

        public override void OnBackPressed() { }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                if (ValidateControls())
                {
                    if (editPassKey.Text.Trim() == "P@ss1234")
                        OpenActivity(typeof(SettingActivity));
                    else
                    {
                        Toast.MakeText(this, "Wrong passkey", ToastLength.Long).Show();
                        editPassKey.Text = "";
                        editPassKey.RequestFocus();
                    }
                }
            }
            catch (Exception ex)
            { clsGLB.ShowMessage(ex.Message, this, MessageTitle.ERROR); }
        }

        private bool ValidateControls()
        {
            try
            {
                bool IsValidate = true;

                if (string.IsNullOrEmpty(editPassKey.Text.Trim()))
                {
                    Toast.MakeText(this, "Input Pass Key", ToastLength.Long).Show();
                    editPassKey.RequestFocus();
                    IsValidate = false;
                }
                return IsValidate;
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
    }
}