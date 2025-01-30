
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

    public class DL_FRACTION
    {
        SqlHelper _SqlHelper = new SqlHelper();
        #region MyFuncation
        /// <summary>
        /// Execute Operation 
        /// </summary>
        /// <returns></returns>
        public DataTable DL_ExecuteTask(PL_FRACTION obj)
        {
            _SqlHelper = new SqlHelper();
            try
            {
                SqlParameter[] param = new SqlParameter[14];

                param[0] = new SqlParameter("@TYPE", SqlDbType.VarChar, 100);
                param[0].Value = obj.DbType;
                param[1] = new SqlParameter("@PART_NO", SqlDbType.VarChar, 1000);
                param[1].Value = obj.PartNo;
                param[2] = new SqlParameter("@MASTER_KANBAN", SqlDbType.VarChar, 1000);
                param[2].Value = obj.MasterKanban;
                param[3] = new SqlParameter("@MASTER_QTY", SqlDbType.VarChar, 100);
                param[3].Value = obj.MasterQty;
                param[4] = new SqlParameter("@CHILD_KANBAN", SqlDbType.VarChar, 1000);
                param[4].Value = obj.ChildKanban;
                param[5] = new SqlParameter("@SCAN_QTY", SqlDbType.VarChar, 100);
                param[5].Value = obj.ChildQty;
                param[6] = new SqlParameter("@CREATED_BY", SqlDbType.VarChar, 100);
                param[6].Value = obj.CreatedBy;
                return _SqlHelper.ExecuteDataset(clsGlobal.mMainSqlConString, CommandType.StoredProcedure, "[PRC_FRACTION_PROCEES]", param).Tables[0];
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion      

    }
}
