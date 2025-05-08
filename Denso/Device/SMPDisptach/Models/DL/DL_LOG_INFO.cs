
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

    public class DL_LOG_INFO
    {
        SqlHelper _SqlHelper = new SqlHelper();
        #region MyFuncation
        /// <summary>
        /// Execute Operation 
        /// </summary>
        /// <returns></returns>
        public DataSet DL_ExecuteTask(PL_LOG_INFO obj)
        {
            _SqlHelper = new SqlHelper();
            try
            {
                SqlParameter[] param = new SqlParameter[14];

                param[0] = new SqlParameter("@TYPE", SqlDbType.VarChar, 100);
                param[0].Value = obj.DbType;
                param[1] = new SqlParameter("@DATE_TIME", SqlDbType.VarChar, 1000);
                param[1].Value = obj.Timestamp;
                param[2] = new SqlParameter("@USER_INFO", SqlDbType.VarChar, 1000);
                param[2].Value = obj.User;
                param[3] = new SqlParameter("@PROCESS", SqlDbType.VarChar, 100);
                param[3].Value = obj.Process;
                param[4] = new SqlParameter("@FUNCTION", SqlDbType.VarChar, 100);
                param[4].Value = obj.Function;
                param[5] = new SqlParameter("@MESSAGE", SqlDbType.VarChar, 500000);
                param[5].Value = obj.Message;
                param[6] = new SqlParameter("@CREATED_BY", SqlDbType.VarChar, 100);
                param[6].Value = obj.CreatedBy;
                return _SqlHelper.ExecuteDataset(clsGlobal.mMainSqlConString, CommandType.StoredProcedure, "[PRC_HHT_LOG_INFO]", param);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion      

    }
}
