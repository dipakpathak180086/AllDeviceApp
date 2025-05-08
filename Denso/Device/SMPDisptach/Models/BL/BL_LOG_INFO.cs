
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMPDisptach
{
    public class BL_LOG_INFO
    {
        public DataSet BL_ExecuteTask(PL_LOG_INFO objPl)
        {
            DL_LOG_INFO objDl = new DL_LOG_INFO();
            return objDl.DL_ExecuteTask(objPl);
        }


    }
}
