using Android.App;
using Android.Content;
using Android.OS;
using Android.Text;
using Android.Util;
using Android.Views;
using Android.Widget;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using Android.Content;
using Android.Provider;

namespace SMPDisptach
{
    public enum MessageTitle
    {
        ERROR = 1,
        CONFIRM = 2,
        INFORMATION = 3,
    }

    public class clsGlobal : Activity
    {
        public static string mMainSqlConString = "";
        public static string MainFolder = "SatoFiles";
        public static string MasterFolder = "Master";
        // public static string mUploadPath = "HHTUpload";
        public static string TranscationFolder = "Transcation";
        public static string mPatternPath = "Patterns";
        public static string mDNHADir = "DNHA";
        public static string mCustomerDir = "CUSTOMER";
        public static string mSupplierDir = "SUPPLIER";
        public static string LoginFileName = "LOGIN.txt";
        public static string mAlertPassFileName = "ALERT_PASS.txt";
        public static string mAlertMessageFileName = "ALERT_MSG.txt";
        public static string DNHMaterFileName = "DNHA_PART_DATA.txt";
        public static string CustomerMaterFileName = "CUST_PART_DATA.txt";
        public static string SupplierMaterFileName = "SUP_PART_DATA.txt";
        public static string NGMaterFileName = "NG_PART_DATA.txt";
        public static string DNHAPatternFileName = "DNHA_PATTERN_DATA.txt";
        public static string CustomerPatternFileName = "CUSTOMER_PATTERN_DATA.txt";
        public static string SupplierPatternFileName = "SUPPLIER_PATTERN_DATA.txt";

        public static string CustomerWiseExpiry = "CUST_EXP_DATA.txt";

        public static string ServerIpFileName = "ServerIP.txt";
        public static string SILMasterDataFile = "SILMasterData.txt";
        public static string SILDetailsFile = "SILDetailsData.txt";
        public static string SILCompletedFile = "SILCompleted.txt";
        public static string SILBarcode = "SILBarcode.txt";
        public static readonly string LogTag = "Logs";
        public static readonly string LogFileName = "app_log.txt";

        public static string mSILType = "";
        public static string FilePath = global::Android.OS.Environment.ExternalStorageDirectory.AbsolutePath + "/" + MainFolder;
        public static TcpClient mTcpClient;
        internal static string mSockIp = "";
        internal static Int32 mSockPort = 0;
        public static string LineId = "";
        public static string mEnterDelivery = "";
        public static string mUserId = "1";
        public static string mDNHAKanbanString = "";
        public static string mCustomerKanbanString = "";
        public static string mSupplierKanbanString = "";
        public static string mShipmentType = "";
        public static string m3CheckPointsDigit = "";
        public static string mAlertPassword = "";
        public static string mAlertMeassage = "";
        public static string mWarehouseNo = "";
        public static string mDeviceID = "";
        public static string mFTPIP = "";
        public static string mFTPUserID = "";
        public static string mFTPPassword = "";
        public static string mDatabaseServer = "";
        public static string mDatabaseName = "";
        public static string mDatabaseUserId = "";
        public static string mDatabasePassword = "";
        public static string mCustSeqNo = "";
        public static string mDNHASupSeqNo = "";
        public static string mCustomerCode = "";
        public static string GetUPICODE(int length, string deviceId)
        {
            // Note: i, o, l, 0, and 1 have been removed to reduce 
            // chances of user typos and mis-communication of passwords.
            //'i', 'I',
            //'l', 'L',
            //'o', 'O',
            //'0', '1',
            char[] allowedCharacters = { 'a', 'A', 'b', 'B', 'c', 'C', 'd', 'D', 'e', 'E', 'f', 'F', 'g', 'G', 'h', 'H', /*'i', 'I',*/ 'j', 'J', 'k', 'K', /*'l', 'L',*/ 'm', 'M', 'n', 'N', /*'o', 'O',*/ 'p', 'P', 'q', 'Q', 'r', 'R', 's', 'S', 't', 'T', 'u', 'U', 'v', 'V', 'w', 'W', 'x', 'X', 'y', 'Y', 'z', 'Z', /*'0', '1',*/ '2', '3', '4', '5', '6', '7', '8', '9' };
            char[] allDevice = deviceId.ToCharArray();
            // Create a byte array to hold the random bytes.
            byte[] randomNumber = new byte[length];

            // Create a new instance of the RNGCryptoServiceProvider.
            RNGCryptoServiceProvider Gen = new RNGCryptoServiceProvider();

            // Fill the array with a random value.
            Gen.GetBytes(randomNumber);

            string result = "";
            int iCount = 1;
            foreach (byte b in randomNumber)
            {
                // Convert the byte to an integer value to make the modulus operation easier.
                int rand = Convert.ToInt32(b);
                iCount += 1;
                // Return the random number mod'ed.
                // This yeilds a possible value for each character in the allowable range.
                int value = (rand % allowedCharacters.Length) % allDevice.Length;

                char thisChar = allowedCharacters[value];
                if (iCount == 6)
                {
                    int milliseconds = DateTime.Now.Millisecond;
                    string msTwoDigit = (milliseconds / 10).ToString("D2");
                    result += msTwoDigit;
                    result += thisChar;
                    return result.ToUpper();
                }

                result += thisChar;
            }

            return result.ToUpper();
        }

        public static string GetDeviceId(Context context)
        {
            return Settings.Secure.GetString(context.ContentResolver, Settings.Secure.AndroidId);
        }
        public static string GenerateDeviceLinkedSerial(string deviceId)
        {
            using (SHA256 sha = SHA256.Create())
            {
                byte[] hash = sha.ComputeHash(Encoding.UTF8.GetBytes(deviceId));
                long longHash = BitConverter.ToInt64(hash, 0);
                if (longHash < 0) longHash = -longHash;

                string base36 = Base36Encode(longHash).PadLeft(7, '0');

                // Ensure it is alphanumeric and uppercase
                base36 = Regex.Replace(base36.ToUpper(), "[^A-Z0-9]", "").Substring(0, 7);
                return base36;
            }
        }

