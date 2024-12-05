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
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Security;
using System.Threading.Tasks;
using BatteryDispatchScannerOnline;

namespace BatteryDispatchScannerOnline
{
    class ModNet : Activity
    {

        public static Socket GtcpSocket;
        public static string DeviceIP;
        private static IPEndPoint serverEndPoint;
        private static IPAddress IPAddressServer;
        private static Int32 intBytesToFetch = 1;
        // Device name
        public static int iConnected = 0;
        private static string strDeviceName;

        // The IPHostEntry class associates a Domain Name System (DNS) host name 
        // with an array of aliases and an array of matching IP addresses
        private static IPHostEntry DeviceInfo;

        // Device's IP Address
        private static IPAddress DeviceAddress;

        public static string strReceiveData;
        public static string[] strResult;
        public static string[] strNewResult;
        public static string strRsult;
        public static int i1;

        // ModInit ModInit;
        //clsGlobal clsGLB;
        //public static ModNet()
        //{
        //    try
        //    {
        //        //ModInit = new ModInit();
        //        clsGLB = new clsGlobal();
        //    }

        //    catch (Exception ex)
        //    {
        //        clsGLB.ShowMessage(ex.Message, this, MessageTitle.ERROR);
        //    }
        //}

        // For Initializing the TcpClient
        public static Int16 InitializeTCPClient()
        {
            try
            {
                DeviceInfo = Dns.Resolve(Dns.GetHostName());
                DeviceAddress = DeviceInfo.AddressList[0];
                DeviceIP = DeviceAddress.ToString();

                // MsgBox("InitializeTCP")
                GtcpSocket = null;


                IPAddressServer = IPAddress.Parse(ModInit.GstrServerIP);
                // MsgBox("InitializeTCP")
                serverEndPoint = null;
                serverEndPoint = new IPEndPoint(IPAddressServer, ModInit.GintServerPort);


                GtcpSocket = new Socket(AddressFamily.InterNetwork, System.Net.Sockets.SocketType.Stream, System.Net.Sockets.ProtocolType.Tcp);

                // Connect to Server
                GtcpSocket.Connect(serverEndPoint);
                SendDataToServer("CLIENT_CONNECT^" + DeviceIP);

                System.Threading.Thread.Sleep(2000);

                if (ReceiveDataFromServer() == "0")
                    return 0;
                else
                    return 1;
            }

            catch (SocketException ex)
            {
                //if (iConnected == 1)
                //    clsGLB.ShowMessage(ex.Message, this, MessageTitle.ERROR);
                //else
                //clsGLB.ShowMessage(ex.Message, this, MessageTitle.ERROR);
                //throw ex;

                return 2;
            }
            catch (Exception ex)
            {
                //throw ex;
                return 1;
            }
        }
        // For Closing the TCP Client
        public static void TerminateTCPClient()
        {
            try
            {
                // Send SHUTDOWN Command to the Server
                SendDataToServer("SHUTDOWN");
                // Socket Class Shutdowns the Both client and Server 
                GtcpSocket.Shutdown(SocketShutdown.Both);
                GtcpSocket.Close();
                GtcpSocket = null;
            }
            catch (Exception ex)
            {
                //clsGLB.ShowMessage("Could Not Connect to Server.Application Cannot Continue.", this, MessageTitle.ERROR);
                // MessageBox.Show("Could Not Connect to Server. Application Cannot Continue.", GstrMsgApp, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                //Application.Exit();
                throw ex;

            }
        }
        // For Sending data to the Server
        public static void SendDataToServer(string strData)
        {
            string strOlddata = "";
            // Dim dataBuffer() As Byte = System.Text.Encoding.ASCII.GetBytes("")
            try
            {
                byte[] dataBuffer = System.Text.Encoding.ASCII.GetBytes("");
                // MsgBox("Data Send to server")
                // Convert Data to Byte Array
                strOlddata = strData;
                dataBuffer = System.Text.Encoding.ASCII.GetBytes(strData + ">");

                // Send Data
                GtcpSocket.Send(dataBuffer);
            }
            catch (SocketException ex)
            {
                //if (Symbol.WirelessLAN.AssociationStatus.S24_REG_STATUS_NOT_ASSOCIATED == Symbol.WirelessLAN.AssociationStatus.S24_REG_STATUS_NOT_ASSOCIATED)
                //    System.Threading.Thread.Sleep(15000);


                if (InitializeTCPClient() != 0)
                {
                    //clsGLB.ShowMessage("Restart Application., Invalid Server IP Address", this, MessageTitle.ERROR);
                    // MessageBox.Show("Restart Application.", "Invalid Server IP Address", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                    return;
                }
                else
                    // MsgBox("Sending.....")

                    SendDataToServer(strOlddata);
            }
            catch (Exception ex)
            {
                throw ex;
                //clsGLB.ShowMessage(ex.Message, this, MessageTitle.ERROR);
                //Interaction.MsgBox(ex.Message);
            }
        }
        // For Receiving Data from Server
        public static string ReceiveDataFromServer()
        {
            try
            {
                byte[] dataBuffer = System.Text.Encoding.ASCII.GetBytes("");
                string ReturnValue = "";
                Int32 NoOfBytes;

                dataBuffer = new byte[intBytesToFetch + 1];

                while (true)
                {
                    // Receive Data from Server
                    NoOfBytes = GtcpSocket.Receive(dataBuffer);


                    ReturnValue = ReturnValue + System.Text.Encoding.ASCII.GetString(dataBuffer, 0, NoOfBytes);

                    //if (ReturnValue.StartsWith("||") & ReturnValue.EndsWith("||") & ReturnValue.Length > 4)
                    //    break;
                    if (ReturnValue.EndsWith(">"))
                        break;
                }

                return ReturnValue.Replace(">", "");
            }
            catch (Exception ex)
            {
                //clsGLB.ShowMessage(ex.Message, this, MessageTitle.ERROR);
                //MessageBox.Show(ex.Message);
                throw ex;
            }
        }
        // For Receiving file Datat From Server
        public static void ReceiveFileFromServer(string DataFile)
        {
            string strData;
            Int32 NoOfBytes;
            byte[] dataBuffer = System.Text.Encoding.ASCII.GetBytes("");


            FileInfo File = new FileInfo(ModInit.GstrPath + @"\" + DataFile);
            // Check whether the File Exist or not
            if (File.Exists == true)
                File.Delete();


            BinaryWriter FileWriter = new BinaryWriter(new FileStream(ModInit.GstrPath + @"\" + DataFile, FileMode.Create));

            //try
            //{
            //    // Receive File Data from Server
            //    while (true)
            //    {
            //        dataBuffer = new byte[intBytesToFetch + 1];
            //        NoOfBytes = GtcpSocket.Receive(dataBuffer);

            //        strData = System.Text.Encoding.ASCII.GetString(dataBuffer, 0, NoOfBytes);
            //        if (String.InStr(strData, "|", CompareMethod.Binary) > 0)
            //            break;

            //        FileWriter.Write(dataBuffer);
            //        Application.DoEvents();
            //    }
            //    FileWriter.Close();
            //}
            //catch (Exception ex)
            //{
            //    Interaction.MsgBox("Error in Receiving File : " + ex.Message, MsgBoxStyle.Critical, DataFile);
            //}
        }
        // For
        public static void SendFileToServer(string DataFile)
        {
            byte[] dataBuffer = System.Text.Encoding.ASCII.GetBytes("");
            FileInfo File = new FileInfo(ModInit.GstrPath + @"\" + DataFile);

            if (File.Exists == true)
            {
                BinaryReader FileReader = new BinaryReader(new FileStream(ModInit.GstrPath + @"\" + DataFile, FileMode.Open));

                try
                {
                    dataBuffer = new byte[intBytesToFetch + 1];
                    // Send File Data to Server
                    while (true)
                    {
                        dataBuffer = FileReader.ReadBytes(intBytesToFetch);
                        if (dataBuffer.Length == 0)
                            break;
                        GtcpSocket.Send(dataBuffer);

                    }

                    FileReader.Close();

                    SendDataToServer("||");
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }
        // For Checking the UserID and Password 
        //public static  bool CheckUser(string strUsername, string strPassword)
        //{
        //    try
        //    {
        //        // Send userID and Password to the Server Side
        //        SendDataToServer("LOGIN~" + strUsername.Trim() + "~" + strPassword.Trim());
        //        Application.DoEvents();
        //        // Split the Received data From Server with @
        //        strResult = ReceiveDataFromServer.Split("@");

        //        if (strResult[0] == "1")
        //        {
        //            // For Checking whether the Received 
        //            if (Information.UBound(strResult) == System.Convert.ToInt32(strResult[1]) + 2)
        //            {
        //                for (i1 = 0; i1 <= strResult.Length - 1; i1++)
        //                    return true;
        //            }
        //            else if (strResult[0] == "2")
        //                return false;
        //            else if (strResult[0] == "0")
        //                return false;
        //        }
        //        else if (strResult[0] == "ERROR")
        //            return false;
        //        else
        //            return false;
        //    }
        //    catch (Exception ex)
        //    {
        //        return false;
        //    }
        //}
        public static bool LocationCheck(string strLocation)
        {
            try
            {
                SendDataToServer("LOCATIONCHECK~" + strLocation + "~");
                //Application.DoEvents();
                strResult = ReceiveDataFromServer().Split("@");
                if (ReceiveDataFromServer() == "1")
                    return true;
                else if (ReceiveDataFromServer() == "ERROR~Incorrect Data.")
                {
                    strResult = ReceiveDataFromServer().Split("~");
                    return false;
                }
                else if (strResult[0] == "0")
                    return false;

                return false;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public static bool LocationCheckMarking(string strLocation)
        {
            try
            {
                bool result = false;
                SendDataToServer("LOCATIONCHECKMARKING~" + strLocation + "~");
                //Application.DoEvents();
                strResult = ReceiveDataFromServer().Split("@");
                if (ReceiveDataFromServer() == "1")
                    result = true;
                else if (ReceiveDataFromServer() == "ERROR~Incorrect Data.")
                {
                    strResult = ReceiveDataFromServer().Split("~");
                    result = false;
                }
                else if (strResult[0] == "0")
                    result = false;

                return result;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public static bool LocationCheckLoading(string strLocation)
        {
            try
            {
                SendDataToServer("LOCATIONCHECKLOADING~" + strLocation + "~");
                // Application.DoEvents();
                strResult = ReceiveDataFromServer().Split("@");

                if (strResult[0] == "1")
                {
                    if (strResult.Length == System.Convert.ToInt32(strResult[1]) + 2)
                        return true;
                    else
                        return false;
                }
                else if (ReceiveDataFromServer() == "ERROR~Incorrect Data.")
                {
                    strResult = ReceiveDataFromServer().Split("~");
                    return false;
                }
                else if (strResult[0] == "5")
                    return false;
                else if (strResult[0] == "4")
                    return false;
                else if (strResult[0] == "3")
                    return false;
                else if (strResult[0] == "2")
                    return false;

                return false;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public static bool SaveStock(string strLocation, string strFrameID)
        {
            try
            {
                SendDataToServer("SAVESTOCKTAKING~" + strLocation + "~" + strFrameID);
                //Application.DoEvents();

                ModInit.Gstrarr = ReceiveDataFromServer().Split("~");

                if (ModInit.Gstrarr[0] == "1")
                    return true;
                else
                    return false;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public static bool BikeStatusCheck(string strBikeStatus)
        {
            try
            {
                SendDataToServer("BIKESTATUSCHECK~" + strBikeStatus + "~");
                //Application.DoEvents();
                strResult = ReceiveDataFromServer().Split("@");

                if (strResult[0] == "1")
                    return true;
                else if (ReceiveDataFromServer() == "ERROR~Incorrect Data.")
                    return false;
                else if (strResult[0] == "0")
                    return false;

                return false;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public static bool BikeStatusCheckLoading(string strBikeStatus)
        {
            try
            {
                SendDataToServer("BIKESTATUSCHECKLOADING~" + strBikeStatus + "~");
                //Application.DoEvents();
                strResult = ReceiveDataFromServer().Split("@");
                if (strResult[0] == "1")
                    return true;
                else if (ReceiveDataFromServer() == "ERROR~Incorrect Data.")
                {
                    strResult = ReceiveDataFromServer().Split("~");
                    return false;
                }
                else if (strResult[0] == "EXCEPTION")
                    return false;
                else if (strResult[0] == "0")
                    return false;

                return false;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public static bool PickListStatusCheck(string strPicklistNo)
        {
            try
            {
                SendDataToServer("PICKLISTSTATUSCHECK~" + strPicklistNo + "~");
                //Application.DoEvents();

                strResult = ReceiveDataFromServer().Split("@");

                if (strResult[0] == "1")
                {
                    if (strResult.Length == System.Convert.ToInt32(strResult[1]) + 2)
                    {
                        for (i1 = 0; i1 <= strResult.Length - 1; i1++)
                            return true;
                    }
                    else if (strResult[0] == "0")
                        return false;
                    else if (strResult[0] == "2")
                        return false;
                }
                else if (ReceiveDataFromServer() == "ERROR~Incorrect Data.")
                    strResult = ReceiveDataFromServer().Split("~");
                else
                    return false;

                return false;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public static bool BikeStatusCheckMarking(string strBikeStatus)
        {
            try
            {
                SendDataToServer("BIKESTATUSCHECKMARKING~" + strBikeStatus + "~");
                //Application.DoEvents();

                strResult = ReceiveDataFromServer().Split("@");
                if (ReceiveDataFromServer() == "1")
                    return true;
                else if (ReceiveDataFromServer() == "ERROR~Incorrect Data.")
                    return false;
                else if (strResult[0] == "0")
                    return false;

                return false;
            }
            catch (Exception ex)
            {
                // WriteLog(ex.Message, "BikeStatusCheckMarking")
                return false;
            }
        }


        public static bool FrameStatusCheck(string strLocation, string strFrameNo)
        {
            try
            {
                SendDataToServer("SAP_RECEIVING~" + strLocation.ToUpper() + "~" + strFrameNo);
                //Application.DoEvents();
                ModInit.GstrResult = ReceiveDataFromServer();

                ModInit.Gstrarr = ModInit.GstrResult.Split("~");

                if (ModInit.Gstrarr[0] == "1")
                {
                    if (ModInit.Gstrarr[1] == "Y")
                        return true;
                    else
                        // GstrResult = "NONE"
                        return false;
                }
                else
                    return false;
            }
            catch (Exception ex)
            {
                // WriteLog(ex.Message, "FrameStatusCheck")
                return false;
            }
        }
        public static bool FRAMESTATUSCHECKMARKING(string strPickListNo, string strBikeID, string strMarkLocation)
        {
            try
            {
                SendDataToServer("SAP_MARKING~" + strPickListNo + "~" + strBikeID + "~" + strMarkLocation);
                // MsgBox("1")

                //Application.DoEvents();
                ModInit.GstrResult = "";
                ModInit.Gstrarr = ReceiveDataFromServer().Split("~");
                if (ModInit.Gstrarr[0] == "1")
                {
                    if (ModInit.Gstrarr[1] == "Y")
                        return true;
                    else
                        return false;
                }
                else
                    return false;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public static bool FetchDeliveryDetails(string strDeliveryNo, string optionc)
        {
            try
            {
                SendDataToServer("SAP_FETCHDELIVERYDETAILS~" + strDeliveryNo + "~" + optionc);
                //Application.DoEvents();
                ModInit.GstrResult = ReceiveDataFromServer();
                ModInit.Gstrarr = ModInit.GstrResult.Split("~");

                if (ModInit.Gstrarr[0] == "00" + strDeliveryNo)
                    return true;
                else
                    return false;
            }
            catch (Exception ex)
            {
                // WriteLog(ex.Message, "FrameStatusCheckLoading")
                return false;
            }
        }

        public static bool FrameStatusCheckLoading(string strPicklistNo, string strFrameID, string strbayno)
        {
            try
            {
                SendDataToServer("SAP_LOADING~" + strPicklistNo + "~" + strFrameID + "~" + strbayno);
                //Application.DoEvents();
                ModInit.GstrResult = ReceiveDataFromServer();
                ModInit.Gstrarr = ModInit.GstrResult.Split("~");

                if (ModInit.Gstrarr[0] == "1")
                {
                    if (ModInit.Gstrarr[1] == "L")
                        return true;
                    else
                        return false;
                }
                else
                    return false;
            }
            catch (Exception ex)
            {
                // WriteLog(ex.Message, "FrameStatusCheckLoading")
                return false;
            }
        }
        public static bool Locationstatuscheck(string strlocationid)
        {
            try
            {
                SendDataToServer("LOCATIONCHECKSTATUS~" + strlocationid);
                //Application.DoEvents();
                strResult = ReceiveDataFromServer().Split("~");
                if (strResult[0] == "5")
                    return false;
                else if (strResult[0] == "1")
                    return true;
                else if (ReceiveDataFromServer() == "ERROR~Incorrect Data.")
                    return false;
                else if (strResult[0] == "0")
                    return false;
                return false;
            }
            catch (Exception ex)
            {
                // WriteLog(ex.Message, "Locationstatuscheck")
                return false;
            }
        }

        #region Battery Scanning 

        public static bool FetchBatteryDeliveryData(string strDeliveryNo)
        {
            try
            {
                SendDataToServer("SAP_BAT_FETCH_DELIVERY_DATA^" + strDeliveryNo);
                //Application.DoEvents();
                ModInit.GstrResult = ReceiveDataFromServer();

                ModInit.Gstrarr = ModInit.GstrResult.Split("~");
                if (ModInit.Gstrarr[0] == "00" + strDeliveryNo)
                    return true;
                else
                    return false;
            }
            catch (Exception ex)
            {
                // WriteLog(ex.Message, "FrameStatusCheckLoading")
                return false;
            }
        }
        public static bool ValidateBatteryData(string strDeliveryNo, string strSKU, string strBatteryBatteryBarcode)
        {
            try
            {
                SendDataToServer("SAP_VALIDATE_BAT_DATA^" + strDeliveryNo + "^" + strSKU + "^" + strBatteryBatteryBarcode);
                //Application.DoEvents();
                ModInit.GstrResult = ReceiveDataFromServer();

                ModInit.Gstrarr = ModInit.GstrResult.Split("~");
                if (ModInit.Gstrarr[0] == "OK")
                    return true;
                else
                    return false;
            }
            catch (Exception ex)
            {
                // WriteLog(ex.Message, "FrameStatusCheckLoading")
                return false;
            }
        }
        public static bool GetBatteryTypeData(string strBatteryBatteryBarcode,ref string strBatType)
        {
            try
            {
                SendDataToServer("SAP_GET_BAT_TYPE_DATA^" + strBatteryBatteryBarcode);
                //Application.DoEvents();
                ModInit.GstrResult = ReceiveDataFromServer();
                ModInit.Gstrarr = ModInit.GstrResult.Split("~");
                if (ModInit.Gstrarr[0] == "OK")
                {
                    strBatType = ModInit.Gstrarr[1];
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                // WriteLog(ex.Message, "FrameStatusCheckLoading")
                return false;
            }
        }
        public static bool ValidateBatteryDataTemp(string strDeliveryNo, string strSKU, string strBatteryBatteryBarcode)
        {
            try
            {

                return true;

            }
            catch (Exception ex)
            {
                // WriteLog(ex.Message, "FrameStatusCheckLoading")
                return false;
            }
        }

        public static bool BatteryScanningDataSave(string strDeliveryNo, string strSKU, string strBatteryBarcode)
        {
            try
            {
                SendDataToServer("SAP_BAT_SAVE_DATA^" + strDeliveryNo + "^" + strSKU + "^" + strBatteryBarcode);
                //Application.DoEvents();
                ModInit.GstrResult = ReceiveDataFromServer();
                ModInit.Gstrarr = ModInit.GstrResult.Split("~");

                if (ModInit.Gstrarr[0] == "OK")
                {
                    return true;
                }
                else
                    return false;
            }
            catch (Exception ex)
            {
                // WriteLog(ex.Message, "FrameStatusCheckLoading")
                return false;
            }
        }

        public static bool SaveRverseDelivery(string strIsFlag, string strDeliveryNo)
        {
            try
            {
                SendDataToServer("SAP_BAT_REVERSE_DELIVERY_DATA^" + strIsFlag + "^" + strDeliveryNo);
                //Application.DoEvents();
                ModInit.GstrResult = ReceiveDataFromServer();

                ModInit.Gstrarr = ModInit.GstrResult.Split("~");
                if (ModInit.Gstrarr[0] == "Success")
                    return true;
                else
                    return false;
            }
            catch (Exception ex)
            {
                // WriteLog(ex.Message, "FrameStatusCheckLoading")
                return false;
            }
        }

        public static bool STOBatteryScanningDataSave(string strSKU, string strDeliveryNo, string strTruckNo, string strBatteryBarcode, string strFrame)
        {
            try
            {
                SendDataToServer("SAP_STO_BAT_SAVE_DATA^" + strSKU + "^" + strDeliveryNo + "^" + strTruckNo + "^" + strBatteryBarcode + "^" + strFrame + "^" + ModInit.GstrMarkingLocation);
                //Application.DoEvents();
                ModInit.GstrResult = ReceiveDataFromServer();
                ModInit.Gstrarr = ModInit.GstrResult.Split("~");

                if (ModInit.Gstrarr[0] == "OK")
                {
                    return true;
                }
                else
                    return false;
            }
            catch (Exception ex)
            {
                // WriteLog(ex.Message, "FrameStatusCheckLoading")
                return false;
            }
        }

        #endregion
    }

}