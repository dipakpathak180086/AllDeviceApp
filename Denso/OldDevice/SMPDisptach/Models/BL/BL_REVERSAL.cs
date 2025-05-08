
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMPDisptach
{
    public class BL_REVERSAL
    {
        public DataSet BL_ExecuteTask(PL_REVERSAL objPl)
        {
            DL_REVERSAL objDl = new DL_REVERSAL();
            return objDl.DL_ExecuteTask(objPl);
        }


    }
}
