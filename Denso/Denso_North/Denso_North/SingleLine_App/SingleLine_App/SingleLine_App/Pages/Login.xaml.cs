using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Android.Widget;
using System.Net;

namespace ThreePointCheck_App.Pages
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class Login : ContentPage
	{
        DataTable dt = new DataTable();
        CommonClass.SoundPlay obj = DependencyService.Get<CommonClass.SoundPlay>();
        public Login ()
		{
			InitializeComponent ();
		}
   
        private void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            try
            {
                bool Flag = false;
                if (dt.Rows.Count > 0)
                {
                    DataView dv = new DataView(dt);
                    dv.RowFilter = "UserType='SUPER ADMIN'";

                    if (dv.ToTable().Rows.Count > 0)
                    {
                        if (ControlValidation())
                        {
                            for (int i = 0; i < dt.Rows.Count; i++)
                            {
                                if (dt.Rows[i]["UserID"].ToString() == txtUserID.Text && dt.Rows[i]["Password"].ToString() == txtPassword.Text)
                                {
                                    CommonClass.CommonVariable.UserID = txtUserID.Text;
                                    CommonClass.CommonVariable.UserName = dt.Rows[i]["UserName"].ToString();
                                    CommonClass.CommonVariable.UserType = dt.Rows[i]["UserType"].ToString();

                                    if (CommonClass.CommonVariable.UserType == "SUPER ADMIN")
                                    {
                                        App.Current.MainPage = new Pages.UserCreation();
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
                }
                else
                {
                    App.Current.MainPage = new Pages.UserCreation();

                }
            }
            catch (Exception ex)
            {
                obj.PlaySound("Error");
                DisplayAlert("Error", ex.Message, "OK");
            }
        }

        private void  CreateDirectory()
        {
            if (!Directory.Exists(CommonClass.CommonVariable.Path))
            {
                Directory.CreateDirectory(CommonClass.CommonVariable.Path);
            }
            if (!Directory.Exists(CommonClass.CommonVariable.Path_1))
            {
                Directory.CreateDirectory(CommonClass.CommonVariable.Path_1);
            }

        }
        private void LoginList()
        {
            string Data = CommonClass.CommonMethods.ReadFile(CommonClass.CommonVariable.Path + "/UserList.csv");
            dt = CommonClass.CommonMethods.StringToDataTable(Data);
        }
        private void ContentPage_Appearing(object sender, EventArgs e)
        {
            try
            {
                CreateDirectory();
                LoginList();

                lblLogin.Text = "LOGIN - " + CommonClass.CommonVariable.Version;
                txtUserID.Focus();
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
                DisplayAlert("Error", ex.Message, "OK");
            }
        }
        private bool ControlValidation()
        {
            if(txtUserID.Text==(null) || txtUserID.Text == "")
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
        private string GetFTPFile(string path, string Username, string password)
        {

            string filePath = Android.OS.Environment.ExternalStorageDirectory + "/Denso_3Point/Barcode.csv";
            Uri severUri = new Uri(path);
            if (severUri.Scheme != Uri.UriSchemeFtp)
                return "";

            FtpWebRequest request = (FtpWebRequest)WebRequest.Create(severUri);
            request.Method = WebRequestMethods.Ftp.UploadFile;
            request.UseBinary = true;
            request.UsePassive = false;//true;
            request.KeepAlive = false;
            request.Timeout = System.Threading.Timeout.Infinite;
            request.AuthenticationLevel = System.Net.Security.AuthenticationLevel.None;
            request.Credentials = new NetworkCredential(Username, password);
            StreamReader sourceStream = new StreamReader(filePath);
            byte[] fileContents = Encoding.UTF8.GetBytes(sourceStream.ReadToEnd());
            sourceStream.Close();
            request.ContentLength = fileContents.Length;
            Stream requestStream = request.GetRequestStream();
            requestStream.Write(fileContents, 0, fileContents.Length);
            requestStream.Close();
            requestStream.Dispose();
            FtpWebResponse response = (FtpWebResponse)request.GetResponse();
            response.Close();
            response.Dispose();
            return filePath;
        }
        private void BtnLogin_Clicked(object sender, EventArgs e)
        {
            try
            {
                //GetFTPFile("ftp://172.28.41.246/SATO/Barcode.csv", "VISITOR", "123456");
                if (ControlValidation())
                {
                    bool Flag = false;
                    if (dt.Rows.Count > 0)
                    {
                        for (int i = 0; i < dt.Rows.Count; i++)
                        {
                            if (dt.Rows[i]["UserID"].ToString() == txtUserID.Text && dt.Rows[i]["Password"].ToString() == txtPassword.Text)
                            {

                                
                                    App.Current.MainPage = new Pages.MainWIndow();
                                    CommonClass.CommonVariable.UserID = txtUserID.Text;
                                    CommonClass.CommonVariable.UserName = dt.Rows[i]["UserName"].ToString();
                                    CommonClass.CommonVariable.UserType = dt.Rows[i]["UserType"].ToString();
                                
                                Flag = true;
                                return;
                            }

                        }
                        if (Flag == false)
                        {
                            Toast.MakeText(Android.App.Application.Context, "INVALID CREDENTIAL", ToastLength.Long).Show();
                            obj.PlaySound("Error");
                            txtUserID.Focus();
                         
                        }
                    }
                    else
                    {
                        Toast.MakeText(Android.App.Application.Context, "PLEASE CREATE USERS TO ACCESS THE APP", ToastLength.Long).Show();
                        obj.PlaySound("Error");
                        txtUserID.Text = "";
                        txtPassword.Text = "";
                        txtUserID.Focus();
                    }

                }
            }
            catch (Exception ex)
            {
                obj.PlaySound("Error");
                DisplayAlert("Error", ex.Message, "OK");
            }
        }

        private void TxtPassword_Completed(object sender, EventArgs e)
        {
            BtnLogin_Clicked(sender, e);
        }

        private void TapGestureRecognizer_Tapped_1(object sender, EventArgs e)
        {
            try
            {
                //if (txtUserID.Text == "Admin" && txtPassword.Text == "Admin")
                //{
                //    App.Current.MainPage = new Pages.Settings();
                //}
                //else
                //{
                //    Toast.MakeText(Android.App.Application.Context, "ACCESS DENIED", ToastLength.Long).Show();
                //    obj.PlaySound("Error");
                //    txtUserID.Focus();
                //}
                if (ControlValidation())
                {
                    bool Flag = false;

                    if (dt.Rows.Count > 0)
                    {
                        for (int i = 0; i < dt.Rows.Count; i++)
                        {
                            if (dt.Rows[i]["UserID"].ToString() == txtUserID.Text && dt.Rows[i]["Password"].ToString() == txtPassword.Text)
                            {
                                CommonClass.CommonVariable.UserID = txtUserID.Text;
                                CommonClass.CommonVariable.UserName = dt.Rows[i]["UserName"].ToString();
                                CommonClass.CommonVariable.UserType = dt.Rows[i]["UserType"].ToString();

                                if (CommonClass.CommonVariable.UserType == "SUPER ADMIN")
                                {
                                    App.Current.MainPage = new Pages.Settings();
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
                    else
                    {
                        Toast.MakeText(Android.App.Application.Context, "PLEASE CREATE USERS TO ACCESS THE APP", ToastLength.Long).Show();
                        obj.PlaySound("Error");
                        txtUserID.Text = "";
                        txtPassword.Text = "";
                        txtUserID.Focus();
                    }
                }
            }
            catch (Exception ex)
            {
                obj.PlaySound("Error");
                DisplayAlert("Error", ex.Message, "OK");
            }
        }
    }
}