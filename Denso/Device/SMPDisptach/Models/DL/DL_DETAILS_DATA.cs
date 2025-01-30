
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLLib;

namespace SMPDisptach
{

    public class DL_DETAILS_DATA
    {
        SqlHelper _SqlHelper = new SqlHelper();
        #region MyFuncation
        /// <summary>
        /// Execute Operation 
        /// </summary>
        /// <returns></returns>
        public DataTable DL_ExecuteTask(PL_DETAILS_DATA obj)
        {
            _SqlHelper = new SqlHelper();
            try
            {
                SqlParameter[] param = new SqlParameter[30];
                param[0] = new SqlParameter("@TYPE", SqlDbType.VarChar, 50);
                param[0].Value = obj.DbType;
                param[1] = new SqlParameter("@SIL_NO", SqlDbType.VarChar, 50);
                param[1].Value = obj.SILNo;
                param[2] = new SqlParameter("@SIL_BARCODE", SqlDbType.VarChar, -1); // MAX
                param[2].Value = obj.SILBarcode;
                param[3] = new SqlParameter("@DNHA_SUP_BARCODE", SqlDbType.VarChar, -1); // MAX
                param[3].Value = obj.DNHASupBarcode;
                param[4] = new SqlParameter("@CUS_BARCODE", SqlDbType.VarChar, -1); // MAX
                param[4].Value = obj.CUSBarcode;
                param[5] = new SqlParameter("@PARTNO", SqlDbType.VarChar, 50);
                param[5].Value = obj.PartNo;
                param[6] = new SqlParameter("@CUSTPART", SqlDbType.VarChar, 50);
                param[6].Value = obj.CustPart;
                param[7] = new SqlParameter("@QTY", SqlDbType.VarChar, 50);
                param[7].Value = obj.Qty;
                param[8] = new SqlParameter("@EXTCHAR", SqlDbType.VarChar, 50);
                param[8].Value = obj.ExtChar;
                param[9] = new SqlParameter("@PROCESSCODE", SqlDbType.VarChar, 50);
                param[9].Value = obj.ProcessCode;
                param[10] = new SqlParameter("@TRUCKNO", SqlDbType.VarChar, 50);
                param[10].Value = obj.TruckNo;
                param[11] = new SqlParameter("@SHIPTO", SqlDbType.VarChar, 50);
                param[11].Value = obj.ShipTo;
                param[12] = new SqlParameter("@CUSTCODE", SqlDbType.VarChar, 50);
                param[12].Value = obj.CustCode;
                param[13] = new SqlParameter("@SEQUENCENO", SqlDbType.VarChar, 50);
                param[13].Value = obj.SequenceNo;
                param[14] = new SqlParameter("@CUSTSEQNO", SqlDbType.VarChar, 50);
                param[14].Value = obj.CustSeqNo;
                param[15] = new SqlParameter("@USERID", SqlDbType.VarChar, 50);
                param[15].Value = obj.UserId;
                param[16] = new SqlParameter("@SILSCANNEDON", SqlDbType.VarChar, 50);
                param[16].Value = obj.SILScannedOn;
                param[17] = new SqlParameter("@DNHASCANNEDON", SqlDbType.VarChar, 50);
                param[17].Value = obj.DNHAScannedOn;
                param[18] = new SqlParameter("@CUSTSCANNEDON", SqlDbType.VarChar, 50);
                param[18].Value = obj.CustScannedOn;
                param[19] = new SqlParameter("@DNHAPATTERN", SqlDbType.VarChar, 50);
                param[19].Value = obj.DNHAPattern;
                param[20] = new SqlParameter("@MATCHBARCODE1SEQNO", SqlDbType.Bit);
                param[20].Value = obj.MatchBarcode1SeqNo;
                param[21] = new SqlParameter("@BARCODE1SEQNO", SqlDbType.VarChar, 50);
                param[21].Value = obj.Barcode1SeqNo;
                param[22] = new SqlParameter("@MATCHBARCODE2SEQNO", SqlDbType.Bit);
                param[22].Value = obj.MatchBarcode2SeqNo;
                param[23] = new SqlParameter("@BARCODE2SEQNO", SqlDbType.VarChar, 50);
                param[23].Value = obj.Barcode2SeqNo;
                param[24] = new SqlParameter("@SCANNEDBY", SqlDbType.VarChar, 50);
                param[24].Value = clsGlobal.mUserId;
                return _SqlHelper.ExecuteDataset(clsGlobal.mMainSqlConString, CommandType.StoredProcedure, "[PRC_SIL_DETAILS_DATA]", param).Tables[0];
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion      

    }
}
