using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
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
using static Android.Provider.Settings;

namespace SatoScanningApp.ActivityClass
{
    [Activity(Label = "Setting", WindowSoftInputMode = SoftInput.StateHidden, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation, ScreenOrientation = ScreenOrientation.Portrait)]
    public class SettingActivity : Activity
    {
        clsNetwork oNetwork;
        clsGlobal clsGLB;
        EditText editServerIP;
        EditText editPort;
        EditText editPlant;
        EditText editTagPower;
       
        public SettingActivity()
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
        protected override void OnCreate(Bundle savedInstanceState)
        {
            try
            {
                base.OnCreate(savedInstanceState);
                SetContentView(Resource.Layout.activity_setting);

                Button btnSave = FindViewById<Button>(Resource.Id.btnSave);
                btnSave.Click += BtnSave_Click;

                editServerIP = FindViewById<EditText>(Resource.Id.txtServerIP);
                editPort = FindViewById<EditText>(Resource.Id.txtPort);
                editPlant = FindViewById<EditText>(Resource.Id.txtPlant);
                editTagPower = FindViewById<EditText>(Resource.Id.txtTagPower);



                Button btnBack = FindViewById<Button>(Resource.Id.btnBack);
                btnBack.Click += (e, a) =>
                {
                    this.Finish();
                };

                ReadSettingFile();

                editServerIP.RequestFocus();
            }
            catch (Exception ex)
            {
                clsGLB.ShowMessage(ex.Message, this, MessageTitle.ERROR);
            }
        }

        public override void OnBackPressed() { }
        public string EncryptString(string encryptString)
        {
            string EncryptionKey = "0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            byte[] clearBytes = System.Text.Encoding.Unicode.GetBytes(encryptString);
            using (Aes encryptor = Aes.Create())
            {
                Rfc2898DeriveBytes pdb = new Rfc2898DeriveBytes(EncryptionKey, new byte[] {
            0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76
        });
                encryptor.Key = pdb.GetBytes(32);
                encryptor.IV = pdb.GetBytes(16);
                using (MemoryStream ms = new MemoryStream())
                {
                    using (CryptoStream cs = new CryptoStream(ms, encryptor.CreateEncryptor(), CryptoStreamMode.Write))
                    {
                        cs.Write(clearBytes, 0, clearBytes.Length);
                        cs.Close();
                    }
                    encryptString = Convert.ToBase64String(ms.ToArray());
                }
            }
            return encryptString;
        }
        public string DecryptString(string cipherText)
        {
            string EncryptionKey = "0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            cipherText = cipherText.Replace(" ", "+");
            byte[] cipherBytes = Convert.FromBase64String(cipherText);
            using (Aes encryptor = Aes.Create())
            {
                Rfc2898DeriveBytes pdb = new Rfc2898DeriveBytes(EncryptionKey, new byte[] {
            0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76
        });
                encryptor.Key = pdb.GetBytes(32);
                encryptor.IV = pdb.GetBytes(16);
                using (MemoryStream ms = new MemoryStream())
                {
                    using (CryptoStream cs = new CryptoStream(ms, encryptor.CreateDecryptor(), CryptoStreamMode.Write))
                    {
                        cs.Write(cipherBytes, 0, cipherBytes.Length);
                        cs.Close();
                    }
                    cipherText = System.Text.Encoding.Unicode.GetString(ms.ToArray());
                }
            }
            return cipherText;
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (ValidateControls())
                {

                    string folderPath = Path.Combine(clsGlobal.FilePath, clsGlobal.FileFolder);
                    if (!Directory.Exists(folderPath))
                        Directory.CreateDirectory(folderPath);

                    string filename = Path.Combine(folderPath, clsGlobal.ServerIpFileName);

                    using (var streamWriter = new StreamWriter(filename, false))
                    {
                        Context context = this.ApplicationContext;
                       //string id= Secure.GetString(context.ContentResolver, Secure.AndroidId);
                        streamWriter.WriteLine(editServerIP.Text.Trim());
                        streamWriter.WriteLine(editPort.Text.Trim());
                        streamWriter.WriteLine(editPlant.Text.Trim());
                        streamWriter.WriteLine(editTagPower.Text.Trim());

                        MediaScannerConnection.ScanFile(this, new string[] { filename }, null, null);

                        Toast.MakeText(this, "Setting saved", ToastLength.Long).Show();

                        clsGlobal.mSockIp = editServerIP.Text.Trim();
                        clsGlobal.mSockPort = Convert.ToInt32(editPort.Text.Trim());
                        clsGlobal.mPlant = editPlant.Text.Trim();
                        clsGlobal.mTagPower = Convert.ToInt32(editTagPower.Text.Trim());
                        Finish();
                    }
                }
            }
            catch (Exception ex)
            { clsGLB.ShowMessage(ex.Message, this, MessageTitle.ERROR); }
        }

        private void ReadSettingFile()
        {
            StreamReader sr = null;
            try
            {
                string folderPath = Path.Combine(clsGlobal.FilePath, clsGlobal.FileFolder);
                string filename = Path.Combine(folderPath, clsGlobal.ServerIpFileName);

                if (File.Exists(filename))
                {
                    sr = new StreamReader(filename);
                    editServerIP.Text = sr.ReadLine();
                    editPort.Text = sr.ReadLine();
                    editPlant.Text = sr.ReadLine();
                    editTagPower.Text = sr.ReadLine();

                    sr.Close();
                    sr.Dispose();
                    sr = null;

                    clsGlobal.mSockIp = editServerIP.Text.Trim();
                    clsGlobal.mSockPort = Convert.ToInt32(editPort.Text.Trim());
                    clsGlobal.mPlant = editPlant.Text.Trim();
                    clsGlobal.mTagPower =Convert.ToInt32( editTagPower.Text.Trim());
                }
            }
            catch (Exception ex)
            { throw ex; }
            finally
            {
                if (sr != null)
                {
                    sr.Close();
                    sr.Dispose();
                    sr = null;
                }
            }
        }

        private bool ValidateControls()
        {
            try
            {
                bool IsValidate = true;

                if (string.IsNullOrEmpty(editServerIP.Text.Trim()))
                {
                    Toast.MakeText(this, "Input server ip", ToastLength.Long).Show();
                    editServerIP.RequestFocus();
                    IsValidate = false;
                }
                if (string.IsNullOrEmpty(editPort.Text.Trim()))
                {
                    Toast.MakeText(this, "Input server port", ToastLength.Long).Show();
                    editPort.RequestFocus();
                    IsValidate = false;
                }
                if (string.IsNullOrEmpty(editPlant.Text.Trim()))
                {
                    Toast.MakeText(this, "Input plant code", ToastLength.Long).Show();
                    editPlant.RequestFocus();
                    IsValidate = false;
                }
                if (string.IsNullOrEmpty(editTagPower.Text.Trim()))
                {
                    Toast.MakeText(this, "Input Tag Power in between 5 to 30", ToastLength.Long).Show();
                    editTagPower.RequestFocus();
                    IsValidate = false;
                }
                if (Convert.ToInt32(editTagPower.Text)<5 || Convert.ToInt32(editTagPower.Text) > 30)
                {
                    Toast.MakeText(this, "Input Tag Power in between 5 to 30", ToastLength.Long).Show();
                    editTagPower.RequestFocus();
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