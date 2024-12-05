using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using IOCLAndroidApp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AISScanningApp
{
    internal class FTPMain
    {
        private FtpHandler _FtpHandler = new FtpHandler();
        public long _lLen = 0;
        /// <summary>
        /// Ftp Upload Function
        /// </summary>
        /// <param name="sFileName"></param>
        /// <returns></returns>
        internal bool FtpUpload(string sFileName)
        {
            try
            {
                // _FtpHandler.ftpServerIP = clsGlobal.mFtpAddress + ":" + clsGlobal.mFtpPort;
                _FtpHandler.ftpServerIP = clsGlobal.mFtpAddress;
                _FtpHandler.ftpUserID = clsGlobal.mFtpUserName;
                _FtpHandler.ftpPassword = clsGlobal.mFtpPassword;
                _FtpHandler.Upload(sFileName);
                return true;
            }
            catch (Exception ex)
            {
               
                return false;
                throw;
            }
        }
        /// <summary>
        /// Ftp Download Function
        /// </summary>
        /// <param name="sFileName"></param>
        /// <returns></returns>
        internal bool FtpDownload(string sFilePath, string sFileName)
        {
            try
            {
                _FtpHandler.ftpServerIP = clsGlobal.mFtpAddress + ":" + clsGlobal.mFtpPort;
                _FtpHandler.ftpUserID = clsGlobal.mFtpUserName;
                _FtpHandler.ftpPassword = clsGlobal.mFtpPassword;
                _FtpHandler.Download(sFilePath, sFileName, out _lLen);
                return true;
            }
            catch (Exception)
            {
                return false;
                throw;
            }
        }
        /// <summary>
        /// Remove File Form Ftp
        /// </summary>
        /// <param name="sFileName"></param>
        /// <returns></returns>
        internal bool FtpRemove(string sFileName)
        {
            try
            {
                _FtpHandler.ftpServerIP = clsGlobal.mFtpAddress + ":" + clsGlobal.mFtpPort;
                _FtpHandler.ftpUserID = clsGlobal.mFtpUserName;
                _FtpHandler.ftpPassword = clsGlobal.mFtpPassword;
                _FtpHandler.DeleteFTP(sFileName);
                return true;
            }
            catch (Exception)
            {
                return false;
                throw;
            }
        }
    }
}