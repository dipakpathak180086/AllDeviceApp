
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

    public class DL_HHT_DOWNLOAD
    {
        SqlHelper _SqlHelper = new SqlHelper();
        #region MyFuncation
        /// <summary>
        /// Execute Operation 
        /// </summary>
        /// <returns></returns>
        public DataTable DL_ExecuteTask(PL_HHT_DOWNLOAD obj)
        {
            _SqlHelper = new SqlHelper();
            try
            {
                SqlParameter[] param = new SqlParameter[14];

                param[0] = new SqlParameter("@TYPE", SqlDbType.VarChar, 100);
                param[0].Value = obj.DbType;
                param[1] = new SqlParameter("@SIL_CODE", SqlDbType.VarChar, 100);
                param[1].Value = obj.SIL_CODE;
                param[2] = new SqlParameter("@PART_NO", SqlDbType.VarChar, 100);
                param[2].Value = obj.PART_NO;
                param[3] = new SqlParameter("@TOTAL_QTY", SqlDbType.VarChar, 100);
                param[3].Value = obj.TOTAL_QTY;
                param[4] = new SqlParameter("@SCAN_QTY", SqlDbType.VarChar, 100);
                param[4].Value = obj.SCAN_QTY;
                param[5] = new SqlParameter("@BAL_QTY", SqlDbType.VarChar, 100);
                param[5].Value = obj.BAL_QTY;
                param[6] = new SqlParameter("@CP_PROCESS", SqlDbType.VarChar, 100);
                param[6].Value = obj.CP_PROCESS;
                param[7] = new SqlParameter("@SIL_BARCODE", SqlDbType.VarChar, 5000000);
                param[7].Value = obj.SIL_BARCODE;
                param[8] = new SqlParameter("@BARCODE1", SqlDbType.VarChar, 5000000);
                param[8].Value = obj.BARCODE1;
                param[9] = new SqlParameter("@BARCODE2", SqlDbType.VarChar, 5000000);
                param[9].Value = obj.BARCODE2;
                param[10] = new SqlParameter("@PATTERN_CODE", SqlDbType.VarChar, 100);
                param[10].Value = obj.PATTERN_CODE;
                param[11] = new SqlParameter("@CREATED_BY", SqlDbType.VarChar, 100);
                param[11].Value = obj.CreatedBy;
                return _SqlHelper.ExecuteDataset(clsGlobal.mMainSqlConString, CommandType.StoredProcedure, "[PRC_SIL_DISPATCH]", param).Tables[0];
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion      

    }
}
