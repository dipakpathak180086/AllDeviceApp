using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using BatteryDispatchScannerOnline;

namespace BatteryDispatchScannerOnline
{
    class ModFunctions : Activity
    {
        //ModInit ModInit;
        clsGlobal clsGLB;
        public ModFunctions()
        {
            try
            {
                //ModInit = new ModInit();
                clsGLB = new clsGlobal();
            }

            catch (Exception ex)
            {
                clsGLB.ShowMessage(ex.Message, this, MessageTitle.ERROR);
            }
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
                        ModInit.GstrServerIP = strCon[0];
                        ModInit.GintServerPort = Convert.ToInt32(strCon[1].Trim());
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
                WriteServer.WriteLine("10.30.51.117" + "~" + "5100");
                WriteServer.Close();
                WriteServer = null;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool CheckFile(string FilePath)
        {
            FileInfo File = new FileInfo(FilePath);

            if (File.Exists == false)
            {
                File = null;
                return false;
            }
            else
            {
                File = null;
                return true;
            }
        }

        public bool DeleteFile(string FilePath)
        {
            FileInfo File = new FileInfo(FilePath);

            try
            {
                if (File.Exists == true)
                    File.Delete();
                File = null;
                return true;
            }
            catch (Exception ex)
            {
                File = null;
                return false;
                //WriteLog(ex.Message, "DeleteFile");
            }
        }

        public void WriteLog(string ErrorDesciption, string ProcedureName)
        {
        }
    }

}