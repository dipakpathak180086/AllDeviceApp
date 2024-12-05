using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Net;
using System.Net.Sockets;
using IOCLAndroidApp;

class clsNetwork
{
    TcpClient client;
    bool IS_CONNECTED = false;
    internal void TcpClosed()
    {
        try
        {
            if (clsGlobal.mTcpClient != null)
            {
                clsGlobal.mTcpClient.Client.Send(Encoding.ASCII.GetBytes("quit"));

                clsGlobal.mTcpClient.Close();
            }
        }
        catch (Exception)
        {
        }
        finally
        {
            clsGlobal.mTcpClient = null;
        }
    }
    internal string GetSetTcpNewApp(string sData)
    {

        string Response = string.Empty;
        try
        {
            if (clsGlobal.mTcpClient == null)
            {
                clsGlobal.mTcpClient = new TcpClient();

                clsGlobal.mTcpClient.Connect(clsGlobal.mSockIp, Convert.ToInt32(clsGlobal.mSockPort));
                //client.Connect("192.168.43.239", Convert.ToInt32("5150"));
                IS_CONNECTED = true;
            }
            byte[] bData = Encoding.ASCII.GetBytes(sData);
            clsGlobal.mTcpClient.Client.Send(bData);

            byte[] bRes = new byte[50000000];
            int iLen = clsGlobal.mTcpClient.Client.Receive(bRes);
            Response = Encoding.ASCII.GetString(bRes, 0, iLen);

            string sReturn = "";
            while (!Response.EndsWith("}"))
            {
                sReturn += Response;

                byte[] bRes2 = new byte[50000000];
                int iLen2 = clsGlobal.mTcpClient.Client.Receive(bRes2);
                Response = Encoding.ASCII.GetString(bRes2, 0, iLen2);
                if (Response.EndsWith("}"))
                {
                    Response = Response.Replace("}", "");
                    break;
                }
            }
            Response = Response.Replace("}", "");
            sReturn += Response;
            Response = sReturn.Replace("}", "");
        }
        catch (Exception ex)
        {
            clsGlobal.mTcpClient = null;
            Response = "NO_CONNECTION~" + ex.Message;
        }
        return Response;
    }
    public string fnSendReceiveData(string strData)
    {
        string Response = string.Empty;
        try
        {
            if (clsGlobal.mTcpClient == null)
            {
                clsGlobal.mTcpClient = new TcpClient();

                clsGlobal.mTcpClient.Connect(clsGlobal.mSockIp, Convert.ToInt32(clsGlobal.mSockPort));
                //client.Connect("192.168.43.239", Convert.ToInt32("5150"));
                IS_CONNECTED = true;
            }
            byte[] bData = Encoding.ASCII.GetBytes(strData);
            clsGlobal.mTcpClient.Client.Send(bData);
          
            byte[] bRes = new byte[500000];
            int iLen = clsGlobal.mTcpClient.Client.Receive(bRes);
            Response = Encoding.ASCII.GetString(bRes, 0, iLen);
            //string sReturn = "";
            //while (!Response.EndsWith("}"))
            //{
            //    sReturn += Response;

            //    byte[] bRes2 = new byte[50000000];
            //    int iLen2 = client.Client.Receive(bRes2);
            //    Response = Encoding.ASCII.GetString(bRes2, 0, iLen2);
            //    if (Response.EndsWith("}"))
            //    {
            //        Response = Response.Replace("}", "");
            //        break;
            //    }
            //}
            //Response = Response.Replace("}", "");
            //sReturn += Response;
            //Response = sReturn.Replace("}", "");
        }
        catch (Exception ex)
        {
            clsGlobal.mTcpClient = null;
            Response = "NO_CONNECTION";
        }
       
        return Response;
    }
    public string fnSendReceiveDataOld(string strData)
    {
        string Response = string.Empty;
        try
        {
            client = new TcpClient();

            client.Connect(clsGlobal.mSockIp, Convert.ToInt32(clsGlobal.mSockPort));
            //client.Connect("192.168.43.239", Convert.ToInt32("5150"));
            IS_CONNECTED = true;
            byte[] bData = Encoding.ASCII.GetBytes(strData);
            client.Client.Send(bData);

            byte[] bRes = new byte[500000];
            int iLen = client.Client.Receive(bRes);
            Response = Encoding.ASCII.GetString(bRes, 0, iLen);
            client.Client.Send(Encoding.ASCII.GetBytes("quit"));

            client.Close();
        }
        catch (Exception ex)
        {
            if (IS_CONNECTED)
                client.Close();
            Response = "NO_CONNECTION";
        }
        finally
        { client = null; }
        return Response;
    }
}