        private static string Base36Encode(long value)
        {
            const string chars = "0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            StringBuilder result = new StringBuilder();

            do
            {
                result.Insert(0, chars[(int)(value % 36)]);
                value /= 36;
            } while (value > 0);

            return result.ToString();
        }
        public static string ReplaceCaretWithNewlines(string input)
        {
            if (string.IsNullOrEmpty(input))
            {
                return input; // Return the original string if it's null or empty
            }

            // Replace the caret symbol ('^') with the default newline sequence
            // Since you need to reverse, choose one consistent newline format, usually \r\n.
            return input.Replace("^", "\r\n");
        }
        public static void mBindDataTablesSep(string filePath1, string filePath2, string separator, ref DataTable masterTable, ref DataTable detailsTable)
        {
            masterTable = mReadFileToDataTableSep(filePath1, separator);
            detailsTable = mReadFileToDataTableSep(filePath2, separator);

            // Assuming you want to merge the data based on some key columns
            // Modify the merging logic as per your actual use case
            //DataTable mergedTable = masterTable.Clone(); // Clone structure

        }

        // Helper function to read a file and convert it to a DataTable
        public static DataTable mReadFileToDataTableSep(string filePath, string separator)
        {
            DataTable dataTable = new DataTable();
            string[] lines = File.ReadAllLines(filePath);

            if (lines.Length > 0)
            {
                // Determine the number of columns based on the first row
                string[] firstRowData = lines[0].Split('~');
                int columnCount = firstRowData.Length;

                // Add generic columns (Column1, Column2, etc.)
                for (int i = 0; i < columnCount; i++)
                {
                    dataTable.Columns.Add("Column" + (i + 1));
                }

                // Add rows for each line in the file
                foreach (string line in lines)
                {
                    string[] data = line.Split('~');
                    dataTable.Rows.Add(data);
                }
            }

            return dataTable;
        }
        public static void ConvertDataTableToTxt(DataTable dataTable, string filePath)
        {
            //if (!File.Exists(filePath)) { File.Create(filePath); }
            //else { File.Delete(filePath); }
            using (StreamWriter writer = new StreamWriter(filePath, false)) // 'false' ensures overriding
            {
                // Write the rows only (skip column headers)
                foreach (DataRow row in dataTable.Rows)
                {
                    for (int i = 0; i < dataTable.Columns.Count; i++)
                    {
                        writer.Write(row[i].ToString());
                        if (i < dataTable.Columns.Count - 1)
                        {
                            writer.Write("$"); // Use tab or comma as delimiter
                        }
                    }
                    writer.WriteLine();
                }
            }
        }
        public static bool ReadServerSetting()
        {
            try
            {
                string filename = Path.Combine(clsGlobal.FilePath, "ServerSetting.txt");
                FileInfo ServerFile = new FileInfo(filename);
                StreamReader ReadServer;
                string[] strCon;
                if (ServerFile.Exists == true)
                {
                    ReadServer = new StreamReader(filename);
                    strCon = ReadServer.ReadLine().Split("~");
                    if (strCon.Length >= 1)
                    {
                        System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);
                        mDatabaseServer = strCon[0].Trim();
                        mDatabaseName = strCon[1].Trim();
                        mDatabaseUserId = strCon[2].Trim();
                        mDatabasePassword = strCon[3].Trim();
                        mMainSqlConString = "Server=" + mDatabaseServer + "; Database=" + mDatabaseName + ";Uid=" + mDatabaseUserId + "; pwd=" + mDatabasePassword + "; pooling=true";
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
        public static void DeleteDirectory(string directoryPath)
        {
            if (Directory.Exists(directoryPath))
            {
                // Get all files and subdirectories in the directory
                var files = Directory.GetFiles(directoryPath);
                var subDirectories = Directory.GetDirectories(directoryPath);

                // Delete all files
                foreach (var file in files)
                {
                    File.Delete(file);
                }

                // Recursively delete subdirectories
                foreach (var subDirectory in subDirectories)
                {
                    DeleteDirectory(subDirectory);
                }

                // Finally, delete the directory itself
                Directory.Delete(directoryPath);
            }
            else
            {
                Console.WriteLine("Directory does not exist: " + directoryPath);
            }
        }
        public static DateTime? ParseDate(string dateStr)
        {
            // Possible formats
            string[] formats = {
            "dd-MM-yyyy", "MM-dd-yyyy", "yyyy-MM-dd",
            "dd/MM/yyyy", "MM/dd/yyyy", "yyyy/MM/dd",
            "dd.MM.yyyy", "MM.dd.yyyy", "yyyy.MM.dd","yyyyMMdd"
        };

            foreach (string format in formats)
            {
                if (DateTime.TryParseExact(dateStr, format, CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime date))
                {
                    // Logical validation to resolve conflicts between MM-dd-yyyy and dd-MM-yyyy
                    if (format == "MM-dd-yyyy" || format == "dd-MM-yyyy")
                    {
                        // If the day exceeds 12, it must be dd-MM-yyyy
                        if (date.Day > 12 && format == "MM-dd-yyyy")
                            continue;

                        // If the month exceeds 12, it must be MM-dd-yyyy
                        if (date.Month > 12 && format == "dd-MM-yyyy")
                            continue;
                    }

                    // Return the first valid and logically correct date
                    return date;
                }
            }

            // If no format matches
            return null;
        }
        public static void DeleteDirectoryWithOutFile(string directoryPath)
        {
            if (Directory.Exists(directoryPath))
            {
                // Get all files and subdirectories in the directory

                var subDirectories = Directory.GetDirectories(directoryPath);

                // Recursively delete subdirectories
                foreach (var subDirectory in subDirectories)
                {
                    var files = Directory.GetFiles(subDirectory).Length;
                    bool fileExists = File.Exists(Path.Combine(subDirectory, SILMasterDataFile));
                    if (!fileExists)
                    {
                        DeleteDirectory(subDirectory);
                    }
                }

                // Finally, delete the directory itself
                // Directory.Delete(directoryPath);


            }
            else
            {
                Console.WriteLine("Directory does not exist: " + directoryPath);
            }
        }
        public static string mCheckSILTILType(string strSILTILBarcode)
        {
            try
            {
                if (Regex.IsMatch(strSILTILBarcode, @"^\d{17}[A-Z]\S+"))
                {
                    return "SIL";
                }
                else if (Regex.IsMatch(strSILTILBarcode, @"^\d{17}\s{2}\S+\s\S+"))
                {
                    return "TIL";
                }
                else
                {
                    return "SIL";
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
        public static bool mCheckDNHABarcode(string dnHABarcode)
        {
            try
            {
                if (dnHABarcode.StartsWith("DISC"))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public static string mGetCheckPoints(string strSILBarcode)
        {
            string strReturn = "";
            try
            {
                if (strSILBarcode.Length > 20)
                {
                    string str = strSILBarcode.Substring(17, 1);
                    if (char.IsLetter(str, 0))
                    {
                        strReturn = "3POINTS";
                        //  mShipmentType = "S";
                        m3CheckPointsDigit = str;
                    }
                    else if (str == " ")
                    {
                        strReturn = "2POINTS";
                        // mShipmentType = "T";

                    }
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }

            return strReturn;
        }
        public static string mGetCustomerCode(string strSILBarcode)
        {
            string strReturn = "";
            try
            {
                if (strSILBarcode.Length > 20)
                {
                    string str = strSILBarcode.Substring(7, 8);
                    mCustomerCode = str;
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }

            return mCustomerCode;
        }
        public static List<PL_DNHA_MASTER> mlistDNHA = new List<PL_DNHA_MASTER>();
        public static List<PL_CUSTOMER_MASTER> mlistAllCustomer = new List<PL_CUSTOMER_MASTER>();
        public static List<PL_CUSTOMER_MASTER> mlistCustomer = new List<PL_CUSTOMER_MASTER>();
        public static List<PL_SUPPLIER_MASTER> mlistSupplier = new List<PL_SUPPLIER_MASTER>();
        public static List<PL_SUSPECTED_LOT> mlistSuspectedLot = new List<PL_SUSPECTED_LOT>();
        public static List<Login> mlistLogin = new List<Login>();
        public static List<PL_PATTERN> mlistDNHAPattern = new List<PL_PATTERN>();
        public static List<PL_PATTERN> mlistCustomerPattern = new List<PL_PATTERN>();
        public static List<PL_PATTERN> mlistSupplierPattern = new List<PL_PATTERN>();
        public static List<PL_CUST_EXP_MASTER> mlistCustWiseExpiry = new List<PL_CUST_EXP_MASTER>();
        public static List<KanbanData> GetSILData(string inputString)
        {
            var outputList = new List<KanbanData>();
            try
            {




                string truckNo = null;
                string customerCode = null;
                string shipToLoc = null;
                string pointCheck = null;
                string part = null;
                string qty = "0";
                string partNo = null;
                string string1 = null;
                string string2 = null;
                int start = 1;
                int end = 0;
                int minus = 0;
                int len46 = 0;

                truckNo = "";
                customerCode = "";
                shipToLoc = "";
                pointCheck = "";
                part = "";
                qty = "0";
                string2 = "";

                // Calculate len46 like in the SQL function
                len46 = inputString.Substring(0, Math.Min(25, inputString.Length)).Length
                - inputString.Substring(0, Math.Min(25, inputString.Length)).Replace(" ", "").Length;

                if (len46 >= 3 && inputString.Length == 46)
                {
                    truckNo = inputString.Substring(0, 7);
                    customerCode = inputString.Substring(7, 8);
                    shipToLoc = inputString.Substring(15, 2);
                    pointCheck = inputString.Substring(20, 3);
                }
                else if (len46 >= 3 && inputString.Length > 46)
                {
                    string1 = inputString.Substring(0, 46);
                    string2 = inputString.Substring(46);

                    truckNo = string1.Substring(0, 7);
                    customerCode = string1.Substring(7, 8);
                    shipToLoc = string1.Substring(15, 2);
                    pointCheck = string1.Substring(20, 3);
                }
                else if (inputString.Length > 42)
                {
                    string1 = inputString.Substring(0, 42);
                    string2 = inputString.Substring(42);

                    truckNo = string1.Substring(0, 7);
                    customerCode = string1.Substring(7, 8);
                    shipToLoc = string1.Substring(9, 2);
                    pointCheck = string1.Substring(17, 3);
                }
                else
                {
                    truckNo = inputString.Substring(0, 7);
                    customerCode = inputString.Substring(7, 8);
                    shipToLoc = inputString.Substring(9, 2);
                    pointCheck = inputString.Substring(17, 3);
                }

                if (len46 >= 3)
                {
                    string2 = inputString.Substring(24, inputString.Length - 24);
                }
                else
                {
                    string2 = inputString.Substring(20, inputString.Length - 20);
                }

                // Calculate the end value
                end = string2.Length / 22;

                // Iterate to process parts and quantities
                while (start <= end)
                {
                    //if (minus == 0)
                    //{
                    //    part = string2.Substring(0, 15).Trim();
                    //    qty = decimal.Parse(string2.Substring(15, 7).Trim());
                    //    minus += part.Length + qty.ToString().Length + 1;
                    //}
                    //else
                    //{
                    //    part = string2.Substring(minus, 15).Trim();
                    //    qty = decimal.Parse(string2.Substring(minus + 15, 7).Trim());
                    //    minus += part.Length + qty.ToString().Length;
                    //}
                    if (minus == 0)
                    {
                        part = string2.Substring(0, 15); // Extract 15 characters starting from index 0
                        qty = string2.Substring(15, 7);  // Extract 7 characters starting from index 15
                        minus += (part.Length + qty.ToString().Length); // Update 'minus' by adding the lengths of 'part' and 'qty', plus 1
                    }
                    else
                    {
                        part = string2.Substring(minus, 15);     // Extract 15 characters starting from 'minus'
                        qty = string2.Substring(minus + 15, 7);  // Extract 7 characters starting from 'minus + 15'
                        minus += part.Length + qty.ToString().Length;       // Update 'minus' by adding the lengths of 'part' and 'qty'
                    }


                    partNo = part.Trim();

                    // Add to the output list
                    //outputList.Add(new KanbanData
                    //{
                    //    Kanban = inputString,
                    //    TruckNo = truckNo,
                    //    CustomerCode = customerCode,
                    //    ShipToLoc = shipToLoc,
                    //    PointCheck = pointCheck,
                    //    Part = partNo,
                    //    Qty = decimal.Parse(qty),
                    //    Minus = minus,
                    //    Result = string2
                    //});
                    var existingKanban = outputList.FirstOrDefault(k => k.Part == partNo);

                    if (existingKanban != null)
                    {
                        // If the part already exists, update the quantity
                        existingKanban.Qty += decimal.Parse(qty);
                    }
                    else
                    {
                        // If the part does not exist, add a new entry
                        outputList.Add(new KanbanData
                        {
                            Kanban = inputString,
                            TruckNo = truckNo,
                            CustomerCode = customerCode,
                            ShipToLoc = shipToLoc,
                            PointCheck = pointCheck,
                            Part = partNo,
                            Qty = decimal.Parse(qty),
                            Minus = minus,
                            Result = string2
                        });
                    }

                    start++;
                }
            }
            catch
            {

            }
            return outputList;
        }
        public static List<PL_DNHA_MASTER> ReadDNHAMaster()
        {

            try
            {
                mlistDNHA.Clear();
                string filePath = Path.Combine(FilePath, MasterFolder + "/" + DNHMaterFileName);
                if (File.Exists(filePath))
                {
                    string[] lines = File.ReadAllLines(filePath);

                    // Assuming each line follows a format like: UserId,UserName,Password
                    for (int i = 0; i < lines.Length; i++) // Skipping the first line if it's a header
                    {
                        string[] parts = lines[i].Split('$'); // Assuming comma as the separator
                        if (parts.Length >= 1) // Ensure we have 3 parts
                        {
                            PL_DNHA_MASTER plMaster = new PL_DNHA_MASTER
                            {
                                DNHAPartNo = parts[0].Trim(),
                                // Set manufacturing and expiry dates
                                ExpDays = parts[1].Trim(),
                                MFGShipDays = parts[2].Trim(),

                                // Manually setting expiry-related fields
                                IsMfgDate = parts[3].Trim() == "" ? Convert.ToBoolean(false) : Convert.ToBoolean(parts[3].Trim()),  // Assuming it's not expired

                                IsExpDate = parts[4].Trim() == "" ? Convert.ToBoolean(false) : Convert.ToBoolean(parts[4].Trim()),     // Valid product, not expired

                                EXPShipDays = parts[5].Trim(),
                                LotSize = parts[6].Trim(),
                            };
                            mlistDNHA.Add(plMaster);
                        }


                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error reading  file", ex);
            }

            return mlistDNHA;
        }
        public static List<PL_CUSTOMER_MASTER> ReadCustomerMaster()
        {

            try
            {
                mlistAllCustomer.Clear();
                string filePath = Path.Combine(FilePath, MasterFolder + "/" + CustomerMaterFileName);
                if (File.Exists(filePath))
                {
                    string[] lines = File.ReadAllLines(filePath);

                    // Assuming each line follows a format like: UserId,UserName,Password
                    for (int i = 0; i < lines.Length; i++) // Skipping the first line if it's a header
                    {
                        string[] parts = lines[i].Split('$'); // Assuming comma as the separator
                        if (parts.Length >= 2) // Ensure we have 3 parts
                        {
                            PL_CUSTOMER_MASTER plMaster = new PL_CUSTOMER_MASTER
                            {
                                DNHAPartNo = parts[0].Trim(),
                                CustomerPartNo = parts[1].Trim(),
                                CustomerCode = parts[2].Trim()
                            };
                            mlistAllCustomer.Add(plMaster);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error reading file", ex);
            }

            return mlistAllCustomer;
        }
        public static List<PL_SUPPLIER_MASTER> ReadSupplierMaster()
        {

            try
            {
                mlistSupplier.Clear();
                string filePath = Path.Combine(FilePath, MasterFolder + "/" + SupplierMaterFileName);
                if (File.Exists(filePath))
                {
                    string[] lines = File.ReadAllLines(filePath);

                    // Assuming each line follows a format like:
                    for (int i = 0; i < lines.Length; i++) // Skipping the first line if it's a header
                    {
                        string[] parts = lines[i].Split('$'); // Assuming comma as the separator
                        if (parts.Length >= 2) // Ensure we have 3 parts
                        {
                            PL_SUPPLIER_MASTER plMaster = new PL_SUPPLIER_MASTER
                            {
                                DNHAPartNo = parts[0].Trim(),
                                SupplierPartNo = parts[1].Trim(),
                                SupplierCode = parts[2].Trim(),

                                // Set manufacturing and expiry dates
                                ExpDays = parts[3].Trim(),
                                MFGShipDays = parts[4].Trim(),

                                // Manually setting expiry-related fields
                                IsMfgDate = parts[5].Trim() == "" ? Convert.ToBoolean(false) : Convert.ToBoolean(parts[5].Trim()),  // Assuming it's not expired

                                IsExpDate = parts[6].Trim() == "" ? Convert.ToBoolean(false) : Convert.ToBoolean(parts[6].Trim()),     // Valid product, not expired
                                EXPShipDays = parts[7].Trim(),

                                LotQty = parts.Length > 8 ? parts[8].Trim() : null
                            };
                            mlistSupplier.Add(plMaster);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error reading file", ex);
            }

            return mlistSupplier;
        }

        public static List<PL_SUSPECTED_LOT> ReadSuspectedLotMaster()
        {

            try
            {
                mlistSuspectedLot.Clear();
                string filePath = Path.Combine(FilePath, MasterFolder + "/" + NGMaterFileName);
                if (File.Exists(filePath))
                {
                    string[] lines = File.ReadAllLines(filePath);

                    // Assuming each line follows a format like:
                    for (int i = 0; i < lines.Length; i++) // Skipping the first line if it's a header
                    {
                        string[] parts = lines[i].Split('$'); // Assuming comma as the separator
                        if (parts.Length >= 2) // Ensure we have 3 parts
                        {
                            PL_SUSPECTED_LOT plMaster = new PL_SUSPECTED_LOT
                            {
                                DNHAPartNo = parts[0].Trim(),
                                LotNo = parts[1].Trim(),

                            };
                            mlistSuspectedLot.Add(plMaster);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error reading file", ex);
            }

            return mlistSuspectedLot;
        }
        public static List<Login> ReadUserLogin()
        {

            try
            {
                mlistLogin.Clear();
                string filePath = Path.Combine(FilePath, MasterFolder + "/" + LoginFileName);
                if (File.Exists(filePath))
                {
                    string[] lines = File.ReadAllLines(filePath);

                    // Assuming each line follows a format like: UserId,UserName,Password
                    for (int i = 0; i < lines.Length; i++) // Skipping the first line if it's a header
                    {
                        string[] parts = lines[i].Split('$'); // Assuming comma as the separator
                        if (parts.Length == 2) // Ensure we have 3 parts
                        {
                            Login login = new Login
                            {
                                UserId = parts[0].Trim(),
                                Password = parts[1].Trim()
                            };
                            mlistLogin.Add(login);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error reading file", ex);
            }

            return mlistLogin;
        }
        public static string ReadAlertMessage()
        {

            try
            {
                string filePath = Path.Combine(FilePath, MasterFolder + "/" + mAlertMessageFileName);
                if (File.Exists(filePath))
                {
                    string[] lines = File.ReadAllLines(filePath);

                    if (lines.Length > 0)
                    {
                        mAlertMeassage = lines[0];
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error reading file", ex);
            }

            return mAlertMeassage;
        }
        public static void DeleteAlertMessage()
        {

            try
            {
                string filePath = Path.Combine(FilePath, MasterFolder + "/" + mAlertMessageFileName);
                if (File.Exists(filePath))
                {
                    File.Delete(filePath);
                    clsGlobal.mAlertMeassage = "";
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error reading file", ex);
            }


        }
        public static string ReadAlertPasswordMaster()
        {

            try
            {
                string filePath = Path.Combine(FilePath, MasterFolder + "/" + mAlertPassFileName);
                if (File.Exists(filePath))
                {
                    string[] lines = File.ReadAllLines(filePath);

                    if (lines.Length > 0)
                    {
                        mAlertPassword = lines[0];
                    }
                }
            }
            catch (Exception ex)
            {
                //throw new Exception("Error reading file", ex);
            }

            return mAlertPassword;
        }

        public static List<PL_CUST_EXP_MASTER> ReadCUSTExpMaster()
        {

            try
            {
                mlistCustWiseExpiry.Clear();
                string filePath = Path.Combine(FilePath, MasterFolder + "/" + CustomerWiseExpiry);
                if (File.Exists(filePath))
                {
                    string[] lines = File.ReadAllLines(filePath);

                    // Assuming each line follows a format like: UserId,UserName,Password
                    for (int i = 0; i < lines.Length; i++) // Skipping the first line if it's a header
                    {
                        string[] parts = lines[i].Split('$'); // Assuming comma as the separator
                        if (parts.Length >= 1) // Ensure we have 3 parts
                        {
                            PL_CUST_EXP_MASTER plMaster = new PL_CUST_EXP_MASTER
                            {
                                CustomerCode = parts[0].Trim(),
                                DNHAPartNo = parts[1].Trim(),
                                // Set manufacturing and expiry dates
                                ExpDays = parts[2].Trim(),
                                MFGShipDays = parts[3].Trim(),

                                // Manually setting expiry-related fields
                                IsMfgDate = parts[4].Trim() == "" ? Convert.ToBoolean(false) : Convert.ToBoolean(parts[4].Trim()),  // Assuming it's not expired

                                IsExpDate = parts[5].Trim() == "" ? Convert.ToBoolean(false) : Convert.ToBoolean(parts[5].Trim()),     // Valid product, not expired

                                EXPShipDays = parts[6].Trim(),
                            };
                            mlistCustWiseExpiry.Add(plMaster);
                        }


                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error reading  file", ex);
            }

            return mlistCustWiseExpiry;
        }

        public static void ReplaceInFile(
                   string FilePath, string SearchText, string ReplaceText)
        {
            try
            {
                string _Content = string.Empty;
                using (StreamReader reader = new StreamReader(FilePath))
                {
                    _Content = reader.ReadToEnd();
                    reader.Close();
                }

                _Content = Regex.Replace(_Content, SearchText, ReplaceText);
                using (StreamWriter writer = new StreamWriter(FilePath))
                {
                    writer.Write(_Content);
                    writer.Close();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        public static void WriteNGMSGToFile(string filePath, string content)
        {
            // Using StreamWriter to write to the file
            using (StreamWriter writer = new StreamWriter(filePath, false)) // 'true' appends to the file
            {
                writer.WriteLine(content);
            }
        }
        public static void WriteToFile(string filePath, string content)
        {
            // Using StreamWriter to write to the file
            using (StreamWriter writer = new StreamWriter(filePath, true)) // 'true' appends to the file
            {
                writer.WriteLine(content);
            }
        }
        public static void WriteToFTPFile(string filePath, string content)
        {
            // Using StreamWriter to write to the file
            using (StreamWriter writer = new StreamWriter(filePath, true)) // 'true' appends to the file
            {
                writer.Write(content);
            }
        }
        public static string ReadFromFile(string filePath)
        {
            // Using StreamReader to read from the file
            using (StreamReader reader = new StreamReader(filePath))
            {
                return reader.ReadToEnd();
            }
        }
        public static List<string> BindSILDicName(string directoryPath)
        {
            List<string> list = new List<string>();
            try
            {

                if (Directory.Exists(directoryPath))
                {
                    // Get all files from the directory
                    string[] files = Directory.GetDirectories(directoryPath);

                    // Clear existing items in the ComboBox
                    list.Clear();

                    // Add file names (without full paths) to the ComboBox
                    foreach (var file in files)
                    {
                        list.Add(Path.GetDirectoryName(file).Trim().ToUpper().Replace(".TXT", ""));
                    }
                }
                else
                {
                    throw new DirectoryNotFoundException("Directory not found at the given path.");
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return list;
        }


        #region SIL SCANNING
        public static void WriteSILFileFromList(string filePath, List<ViewSILScanData> dataList)
        {
            // Ensure the file path is valid
            if (string.IsNullOrEmpty(filePath))
            {
                throw new ArgumentException("Invalid file path.");
            }

            // Create or overwrite the file
            using (StreamWriter writer = new StreamWriter(filePath, false))  // 'false' to overwrite the file if it exists
            {
                foreach (var item in dataList)
                {
                    string line = $"{item.PartNo}~{item.Qty}~{item.ScanQty}~{item.Balance}~{item.Bin}";
                    writer.WriteLine(line);
                }
            }
        }
        public static List<ViewSILScanData> ReadSILFileToList(string filePath)
        {
            List<ViewSILScanData> list = new List<ViewSILScanData>();

            // Ensure the file exists before attempting to read
            if (!File.Exists(filePath))
            {
                throw new FileNotFoundException("The specified file was not found.");
            }

            // Open the file for reading
            using (StreamReader reader = new StreamReader(filePath))
            {
                string line;

                // Read the file line by line
                while ((line = reader.ReadLine()) != null)
                {
                    // Split the line into parts assuming CSV format (Comma-Separated Values)
                    string[] parts = line.Split('~');

                    // Assuming the file has columns: PartNo, Qty, ScanQty, Balance (adjust as necessary)
                    if (parts.Length >= 4)
                    {
                        ViewSILScanData data = new ViewSILScanData
                        {
                            PartNo = parts[0],
                            Qty = parts[1],
                            ScanQty = parts[2],
                            Balance = parts[3],
                            Bin = parts[4],
                        };

                        // Add the parsed object to the list
                        list.Add(data);
                    }
                }
            }

            return list;
        }
        public static List<ViewFTPScanData> ReadSILFTPFileToList(string filePath)
        {
            List<ViewFTPScanData> list = new List<ViewFTPScanData>();

            // Ensure the file exists before attempting to read
            if (!File.Exists(filePath))
            {
                throw new FileNotFoundException("The specified file was not found.");
            }

            // Open the file for reading
            using (StreamReader reader = new StreamReader(filePath))
            {
                string line;

                // Read the file line by line
                while ((line = reader.ReadLine()) != null)
                {
                    // Split the line into parts assuming CSV format (Comma-Separated Values)
                    string[] parts = line.Split('~');
                    int BinQty = 0;
                    int BinNo = 0;
                    // Assuming the file has columns: PartNo, Qty, ScanQty, Balance (adjust as necessary)
                    if (parts.Length >= 4)
                    {
                        if (mlistDNHA.Count > 0)
                        {

                            try
                            {
                                BinQty = Convert.ToInt32(mlistDNHA.Where(x => x.DNHAPartNo == parts[0]).Select(m => m.LotSize).FirstOrDefault());
                                BinNo = Convert.ToInt32(parts[2]) / BinQty;
                            }
                            catch
                            {
                                BinQty = 0;
                            }
                        }
                        ViewFTPScanData data = new ViewFTPScanData
                        {
                            PartNo = parts[0],
                            SILQty = parts[1],
                            DensoQty = parts[2],
                            CustQty = parts[2],
                            Bin = Convert.ToString(BinNo)
                        };

                        // Add the parsed object to the list
                        list.Add(data);
                    }
                }
            }

            return list;
        }

        public static List<SILKanbanBarcodeScannedData> ReadSILScannedFileToList(string filePath)
        {
            List<SILKanbanBarcodeScannedData> list = new List<SILKanbanBarcodeScannedData>();

            // Ensure the file exists before attempting to read
            if (!File.Exists(filePath))
            {
                throw new FileNotFoundException("The specified file was not found.");
            }

            // Open the file using StreamReader and read the entire content
            using (StreamReader reader = new StreamReader(filePath))
            {
                // Read all the file content at once
                string fileContent = reader.ReadToEnd();

                // Split the content into lines by newline characters (handles different OS line endings)
                string[] lines = fileContent.Split(new[] { "\r\n", "\n", "\r" }, StringSplitOptions.None);

                // Process each line separately
                foreach (string line in lines)
                {
                    // Skip empty lines
                    if (string.IsNullOrWhiteSpace(line))
                    {
                        continue;
                    }

                    // Split the line by the '~' delimiter
                    string[] parts = line.Split('~');

                    // Assuming the file has columns: PartNo, Barcode1, Barcode2
                    if (parts.Length >= 1)
                    {
                        SILKanbanBarcodeScannedData data = new SILKanbanBarcodeScannedData();
                        data.SILBarcode = parts[0];
                        data.Barcode1 = parts[1].Replace("^", "\n");

                        // Handle Barcode2 with a condition in case it's missing
                        data.Barcode2 = parts.Length > 2 ? parts[2].Replace("^", "\n") : string.Empty;
                        data.isMatchBarcode1SeqNo = parts == null ? false : Convert.ToBoolean(parts[18].Trim());
                        data.Barcode1SEQNo = parts.Length > 2 ? parts[19].Trim() : string.Empty;

                        data.isMatchBarcode2SeqNo = parts == null ? false : Convert.ToBoolean(parts[20].Trim());
                        data.Barcode2SEQNo = parts.Length > 2 ? parts[21].Trim() : string.Empty;

                        // Add the parsed object to the list
                        list.Add(data);
                    }
                }
            }

            return list;
        }

        public static string ReadSILBarcodeFromFile(string filePath)
        {
            string strBarcode = "";

            // Ensure the file exists before attempting to read
            if (!File.Exists(filePath))
            {
                throw new FileNotFoundException("The specified file was not found.");
            }

            // Open the file using StreamReader and read the entire content
            using (StreamReader reader = new StreamReader(filePath))
            {
                // Read all the file content at once
                string fileContent = reader.ReadToEnd();

                // Split the content into lines by newline characters (handles different OS line endings)
                string[] lines = fileContent.Split(new[] { "\r\n", "\n", "\r" }, StringSplitOptions.None);

                // Process each line separately
                foreach (string line in lines)
                {
                    // Skip empty lines
                    if (string.IsNullOrWhiteSpace(line))
                    {
                        continue;
                    }

                    // Split the line by the '~' delimiter
                    string[] parts = line.Split('~');

                    // Assuming the file has columns: PartNo, Barcode1, Barcode2
                    if (parts.Length >= 0)
                    {
                        strBarcode = parts[0];
                    }
                }
            }

            return strBarcode;
        }

        public static string ReplaceNewlinesWithCaret(string input)
        {
            if (string.IsNullOrEmpty(input))
            {
                return input; // Return the original string if it's null or empty
            }

            // Replace all newline variations (\r\n, \r, \n) with '^'
            return input.Replace("\r\n", "^").Replace("\r", "^").Replace("\n", "^");
        }
        #endregion

        #region BindPatternData

        public static List<PL_PATTERN> ReadDNHAPatternFile()
        {
            try
            {
                mlistDNHAPattern.Clear();
                string filePath = Path.Combine(FilePath, MasterFolder + "/" + mPatternPath + "/" + mDNHADir + "/" + DNHAPatternFileName);
                if (File.Exists(filePath))
                {
                    string[] lines = File.ReadAllLines(filePath);

                    // Assuming each line follows a format like: UserId,UserName,Password
                    for (int i = 0; i < lines.Length; i++) // Skipping the first line if it's a header
                    {
                        string[] parts = lines[i].Split('$'); // Assuming comma as the separator
                        if (parts.Length >= 2) // Ensure we have 3 parts
                        {
                            PL_PATTERN login = new PL_PATTERN();
                            login.Code = parts[0].Trim();
                            login.Name = parts[1].Trim();
                            login.Patterns = parts[2].Trim();
                            login.Seperater = parts[3];
                            login.Fields = parts[4].Trim();
                            string[] fields = parts[4].Split(',');

                            foreach (var field in fields)
                            {
                                // Split each field by '-'
                                string[] fieldParts = field.Split('-');

                                if (fieldParts.Length > 1)
                                {
                                    // Use the first part as the key (e.g., "PartNo")
                                    string key = fieldParts[0];

                                    // Dynamically concatenate the rest as the value
                                    string value = string.Join("-", fieldParts, 1, fieldParts.Length - 1);

                                    // Add to the tuple
                                    login.keyValueData.Add(new Tuple<string, string>(key, value));


                                }
                            }
                            mlistDNHAPattern.Add(login);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error reading login file", ex);
            }

            return mlistDNHAPattern;
        }
        public static List<PL_PATTERN> ReadCutomerPatternFile()
        {
            try
            {
                mlistCustomerPattern.Clear();
                string filePath = Path.Combine(FilePath, MasterFolder + "/" + mPatternPath + "/" + mCustomerDir + "/" + CustomerPatternFileName);
                if (File.Exists(filePath))
                {
                    string[] lines = File.ReadAllLines(filePath);

                    // Assuming each line follows a format like: UserId,UserName,Password
                    for (int i = 0; i < lines.Length; i++) // Skipping the first line if it's a header
                    {
                        string[] parts = lines[i].Split('$'); // Assuming comma as the separator
                        if (parts.Length >= 2) // Ensure we have 3 parts
                        {
                            PL_PATTERN login = new PL_PATTERN();
                            login.Code = parts[0].Trim();
                            login.Name = parts[1].Trim();
                            login.Patterns = parts[2].Trim();
                            login.ThreePointCheckDigit = parts[3].Trim();
                            login.Seperater = parts[4];
                            login.Fields = parts[5].Trim();
                            string[] fields = parts[5].Split(',');

                            foreach (var field in fields)
                            {
                                // Split each field by '-'
                                string[] fieldParts = field.Split('-');

                                if (fieldParts.Length > 1)
                                {
                                    // Use the first part as the key (e.g., "PartNo")
                                    string key = fieldParts[0];

                                    // Dynamically concatenate the rest as the value
                                    string value = string.Join("-", fieldParts, 1, fieldParts.Length - 1);

                                    // Add to the tuple
                                    login.keyValueData.Add(new Tuple<string, string>(key, value));
                                }
                            }
                            mlistCustomerPattern.Add(login);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error reading login file", ex);
            }

            return mlistCustomerPattern;
        }
        public static List<PL_PATTERN> ReadSupplierPatternFile()
        {
            try
            {
                mlistSupplierPattern.Clear();
                string filePath = Path.Combine(FilePath, MasterFolder + "/" + mPatternPath + "/" + mSupplierDir + "/" + SupplierPatternFileName);
                if (File.Exists(filePath))
                {
                    string[] lines = File.ReadAllLines(filePath);

                    // Assuming each line follows a format like: UserId,UserName,Password
                    for (int i = 0; i < lines.Length; i++) // Skipping the first line if it's a header
                    {
                        string[] parts = lines[i].Split('$'); // Assuming comma as the separator
                        if (parts.Length >= 2) // Ensure we have 3 parts
                        {
                            PL_PATTERN login = new PL_PATTERN();
                            login.Code = parts[0].Trim();
                            login.Name = parts[1].Trim();
                            login.Patterns = parts[2].Trim();
                            login.Seperater = parts[3];
                            login.Fields = parts[4].Trim();
                            string[] fields = parts[4].Split(',');

                            foreach (var field in fields)
                            {
                                // Split each field by '-'
                                string[] fieldParts = field.Split('-');

                                if (fieldParts.Length > 1)
                                {
                                    // Use the first part as the key (e.g., "PartNo")
                                    string key = fieldParts[0];

                                    // Dynamically concatenate the rest as the value
                                    string value = string.Join("-", fieldParts, 1, fieldParts.Length - 1);

                                    // Add to the tuple
                                    login.keyValueData.Add(new Tuple<string, string>(key, value));
                                }
                            }
                            mlistSupplierPattern.Add(login);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error reading login file", ex);
            }

            return mlistSupplierPattern;
        }


        #endregion

        #region GenericFunction To Get Qty if it has comma
        public static void ParseCommaBarcode(string barcode, out string part, out int qty)
        {
            // Define regex patterns for part number and quantity
            string partPattern = @"[A-Za-z0-9\-]+"; // Alphanumeric parts
            string qtyPattern = @",\d{1,3},"; // Quantities are 1 to 3 digits, enclosed by commas

            part = "";
            qty = 0;

            // Split barcode by common delimiters
            string[] elements = barcode.Split(new char[] { ',', '-', '/', ' ' }, StringSplitOptions.RemoveEmptyEntries);

            foreach (string element in elements)
            {
                // If it's alphanumeric and longer than 5 characters, assume it's a part number
                if (Regex.IsMatch(element, partPattern) && element.Length >= 5)
                {
                    part = element;
                }
            }

            // Use regex to find the quantity enclosed by commas
            Match qtyMatch = Regex.Match(barcode, qtyPattern);
            if (qtyMatch.Success)
            {
                string qtyStr = qtyMatch.Value.Trim(','); // Remove the commas around the quantity
                if (int.TryParse(qtyStr, out int parsedQty))
                {
                    qty = parsedQty;
                }
            }


        }
        #endregion
        public static void ParseBarcode(string barcode, out string part, out int qty)
        {
            // Define regex patterns for part number and quantity
            string partPattern = @"[A-Za-z0-9\-]+"; // Alphanumeric parts
            string qtyPattern = @",\d{1,3},"; // Quantities are 1 to 3 digits, enclosed by commas

            part = "";
            qty = 0;

            // Split barcode by common delimiters
            string[] elements = barcode.Split(new char[] { ',', '-', '/', ' ' }, StringSplitOptions.RemoveEmptyEntries);

            foreach (string element in elements)
            {
                // If it's alphanumeric and longer than 5 characters, assume it's a part number
                if (Regex.IsMatch(element, partPattern) && element.Length >= 5)
                {
                    part = element;
                }
            }

            // Use regex to find the quantity enclosed by commas
            Match qtyMatch = Regex.Match(barcode, qtyPattern);
            if (qtyMatch.Success)
            {
                string qtyStr = qtyMatch.Value.Trim(','); // Remove the commas around the quantity
                if (int.TryParse(qtyStr, out int parsedQty))
                {
                    qty = parsedQty;
                }
            }


        }
        //***************************************
        public static void ShowMessage(string msg, Activity activity, MessageTitle MsgTitle)
        {
            AlertDialog.Builder builder = new AlertDialog.Builder(activity);
            builder.SetTitle(MsgTitle.ToString());
            builder.SetMessage(msg);
            builder.SetCancelable(false);
            builder.SetPositiveButton("OK", (sender, e) =>
            {
                //activity.Finish();
            });
            builder.Show();
        }

        public static void showToastNGMessage(string Message, Context con)
        {
            string message = "<b><font color='#FFFFFF'>" + Message + "</font></b>";
            Toast tost = Toast.MakeText(con, Html.FromHtml(message), ToastLength.Long);
            View v = tost.View;

            v.SetBackgroundColor(Android.Graphics.Color.Red);
            if (con is Activity act)
            {
                if (act.Class.Name.Contains("SILScanning") || act.Class.Name.Contains("Fraction") || act.Class.Name.Contains("Reversal"))
                {
                    string filePath = Path.Combine(FilePath, MasterFolder + "/" + mAlertMessageFileName);
                    DeleteAlertMessage();
                    WriteNGMSGToFile(filePath, Message);
                    ReadAlertMessage();
                }

            }
            tost.Show();
        }
        public static void showToastOKMessage(string Message, Context con)
        {
            Toast tost = Toast.MakeText(con, Message, ToastLength.Long);
            View v = tost.View;

            v.SetBackgroundColor(Android.Graphics.Color.Green);
            tost.Show();
        }

        private static string GetLogFilePath()
        {
            string logDir;

            if (Build.VERSION.SdkInt >= BuildVersionCodes.O)
            {
                logDir = Application.Context.GetExternalFilesDir(null).AbsolutePath;
            }
            else
            {
                logDir = Android.OS.Environment.ExternalStorageDirectory.AbsolutePath;
            }

            // Create "Logs" folder inside the directory
            string fullDir = Path.Combine(clsGlobal.FilePath, clsGlobal.LogTag);

            if (!Directory.Exists(fullDir))
                Directory.CreateDirectory(fullDir);

            return Path.Combine(fullDir, LogFileName);
        }

        public static void WriteLog(string message)
        {
            try
            {
                string logFilePath = GetLogFilePath();

                // Get process name
                string processName = Application.Context.ApplicationInfo.ProcessName;

                // Get caller method and class
                var stackTrace = new StackTrace();
                var frame = stackTrace.GetFrame(1); // 1 = caller
                var method = frame?.GetMethod();
                string className = method?.DeclaringType?.Name ?? "UnknownClass";
                string methodName = method?.Name ?? "UnknownMethod";

                // Build log entry
                string logMessage = $"{DateTime.Now:yyyy-MM-dd HH:mm:ss} | " +
                                     $"User: {clsGlobal.mUserId} | " +
                                     $"Process: {processName} | " +
                                     $"Function: {className}.{methodName} | " +
                                     $"Message: {message}{System.Environment.NewLine}";

                File.AppendAllText(logFilePath, logMessage);

            }
            catch (Exception ex)
            {
                Log.Error(LogTag, "Failed to write log: " + ex.Message);
            }
        }
        public static List<PL_LOG_INFO> mReadLogs()
        {
            var entries = new List<PL_LOG_INFO>();
            string logFilePath = GetLogFilePath();

            if (!File.Exists(logFilePath))
                return entries;

            string[] lines = File.ReadAllLines(logFilePath);

            var logPattern = new Regex(@"^(?<timestamp>\d{4}-\d{2}-\d{2} \d{2}:\d{2}:\d{2}) \| " +
                                       @"User: (?<user>.*?) \| " +
                                       @"Process: (?<process>.*?) \| " +
                                       @"Function: (?<function>.*?) \| " +
                                       @"Message: (?<message>.*)$");

            foreach (var line in lines)
            {
                var match = logPattern.Match(line);
                if (match.Success)
                {
                    entries.Add(new PL_LOG_INFO
                    {
                        Timestamp = DateTime.Parse(match.Groups["timestamp"].Value),
                        User = match.Groups["user"].Value,
                        Process = match.Groups["process"].Value,
                        Function = match.Groups["function"].Value,
                        Message = match.Groups["message"].Value
                    });
                }
            }

            return entries;
        }
    }





}
