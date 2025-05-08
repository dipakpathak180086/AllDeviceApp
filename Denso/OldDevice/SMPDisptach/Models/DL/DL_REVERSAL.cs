
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

    public class DL_REVERSAL
    {
        SqlHelper _SqlHelper = new SqlHelper();
        #region MyFuncation
        /// <summary>
        /// Execute Operation 
        /// </summary>
        /// <returns></returns>
        public DataSet DL_ExecuteTask(PL_REVERSAL obj)
        {
            _SqlHelper = new SqlHelper();
            try
            {
                SqlParameter[] param = new SqlParameter[14];

                param[0] = new SqlParameter("@TYPE", SqlDbType.VarChar, 100);
                param[0].Value = obj.DbType;
                param[1] = new SqlParameter("@SIL_CODE", SqlDbType.VarChar, 1000);
                param[1].Value = obj.SIL_NO;
                param[2] = new SqlParameter("@SIL_BARCODE", SqlDbType.VarChar, 1000);
                param[2].Value = obj.SIL_BARCODE;
                param[3] = new SqlParameter("@BARCODE1", SqlDbType.VarChar, 100);
                param[3].Value = obj.DNHA_BARCODE;
                param[4] = new SqlParameter("@CREATED_BY", SqlDbType.VarChar, 100);
                param[4].Value = obj.CreatedBy;
                return _SqlHelper.ExecuteDataset(clsGlobal.mMainSqlConString, CommandType.StoredProcedure, "[PRC_REVERSAL]", param);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion      

    }
}
