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
    public partial class Lock_Screen : ContentPage
    {
        public Lock_Screen()
        {
            InitializeComponent();
        }
        CommonClass.SoundPlay obj = DependencyService.Get<CommonClass.SoundPlay>();

        private void btnUnLock_Clicked(object sender, EventArgs e)
        {
            try
            {
                string Data = CommonClass.CommonMethods.ReadFile(CommonClass.CommonVariable.Path + "/UserList.csv");
                DataTable dt = CommonClass.CommonMethods.StringToDataTable(Data);
                bool Flag = false;

                if (dt.Rows.Count > 0)
                {
                    if (ControlValidation())
                    {
                        for (int i = 0; i < dt.Rows.Count; i++)
                        {
                            if (dt.Rows[i]["UserID"].ToString() == txtUserID.Text && dt.Rows[i]["Password"].ToString() == txtPassword.Text)
                            {
                                if (dt.Rows[i]["UserType"].ToString() == "ADMIN" || dt.Rows[i]["UserType"].ToString() == "SUPER ADMIN")
                                {
                                    File.Delete(CommonClass.CommonVariable.Path + "//" + "Lock.txt");
                                    App.Current.MainPage = new Pages.Login();
                                    Flag = true;
                                    return;
                                }
                            }
                        }
                        if (Flag == false)
                        {
                            Toast.MakeText(Android.App.Application.Context, "INVALID CREDENTIAL", ToastLength.Long).Show();
                            obj.PlaySound("Error");
                            txtUserID.Focus();
                        }
                    }
                }
                else
                {
                    App.Current.MainPage = new Pages.UserCreation();
                }
            }
            catch (Exception ex)
            {
                obj.PlaySound("Error");
                Toast.MakeText(Android.App.Application.Context, ex.Message.ToString(), ToastLength.Long).Show();

            }
        }
        private bool ControlValidation()
        {
            if (txtUserID.Text == (null) || txtUserID.Text == "")
            {
                Toast.MakeText(Android.App.Application.Context, "PLEASE ENTER USERID", ToastLength.Long).Show();
                obj.PlaySound("Error");
                txtUserID.Focus();
                return false;
            }
            if (txtPassword.Text == (null) || txtPassword.Text == "")
            {
                Toast.MakeText(Android.App.Application.Context, "PLEASE ENTER PASSWORD", ToastLength.Long).Show();
                obj.PlaySound("Error");
                txtPassword.Text = "";
                return false;
            }

            return true;
        }
        private void BtnExit_Clicked(object sender, EventArgs e)
        {
            try
            {

                var cachePath = System.IO.Path.GetTempPath();

                // If exist, delete the cache directory and everything in it recursivly
                if (System.IO.Directory.Exists(cachePath))
                    System.IO.Directory.Delete(cachePath, true);

                // If not exist, restore just the directory that was deleted
                if (!System.IO.Directory.Exists(cachePath))
                    System.IO.Directory.CreateDirectory(cachePath);
                System.Diagnostics.Process.GetCurrentProcess().Kill();

            }
            catch (Exception ex)
            {
                obj.PlaySound("Error");
                Toast.MakeText(Android.App.Application.Context, ex.Message.ToString(), ToastLength.Long).Show();

            }
        }

        private void TxtPassword_Completed(object sender, EventArgs e)
        {
            btnUnLock_Clicked(sender, e);
        }

        private void ContentPage_Appearing(object sender, EventArgs e)
        {
            try
            {
                if (File.Exists(CommonClass.CommonVariable.Path + "//" + "Lock.txt"))
                {
                    string data = CommonClass.CommonMethods.ReadFile(CommonClass.CommonVariable.Path + "//" + "Lock.txt");
                    lblError.Text = data;
                }
                txtUserID.Focus();
            }
            catch (Exception ex)
            {
                obj.PlaySound("Error");
                Toast.MakeText(Android.App.Application.Context, ex.Message.ToString(), ToastLength.Long).Show();
            }
        }
    }
}