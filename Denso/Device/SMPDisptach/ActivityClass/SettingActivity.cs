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
using SMPDisptach;

namespace SMPDisptach
{
    [Activity(Label = "Setting", WindowSoftInputMode = SoftInput.StateHidden, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation, ScreenOrientation = ScreenOrientation.Portrait)]
    public class SettingActivity : Activity
    {
        //clsNetwork oNetwork;
        clsGlobal clsGLB;
        EditText editServerIP;
        EditText editPort;
        EditText editPlantCode;
        //Spinner cmbSite;
        //List<string> _ListSite = new List<string>();
        public SettingActivity()
        {
            try
            {
                clsGLB = new clsGlobal();
                //oNetwork = new clsNetwork();
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

                //cmbSite = FindViewById<Spinner>(Resource.Id.cmbSite);

                Button btnSave = FindViewById<Button>(Resource.Id.btnSave);
                btnSave.Click += BtnSave_Click;

                editServerIP = FindViewById<EditText>(Resource.Id.txtServerIP);
                editPort = FindViewById<EditText>(Resource.Id.txtPort);
                editPlantCode = FindViewById<EditText>(Resource.Id.txtPlantCode);

                Button btnBack = FindViewById<Button>(Resource.Id.btnBack);
                btnBack.Click += (e, a) =>
                {
                    this.Finish();
                };

                
                ReadServerIP();

                editServerIP.RequestFocus();
            }
            catch (Exception ex)
            {
                clsGLB.ShowMessage(ex.Message, this, MessageTitle.ERROR);
            }
        }

        public override void OnBackPressed() { }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (ValidateControls())
                {

                    //string folderPath = Path.Combine(clsGlobal.FilePath, clsGlobal.FileFolder);
                    //if (!Directory.Exists(folderPath))
                    //    Directory.CreateDirectory(folderPath);

                    string filename = Path.Combine(ModInit.GstrPath, "Server.SYS");

                    //using (var streamWriter = new StreamWriter(filename, false))
                    //{
                    WriteServerIP();

                    MediaScannerConnection.ScanFile(this, new string[] { filename }, null, null);

                    Toast.MakeText(this, "Setting saved", ToastLength.Long).Show();

                    Finish();
                    //}
                }
            }
            catch (Exception ex)
            { clsGLB.ShowMessage(ex.Message, this, MessageTitle.ERROR); }
        }

        public bool ReadServerIP()
        {
            try
            {
                string filename = Path.Combine(ModInit.GstrPath, "Server.SYS");
                FileInfo ServerFile = new FileInfo(filename);
                StreamReader ReadServer;
                string[] strCon;
                if (ServerFile.Exists == true)
                {
                    ReadServer = new StreamReader(filename);
                    strCon = ReadServer.ReadLine().Split("~");
                    if (strCon.Length >= 1)
                    {
                        editServerIP.Text = strCon[0].Trim();
                        editPort.Text = strCon[1].Trim();
                        editPlantCode.Text= strCon[2].Trim();
                    }
                    else
                    {
                        ReadServer.Close();
                        ReadServer = null;
                        ServerFile = null;
                        return false;
                    }
                    ReadServer.Close();
                    ReadServer = null;
                    ServerFile = null;
                    return true;
                }
                else
                {
                    ServerFile = null;
                    return false;
                }
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public void WriteServerIP()
        {
            try
            {
                string filename = Path.Combine(ModInit.GstrPath, "Server.SYS");
                StreamWriter WriteServer = new StreamWriter(filename, false);
                //WriteServer.WriteLine(ModInit.GstrServerIP + "~" + ModInit.GintServerPort);
                WriteServer.WriteLine(editServerIP.Text + "~" + editPort.Text + "~" + editPlantCode.Text);
                WriteServer.Close();
                WriteServer = null;
                ModInit.GstrServerIP = editServerIP.Text.Trim();
                ModInit.GintServerPort = Convert.ToInt32(editPort.Text.Trim());
                ModInit.GstrMarkingLocation= editPlantCode.Text.Trim();
            }
            catch (Exception ex)
            {
                throw ex;
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
                if (string.IsNullOrEmpty(editPlantCode.Text.Trim()))
                {
                    Toast.MakeText(this, "Input Plant Code", ToastLength.Long).Show();
                    editPlantCode.RequestFocus();
                    IsValidate = false;
                }
                //if (cmbSite.SelectedItemPosition <= 0)
                //{
                //    Toast.MakeText(this, "Select Line", ToastLength.Long).Show();
                //    IsValidate = false;
                //}
                return IsValidate;
            }
            catch (Exception ex) { throw ex; }
        }

        //private void BindCombo()
        //{
        //    try
        //    {
        //        string _MESSAGE = "GET_LINE~" + "}";
        //        string[] _RESPONSE = oNetwork.fnSendReceiveData(_MESSAGE).Split('~');
        //        // string[] _RESPONSE = "VALID~1-LINE1~2-LINE2~3-LINE3".Split('~');
        //        switch (_RESPONSE[0])
        //        {
        //            case "VALID":
        //                for (int i = 1; i < _RESPONSE.Length; i++)
        //                {
        //                    _ListSite.Add(_RESPONSE[i]);
        //                }
        //                ArrayAdapter<string> arrayAdapter = new ArrayAdapter<string>(this, Resource.Layout.Spiner, _ListSite);
        //                cmbSite.Adapter = arrayAdapter;
        //                if (_ListSite.Count > 0)
        //                    cmbSite.SetSelection(0);
        //                break;

        //            case "INVALID":
        //                clsGLB.ShowMessage(_RESPONSE[1], this, MessageTitle.INFORMATION);
        //                break;

        //            case "ERROR":
        //                clsGLB.ShowMessage(_RESPONSE[1], this, MessageTitle.INFORMATION);
        //                break;

        //            case "NO_CONNECTION":
        //                clsGLB.ShowMessage("Communication server not connected", this, MessageTitle.INFORMATION);
        //                break;

        //            default:
        //                clsGLB.ShowMessage("No option match from comm server", this, MessageTitle.INFORMATION);
        //                break;

        //        }

        //    }
        //    catch (Exception ex)
        //    {
        //        clsGLB.ShowMessage(ex.Message, this, MessageTitle.ERROR);
        //    }
        //}

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