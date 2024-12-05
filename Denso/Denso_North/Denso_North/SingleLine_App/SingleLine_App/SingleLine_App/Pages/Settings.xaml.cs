using Android.Widget;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ThreePointCheck_App.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Settings : ContentPage
    {
        public Settings()
        {
            InitializeComponent();
        }
        CommonClass.SoundPlay obj = DependencyService.Get<CommonClass.SoundPlay>();
        private void BtnSave_Clicked(object sender, EventArgs e)
        {
            try
            {
                if (ControlValidation())
                {

                    if (File.Exists(CommonClass.CommonVariable.Path + "/Settings.txt"))
                    {
                        File.Delete(CommonClass.CommonVariable.Path + "/Settings.txt");
                        string str1 = "WH_ID" + "," + "Device_ID" + "," + "FTP_Ip" + "," + "FTP_UserID" + "," + "FTP_Password" + "," + "Application_Type";
                        CommonClass.CommonMethods.WriteFile(CommonClass.CommonVariable.Path + "/Settings.txt", str1);
                    }

                    string str = txtWhNo.Text + "," + txtDeviceID.Text + "," + txtFTPIP.Text + "," + txtUserID.Text + "," + txtPassword.Text + "," + pkSIL.SelectedItem ;
                    CommonClass.CommonMethods.WriteFile(CommonClass.CommonVariable.Path + "/Settings.txt", str);
                    Toast.MakeText(Android.App.Application.Context, "DATA SAVED", ToastLength.Long).Show(); ;
                    obj.PlaySound("Success");
                    Clear();
                }
            }
            catch (Exception ex)
            {
                obj.PlaySound("Error");
                DisplayAlert("Error", ex.Message, "OK");
            }
        }
        private void Clear()
        {

            txtWhNo.Text = "";
            txtDeviceID.Text = "";
            txtFTPIP.Text = "";
            txtUserID.Text = "";
            txtPassword.Text = "";
            pkSIL.SelectedIndex = -1;
            txtWhNo.Focus();
        }
        private void BtnClear_Clicked(object sender, EventArgs e)
        {
            try
            {
                Clear();
            }
            catch (Exception ex)
            {
                obj.PlaySound("Error");
                DisplayAlert("Error", ex.Message, "OK");
            }
        }

        private void BtnExit_Clicked(object sender, EventArgs e)
        {
            try
            {
                App.Current.MainPage = new Pages.Login();
            }
            catch (Exception ex)
            {
                obj.PlaySound("Error");
                DisplayAlert("Error", ex.Message, "OK");
            }
        }
        private bool ControlValidation()
        {
            if (txtWhNo.Text == (null) || txtWhNo.Text == "")
            {
                Toast.MakeText(Android.App.Application.Context, "PLEASE ENTER WAREHOUSE NO", ToastLength.Long).Show();
                obj.PlaySound("Error");
                txtWhNo.Focus();
                return false;
            }
            if (txtDeviceID.Text == (null) || txtDeviceID.Text == "")
            {
                Toast.MakeText(Android.App.Application.Context, "PLEASE ENTER DEVICE ID", ToastLength.Long).Show();
                obj.PlaySound("Error");
                txtDeviceID.Focus();
                return false;
            }
            if (txtFTPIP.Text == (null) || txtFTPIP.Text == "")
            {
                Toast.MakeText(Android.App.Application.Context, "PLEASE ENTER FTP IP", ToastLength.Long).Show();
                obj.PlaySound("Error");
                txtFTPIP.Text = "";
                txtFTPIP.Focus();
                return false;
            }
            if (txtUserID.Text == (null) || txtUserID.Text == "")
            {
                Toast.MakeText(Android.App.Application.Context, "PLEASE ENTER FTP USER ID", ToastLength.Long).Show();
                obj.PlaySound("Error");
                txtUserID.Text = "";
                txtUserID.Focus();
                return false;
            }
            if (txtPassword.Text == (null) || txtPassword.Text == "")
            {
                Toast.MakeText(Android.App.Application.Context, "PLEASE ENTER FTP PASSORD", ToastLength.Long).Show();
                obj.PlaySound("Error");
                txtPassword.Text = "";
                txtPassword.Focus();
                return false;
            }
            if (pkSIL.SelectedIndex ==-1)
            {
                Toast.MakeText(Android.App.Application.Context, "PLEASE SELECT APPLICATION TYPE", ToastLength.Long).Show();
                obj.PlaySound("Error");
              
                return false;
            }
            return true;
        }
        private void ContentPage_Appearing(object sender, EventArgs e)
        {
            try
            {
                if (!File.Exists(CommonClass.CommonVariable.Path + "/Settings.txt"))
                {
                    string str = "WH_ID" + "," + "Device_ID" + "," + "FTP_Ip" + "," + "FTP_UserID" + "," + "FTP_Password" + "," + "Application_Type";
                    CommonClass.CommonMethods.WriteFile(CommonClass.CommonVariable.Path + "/Settings.txt", str);
                }

                if (File.Exists(CommonClass.CommonVariable.Path + "//Settings.txt"))
                {
                    string Data = CommonClass.CommonMethods.ReadFile(CommonClass.CommonVariable.Path + "/Settings.txt");
                    DataTable dtSettings = CommonClass.CommonMethods.StringToDataTable(Data);
                    if (dtSettings.Rows.Count > 0)
                    {
                        txtWhNo.Text = dtSettings.Rows[0]["WH_ID"].ToString();
                        txtDeviceID.Text = dtSettings.Rows[0]["Device_ID"].ToString();
                        txtFTPIP.Text = dtSettings.Rows[0]["FTP_Ip"].ToString();
                        txtUserID.Text = dtSettings.Rows[0]["FTP_UserID"].ToString();
                        txtPassword.Text = dtSettings.Rows[0]["FTP_Password"].ToString();
                        pkSIL.SelectedItem = dtSettings.Rows[0]["Application_Type"].ToString();

                    }
                }


                txtWhNo.Focus();
            }
            catch (Exception ex)
            {
                obj.PlaySound("Error");
                DisplayAlert("Error", ex.Message, "OK");
            }
        }
    }
}
