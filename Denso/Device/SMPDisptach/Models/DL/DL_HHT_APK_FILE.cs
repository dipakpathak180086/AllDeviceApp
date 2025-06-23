
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

    public class DL_HHT_APK_FILE
    {
        SqlHelper _SqlHelper = new SqlHelper();
        #region MyFuncation
        /// <summary>
        /// Execute Operation 
        /// </summary>
        /// <returns></returns>
        public DataTable DL_ExecuteTask(PL_HHT_APK_FILE obj)
        {
            _SqlHelper = new SqlHelper();
            try
            {
                SqlParameter[] param = new SqlParameter[14];

                param[0] = new SqlParameter("@TYPE", SqlDbType.VarChar, 100);
                param[0].Value = obj.DbType;
                param[1] = new SqlParameter("@FILE_NAME", SqlDbType.VarChar, 50);
                param[1].Value = obj.FileName;
                param[2] = new SqlParameter("@VERSION", SqlDbType.VarChar, 50);
                param[2].Value = obj.Version;
                param[3] = new SqlParameter("@FILE_CONTENT", SqlDbType.VarBinary);
                if (obj.FileData != null)
                {
                    param[3].Value = obj.FileData;
                }
                else
                {
                    param[3].Value = DBNull.Value;
                }
                param[4] = new SqlParameter("@CREATED_BY", SqlDbType.VarChar, 50);
                param[4].Value = obj.CreatedBy;
                return _SqlHelper.ExecuteDataset(clsGlobal.mMainSqlConString, CommandType.StoredProcedure, "[PRC_DOWNLOAD_APK_FILES]", param).Tables[0];
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion      

    }
}
